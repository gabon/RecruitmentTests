using System.Text;

namespace DiamondKata;

public static class MatrixExtension
{
    public static string ToMultilineString(this char[,] matrix)
    {
        return matrix.ToMultilineString(null);
    }

    public static string ToMultilineString(this char[,] matrix,
        char? spaceReplacement)
    {
        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        var sb = new StringBuilder();
        //todo: check if this can be converted to a foreach or linq or something more readable too many ifs and loops
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
