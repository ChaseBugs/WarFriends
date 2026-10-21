using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>Mirrors <c>CamosManager.SavedPlayerVisualSlot</c>. Note the exact casing of the name.</summary>
public sealed class SavedPlayerVisualSlot : LegacyStateObject
{
    [JsonPropertyName("equippedID")]
    public string? EquippedId { get; set; }
}
