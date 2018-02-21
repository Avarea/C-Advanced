using System.Collections.Generic;

namespace PoisonousPlants
{
    using System;
    using System.Linq;
    class PoisonousPlants
    {
        static void Main()
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine()?.Split().Select(int.Parse).ToArray();

            var indexes = new Stack<int>();
            indexes.Push(0);

            var days = new int[numberOfPlants];

            for (int i = 1; i < numberOfPlants; i++)
            {
                var maximumDays = 0;
                while (indexes.Count > 0 && plants[indexes.Peek()] >= plants[i])
                {
                    maximumDays = Math.Max(maximumDays, days[indexes.Pop()]);
                }
                if (indexes.Count > 0)
                {
                    days[i] = maximumDays + 1;
                }
                indexes.Push(i);
            }
            Console.WriteLine(days.Max());
        }
    }
}