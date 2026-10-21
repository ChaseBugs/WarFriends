using System.Text.Json;
using War.Persistence;

namespace War.Backend.Features.Battle.Settlement;

internal sealed record BattleWinStreak(int WinCount, int TimeStamp)
{
    internal static BattleWinStreak Read(LegacyPlayerDocument player, int now)
    {
        if (!player.Serialized.TryGetValue("WinStreak", out string? json))
        {
            return new(0, 0);
        }
        using JsonDocument document = JsonDocument.Parse(json);
        JsonElement root = document.RootElement;
        if (root.ValueKind != JsonValueKind.Object || root.EnumerateObject().Count() != 2 ||
            !root.TryGetProperty("WinCount", out JsonElement count) || !count.TryGetInt32(out int wins) ||
            !root.TryGetProperty("TimeStamp", out JsonElement time) || !time.TryGetInt32(out int seconds) ||
            wins is < 0 or > 9 || seconds < 0 || seconds > now ||
            (wins == 0 && seconds != 0) || (wins > 0 && seconds == 0))
        {
            throw new InvalidDataException("Invalid stored battle win streak.");
        }
        return new(wins, seconds);
    }
}
