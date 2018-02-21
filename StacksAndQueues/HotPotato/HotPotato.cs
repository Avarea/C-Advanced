namespace HotPotato
{
    using System;
    using System.Collections.Generic;

    class HotPotato
    {
        static void Main()
        {
            var children = Console.ReadLine().Split(' ');
            int tossCount = int.Parse(Console.ReadLine());

            var queue = new Queue<string>(children);
            while (queue.Count != 1)
            {
                for (int i = 1; i < tossCount; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");

            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
