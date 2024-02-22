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
        Assert.Equal("A", matrix.ToString());
    }
    
    [Fact]
    public void ToMultilineString_TwoOnOne_ConcatenatedOneLine()
    {
        var matrix = new[,] { { 'A', 'B' } };
        Assert.Equal("A B", matrix.ToString());
    }
    
    [Fact]
    public void ToMultilineString_TwoOnTwo_ConcatenatedTwoLines()
    {
        var matrix = new[,] { { 'A', 'B' }, { 'C', 'D' } };
        Assert.Equal("A B\nC D", matrix.ToString());
    }
 
}

public class Diamond
{
    public static char[,] Generate(char letter)
    {
        return new[,] { { 'A' } };
    }
}
