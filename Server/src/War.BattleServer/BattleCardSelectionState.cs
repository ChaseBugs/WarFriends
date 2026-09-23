namespace War.BattleServer;

/// <summary>Server-owned prebattle card selection. Client payloads are checked
/// against the trusted catalog and never become authority by themselves.</summary>
public sealed class BattleCardSelectionState
{
    private sealed record Selection(string PlayerId, IReadOnlyList<string> Cards);
    private readonly Dictionary<string, Selection> byRequest = new(StringComparer.Ordinal);
    private readonly Dictionary<string, IReadOnlyList<string>> byPlayer = new(StringComparer.Ordinal);

    public IReadOnlyList<string> Submit(string playerId, string requestId,
        IEnumerable<string> cards, IReadOnlySet<string> catalog)
    {
        if (!Guid.TryParseExact(playerId, "N", out _) || string.IsNullOrWhiteSpace(requestId) || requestId.Length > 128)
            throw new InvalidDataException("Invalid card selection identity.");
        var validated = BattleLoadoutPolicy.ValidateCardIds(cards, catalog);
        if (byRequest.TryGetValue(requestId, out var prior))
        {
            if (!string.Equals(prior.PlayerId, playerId, StringComparison.Ordinal) ||
                !prior.Cards.SequenceEqual(validated, StringComparer.Ordinal))
                throw new InvalidDataException("Card selection request conflict.");
            return prior.Cards;
        }
        if (byPlayer.ContainsKey(playerId)) throw new InvalidDataException("Card selection already submitted.");
        var frozen = Array.AsReadOnly(validated.ToArray());
        byRequest.Add(requestId, new Selection(playerId, frozen));
        byPlayer.Add(playerId, frozen);
        return frozen;
    }

    public bool TryGet(string playerId, out IReadOnlyList<string> cards)
        => byPlayer.TryGetValue(playerId, out cards!);
}
