using MongoDB.Driver;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.Profile;
using War.Persistence.Legacy.State;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    private const int MaximumProfileAttempts = 8;

    /// <summary>
    /// Rebases a complete profile replacement while retaining current metadata and session authority.
    /// </summary>
    public async Task<LegacyPlayerDocument?> ApplyProfileAsync(
        LegacyPlayerDocument authenticated,
        LegacyProfileChange change,
        DateTimeOffset applicationTime,
        CancellationToken cancellationToken)
    {
        long seconds = applicationTime.ToUnixTimeSeconds();
        if (seconds is < 0 or > int.MaxValue)
        {
            throw new InvalidDataException("Invalid legacy profile application time.");
        }

        for (int attempt = 0; attempt < MaximumProfileAttempts; attempt++)
        {
            LegacyPlayerDocument? current = await ById(authenticated.Id, cancellationToken);
            if (current == null || current.SessionHash != authenticated.SessionHash ||
                current.SessionExpiresUtc <= applicationTime.UtcDateTime)
            {
                return null;
            }

            LegacySessionAuthority.ValidateStored(current, applicationTime.UtcDateTime);
            LegacyProfileValues.ValidateStored(current);
            UpdateDefinition<LegacyPlayerDocument> update = BuildProfileUpdate(current, change, (int)seconds);
            LegacyPlayerDocument? committed = await players.FindOneAndUpdateAsync(
                row => row.Id == current.Id && row.Revision == current.Revision &&
                    row.SessionHash == authenticated.SessionHash && row.SessionExpiresUtc > applicationTime.UtcDateTime,
                update.Inc(row => row.Revision, 1),
                new FindOneAndUpdateOptions<LegacyPlayerDocument> { ReturnDocument = ReturnDocument.After },
                cancellationToken);
            if (committed != null)
            {
                LegacyPlayerIdentityAuthority.Validate(committed);
                LegacyPlayerEconomyAuthority.Validate(committed);
                LegacyProfileValues.ValidateStored(committed);
                return committed;
            }
        }

        throw new InvalidDataException("Profile authority changed too often to publish.");
    }

    private static UpdateDefinition<LegacyPlayerDocument> BuildProfileUpdate(
        LegacyPlayerDocument current, LegacyProfileChange change, int now)
    {
        // A request captured before a newer heartbeat must not move durable presence backwards.
        int lastAction = Math.Max(current.LastAction, now);
        UpdateDefinitionBuilder<LegacyPlayerDocument> update = Builders<LegacyPlayerDocument>.Update;
        return change.Kind switch
        {
            LegacyProfileChangeKind.Status => update.Set(row => row.Status, change.Status)
                .Set(row => row.LastAction, lastAction),
            LegacyProfileChangeKind.DeviceRegistration => update.Set(row => row.DeviceToken, change.DeviceToken!)
                .Set(row => row.Locale, change.Locale!).Set(row => row.LastAction, lastAction),
            LegacyProfileChangeKind.Language => update.Set(row => row.Locale, change.Locale!),
            LegacyProfileChangeKind.Country => update.Set(row => row.Country, change.Country!),
            _ => throw new InvalidDataException("Unsupported legacy profile replacement.")
        };
    }
}
