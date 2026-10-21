using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace War.Persistence.Legacy.Tutorial;

/// <summary>Retains source-null pending identity while refusing coercive BSON identity representations.</summary>
public sealed class LegacyTutorialIdSerializer : SerializerBase<string?>
{
    /// <inheritdoc />
    public override string? Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        if (context.Reader.GetCurrentBsonType() == BsonType.Null)
        {
            context.Reader.ReadNull();
            return null;
        }

        return context.Reader.GetCurrentBsonType() == BsonType.String
            ? context.Reader.ReadString()
            : throw new FormatException("Tutorial identity is not a BSON string.");
    }

    /// <inheritdoc />
    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string? value)
    {
        if (value == null)
        {
            context.Writer.WriteNull();
        }
        else
        {
            context.Writer.WriteString(value);
        }
    }
}
