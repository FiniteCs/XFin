namespace CLP;

/// <summary>
/// The basic argument to be passed into a command.
/// </summary>
public sealed class Argument
{
    public Argument(ArgumentType type)
    {
        ArgumentType = type;
    }

    /// <summary>
    /// The type of the argument
    /// </summary>
    public ArgumentType ArgumentType { get; }
}
