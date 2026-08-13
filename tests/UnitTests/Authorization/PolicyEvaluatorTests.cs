namespace OpenHealthOS.UnitTests.Authorization;

using OpenHealthOS.Contracts.Authorization;
using OpenHealthOS.Contracts.Identity;
using OpenHealthOS.Security.Authorization;
using Xunit;

public sealed class PolicyEvaluatorTests
{
    [Fact]
    public void Evaluate_ShouldAllow_WhenPolicySetIsSatisfied()
    {
        var policySet = new AuthorizationPolicySet(
        [
            new PermissionPolicy(new Permission("patient.read")),
        ]);

        var evaluator = new PolicyEvaluator(policySet);

        var context = CreateContext("patient.read");

        var result = evaluator.Evaluate(context);

        Assert.Equal(
            AuthorizationDecision.Allow,
            result);
    }

    [Fact]
    public void Evaluate_ShouldDeny_WhenPolicySetIsNotSatisfied()
    {
        var policySet = new AuthorizationPolicySet(
        [
            new PermissionPolicy(new Permission("patient.write")),
        ]);

        var evaluator = new PolicyEvaluator(policySet);

        var context = CreateContext("patient.read");

        var result = evaluator.Evaluate(context);

        Assert.Equal(
            AuthorizationDecision.Deny,
            result);
    }

    [Fact]
    public void Evaluate_ShouldAllow_WhenAllPoliciesAreSatisfied()
    {
        var policySet = new AuthorizationPolicySet(
        [
            new PermissionPolicy(new Permission("patient.read")),
            new PermissionPolicy(new Permission("patient.read")),
        ]);

        var evaluator = new PolicyEvaluator(policySet);

        var context = CreateContext("patient.read");

        var result = evaluator.Evaluate(context);

        Assert.Equal(
            AuthorizationDecision.Allow,
            result);
    }

    [Fact]
    public void Evaluate_ShouldDeny_WhenAnyPolicyIsNotSatisfied()
    {
        var policySet = new AuthorizationPolicySet(
        [
            new PermissionPolicy(new Permission("patient.read")),
            new PermissionPolicy(new Permission("patient.write")),
        ]);

        var evaluator = new PolicyEvaluator(policySet);

        var context = CreateContext("patient.read");

        var result = evaluator.Evaluate(context);

        Assert.Equal(
            AuthorizationDecision.Deny,
            result);
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenPolicySetIsNull()
    {
        Assert.Throws<ArgumentNullException>(
            () => new PolicyEvaluator(null!));
    }

    [Fact]
    public void Evaluate_ShouldThrow_WhenContextIsNull()
    {
        var policySet = new AuthorizationPolicySet(
        [
            new PermissionPolicy(new Permission("patient.read")),
        ]);

        var evaluator = new PolicyEvaluator(policySet);

        Assert.Throws<ArgumentNullException>(
            () => evaluator.Evaluate(null!));
    }

    private static AuthorizationContextDto CreateContext(
        string permission)
    {
        return new AuthorizationContextDto
        {
            Identity = new IdentityContextDto
            {
                SubjectId = "test-user",
                PrincipalType = PrincipalType.User,
                Scopes = [permission],
            },
            Permission = new Permission(permission),
            ResourceType = "Patient",
        };
    }
}
