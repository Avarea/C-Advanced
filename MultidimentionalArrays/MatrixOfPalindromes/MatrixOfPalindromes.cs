namespace MatrixOfPalindromes
{
    using System;
    using System.Linq;

    class MatrixOfPalindromes
    {
        static void Main()
        {
            int[] input = Console.ReadLine()?.Split(' ').Select(int.Parse).ToArray();
            int rows = input[0];
            int columns = input[1];
        
            string[] alphabet = "a b c d e f g h i j k l m n o p q r s t u v w x y z".Split(' ');
            var matrix = new string[rows][];

            for (var i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new string[columns];
            }

            for (int rowsCount = 0; rowsCount < rows; rowsCount++)
            {

                for (int colsCount = 0; colsCount < columns; colsCount++)
                {
                    matrix[rowsCount][colsCount] =
                        $"{alphabet[rowsCount]}{alphabet[colsCount + rowsCount]}{alphabet[rowsCount]}";
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
