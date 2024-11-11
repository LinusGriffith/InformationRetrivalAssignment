using System.Diagnostics;
using Porter2Stemmer;

namespace IndexingAssignment1Processor
{
    public readonly struct Document
    {
        public int Id {get;}
        public string Body {get;}

        public Document(int id, string body)
        {
            Id = id;
            Body = body;
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var documents = ReadDocument("IRW1.txt");
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public static List<Document> ReadDocument(string fileName)
        {
            const string Separator = "********************************************";
            var documents = new List<Document>();

            string content = File.ReadAllText(fileName);

            var porterStemmer = new Porter2Stemmer.EnglishPorter2Stemmer();

            var parts = content.Split(new[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                documents.Add(new Document(i, parts[i].Trim()));
            }

            return documents;
        }
    }
}