// See https://aka.ms/new-console-template for more information

using DiamondKata;

if (args.Length != 1 || args[0].Length != 1)
{
    Console.WriteLine("Please enter a single character.");
    return;
}

try
{
    char letter = args[0][0];
    char[,] result = Diamond.Generate(letter);
    Console.WriteLine(result.ToMultilineString());
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
