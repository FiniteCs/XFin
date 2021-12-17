namespace CLP;

/// <summary>
/// The command class, used to define new commands.
/// </summary>
public sealed class Command
{
    /// <summary>
    /// Constructor for the command.
    /// <para><paramref name="prefix"/>: The string that comes before the command.</para>
    /// <para><paramref name="cmd"/>: The base command.</para>
    /// <para><paramref name="suffix"/>: The string that comes after the command.</para>
    /// <para><paramref name="arguments"/>: The arguments for the command.</para>
    /// </summary>
    /// <param name="prefix"></param>
    /// <param name="cmd"></param>
    /// <param name="suffix"></param>
    /// <param name="arguments"></param>
    public Command(string prefix, string cmd, string suffix, params Argument[] arguments)
    {
        Prefix = prefix;
        Cmd = prefix + cmd + suffix;
        Suffix = suffix;
        Arguments = arguments;
    }

    /// <summary>
    /// Constructor for the command, excluding the prefix, and suffix
    /// <para><paramref name="cmd"/>: The base command.</para>
    /// <para><paramref name="arguments"/>: The arguments for the command.</para>
    /// </summary>
    /// <param name="cmd"></param>
    /// <param name="arguments"></param>
    public Command(string cmd, params Argument[] arguments)
        : this(null, cmd, null, arguments)
    {
    }

    /// <summary>
    /// The command's prefix
    /// </summary>
    public string Prefix { get; }

    /// <summary>
    /// The command's prefix including prefix and suffix
    /// </summary>
    public string Cmd { get; }

    /// <summary>
    /// The command's suffix
    /// </summary>
    public string Suffix { get; }

    /// <summary>
    /// The command's arguments
    /// </summary>
    public Argument[] Arguments { get; }
}
