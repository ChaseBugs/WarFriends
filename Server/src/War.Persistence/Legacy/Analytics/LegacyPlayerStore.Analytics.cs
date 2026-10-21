using MongoDB.Driver;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.Analytics;
using War.Persistence.Legacy.Preferences;
using War.Persistence.Legacy.State;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    private const int MaximumAnalyticsAttempts = 8;

    /// <summary>
    /// Marks one known flag on the current valid snapshot without overwriting concurrent analytics changes.
    /// </summary>
    public async Task<LegacyPlayerDocument?> MarkAnalyticsShownAsync(
        LegacyPlayerDocument authenticated,
        LegacyAnalyticsFlag flag,
        DateTimeOffset applicationTime,
        CancellationToken cancellationToken)
    {
        string name = LegacyAnalyticsState.FlagName(flag);
        if (applicationTime.ToUnixTimeSeconds() is < 0 or > int.MaxValue)
        {
            throw new InvalidDataException("Invalid analytics application time.");
        }

        for (int attempt = 0; attempt < MaximumAnalyticsAttempts; attempt++)
        {
            LegacyPlayerDocument? current = await ById(authenticated.Id, cancellationToken);
            if (current == null || current.SessionHash != authenticated.SessionHash ||
                current.SessionExpiresUtc <= applicationTime.UtcDateTime)
            {
                return null;
            }

            LegacySessionAuthority.ValidateStored(current, applicationTime.UtcDateTime);
            LegacySettingsSnapshot.ValidateContainer(current.Serialized);
            var state = LegacyAnalyticsState.Read(current.Serialized);
            if (state[name]?.GetValue<bool>() == true)
            {
                return current;
            }

            state[name] = true;
            string json = LegacyAnalyticsState.Write(state);
            LegacyPlayerDocument? committed = await players.FindOneAndUpdateAsync(
                row => row.Id == current.Id && row.Revision == current.Revision &&
                    row.SessionHash == authenticated.SessionHash && row.SessionExpiresUtc > applicationTime.UtcDateTime,
                Builders<LegacyPlayerDocument>.Update.Set("Serialized.PlayerAnalyticsData", json)
                    .Inc(row => row.Revision, 1),
                new FindOneAndUpdateOptions<LegacyPlayerDocument> { ReturnDocument = ReturnDocument.After },
                cancellationToken);
            if (committed != null)
            {
                LegacyPlayerIdentityAuthority.Validate(committed);
                LegacyPlayerEconomyAuthority.Validate(committed);
                LegacyAnalyticsState.ValidateContainer(committed.Serialized);
                return committed;
            }
        }

        throw new InvalidDataException("Analytics authority changed too often to publish.");
    }
}
