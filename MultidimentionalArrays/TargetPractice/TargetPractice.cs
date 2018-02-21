using System;
using System.Linq;

namespace TargetPractice
{
    class TargetPractice
    {
        static void Main()
        {
            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var snakeString = Console.ReadLine().ToCharArray();
            var shot = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int numberOfRows = dimensions[0];
            int numberOfColumns = dimensions[1];
            int shotRow = shot[0];
            int shotColumn = shot[1];
            int shotRadius = shot[2];


            CreateMatrix(out var matrix, numberOfRows, numberOfColumns);//create matrix
            FillMatrix(ref matrix, snakeString); //fill with the char array
            CleanBlastedArea(ref matrix, shotRow, shotColumn, shotRadius);  //clear the shot area
            FallingDown(ref matrix);
            PrintMatrix(ref matrix);
        }

        static void FallingDown(ref char[][] matrix)
        {
            var hasChange = true;
            while (hasChange)
            {
                hasChange = false;
                for (int row = 0; row < matrix.Length - 1; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        var currentSymbol = matrix[row][col];
                        if (matrix[row + 1][col] == ' ' && matrix[row][col] != ' ')
                        {
                            hasChange = true;
                            matrix[row + 1][col] = currentSymbol;
                            matrix[row][col] = ' ';
                        }
                    }
                }
            }
            
        }
    
        static void CleanBlastedArea(ref char[][] matrix, int shotRow, int shotColumn, int shotRadius)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (IsInside(row, col, shotRow, shotColumn,shotRadius))
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }

        }

        static bool IsInside(int row, int col, int shotRow, int shotColumn, int shotRadius)
        {
            int targetRow = row - shotRow;
            int targetCol = col - shotColumn;

            var isInRadius = targetRow * targetRow + targetCol * targetCol <= shotRadius * shotRadius;
            return isInRadius;
        }

        static void FillMatrix(ref char[][] matrix, char[] snakestring)
        {
            int snakeIndex = 0;
            bool toTheLeft = true;
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                if (toTheLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        if (snakeIndex == snakestring.Length)
                        {
                            snakeIndex = 0;
                        }
                        matrix[row][col] = snakestring[snakeIndex++];
                    }
                    toTheLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (snakeIndex == snakestring.Length)
                        {
                            snakeIndex = 0;
                        }
                        matrix[row][col] = snakestring[snakeIndex++];
                    }
                    toTheLeft = true;
                }
            }
        }

        static void CreateMatrix(out char[][] matrix, int numberofRows, int numberOfColums)
        {
            matrix = new char[numberofRows][];

            for (int i = 0; i < numberofRows; i++)
            {
                matrix[i] = new char[numberOfColums];
            }
        }

        public static void PrintMatrix(ref char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
