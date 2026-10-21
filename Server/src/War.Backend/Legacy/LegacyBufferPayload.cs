using System.Text.Json;
using System.Text.Json.Nodes;

namespace War.Backend.Legacy;

/// <summary>Turns malformed request value types into callback-safe per-action JSON failures.</summary>
public static class LegacyBufferPayload
{
    /// <summary>Reads an optional source string without converting arrays, numbers or Booleans.</summary>
    public static string? ReadString(JsonNode? value)
    {
        if (value == null)
        {
            return null;
        }

        if (value is JsonValue scalar && scalar.TryGetValue(out string? text))
        {
            return text;
        }

        throw new JsonException("Buffered string field has an incompatible JSON type.");
    }

    /// <summary>Reads an optional equipped flag using the Client's exact Boolean representation.</summary>
    public static bool ReadFlag(JsonNode? flags, string field)
    {
        if (flags == null)
        {
            return false;
        }

        if (flags is not JsonObject properties)
        {
            throw new JsonException("Buffered unit flags must be an object.");
        }

        JsonNode? value = properties[field];
        if (value == null)
        {
            return false;
        }

        if (value is JsonValue scalar && scalar.TryGetValue(out bool flag))
        {
            return flag;
        }

        throw new JsonException("Buffered equipped flag must be Boolean.");
    }
}
