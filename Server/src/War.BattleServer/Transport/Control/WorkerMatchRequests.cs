using System.Text.Json;
using System.Text.RegularExpressions;
using War.Shared;

namespace War.BattleServer.Transport.Control;

internal static class WorkerMatchRequests
{
    private const int MaximumMatchIdCharacters = 64;
    private const int PlayerIdCharacters = 32;

    internal static ReconnectControlRequest ReadReconnect(byte[] body)
    {
        using JsonDocument document = JsonDocument.Parse(body);
        JsonElement root = document.RootElement;
        if (root.ValueKind != JsonValueKind.Object || root.EnumerateObject().Count() != 3)
        {
            throw new InvalidDataException("Invalid reconnect shape.");
        }

        string matchId = ReadString(root, "matchId");
        string playerId = ReadString(root, "playerId");
        string requestId = ReadString(root, "requestId");
        if (matchId.Length is < 1 or > MaximumMatchIdCharacters || playerId.Length != PlayerIdCharacters ||
            !CanonicalGuid.IsCanonical(requestId))
        {
            throw new InvalidDataException("Invalid reconnect identities.");
        }
        return new ReconnectControlRequest(matchId, playerId, requestId);
    }

    internal static CancelControlRequest ReadCancellation(byte[] body)
    {
        using JsonDocument document = JsonDocument.Parse(body);
        JsonElement root = document.RootElement;
        if (root.ValueKind != JsonValueKind.Object || root.EnumerateObject().Count() is < 1 or > 2)
        {
            throw new InvalidDataException("Invalid cancellation shape.");
        }

        string matchId = ReadString(root, "matchId");
        if (matchId.Length is < 1 or > MaximumMatchIdCharacters ||
            !matchId.All(character => char.IsAsciiLetterOrDigit(character) || character is '_' or '-'))
        {
            throw new InvalidDataException("Invalid cancellation identity.");
        }
        if (!root.TryGetProperty("manifestHash", out JsonElement hash))
        {
            if (root.EnumerateObject().Count() != 1)
            {
                throw new InvalidDataException("Unknown cancellation field.");
            }
            return new CancelControlRequest(matchId, null);
        }
        if (root.EnumerateObject().Count() != 2 || hash.ValueKind != JsonValueKind.String ||
            !Regex.IsMatch(hash.GetString() ?? "", @"\A[0-9a-f]{64}\z"))
        {
            throw new InvalidDataException("Invalid cancellation manifest hash.");
        }
        return new CancelControlRequest(matchId, hash.GetString());
    }

    private static string ReadString(JsonElement root, string field)
    {
        if (!root.TryGetProperty(field, out JsonElement value) || value.ValueKind != JsonValueKind.String)
        {
            throw new InvalidDataException("Missing control identity.");
        }
        return value.GetString()!;
    }
}
