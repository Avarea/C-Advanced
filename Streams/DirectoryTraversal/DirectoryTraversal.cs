namespace DirectoryTraversal
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            var filesDictionary = new Dictionary<string, List<FileInfo>>();
            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;
                //long size = fileInfo.Length;

                if (!filesDictionary.ContainsKey(extension))
                {
                    filesDictionary[extension] = new List<FileInfo>();
                }
                filesDictionary[extension].Add(fileInfo);
            }

            filesDictionary = filesDictionary
                .OrderByDescending(f => f.Value.Count)
                .ThenBy(f => f.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullFileName = desktop + "/report.txt";

            using (var writer = new StreamWriter(fullFileName))
            {
                foreach (var pair in filesDictionary)
                {
                    string extension = pair.Key;
                    var fileInfos = pair.Value.OrderByDescending(fi => fi.Length);

                    writer.WriteLine(extension);

                    foreach (var fileInfo in fileInfos)
                    {
                        double fileSize = (double) fileInfo.Length / 1024;

                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:f2}kb");
                    }
                }
            }
        }
    }
}
