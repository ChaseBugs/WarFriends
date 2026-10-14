using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record PvpBonusSource(int Index, string Name, string PrefabGuid,
    long ComponentFileId, string PrefabPath, string PrefabSha256,
    float Probability, float ArenaProbability);
public sealed record PvpBonusGoldRange(int Minimum, int MaximumExclusive);
public sealed record PvpBonusWarbucksDrawRange(int Minimum, int MaximumExclusive);

/// <summary>Host-established source perspective, never a Client probability request.</summary>
public sealed record PvpBonusWeightContext(bool IsWarArena, bool IsFriendlyDeathMatch,
    int LocalDisplayLevel, int OwnerLevelIndex, int GoldBonusesCollected,
    bool FirstTwoWeaponsHaveLowAmmo);

public sealed class PvpBonusCatalog
{
    private const string ReviewedSha256 =
        "e2b8b7e890bea0001574f5cc942b078b4003cbbd252db54af9971049423d509f";
    private const string ReviewedUnityReferenceSha256 =
        "bf5adb198147574e57271ec438664db7af61bd43f4ad68e466126e13091e564c";
    private const string ReviewedSourceCodeSha256 =
        "7ea7e1169d91fe906a5dddc70c12efe36aba168f68230c22581665a0f68c5f86";
    private static readonly string[] SourceNames = ["KillStreakBonusGold",
        "KillStreakBonusAddHealth", "KillStreakBonusWarbucks", "KillStreakBonusGrenades",
        "KillStreakBonusSlowMotion", "KillStreakBonusTurret", "KillStreakBonusKevlar",
        "KillStreakBonusCard", "KillStreakBonusAddAmmo"];
    // Mathf.Pow results from the digest-pinned Unity probe, indexed by the
    // recipient's zero-based rank. The content loader checks every bit below
    // against the generated probe before match traffic is admitted.
    private static readonly int[] UnityWarbucksScaleBits = [
        0x3F683DB6, 0x3F6FE7AF, 0x3F77D267, 0x3F800000, 0x3F843958,
        0x3F88965F, 0x3F8D1843, 0x3F91C03B, 0x3F968F89, 0x3F9B8778,
        0x3FA0A961, 0x3FA5F6A6, 0x3FAB70B5, 0x3FB11909, 0x3FB6F128,
        0x3FBCFAA7, 0x3FC33725, 0x3FC9A853, 0x3FD04FEE, 0x3FD72FC0,
        0x3FDE49A5, 0x3FE59F88, 0x3FED3363, 0x3FF50742, 0x3FFD1D42,
        0x4002BBC8, 0x40070C38, 0x400B811A, 0x40101BA2, 0x4014DD0F,
        0x4019C6A8, 0x401ED9C2, 0x402417BA, 0x402981FB, 0x402F19FB,
        0x4034E13D, 0x403AD950, 0x404103CF, 0x40476266, 0x404DF6CC,
        0x4054C2C8, 0x405BC82F, 0x406308E7
    ];
    public IReadOnlyList<PvpBonusSource> Rows { get; }
    public float LowAmmoThreshold { get; }
    public float WarbucksScalingBase { get; }
    public PvpBonusWarbucksDrawRange WarbucksBaseDrawRange { get; } = new(500, 1500);

    private PvpBonusCatalog(PvpBonusSource[] rows, float lowAmmoThreshold,
        float warbucksScalingBase)
    {
        Rows = new ReadOnlyCollection<PvpBonusSource>(rows);
        LowAmmoThreshold = lowAmmoThreshold;
        WarbucksScalingBase = warbucksScalingBase;
    }

    public int WarbucksRewardForBaseDraw(int ownerLevelIndex, int baseDraw)
        => WarbucksAmountForRecipient(ownerLevelIndex, baseDraw);

