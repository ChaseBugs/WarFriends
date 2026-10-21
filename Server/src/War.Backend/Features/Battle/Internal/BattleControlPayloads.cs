using System.Text.Json;

namespace War.Backend.Features.Battle.Internal;

internal static class BattleControlPayloads
{
    private const int ResultFields = 4;
    private const int AllocationFields = 2;
    private const int PairSize = 2;

    internal static TerminalSubmission ReadResult(byte[] body, string serverId)
    {
        using JsonDocument document = JsonDocument.Parse(body);
        JsonElement root = document.RootElement;
        ValidateEnvelope(root, serverId, ResultFields);
        if (!root.TryGetProperty("matchId", out JsonElement match) || match.ValueKind != JsonValueKind.String ||
            !root.TryGetProperty("digest", out JsonElement digest) || digest.ValueKind != JsonValueKind.String ||
            !root.TryGetProperty("snapshot", out JsonElement snapshot) || snapshot.ValueKind != JsonValueKind.String)
        {
            throw new InvalidDataException("Invalid terminal submission.");
        }

        return new TerminalSubmission(match.GetString()!, digest.GetString()!,
            Convert.FromBase64String(snapshot.GetString()!));
    }

    internal static string[] ReadPlayerIds(byte[] body, string serverId)
    {
        using JsonDocument document = JsonDocument.Parse(body);
        JsonElement root = document.RootElement;
        ValidateEnvelope(root, serverId, AllocationFields);
        if (!root.TryGetProperty("playerIds", out JsonElement players) ||
            players.ValueKind != JsonValueKind.Array || players.GetArrayLength() != PairSize)
        {
            throw new InvalidDataException("Invalid allocation read.");
        }

        return players.EnumerateArray()
            .Select(player => player.ValueKind == JsonValueKind.String ? player.GetString()! : "").ToArray();
    }

    private static void ValidateEnvelope(JsonElement root, string serverId, int expectedFields)
    {
        if (root.ValueKind != JsonValueKind.Object || root.EnumerateObject().Count() != expectedFields ||
            !root.TryGetProperty("serverId", out JsonElement host) ||
            host.ValueKind != JsonValueKind.String || host.GetString() != serverId)
        {
            throw new InvalidDataException("Invalid internal control envelope.");
        }
    }
}
