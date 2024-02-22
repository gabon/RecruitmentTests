namespace DiamondKata.Tests;

public class MatrixExtensionTests
{
    [Fact]
    public void ToMultilineString_Empty_Empty()
    {
        var matrix = new char[,] { };
        Assert.Equal("",
            matrix.ToMultilineString());
    }

    [Fact]
    public void ToMultilineString_OneEmptyString_OneEmptyString()
    {
        var matrix = new[,] { { ' ' } };
        Assert.Equal("",
            matrix.ToMultilineString());
    }

    [Fact]
    public void ToMultilineString_Null_ThrowsArgumentException()
    {
        char[,] matrix = null!;
        Assert.Throws<ArgumentException>(() => matrix.ToMultilineString());
    }


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
