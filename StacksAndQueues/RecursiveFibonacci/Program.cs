using System;

namespace RecursiveFibonacci
{
    class RecursiveFibonacci
    {
        private static long[] memoization;

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            memoization = new long[n + 1];

            Console.WriteLine(GetFibonacci(n));
        }

        public static long GetFibonacci(long n)
        {
            if (n <= 2)
                return 1;

            if (memoization[n] != 0)
                return memoization[n];


            memoization[n] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            return memoization[n];
        }
    }
}