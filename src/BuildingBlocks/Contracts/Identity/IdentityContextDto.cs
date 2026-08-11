namespace OpenHealthOS.Contracts.Identity;

/// <summary>
/// Represents the identity information associated with an authenticated
/// OpenHealthOS request.
/// </summary>
public sealed record IdentityContextDto
{
    /// <summary>
    /// Gets the unique identifier of the authenticated subject.
    /// </summary>
    public required string SubjectId { get; init; }

    /// <summary>
    /// Gets the type of the effective security principal.
    /// </summary>
    public required PrincipalType PrincipalType { get; init; }

    /// <summary>
    /// Gets the identifier of the client application requesting access.
    /// </summary>
    public string? ClientId { get; init; }

    /// <summary>
    /// Gets the identifier of the organization associated with the request.
    /// </summary>
    public string? OrganizationId { get; init; }

    /// <summary>
    /// Gets the identifier of the tenant associated with the request.
    /// </summary>
    public string? TenantId { get; init; }

    /// <summary>
    /// Gets the roles associated with the authenticated principal.
    /// </summary>
    public IReadOnlyCollection<string> Roles { get; init; } =
        Array.Empty<string>();

    /// <summary>
    /// Gets the OAuth scopes granted to the request.
    /// </summary>
    public IReadOnlyCollection<string> Scopes { get; init; } =
        Array.Empty<string>();
}