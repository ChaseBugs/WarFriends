using War.Backend.Features.Accounts;
using War.Backend.Transport.Http;
using War.Protocol;
using static War.Backend.HttpProtocol;

namespace War.Backend.Features.Network;

public static class ConnectivityEndpoints
{
    public static void MapConnectivityEndpoints(this RouteGroupBuilder routes)
    {
        routes.MapPost("/network/connect", ConnectAsync);
    }

    private static async Task<IResult> ConnectAsync(HttpContext context, AccountApplicationService accounts,
        ConnectivityProbeService probes)
    {
        PlayerProfile? player = await accounts.AuthenticateAsync(BackendBearerToken.Read(context),
            context.RequestAborted);
        if (player == null)
        {
            return ApplicationHttpResults.AuthenticationRequired();
        }

        ConnectionRequest request = await Read(context, ConnectionRequest.Parser);
        return probes.Issue(player, request).ToHttp();
    }
}
