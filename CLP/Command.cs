namespace CLP;

public sealed class Command
{
    public Command(string prefix, string cmd, string suffix, params Argument[] arguments)
    {
        Prefix = prefix;
        Cmd = prefix + cmd + suffix;
        Suffix = suffix;
        Arguments = arguments;
    }

    public Command(string cmd, params Argument[] arguments)
        : this(null, cmd, null, arguments)
    {
    }

    public string Prefix { get; }
    public string Cmd { get; }
    public string Suffix { get; }
    public Argument[] Arguments { get; }
}
