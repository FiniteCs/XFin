using CLP;

namespace CLPTest;

internal static class Program
{
    private static void Main()
    {
        Command command = new("DoSum", new Argument(ArgumentType.Double), new Argument(ArgumentType.String));

        string s = Console.ReadLine();
        CommandParser parser = new(s);
        ParsedCommand parsedCommand = parser.Parse(command);
        if (parser.Diagnostics.Any())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (string diagnostic in parser.Diagnostics)
                Console.WriteLine(diagnostic);

            Console.ResetColor();
            goto End;
        }

        Console.WriteLine();

        foreach (ParsedArgument parsedArgument in parsedCommand.ParsedArguments)
        {
            Console.WriteLine(parsedArgument.Argument.ArgumentType);
            Console.WriteLine(parsedArgument.Value);
            Console.WriteLine();
        }

    End:
        return;
    }
}
