namespace AppliedArithmetics
{
    using System;
    using System.Linq;

    class AppliedArithmetics
    {
        static void Main()
        {
            var numbers = Console.ReadLine()?.Split(' ').Select(int.Parse).ToList();
            var command = Console.ReadLine();
            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(n => n + 1).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(n => n - 1).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(n => n * 2).ToList();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }
                command = Console.ReadLine();
            }
        }
    }
}
