using War.Backend.Transport.Http;
using War.Protocol;
using static War.Backend.HttpProtocol;

namespace War.Backend.Features.Accounts;

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this RouteGroupBuilder routes)
    {
        routes.MapPost("/register", RegisterAsync);
        routes.MapPost("/login", LoginAsync);
    }

    public static void MapPlayerEndpoint(this RouteGroupBuilder routes)
    {
        routes.MapGet("/player", ReadPlayerAsync);
    }

    private static async Task<IResult> RegisterAsync(HttpContext context, AccountApplicationService accounts)
    {
        RegisterRequest request = await Read(context, RegisterRequest.Parser);
        return (await accounts.RegisterAsync(request, context.RequestAborted)).ToHttp();
    }

    private static async Task<IResult> LoginAsync(HttpContext context, AccountApplicationService accounts)
    {
        LoginRequest request = await Read(context, LoginRequest.Parser);
        return (await accounts.LoginAsync(request, context.RequestAborted)).ToHttp();
    }

    private static async Task<IResult> ReadPlayerAsync(HttpContext context, AccountApplicationService accounts)
    {
        PlayerProfile? player = await accounts.AuthenticateAsync(BackendBearerToken.Read(context),
            context.RequestAborted);
        return player == null ? ApplicationHttpResults.AuthenticationRequired() : Proto(player);
    }
}
