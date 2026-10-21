using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>Mirrors <c>LevelManager.ItemDelivery</c> — an in-progress purchase or upgrade timer.</summary>
public sealed class ItemDelivery : LegacyStateObject
{
    [JsonPropertyName("activationNeeded")]
    public bool ActivationNeeded { get; set; }

    [JsonPropertyName("boughtIndex")]
    public int BoughtIndex { get; set; }

    [JsonPropertyName("end")]
    public long End { get; set; }

    [JsonPropertyName("itemId")]
    public string? ItemId { get; set; }

    [JsonPropertyName("slotId")]
    public int SlotId { get; set; }

    [JsonPropertyName("start")]
    public long Start { get; set; }
}
