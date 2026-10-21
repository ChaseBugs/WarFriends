using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace War.Persistence.Legacy.State;

/// <summary>
/// Accepts only exact BSON integers; strings, floating point, Booleans and null never become counters.
/// </summary>
public sealed class LegacyInt32Serializer : SerializerBase<int>
{
    /// <inheritdoc />
    public override int Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        long value = context.Reader.GetCurrentBsonType() switch
        {
            BsonType.Int32 => context.Reader.ReadInt32(),
            BsonType.Int64 => context.Reader.ReadInt64(),
            _ => throw new FormatException("Legacy counter is not an exact BSON integer.")
        };
        if (value is < int.MinValue or > int.MaxValue)
        {
            throw new FormatException("Legacy BSON counter exceeds signed Int32.");
        }

        return (int)value;
    }

    /// <inheritdoc />
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, int value) =>
        context.Writer.WriteInt32(value);
}
