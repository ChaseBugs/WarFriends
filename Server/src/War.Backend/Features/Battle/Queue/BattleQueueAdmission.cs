using War.Backend.Application;
using War.Persistence;
using War.Shared;
using static War.Backend.Application.ApplicationFailureKind;

namespace War.Backend.Features.Battle.Queue;

/// <summary>Refreshes only inactive inventory authority, then verifies the current source presentation.</summary>
public sealed class BattleQueueAdmission
{
    private readonly LegacyPlayerStore _accounts;
    private readonly BattleAllocationStore _allocations;
    private readonly BattleAllocationPreparationStore _preparation;
    private readonly BattleManifestFactory? _factory;

    public BattleQueueAdmission(LegacyPlayerStore accounts, BattleAllocationStore allocations,
        BattleAllocationPreparationStore preparation, BattleManifestFactory? factory = null)
    {
        _accounts = accounts;
        _allocations = allocations;
        _preparation = preparation;
        _factory = factory;
    }

    public async Task<ApplicationFailure?> PrepareAsync(string playerId, CancellationToken cancellationToken)
    {
        try
        {
            LegacyPlayerDocument account = await ReadAccountAsync(playerId, cancellationToken);
            BattleAllocationProjection? allocation = await _allocations.Get(playerId, cancellationToken);
            if (allocation == null || !BattleAllocationSource.HasMatchingAllocation(account, allocation))
            {
                await _preparation.RefreshInactiveAsync(playerId, account.Revision, snapshot =>
                {
                    RequireFactory().ValidatePresentation(BattlePlayerPresentationSource.Project(snapshot));
                    return BattleAllocationSource.Project(snapshot);
                }, cancellationToken);
            }
        }
        catch (InvalidDataException)
        {
            return new ApplicationFailure(Conflict, "battle_allocation_invalid",
                "The trusted battle allocation is invalid.");
        }
        return await VerifyPresentationAsync(playerId, cancellationToken);
    }

    private async Task<ApplicationFailure?> VerifyPresentationAsync(string playerId,
        CancellationToken cancellationToken)
    {
        try
        {
            LegacyPlayerDocument account = await ReadAccountAsync(playerId, cancellationToken);
            BattleAllocationProjection allocation = await _allocations.Get(playerId, cancellationToken)
                ?? throw new InvalidDataException("Battle allocation is missing.");
            BattleAllocationSource.ValidateMatchesAccount(account, allocation);
            RequireFactory().ValidatePresentation(BattlePlayerPresentationSource.Project(account));
            return null;
        }
        catch (InvalidDataException)
        {
            return new ApplicationFailure(Conflict, "battle_presentation_invalid",
                "A complete durable player presentation is required before matchmaking.");
        }
    }

    private async Task<LegacyPlayerDocument> ReadAccountAsync(string playerId, CancellationToken cancellationToken)
    {
        return await _accounts.ById(playerId, cancellationToken)
            ?? throw new InvalidDataException("A durable account is required for battle preparation.");
    }

    private BattleManifestFactory RequireFactory()
    {
        return _factory ?? throw new InvalidDataException("Battle manifest provisioning is unavailable.");
    }
}
