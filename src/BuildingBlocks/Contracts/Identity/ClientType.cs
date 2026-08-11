namespace OpenHealthOS.Contracts.Identity;

/// <summary>
/// Represents the type of application or workload requesting access
/// to OpenHealthOS.
/// </summary>
public enum ClientType
{
    /// <summary>
    /// A web application.
    /// </summary>
    WebApplication = 1,

    /// <summary>
    /// A mobile application.
    /// </summary>
    MobileApplication = 2,

    /// <summary>
    /// A backend service.
    /// </summary>
    Service = 3,

    /// <summary>
    /// An external or partner application.
    /// </summary>
    ExternalApplication = 4,

    /// <summary>
    /// An AI or machine-learning workload.
    /// </summary>
    AIWorkload = 5
}