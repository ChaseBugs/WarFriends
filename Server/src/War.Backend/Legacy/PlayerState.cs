using System.Text.Json;
using System.Text.Json.Serialization;
using War.Backend.Legacy.State;
using War.Persistence.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>
/// Reads and writes the 1.4.0 Client's typed subsystem objects without scalar coercion or metadata loss.
/// </summary>
/// <remarks>
/// <para>Each type mirrors a client POCO field-for-field, and every JSON name is stated explicitly
/// rather than derived from a naming policy: the client serializes with Newtonsoft using its
/// public field names verbatim, so a policy that renamed even one field would silently produce a
/// blob the client deserializes into defaults. <c>equippedID</c> is the obvious trap.</para>
/// <para>These are modelled, not opaque, because the actions that mutate them — "was shown"
/// acknowledgements, equipping, buying — change fields *inside* the blob. A server that stored
/// the blob as a string could not apply them.</para>
/// <para>Models live under Legacy/State/Models with their public namespaces preserved. Unmodeled
/// subsystem keys remain opaque until a feature supplies source-backed validation. Parsing is not
/// proof that every rank, item identity, count or progression receipt is valid.</para>
/// </remarks>
public static class PlayerState
{
    /// <summary>
    /// Matches the client's <c>JsonConvert</c> defaults closely enough for these POCOs: fields are
    /// named explicitly, nulls are written (the client's guards test for JSON null, not absence),
    /// and numbers are plain.
    /// </summary>
    public static readonly JsonSerializerOptions Options = CreateOptions();

    /// <summary>A null argument is reserved for proved absence; malformed present text is never a default.</summary>
    public static T Read<T>(string? json) where T : new()
    {
        if (json == null)
        {
            return new T();
        }

        try
        {
            using JsonDocument document = LegacyStateJson.ParseObject(json);
            LegacyStateContract.Validate(document.RootElement, typeof(T));
            return document.RootElement.Deserialize<T>(Options)
                ?? throw new JsonException("Present legacy state deserialized to null.");
        }
        catch (JsonException exception)
        {
            throw new InvalidDataException("Invalid present legacy subsystem state.", exception);
        }
    }

    /// <summary>Only a missing key selects legacy defaults; a present null value remains damaged state.</summary>
    public static T Read<T>(IReadOnlyDictionary<string, string>? states, string key) where T : new()
    {
        if (states == null)
        {
            throw new InvalidDataException("Legacy subsystem container is null.");
        }

        if (!states.TryGetValue(key, out string? json))
        {
            return new T();
        }

        if (json == null)
        {
            throw new InvalidDataException("A present legacy subsystem has a null value.");
        }

        return Read<T>(json);
    }

    /// <summary>Validates a typed successor while retaining permitted unmodeled metadata.</summary>
    public static string Write<T>(T value)
    {
        try
        {
            string json = JsonSerializer.Serialize(value, Options);
            using JsonDocument document = LegacyStateJson.ParseObject(json);
            LegacyStateContract.Validate(document.RootElement, typeof(T));
            return json;
        }
        catch (JsonException exception)
        {
            throw new InvalidDataException("Invalid legacy subsystem successor.", exception);
        }
    }

    private static JsonSerializerOptions CreateOptions()
    {
        var options = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.Never };
        // Integer dictionary keys have their own converter. Scalar string coercion is not needed.
        options.MakeReadOnly(populateMissingResolver: true);
        return options;
    }
}
