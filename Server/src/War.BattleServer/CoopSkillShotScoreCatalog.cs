using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopSkillShotScore(int Flag, string Name, string DictionaryId, int MissionPoints);

public enum CoopEnemyKillCredit
{
    Player,
    AlliedArmy,
    UnownedBasicDamage,
    UnownedExplosion
}

/// <summary>
/// Source points for Score missions. SkillShotController gives different flags
/// for a player's kill, an allied army kill, and an unowned environmental kill.
/// Call these methods only with events established by host combat rules.
/// </summary>
public sealed class CoopSkillShotScoreCatalog
{
    private const int KillFlag = 4096;
    private const int ExplosiveKillFlag = 8192;
    private const int AlliedArmyKillFlag = 32768;
    private const int EnvironmentalKillFlag = 262144;
    internal const int DoubleKillFlag = 32;
    internal const int TripleKillFlag = 64;
    internal const int MultiKillFlag = 128;
    internal const int ComboWindowTicks = 27;
    private const string ReviewedSha256 =
        "4813a3a2404bb0ad2e08035eec0de1ad954b315446e71c8c0dcb0b23d431e5fd";
    private readonly IReadOnlyList<CoopSkillShotScore> rows;
    private readonly int knownFlags;

    private CoopSkillShotScoreCatalog(CoopSkillShotScore[] scores, int flags)
    {
        rows = new ReadOnlyCollection<CoopSkillShotScore>(scores);
        knownFlags = flags;
    }

    public IReadOnlyList<CoopSkillShotScore> Rows => rows;

    public int PointsForConfirmedEnemyKill(CoopEnemyKillCredit credit,
        int comboFlag = 0)
    {
        // SkillShotController.GameEntityOnKilled emits these base flags for an
        // enemy death. Only a player-owned kill calls RecieveKill, so its combo
        // flag must come from the host's accepted kill history.
        if (comboFlag != 0 && (credit != CoopEnemyKillCredit.Player ||
            comboFlag is not (DoubleKillFlag or TripleKillFlag or MultiKillFlag)))
            throw new ArgumentOutOfRangeException(nameof(comboFlag));
        return credit switch
        {
            CoopEnemyKillCredit.Player => PointsForFlags(KillFlag | comboFlag),
            CoopEnemyKillCredit.AlliedArmy => PointsForFlags(AlliedArmyKillFlag),
            CoopEnemyKillCredit.UnownedBasicDamage =>
                PointsForFlags(KillFlag | EnvironmentalKillFlag),
            CoopEnemyKillCredit.UnownedExplosion =>
                PointsForFlags(KillFlag | EnvironmentalKillFlag | ExplosiveKillFlag),
            _ => throw new ArgumentOutOfRangeException(nameof(credit))
        };
    }

    public int PointsForFlags(int confirmedFlags)
    {
        if (confirmedFlags < 0 || (confirmedFlags & ~knownFlags) != 0)
            throw new ArgumentOutOfRangeException(nameof(confirmedFlags));

        int total = 0;
        foreach (CoopSkillShotScore row in rows)
        {
            if ((confirmedFlags & row.Flag) != 0)
                total = checked(total + row.MissionPoints);
        }
        return total;
    }

    public static CoopSkillShotScoreCatalog Load(string path, string sceneSha256,
        string battleContentSha256)
    {
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedSha256)
            throw new InvalidDataException("Co-op skill-shot scores differ from reviewed Client.");

        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("sceneSha256").GetString() != sceneSha256 ||
            root.GetProperty("battleContentSha256").GetString() != battleContentSha256 ||
            root.GetProperty("comboWindowSeconds").GetSingle() != 0.9f ||
            MatchManifest.TickRate != 30)
            throw new InvalidDataException("Co-op skill-shot scores use different source data.");

        JsonElement sourceRows = root.GetProperty("rows");
        if (sourceRows.GetArrayLength() != 19)
            throw new InvalidDataException("Incomplete co-op skill-shot scores.");

        var scores = new CoopSkillShotScore[19];
        int flags = 0;
        var names = new HashSet<string>(StringComparer.Ordinal);
        for (int index = 0; index < scores.Length; index++)
        {
            JsonElement source = sourceRows[index];
            int flag = source.GetProperty("flag").GetInt32();
            int points = source.GetProperty("missionPoints").GetInt32();
            string name = source.GetProperty("name").GetString() ?? "";
            string dictionaryId = source.GetProperty("dictionaryId").GetString() ?? "";
            if (flag <= 0 || (flag & (flag - 1)) != 0 || (flags & flag) != 0 ||
                points < 0 || points > 1_000_000 ||
                !names.Add(name) || name.Length is < 1 or > 40 ||
                name.Any(character => !char.IsAsciiLetter(character)) ||
                dictionaryId.Length is < 4 or > 80 ||
                dictionaryId.Any(character =>
                    !char.IsAsciiLetterUpper(character) && character != '_'))
                throw new InvalidDataException("Invalid co-op skill-shot row.");
            flags |= flag;
            scores[index] = new CoopSkillShotScore(flag, name, dictionaryId, points);
        }
        return new CoopSkillShotScoreCatalog(scores, flags);
    }
}
