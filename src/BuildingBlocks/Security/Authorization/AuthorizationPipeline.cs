namespace OpenHealthOS.Security.Authorization;

using OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Provides the application authorization pipeline by delegating
/// authorization requests to the authorization service.
/// </summary>
public sealed class AuthorizationPipeline : IAuthorizationPipeline
{
    private readonly IAuthorizationService _authorizationService;

    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="AuthorizationPipeline"/> class.
    /// </summary>
    /// <param name="authorizationService">
    /// The authorization service used to evaluate requests.
    /// </param>
    public AuthorizationPipeline(
        IAuthorizationService authorizationService)
    {
        ArgumentNullException.ThrowIfNull(authorizationService);

        _authorizationService = authorizationService;
    }

    /// <summary>
    /// Evaluates an authorization request.
    /// </summary>
    /// <param name="request">
    /// The authorization request to evaluate.
    /// </param>
    /// <returns>
    /// The authorization decision returned by the authorization service.
    /// </returns>
    public AuthorizationDecision Authorize(
        AuthorizationRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        return _authorizationService.Authorize(request.Context);
    }
}
