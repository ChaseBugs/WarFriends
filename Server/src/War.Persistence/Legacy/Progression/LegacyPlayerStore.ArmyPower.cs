using MongoDB.Driver;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.State;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    /// <summary>Publishes one bounded display assertion only for the expected live account session/revision.</summary>
    public async Task<LegacyPlayerDocument?> UpdateArmyPowerAsync(
        LegacyPlayerDocument expected, int power, CancellationToken cancellationToken)
    {
        DateTime nowUtc = DateTime.UtcNow;
        LegacySessionAuthority.ValidateStored(expected, nowUtc);
        LegacyPlayerIdentityAuthority.Validate(expected);
        LegacyPlayerEconomyAuthority.Validate(expected);
        LegacyPlayerEconomyAuthority.ValidateArmyPower(power);

        LegacyPlayerDocument? committed = await players.FindOneAndUpdateAsync(
            current => current.Id == expected.Id && current.Revision == expected.Revision &&
                current.SessionHash == expected.SessionHash && current.SessionExpiresUtc > nowUtc,
            Builders<LegacyPlayerDocument>.Update.Set(current => current.ArmyPower, power)
                .Inc(current => current.Revision, 1),
            new FindOneAndUpdateOptions<LegacyPlayerDocument> { ReturnDocument = ReturnDocument.After },
            cancellationToken);
        if (committed != null)
        {
            LegacyPlayerIdentityAuthority.Validate(committed);
            LegacyPlayerEconomyAuthority.Validate(committed);
        }

        return committed;
    }
}
