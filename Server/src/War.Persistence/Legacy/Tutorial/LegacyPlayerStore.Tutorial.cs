using MongoDB.Driver;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.Preferences;
using War.Persistence.Legacy.State;
using War.Persistence.Legacy.Tutorial;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    private const int MaximumTutorialAttempts = 8;

    /// <summary>Atomically publishes tutorial identity/mirrors or returns a read-only bound replay.</summary>
    public async Task<LegacyTutorialResult> ApplyTutorialAsync(
        LegacyPlayerDocument authenticated,
        LegacyTutorialOperation operation,
        DateTimeOffset applicationTime,
        CancellationToken cancellationToken)
    {
        if (applicationTime.ToUnixTimeSeconds() is < 0 or > int.MaxValue)
        {
            throw new InvalidDataException("Invalid tutorial application time.");
        }

        string proposedId = Guid.NewGuid().ToString("N");
        for (int attempt = 0; attempt < MaximumTutorialAttempts; attempt++)
        {
            LegacyPlayerDocument? current = await ById(authenticated.Id, cancellationToken);
            if (current == null || current.SessionHash != authenticated.SessionHash ||
                current.SessionExpiresUtc <= applicationTime.UtcDateTime)
            {
                return new(LegacyTutorialOutcome.InvalidSession);
            }

            LegacySessionAuthority.ValidateStored(current, applicationTime.UtcDateTime);
            LegacySettingsSnapshot.ValidateContainer(current.Serialized);
            LegacyTutorialResult? unchanged = ReadTutorialOutcome(current, operation);
            if (unchanged != null)
            {
                return unchanged;
            }

            var next = new LegacyTutorialState
            {
                BattleId = current.PendingTutorialBattleId ?? proposedId, Completed = !operation.IsStart
            };
            LegacyPlayerDocument? committed = await PublishTutorialAsync(
                current, next, applicationTime.UtcDateTime, cancellationToken);
            if (committed != null)
            {
                LegacyPlayerIdentityAuthority.Validate(committed);
                LegacyPlayerEconomyAuthority.Validate(committed);
                LegacyTutorialAuthority.ValidateForRead(committed);
                return new(LegacyTutorialOutcome.Published, committed, next.BattleId);
            }
        }

        throw new InvalidDataException("Tutorial authority changed too often to publish.");
    }

    private static LegacyTutorialResult? ReadTutorialOutcome(
        LegacyPlayerDocument current, LegacyTutorialOperation operation)
    {
        LegacyTutorialAuthority.ValidateForRead(current);
        if (current.TutorialCompleted && current.TutorialState == null)
        {
            return new(LegacyTutorialOutcome.LegacyProofRequired, current);
        }

        if (!operation.IsStart && operation.BattleId !=
            (current.TutorialState?.BattleId ?? current.PendingTutorialBattleId))
        {
            return new(LegacyTutorialOutcome.WrongBattle, current);
        }

        if (current.TutorialState != null && (operation.IsStart || current.TutorialState.Completed))
        {
            return new(LegacyTutorialOutcome.Replayed, current, current.TutorialState.BattleId);
        }

        return null;
    }

    private async Task<LegacyPlayerDocument?> PublishTutorialAsync(
        LegacyPlayerDocument current, LegacyTutorialState next, DateTime nowUtc, CancellationToken cancellationToken)
    {
        FilterDefinition<LegacyPlayerDocument> filter = Builders<LegacyPlayerDocument>.Filter.Where(row =>
            row.Id == current.Id && row.Revision == current.Revision && row.SessionHash == current.SessionHash &&
            row.SessionExpiresUtc > nowUtc && row.TutorialCompleted == current.TutorialCompleted &&
            row.PendingTutorialBattleId == current.PendingTutorialBattleId) &
            Builders<LegacyPlayerDocument>.Filter.Eq(row => row.TutorialState, current.TutorialState);
        return await players.FindOneAndUpdateAsync(filter,
            Builders<LegacyPlayerDocument>.Update.Set(row => row.TutorialState, next)
                .Set(row => row.PendingTutorialBattleId, next.Completed ? null : next.BattleId)
                .Set(row => row.TutorialCompleted, next.Completed).Inc(row => row.Revision, 1),
            new FindOneAndUpdateOptions<LegacyPlayerDocument> { ReturnDocument = ReturnDocument.After },
            cancellationToken);
    }
}
