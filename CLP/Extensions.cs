namespace CLP;

public static class Extensions
{
    public static bool IsInteger(this ArgumentType type)
    {
        switch (type)
        {
            case ArgumentType.Int8:
            case ArgumentType.Int16:
            case ArgumentType.Int32:
            case ArgumentType.Int64:
            case ArgumentType.Uint8:
            case ArgumentType.Uint16:
            case ArgumentType.Uint32:
            case ArgumentType.Uint64:
                return true;
            default:
                return false;
        }
    }
}