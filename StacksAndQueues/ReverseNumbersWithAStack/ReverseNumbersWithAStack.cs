using System;
using System.Collections.Generic;

namespace ReverseNumbersWithAStack
{
    class ReverseNumbersWithAStack
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var stack = new Stack<int>();

                foreach (var num in input)
                {
                    stack.Push(int.Parse(num));
                }

                while (stack.Count != 0)
                {
                    Console.Write($"{stack.Pop()} ");
                }
                Console.WriteLine();
            }
            catch (Exception )
            {
                Console.WriteLine(input);
            }

        }
    }
}
