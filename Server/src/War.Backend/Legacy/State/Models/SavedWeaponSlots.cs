using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>Mirrors <c>LevelManager.SavedWeaponSlots</c>.</summary>
public sealed class SavedWeaponSlots : LegacyStateObject
{
    [JsonPropertyName("bought")]
    public bool Bought { get; set; }

    [JsonPropertyName("boughtIndex")]
    public int BoughtIndex { get; set; }

    [JsonPropertyName("showed")]
    public bool Showed { get; set; }

    [JsonPropertyName("borrowed")]
    public bool Borrowed { get; set; }
}
