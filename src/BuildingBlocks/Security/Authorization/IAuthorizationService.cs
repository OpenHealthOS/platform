namespace OpenHealthOS.Security.Authorization;

using OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Provides the application-facing authorization service.
/// </summary>
public interface IAuthorizationService
{
    /// <summary>
    /// Evaluates whether the specified authorization context is allowed.
    /// </summary>
    /// <param name="context">
    /// The authorization context to evaluate.
    /// </param>
    /// <returns>
    /// The authorization decision.
    /// </returns>
    AuthorizationDecision Authorize(AuthorizationContextDto context);
}
