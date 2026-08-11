namespace OpenHealthOS.Contracts.Authorization;

using OpenHealthOS.Contracts.Identity;

/// <summary>
/// Represents the information required to evaluate an authorization request.
/// </summary>
public sealed record AuthorizationContextDto
{
    /// <summary>
    /// Gets the authenticated identity associated with the request.
    /// </summary>
    public required IdentityContextDto Identity { get; init; }

    /// <summary>
    /// Gets the permission being requested.
    /// </summary>
    public required Permission Permission { get; init; }

    /// <summary>
    /// Gets the resource type against which authorization is evaluated.
    /// </summary>
    public required string ResourceType { get; init; }

    /// <summary>
    /// Gets the optional resource identifier.
    /// </summary>
    public string? ResourceId { get; init; }

    /// <summary>
    /// Gets the optional tenant identifier associated with the resource.
    /// </summary>
    public string? TenantId { get; init; }

    /// <summary>
    /// Gets the optional organization identifier associated with the resource.
    /// </summary>
    public string? OrganizationId { get; init; }
}
