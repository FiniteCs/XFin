namespace CLP;

/// <summary>
/// The basic argument to be passed into a command.
/// </summary>
public sealed class Argument
{
    public Argument(ArgumentType type, string name)
    {
        ArgumentType = type;
        Name = name;
    }

    /// <summary>
    /// The type of the argument
    /// </summary>
    public ArgumentType ArgumentType { get; }
    public string Name { get; }
}
