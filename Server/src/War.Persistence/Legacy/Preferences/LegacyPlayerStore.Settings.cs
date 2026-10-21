using MongoDB.Driver;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.Preferences;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    private const int MaximumSettingsAttempts = 8;

    /// <summary>Publishes complete flags and retained metadata against the current authenticated revision.</summary>
    public async Task<LegacyPlayerDocument?> ApplySettingsAsync(
        LegacyPlayerDocument authenticated,
        LegacySettingsSnapshot replacement,
        DateTimeOffset applicationTime,
        CancellationToken cancellationToken)
    {
        if (applicationTime.ToUnixTimeSeconds() is < 0 or > int.MaxValue)
        {
            throw new InvalidDataException("Invalid Settings application time.");
        }

        DateTime nowUtc = applicationTime.UtcDateTime;
        for (int attempt = 0; attempt < MaximumSettingsAttempts; attempt++)
        {
            LegacyPlayerDocument? current = await ById(authenticated.Id, cancellationToken);
            if (current == null || current.SessionHash != authenticated.SessionHash ||
                current.SessionExpiresUtc <= nowUtc)
            {
                return null;
            }

            LegacySessionAuthority.ValidateStored(current, nowUtc);
            string json = replacement.Merge(current.Serialized);
            var update = Builders<LegacyPlayerDocument>.Update.Set("Serialized.Settings", json)
                .Inc(player => player.Revision, 1);
            LegacyPlayerDocument? committed = await players.FindOneAndUpdateAsync(
                player => player.Id == current.Id && player.Revision == current.Revision &&
                    player.SessionHash == authenticated.SessionHash,
                update, new FindOneAndUpdateOptions<LegacyPlayerDocument> { ReturnDocument = ReturnDocument.After },
                cancellationToken);
            if (committed != null)
            {
                return committed;
            }
        }

        throw new InvalidDataException("Settings authority changed too often to publish.");
    }
}
