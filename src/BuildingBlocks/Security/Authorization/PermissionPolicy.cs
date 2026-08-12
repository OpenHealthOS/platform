namespace OpenHealthOS.Security.Authorization;

using OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Authorization policy that requires a specific permission.
/// </summary>
public sealed class PermissionPolicy : IAuthorizationPolicy
{
    private readonly Permission _permission;

    /// <summary>
    /// Initializes a new instance of the <see cref="PermissionPolicy"/> class.
    /// </summary>
    /// <param name="permission">
    /// The permission required by this policy.
    /// </param>
    public PermissionPolicy(Permission permission)
    {
        ArgumentNullException.ThrowIfNull(permission);

        _permission = permission;
    }

    /// <summary>
    /// Determines whether the authorization context satisfies the policy.
    /// </summary>
    /// <param name="context">
    /// The authorization context to evaluate.
    /// </param>
    /// <returns>
    /// <see langword="true"/> when the requested permission matches the
    /// policy permission; otherwise <see langword="false"/>.
    /// </returns>
    public bool IsSatisfied(AuthorizationContextDto context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return string.Equals(
            context.Permission.Value,
            _permission.Value,
            StringComparison.OrdinalIgnoreCase);
    }
}
