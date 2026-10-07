using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopBossAttackTiming(
    int MissionIndex, int SourceDifficulty, int PlayerBotsRow, int ConfigIndex,
    string PrimaryCategory, string SecondaryCategory,
    string ExplosiveCategory, string PistolCategory,
    float ShootFrequencyMinSeconds, float ShootFrequencyMaxSeconds,
    float ShootingLengthMinSeconds, float ShootingLengthMaxSeconds,
    float ShootAccuracy, float ExplosiveSwitchProbability, float OpponentOffense,
    float OpponentOffenseReactionSeconds);

/// <summary>
/// BotManager chooses a PlayerBots row by mission difficulty, then its
/// PlayerBotDiffculties row. These are the selected PlayerBot shooting values.
/// </summary>
public sealed class CoopBossAttackTimingCatalog
{
    private const string ReviewedArtifactSha256 =
        "dc284fe64fc7a2d4430c1c2c554887ed7322da19c8cbfc8a01ad6d8e792367b0";

    public IReadOnlyList<CoopBossAttackTiming> Missions { get; }

    private CoopBossAttackTimingCatalog(CoopBossAttackTiming[] missions)
    {
        Missions = new ReadOnlyCollection<CoopBossAttackTiming>(missions);
    }

    public CoopBossAttackTiming ForMission(int missionIndex)
    {
        if (missionIndex is < 4 or > 74 || missionIndex % 5 != 4)
            throw new ArgumentOutOfRangeException(nameof(missionIndex));
        return Missions[missionIndex / 5];
    }

    public static CoopBossAttackTimingCatalog Load(string path,
        MissionCatalog missions, CoopBotRuleCatalog bots)
    {
        ArgumentNullException.ThrowIfNull(missions);
        ArgumentNullException.ThrowIfNull(bots);
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedArtifactSha256)
            throw new InvalidDataException("Boss shooting rows differ from MainScene.");

        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "sceneSha256", "botRulesSha256",
            "difficultyComponentFileId", "playerBotsComponentFileId", "missions");
        string botPath = Path.Combine(Path.GetDirectoryName(Path.GetFullPath(path))!,
            "recovered-coop-bot-rules.json");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("sceneSha256").GetString() != missions.SourceSha256 ||
            root.GetProperty("botRulesSha256").GetString() !=
                Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(botPath))) ||
            root.GetProperty("difficultyComponentFileId").GetInt32() != 46608 ||
            root.GetProperty("playerBotsComponentFileId").GetInt32() != 46610)
            throw new InvalidDataException("Boss shooting source identity changed.");

        JsonElement entries = root.GetProperty("missions");
        if (entries.ValueKind != JsonValueKind.Array || entries.GetArrayLength() != 15)
            throw new InvalidDataException("Boss shooting needs fifteen missions.");
        var rows = new CoopBossAttackTiming[15];
        for (int index = 0; index < rows.Length; index++)
        {
            JsonElement entry = entries[index];
            RequireFields(entry, "missionIndex", "sourceDifficulty",
                "playerBotsRow", "configIndex", "primaryCategory",
                "secondaryCategory", "explosiveCategory", "pistolCategory",
                "shootFrequencyMinSeconds",
                "shootFrequencyMaxSeconds", "shootingLengthMinSeconds",
                "shootingLengthMaxSeconds", "shootAccuracy",
                "explosiveSwitchProbability", "opponentOffense",
                "opponentOffenseReactionSeconds");
            int missionIndex = index * 5 + 4;
            CoopBotRule bot = bots.ForMission(missionIndex);
            int sourceDifficulty = entry.GetProperty("sourceDifficulty").GetInt32();
            int playerBotsRow = entry.GetProperty("playerBotsRow").GetInt32();
            int configIndex = entry.GetProperty("configIndex").GetInt32();
            string primary = entry.GetProperty("primaryCategory").GetString() ?? "";
            string secondary = entry.GetProperty("secondaryCategory").GetString() ?? "";
            string explosive = entry.GetProperty("explosiveCategory").GetString() ?? "";
            string pistol = entry.GetProperty("pistolCategory").GetString() ?? "";
            float frequencyMin = Positive(entry, "shootFrequencyMinSeconds");
            float frequencyMax = Positive(entry, "shootFrequencyMaxSeconds");
            float lengthMin = Positive(entry, "shootingLengthMinSeconds");
            float lengthMax = Positive(entry, "shootingLengthMaxSeconds");
            float accuracy = Probability(entry, "shootAccuracy");
            float explosiveSwitch = Probability(entry,
                "explosiveSwitchProbability");
            float offense = Probability(entry, "opponentOffense");
            float reaction = Positive(entry, "opponentOffenseReactionSeconds");
            if (entry.GetProperty("missionIndex").GetInt32() != missionIndex ||
                missions.Get(missionIndex).MissionType != "KillOpponent" ||
                sourceDifficulty != bot.Difficulty ||
                playerBotsRow != sourceDifficulty ||
                configIndex is < 0 or > 31 ||
                primary != "AssaultRifle " ||
                secondary is not ("SniperRifle" or "Shotgun") ||
                explosive is not ("Grenade" or "RocketLauncher") ||
                pistol != "Pistol" ||
                frequencyMin > frequencyMax || lengthMin > lengthMax)
                throw new InvalidDataException("Boss shooting row differs from its mission.");
            rows[index] = new CoopBossAttackTiming(missionIndex,
                sourceDifficulty, playerBotsRow, configIndex,
                primary, secondary, explosive, pistol,
                frequencyMin, frequencyMax, lengthMin, lengthMax,
                accuracy, explosiveSwitch, offense, reaction);
        }
        return new CoopBossAttackTimingCatalog(rows);
    }

    private static float Positive(JsonElement entry, string name)
    {
        float value = entry.GetProperty(name).GetSingle();
        if (!float.IsFinite(value) || value <= 0 || value > 60)
            throw new InvalidDataException($"Boss {name} is outside shooting bounds.");
        return value;
    }

    private static float Probability(JsonElement entry, string name)
    {
        float value = entry.GetProperty(name).GetSingle();
        if (!float.IsFinite(value) || value < 0 || value > 1)
            throw new InvalidDataException($"Boss {name} is not a probability.");
        return value;
    }

    private static void RequireFields(JsonElement entry, params string[] fields)
    {
        if (entry.ValueKind != JsonValueKind.Object ||
            entry.EnumerateObject().Count() != fields.Length ||
            fields.Any(name => !entry.TryGetProperty(name, out _)))
            throw new InvalidDataException("Boss shooting artifact has unexpected fields.");
    }
}
