namespace DiamondKata;

public class Diamond
{
    public static char[,] Generate(char letter)
    {
        if (letter == default)
        {
            throw new ArgumentNullException(nameof(letter));
        }

        if (letter is < 'A' or > 'Z')
        {
            //Throw an exception with list of valid letters
            throw new ArgumentException("Invalid letter. Please use capital a letter between A and Z.");
        }

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
