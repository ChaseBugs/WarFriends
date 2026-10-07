using System.Collections.ObjectModel;
using System.Text.Json;

namespace War.BattleServer;

public sealed record MissionSpawnBehaviour(
    string Name, int Level, int SceneLimit, int MissionLimit);

public sealed record MissionTimedEvent(
    float TimeSeconds, string Behaviour, int Level, bool IsCardUnit,
    int Count, string Card);

public sealed record MissionMapRule(
    int Stage, string Name, string Scene, string SceneSha256);

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
    public const string SourceRevision = "d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43";
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
    private static readonly string[] ExpectedMapScenes =
        ["Desert_New", "Snow_Single", "City_Single", "Aztec_Single", "Park_Single"];
    private static readonly string[] ExpectedBossMapScenes =
        ["Desert_Multiplayer", "Snow_Multiplayer", "City_Multiplayer",
         "Aztec_Multiplayer", "Park_Multiplayer"];
    private static readonly string[] ExpectedMapHashes =
        ["e5e2ad6c9f602125d1da7c1949e0f002e8ee229a4c1fc16bf703ae96000f40c5",
         "a797c945ccc4e4307ad55611e16db086d3ace63f31a535388f7e5bbb461daf27",
         "99a24a690a023c8f9c2f1195b727ecdcc22740a6f0479f6148909a22db3f5127",
         "5fbfe89a6ff35e0769d4fcdbd9a80e6c31baec653a3bd78c53b81211cd8b9e17",
         "0f816c262e021a36bc347d62734504f9b86d2031d11a55cdf3c377bf4990ba83"];
    private static readonly string[] ExpectedBossMapHashes =
        ["d2acaeb238fb2dfdcfb0e1bb69a52628798498f7b6992ecf9418a727360368c1",
         "67291457da28646c9ce377f3812d1bf0fa5332bfe664f58a4430a823744e6f21",
         "acaf878b188dbc17fca6795b5db7e9c7797b91dee0fcb6fb02d5e85d7cc11c4f",
         "50b3077f1898189cbf40c2232771175b85eec0f03737901373da377faf95291e",
         "09b2c084ef5da6707fbebd4261a60baa0f12e24fef31efc4c6d4671b721e70ed"];

    public string SourceSha256 { get; }
    public IReadOnlyList<MissionRule> Missions { get; }
    public IReadOnlyList<MissionMapRule> Maps { get; }
    public IReadOnlyList<MissionMapRule> BossMaps { get; }

    private MissionCatalog(string sourceSha256, MissionRule[] missions,
        MissionMapRule[] maps, MissionMapRule[] bossMaps)
    {
        SourceSha256 = sourceSha256;
        Missions = new ReadOnlyCollection<MissionRule>(missions);
        Maps = new ReadOnlyCollection<MissionMapRule>(maps);
        BossMaps = new ReadOnlyCollection<MissionMapRule>(bossMaps);
    }

    public MissionRule Get(int missionIndex)
    {
        if (missionIndex < 0 || missionIndex >= Missions.Count)
            throw new ArgumentOutOfRangeException(nameof(missionIndex));
        return Missions[missionIndex];
    }

    public MissionMapRule MapForMission(int missionIndex)
    {
        MissionRule mission = Get(missionIndex);
        // MapManager.MapEntry.sceneName uses levelPVPName for BotMission:
        // GameController.isCoop/isCampaign explicitly exclude that subtype.
        return mission.MissionType == "KillOpponent"
            ? BossMaps[mission.MapStage - 1] : Maps[mission.MapStage - 1];
    }

    public MissionObjectiveState CreateObjectiveState(int missionIndex)
    {
        return new MissionObjectiveState(Get(missionIndex));
    }

    public MissionAutomaticSpawnState CreateAutomaticSpawnState(
        int missionIndex, Func<int, int>? chooseBehaviour = null)
    {
        return new MissionAutomaticSpawnState(Get(missionIndex), chooseBehaviour);
    }

    public static MissionCatalog Load(string path)
    {
        using var document = JsonDocument.Parse(File.ReadAllText(path));
        JsonElement root = document.RootElement;
        RequireProperties(root, "source", "sourceSha256", "maps", "bossMaps", "missions");
        if (root.GetProperty("source").GetString() != SourcePath)
            throw new InvalidDataException("Mission catalog has unexpected source provenance.");

        string sourceHash = ReadHash(root, "sourceSha256");
        if (sourceHash != SourceRevision)
            throw new InvalidDataException("Mission catalog is from an unreviewed MainScene.");
        MissionMapRule[] maps = ReadMaps(root.GetProperty("maps"),
            ExpectedMapScenes, ExpectedMapHashes);
        MissionMapRule[] bossMaps = ReadMaps(root.GetProperty("bossMaps"),
            ExpectedBossMapScenes, ExpectedBossMapHashes);
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
        return new MissionCatalog(sourceHash, missions, maps, bossMaps);
    }

    private static MissionMapRule[] ReadMaps(JsonElement entries,
        string[] expectedScenes, string[] expectedHashes)
    {
        if (entries.ValueKind != JsonValueKind.Array ||
            entries.GetArrayLength() != expectedScenes.Length)
            throw new InvalidDataException("Mission map catalog must contain five source stages.");

        var maps = new MissionMapRule[expectedScenes.Length];
        for (int index = 0; index < maps.Length; index++)
        {
            JsonElement entry = entries[index];
            RequireProperties(entry, "stage", "name", "scene", "sceneSha256");
            int stage = ReadInt(entry, "stage", 1, maps.Length);
            string name = entry.GetProperty("name").GetString() ?? "";
            string scene = entry.GetProperty("scene").GetString() ?? "";
            string hash = ReadHash(entry, "sceneSha256");
            if (stage != index + 1 || scene != expectedScenes[index] ||
                hash != expectedHashes[index] ||
                name.Length is < 1 or > 40 || name.Any(char.IsControl))
                throw new InvalidDataException("Mission map order or identity differs from the source.");
            maps[index] = new MissionMapRule(stage, name, scene, hash);
        }
        return maps;
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
            ReadInt(entry, "mapStage", 1, 5), type, objective,
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
