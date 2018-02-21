namespace TrafficLights
{
    using System;
    using System.Collections.Generic;

    class TrafficLights
    {
        static void Main()
        {
            int numberOfPassingCars = int.Parse(Console.ReadLine());
            var command = Console.ReadLine();
            var queue = new Queue<string>();
            int counter = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    var carsThatCanPass = Math.Min(numberOfPassingCars, queue.Count);
                    for (int i = 0; i < carsThatCanPass; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        counter++;
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
