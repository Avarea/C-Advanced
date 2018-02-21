namespace CopyBinaryFile
{
    using System;
    using System.IO;

    class CopyBinaryFile
    {
        static void Main()
        {
            FileStream source = new FileStream(@"C:\Users\Gzero\Desktop\C# Advanced\Streams\CopyBinaryFile/text.txt", FileMode.Open);
            using (source)
            {
                FileStream destination = new FileStream(@"C:\Users\Gzero\Desktop\C# Advanced\Streams\CopyBinaryFile/text-copy.txt", FileMode.Create);
                using (destination)
                {
                    while (true)
                    {
                        byte[] buffer = new Byte[1024];
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
