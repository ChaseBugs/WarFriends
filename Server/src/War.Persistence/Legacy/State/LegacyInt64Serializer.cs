using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace War.Persistence.Legacy.State;

/// <summary>Preserves signed-Int64 endpoints and refuses lossy or textual BSON currency representations.</summary>
public sealed class LegacyInt64Serializer : SerializerBase<long>
{
    /// <inheritdoc />
    public override long Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) =>
        context.Reader.GetCurrentBsonType() switch
        {
            BsonType.Int32 => context.Reader.ReadInt32(),
            BsonType.Int64 => context.Reader.ReadInt64(),
            _ => throw new FormatException("Legacy amount is not an exact BSON integer.")
        };

    /// <inheritdoc />
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, long value) =>
        context.Writer.WriteInt64(value);
}
