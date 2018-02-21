namespace DiagonalDifference
{
    using System;
    using System.Linq;

    class DiagonalDifference
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            var matrix = new long[size][];

            for (var count = 0; count < matrix.Length; count++)
            {
                matrix[count] = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
            }

            var leftDiag = 0L;
            var rightDiag = 0L;

            for (int i = 0; i < matrix.Length; i++)
            {
                leftDiag += matrix[i][i];
                rightDiag += matrix[i][matrix.Length - 1 - i];
            }

            Console.WriteLine(Math.Abs(leftDiag - rightDiag));
        }
    }
}
