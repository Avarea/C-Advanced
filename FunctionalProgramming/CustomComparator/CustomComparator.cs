namespace CustomComparator
{
    using System;
    using System.Linq;

    class CustomComparator
    {
        static void Main()
        {
            var input = Console.ReadLine()?.Split(' ').Select(int.Parse).ToList();
            var evenNums = input.FindAll(x => x % 2 == 0);
            evenNums.Sort();
            var oddNums = input.FindAll(x => x % 2 != 0);
            oddNums.Sort();

            Console.WriteLine(string.Join(" ", evenNums.Concat(oddNums)));
        }
    }
}
