namespace RubiksMatrix
{
    using System;
    using System.Linq;

    class RubiksMatrix
    {
        static void Main()
        {
            var dimensions = Console.ReadLine()?.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var r = dimensions[0];
            var c = dimensions[1];

            InitMatrix(out var matrix, r, c);
            InitMatrix(out var originalMatrix, r, c);

            var numberOfCommand = int.Parse(Console.ReadLine());

            while (numberOfCommand > 0)
            {
                var input = Console.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var rowOrColumnNum = int.Parse(input[0]);
                var command = input[1];
                var moves = int.Parse(input[2]);

                switch (command)
                {
                    case "up":
                        ColumsMove(ref matrix, rowOrColumnNum, moves, command);
                        break;
                    case "down":
                        ColumsMove(ref matrix, rowOrColumnNum, moves, command);
                        break;

                    case "left":
                        RowsMove(ref matrix, rowOrColumnNum, moves, command);
                        break;

                    case "right":
                        RowsMove(ref matrix, rowOrColumnNum, moves, command);
                        break;
                }
                numberOfCommand--;
            }

            Verification(ref originalMatrix, ref matrix);
        }

        private static void Verification(ref int[][] originalMatrix, ref int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == originalMatrix[row][col])
                    {
                        Console.WriteLine("No swap required");
                        continue;
                    }

                    var searchedElement = originalMatrix[row][col];
                    for (int r = row; r < matrix.Length; r++)
                    {
                        for (int c = 0; c < matrix[r].Length; c++)
                        {
                            if (matrix[r][c] == searchedElement)
                            {
                                matrix[r][c] = matrix[row][col];
                                matrix[row][col] = searchedElement;
                                Console.WriteLine($"Swap ({row}, {col}) with ({r}, {c})");
                            }
                        }
                    }
                }
            }
        }

        private static void RowsMove(ref int[][] matrix, int row, int moves, string command)
        {
            moves = moves % matrix[row].Length;

            if (command.Equals("left"))
            {
                for (int i = 0; i < moves; i++)
                {
                    var firstElement = matrix[row][0];
                    for (int col = 0; col < matrix[row].Length - 1; col++)
                    {
                        matrix[row][col] = matrix[row][col + 1];
                    }
                    matrix[row][matrix[row].Length - 1] = firstElement;
                }
            }
            else
            {
                for (var i = 0; i < moves; i++)
                {
                    var lastElement = matrix[row][matrix[row].Length - 1];
                    for (var col = matrix[row].Length - 1; col > 0; col--)
                    {
                        matrix[row][col] = matrix[row][col - 1];
                    }

                    matrix[row][0] = lastElement;
                }
            }
        }

        private static void ColumsMove(ref int[][] matrix, int column, int moves, string command)
        {
            moves = moves % matrix[0].Length;

            if (command.Equals("up"))
            {
                for (var i = 0; i < moves; i++)
                {
                    var firstElement = matrix[0][column];
                    for (var row = 0; row < matrix.Length - 1; row++)
                    {
                        matrix[row][column] = matrix[row + 1][column];
                    }

                    matrix[matrix.Length - 1][column] = firstElement;
                }
            }
            else
            {
                for (var i = 0; i < moves; i++)
                {
                    var lastElement = matrix[matrix.Length - 1][column];
                    for (var row = matrix.Length - 1; row > 0; row--)
                    {
                        matrix[row][column] = matrix[row - 1][column];
                    }

                    matrix[0][column] = lastElement;
                }
            }
        }

        public static void InitMatrix(out int[][] matrix, int r, int c)
        {
            var counter = 1;
            matrix = new int[r][];
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[c];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = counter++;
                }
            }
        }
    }
}
