namespace OpenHealthOS.Security.Authentication;

using OpenHealthOS.Contracts.Identity;

/// <summary>
/// Provides access to the identity associated with the current request.
/// </summary>
public interface IIdentityContext
{
    /// <summary>
    /// Gets a value indicating whether the current request is authenticated.
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    /// Gets the unique identifier of the authenticated subject.
    /// </summary>
    string? SubjectId { get; }

    /// <summary>
    /// Gets the type of the effective security principal.
    /// </summary>
    PrincipalType? PrincipalType { get; }

    /// <summary>
    /// Gets the identifier of the client application requesting access.
    /// </summary>
    string? ClientId { get; }

    /// <summary>
    /// Gets the organization associated with the current request.
    /// </summary>
    string? OrganizationId { get; }

    /// <summary>
    /// Gets the tenant associated with the current request.
    /// </summary>
    string? TenantId { get; }

    /// <summary>
    /// Gets the roles associated with the current principal.
    /// </summary>
    IReadOnlyCollection<string> Roles { get; }

    /// <summary>
    /// Gets the OAuth scopes associated with the current request.
    /// </summary>
    IReadOnlyCollection<string> Scopes { get; }
}