using MongoDB.Driver;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.Progression;
using War.Persistence.Legacy.State;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    /// <summary>Commits rewards and a non-expiring replay cursor in the same account update.</summary>
    public async Task<LegacyPlayerDocument> MergeOfflineBotsAsync(LegacyPlayerDocument authenticated,
        OfflineBotJournal journal, Action<LegacyPlayerDocument, OfflineBotOutcome> apply,
        CancellationToken cancellationToken)
    {
        journal.Validate();
        for (int attempt = 0; attempt < 8; attempt++)
        {
            LegacyPlayerDocument current = await ById(authenticated.Id, cancellationToken)
                ?? throw new InvalidDataException("Offline account disappeared.");
            DateTime now = DateTime.UtcNow;
            LegacySessionAuthority.ValidateStored(current, now);
            if (current.SessionHash != authenticated.SessionHash || current.SessionExpiresUtc <= now)
            {
                throw new InvalidDataException("Offline synchronization session expired.");
            }
            if (current.OfflineBotStreams == null || current.OfflineBotStreams.Count > 16 ||
                current.OfflineBotStreams.Any(pair => !Guid.TryParseExact(pair.Key, "N", out _) ||
                    pair.Value is < 0 or > int.MaxValue))
            {
                throw new InvalidDataException("Invalid offline replay cursors.");
            }
            if (!current.OfflineBotStreams.ContainsKey(journal.Stream) && current.OfflineBotStreams.Count == 16)
            {
                throw new InvalidDataException("Offline device limit reached.");
            }
            long cursor = current.OfflineBotStreams.GetValueOrDefault(journal.Stream);
            long original = cursor;
            foreach (OfflineBotOutcome battle in journal.Battles)
            {
                if (battle.Sequence <= cursor)
                {
                    continue;
                }
                if (battle.Sequence != cursor + 1)
                {
                    throw new InvalidDataException("Offline synchronization contains a gap.");
                }
                apply(current, battle);
                cursor = battle.Sequence;
            }
            if (cursor == original)
            {
                return current;
            }
            current.OfflineBotStreams[journal.Stream] = cursor;
            LegacyPlayerEconomyAuthority.Validate(current);
            long revision = current.Revision;
            current.Revision = checked(revision + 1);
            var result = await players.ReplaceOneAsync(player => player.Id == current.Id &&
                player.Revision == revision && player.SessionHash == authenticated.SessionHash,
                current, cancellationToken: cancellationToken);
            if (result.ModifiedCount == 1)
            {
                return current;
            }
        }
        throw new InvalidDataException("Offline synchronization conflicted repeatedly.");
    }
}
