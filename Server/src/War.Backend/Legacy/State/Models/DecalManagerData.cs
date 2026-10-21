using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>Mirrors <c>CamosManager.DecalManagerData</c> — cosmetics owned and equipped.</summary>
public sealed class DecalManagerData : LegacyStateObject
{
    [JsonPropertyName("visuals")]
    public Dictionary<string, SavedPlayerVisual> Visuals { get; set; } = [];
    [JsonPropertyName("slots")]
    public Dictionary<int, SavedPlayerVisualSlot> Slots { get; set; } = [];
    [JsonPropertyName("previousHeadDecal")]
    public string PreviousHeadDecal { get; set; } = "";
}
