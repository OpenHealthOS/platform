namespace OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Represents a named authorization permission.
/// </summary>
public sealed record Permission
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Permission"/> class.
    /// </summary>
    /// <param name="value">The stable permission identifier.</param>
    public Permission(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(
                "Permission value cannot be null or whitespace.",
                nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// Gets the stable permission identifier.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Returns the permission identifier.
    /// </summary>
    /// <returns>The permission identifier string.</returns>
    public override string ToString() => Value;
}
