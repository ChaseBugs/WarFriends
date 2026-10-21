using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>Mirrors <c>PlayerInventory.InventoryData</c> — the equipped weapon slots.</summary>
public sealed class InventoryData : LegacyStateObject
{
    [JsonPropertyName("slots")]
    public Dictionary<int, SerializedSlotDetail> Slots { get; set; } = [];
}
