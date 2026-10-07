using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed class CoopBotRule
{
    public int MissionIndex { get; }
    public string Name { get; }
    public int Difficulty { get; }
    public int Level { get; }
    public float HealthMultiplier { get; }
    public string Camo { get; }
    public string HeadAccessory { get; }
    public string Helmet { get; }
    public string PowerBand { get; }
    public bool UseDefinedCards { get; }
    public IReadOnlyList<string> Cards { get; }

    internal CoopBotRule(int missionIndex, string name, int difficulty, int level,
        float healthMultiplier, string camo, string headAccessory, string helmet,
        string powerBand, bool useDefinedCards, string[] cards)
    {
        MissionIndex = missionIndex;
        Name = name;
        Difficulty = difficulty;
        Level = level;
        HealthMultiplier = healthMultiplier;
        Camo = camo;
        HeadAccessory = headAccessory;
        Helmet = helmet;
        PowerBand = powerBand;
        UseDefinedCards = useDefinedCards;
        Cards = new ReadOnlyCollection<string>(cards);
    }
}

/// <summary>
/// Source BotMission definitions. The six zero-multiplier rows are preserved;
/// this catalog does not turn them into a killable boss or award a victory.
/// </summary>
public sealed class CoopBotRuleCatalog
{
    private const string SourceSha256 =
        "b0a713650355cad6ea8ccaeec64a3ca89e035e0fe8793f58714db78005bc7048";

    public IReadOnlyList<CoopBotRule> Bots { get; }

    private CoopBotRuleCatalog(CoopBotRule[] bots)
    {
        Bots = new ReadOnlyCollection<CoopBotRule>(bots);
    }

    public CoopBotRule ForMission(int missionIndex)
    {
        if (missionIndex is < 0 or > 74 || missionIndex % 5 != 4)
            throw new ArgumentOutOfRangeException(nameof(missionIndex));
        return Bots[missionIndex / 5];
    }

    public static CoopBotRuleCatalog Load(string path, MissionCatalog missions)
    {
        ArgumentNullException.ThrowIfNull(missions);
        byte[] bytes = File.ReadAllBytes(path);
        string digest = Convert.ToHexStringLower(SHA256.HashData(bytes));
        if (digest != SourceSha256)
            throw new InvalidDataException("Co-op boss rows differ from recovered MainScene.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "missionSourceSha256", "bots");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("missionSourceSha256").GetString() != missions.SourceSha256)
            throw new InvalidDataException("Co-op boss rows differ from the mission source.");
        JsonElement entries = root.GetProperty("bots");
        if (entries.ValueKind != JsonValueKind.Array || entries.GetArrayLength() != 15)
            throw new InvalidDataException("Co-op boss catalog needs fifteen rows.");

        var bots = new CoopBotRule[15];
        int zeroHealthMultipliers = 0;
        for (int index = 0; index < bots.Length; index++)
        {
            JsonElement entry = entries[index];
            RequireFields(entry, "missionIndex", "sceneDataSha256", "bot");
            int missionIndex = 4 + index * 5;
            MissionRule mission = missions.Get(missionIndex);
            if (entry.GetProperty("missionIndex").GetInt32() != missionIndex ||
                mission.MissionType != "KillOpponent" ||
                entry.GetProperty("sceneDataSha256").GetString() !=
                    mission.SceneDataSha256)
                throw new InvalidDataException("Co-op boss row differs from its mission.");

            JsonElement bot = entry.GetProperty("bot");
            RequireFields(bot, "name", "difficulty", "level", "hpReduction",
                "camo", "headAccesory", "helmet", "powerBand",
                "useDefinedCards", "cards");
            int difficulty = bot.GetProperty("difficulty").GetInt32();
            int level = bot.GetProperty("level").GetInt32();
            float healthMultiplier = bot.GetProperty("hpReduction").GetSingle();
            if (difficulty is < 1 or > 49 || level is < 0 or > 49 ||
                !float.IsFinite(healthMultiplier) || healthMultiplier is < 0 or > 1)
                throw new InvalidDataException("Co-op boss difficulty or health is invalid.");
            if (healthMultiplier == 0)
                zeroHealthMultipliers++;

            JsonElement cardEntries = bot.GetProperty("cards");
            if (cardEntries.ValueKind != JsonValueKind.Array ||
                cardEntries.GetArrayLength() > 8)
                throw new InvalidDataException("Co-op boss card list is invalid.");
            string[] cards = cardEntries.EnumerateArray()
                .Select(card => ReadText(card, 64)).ToArray();
            bool useDefinedCards = bot.GetProperty("useDefinedCards").GetBoolean();
            if (!useDefinedCards && cards.Length != 0)
                throw new InvalidDataException("Co-op boss card selection is inconsistent.");
            bots[index] = new CoopBotRule(missionIndex,
                ReadText(bot.GetProperty("name"), 64), difficulty, level,
                healthMultiplier, ReadText(bot.GetProperty("camo"), 64),
                ReadText(bot.GetProperty("headAccesory"), 64),
                ReadText(bot.GetProperty("helmet"), 64),
                ReadText(bot.GetProperty("powerBand"), 64),
                useDefinedCards, cards);
        }
        if (zeroHealthMultipliers != 6)
            throw new InvalidDataException("Co-op boss zero-health source rows changed.");
        return new CoopBotRuleCatalog(bots);
    }

    private static string ReadText(JsonElement entry, int maxLength)
    {
        string value = entry.GetString() ?? "";
        if (value.Length > maxLength || value.Any(char.IsControl))
            throw new InvalidDataException("Co-op boss text is invalid.");
        return value;
    }

    private static void RequireFields(JsonElement entry, params string[] fields)
    {
        if (entry.ValueKind != JsonValueKind.Object ||
            entry.EnumerateObject().Count() != fields.Length ||
            fields.Any(name => !entry.TryGetProperty(name, out _)))
            throw new InvalidDataException("Co-op boss record has unexpected fields.");
    }
}
