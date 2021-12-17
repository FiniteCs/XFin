using CLP;

namespace CLPTest;

internal static class Program
{
    private static void Main()
    {
        Command[] commands =
        {
             new("-", "Cmd", null, new Argument(ArgumentType.Double, "Arg1"), new Argument(ArgumentType.String, "Arg2")),
             new(":", "Cmd1", "-", new Argument(ArgumentType.Int8, "Arg1"), new Argument(ArgumentType.Double, "Arg2"))
        };

        string s = Console.ReadLine();
        CommandParser parser = new(s);
        ParsedCommand parsedCommand = parser.Parse(commands);
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
