namespace ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ListOfPredicates
    {
        static void Main()
        {
            int maxNumber = int.Parse(Console.ReadLine());
            var sequence = Console.ReadLine()?.Split(' ').Select(int.Parse).ToList();
            var result = new List<int>();

            for (int i = 1; i <= maxNumber; i++)
            {
                result.Add(i);
            }

            for (int i = 0; i < sequence.Count; i++)
            {
                result = result.FindAll(x => x % sequence[i] == 0).ToList();
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
