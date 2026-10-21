using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>Mirrors <c>LevelManager.SavedArmySlots</c>.</summary>
public sealed class SavedArmySlots : LegacyStateObject
{
    [JsonPropertyName("bought")]
    public bool Bought { get; set; }

    [JsonPropertyName("boughtIndex")]
    public int BoughtIndex { get; set; }

    [JsonPropertyName("specialSlot")]
    public int SpecialSlot { get; set; }

    [JsonPropertyName("showed")]
    public bool Showed { get; set; }

    [JsonPropertyName("tier")]
    public int Tier { get; set; }

    [JsonPropertyName("borrowed")]
    public bool Borrowed { get; set; }

    [JsonPropertyName("wasEquipped")]
    public bool WasEquipped { get; set; }

    [JsonPropertyName("equipped")]
    public bool Equipped { get; set; }

    [JsonPropertyName("eliteSlot")]
    public int EliteSlot { get; set; }

    [JsonPropertyName("parts")]
    public int Parts { get; set; }
}
