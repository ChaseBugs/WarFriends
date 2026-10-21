using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>Mirrors <c>CardManager.CardData</c> — just a running count, no per-card unlock threshold.</summary>
public sealed class SavedCardData : LegacyStateObject
{
    [JsonPropertyName("amount")]
    public int Amount { get; set; }
}
