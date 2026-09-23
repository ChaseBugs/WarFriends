namespace War.BattleServer;

public sealed class BattleRibbonLedger
{
    private readonly HashSet<string> ribbons = new(StringComparer.Ordinal);
    public int Count => ribbons.Count;
    public bool Record(string ribbonId)
    {
        if (string.IsNullOrWhiteSpace(ribbonId) || ribbonId.Length > 64 ||
            ribbonId.Any(char.IsControl) || !System.Text.RegularExpressions.Regex.IsMatch(ribbonId, @"\A[A-Za-z0-9_-]+\z"))
            throw new InvalidDataException("Invalid battle ribbon identity.");
        if (ribbons.Count >= 128 && !ribbons.Contains(ribbonId)) return false;
        return ribbons.Add(ribbonId);
    }
    public IReadOnlyCollection<string> Snapshot() => ribbons.OrderBy(x => x, StringComparer.Ordinal).ToArray();
}
