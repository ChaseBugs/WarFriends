using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace War.Persistence.Legacy.Tutorial;

/// <summary>Distinguishes a missing legacy schema from a present BSON-null tutorial container.</summary>
public sealed class LegacyTutorialStateSerializer : SerializerBase<LegacyTutorialState?>
{
    private static readonly IBsonSerializer<LegacyTutorialState> StateSerializer =
        BsonSerializer.LookupSerializer<LegacyTutorialState>();

    /// <inheritdoc />
    public override LegacyTutorialState? Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        if (context.Reader.GetCurrentBsonType() != BsonType.Document)
        {
            throw new FormatException("Present tutorial state must be a BSON document.");
        }

        return StateSerializer.Deserialize(context, args);
    }

    /// <inheritdoc />
    public override void Serialize(
        BsonSerializationContext context, BsonSerializationArgs args, LegacyTutorialState? value)
    {
        if (value == null)
        {
            // Mongo equality-to-null selects missing legacy schema; root writers omit this value.
            context.Writer.WriteNull();
        }
        else
        {
            StateSerializer.Serialize(context, args, value);
        }
    }
}
