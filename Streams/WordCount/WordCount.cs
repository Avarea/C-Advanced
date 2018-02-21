namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class WordCount
    {
        static void Main()
        {
            StreamReader streamReader = new StreamReader("words.txt");
            StreamWriter streamWriter = new StreamWriter("result.txt");
            List<string> containingWords = new List<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();

            using (streamReader)
            {
                var line = streamReader.ReadLine()?.ToLower();
                while (line != null)
                {
                    containingWords.Add(line);
                    line = streamReader.ReadLine()?.ToLower();
                }


                foreach (var word in containingWords)
                {
                    if (!dict.ContainsKey(word))
                    {
                        dict.Add(word, 0);
                    }
                }
            }

            var reader = new StreamReader("text.txt");
            using (reader)
            {
                var line = reader.ReadLine()?.ToLower();
                while (line != null)
                {
                    foreach (var word in line.Split(new[] { ' ', '.', ',', '-', '?', '!' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        if (dict.ContainsKey(word))
                        {
                            dict[word]++;
                        }
                    }

                    line = reader.ReadLine()?.ToLower();
                }
            }

            using (streamWriter)
            {
                foreach (var pair in dict.OrderByDescending(x => x.Value))
                {
                    streamWriter.WriteLine($"{pair.Key} - {pair.Value}");
                }

            }
            Console.WriteLine(string.Join(" ", containingWords));
            //not finished
        }
    }
}
