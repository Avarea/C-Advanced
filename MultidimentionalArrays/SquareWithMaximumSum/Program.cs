namespace SquareWithMaximumSum
{
    using System;
    using System.Linq;

    class SquareWithMaximumSum
    {
        static void Main()
        {
            int[] rowsAndColumns = Console.ReadLine()?.Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsAndColumns[0], rowsAndColumns[1]];

            for (int rows = 0; rows < rowsAndColumns[0]; rows++)
            {
                var rowValues = Console.ReadLine()?.Split(new string[] { ", " }, StringSplitOptions.None).Select(int.Parse).ToArray();
                for (int cols = 0; cols < rowsAndColumns[1]; cols++)
                {
                    matrix[rows, cols] = rowValues[cols];
                }
            }
            int sum = 0;
            int rowIndex = 0;
            int columnIndex = 0;

            for (int rows = 0; rows < matrix.GetLength(0) - 1; rows++)
            {
                for (int cols = 0; cols < matrix.GetLength(1) - 1; cols++)
                {
                    var tempSum = matrix[rows, cols] + matrix[rows, cols + 1] + matrix[rows + 1, cols + 1] +
                                  matrix[rows + 1, cols];
                    if (tempSum > sum)
                    {
                        sum = tempSum;
                        rowIndex = rows;
                        columnIndex = cols;
                    }
                }
            }

            Console.WriteLine(matrix[rowIndex, columnIndex] + " " + matrix[rowIndex, columnIndex + 1]);
            Console.WriteLine(matrix[rowIndex + 1, columnIndex] + " " + matrix[rowIndex + 1, columnIndex + 1]);
            Console.WriteLine(sum);
        }
    }
}