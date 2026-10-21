using War.Backend.Features.Battle.Authentication;
using War.Backend.Features.Battle.Rematch;
using War.Backend.Transport.Http;
using War.Protocol;
using static War.Backend.HttpProtocol;

namespace War.Backend;

public static class BattleRematchEndpoints
{
    public static void MapBattleRematchEndpoints(this RouteGroupBuilder routes)
    {
        routes.MapPost("/battle/rematch/read", ReadAsync);
        routes.MapPost("/battle/rematch/accept", AcceptAsync);
        routes.MapPost("/battle/rematch/cancel", CancelAsync);
        routes.MapPost("/battle/rematch/allocate", AllocateAsync);
        routes.MapPost("/battle/rematch/cancel-allocation", CancelAllocatedAsync);
    }

    private static Task<IResult> ReadAsync(HttpContext context, BattlePlayerAuthentication authentication,
        BattleRematchApplicationService rematches)
    {
        return ApplyIntentAsync(context, authentication, rematches, RematchIntent.Read);
    }

    private static Task<IResult> AcceptAsync(HttpContext context, BattlePlayerAuthentication authentication,
        BattleRematchApplicationService rematches)
    {
        return ApplyIntentAsync(context, authentication, rematches, RematchIntent.Accept);
    }

    private static Task<IResult> CancelAsync(HttpContext context, BattlePlayerAuthentication authentication,
        BattleRematchApplicationService rematches)
    {
        return ApplyIntentAsync(context, authentication, rematches, RematchIntent.Cancel);
    }

    private static async Task<IResult> ApplyIntentAsync(HttpContext context,
        BattlePlayerAuthentication authentication, BattleRematchApplicationService rematches, RematchIntent intent)
    {
        string? playerId = await authentication.AuthenticateAsync(BackendBearerToken.Read(context),
            context.RequestAborted);
        if (playerId == null)
        {
            return ApplicationHttpResults.AuthenticationRequired();
        }

        MatchGrantRequest request = await Read(context, MatchGrantRequest.Parser);
        return (await rematches.ApplyIntentAsync(playerId, request, intent, context.RequestAborted)).ToHttp();
    }

    private static async Task<IResult> AllocateAsync(HttpContext context, BattlePlayerAuthentication authentication,
        BattleRematchApplicationService rematches)
    {
        string? playerId = await authentication.AuthenticateAsync(BackendBearerToken.Read(context),
            context.RequestAborted);
        if (playerId == null)
        {
            return ApplicationHttpResults.AuthenticationRequired();
        }

        MatchGrantRequest request = await Read(context, MatchGrantRequest.Parser);
        return (await rematches.AllocateAsync(playerId, request, context.RequestAborted)).ToHttp();
    }

    private static async Task<IResult> CancelAllocatedAsync(HttpContext context,
        BattlePlayerAuthentication authentication, BattleRematchApplicationService rematches)
    {
        string? playerId = await authentication.AuthenticateAsync(BackendBearerToken.Read(context),
            context.RequestAborted);
        if (playerId == null)
        {
            return ApplicationHttpResults.AuthenticationRequired();
        }

        MatchGrantRequest request = await Read(context, MatchGrantRequest.Parser);
        return (await rematches.CancelAllocatedAsync(playerId, request, context.RequestAborted)).ToHttp();
    }
}