    internal static int WarbucksAmountForRecipient(int ownerLevelIndex, int baseDraw)
    {
        if (ownerLevelIndex is < 0 or > 42)
            throw new ArgumentOutOfRangeException(nameof(ownerLevelIndex));
        if (baseDraw is < 500 or >= 1500)
            throw new ArgumentOutOfRangeException(nameof(baseDraw));
        // Unity's Mathf.Pow and .NET MathF.Pow differ at integer truncation
        // boundaries. Use the reviewed Unity result for each source rank.
        float scale = BitConverter.Int32BitsToSingle(UnityWarbucksScaleBits[ownerLevelIndex]);
        double scaled = (double)scale * baseDraw;
        if (!double.IsFinite(scaled) || scaled < 0d || scaled > int.MaxValue)
            throw new InvalidDataException("PvP Warbucks reward exceeds source integer authority.");
        return (int)scaled;
    }

    public PvpBonusGoldRange GoldRewardRange(int displayLevel)
        => GoldRewardRangeForDisplayLevel(displayLevel);

    internal static PvpBonusGoldRange GoldRewardRangeForDisplayLevel(int displayLevel)
    {
        if (displayLevel is < 1 or > 43)
            throw new ArgumentOutOfRangeException(nameof(displayLevel));
        // The source casts each interpolated float to int before Random.Range.
        int minimum = (int)InterpolateGoldAmount(displayLevel, 5f, 3f);
        int maximum = (int)InterpolateGoldAmount(displayLevel, 10f, 6f);
        return new(minimum, maximum);
    }

    private static float InterpolateGoldAmount(int displayLevel, float low, float high)
    {
        if (displayLevel <= 5) return low;
        if (displayLevel >= 8) return high;
        float fraction = (float)(displayLevel - 5) / 3f;
        return (float)((1d - fraction) * low + (double)fraction * high);
    }

    public IReadOnlyList<float> WeightsForSourceContext(PvpBonusWeightContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        if (context.LocalDisplayLevel is < 1 or > 43 ||
            context.OwnerLevelIndex is < 0 or > 42 || context.GoldBonusesCollected < 0)
            throw new ArgumentOutOfRangeException(nameof(context));
        var weights = new float[Rows.Count];
        foreach (var row in Rows)
            weights[row.Index] = context.IsWarArena ? row.ArenaProbability : row.Probability;

        // Gold's override uses LevelManager's local display level and local
        // analytics, even when GetBonusProbability receives another owner.
        bool goldAllowed = !context.IsFriendlyDeathMatch &&
            (context.LocalDisplayLevel <= 5 || context.GoldBonusesCollected < 3);
        if (!goldAllowed)
            weights[0] = 0;
        else
            weights[0] = InterpolateGoldProbability(context.LocalDisplayLevel, weights[0]);

        if (context.IsFriendlyDeathMatch)
            weights[2] = 0;
        // Card eligibility instead uses the owner's zero-based properties.level.
        if (context.IsFriendlyDeathMatch || context.OwnerLevelIndex <= 6)
            weights[7] = 0;
        if (context.FirstTwoWeaponsHaveLowAmmo)
            weights[8] *= 2f;
        return new ReadOnlyCollection<float>(weights);
    }

    private static float InterpolateGoldProbability(int displayLevel, float baseProbability)
    {
        if (displayLevel <= 5) return 25f;
        if (displayLevel >= 8) return baseProbability;
        float fraction = (float)(displayLevel - 5) / 3f;
        // Retain LevelManager's float fraction storage and Mono intermediate
        // expression precision, matching the original-method Mono weight probe.
        return (float)((1d - fraction) * 25f + (double)fraction * baseProbability);
    }

