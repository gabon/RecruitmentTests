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

public class Diamond
{
    public static char[,] Generate(char letter)
    {
        return new[,] { { 'A' } };
    }
}
