using System.Text;

namespace DiamondKata.Tests;

public class DiamondTests
{
    [Fact]
    public void Test1()
    {
        Assert.Equal(new[,] { { 'A' } },
            Diamond.Generate('A'));
    }
}

public class MatrixExtensionTests
{
    [Fact]
    public void ToMultilineString_OneLetter_OneLetter()
    {
        var matrix = new[,] { { 'A' } };
        Assert.Equal("A",
            matrix.ToMultilineString());
    }

    [Fact]
    public void ToMultilineString_TwoOnOne_ConcatenatedOneLine()
    {
        var matrix = new[,] { { 'A', 'B' } };
        Assert.Equal("A B",
            matrix.ToMultilineString());
    }

    [Fact]
    public void ToMultilineString_TwoOnTwo_ConcatenatedTwoLines()
    {
        var matrix = new[,] { { 'A', 'B' }, { 'C', 'D' } };
        Assert.Equal("A B\nC D",
            matrix.ToMultilineString());
    }
}

public static class MatrixExtension
{
    public static string ToMultilineString(this char[,] matrix)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            sb.Append(matrix[i,
                0]);
            if (i < matrix.GetLength(0) - 1)
            {
                sb.Append(' ');
            }
        }

        return sb.ToString();
    }
}

public class Diamond
{
    public static char[,] Generate(char letter)
    {
        return new[,] { { 'A' } };
    }
}
