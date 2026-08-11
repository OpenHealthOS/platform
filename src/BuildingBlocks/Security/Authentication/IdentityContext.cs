namespace OpenHealthOS.Security.Authentication;

using OpenHealthOS.Contracts.Identity;

/// <summary>
/// Default implementation of <see cref="IIdentityContext"/>.
/// </summary>
public sealed class IdentityContext : IIdentityContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IdentityContext"/> class
    /// representing an unauthenticated request.
    /// </summary>
    public IdentityContext()
    {
        Roles = Array.Empty<string>();
        Scopes = Array.Empty<string>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="IdentityContext"/> class
    /// using the supplied identity contract.
    /// </summary>
    /// <param name="identity">The identity information.</param>
    public IdentityContext(IdentityContextDto identity)
    {
        ArgumentNullException.ThrowIfNull(identity);

        IsAuthenticated = true;
        SubjectId = identity.SubjectId;
        PrincipalType = identity.PrincipalType;
        ClientId = identity.ClientId;
        OrganizationId = identity.OrganizationId;
        TenantId = identity.TenantId;
        Roles = identity.Roles.ToArray();
        Scopes = identity.Scopes.ToArray();
    }

    /// <inheritdoc />
    public bool IsAuthenticated { get; }

    /// <inheritdoc />
    public string? SubjectId { get; }

    /// <inheritdoc />
    public PrincipalType? PrincipalType { get; }

    /// <inheritdoc />
    public string? ClientId { get; }

    /// <inheritdoc />
    public string? OrganizationId { get; }

    /// <inheritdoc />
    public string? TenantId { get; }

    /// <inheritdoc />
    public IReadOnlyCollection<string> Roles { get; }

    /// <inheritdoc />
    public IReadOnlyCollection<string> Scopes { get; }
}