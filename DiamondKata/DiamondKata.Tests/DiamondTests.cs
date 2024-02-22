namespace DiamondKata.Tests;

public class DiamondTests
{
    [Fact]
    public void Test1()
    {
        Assert.Equal("A",
            Diamond.Generate('A'));
    }
}

public class Diamond
{
    public static string Generate(char letter)
    {
        return "A";
    }
}
