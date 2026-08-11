namespace OpenHealthOS.Contracts.Identity;

/// <summary>
/// Standard and OpenHealthOS-specific identity claim names.
/// </summary>
public static class IdentityClaims
{
    /// <summary>
    /// Unique identifier of the authenticated subject.
    /// </summary>
    public const string Subject = "sub";

    /// <summary>
    /// Identifier of the OAuth/OIDC client requesting access.
    /// </summary>
    public const string ClientId = "client_id";

    /// <summary>
    /// Authorized OAuth scopes.
    /// </summary>
    public const string Scope = "scope";

    /// <summary>
    /// Assigned role.
    /// </summary>
    public const string Role = "role";

    /// <summary>
    /// OpenHealthOS organization identifier.
    /// </summary>
    public const string OrganizationId = "organization_id";

    /// <summary>
    /// OpenHealthOS tenant identifier.
    /// </summary>
    public const string TenantId = "tenant_id";

    /// <summary>
    /// OpenHealthOS principal type.
    /// </summary>
    public const string PrincipalType = "principal_type";
}