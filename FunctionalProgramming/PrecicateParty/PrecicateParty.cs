namespace PrecicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PrecicateParty
    {
        public static void Main()
        {
            var peopleComingToTheParty = Console.ReadLine()?.Split(' ').ToList();
            var command = Console.ReadLine()?.Split(' ');
            while (command[0] != "Party!")
            {
                switch (command[1])
                {
                    case "StartsWith":
                        ApplyChangesForStart(peopleComingToTheParty, command[0], command[1], command[2]);
                        break;
                    case "EndsWith":
                        ApplyChangesForEnd(peopleComingToTheParty, command[0], command[1], command[2]);
                        break;
                    case "Length":

                        break;
                }

                command = Console.ReadLine()?.Split(' ');
            }


            PrintPeople(peopleComingToTheParty);
        }

        public static void ApplyChangesForStart(List<string> people, string firstParamter, string secondParameter, string thirdParameter)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].StartsWith(thirdParameter))
                {
                    if (firstParamter == "Remove")
                    {
                        people.RemoveAt(i);
                        break;
                    }

                    if (firstParamter == "Double")
                    {
                        people.Add(people[i]);
                        break;
                    }
                }
            }
        }

        public static void ApplyChangesForEnd(List<string> people, string firstParamter, string secondParameter, string thirdParameter)
        {
            for (int i = 0; i < people.Count; i++)
            {
                if (people[i].EndsWith(thirdParameter))
                {
                    if (firstParamter == "Remove")
                    {
                        people.RemoveAt(i);
                        break;
                    }

                    if (firstParamter == "Double")
                    {
                        people.Add(people[i]);
                        break;
                    }
                }
            }
        }

        public static void PrintPeople(List<string> people)
        {
            if (people.Count > 0)
            {
                Console.WriteLine(string.Join(", ", people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine($"Nobody is going to the party!");
            }
        }
    }
}