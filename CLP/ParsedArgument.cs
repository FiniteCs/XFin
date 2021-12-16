namespace CLP;

public sealed class ParsedArgument
{
    internal ParsedArgument(Argument argument, string text, object value)
    {
        Argument = argument;
        Text = text;
        Value = value;
    }

    public Argument Argument { get; }
    public string Text { get; }
    public object Value { get; }
}
