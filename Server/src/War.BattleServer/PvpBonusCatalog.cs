using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record PvpBonusSource(int Index, string Name, string PrefabGuid,
    long ComponentFileId, string PrefabPath, string PrefabSha256,
    float Probability, float ArenaProbability);
public sealed record PvpBonusGoldRange(int Minimum, int MaximumExclusive);

/// <summary>Host-established source perspective, never a Client probability request.</summary>
public sealed record PvpBonusWeightContext(bool IsWarArena, bool IsFriendlyDeathMatch,
    int LocalDisplayLevel, int OwnerLevelIndex, int GoldBonusesCollected,
    bool FirstTwoWeaponsHaveLowAmmo);

public sealed class PvpBonusCatalog
{
    private const string ReviewedSha256 =
        "15dd2f0e05e2d3966d111e9ed2b9e065eadc6bc3e1cafe600e03d59254fd8755";
    private static readonly string[] SourceNames = ["KillStreakBonusGold",
        "KillStreakBonusAddHealth", "KillStreakBonusWarbucks", "KillStreakBonusGrenades",
        "KillStreakBonusSlowMotion", "KillStreakBonusTurret", "KillStreakBonusKevlar",
        "KillStreakBonusCard", "KillStreakBonusAddAmmo"];
    public IReadOnlyList<PvpBonusSource> Rows { get; }
    public float LowAmmoThreshold { get; }

    private PvpBonusCatalog(PvpBonusSource[] rows, float lowAmmoThreshold)
    {
        Rows = new ReadOnlyCollection<PvpBonusSource>(rows);
        LowAmmoThreshold = lowAmmoThreshold;
    }

    public PvpBonusGoldRange GoldRewardRange(int displayLevel)
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
        return new PvpBonusCatalog(rows, rules.GetProperty("lowAmmoThreshold").GetSingle());
    }
}
