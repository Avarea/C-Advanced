namespace BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicStackOperations
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var stackNumbers = Console.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int numberOfElementsToPush = int.Parse(input[0]);
            int numberOfElementsToPop = int.Parse(input[1]);
            int numberToCheck = int.Parse(input[2]);

            var stack = new Stack<int>();


                foreach (var num in stackNumbers)
                {
                    stack.Push(int.Parse(num));
                }
                

            for (int i = 1; i <= numberOfElementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            if (stack.Contains(numberToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}