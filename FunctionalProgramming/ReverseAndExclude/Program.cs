using System;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()?.Split(' ').Select(int.Parse).Reverse().ToList();
            var divisor = int.Parse(Console.ReadLine());

            numbers = numbers.Where(n => Filter(n, x => x % divisor != 0)).ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static bool Filter(int number, Func<int, bool> filter)
        {
            return filter(number);
        }
    }
}
