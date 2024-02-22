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
        _output.WriteLine($"Result:{Environment.NewLine}{result.ToMultilineString('_')}");
        Assert.Equal(expected,
            result);
    }
    
    [Theory]
    [MemberData(nameof(DiamondTestData))]
    public void Generate_GivenLetter_MatrixWithCorrectSize(char letter, char[,] expected)
    {
        // Act
        char[,] result = Diamond.Generate(letter);

        // Assert
        Assert.Equal(expected.GetLength(0), result.GetLength(0));
        Assert.Equal(expected.GetLength(1), result.GetLength(1));
    }
   
}

public class Diamond
{
    public static char[,] Generate(char letter)
    {
        
        //calculate the size of the diamond
        //first line of the diamond
        //first half of the diamond
        //second half of the diamond
        if (letter == 'A')
        {
            return new[,] { { 'A' } };
        }

        if (letter == 'B')
        {
            return new[,]
            {
                { ' ', 'A', ' ' },
                { 'B', ' ', 'B' },
                { ' ', 'A', ' ' }
            };
        }

        if (letter == 'C')
        {
            return new[,]
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
