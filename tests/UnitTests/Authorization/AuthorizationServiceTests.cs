namespace OpenHealthOS.UnitTests.Authorization;

using OpenHealthOS.Contracts.Authorization;
using OpenHealthOS.Contracts.Identity;
using OpenHealthOS.Security.Authorization;
using Xunit;

public sealed class AuthorizationServiceTests
{
    [Fact]
    public void Authorize_ShouldReturnAllow_WhenEvaluatorAllows()
    {
        var evaluator = new StubAuthorizationEvaluator(
            AuthorizationDecision.Allow);

        var service = new AuthorizationService(evaluator);

        var result = service.Authorize(CreateContext());

        Assert.Equal(
            AuthorizationDecision.Allow,
            result);
    }

    [Fact]
    public void Authorize_ShouldReturnDeny_WhenEvaluatorDenies()
    {
        var evaluator = new StubAuthorizationEvaluator(
            AuthorizationDecision.Deny);

        var service = new AuthorizationService(evaluator);

        var result = service.Authorize(CreateContext());

        Assert.Equal(
            AuthorizationDecision.Deny,
            result);
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenEvaluatorIsNull()
    {
        Assert.Throws<ArgumentNullException>(
            () => new AuthorizationService(null!));
    }

    [Fact]
    public void Authorize_ShouldThrow_WhenContextIsNull()
    {
        var evaluator = new StubAuthorizationEvaluator(
            AuthorizationDecision.Allow);

        var service = new AuthorizationService(evaluator);

        Assert.Throws<ArgumentNullException>(
            () => service.Authorize(null!));
    }

    [Fact]
    public void Authorize_ShouldDelegateToEvaluator()
    {
        var evaluator = new StubAuthorizationEvaluator(
            AuthorizationDecision.Allow);

        var service = new AuthorizationService(evaluator);

        var context = CreateContext();

        service.Authorize(context);

        Assert.Same(context, evaluator.LastContext);
    }

    private static AuthorizationContextDto CreateContext()
    {
        return new AuthorizationContextDto
        {
            Identity = new IdentityContextDto
            {
                SubjectId = "test-user",
                PrincipalType = PrincipalType.User,
                Scopes = ["patient.read"],
            },
            Permission = new Permission("patient.read"),
            ResourceType = "Patient",
        };
    }

    private sealed class StubAuthorizationEvaluator
        : IAuthorizationEvaluator
    {
        private readonly AuthorizationDecision _decision;

        public StubAuthorizationEvaluator(
            AuthorizationDecision decision)
        {
            _decision = decision;
        }

        public AuthorizationContextDto? LastContext { get; private set; }

        public AuthorizationDecision Evaluate(
            AuthorizationContextDto context)
        {
            LastContext = context;

            return _decision;
        }
    }
}
