using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class BalancedParentheses
    {
        static void Main()
        {
            char[] input = Console.ReadLine()?.ToCharArray();

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            char[] opening = { '(', '[', '{' };
            char[] closing = { ')', ']', '}' };

            var stack = new Stack<char>();

            foreach (var element in input)
            {
                if (opening.Contains(element))
                {
                    stack.Push(element);
                }
                else if (closing.Contains(element))
                {
                    var lastElement = stack.Pop();
                    int openingIndex = Array.IndexOf(opening, lastElement);
                    int closingIndex = Array.IndexOf(closing, element);

                    if (openingIndex != closingIndex)
                    {
                        Console.WriteLine("NO");
                        Environment.Exit(0);
                    }
                }
            }

            if (stack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}