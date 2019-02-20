using System;
using Google.Cloud.TextToSpeech.V1;
using System.IO;

//Rowbottom first attempts.  Minor changes to language and output.  Locally I have added to winforms.  Will post at some point.

namespace TextToSpeechApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = TextToSpeechClient.Create();
           // var response = client.ListVoices("fa"); 
           // foreach (var voice in response.Voices)
            //{    Console.WriteLine($"{voice.Name} ({voice.SsmlGender}); Language codes: {string.Join(", " ,voice.LanguageCodes)} ");
           // }
            
            
            //Voice input as text or SSML
            var input = new SynthesisInput{
                Text = "ahlaan wamarhabaan bikum fi madrasat krigh kilbirghr alththanawiat lilbawdakast"
            };
            
            //Build the voice request
            var voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = "fr-FR",
                SsmlGender = SsmlVoiceGender.Female
            };

            //lets specify the audio file type
            var audioConfig = new AudioConfig
            {
                AudioEncoding = AudioEncoding.Mp3    
            };
            
            //create the text-to-speech request
            var response = client.SynthesizeSpeech(input, voiceSelection, audioConfig);
            
            //write the response to the output file
            using (var output = File.Create("output_fr1.mp3"))
            {
                response.AudioContent.WriteTo(output);
            }
            Console.WriteLine("Audio content written to file \"output.mp3\"");
            
        }
    }
}
