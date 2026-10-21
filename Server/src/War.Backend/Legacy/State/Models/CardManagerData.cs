using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>
/// Mirrors <c>CardManager.CardManagerData</c>. Pack/card-pool mutations preserve the other source
/// fields during a round trip; Buddy-card rental and extra-slot entitlement remain separate features.
/// </summary>
public sealed class CardManagerData : LegacyStateObject
{
    [JsonPropertyName("cardData")]
    public Dictionary<string, SavedCardData> CardData { get; set; } = [];
    [JsonPropertyName("buddyCardData")]
    public Dictionary<string, SavedBuddyCardData> BuddyCardData { get; set; } = [];
    [JsonPropertyName("nextWithdraw")]
    public int NextWithdraw { get; set; }

    [JsonPropertyName("nextBuddyDeposit")]
    public int NextBuddyDeposit { get; set; }

    [JsonPropertyName("extraSlot")]
    public bool ExtraSlot { get; set; }
}
