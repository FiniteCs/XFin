using System.Collections.Immutable;

namespace CLP;

/// <summary>
/// The command parser.
/// </summary>
public sealed class CommandParser
{
    private readonly string _text;
    private int _position;
    private readonly List<string> _diagnostics;

    public CommandParser(string text)
    {
        _text = text;
        _diagnostics = new();
    }

    public ImmutableArray<string> Diagnostics => _diagnostics.ToImmutableArray();

    private char Peek(int offset)
    {
        int index = _position + offset;
        if (index >= _text.Length)
            return '\0';

        return _text[index];
    }

    private char Current => Peek(0);

    /// <summary>
    /// Parse a command from the text
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    public ParsedCommand Parse(Command command)
    {
        if (Current == command.Cmd[0])
        {
            int start = _position;
            while (_position < command.Cmd.Length)
                _position++;

            int length = _position - start;
            string text = _text.Substring(start, length);
            if (text != command.Cmd)
            {
                int i = _position;
                while (!char.IsWhiteSpace(Current) &&
                       Current != '\0')
                    _position++;

                int len = _position - i;
                string s = _text.Substring(i, len);

                _diagnostics.Add($"Invalid command \"{s}\"");
                return null;
            }
        }
        else
        {
            int start = _position;
            while (!char.IsWhiteSpace(Current) &&
                   Current != '\0')
                _position++;

            int length = _position - start;
            string text = _text.Substring(start, length);

            _diagnostics.Add($"Invalid command \"{text}\"");
            return null;
        }

        List<ParsedArgument> parsedArguments = new();
        foreach (Argument argument in command.Arguments)
        {
            ParsedArgument parsedArgument = ParseArgument(argument);
            if (parsedArgument == null)
                continue;

            parsedArguments.Add(parsedArgument);
        }

        return new ParsedCommand(command, parsedArguments.ToImmutableArray());
    }

    private ParsedArgument ParseArgument(Argument argument)
    {
        if (char.IsWhiteSpace(Current))
        {
            while (char.IsWhiteSpace(Current))
                _position++;
        }

        int start = _position;
        if (Current == '\0')
            return null;


        if (Current == '\"')
        {
            // Skip the quote
            _position++;
            start = _position;
            while (Current != '\"')
            {
                if (Current == '\0')
                {
                    _diagnostics.Add($"Unterminated string.");
                    return null;
                }
                _position++;
            }

            int length = _position - start;
            string text = _text.Substring(start, length);

            // Skip the quote
            _position++;

            if (argument.ArgumentType != ArgumentType.String)
            {
                _diagnostics.Add($"Invalid argument type {ArgumentType.String} expected {argument.ArgumentType}.");
                return null;
            }
            return new ParsedArgument(argument, text, text);
        }

        if (char.IsDigit(Current))
        {
            bool pointFound = false;
            while (char.IsDigit(Current) ||
                  (Current == '.' && pointFound == false))
                _position++;

            if (pointFound &&
                argument.ArgumentType.IsInteger())
            {
                _diagnostics.Add($"Result type is a pointed value, where {argument.ArgumentType} is an integer.");
                return null;
            }
            else if (argument.ArgumentType == ArgumentType.String)
            {
                _diagnostics.Add($"Invalid argument type {argument.ArgumentType} expected {ArgumentType.String}.");
                return null;
            }

            int length = _position - start;
            string text = _text.Substring(start, length);
            object value = GetValue(argument.ArgumentType, text);
            return new ParsedArgument(argument, text, value);
        }

        _diagnostics.Add($"Unexpected character: '{Current}'");
        return null;
    }

    private object GetValue(ArgumentType type, string text)
    {
        switch (type)
        {
            case ArgumentType.Int8:
                if (sbyte.TryParse(text, out sbyte i8))
                    return i8;

                goto default;
            case ArgumentType.Int16:
                if (short.TryParse(text, out short i16))
                    return i16;

                goto default;
            case ArgumentType.Int32:
                if (int.TryParse(text, out int i32))
                    return i32;

                goto default;
            case ArgumentType.Int64:
                if (long.TryParse(text, out long i64))
                    return i64;

                goto default;
            case ArgumentType.Uint8:
                if (byte.TryParse(text, out byte ui8))
                    return ui8;

                goto default;
            case ArgumentType.Uint16:
                if (ushort.TryParse(text, out ushort ui16))
                    return ui16;

                goto default;
            case ArgumentType.Uint32:
                if (uint.TryParse(text, out uint ui32))
                    return ui32;

                goto default;
            case ArgumentType.Uint64:
                if (ulong.TryParse(text, out ulong ui64))
                    return ui64;

                goto default;
            case ArgumentType.Float:
                if (float.TryParse(text, out float flo))
                    return flo;

                goto default;
            case ArgumentType.Double:
                if (double.TryParse(text, out double dou))
                    return dou;

                goto default;
            case ArgumentType.Decimal:
                if (decimal.TryParse(text, out decimal dec))
                    return dec;

                goto default;
            case ArgumentType.String:
                return text;
            default:
                _diagnostics.Add($"Failed to parse value '{text}'");
                return null;
        }
    }
}
