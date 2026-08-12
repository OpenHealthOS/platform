namespace OpenHealthOS.Security.Authorization;

using OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Represents a policy used to determine whether an authorization
/// request satisfies a defined authorization rule.
/// </summary>
public interface IAuthorizationPolicy
{
    /// <summary>
    /// Determines whether the specified authorization context satisfies
    /// this policy.
    /// </summary>
    /// <param name="context">
    /// The authorization context to evaluate.
    /// </param>
    /// <returns>
    /// <see langword="true"/> when the context satisfies the policy;
    /// otherwise <see langword="false"/>.
    /// </returns>
    bool IsSatisfied(AuthorizationContextDto context);
}
