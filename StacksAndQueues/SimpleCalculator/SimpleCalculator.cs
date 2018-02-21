namespace SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SimpleCalculator
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ');

            var stackOfCalculations = new Stack<string>(input.Reverse());
            while (stackOfCalculations.Count > 1)
            {
                int firstNumber = int.Parse(stackOfCalculations.Pop());
                string delimter = stackOfCalculations.Pop();
                int secondNumber = int.Parse(stackOfCalculations.Pop());
                
                switch (delimter)
                {
                    case "+":
                        stackOfCalculations.Push((firstNumber + secondNumber).ToString());
                        break;

                    case "-":
                        stackOfCalculations.Push((firstNumber - secondNumber).ToString());
                        break;
                }
               
            }
            Console.WriteLine(stackOfCalculations.Pop());
        }
    }
}
