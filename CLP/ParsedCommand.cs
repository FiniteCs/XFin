using System.Collections.Immutable;

namespace CLP;

/// <summary>
/// Represents a parsed command.
/// </summary>
public sealed class ParsedCommand
{
    internal ParsedCommand(Command command, ImmutableArray<ParsedArgument> parsedArguments)
    {
        Command = command;
        ParsedArguments = parsedArguments;
    }

    public Command Command { get; }
    public ImmutableArray<ParsedArgument> ParsedArguments { get; }
    public ParsedArgument this[int index] => ParsedArguments[index];
    public ParsedArgument this[string name]
    {
        get
        {
            foreach (ParsedArgument argument in ParsedArguments)
                if (argument.Argument.Name == name)
                    return argument;

            return null;
        }
    }

    public static ParsedCommand Parse(string text, Command command)
    {
        CommandParser commandParser = new(text);
        return commandParser.Parse(command);
    }
}
