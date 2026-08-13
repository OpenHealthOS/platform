namespace OpenHealthOS.UnitTests.Authorization;

using OpenHealthOS.Contracts.Authorization;
using OpenHealthOS.Contracts.Identity;
using OpenHealthOS.Security.Authorization;
using Xunit;

public sealed class AuthorizationPipelineTests
{
    [Fact]
    public void Authorize_ShouldReturnAllow_WhenServiceAllows()
    {
        var service = new StubAuthorizationService(
            AuthorizationDecision.Allow);

        var pipeline = new AuthorizationPipeline(service);

        var request = CreateRequest();

        var result = pipeline.Authorize(request);

        Assert.Equal(
            AuthorizationDecision.Allow,
            result);
    }

    [Fact]
    public void Authorize_ShouldReturnDeny_WhenServiceDenies()
    {
        var service = new StubAuthorizationService(
            AuthorizationDecision.Deny);

        var pipeline = new AuthorizationPipeline(service);

        var request = CreateRequest();

        var result = pipeline.Authorize(request);

        Assert.Equal(
            AuthorizationDecision.Deny,
            result);
    }

    [Fact]
    public void Constructor_ShouldThrow_WhenServiceIsNull()
    {
        Assert.Throws<ArgumentNullException>(
            () => new AuthorizationPipeline(null!));
    }

    [Fact]
    public void Authorize_ShouldThrow_WhenRequestIsNull()
    {
        var service = new StubAuthorizationService(
            AuthorizationDecision.Allow);

        var pipeline = new AuthorizationPipeline(service);

        Assert.Throws<ArgumentNullException>(
            () => pipeline.Authorize(null!));
    }

    [Fact]
    public void Authorize_ShouldPassContextToService()
    {
        var service = new StubAuthorizationService(
            AuthorizationDecision.Allow);

        var pipeline = new AuthorizationPipeline(service);

        var request = CreateRequest();

        pipeline.Authorize(request);

        Assert.Same(request.Context, service.LastContext);
    }

    private static AuthorizationRequest CreateRequest()
    {
        var context = new AuthorizationContextDto
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

        return new AuthorizationRequest(context);
    }

    private sealed class StubAuthorizationService
        : IAuthorizationService
    {
        private readonly AuthorizationDecision _decision;

        public StubAuthorizationService(
            AuthorizationDecision decision)
        {
            _decision = decision;
        }

        public AuthorizationContextDto? LastContext { get; private set; }

        public AuthorizationDecision Authorize(
            AuthorizationContextDto context)
        {
            LastContext = context;

            return _decision;
        }
    }
}
