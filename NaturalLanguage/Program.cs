using System;
using Google.Cloud.Language.V1;



namespace NaturalLanguageApiDemo
{


    class Program
    {
        static void Main(string[] args)
        {
            Paragraph [] paragraphs = new Paragraph[5];

            paragraphs[0] = new Paragraph("The first day of every class I explain to my students what my primary goal is as a computer science teacher:  “My goal is to help you create and polish projects that make you look like you have superpowers compared to all the other candidates.  For future coop interviews, for future job interviews, forever.  I want you to have an unfair advantage.  Help me to help you be awesome and marks will sort themselves out.”  I am applying to the position of Professor of the CSAIT diploma program with prospects of involvement with the STEAM Academy delivery model.  I would love to have the opportunity to give an unfair edge to students in the Mohawk and STEAM Academy CSAIT programs.  Three qualities I have which establish me as an ideal candidate are: my experience in delivering advanced software development content at the senior high school / college level, my ability to create new and interesting contexts for assignments, and my desire and ability to learn and teach new technologies to remain on the cutting edge.  I would like to take some time to prove these qualities and how they could be of use to Mohawk College.");
            paragraphs[1] = new Paragraph("Prior to myself taking over the programming sections at Craig Kielburger Secondary School, teachers called the computer lab, “Starcraft Academy”, because more advanced programmers would finish the problem sets before the rest and then play games on the computers until the slower students caught up.  I redesigned the program from the bottom up by introducing open-ended, project-based learning. My program features a focus on open-concept problems in which students are encouraged to learn the concepts of programming in context.  Students are given a set of critical requirements which meet the curriculum concepts and would consist of a working MVP of the product.  They then top themselves up to 100% by choosing upon co-constructed optional requirements.  This program structure builds the developers’ mindset; where students are thinking of what features they will be able to target for this iteration based on their talents, interests and time constraints.  Feedback is given with a stress on self-reflection and growth.  High achieving students are mentored to complete as many features as possible and encouraged to explore APIs, libraries and features and that might add remarkable new functionalities.  Like in a more professional atmosphere, students are also encouraged to ask myself and each other for guidance and feedback.  For my part in the process, I am continually monitoring and reflecting on student progress, giving extra explanation where required at the class, group and individual level.  I periodically adjust criteria and expectations with a view of the long term development of the student.  I have been doing this for years, fine-tuning my approach and one thing I can tell you is that it works.  Students by and large respond well and take pride in building their skills, collaborating and seeing how others react to their impressive work.  As proof, I would offer the Slack Analytics for my most recent Grade 12 course, the fact that within a two hour exam, my grade 11 students produced working Slot Machine programs (which used to be the 2 week summatives during the “Starcraft Academy” days). I could also mention that I presently have not just one, but three, first year students that have been accepted into the Watonomous self-driving vehicle program at the Univeristy of Waterloo where is is unheard of that any first year student would get accepted.  Those students were accepted based on the experiences they gained in my classes.");
            paragraphs[2] = new Paragraph("In order to give my students amazing experiences they can brag about, I have to create amazing contexts for them to learn and demonstrate their understanding.  Over the years, my students have created simulations of bacterial ecosystems in which predators consume photosynthesizing algae and then watched to see the impact of designing and introducing a scavenger class has upon the population dynamics.  They have programmed agent programs that not only attack and dodge bullets but have to work together in teams and fulfil roles. There have been 3D physics simulations of electromagnetic fields as commissioned by senior physics student clients struggling with concepts, apps that allow drama students to cue up sound effects for their plays, and games that teach linear equations in a kinesthetic sense.  When York University stopped working on a citizen science program to make and monitor a large scale array of sensors to detect Cosmic Rays, my students took on the task and started from scratch, making apps in Android and iOS to detect Cosmic Rays(http://tiny.cc/solta-report). In each of these activities, students learned important modern programming paradigms, learned to access APIs and enjoyed the challenge of the interesting context.  I have a growing list of intriguing situations that I would love to expose Mohawk and STEAM Academy students for their benefit.");
            paragraphs[3] = new Paragraph("In order for me to expose my students to new and interesting experiences, I am  constantly learning new languages, environments, and situations.  I am constantly seeking out new partnerships and collaboration opportunities.  When I learned about the STEAM Academy in September, I sent out an email to seek out new situations.  Rather than learning to use CoreML and following a recipe example, I am happier extending the CoreML example into new context and against a similar solution in Google AutoML, AWS Sage Maker, or IBM’s Watson. I have a growing body of knowledge in programming in Go, Python, C# and Dart.  On the problem-solving website Hackerrank, I have solutions to some problems in 6 different languages.  A process of continual testing and experimenting and learning allows me to choose the language and technology suite that suits the purpose.  I have students in Coop that I am mentoring in making Augmented Reality apps for the Joggins Fossil Institute and others that I am preparing to make chemistry educational apps in Unity.  I am currently working on tutorials in networking support for games and machine learning for vision recognition.   For the last 5 years, I have conducted professional development sessions for my fellow computer science teachers in the Halton District School Board like the one here.  I have built relationships to co-develop SHSM support certifications with Magdin Stoica from Sheridan College. And of course, learning something new means applying in new and interesting ways. Going forward, I feel that my continual desire to stay current and on the forefront will allow me to always make sure the course content for Mohawk and STEAM Academy. Philosophically,I also believe one of the most important things we can do as teachers is to model being a super learner, the resiliency to persevere through challenges and how we overcome them.  So whether its how use callback functions in Google Scripts to automatically make random teams from my Google Classroom or training custom Neural Machine Learning Translation models to learn the Cayuga Language, I want to be around new and interesting technologies and I want to expose Mohawk students to them in ways that set them apart.");
            paragraphs[4] = new Paragraph("I have spoke about how I can contribute to the Mohawk program through my programming abilities and teaching philosophy.  But I would also like to close by identifying how I can contribute to the overall tapestry of diversity at Mohawk College and the STEAM Academy.  I am an off-reserve Haudenosaunee (Iroquois) person that was from an economically disadvantaged background.  I have travelled an non-linear and colorful career path and it has given me an appreciation for the value of diversity.  I taught Anishinabe students on a remote reserve in Northern Ontario, and I presently teach at a school where over ⅔ my students are of new-comer origin.  I see directly the value of synthesizing new ideas from differing world views while simultaneously honouring and preserving endangered cultures from the tyranny of the Monoculture.  I see technology as a tool to empower diverse peoples to tell their stories and share differing vantage points to the benefit of all, but am also well aware of the threat of techonology being in only a select, priviledged class.  I am currently operating a not-for-profit organization, LearnCayuga.org, which is using machine learning and cloud technologies to built translation and learning support for Cayuga, an Haudenosaunee language I am learning.  I want to bring the bounties promised by cloud services and mobile computing to a larger audience than I can reach in my current role and I believe the position at Mohawk College is perfect for me to do so.");
           // var sentences = text.Split(".");

            var client = LanguageServiceClient.Create();
            foreach (Paragraph p in paragraphs){
                p.getResponse(client);
                //var response = client.AnalyzeSentiment(Document.FromPlainText(s));
                //var sentiment = response.DocumentSentiment;
                //Console.WriteLine($"Score: {sentiment.Score}");
                //Console.WriteLine($"Magnitude: {sentiment.Magnitude}");
            }
        }
    }


    class Paragraph{

        protected string[] sentences;
        protected double[] scores;
        protected double average;

         


        public Paragraph (string text){
            sentences = sentences = text.Split(".");
            scores = new double[sentences.Length];
        }

        public void getResponse(LanguageServiceClient client){
            for (int i = 0; i < sentences.Length; i++){
                var response = client.AnalyzeSentiment(Document.FromPlainText(sentences[i]));
                var sentiment = response.DocumentSentiment;
                scores[i] = sentiment.Score;
                Console.WriteLine("Sentence: "+i+" : "+ scores[i]);
                average += scores[i];
            }
            
            average /= scores.Length;
            Console.WriteLine($"Average: {average}");
        }

    }
}
