using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopBotHealth(
    int MissionIndex, int Level, float BaseHealth,
    float HealthMultiplier, float MaximumHealth);

/// <summary>
/// Decoded MainScene balance-table health and BotManager's binary32 product.
/// A zero maximum is preserved; it is not a server-authored fallback value.
/// </summary>
public sealed class CoopBotHealthCatalog
{
    private const string ReviewedArtifactSha256 =
        "062b83733295b3b7c80c3ae7288d2a56931f012648ad2d36b7374ca81342db25";

    public IReadOnlyList<float> PlayerHealthByLevel { get; }
    public IReadOnlyList<CoopBotHealth> Bosses { get; }

    private CoopBotHealthCatalog(float[] levels, CoopBotHealth[] bosses)
    {
        PlayerHealthByLevel = new ReadOnlyCollection<float>(levels);
        Bosses = new ReadOnlyCollection<CoopBotHealth>(bosses);
    }

    public CoopBotHealth ForMission(int missionIndex)
    {
        if (missionIndex is < 0 or > 74 || missionIndex % 5 != 4)
            throw new ArgumentOutOfRangeException(nameof(missionIndex));
        return Bosses[missionIndex / 5];
    }

    public static CoopBotHealthCatalog Load(string path, MissionCatalog missions,
        CoopBotRuleCatalog bots)
    {
        ArgumentNullException.ThrowIfNull(missions);
        ArgumentNullException.ThrowIfNull(bots);
        byte[] bytes = File.ReadAllBytes(path);
        if (Digest(bytes) != ReviewedArtifactSha256)
            throw new InvalidDataException("Co-op boss health differs from MainScene.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "sceneSha256", "botRulesSha256",
            "playerHealthByLevel", "bossHealth");
        string directory = Path.GetDirectoryName(path)!;
        byte[] botBytes = File.ReadAllBytes(Path.Combine(directory,
            "recovered-coop-bot-rules.json"));
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("sceneSha256").GetString() != missions.SourceSha256 ||
            root.GetProperty("botRulesSha256").GetString() != Digest(botBytes))
            throw new InvalidDataException("Co-op boss health source binding changed.");

        JsonElement levelEntries = root.GetProperty("playerHealthByLevel");
        if (levelEntries.ValueKind != JsonValueKind.Array ||
            levelEntries.GetArrayLength() != 44)
            throw new InvalidDataException("Co-op player health needs 44 source rows.");
        var levels = new float[44];
        for (int index = 0; index < levels.Length; index++)
        {
            float health = levelEntries[index].GetSingle();
            if (!float.IsFinite(health) || health <= 0 || health >= 100_000 ||
                index > 0 && health <= levels[index - 1])
                throw new InvalidDataException("Co-op player health row is invalid.");
            levels[index] = health;
        }

        JsonElement bossEntries = root.GetProperty("bossHealth");
        if (bossEntries.ValueKind != JsonValueKind.Array ||
            bossEntries.GetArrayLength() != 15)
            throw new InvalidDataException("Co-op boss health needs fifteen rows.");
        var bosses = new CoopBotHealth[15];
        int zeroHealthCount = 0;
        for (int index = 0; index < bosses.Length; index++)
        {
            JsonElement entry = bossEntries[index];
            RequireFields(entry, "missionIndex", "level", "baseHealth",
                "healthMultiplier", "maximumHealth");
            int missionIndex = 4 + index * 5;
            CoopBotRule rule = bots.ForMission(missionIndex);
            int level = entry.GetProperty("level").GetInt32();
            float baseHealth = entry.GetProperty("baseHealth").GetSingle();
            float multiplier = entry.GetProperty("healthMultiplier").GetSingle();
            float maximum = entry.GetProperty("maximumHealth").GetSingle();
            if (level < 0 || level >= levels.Length ||
                rule.Level < 0 || rule.Level >= levels.Length)
                throw new InvalidDataException("Co-op boss level lacks a balance row.");
            float expectedMaximum = levels[rule.Level] * rule.HealthMultiplier;
            if (entry.GetProperty("missionIndex").GetInt32() != missionIndex ||
                level != rule.Level || baseHealth != levels[level] ||
                multiplier != rule.HealthMultiplier ||
                !float.IsFinite(maximum) || maximum < 0 ||
                BitConverter.SingleToInt32Bits(maximum) !=
                    BitConverter.SingleToInt32Bits(expectedMaximum))
                throw new InvalidDataException("Co-op boss health differs from its source row.");
            if (maximum == 0)
                zeroHealthCount++;
            bosses[index] = new CoopBotHealth(missionIndex, level,
                baseHealth, multiplier, maximum);
        }
        if (zeroHealthCount != 6)
            throw new InvalidDataException("Co-op zero-health boss count changed.");
        return new CoopBotHealthCatalog(levels, bosses);
    }

    private static string Digest(byte[] bytes) =>
        Convert.ToHexStringLower(SHA256.HashData(bytes));

    private static void RequireFields(JsonElement entry, params string[] fields)
    {
        if (entry.ValueKind != JsonValueKind.Object ||
            entry.EnumerateObject().Count() != fields.Length ||
            fields.Any(name => !entry.TryGetProperty(name, out _)))
            throw new InvalidDataException("Co-op boss health has unexpected fields.");
    }
}
