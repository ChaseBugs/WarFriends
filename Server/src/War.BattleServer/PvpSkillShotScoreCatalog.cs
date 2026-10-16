using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record PvpSkillShotScore(int Flag, string Name,
    string DictionaryId, int MultiplayerPoints);

/// <summary>Immutable source score rows. Call only with host-confirmed flags.</summary>
public sealed class PvpSkillShotScoreCatalog
{
    private const string ReviewedSha256 =
        "7358effb84b956ee67b29cb4faa48e80703af73e48d4c9651494b97c5f2fcbc4";
    private const float ReviewedLongShotDistance = 6f;
    private static readonly int[] SourceFlags =
        [1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 2048, 4096,
         65536, 131072, 8192, 262144, 32768, 16384, 524288];
    private readonly int knownFlags;
    public IReadOnlyList<PvpSkillShotScore> Rows { get; }
    public float ComboWindowSeconds => 0.9f;
    /// <summary>Reviewed MainScene distance for the source LongShot flag.</summary>
    public float LongShotDistance => ReviewedLongShotDistance;

    private PvpSkillShotScoreCatalog(PvpSkillShotScore[] rows)
    {
        Rows = new ReadOnlyCollection<PvpSkillShotScore>(rows);
        foreach (var row in rows) knownFlags |= row.Flag;
    }

    public int PointsForConfirmedFlags(int flags)
    {
        if (flags < 0 || (flags & ~knownFlags) != 0)
            throw new ArgumentOutOfRangeException(nameof(flags));
        int total = 0;
        foreach (var row in Rows)
            if ((flags & row.Flag) == row.Flag)
                total = checked(total + row.MultiplayerPoints);
        return total;
    }

    public static PvpSkillShotScoreCatalog Load(string path,
        string sceneSha256, string battleContentSha256)
    {
        byte[] bytes = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedSha256)
            throw new InvalidDataException("PvP scores differ from the reviewed Client artifact.");
        using var document = JsonDocument.Parse(bytes);
        var root = document.RootElement;
        RequireFields(root, "version", "sceneSha256", "battleContentSha256",
            "sheetCodeSha256", "skillCodeSha256", "comboWindowSeconds", "longShotDistance", "rows");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("sceneSha256").GetString() != sceneSha256 ||
            root.GetProperty("battleContentSha256").GetString() != battleContentSha256 ||
            root.GetProperty("comboWindowSeconds").GetSingle() != 0.9f ||
            root.GetProperty("longShotDistance").GetSingle() != ReviewedLongShotDistance)
            throw new InvalidDataException("PvP scores use different source provenance.");
        var source = root.GetProperty("rows");
        if (source.GetArrayLength() != SourceFlags.Length)
            throw new InvalidDataException("Incomplete PvP skill-shot rows.");
        var rows = new PvpSkillShotScore[SourceFlags.Length];
        var names = new HashSet<string>(StringComparer.Ordinal);
        var dictionaryIds = new HashSet<string>(StringComparer.Ordinal);
        for (int index = 0; index < rows.Length; index++)
        {
            var item = source[index];
            RequireFields(item, "flag", "name", "dictionaryId", "multiplayerPoints");
            int flag = item.GetProperty("flag").GetInt32();
            string name = item.GetProperty("name").GetString() ?? "";
            string dictionaryId = item.GetProperty("dictionaryId").GetString() ?? "";
            int points = item.GetProperty("multiplayerPoints").GetInt32();
            if (flag != SourceFlags[index] || name.Length is < 1 or > 32 ||
                name.Any(character => !char.IsAsciiLetter(character)) || !names.Add(name) ||
                !dictionaryId.StartsWith("ID_SKILL_", StringComparison.Ordinal) ||
                dictionaryId.Length > 64 || !dictionaryIds.Add(dictionaryId) ||
                points is < 0 or > 1_000_000)
                throw new InvalidDataException("Invalid PvP skill-shot score row.");
            rows[index] = new PvpSkillShotScore(flag, name, dictionaryId, points);
        }
        return new PvpSkillShotScoreCatalog(rows);
    }

    private static void RequireFields(JsonElement item, params string[] expected)
    {
        if (item.ValueKind != JsonValueKind.Object)
            throw new InvalidDataException("Score authority must be an object.");
        var names = item.EnumerateObject().Select(field => field.Name).ToArray();
        if (names.Length != expected.Length ||
            !names.ToHashSet(StringComparer.Ordinal).SetEquals(expected))
            throw new InvalidDataException("Score authority has unexpected fields.");
    }
}
