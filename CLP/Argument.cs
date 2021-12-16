namespace CLP;

public sealed class Argument
{
    public Argument(ArgumentType type)
    {
        ArgumentType = type;
    }

    public ArgumentType ArgumentType { get; }
}
