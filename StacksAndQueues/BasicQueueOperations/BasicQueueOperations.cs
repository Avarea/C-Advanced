namespace BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicQueueOperations
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var queueNumbers = Console.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int numberOfElementsToPush = int.Parse(input[0]);
            int numberOfElementsToPop = int.Parse(input[1]);
            int numberToCheck = int.Parse(input[2]);

            var queue = new Queue<int>();

            foreach (var num in queueNumbers)
            {
                queue.Enqueue(int.Parse(num));
            }

            for (int i = 0; i < numberOfElementsToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (queue.Contains(numberToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
