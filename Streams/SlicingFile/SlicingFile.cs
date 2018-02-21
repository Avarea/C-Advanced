namespace SlicingFile
{
    using System;    
    using System.Collections.Generic;
    using System.IO;

    class SlicingFile
    {
        static void Main()
        {
            Slice("../sliceMe.mp4","",5);

            var files = new List<string>
            {
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4",
            };

            Assemble(files, "");
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long fileSize = (long) Math.Ceiling((double)reader.Length / parts);
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

                for (int i = 0; i < parts; i++)
                {
                    long currentFileSize = 0;

                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }

                    if (!destinationDirectory.EndsWith("/"))
                    {
                        destinationDirectory += "/";
                    }

                    string currentPart = destinationDirectory + $"Part-{i}.{extension}";

                    using (FileStream writer = new FileStream(currentPart, FileMode.Create))
                    {
                        byte[] buffer = new byte[4096];
                        while (reader.Read(buffer, 0, buffer.Length) == 4096)
                        {
                            writer.Write(buffer, 0, buffer.Length);
                            currentFileSize += 4096;
                            if (currentFileSize >= fileSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.') + 1);

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }

            if (!destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }

            string assambleFile = $"{destinationDirectory}Assembled.{extension}";

            using (FileStream writer = new FileStream(assambleFile, FileMode.Create))
            {
                byte[] buffer = new byte[4096];

                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(buffer,0,4096) == 4096)
                        {
                            writer.Write(buffer, 0, 4096);
                        }
                    }
                }
            }
        }
    }
}
