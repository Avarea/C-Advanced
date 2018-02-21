namespace FindEvensOrOdds
{
    using System;

    class FindEvensOrOdds
    {
        static void Main()
        {
            var borders = Console.ReadLine()?.Split(' ');
            int low = int.Parse(borders[0]);
            int high = int.Parse(borders[1]);
            string format = Console.ReadLine();

            Predicate<int> predicate = EvenOrOdd;
            for (int i = low; i <= high; i++)
            {
                if (format == "even" && predicate(i))
                {
                    Console.Write(i + " ");
                }
                else if (format == "odd" && !predicate(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        private static bool EvenOrOdd(int number)
        {
            return number % 2 == 0;
        }
    }
}
