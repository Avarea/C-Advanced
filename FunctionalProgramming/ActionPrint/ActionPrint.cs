namespace ActionPrint
{
    using System;

    class ActionPrint
    {
        static void Main()
        {
            Action<string> action = n => Console.WriteLine(n);

            foreach (var word in Console.ReadLine().Split(' '))
            {
                action(word);
            }
        }
    }
}
