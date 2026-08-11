namespace OpenHealthOS.Contracts.Identity;

/// <summary>
/// Represents the effective security principal associated with a request.
/// </summary>
public enum PrincipalType
{
    /// <summary>
    /// A human user.
    /// </summary>
    User = 1,

    /// <summary>
    /// A service or backend workload.
    /// </summary>
    Service = 2,

    /// <summary>
    /// A workload operating on behalf of the platform,
    /// including AI workloads.
    /// </summary>
    Workload = 3
}