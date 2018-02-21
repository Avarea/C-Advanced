namespace SquaresInMatrix
{
    using System;
    using System.Linq;

    class SquaresInMatrix
    {
        static void Main()
        {
            var dimensions = Console.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var columns = dimensions[1];

            var matrix = new string[rows][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new[] { ' ' })
                    .ToArray();
            }

            int counter = 0;

            for (var rowCount = 0; rowCount < matrix.Length - 1; rowCount++)
            {
                for (var colCount = 0; colCount < matrix[rowCount].Length - 1; colCount++)
                {
                    var leftUp = matrix[rowCount][colCount];
                    var rightUp = matrix[rowCount][colCount + 1];
                    var leftDown = matrix[rowCount + 1][colCount];
                    var rightDown = matrix[rowCount + 1][colCount + 1];

                    if (leftUp.Equals(leftDown) && leftUp.Equals(rightDown) && leftUp.Equals(rightUp))
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
