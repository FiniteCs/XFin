using System.Collections.Immutable;

namespace CLP;

public sealed class ParsedCommand
{
    internal ParsedCommand(Command command, ImmutableArray<ParsedArgument> parsedArguments)
    {
        Command = command;
        ParsedArguments = parsedArguments;
    }

    public Command Command { get; }
    public ImmutableArray<ParsedArgument> ParsedArguments { get; }
}
