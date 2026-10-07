using System.Collections.ObjectModel;
using System.Text.Json;

namespace War.BattleServer;

public sealed record MissionSpawnBehaviour(
    string Name, int Level, int SceneLimit, int MissionLimit);

public sealed record MissionTimedEvent(
    float TimeSeconds, string Behaviour, int Level, bool IsCardUnit,
    int Count, string Card);

/// <summary>A single recovered campaign mission's server-owned configuration.</summary>
public sealed record MissionRule(
    int Index, int Level, int MapStage, string MissionType, int? Objective,
    int TimeSeconds, int ScoreOneStar, int ScoreTwoStars, int ScoreThreeStars,
    int MaxUnitsAtOnce, int RewardWarbucks, int RewardGold, int RewardXp,
    float HealthTargetFraction, float TimeTargetFraction,
    int RecommendedArmyPower,
    IReadOnlyList<MissionSpawnBehaviour> Behaviours,
    IReadOnlyList<MissionTimedEvent> Events,
    string SceneDataSha256);

/// <summary>Validated, immutable mission rules extracted from the 1.4.0 MainScene.</summary>
public sealed class MissionCatalog
{
    private const string SourcePath = "Clients/ExportedProject/Assets/Scenes/MainScene.unity";
    private const string SourceHash = "d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43";
    private static readonly HashSet<string> KnownBehaviours = new(StringComparer.OrdinalIgnoreCase)
    {
        "Assaulter", "Sniper", "Grenadier", "Shotgunner", "Parachuter",
        "Minigunner", "RocketLauncher", "Swat", "Engineer", "Drone",
        "Helicopter", "DeployHeli", "Humvee", "Buggy", "Tank",
        "MachineGunner", "SciFi", "Transporter", "Commando",
        "Flamethrower", "Gunslinger", "Warper", "Mortar", "Mech"
    };
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

    public MissionObjectiveState CreateObjectiveState(int missionIndex)
    {
        return new MissionObjectiveState(Get(missionIndex));
    }

    public static MissionCatalog Load(string path)
    {
        using var document = JsonDocument.Parse(File.ReadAllText(path));
        JsonElement root = document.RootElement;
        RequireProperties(root, "source", "sourceSha256", "missions");
        if (root.GetProperty("source").GetString() != SourcePath)
            throw new InvalidDataException("Mission catalog has unexpected source provenance.");

        string sourceHash = ReadHash(root, "sourceSha256");
        if (sourceHash != SourceHash)
            throw new InvalidDataException("Mission catalog is from an unreviewed MainScene.");
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
            "maxUnitsAtOnce", "rewardWarbucks", "rewardGold", "rewardXp",
            "healthTargetFraction", "timeTargetFraction", "recommendedArmyPower",
            "behaviours", "events", "sceneDataSha256");

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
            ReadFraction(entry, "healthTargetFraction"),
            ReadFraction(entry, "timeTargetFraction"),
            ReadInt(entry, "recommendedArmyPower", 0, 1_000_000),
            ReadBehaviours(entry.GetProperty("behaviours")),
            ReadEvents(entry.GetProperty("events"),
                ReadInt(entry, "timeSeconds", 1, 3600)),
            ReadHash(entry, "sceneDataSha256"));
        if (mission.ScoreOneStar > mission.ScoreTwoStars ||
            mission.ScoreTwoStars > mission.ScoreThreeStars)
            throw new InvalidDataException("Mission star thresholds are out of order.");
        return mission;
    }

    private static IReadOnlyList<MissionSpawnBehaviour> ReadBehaviours(JsonElement entries)
    {
        if (entries.ValueKind != JsonValueKind.Array || entries.GetArrayLength() > 64)
            throw new InvalidDataException("Mission behavior list is invalid.");
        var behaviours = new List<MissionSpawnBehaviour>();
        var seenNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (JsonElement entry in entries.EnumerateArray())
        {
            RequireProperties(entry, "name", "level", "sceneLimit", "missionLimit");
            string name = ReadBehaviourName(entry, "name");
            if (!seenNames.Add(name))
                throw new InvalidDataException("Mission repeats a unit behavior.");
            behaviours.Add(new MissionSpawnBehaviour(name,
                ReadInt(entry, "level", 0, 100),
                ReadInt(entry, "sceneLimit", 0, 100),
                ReadInt(entry, "missionLimit", 0, 10_000)));
        }
        return new ReadOnlyCollection<MissionSpawnBehaviour>(behaviours);
    }

    private static IReadOnlyList<MissionTimedEvent> ReadEvents(
        JsonElement entries, int missionTimeSeconds)
    {
        if (entries.ValueKind != JsonValueKind.Array || entries.GetArrayLength() > 128)
            throw new InvalidDataException("Mission event list is invalid.");
        var events = new List<MissionTimedEvent>();
        foreach (JsonElement entry in entries.EnumerateArray())
        {
            RequireProperties(entry, "time", "behaviour", "level", "isCardUnit", "count", "card");
            float time = entry.GetProperty("time").GetSingle();
            if (!float.IsFinite(time) || time < 0 || time > missionTimeSeconds)
                throw new InvalidDataException("Mission event is outside its source timer.");
            string behaviour = ReadBehaviourName(entry, "behaviour");
            string card = entry.GetProperty("card").GetString() ?? "";
            if (card.Length > 128 || card.Any(char.IsControl))
                throw new InvalidDataException("Mission event card identity is invalid.");
            events.Add(new MissionTimedEvent(time, behaviour,
                ReadInt(entry, "level", 0, 100),
                entry.GetProperty("isCardUnit").GetBoolean(),
                ReadInt(entry, "count", 0, 10_000), card));
        }
        return new ReadOnlyCollection<MissionTimedEvent>(events);
    }

    private static string ReadBehaviourName(JsonElement entry, string field)
    {
        string name = entry.GetProperty(field).GetString() ?? "";
        if (!KnownBehaviours.Contains(name))
            throw new InvalidDataException("Mission names an unsupported unit behavior.");
        return name;
    }

    private static float ReadFraction(JsonElement entry, string name)
    {
        float value = entry.GetProperty(name).GetSingle();
        if (!float.IsFinite(value) || value <= 0 || value > 1)
            throw new InvalidDataException($"Mission {name} is outside the recovered domain.");
        return value;
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
