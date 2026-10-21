using System.Text.Json.Nodes;
using static War.Backend.Legacy.Buffering.LegacyBufferedResults;

namespace War.Backend.Legacy.Buffering.Squads;

internal static class LegacyBufferedSquadChat
{
    /// <summary>
    /// Mirrors <c>PlayerAnalytics.lastSeenSquadChatTimestamp</c>'s setter (only ever advances, never
    /// regresses) by patching just this one field of the otherwise-unmodeled <c>PlayerAnalyticsData</c>
    /// blob through the same strict contract as the direct shown-once flags, conserving metadata.
    /// </summary>
    internal static (DatabaseResult, JsonObject) SaveLastSeenSquadChatTimeStamp(
        BufferedRequest request, LegacyBufferedState state)
    {
        if (!int.TryParse(request.Data, System.Globalization.NumberStyles.None,
            System.Globalization.CultureInfo.InvariantCulture, out int timestamp) ||
            timestamp.ToString(System.Globalization.CultureInfo.InvariantCulture) != request.Data)
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }
        if (timestamp > (state.Analytics["lastSeenSquadChatTimeStampDB"]?.GetValue<int>() ?? 0))
        {
            state.Analytics["lastSeenSquadChatTimeStampDB"] = timestamp;
            state.AnalyticsChanged();
        }
        return Ok(request);
    }
}
