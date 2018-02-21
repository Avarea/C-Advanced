namespace CustomMinFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CustomMinFunction
    {
        static void Main()
        {
            Func<List<int>, int> minimumNum = FindMinNumber;

            var input = Console.ReadLine()?.Split(' ').Select(int.Parse).ToList();
            Console.WriteLine(FindMinNumber(input));
        }

        private static int FindMinNumber(List<int> numbers)
        {
            int minNum = int.MaxValue;

            foreach (var num in numbers)
            {
                if (minNum > num)
                {
                    minNum = num;
                }
            }

            return minNum;
        }
    }
}
