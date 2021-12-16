namespace CLP;

/// <summary>
/// Represents all valid types for an <seealso cref="Argument"/>.
/// </summary>
public enum ArgumentType
{
    /// <summary>
    /// Represent an <see langword="int8"/>: -128 to 127
    /// </summary>
    Int8,

    /// <summary>
    /// Represents an <see langword="int16"/>: -32,768 to 32,767
    /// </summary>
    Int16,

    /// <summary>
    /// Represents an <see langword="int32"/>: -2,147,483,648 to 2,147,483,647
    /// </summary>
    Int32,

    /// <summary>
    /// Represents a <see langword="int64"/>: -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
    /// </summary>
    Int64,

    /// <summary>
    /// Represent an <see langword="unsigned int8"/>: 0 to 255
    /// </summary>
    Uint8,

    /// <summary>
    /// Represent an <see langword="unsigned int16"/>: 0 to 65,536
    /// </summary>
    Uint16,

    /// <summary>
    /// Represent an <see langword="unsigned int32"/>: 0 to 4,294,967,296
    /// </summary>
    Uint32,

    /// <summary>
    /// Represent an <see langword="unsigned int16"/>: 0 to 18,446,744,073,709,551,616
    /// </summary>
    Uint64,

    /// <summary>
    /// Represent a <see langword="float"/>: ±1.5 * 10−45 to ±3.4 * 1038, ~6-9 digits
    /// </summary>
    Float,

    /// <summary>
    /// Represent a <see langword="double"/>: ±5.0 * 10−324 to ±1.7 * 10308, ~15-17 digits
    /// </summary>
    Double,

    /// <summary>
    /// Represent a <see langword="decimal"/>: ±1.0 * 10-28 to ±7.9228 * 1028, 28-29 digits
    /// </summary>
    Decimal,

    /// <summary>
    /// Represent a <see langword="string"/>
    /// </summary>
    String
}
