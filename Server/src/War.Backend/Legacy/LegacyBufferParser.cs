using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.Json;

namespace War.Backend.Legacy;

/// <summary>Validates a complete Client buffer envelope before any contained request can execute.</summary>
public static class LegacyBufferParser
{
    public const int MaxRequestsPerBuffer = 256;

    public const int MaxBuffers = 64;

    private const int MaximumBufferIdLength = 128;

    private static readonly IReadOnlySet<string> RequestFields = new HashSet<string>(StringComparer.Ordinal)
    {
        "action", "data"
    };

    private static readonly IReadOnlySet<string> BufferFields = new HashSet<string>(StringComparer.Ordinal)
    {
        "alreadySent", "id", "requestCount", "requests"
    };

    /// <summary>Parses the Client's integer-keyed request dictionary in canonical index order.</summary>
    public static IReadOnlyList<BufferedRequest> ParseRequests(string? json)
    {
        if (string.IsNullOrEmpty(json))
        {
            return [];
        }

        using JsonDocument document = JsonDocument.Parse(json);
        return ReadRequests(document.RootElement);
    }

    /// <summary>Validates every pending boot buffer before returning any of them to the processor.</summary>
    public static IReadOnlyList<ParsedBuffer> ParseBuffers(string? json)
    {
        if (string.IsNullOrEmpty(json))
        {
            return [];
        }

        using JsonDocument document = JsonDocument.Parse(json);
        RequireObject(document.RootElement);
        var buffers = new List<ParsedBuffer>();
        var identities = new HashSet<string>(StringComparer.Ordinal);
        foreach (JsonProperty entry in document.RootElement.EnumerateObject())
        {
            if (!IsValidBufferId(entry.Name) || !identities.Add(entry.Name) || buffers.Count >= MaxBuffers)
            {
                throw new JsonException("Invalid, duplicate or excessive buffer identity.");
            }

            RequireObject(entry.Value);
            ValidateFields(entry.Value, BufferFields);
            if (!entry.Value.TryGetProperty("requests", out JsonElement requests))
            {
                throw new JsonException("Pending buffer is missing its request dictionary.");
            }

            IReadOnlyList<BufferedRequest> parsed = ReadRequests(requests);
            ValidateMetadata(entry, parsed.Count);
            buffers.Add(new ParsedBuffer(entry.Name, parsed));
        }

        return buffers;
    }

    /// <summary>Checks the bounded opaque identifier shared by direct and boot buffer transport.</summary>
    public static bool IsValidBufferId([NotNullWhen(true)] string? identity)
    {
        return !string.IsNullOrEmpty(identity) && identity.Length <= MaximumBufferIdLength &&
            !identity.Any(char.IsControl);
    }

    private static IReadOnlyList<BufferedRequest> ReadRequests(JsonElement root)
    {
        RequireObject(root);
        var requests = new List<BufferedRequest>();
        var indexes = new HashSet<int>();
        foreach (JsonProperty entry in root.EnumerateObject())
        {
            if (requests.Count >= MaxRequestsPerBuffer ||
                !int.TryParse(entry.Name, NumberStyles.None, CultureInfo.InvariantCulture, out int index) ||
                index < 0 || index.ToString(CultureInfo.InvariantCulture) != entry.Name || !indexes.Add(index))
            {
                throw new JsonException("Invalid, duplicate or excessive request index.");
            }

            requests.Add(ReadRequest(index, entry.Value));
        }

        requests.Sort((left, right) => left.Index.CompareTo(right.Index));
        return requests;
    }

    private static BufferedRequest ReadRequest(int index, JsonElement entry)
    {
        RequireObject(entry);
        ValidateFields(entry, RequestFields);
        if (!entry.TryGetProperty("action", out JsonElement action) ||
            action.ValueKind != JsonValueKind.Number || !action.TryGetInt32(out int actionId) ||
            !Enum.IsDefined(typeof(DatabaseAction), actionId))
        {
            throw new JsonException("Invalid buffered action.");
        }

        if (!entry.TryGetProperty("data", out JsonElement value) ||
            value.ValueKind is not (JsonValueKind.String or JsonValueKind.Null))
        {
            throw new JsonException("Buffered payload must be a string or null.");
        }

        return new BufferedRequest(index, (DatabaseAction)actionId, value.GetString());
    }

    private static void ValidateMetadata(JsonProperty entry, int count)
    {
        JsonElement buffer = entry.Value;
        if (buffer.TryGetProperty("id", out JsonElement identity) &&
            (identity.ValueKind != JsonValueKind.String || identity.GetString() != entry.Name))
        {
            throw new JsonException("Pending buffer identity does not match its dictionary key.");
        }

        if (buffer.TryGetProperty("requestCount", out JsonElement requestCount) &&
            (requestCount.ValueKind != JsonValueKind.Number || !requestCount.TryGetInt32(out int declared) ||
                declared != count))
        {
            throw new JsonException("Pending buffer count does not match its requests.");
        }

        if (buffer.TryGetProperty("alreadySent", out JsonElement sent) &&
            sent.ValueKind is not (JsonValueKind.True or JsonValueKind.False))
        {
            throw new JsonException("Pending buffer delivery metadata is not Boolean.");
        }
    }

    private static void RequireObject(JsonElement value)
    {
        if (value.ValueKind != JsonValueKind.Object)
        {
            throw new JsonException("Buffered request container must be an object.");
        }
    }

    private static void ValidateFields(JsonElement value, IReadOnlySet<string> supported)
    {
        var names = new HashSet<string>(StringComparer.Ordinal);
        foreach (JsonProperty field in value.EnumerateObject())
        {
            if (!names.Add(field.Name) || !supported.Contains(field.Name))
            {
                throw new JsonException("Duplicate or unknown buffered field.");
            }
        }
    }
}
