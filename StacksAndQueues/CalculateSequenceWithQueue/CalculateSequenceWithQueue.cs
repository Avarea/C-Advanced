namespace CalculateSequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    class CalculateSequenceWithQueue
    {
        static void Main()
        {
            long s1 = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            var tempQueue = new Queue<long>();

            int counter = 1;

            queue.Enqueue(s1);

            for (int i = 1; i < 50; i++)
            {
                switch (counter)
                {
                    case 0:
                        s1 = tempQueue.Dequeue();
                        counter++;
                        goto case 1;

                    case 1:
                        long s2 = s1 + 1;
                        queue.Enqueue(s2);
                        tempQueue.Enqueue(s2);
                        counter++;
                        break;

                    case 2:
                        long s3 = 2 * s1 + 1;
                        queue.Enqueue(s3);
                        tempQueue.Enqueue(s3);
                        counter++;
                        break;

                    case 3:
                        long s4 = s1 + 2;
                        queue.Enqueue(s4);
                        tempQueue.Enqueue(s4);
                        counter = 0;
                        break;
                }
            }
            for (int j = 0; j < 50; j++)
            {
                Console.Write($"{queue.Dequeue()} ");
            }
            Console.WriteLine();
        }
    }
}
