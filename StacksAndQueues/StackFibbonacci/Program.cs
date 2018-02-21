namespace StackFibbonacci
{
    using System;
    using System.Collections.Generic;
    class StackFibbonacci
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<long>();

            stack.Push(1);
            stack.Push(1);

            for (var i = 2; i < n; i++)
            {
                var second = stack.Pop();
                var first = stack.Pop();
                var next = first + second;

                stack.Push(first);
                stack.Push(second);
                stack.Push(next);
            }
            Console.WriteLine(stack.Peek());
        }
    }
}