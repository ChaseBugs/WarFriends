using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>Mirrors <c>LevelManager.LevelManagerData</c> — the army and weapon loadout.</summary>
public sealed class LevelManagerData : LegacyStateObject
{
    [JsonPropertyName("savedArmies")]
    public Dictionary<string, SavedArmySlots> SavedArmies { get; set; } = [];
    [JsonPropertyName("savedWeapons")]
    public Dictionary<string, SavedWeaponSlots> SavedWeapons { get; set; } = [];
    [JsonPropertyName("unitDelivery")]
    public ItemDelivery UnitDelivery { get; set; } = new();
    [JsonPropertyName("weaponDelivery")]
    public ItemDelivery WeaponDelivery { get; set; } = new();
}
