using War.Persistence.Legacy.State;
using War.Backend.Legacy.Accounts;

namespace War.Backend.Legacy;

/// <summary>
/// Server-owned starting state for a new account. Bound from the <c>Legacy:Starter</c>
/// configuration section, on top of catalog-derived defaults (<see cref="FromCatalog"/>).
/// </summary>
/// <remarks>
/// The client's <c>CreateAccount</c> request carries <c>StartingGold</c>/<c>StartingWarbucks</c>
/// taken from a Fuseboxx A/B payload. Those are client-reported values on an account-management
/// action that has no session yet, so they are read for logging only and never assigned. The
/// balances below are the authority.
/// </remarks>
public sealed class LegacyStarterState
{
    /// <summary>
    /// Fallback used only when <see cref="LegacyCatalog"/> has no <c>Google2u.Constants</c> sheet
    /// loaded (no <c>Legacy:ContentPath</c> configured). When the catalog is loaded,
    /// <see cref="FromCatalog"/> overrides these with the verified sheet values:
    /// <c>StartingGold=75</c>, <c>StartingWarbucks=15000</c>, <c>DogTagCap=5</c> — none of these
    /// three fallback numbers is evidenced; they exist only so the boot chain still produces a
    /// playable (if unverified) account with no catalog configured at all.
    /// </summary>
    public long Gold { get; set; } = 500;
    public long WarBucks { get; set; } = 50;
    public long Tickets { get; set; }
    public long Scraps { get; set; }
    public int Level { get; set; } = 1;

    /// <summary>
    /// Total dog-tag regeneration capacity in <b>seconds</b> — <c>DogTagManager.max</c>, which the
    /// client computes as <c>DogTagCap * DogTagRefillTime</c> (a dog-tag <i>count</i> times the
    /// per-tag regen period), not the raw tag count. <see cref="FromCatalog"/> corrects this to the
    /// real product once both constants are loaded; this fallback (10 seconds) is deliberately
    /// tiny and unevidenced, matching the other catalog-free fallbacks' posture of "playable but not
    /// authoritative" rather than guessing a plausible-looking number.
    /// </summary>
    public int DogTagMax { get; set; } = 10;
    public int PlacementMatchesRequired { get; set; } = 1;
    public int SessionLifetimeHours { get; set; } = 24;

    /// <summary>
    /// The sheet-configuration version reported to <c>GetConfigurations</c>. Kept at the client's
    /// own initial value so the client keeps using its shipped Google2u sheets; bump it only
    /// alongside real sheet documents in the response.
    /// </summary>
    public string SheetConfiguration { get; set; } = "0";

    /// <summary>
    /// Applies the verified <c>Google2u.Constants</c> starter values on top of the hardcoded
    /// fallback defaults. Called before configuration binding, so an explicit
    /// <c>Legacy:Starter</c> override still takes precedence over either source.
    /// </summary>
    public static LegacyStarterState FromCatalog(LegacyCatalog catalog)
    {
        var state = new LegacyStarterState();
        if (!catalog.IsLoaded)
        {
            return state;
        }

        state.Gold = LegacyStarterConstants.Read(catalog, "StartingGold", long.MaxValue);
        state.WarBucks = LegacyStarterConstants.Read(catalog, "StartingWarbucks", long.MaxValue);
        state.PlacementMatchesRequired = (int)LegacyStarterConstants.Read(
            catalog, "LeaguePlacementMatches", LegacyPlayerEconomyAuthority.RecoveredPlacementMatches);
        long cap = LegacyStarterConstants.Read(catalog, "DogTagCap", int.MaxValue);
        long refill = LegacyStarterConstants.Read(catalog, "DogTagRefillTime", int.MaxValue);
        if (cap == 0 || refill == 0 || cap * refill > int.MaxValue)
        {
            throw new InvalidDataException("Invalid source dog-tag capacity.");
        }

        // DogTagManager.max is a count multiplied by the per-tag period in seconds.
        state.DogTagMax = checked((int)(cap * refill));
        return state;
    }

}
