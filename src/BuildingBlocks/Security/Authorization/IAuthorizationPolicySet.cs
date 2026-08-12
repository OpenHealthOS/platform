namespace OpenHealthOS.Security.Authorization;

using OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Represents a composition of authorization policies.
/// </summary>
public interface IAuthorizationPolicySet
{
    /// <summary>
    /// Determines whether the authorization context satisfies all policies
    /// in the set.
    /// </summary>
    /// <param name="context">
    /// The authorization context to evaluate.
    /// </param>
    /// <returns>
    /// <see langword="true"/> when all policies are satisfied;
    /// otherwise <see langword="false"/>.
    /// </returns>
    bool IsSatisfied(AuthorizationContextDto context);
}
