namespace LineNumbers
{
    using System.IO;

    class LineNumbers
    {
        static void Main()
        {
            StreamReader streamReader = new StreamReader("text.txt");
            StreamWriter streamWriter = new StreamWriter("output.txt");
            int counter = 1; 
            using (streamReader)
            {
                using (streamWriter)
                {
                    var line = streamReader.ReadLine();
                    while (line != null)
                    {
                        streamWriter.WriteLine($"Line {counter}: {line}");
                        counter++;
                        line = streamReader.ReadLine();
                    }
                }

            }
        }
    }
}
