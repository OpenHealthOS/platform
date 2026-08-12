namespace OpenHealthOS.UnitTests.Authorization;

using OpenHealthOS.Contracts.Authorization;
using OpenHealthOS.Contracts.Identity;
using OpenHealthOS.Security.Authorization;
using Xunit;

public sealed class PermissionPolicyTests
{
    [Fact]
    public void IsSatisfied_ShouldReturnTrue_WhenPermissionMatches()
    {
        var policy = new PermissionPolicy(
            new Permission("patient.read"));

        var context = CreateContext("patient.read");

        var result = policy.IsSatisfied(context);

        Assert.True(result);
    }

    [Fact]
    public void IsSatisfied_ShouldReturnTrue_WhenPermissionMatchesIgnoringCase()
    {
        var policy = new PermissionPolicy(
            new Permission("patient.read"));

        var context = CreateContext("PATIENT.READ");

        var result = policy.IsSatisfied(context);

        Assert.True(result);
    }

    [Fact]
    public void IsSatisfied_ShouldReturnFalse_WhenPermissionDoesNotMatch()
    {
        var policy = new PermissionPolicy(
            new Permission("patient.read"));

        var context = CreateContext("patient.write");

        var result = policy.IsSatisfied(context);

        Assert.False(result);
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
