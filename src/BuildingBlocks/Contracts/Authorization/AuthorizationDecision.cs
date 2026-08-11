namespace OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Represents the outcome of an authorization evaluation.
/// </summary>
public enum AuthorizationDecision
{
    /// <summary>
    /// Access is allowed.
    /// </summary>
    Allow = 1,

    /// <summary>
    /// Access is denied.
    /// </summary>
    Deny = 2,
}
