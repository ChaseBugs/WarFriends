namespace War.BattleServer;

public sealed class WarCardEffectStack
{
    private readonly Dictionary<string, int> counts = new(StringComparer.Ordinal);

    public bool TryApply(string cardId, bool stackable)
    {
        if (string.IsNullOrWhiteSpace(cardId) || !WarCardEffectCatalog.TryGet(cardId, out _))
            return false;

        int activeCount = counts.GetValueOrDefault(cardId);
        if ((!stackable && activeCount > 0) || activeCount >= 16)
            return false;

        counts[cardId] = activeCount + 1;
        return true;
    }

    public void Release(string cardId)
    {
        if (!counts.TryGetValue(cardId, out int activeCount) || activeCount == 0)
            throw new InvalidOperationException("A War Card effect cannot be released twice.");

        if (activeCount == 1) counts.Remove(cardId);
        else counts[cardId] = activeCount - 1;
    }

    public int Count(string cardId) => counts.GetValueOrDefault(cardId);
}
