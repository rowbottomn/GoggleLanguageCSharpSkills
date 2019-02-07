using System;
using System.Collections.Generic;
using Google.Cloud.VideoIntelligence.V1;

namespace VideoIntApiDemo
{
    
    public static object TranscribeVideo(string uri)
    {
        Console.WriteLine("Processing video for speech transcription.");

        var client = VideoIntelligenceServiceClient.Create();
        var request = new AnnotateVideoRequest
        {
            InputUri = uri,
            Features = { Feature.SpeechTranscription },
            VideoContext = new VideoContext
            {
                SpeechTranscriptionConfig = new SpeechTranscriptionConfig
                {
                    LanguageCode = "en-US",
                    EnableAutomaticPunctuation = true
                }
            },
        };
        var op = client.AnnotateVideo(request).PollUntilCompleted();

        // There is only one annotation result since only one video is
        // processed.
        var annotationResults = op.Result.AnnotationResults[0];
        foreach (var transcription in annotationResults.SpeechTranscriptions)
        {
            // The number of alternatives for each transcription is limited
            // by SpeechTranscriptionConfig.MaxAlternatives.
            // Each alternative is a different possible transcription
            // and has its own confidence score.
            foreach (var alternative in transcription.Alternatives)
            {
                Console.WriteLine("Alternative level information:");

                Console.WriteLine($"Transcript: {alternative.Transcript}");
                Console.WriteLine($"Confidence: {alternative.Confidence}");

                foreach (var wordInfo in alternative.Words)
                {
                    Console.WriteLine($"\t{wordInfo.StartTime} - " +
                                    $"{wordInfo.EndTime}:" +
                                    $"{wordInfo.Word}");
                }
            }
        }

        return 0;
    }
}
