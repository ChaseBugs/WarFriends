using MongoDB.Bson.Serialization.Attributes;

namespace War.Persistence;

/// <summary>Serializes changes to one player's battle admission within Mongo transactions.</summary>
public sealed class BattleAdmissionFenceDocument
{
    [BsonId]
    public string PlayerId { get; set; } = "";

    public long Revision { get; set; }
}
