using MongoDB.Bson.Serialization.Attributes;
using War.Persistence.Legacy.State;

namespace War.Persistence.Legacy.Tutorial;

/// <summary>Versioned identity and terminal marker for one account's unrewarded tutorial acknowledgement.</summary>
public sealed record LegacyTutorialState
{
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int Version { get; init; } = 1;

    [BsonRequired]
    [BsonSerializer(typeof(LegacyTutorialIdSerializer))]
    public required string BattleId { get; init; }

    [BsonRequired]
    [BsonSerializer(typeof(LegacyBooleanSerializer))]
    public bool Completed { get; init; }
}
