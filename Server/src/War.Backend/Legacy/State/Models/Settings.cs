using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>
/// Mirrors <c>SettingsManager.Settings</c> — the notification toggles sent by <c>UpdateSettings</c>
/// (action 165) as a JSON string in the <c>Settings</c> field, and stored under this same simple
/// name as a <c>DatabaseSerializedObjectGeneric&lt;Settings&gt;</c> blob.
/// </summary>
public sealed class Settings : LegacyStateObject
{
    [JsonPropertyName("challenge")]
    public bool Challenge { get; set; }

    [JsonPropertyName("squadStatus")]
    public bool SquadStatus { get; set; }

    [JsonPropertyName("squadEvents")]
    public bool SquadEvents { get; set; }

    [JsonPropertyName("maintenance")]
    public bool Maintenance { get; set; }

    [JsonPropertyName("playerLeague")]
    public bool PlayerLeague { get; set; }

    [JsonPropertyName("dailyRewardNotification")]
    public bool DailyRewardNotification { get; set; }
}
