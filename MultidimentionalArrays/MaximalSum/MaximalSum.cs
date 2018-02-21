namespace MaximalSum
{
    using System;
    using System.Linq;

    class MaximalSum
    {
        static void Main()
        {
            var dimensions = Console.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var n = dimensions[0];
            var m = dimensions[1];

            var matrix = new long[n][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            }

            long maximumSum = long.MinValue;
            int rowStartIndex = 0;
            int columnStartIndex = 0;

            for (int rowCount = 0; rowCount < matrix.Length - 2; rowCount++)
            {
                for (int colCount = 0; colCount < matrix[rowCount].Length - 2; colCount++)
                {
                    var tempSum = CalculateSumOfCurrentSquare(ref matrix, rowCount, colCount);

                    if (tempSum > maximumSum)
                    {
                        maximumSum = tempSum;
                        rowStartIndex = rowCount;
                        columnStartIndex = colCount;
                    }
                }
            }

            Console.WriteLine($"Sum = {maximumSum}");
            for (var row = rowStartIndex; row < rowStartIndex + 3; row++)
            {
                for (var col = columnStartIndex; col < columnStartIndex + 3; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }


        public static long CalculateSumOfCurrentSquare(ref long[][] matrix, int startRow, int startCol)
        {
            var sum = 0L;

            for (var row = startRow; row < startRow + 3; row++)
            {
                for (var col = startCol; col < startCol + 3; col++)
                {
                    sum += matrix[row][col];
                }
            }

            return sum;
        }
    }
}
