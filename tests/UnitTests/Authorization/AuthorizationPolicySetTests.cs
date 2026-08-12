namespace OpenHealthOS.UnitTests.Authorization;

using OpenHealthOS.Contracts.Authorization;
using OpenHealthOS.Contracts.Identity;
using OpenHealthOS.Security.Authorization;
using Xunit;

public sealed class AuthorizationPolicySetTests
{
    [Fact]
    public void IsSatisfied_ShouldAllow_WhenAllPoliciesAreSatisfied()
    {
        var context = CreateContext("patient.read");

        var policySet = new AuthorizationPolicySet(
        [
            new PermissionPolicy(new Permission("patient.read")),
            new PermissionPolicy(new Permission("PATIENT.READ")),
        ]);

        var result = policySet.IsSatisfied(context);

        Assert.True(result);
    }

    [Fact]
    public void IsSatisfied_ShouldDeny_WhenAnyPolicyIsNotSatisfied()
    {
        var context = CreateContext("patient.read");

        var policySet = new AuthorizationPolicySet(
        [
            new PermissionPolicy(new Permission("patient.read")),
            new PermissionPolicy(new Permission("patient.write")),
        ]);

        var result = policySet.IsSatisfied(context);

        Assert.False(result);
    }

    [Fact]
    public void IsSatisfied_ShouldAllow_WhenPolicySetIsEmpty()
    {
        var context = CreateContext("patient.read");

        var policySet = new AuthorizationPolicySet(
            Array.Empty<IAuthorizationPolicy>());

        var result = policySet.IsSatisfied(context);

        Assert.True(result);
    }

    [Fact]
    public void IsSatisfied_ShouldThrow_WhenContextIsNull()
    {
        var policySet = new AuthorizationPolicySet(
        [
            new PermissionPolicy(new Permission("patient.read")),
        ]);

        Assert.Throws<ArgumentNullException>(
            () => policySet.IsSatisfied(null!));
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenPoliciesIsNull()
    {
        Assert.Throws<ArgumentNullException>(
            () => new AuthorizationPolicySet(null!));
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
            },
            Permission = new Permission(permission),
            ResourceType = "Patient",
        };
    }
}
