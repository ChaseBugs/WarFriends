using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace War.Persistence.Legacy.State;

/// <summary>Prevents BSON strings and numbers from becoming durable Boolean authority.</summary>
public sealed class LegacyBooleanSerializer : SerializerBase<bool>
{
    /// <inheritdoc />
    public override bool Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) =>
        context.Reader.GetCurrentBsonType() == BsonType.Boolean
            ? context.Reader.ReadBoolean()
            : throw new FormatException("Legacy authority flag is not a BSON Boolean.");

    /// <inheritdoc />
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, bool value) =>
        context.Writer.WriteBoolean(value);
}
