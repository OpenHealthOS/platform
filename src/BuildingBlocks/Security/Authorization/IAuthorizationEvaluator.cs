namespace OpenHealthOS.Security.Authorization;

using OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Evaluates whether an authorization request is allowed.
/// </summary>
public interface IAuthorizationEvaluator
{
    /// <summary>
    /// Evaluates the specified authorization context.
    /// </summary>
    /// <param name="context">The authorization context to evaluate.</param>
    /// <returns>The authorization decision.</returns>
    AuthorizationDecision Evaluate(AuthorizationContextDto context);
}
