namespace OpenHealthOS.Security.Authorization;

using OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Provides access to the authorization context associated with the current request.
/// </summary>
public interface IAuthorizationContext
{
    /// <summary>
    /// Gets the permission being evaluated.
    /// </summary>
    Permission Permission { get; }

    /// <summary>
    /// Gets the resource type against which authorization is evaluated.
    /// </summary>
    string ResourceType { get; }

    /// <summary>
    /// Gets the optional resource identifier.
    /// </summary>
    string? ResourceId { get; }

    /// <summary>
    /// Gets the tenant identifier associated with the authorization request.
    /// </summary>
    string? TenantId { get; }

    /// <summary>
    /// Gets the organization identifier associated with the authorization request.
    /// </summary>
    string? OrganizationId { get; }
}
