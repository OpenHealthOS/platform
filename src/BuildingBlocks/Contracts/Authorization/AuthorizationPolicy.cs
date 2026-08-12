namespace OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Represents a named authorization policy.
/// </summary>
public sealed record AuthorizationPolicy
{
    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="AuthorizationPolicy"/> class.
    /// </summary>
    /// <param name="value">The stable policy identifier.</param>
    public AuthorizationPolicy(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(
                "Authorization policy value cannot be null or whitespace.",
                nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// Gets the stable policy identifier.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Returns the policy identifier.
    /// </summary>
    /// <returns>The policy identifier string.</returns>
    public override string ToString() => Value;
}
