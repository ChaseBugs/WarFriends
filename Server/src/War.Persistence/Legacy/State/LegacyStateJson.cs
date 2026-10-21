using System.Text;
using System.Text.Json;

namespace War.Persistence.Legacy.State;

/// <summary>Checks bounded durable JSON before callers interpret fields or publish a replacement.</summary>
public static class LegacyStateJson
{
    public const int MaximumBytes = 1024 * 1024;
    private const int MaximumDepth = 32;
    private const int MaximumNodes = 65_536;
    private static readonly UTF8Encoding StrictUtf8 = new(false, true);

    /// <summary>Refuses present-null, duplicate, non-finite or oversized state; the caller owns the document.</summary>
    public static JsonDocument ParseObject(string? json)
    {
        if (string.IsNullOrWhiteSpace(json) || json.Length > MaximumBytes)
        {
            throw new JsonException("Present legacy state is empty or exceeds its resource bound.");
        }

        try
        {
            if (StrictUtf8.GetByteCount(json) > MaximumBytes)
            {
                throw new JsonException("Legacy state exceeds its UTF-8 byte bound.");
            }
        }
        catch (EncoderFallbackException exception)
        {
            throw new JsonException("Legacy state contains invalid Unicode.", exception);
        }

        JsonDocument document = JsonDocument.Parse(json, new JsonDocumentOptions { MaxDepth = MaximumDepth });
        try
        {
            if (document.RootElement.ValueKind != JsonValueKind.Object)
            {
                throw new JsonException("Present legacy state must be an object.");
            }

            int nodes = 0;
            Validate(document.RootElement, ref nodes);
            return document;
        }
        catch
        {
            document.Dispose();
            throw;
        }
    }

    private static void Validate(JsonElement value, ref int nodes)
    {
        if (++nodes > MaximumNodes)
        {
            throw new JsonException("Legacy state exceeds its node budget.");
        }

        switch (value.ValueKind)
        {
            case JsonValueKind.Object:
                ValidateObject(value, ref nodes);
                break;
            case JsonValueKind.Array:
                foreach (JsonElement item in value.EnumerateArray())
                {
                    Validate(item, ref nodes);
                }
                break;
            case JsonValueKind.Number:
                if (!value.TryGetDouble(out double number) || !double.IsFinite(number))
                {
                    throw new JsonException("Legacy state contains an unsupported numeric value.");
                }
                break;
        }
    }

    private static void ValidateObject(JsonElement value, ref int nodes)
    {
        var fields = new HashSet<string>(StringComparer.Ordinal);
        foreach (JsonProperty property in value.EnumerateObject())
        {
            if (!fields.Add(property.Name))
            {
                throw new JsonException("Legacy state contains a duplicate JSON property.");
            }

            Validate(property.Value, ref nodes);
        }
    }
}
