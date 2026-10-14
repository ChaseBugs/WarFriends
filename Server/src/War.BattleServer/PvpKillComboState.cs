namespace War.BattleServer;

public sealed record PvpKillComboResult(int Streak, int ComboFlag);

/// <summary>
/// Mirrors the shared SkillShotManager.RecieveKill history. Feed only eligible
/// host-confirmed player-owned entity deaths and their original game time.
/// </summary>
public sealed class PvpKillComboState
{
    private const int DoubleKillFlag = 32;
    private const int TripleKillFlag = 64;
    private const int MultiKillFlag = 128;
    private readonly float comboWindow;
    private readonly int maximumReceipts;
    private readonly Dictionary<string, SavedKill> receipts = new(StringComparer.Ordinal);
    private sealed record SavedKill(float GameTime, PvpKillComboResult Result);

    public int Streak { get; private set; }
    public float LastKillTime { get; private set; }
    public int ReceiptCount => receipts.Count;

    public PvpKillComboState(PvpSkillShotScoreCatalog catalog, int maximumReceipts = 4096)
    {
        ArgumentNullException.ThrowIfNull(catalog);
        if (maximumReceipts is < 1 or > 4096)
            throw new ArgumentOutOfRangeException(nameof(maximumReceipts));
        comboWindow = catalog.ComboWindowSeconds;
        this.maximumReceipts = maximumReceipts;
    }

    /// <summary>The receipt identifies one host-established death, not a Client command.</summary>
    public PvpKillComboResult RecordConfirmedKill(string receiptId, float gameTime)
    {
        if (!Guid.TryParseExact(receiptId, "N", out _) || receiptId != receiptId.ToLowerInvariant())
            throw new InvalidDataException("Invalid confirmed kill receipt identity.");
        if (!float.IsFinite(gameTime) || gameTime < 0)
            throw new ArgumentOutOfRangeException(nameof(gameTime));
        if (receipts.TryGetValue(receiptId, out var previous))
        {
            if (BitConverter.SingleToInt32Bits(previous.GameTime) != BitConverter.SingleToInt32Bits(gameTime))
                throw new InvalidDataException("Confirmed kill receipt changed its source time.");
            return previous.Result;
        }
        if (gameTime < LastKillTime)
            throw new InvalidDataException("Confirmed kill callbacks arrived out of source time order.");
        if (receipts.Count == maximumReceipts)
            throw new InvalidOperationException("Confirmed kill receipt capacity exhausted.");

        // The Unity Mono source probe promotes these float operands for the
        // comparison. Keep stored times/window as float, but compare in double.
        // Rounding the sum to float or replacing it with integer ticks differs.
        int nextStreak = (double)gameTime < (double)LastKillTime + comboWindow
            ? checked(Streak + 1) : 1;
        int comboFlag = 0;
        if (nextStreak == 2) comboFlag = DoubleKillFlag;
        if (nextStreak == 3) comboFlag = TripleKillFlag;
        if (nextStreak > 3) comboFlag = MultiKillFlag;
        var result = new PvpKillComboResult(nextStreak, comboFlag);

        receipts.Add(receiptId, new SavedKill(gameTime, result));
        Streak = nextStreak;
        LastKillTime = gameTime;
        return result;
    }
}
