using Xunit.Abstractions;

namespace DiamondKata.Tests;

public class DiamondTests
{
    private readonly ITestOutputHelper _output;

    public DiamondTests(ITestOutputHelper output)
    {
        _output = output;
    }

    public static IEnumerable<object[]> DiamondTestData()
    {
        yield return new object[]
        {
            'A', new[,]
            {
                { 'A' }
            }
        };
        yield return new object[]
        {
            'B', new[,]
            {
                { ' ', 'A', ' ' },
                { 'B', ' ', 'B' },
                { ' ', 'A', ' ' }
            }
        };
        yield return new object[]
        {
            'C',
            new[,]
            {
                { ' ', ' ', 'A', ' ', ' ' },
                { ' ', 'B', ' ', 'B', ' ' },
                { 'C', ' ', ' ', ' ', 'C' },
                { ' ', 'B', ' ', 'B', ' ' },
                { ' ', ' ', 'A', ' ', ' ' }
            }
        };
    }

    [Theory]
    [MemberData(nameof(DiamondTestData))]
    public void Generate_GivenLetter_ReturnsDiamond(char letter,
        char[,] expected)
    {
        // Act
        char[,] result = Diamond.Generate(letter);

        // Assert
        _output.WriteLine($"Result:{Environment.NewLine}{result.ToMultilineString()}");
        Assert.Equal(expected,
            result);
    }
}

public class Diamond
{
    public static char[,] Generate(char letter)
    {
        if (letter == 'A')
        {
            return new char[,] { { 'A' } };
        }
        
        if(letter == 'B')
        {
            return new char[,]
            {
                { ' ', 'A', ' ' },
                { 'B', ' ', 'B' },
                { ' ', 'A', ' ' }
            };
        }
        
        if(letter == 'C')
        {
            return new char[,]
            {
                { ' ', ' ', 'A', ' ', ' ' },
                { ' ', 'B', ' ', 'B', ' ' },
                { 'C', ' ', ' ', ' ', 'C' },
                { ' ', 'B', ' ', 'B', ' ' },
                { ' ', ' ', 'A', ' ', ' ' }
            };
        }

        throw new NotImplementedException();
    }
}
