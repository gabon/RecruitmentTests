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
        Assert.Equal("AB",
            matrix.ToMultilineString());
    }

    [Fact]
    public void ToMultilineString_TwoOnTwo_ConcatenatedTwoLines()
    {
        var matrix = new[,] { { 'A', 'B' }, { 'C', 'D' } };
        Assert.Equal($"AB{Environment.NewLine}CD",
            matrix.ToMultilineString());
    }
    
    [Fact]
    public void ToMultilineString_ThreeOnThree_ConcatenatedThreeLines()
    {
        var matrix = new[,] { { 'A', 'B', 'C' }, { 'D', 'E', 'F' }, { 'G', 'H', 'I' } };
        Assert.Equal($"ABC{Environment.NewLine}DEF{Environment.NewLine}GHI",
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
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                sb.Append(matrix[i,
                    j]);
                if (j < matrix.GetLength(1) - 1)
                {
                    sb.Append(' ');
                }
            }

            if (i < matrix.GetLength(0) - 1)
            {
                sb.Append(Environment.NewLine);
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
