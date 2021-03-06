using System;
using System.Threading.Tasks;
using Diagraph.Infrastructure.Api;
using Diagraph.Infrastructure.Auth;
using Diagraph.Infrastructure.Auth.OAuth2;
using Diagraph.Infrastructure.Cache;
using Diagraph.Infrastructure.Emails;
using Diagraph.Infrastructure.Tests;
using Diagraph.Modules.Identity.Database;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace Diagraph.Modules.Identity.Tests;

public class IdentityFixture : IAsyncLifetime
{
    public static readonly Guid RegisteredUserId = new("f0e7608f-e19a-450d-af66-ab9466f0a7fe");
    
    public ModuleFixture Module { get; }
    public EventStoreFixture EventStore { get; }
    public DatabaseFixture<IdentityDbContext> Database   { get; }

    public IdentityFixture()
    {
        Module     = new(ConfigureServices);
        EventStore = new();
        Database   = new("identity", Module.Service<IdentityDbContext>);
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        Mock<IEmailClient> emailClientMock = new();
        emailClientMock
            .Setup(c => c.SendAsync(It.IsAny<Email>()))
            .Returns(Task.CompletedTask);
        services.AddScoped(_ => emailClientMock.Object);

        Mock<IUserContext> userContextMock = new();
        userContextMock.SetupGet(c => c.UserId).Returns(RegisteredUserId);
        services.AddScoped(_ => userContextMock.Object);

        Mock<IAuthorizationCodeFlow> authCodeFlowMock = new();
        authCodeFlowMock.Setup
        (
            f => f.ExecuteAsync
            (
                It.IsAny<string>(), 
                It.IsAny<string>()
            )
        ).ReturnsAsync(new OAuth2TokenResponse { RefreshToken = "refresh_token" });
        services.AddScoped(_ => authCodeFlowMock.Object);
        
        Mock<ICache> cacheMock = new();
        cacheMock.Setup
        (
            c => c.Get<ResponseContainer, string>(It.IsAny<string>())
        ).Returns((ResponseContainer)null);
        services.AddScoped(_ => cacheMock.Object);
    }

    public Task InitializeAsync() => Task.WhenAll
    (
        Database.InitializeAsync(),
        EventStore.InitializeAsync()
    );

    public Task DisposeAsync() => Task.WhenAll
    (
        Database.DisposeAsync(),
        EventStore.DisposeAsync()
    );
}