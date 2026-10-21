using War.Backend.Features.Battle.Authentication;
using War.Backend.Transport.Http;
using War.Protocol;
using static War.Backend.HttpProtocol;

namespace War.Backend.Features.Battle.Queue;

public static class BattleQueueEndpoints
{
    public static void MapBattleQueueEndpoints(this RouteGroupBuilder routes)
    {
        routes.MapPost("/battle/queue/attempt", IssueAttemptAsync);
        routes.MapPost("/battle/queue/join", JoinAsync);
        routes.MapPost("/battle/queue/cancel", CancelAsync);
    }

    private static async Task<IResult> IssueAttemptAsync(HttpContext context, BattlePlayerAuthentication authentication,
        BattleQueueAttemptService attempts)
    {
        string? playerId = await authentication.AuthenticateAsync(BackendBearerToken.Read(context),
            context.RequestAborted);
        if (playerId == null)
        {
            return ApplicationHttpResults.AuthenticationRequired();
        }

        MatchQueueRequest request = await Read(context, MatchQueueRequest.Parser);
        return attempts.Issue(playerId, request).ToHttp();
    }

    private static async Task<IResult> JoinAsync(HttpContext context, BattlePlayerAuthentication authentication,
        BattleQueueApplicationService queue)
    {
        string? playerId = await authentication.AuthenticateAsync(BackendBearerToken.Read(context),
            context.RequestAborted);
        if (playerId == null)
        {
            return ApplicationHttpResults.AuthenticationRequired();
        }

        MatchQueueRequest request = await Read(context, MatchQueueRequest.Parser);
        return (await queue.JoinAsync(playerId, request, context.RequestAborted)).ToHttp();
    }

    private static async Task<IResult> CancelAsync(HttpContext context, BattlePlayerAuthentication authentication,
        BattleQueueCancellationService queue)
    {
        string? playerId = await authentication.AuthenticateAsync(BackendBearerToken.Read(context),
            context.RequestAborted);
        if (playerId == null)
        {
            return ApplicationHttpResults.AuthenticationRequired();
        }

        MatchQueueRequest request = await Read(context, MatchQueueRequest.Parser);
        return (await queue.CancelAsync(playerId, request, context.RequestAborted)).ToHttp();
    }
}
