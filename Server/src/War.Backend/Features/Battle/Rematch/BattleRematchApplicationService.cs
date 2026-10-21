using System.Net;
using War.Backend.Application;
using War.Backend.Features.Battle.Admission;
using War.Persistence;
using War.Protocol;
using static War.Backend.Application.ApplicationFailureKind;
using QueueResult = War.Backend.Application.ApplicationResult<War.Protocol.MatchQueueReply>;

namespace War.Backend.Features.Battle.Rematch;

public sealed class BattleRematchApplicationService
{
    private readonly BattleRematchConsentStore _consents;
    private readonly BattleRematchCancellation _cancellation;
    private readonly BattleRematchAllocator? _allocator;

    public BattleRematchApplicationService(BattleRematchConsentStore consents, BattleRematchCancellation cancellation,
        BattleRematchAllocator? allocator = null)
    {
        _consents = consents;
        _cancellation = cancellation;
        _allocator = allocator;
    }

    public async Task<ApplicationResult<MatchRematchConsent>> ApplyIntentAsync(string playerId,
        MatchGrantRequest request, RematchIntent intent, CancellationToken cancellationToken)
    {
        if (!BattleRequestPolicy.IsOnlyMatchId(request))
        {
            return ApplicationResult<MatchRematchConsent>.FromFailure(InvalidRequestFailure());
        }

        try
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            BattleRematchConsentDocument? consent = intent switch
            {
                RematchIntent.Read => await _consents.ReadAsync(request.MatchId, playerId, now, cancellationToken),
                RematchIntent.Accept => await _consents.AcceptAsync(request.MatchId, playerId, now, cancellationToken),
                RematchIntent.Cancel => await _consents.CancelAsync(request.MatchId, playerId, now, cancellationToken),
                _ => throw new ArgumentOutOfRangeException(nameof(intent))
            };
            return ApplicationResult<MatchRematchConsent>.Success(
                BattleRematchProjection.Project(request.MatchId, consent));
        }
        catch (InvalidDataException)
        {
            return ApplicationResult<MatchRematchConsent>.Reject(Conflict, "rematch_unavailable",
                "Completed battle consent is unavailable for this participant.");
        }
    }

    public async Task<QueueResult> AllocateAsync(string playerId, MatchGrantRequest request,
        CancellationToken cancellationToken)
    {
        if (!BattleRequestPolicy.IsOnlyMatchId(request))
        {
            return QueueResult.FromFailure(InvalidRequestFailure());
        }
        if (_allocator == null)
        {
            return QueueResult.Reject(Unavailable, "rematch_disabled", "Rematch allocation policy is not configured.");
        }

        try
        {
            return QueueResult.Success(await _allocator.AllocateAsync(request.MatchId, playerId, cancellationToken));
        }
        catch (InvalidDataException)
        {
            return QueueResult.Reject(Conflict, "rematch_unavailable",
                "Source-compatible rematch allocation is unavailable.");
        }
        catch (HttpRequestException)
        {
            return QueueResult.Reject(Unavailable, "rematch_provision_deferred",
                "Reserved rematch provisioning must be retried.");
        }
    }

    public async Task<QueueResult> CancelAllocatedAsync(string playerId, MatchGrantRequest request,
        CancellationToken cancellationToken)
    {
        if (!BattleRequestPolicy.IsOnlyMatchId(request))
        {
            return QueueResult.FromFailure(InvalidRequestFailure());
        }

        try
        {
            return QueueResult.Success(
                await _cancellation.CancelAllocatedAsync(request.MatchId, playerId, cancellationToken));
        }
        catch (InvalidDataException)
        {
            return QueueResult.Reject(Conflict, "rematch_unavailable",
                "Source-bound rematch cancellation is unavailable.");
        }
        catch (HttpRequestException failure) when (failure.StatusCode == HttpStatusCode.Conflict)
        {
            return QueueResult.Reject(Conflict, "rematch_cancellation_conflict",
                "The Worker did not confirm prestart cancellation.");
        }
        catch (Exception failure) when (failure is HttpRequestException ||
            failure is OperationCanceledException && !cancellationToken.IsCancellationRequested)
        {
            return QueueResult.Reject(Unavailable, "rematch_cancellation_deferred",
                "Reserved rematch cancellation must be retried.");
        }
    }

    private static ApplicationFailure InvalidRequestFailure()
    {
        return new ApplicationFailure(InvalidRequest, "invalid_rematch_request",
            "Only a canonical completed match ID is accepted.");
    }
}
