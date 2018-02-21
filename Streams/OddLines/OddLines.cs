namespace OddLines
{
    using System;
    using System.IO;

    class OddLines
    {
        static void Main()
        {
            StreamReader stream = new StreamReader("text.txt");
            using (stream)
            {
                string line = stream.ReadLine();
                int counter = 0;
                while (line != null)
                {
                    if (counter % 2 == 1)
                    {
                        Console.WriteLine(line);
                    }

                    counter++;
                    line = stream.ReadLine();
                }
            }
        }
    }
}
