using System.Globalization;
using War.Persistence;
using War.Persistence.Legacy.State;

namespace War.Backend.Legacy.Progression;

/// <summary>Publishes a bounded display assertion against current account/session authority.</summary>
internal static class LegacyArmyPowerEndpoint
{
    internal static async Task<IResult> HandleAsync(
        LegacyRequest request,
        LegacyPlayerDocument player,
        LegacyPlayerStore store,
        CancellationToken cancellationToken)
    {
        // The recovered builder emits invariant Int32 text; its success callback reads no fields.
        // This remains a display assertion, never combat, matchmaking, price or reward authority.
        string? text = request.SingleField("ArmyPower");
        if (!int.TryParse(text, NumberStyles.None, CultureInfo.InvariantCulture, out int power) ||
            power > LegacyPlayerEconomyAuthority.MaximumArmyPower ||
            power.ToString(CultureInfo.InvariantCulture) != text)
        {
            return LegacyResponse.Failure(DatabaseResult.JsonFailure);
        }

        LegacyPlayerDocument? committed = await store.UpdateArmyPowerAsync(player, power, cancellationToken);
        if (committed == null)
        {
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }

        return LegacyResponse.Json(DatabaseResult.Success);
    }
}
