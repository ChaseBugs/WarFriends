using War.Backend.Features.Battle.Authentication;
using War.Backend.Transport.Http;
using War.Protocol;
using static War.Backend.HttpProtocol;

namespace War.Backend.Features.Battle.Admission;

public static class BattleAdmissionEndpoints
{
    public static void MapBattleAdmissionEndpoints(this RouteGroupBuilder routes)
    {
        routes.MapPost("/battle/grant", ReadGrantAsync);
        routes.MapPost("/battle/reconnect", ReconnectAsync);
    }

    private static async Task<IResult> ReadGrantAsync(HttpContext context, BattlePlayerAuthentication authentication,
        BattleGrantApplicationService grants)
    {
        string? playerId = await authentication.AuthenticateAsync(BackendBearerToken.Read(context),
            context.RequestAborted);
        if (playerId == null)
        {
            return ApplicationHttpResults.AuthenticationRequired();
        }

        MatchGrantRequest request = await Read(context, MatchGrantRequest.Parser);
        return (await grants.GetAsync(playerId, request.MatchId, context.RequestAborted)).ToHttp();
    }

    private static async Task<IResult> ReconnectAsync(HttpContext context, BattlePlayerAuthentication authentication,
        BattleGrantApplicationService grants)
    {
        string? playerId = await authentication.AuthenticateAsync(BackendBearerToken.Read(context),
            context.RequestAborted);
        if (playerId == null)
        {
            return ApplicationHttpResults.AuthenticationRequired();
        }

        MatchReconnectRequest request = await Read(context, MatchReconnectRequest.Parser);
        return (await grants.ReconnectAsync(playerId, request, context.RequestAborted)).ToHttp();
    }
}
