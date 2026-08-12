namespace OpenHealthOS.Security.Authorization;

using OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Evaluates authorization permissions using the scopes
/// associated with the authenticated identity.
/// </summary>
public sealed class PermissionEvaluator : IAuthorizationEvaluator
{
    /// <summary>
    /// Evaluates whether the requested permission is granted.
    /// </summary>
    /// <param name="context">
    /// The authorization context to evaluate.
    /// </param>
    /// <returns>
    /// <see cref="AuthorizationDecision.Allow"/> when the permission is
    /// granted; otherwise <see cref="AuthorizationDecision.Deny"/>.
    /// </returns>
    public AuthorizationDecision Evaluate(AuthorizationContextDto context)
    {
        ArgumentNullException.ThrowIfNull(context);

        var permission = context.Permission.Value;

        return context.Identity.Scopes.Contains(
            permission,
            StringComparer.OrdinalIgnoreCase)
            ? AuthorizationDecision.Allow
            : AuthorizationDecision.Deny;
    }
}
