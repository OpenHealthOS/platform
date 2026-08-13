namespace OpenHealthOS.Security.Authorization;

using OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Represents an authorization request submitted to the authorization
/// pipeline.
/// </summary>
public sealed record AuthorizationRequest
{
    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="AuthorizationRequest"/> class.
    /// </summary>
    /// <param name="context">
    /// The authorization context associated with the request.
    /// </param>
    public AuthorizationRequest(AuthorizationContextDto context)
    {
        ArgumentNullException.ThrowIfNull(context);

        Context = context;
    }

    /// <summary>
    /// Gets the authorization context.
    /// </summary>
    public AuthorizationContextDto Context { get; }
}
