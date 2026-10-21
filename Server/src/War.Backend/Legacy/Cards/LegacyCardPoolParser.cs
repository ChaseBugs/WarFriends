using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace War.Backend.Legacy.Cards;

/// <summary>Parses the Client's double-encoded card amounts without silently skipping damaged entries.</summary>
public static class LegacyCardPoolParser
{
    private const int MaximumPayloadLength = 32768;
    private const int MaximumEntries = 67;

    public static Dictionary<string, int> ParseAmounts(string json)
    {
        if (json.Length > MaximumPayloadLength)
        {
            throw new JsonException("Card-pool payload is too large.");
        }

        using JsonDocument document = JsonDocument.Parse(json);
        if (document.RootElement.ValueKind != JsonValueKind.Object)
        {
            throw new JsonException("Expected a card-pool object.");
        }

        var amounts = new Dictionary<string, int>(StringComparer.Ordinal);
        foreach (JsonProperty card in document.RootElement.EnumerateObject())
        {
            if (amounts.Count >= MaximumEntries || card.Name.Length is < 1 or > 64 ||
                card.Value.ValueKind != JsonValueKind.String || amounts.ContainsKey(card.Name))
            {
                throw new JsonException("Invalid or duplicate card-pool entry.");
            }

            amounts.Add(card.Name, ParseAmount(card.Value.GetString()!));
        }

        return amounts;
    }

    public static string Digest(LegacyCardPoolIntent intent)
    {
        string canonical = JsonSerializer.Serialize(new
        {
            Added = intent.Added.OrderBy(pair => pair.Key, StringComparer.Ordinal).ToArray(),
            Removed = intent.Removed.OrderBy(pair => pair.Key, StringComparer.Ordinal).ToArray(),
            intent.CardId,
            intent.DonorId
        });
        return Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(canonical)));
    }

    private static int ParseAmount(string json)
    {
        using JsonDocument document = JsonDocument.Parse(json);
        JsonElement root = document.RootElement;
        if (root.ValueKind != JsonValueKind.Object)
        {
            throw new JsonException("Expected an encoded card amount.");
        }

        JsonProperty[] fields = root.EnumerateObject().ToArray();
        if (fields.Length != 1 || fields[0].Name != "amount" ||
            fields[0].Value.ValueKind != JsonValueKind.Number ||
            !fields[0].Value.TryGetInt32(out int amount) || amount <= 0)
        {
            throw new JsonException("Expected one positive Int32 card amount.");
        }

        return amount;
    }
}
