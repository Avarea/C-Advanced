﻿namespace MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class MaximumElement
    {
        static void Main()
        {
            int commandsCount = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxStack = new Stack<int>();

            maxStack.Push(int.MinValue);

            for (int i = 0; i < commandsCount; i++)
            {
                var command = Console.ReadLine()?.Split(' ').Select(int.Parse).ToArray();

                switch (command[0])
                {
                    case 1:
                        var element = command[1];
                        stack.Push(element);
                        if (element >= maxStack.Peek())
                        {
                            maxStack.Push(element);
                        }
                        break;

                    case 2:
                        var poppedElement = stack.Pop();
                        if (maxStack.Peek() == poppedElement)
                        {
                            maxStack.Pop();
                        }
                        break;

                    case 3:
                        int maxElement = maxStack.Peek();
                        Console.WriteLine(maxElement);
                        break;
                }
            }
        }
    }
}
