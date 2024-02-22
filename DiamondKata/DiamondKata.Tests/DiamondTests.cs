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
        yield return new object[]
        {
            'D',
            new[,]
            {
                { ' ', ' ', ' ', 'A', ' ', ' ', ' ' },
                { ' ', ' ', 'B', ' ', 'B', ' ', ' ' },
                { ' ', 'C', ' ', ' ', ' ', 'C', ' ' },
                { 'D', ' ', ' ', ' ', ' ', ' ', 'D' },
                { ' ', 'C', ' ', ' ', ' ', 'C', ' ' },
                { ' ', ' ', 'B', ' ', 'B', ' ', ' ' },
                { ' ', ' ', ' ', 'A', ' ', ' ', ' ' }
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

    [Theory]
    [InlineData('a')]
    [InlineData('z')]
    [InlineData('1')]
    [InlineData(' ')]
    [InlineData('!')]
    public void Generate_InvalidLetter_ThrowsArgumentException(char letter)
    {
        // Arrange

        // Act
        Action act = () => Diamond.Generate(letter);

        // Assert
        Assert.Throws<ArgumentException>(act);
    }
    
    [Fact]
    public void Generate_NullLetter_ThrowsArgumentNullException()
    {
        // Arrange

        // Act
        Action act = () => Diamond.Generate(default);

        // Assert
        Assert.Throws<ArgumentNullException>(act);
    }
    
}

public class Diamond
{
    public static char[,] Generate(char letter)
    {
        int letterIndex = letter - 'A' + 1;
        int lines = letterIndex * 2 - 1;
        int columns = letterIndex * 2 - 1;
        var matrix = new char[lines, columns];


        for (var line = 0; line < lines; line++)
        {
            for (var column = 0; column < columns; column++)
            {
                if ((line < letterIndex && column == letterIndex - line - 1) ||
                    column == letterIndex + line - 1)
                {
                    matrix[line,
                        column] = (char)('A' + line);
                }
                else if (column == line - letterIndex + 1 ||
                         column == columns - line + letterIndex - 2)
                {
                    matrix[line,
                        column] = (char)('A' + lines - line - 1);
                }
                else
                {
                    matrix[line,
                        column] = ' ';
                }
            }
        }

        return matrix;
    }
}
