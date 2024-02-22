using System.Text;

namespace DiamondKata;

public static class MatrixExtension
{
    public static string ToMultilineString(this char[,] matrix)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                sb.Append(matrix[i,
                    j]);
            }

            if (i < matrix.GetLength(0) - 1)
            {
                sb.Append(Environment.NewLine);
            }
        }

        return sb.ToString();
    }
}
