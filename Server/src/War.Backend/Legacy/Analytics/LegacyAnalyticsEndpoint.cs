using War.Persistence;
using War.Persistence.Legacy.Analytics;

namespace War.Backend.Legacy.Analytics;

/// <summary>Maps recovered no-payload actions to a closed set of monotonic analytics flags.</summary>
internal static class LegacyAnalyticsEndpoint
{
    internal static async Task<IResult> ExecuteAsync(
        DatabaseAction action,
        LegacyPlayerDocument authenticated,
        LegacyPlayerStore store,
        CancellationToken cancellationToken)
    {
        LegacyAnalyticsFlag flag = action switch
        {
            DatabaseAction.ChatShownFirstTime => LegacyAnalyticsFlag.Chat,
            DatabaseAction.CustomizationShown => LegacyAnalyticsFlag.Customization,
            DatabaseAction.WarpathShownFirstTime => LegacyAnalyticsFlag.Warpath,
            DatabaseAction.CardpoolShown => LegacyAnalyticsFlag.CardPool,
            DatabaseAction.CraftingShown => LegacyAnalyticsFlag.Crafting,
            DatabaseAction.LeagueLeaderboardShown => LegacyAnalyticsFlag.LeagueLeaderboards,
            DatabaseAction.ElitesFeatureShown => LegacyAnalyticsFlag.Elites,
            _ => throw new InvalidDataException("Unsupported analytics acknowledgement action.")
        };
        // All original success callbacks read no response fields; payload diagnostics select no flag.
        LegacyPlayerDocument? committed = await store.MarkAnalyticsShownAsync(
            authenticated, flag, DateTimeOffset.UtcNow, cancellationToken);
        return LegacyResponse.Json(committed == null ? DatabaseResult.InvalidToken : DatabaseResult.Success);
    }
}
