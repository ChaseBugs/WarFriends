using System.Collections.ObjectModel;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>A single recovered campaign mission's server-owned configuration.</summary>
public sealed record MissionRule(
    int Index, int Level, int MapStage, string MissionType, int? Objective,
    int TimeSeconds, int ScoreOneStar, int ScoreTwoStars, int ScoreThreeStars,
    int MaxUnitsAtOnce, int RewardWarbucks, int RewardGold, int RewardXp,
    string SceneDataSha256);

/// <summary>Validated, immutable mission rules extracted from the 1.4.0 MainScene.</summary>
public sealed class MissionCatalog
{
    private const string SourcePath = "Clients/ExportedProject/Assets/Scenes/MainScene.unity";
    private static readonly IReadOnlyDictionary<string, int> ExpectedTypes =
        new Dictionary<string, int>(StringComparer.Ordinal)
        {
            ["KillXEnemies"] = 22,
            ["SurviveXSeconds"] = 23,
            ["Score"] = 15,
            ["KillOpponent"] = 15
        };

    public string SourceSha256 { get; }
    public IReadOnlyList<MissionRule> Missions { get; }

    private MissionCatalog(string sourceSha256, MissionRule[] missions)
    {
        SourceSha256 = sourceSha256;
        Missions = new ReadOnlyCollection<MissionRule>(missions);
    }

    public MissionRule Get(int missionIndex)
    {
        if (missionIndex < 0 || missionIndex >= Missions.Count)
            throw new ArgumentOutOfRangeException(nameof(missionIndex));
        return Missions[missionIndex];
    }

    public static MissionCatalog Load(string path)
    {
        using var document = JsonDocument.Parse(File.ReadAllText(path));
        JsonElement root = document.RootElement;
        RequireProperties(root, "source", "sourceSha256", "missions");
        if (root.GetProperty("source").GetString() != SourcePath)
            throw new InvalidDataException("Mission catalog has unexpected source provenance.");

        string sourceHash = ReadHash(root, "sourceSha256");
        JsonElement entries = root.GetProperty("missions");
        if (entries.ValueKind != JsonValueKind.Array || entries.GetArrayLength() != 75)
            throw new InvalidDataException("Mission catalog must contain all 75 source rows.");

        var missions = new MissionRule[75];
        var typeCounts = new Dictionary<string, int>(StringComparer.Ordinal);
        for (int index = 0; index < missions.Length; index++)
        {
            MissionRule mission = ReadMission(entries[index]);
            if (mission.Index != index || mission.Level != index + 1)
                throw new InvalidDataException("Mission rows are missing or out of order.");
            missions[index] = mission;
            typeCounts[mission.MissionType] = typeCounts.GetValueOrDefault(mission.MissionType) + 1;
        }

        foreach (var expected in ExpectedTypes)
        {
            if (typeCounts.GetValueOrDefault(expected.Key) != expected.Value)
                throw new InvalidDataException("Mission objective types differ from the recovered source.");
        }
        return new MissionCatalog(sourceHash, missions);
    }

    private static MissionRule ReadMission(JsonElement entry)
    {
        RequireProperties(entry, "index", "level", "mapStage", "missionType", "objective",
            "timeSeconds", "scoreOneStar", "scoreTwoStars", "scoreThreeStars",
            "maxUnitsAtOnce", "rewardWarbucks", "rewardGold", "rewardXp", "sceneDataSha256");

        string type = entry.GetProperty("missionType").GetString() ?? "";
        if (!ExpectedTypes.ContainsKey(type))
            throw new InvalidDataException("Unknown recovered mission objective type.");
        JsonElement objectiveValue = entry.GetProperty("objective");
        int? objective = objectiveValue.ValueKind == JsonValueKind.Null
            ? null : objectiveValue.GetInt32();
        bool needsObjective = type is "KillXEnemies" or "Score";
        if (needsObjective != objective.HasValue || objective is <= 0 or > 100_000)
            throw new InvalidDataException("Mission objective does not match its type.");

        var mission = new MissionRule(
            ReadInt(entry, "index", 0, 74), ReadInt(entry, "level", 1, 75),
            ReadInt(entry, "mapStage", 1, 100), type, objective,
            ReadInt(entry, "timeSeconds", 1, 3600),
            ReadInt(entry, "scoreOneStar", 0, 1_000_000),
            ReadInt(entry, "scoreTwoStars", 0, 1_000_000),
            ReadInt(entry, "scoreThreeStars", 0, 1_000_000),
            ReadInt(entry, "maxUnitsAtOnce", 1, 100),
            ReadInt(entry, "rewardWarbucks", 0, 1_000_000),
            ReadInt(entry, "rewardGold", 0, 1_000_000),
            ReadInt(entry, "rewardXp", 0, 1_000_000),
            ReadHash(entry, "sceneDataSha256"));
        if (mission.ScoreOneStar > mission.ScoreTwoStars ||
            mission.ScoreTwoStars > mission.ScoreThreeStars)
            throw new InvalidDataException("Mission star thresholds are out of order.");
        return mission;
    }

    private static int ReadInt(JsonElement entry, string name, int minimum, int maximum)
    {
        int value = entry.GetProperty(name).GetInt32();
        if (value < minimum || value > maximum)
            throw new InvalidDataException($"Mission {name} is outside the recovered domain.");
        return value;
    }

    private static string ReadHash(JsonElement entry, string name)
    {
        string hash = entry.GetProperty(name).GetString() ?? "";
        if (hash.Length != 64 || hash.Any(character => !char.IsAsciiHexDigitLower(character)))
            throw new InvalidDataException($"Mission {name} must be a lowercase SHA-256 digest.");
        return hash;
    }

    private static void RequireProperties(JsonElement entry, params string[] names)
    {
        if (entry.ValueKind != JsonValueKind.Object)
            throw new InvalidDataException("Mission catalog contains a non-object record.");
        var expected = new HashSet<string>(names, StringComparer.Ordinal);
        foreach (JsonProperty property in entry.EnumerateObject())
        {
            if (!expected.Remove(property.Name))
                throw new InvalidDataException("Mission catalog contains an unknown or duplicate field.");
        }
        if (expected.Count != 0)
            throw new InvalidDataException("Mission catalog is missing a required field.");
    }
}
