namespace OpenHealthOS.Security.Authorization;

using OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Represents the application authorization pipeline.
/// </summary>
public interface IAuthorizationPipeline
{
    /// <summary>
    /// Evaluates an authorization request.
    /// </summary>
    /// <param name="request">
    /// The authorization request to evaluate.
    /// </param>
    /// <returns>
    /// The resulting authorization decision.
    /// </returns>
    AuthorizationDecision Authorize(
        AuthorizationRequest request);
}