    public static PvpBonusCatalog Load(string path, string sceneSha256, string contentSha256)
    {
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedSha256)
            throw new InvalidDataException("PvP bonus catalog differs from reviewed source.");
        using var document = JsonDocument.Parse(bytes);
        var root = document.RootElement;
        var rules = root.GetProperty("rules");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("sceneSha256").GetString() != sceneSha256 ||
            root.GetProperty("battleContentSha256").GetString() != contentSha256 ||
            rules.GetProperty("goldLowLevelProbability").GetSingle() != 25f ||
            rules.GetProperty("goldLowLevelMinimum").GetSingle() != 5f ||
            rules.GetProperty("goldLowLevelMaximum").GetSingle() != 10f ||
            rules.GetProperty("goldRegularMinimum").GetSingle() != 3f ||
            rules.GetProperty("goldRegularMaximum").GetSingle() != 6f ||
            rules.GetProperty("warbucksMinimum").GetSingle() != 500f ||
            rules.GetProperty("warbucksMaximum").GetSingle() != 1500f ||
            rules.GetProperty("warbucksScalingBase").GetSingle() != 1.033f ||
            rules.GetProperty("cardUnlockLevel").GetSingle() != 6f ||
            rules.GetProperty("lowAmmoThreshold").GetSingle() != 0.1f ||
            rules.GetProperty("lowAmmoMultiplier").GetSingle() != 2f ||
            rules.GetProperty("rankCount").GetInt32() != 43)
            throw new InvalidDataException("PvP bonus catalog uses different source provenance.");
        var source = root.GetProperty("rows");
        if (source.GetArrayLength() != SourceNames.Length)
            throw new InvalidDataException("Incomplete source bonus list.");
        var rows = new PvpBonusSource[SourceNames.Length];
        for (int index = 0; index < rows.Length; index++)
        {
            var row = source[index];
            if (row.GetProperty("index").GetInt32() != index || row.GetProperty("name").GetString() != SourceNames[index])
                throw new InvalidDataException("Source bonus order changed.");
            rows[index] = new(index, SourceNames[index], row.GetProperty("prefabGuid").GetString()!,
                row.GetProperty("componentFileId").GetInt64(), row.GetProperty("prefabPath").GetString()!,
                row.GetProperty("prefabSha256").GetString()!, row.GetProperty("probability").GetSingle(),
                row.GetProperty("arenaProbability").GetSingle());
        }
        string unityReference = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(path))!,
            "unity-pvp-bonus-reference.json");
        ValidateUnityWarbucksScales(unityReference);
        return new PvpBonusCatalog(rows, rules.GetProperty("lowAmmoThreshold").GetSingle(),
            rules.GetProperty("warbucksScalingBase").GetSingle());
    }

    private static void ValidateUnityWarbucksScales(string path)
    {
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedUnityReferenceSha256)
            throw new InvalidDataException("PvP bonus Unity arithmetic differs from reviewed source.");
        using var document = JsonDocument.Parse(bytes);
        var root = document.RootElement;
        if (root.GetProperty("version").GetInt32() != 2 ||
            root.GetProperty("unityVersion").GetString() != "2018.3.0f2" ||
            root.GetProperty("codeSha256").GetString() != ReviewedSourceCodeSha256)
            throw new InvalidDataException("PvP bonus Unity arithmetic has different provenance.");
        var samples = root.GetProperty("currencySamples");
        if (samples.GetArrayLength() != UnityWarbucksScaleBits.Length)
            throw new InvalidDataException("Incomplete Unity Warbucks rank scales.");
        for (int level = 0; level < UnityWarbucksScaleBits.Length; level++)
        {
            var sample = samples[level];
            string? amountsSha256 = sample.GetProperty("amountsSha256").GetString();
            if (sample.GetProperty("recipientLevelIndex").GetInt32() != level ||
                sample.GetProperty("scaleBits").GetInt32() != UnityWarbucksScaleBits[level] ||
                amountsSha256 is not {Length: 64} ||
                amountsSha256.Any(character => !Uri.IsHexDigit(character) || char.IsUpper(character)))
                throw new InvalidDataException("Invalid Unity Warbucks rank sample.");
        }
    }
}
