namespace TriFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class TriFunction
    {
        static void Main()
        {
            int sum = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ').ToList();

            Console.WriteLine(names.FirstOrDefault(name => name.ToCharArray().Sum(c => c) >= sum));
        }
    }
}