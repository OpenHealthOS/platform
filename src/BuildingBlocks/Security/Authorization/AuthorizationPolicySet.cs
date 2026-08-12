namespace OpenHealthOS.Security.Authorization;

using OpenHealthOS.Contracts.Authorization;

/// <summary>
/// Evaluates a collection of authorization policies using AND semantics.
/// </summary>
public sealed class AuthorizationPolicySet : IAuthorizationPolicySet
{
    private readonly IReadOnlyCollection<IAuthorizationPolicy> _policies;

    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="AuthorizationPolicySet"/> class.
    /// </summary>
    /// <param name="policies">
    /// The policies that must all be satisfied.
    /// </param>
    public AuthorizationPolicySet(
        IEnumerable<IAuthorizationPolicy> policies)
    {
        ArgumentNullException.ThrowIfNull(policies);

        _policies = policies.ToArray();

        if (_policies.Any(policy => policy is null))
        {
            throw new ArgumentException(
                "Policy collection cannot contain null policies.",
                nameof(policies));
        }
    }

    /// <summary>
    /// Determines whether all policies are satisfied.
    /// </summary>
    /// <param name="context">
    /// The authorization context to evaluate.
    /// </param>
    /// <returns>
    /// <see langword="true"/> when every policy is satisfied;
    /// otherwise <see langword="false"/>.
    /// </returns>
    public bool IsSatisfied(AuthorizationContextDto context)
    {
        ArgumentNullException.ThrowIfNull(context);

        return _policies.All(policy => policy.IsSatisfied(context));
    }
}
