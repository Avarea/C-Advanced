namespace ReverseStrings
{
    using System;
    using System.Collections.Generic;

    class ReverseStrings
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var stackOfStrings = new Stack<char>();

            foreach (var character in input)
            {
                stackOfStrings.Push(character);
            }

            while (stackOfStrings.Count != 0)
            {
                Console.Write(stackOfStrings.Pop());
            }
            Console.WriteLine();
        }
    }
}
