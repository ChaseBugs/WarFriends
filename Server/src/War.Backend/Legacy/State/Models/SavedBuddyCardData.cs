using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>Mirrors <c>CardManager.BuddyCardData</c>. Not written by anything implemented yet.</summary>
public sealed class SavedBuddyCardData : LegacyStateObject
{
    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    [JsonPropertyName("buddyName")]
    public string? BuddyName { get; set; }

    [JsonPropertyName("equippedVisuals")]
    public Dictionary<int, SavedPlayerVisualSlot> EquippedVisuals { get; set; } = [];
    [JsonPropertyName("unityType")]
    public int UnitType { get; set; }

    [JsonPropertyName("primaryWeapon")]
    public int PrimaryWeapon { get; set; }

    [JsonPropertyName("secondaryWeapon")]
    public int SecondaryWeapon { get; set; }

    [JsonPropertyName("armypower")]
    public int ArmyPower { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }
}
