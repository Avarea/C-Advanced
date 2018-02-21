namespace PredicateForNames
{
    using System;
    using System.Linq;

    class PredicateForNames
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            var input = Console.ReadLine()?.Split(' ').Where(w => w.Length <= length).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
