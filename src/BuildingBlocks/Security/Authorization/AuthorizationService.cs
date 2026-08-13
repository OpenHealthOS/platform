namespace OpenHealthOS.Security.Authorization;

using OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Provides application-facing authorization by delegating evaluation
/// to an authorization evaluator.
/// </summary>
public sealed class AuthorizationService : IAuthorizationService
{
    private readonly IAuthorizationEvaluator _evaluator;

    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="AuthorizationService"/> class.
    /// </summary>
    /// <param name="evaluator">
    /// The authorization evaluator used to evaluate requests.
    /// </param>
    public AuthorizationService(IAuthorizationEvaluator evaluator)
    {
        ArgumentNullException.ThrowIfNull(evaluator);

        _evaluator = evaluator;
    }

    /// <summary>
    /// Evaluates whether the specified authorization context is allowed.
    /// </summary>
    /// <param name="context">
    /// The authorization context to evaluate.
    /// </param>
    /// <returns>
    /// The authorization decision returned by the evaluator.
    /// </returns>
    public AuthorizationDecision Authorize(
        AuthorizationContextDto context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return _evaluator.Evaluate(context);
    }
}
