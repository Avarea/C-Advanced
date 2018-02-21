namespace CountUppercaseWords
{
    using System;
    using System.Linq;

    class CountUppercaseWords
    {
        static void Main()
        {
            Func<string, bool> func = w => char.IsUpper(w[0]);

            Console.ReadLine()
                .Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries)
                .Where(func)
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
