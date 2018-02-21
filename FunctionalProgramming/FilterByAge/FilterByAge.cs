namespace FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FilterByAge
    {
        static void Main()
        {
            var input = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();

            for (int count = 0; count < input; count++)
            {
                var person = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                people.Add(person[0], int.Parse(person[1]));
            }
            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var filter = GetFilter(condition, age);
            var printer = GetPrinter(format);

            foreach (var person in people)
            {
                if (filter(person.Value))
                {
                    printer(person);
                }
            }
        }

        static Func<int, bool> GetFilter(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x < age;
            }
            else
            {
                return x => x >= age;
            }
        }

        static Action<KeyValuePair<string, int>> GetPrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                    break;
                case "age":
                    return x => Console.WriteLine(x.Value);
                    break;
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                    break;
                    default:
                    throw new NotImplementedException();
            }
        }
    }
}
