using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>Mirrors <c>PlayerInventory.SerializedSlotDetail</c>.</summary>
public sealed class SerializedSlotDetail : LegacyStateObject
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("weaponIndex")]
    public int WeaponIndex { get; set; }
}
