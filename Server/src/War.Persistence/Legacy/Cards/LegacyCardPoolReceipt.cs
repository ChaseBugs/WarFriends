using MongoDB.Bson.Serialization.Attributes;

namespace War.Persistence.Legacy.Cards;

/// <summary>Records the outcome committed with a card transfer; these replay fences do not expire.</summary>
public sealed class LegacyCardPoolReceipt
{
    [BsonId]
    public string Id { get; set; } = "";

    public string ActorId { get; set; } = "";

    public int ActionId { get; set; }

    public string PayloadDigest { get; set; } = "";

    public int Result { get; set; }

    public int NextWithdraw { get; set; }

    public DateTime CreatedUtc { get; set; }
}
