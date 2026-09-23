namespace War.BattleServer;

/// <summary>Terminal-match rematch boundary. A terminal match is immutable;
/// accepted requests are idempotently recorded for a separate allocator to
/// issue a fresh match and grants.</summary>
public sealed class RematchRequestState
{
    private const int Capacity = 256;
    private readonly Dictionary<string, string> requests = new(StringComparer.Ordinal);

    public int Count => requests.Count;

    public string Request(string matchId, string playerId, string requestId, bool terminal)
    {
        if (string.IsNullOrWhiteSpace(matchId) || matchId.Length > 64 ||
            string.IsNullOrWhiteSpace(playerId) || !Guid.TryParseExact(playerId, "N", out _) ||
            string.IsNullOrWhiteSpace(requestId) || requestId.Length > 128)
            throw new InvalidDataException("Invalid rematch request identity.");
        if (!terminal) return "not-terminal";
        string key = matchId + ":" + playerId + ":" + requestId;
        if (requests.TryGetValue(key, out var existing)) return existing;
        if (requests.Count >= Capacity) return "rematch-capacity";
        requests.Add(key, "fresh-allocation-required");
        return "fresh-allocation-required";
    }
}
