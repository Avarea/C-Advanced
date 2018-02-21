using System;
using System.Collections.Generic;
using System.Linq;

namespace LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            var firstMatrix = new int[rows][];
            var secondMatrix = new int[rows][];

            InitializeMatrix(ref firstMatrix);
            InitializeMatrix(ref secondMatrix);

            ReverseMatrix(ref secondMatrix);

            if (IsMatched(ref firstMatrix, ref secondMatrix, out long count))
            {
                PrintCombinedMatrix(ref firstMatrix, ref secondMatrix);
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {count}");
            }
        }

        static void PrintCombinedMatrix(ref int[][] firstMatrix, ref int[][] secondMatrix)
        {
            for (int row = 0; row < firstMatrix.Length; row++)
            {
                Console.Write("[");
                Console.Write(string.Join(", ", firstMatrix[row]));
                Console.Write(", ");
                Console.Write(string.Join(", ", secondMatrix[row]));
                Console.WriteLine("]");
            }
        }

        static bool IsMatched(ref int[][] firstMatrix, ref int[][] secondMatrix, out long count)
        {
            count = 0;
            SortedSet<int> rowsLength = new SortedSet<int>();

            for (int row = 0; row < firstMatrix.Length; row++)
            {
                count += firstMatrix[row].Length + secondMatrix[row].Length;
                rowsLength.Add(firstMatrix[row].Length + secondMatrix[row].Length);
            }

            return rowsLength.Count == 1;
        }

        static void ReverseMatrix(ref int[][] secondMatrix)
        {
            for (int row = 0; row < secondMatrix.Length; row++)
            {
                Array.Reverse(secondMatrix[row]);
            }
        }

        static void InitializeMatrix(ref int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                matrix[row] = input;
            }
        }
    }
}
