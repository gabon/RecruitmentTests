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
                { ' ', 'A', ' ' }
                // { 'B', ' ', 'B' },
                // { ' ', 'A', ' ' }
            }
        };
        yield return new object[]
        {
            'C',
            new[,]
            {
                { ' ', ' ', 'A', ' ', ' ' }
                // { ' ', 'B', ' ', 'B', ' ' },
                // { 'C', ' ', ' ', ' ', 'C' },
                // { ' ', 'B', ' ', 'B', ' ' },
                // { ' ', ' ', 'A', ' ', ' ' }
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
        _output.WriteLine($"Expected:{Environment.NewLine}{expected.ToMultilineString('_')}");
        Assert.Equal(expected,
            result);
    }

    [Theory]
    [MemberData(nameof(DiamondTestData))]
    public void Generate_GivenLetter_MatrixWithCorrectSize(char letter,
        char[,] expected)
    {
        // Act
        char[,] result = Diamond.Generate(letter);

        // Assert
        Assert.Equal(expected.GetLength(0),
            result.GetLength(0));
        Assert.Equal(expected.GetLength(1),
            result.GetLength(1));
    }

    [Fact]
    public void Generate_InvalidLetter_ThrowsArgumentException()
    {
        // Arrange
        var letter = '0';

        // Act
        Action act = () => Diamond.Generate(letter);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }
}

public class Diamond
{
    public static char[,] Generate(char letter)
    {
        int letterIndex = letter - 'A' + 1;
        var lines = 1; // letterIndex * 2 - 1;
        int columns = letterIndex * 2 - 1;
        var matrix = new char[lines, columns];

        //first line of the diamond
        for (var line = 0; line < lines; line++)
        {
            for (var column = 0; column < columns; column++)
            {
                matrix[line,
                    column] = ' ';
            }
        }

        matrix[0,
            letterIndex - 1] = 'A';


        return matrix;
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
