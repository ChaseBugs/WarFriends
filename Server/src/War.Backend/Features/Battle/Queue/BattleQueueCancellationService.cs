using System.Net;
using War.Backend.Features.Battle.Admission;
using War.Infrastructure;
using War.Persistence;
using War.Protocol;
using static War.Backend.Application.ApplicationFailureKind;
using QueueResult = War.Backend.Application.ApplicationResult<War.Protocol.MatchQueueReply>;

namespace War.Backend.Features.Battle.Queue;

public sealed class BattleQueueCancellationService
{
    private readonly BattleMatchQueueStore _queue;
    private readonly BattlePairedCancellation _cancellation;
    private readonly BattleQueueAttemptTokens _attempts;

    public BattleQueueCancellationService(BattleMatchQueueStore queue, BattlePairedCancellation cancellation,
        BattleQueueAttemptTokens attempts)
    {
        _queue = queue;
        _cancellation = cancellation;
        _attempts = attempts;
    }

    public async Task<QueueResult> CancelAsync(string playerId, MatchQueueRequest request,
        CancellationToken cancellationToken)
    {
        if (!BattleRequestPolicy.IsOnlyQueueAttempt(request))
        {
            return QueueResult.Reject(InvalidRequest, "invalid_matchmaking_request",
                "Unknown matchmaking request fields.");
        }

        DateTimeOffset now = DateTimeOffset.UtcNow;
        BattleQueueAttemptIdentity? attempt;
        try
        {
            attempt = request.AttemptToken.Length == 0 ? null :
                _attempts.ValidateForCancellation(request.AttemptToken, playerId, now.ToUnixTimeSeconds());
        }
        catch (InvalidDataException)
        {
            return QueueResult.Reject(InvalidRequest, "invalid_queue_attempt", "Invalid queue attempt credential.");
        }

        BattlePairingResult decision = attempt.HasValue
            ? await _queue.CancelAttemptAsync(attempt.Value, now, cancellationToken)
            : await _queue.CancelWithPairAsync(playerId, now, cancellationToken);
        if (decision.Code == "already-paired")
        {
            return await CancelPairedAsync(decision, cancellationToken);
        }
        return QueueResult.Success(new MatchQueueReply { Code = decision.Code });
    }

    private async Task<QueueResult> CancelPairedAsync(BattlePairingResult decision, CancellationToken cancellationToken)
    {
        try
        {
            string code = await _cancellation.CancelAsync(decision, cancellationToken);
            return QueueResult.Success(new MatchQueueReply { Code = code });
        }
        catch (HttpRequestException failure) when (failure.StatusCode == HttpStatusCode.Conflict)
        {
            return QueueResult.Success(new MatchQueueReply { Code = "already-paired" });
        }
        catch (Exception failure) when (failure is InvalidDataException or HttpRequestException ||
            failure is OperationCanceledException && !cancellationToken.IsCancellationRequested)
        {
            return QueueResult.Reject(Unavailable, "match_cancellation_deferred",
                "Paired cancellation must be retried.");
        }
    }
}
