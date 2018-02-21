namespace KnightsOfHonor
{
    using System;

    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string> action = n => Console.WriteLine($"Sir {n}");

            foreach (var word in Console.ReadLine().Split(' '))
            {
                action(word);
            }
        }
    }
}
