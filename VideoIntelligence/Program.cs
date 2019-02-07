using System;
using System.Collections.Generic;
using Google.Cloud.VideoIntelligence.V1;

namespace VideoIntApiDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = VideoIntelligenceServiceClient.Create();
            var request = new AnnotateVideoRequest
            {
                //InputUri = "gs://cloudmleap/video/next/gbikes_dinosaur.mp4",
                InputUri = "~/home/rowbottom_nathan/NMTexample.mp4",
                Features = { Feature.LabelDetection }
            };
            var op = client.AnnotateVideo(request).PollUntilCompleted();
            foreach (var result in op.Result.AnnotationResults)
            {
                PrintLabels("Video", result.SegmentLabelAnnotations);
                PrintLabels("Shot", result.ShotLabelAnnotations);
                PrintLabels("Frame", result.FrameLabelAnnotations);
            }
        }

        static void PrintLabels(string labelName,
            IEnumerable<LabelAnnotation> labelAnnotations)
        {
            foreach (var annotation in labelAnnotations)
            {
                Console.WriteLine($"{labelName} label: {annotation.Entity.Description}");
                foreach (var entity in annotation.CategoryEntities)
                {
                    Console.WriteLine($"{labelName} label category: {entity.Description}");
                }
                foreach (var segment in annotation.Segments)
                {
                    Console.Write("Segment location: ");
                    Console.Write(segment.Segment.StartTimeOffset);
                    Console.Write(":");
                    Console.WriteLine(segment.Segment.EndTimeOffset);
                    Console.WriteLine($"Confidence: {segment.Confidence}");
                }
            }
        }
    }

}
