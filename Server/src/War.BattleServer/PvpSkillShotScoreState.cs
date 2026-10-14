using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record PvpSkillShotScoreReceipt(int Flags, int Points, int ScoreAfter);

/// <summary>
/// One player's source PvP score and skill-shot counts. Inputs must come from
/// confirmed host callbacks; this is not a parser for Client score assertions.
/// </summary>
public sealed class PvpSkillShotScoreState
{
    private readonly PvpSkillShotScoreCatalog catalog;
    private readonly int maximumReceipts;
    private Dictionary<int, int> counts = new();
    private Dictionary<string, PvpSkillShotScoreReceipt> receipts = new(StringComparer.Ordinal);

    public int Score { get; private set; }
    public int ReceiptCount => receipts.Count;
    internal bool HasReceipt(string receiptId) => receipts.ContainsKey(receiptId);
    public IReadOnlyDictionary<int, int> Counts => new ReadOnlyDictionary<int, int>(new Dictionary<int, int>(counts));

    public PvpSkillShotScoreState(PvpSkillShotScoreCatalog catalog, int maximumReceipts = 4096)
    {
        ArgumentNullException.ThrowIfNull(catalog);
        if (maximumReceipts is < 1 or > 4096)
            throw new ArgumentOutOfRangeException(nameof(maximumReceipts));
        this.catalog = catalog;
        this.maximumReceipts = maximumReceipts;
        foreach (var row in catalog.Rows)
            counts.Add(row.Flag, 0);
    }

    internal PvpSkillShotScoreState PrepareConfirmedSkillShotCopy(string receiptId, int flags,
        out PvpSkillShotScoreReceipt result)
    {
        var candidate = (PvpSkillShotScoreState)MemberwiseClone();
        candidate.counts = new Dictionary<int, int>(counts);
        candidate.receipts = new Dictionary<string, PvpSkillShotScoreReceipt>(receipts, StringComparer.Ordinal);
        result = candidate.RecordConfirmedSkillShot(receiptId, flags);
        return candidate;
    }

    public PvpSkillShotScoreReceipt RecordConfirmedSkillShot(string receiptId, int flags)
    {
        if (!Guid.TryParseExact(receiptId, "N", out _) || receiptId != receiptId.ToLowerInvariant())
            throw new InvalidDataException("Invalid confirmed skill-shot receipt identity.");
        int points = catalog.PointsForConfirmedFlags(flags);
        if (receipts.TryGetValue(receiptId, out var previous))
        {
            if (previous.Flags != flags)
                throw new InvalidDataException("Confirmed skill-shot receipt changed its flags.");
            return previous;
        }
        if (receipts.Count == maximumReceipts)
            throw new InvalidOperationException("Confirmed skill-shot receipt capacity exhausted.");

        // SkillShotManager visits every matching source row, and ScoreManager
        // increments each row once. Zero-point rows still have a count.
        // Calculate all changes first so overflow cannot leave a partial award.
        int nextScore = checked(Score + points);
        var changedCounts = new List<KeyValuePair<int, int>>();
        foreach (var row in catalog.Rows)
        {
            if ((flags & row.Flag) == row.Flag)
                changedCounts.Add(new(row.Flag, checked(counts[row.Flag] + 1)));
        }

        var result = new PvpSkillShotScoreReceipt(flags, points, nextScore);
        receipts.Add(receiptId, result);
        foreach (var changed in changedCounts)
            counts[changed.Key] = changed.Value;
        Score = nextScore;
        return result;
    }
}
