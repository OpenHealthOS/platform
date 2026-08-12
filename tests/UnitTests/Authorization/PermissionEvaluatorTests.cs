namespace OpenHealthOS.UnitTests.Authorization;

using OpenHealthOS.Contracts.Authorization;
using OpenHealthOS.Contracts.Identity;
using OpenHealthOS.Security.Authorization;
using Xunit;

public sealed class PermissionEvaluatorTests
{
    private readonly PermissionEvaluator _evaluator = new();

    [Fact]
    public void Evaluate_ShouldThrow_WhenContextIsNull()
    {
        var action = () => { _evaluator.Evaluate(null!); };

        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void Evaluate_ShouldAllow_WhenPermissionExistsInScopes()
    {
        var context = CreateContext(
            scopes: ["patient.read"]);

        var result = _evaluator.Evaluate(context);

        Assert.Equal(
            AuthorizationDecision.Allow,
            result);
    }

    [Fact]
    public void Evaluate_ShouldDeny_WhenPermissionIsNotGranted()
    {
        var context = CreateContext(
            scopes: ["patient.write"]);

        var result = _evaluator.Evaluate(context);

        Assert.Equal(
            AuthorizationDecision.Deny,
            result);
    }

    [Fact]
    public void Evaluate_ShouldDeny_WhenIdentityHasNoPermissions()
    {
        var context = CreateContext();

        var result = _evaluator.Evaluate(context);

        Assert.Equal(
            AuthorizationDecision.Deny,
            result);
    }

    [Fact]
    public void Evaluate_ShouldBeCaseInsensitive()
    {
        var context = CreateContext(
            scopes: ["PATIENT.READ"]);

        var result = _evaluator.Evaluate(context);

        Assert.Equal(
            AuthorizationDecision.Allow,
            result);
    }

    private static AuthorizationContextDto CreateContext(
    IReadOnlyCollection<string>? scopes = null)
    {
        return new AuthorizationContextDto
        {
            Identity = new IdentityContextDto
            {
                SubjectId = "test-user",
                PrincipalType = PrincipalType.User,
                Scopes = scopes ?? Array.Empty<string>(),
                Roles = Array.Empty<string>(),
            },
            Permission = new Permission("patient.read"),
            ResourceType = "Patient",
        };
    }
}
