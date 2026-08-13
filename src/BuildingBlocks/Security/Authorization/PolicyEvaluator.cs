namespace OpenHealthOS.Security.Authorization;

using OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Evaluates authorization requests using an authorization policy set.
/// </summary>
public sealed class PolicyEvaluator : IAuthorizationEvaluator
{
    private readonly IAuthorizationPolicySet _policySet;

    /// <summary>
    /// Initializes a new instance of the <see cref="PolicyEvaluator"/> class.
    /// </summary>
    /// <param name="policySet">
    /// The authorization policy set used to evaluate requests.
    /// </param>
    public PolicyEvaluator(IAuthorizationPolicySet policySet)
    {
        ArgumentNullException.ThrowIfNull(policySet);

        _policySet = policySet;
    }

    /// <summary>
    /// Evaluates whether the authorization context satisfies the policy set.
    /// </summary>
    /// <param name="context">
    /// The authorization context to evaluate.
    /// </param>
    /// <returns>
    /// <see cref="AuthorizationDecision.Allow"/> when all policies are
    /// satisfied; otherwise <see cref="AuthorizationDecision.Deny"/>.
    /// </returns>
    public AuthorizationDecision Evaluate(AuthorizationContextDto context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return _policySet.IsSatisfied(context)
            ? AuthorizationDecision.Allow
            : AuthorizationDecision.Deny;
    }
}
