using System.Net;
using War.Backend.Application;
using War.Backend.Hosting.Configuration;
using War.Infrastructure;
using War.Persistence;
using War.Protocol;
using War.Shared;
using static War.Backend.Application.ApplicationFailureKind;
using GrantResult = War.Backend.Application.ApplicationResult<War.Protocol.MatchConnectionGrant>;

namespace War.Backend.Features.Battle.Admission;

public sealed class BattleGrantApplicationService
{
    private readonly BattleGrantStore _grants;
    private readonly BattleMatchQueueStore _queue;
    private readonly BattleMatchControlClient _control;
    private readonly Uri _reconnectEndpoint;

    public BattleGrantApplicationService(BattleGrantStore grants, BattleMatchQueueStore queue,
        BattleMatchControlClient control, BackendBattleOptions deployment)
    {
        _grants = grants;
        _queue = queue;
        _control = control;
        _reconnectEndpoint = new Uri(deployment.ControlEndpoint.AbsoluteUri.TrimEnd('/') + "/reconnect");
    }

    public async Task<GrantResult> GetAsync(string playerId, string matchId, CancellationToken cancellationToken)
    {
        try
        {
            BattlePairingResult? pair = await _queue.ForMatch(matchId, cancellationToken);
            if (pair?.Players == null || !pair.Players.Contains(playerId, StringComparer.Ordinal))
            {
                return GrantResult.Reject(Missing, "match_grant_missing",
                    "No active match grant is assigned to this player.");
            }

            MatchConnectionGrant? grant = await _grants.GetForPlayer(matchId, playerId,
                DateTimeOffset.UtcNow.ToUnixTimeSeconds(), cancellationToken);
            ValidateRoster(grant, pair.Players);
            return grant == null
                ? GrantResult.Reject(Missing, "match_grant_missing", "No match grant is assigned to this player.")
                : GrantResult.Success(grant);
        }
        catch (InvalidDataException)
        {
            return GrantResult.Reject(InvalidRequest, "invalid_match_grant", "Match grant is invalid or expired.");
        }
    }

    public async Task<GrantResult> ReconnectAsync(string playerId, MatchReconnectRequest request,
        CancellationToken cancellationToken)
    {
        if (!BattleRequestPolicy.IsMatchId(request.MatchId) || !CanonicalGuid.IsCanonical(request.RequestId))
        {
            return GrantResult.Reject(InvalidRequest, "invalid_reconnect",
                "A canonical match and request ID are required.");
        }

        // A damaged pair retains the existing top-level authority-failure behavior.
        BattlePairingResult? pair = await _queue.ForMatch(request.MatchId, cancellationToken);
        if (pair?.Players == null || !pair.Players.Contains(playerId, StringComparer.Ordinal))
        {
            return GrantResult.Reject(Missing, "match_grant_missing", "No match is assigned to this player.");
        }

        GrantResult assignment = await ReadAssignmentAsync(playerId, request.MatchId, pair, cancellationToken);
        if (assignment.Failure != null)
        {
            return assignment;
        }
        return await RotateAsync(playerId, request, cancellationToken);
    }

    private async Task<GrantResult> ReadAssignmentAsync(string playerId, string matchId,
        BattlePairingResult pair, CancellationToken cancellationToken)
    {
        try
        {
            MatchConnectionGrant? prior = await _grants.GetAssignmentForPlayer(matchId, playerId,
                DateTimeOffset.UtcNow.ToUnixTimeSeconds(), cancellationToken);
            ValidateRoster(prior, pair.Players!);
            return prior == null
                ? GrantResult.Reject(Missing, "match_grant_missing", "No retained battle assignment is available.")
                : GrantResult.Success(prior);
        }
        catch (InvalidDataException)
        {
            return GrantResult.Reject(Conflict, "invalid_match_grant", "Durable battle grant assignment is invalid.");
        }
    }

    private async Task<GrantResult> RotateAsync(string playerId, MatchReconnectRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            MatchConnectionGrant replacement = await _control.ReconnectAsync(_reconnectEndpoint,
                request.MatchId, playerId, request.RequestId, cancellationToken);
            MatchConnectionGrant published = await _grants.ReplaceForPlayer(request.MatchId, playerId,
                replacement, DateTimeOffset.UtcNow.ToUnixTimeSeconds(), cancellationToken);
            return GrantResult.Success(published);
        }
        catch (HttpRequestException error) when (error.StatusCode == HttpStatusCode.Conflict)
        {
            return GrantResult.Reject(Conflict, "battle_reconnect_unavailable",
                "The running match cannot reconnect this player.");
        }
        catch (HttpRequestException)
        {
            return GrantResult.Reject(Unavailable, "battle_reconnect_unavailable",
                "The battle host did not issue a reconnect grant.");
        }
        catch (InvalidDataException)
        {
            return GrantResult.Reject(Conflict, "battle_reconnect_conflict",
                "The reconnect grant conflicts with durable match authority.");
        }
    }

    private static void ValidateRoster(MatchConnectionGrant? grant, IReadOnlyList<string> players)
    {
        if (grant != null && !grant.PlayerViews.Select(view => view.PlayerId)
            .SequenceEqual(players, StringComparer.Ordinal))
        {
            throw new InvalidDataException("Battle grant roster differs from the active pair.");
        }
    }
}
