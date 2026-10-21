using System.Collections.Frozen;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using War.Persistence.Legacy.State;

namespace War.Persistence.Legacy.Preferences;

/// <summary>One complete immutable six-Boolean request, validated against the recovered Settings contract.</summary>
public sealed class LegacySettingsSnapshot
{
    private const int MaximumRequestBytes = 4096;
    private static readonly string[] Names =
        ["challenge", "squadStatus", "squadEvents", "maintenance", "playerLeague", "dailyRewardNotification"];
    private static readonly FrozenSet<string> ExactNames = Names.ToFrozenSet(StringComparer.Ordinal);
    private static readonly FrozenSet<string> IgnoreCaseNames = Names.ToFrozenSet(StringComparer.OrdinalIgnoreCase);
    private readonly string _json;

    private LegacySettingsSnapshot(string json)
    {
        _json = json;
    }

    /// <summary>Accepts exactly the six source Boolean fields, without partial updates or diagnostic aliases.</summary>
    public static LegacySettingsSnapshot Parse(string? json)
    {
        if (json == null || json.Length > MaximumRequestBytes || Encoding.UTF8.GetByteCount(json) > MaximumRequestBytes)
        {
            throw new JsonException("Settings request is missing or exceeds its byte bound.");
        }

        using JsonDocument document = LegacyStateJson.ParseObject(json);
        Validate(document.RootElement);
        if (document.RootElement.EnumerateObject().Any(property => !ExactNames.Contains(property.Name)))
        {
            throw new JsonException("Settings request contains an unknown field.");
        }

        return new LegacySettingsSnapshot(json);
    }

    /// <summary>Validates present durable state while leaving an absent legacy subsystem absent.</summary>
    public static void ValidateContainer(IReadOnlyDictionary<string, string>? states)
    {
        if (states == null)
        {
            throw new InvalidDataException("Legacy subsystem container is null.");
        }

        if (!states.TryGetValue("Settings", out string? json))
        {
            return;
        }

        try
        {
            using JsonDocument document = LegacyStateJson.ParseObject(json);
            Validate(document.RootElement);
        }
        catch (JsonException exception)
        {
            throw new InvalidDataException("Invalid durable Settings authority.", exception);
        }
    }

    /// <summary>Replaces known flags while conserving validated unmodeled durable metadata.</summary>
    internal string Merge(IReadOnlyDictionary<string, string> states)
    {
        ValidateContainer(states);
        if (!states.TryGetValue("Settings", out string? existing))
        {
            return _json;
        }

        JsonObject merged = JsonNode.Parse(existing!)!.AsObject();
        using JsonDocument replacement = JsonDocument.Parse(_json);
        foreach (string name in Names)
        {
            merged[name] = replacement.RootElement.GetProperty(name).GetBoolean();
        }

        string json = merged.ToJsonString();
        using JsonDocument validated = LegacyStateJson.ParseObject(json);
        return json;
    }

    private static void Validate(JsonElement value)
    {
        foreach (string name in Names)
        {
            if (!value.TryGetProperty(name, out JsonElement flag) ||
                flag.ValueKind is not (JsonValueKind.True or JsonValueKind.False))
            {
                throw new JsonException("Settings requires every source Boolean field.");
            }
        }

        foreach (JsonProperty property in value.EnumerateObject())
        {
            if (!ExactNames.Contains(property.Name) && IgnoreCaseNames.Contains(property.Name))
            {
                throw new JsonException("Settings contains a conflicting case alias.");
            }
        }
    }
}
