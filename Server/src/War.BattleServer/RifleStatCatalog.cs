using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

// Upgrade data only: prefab, muzzle, critical multiplier and projectile settings
// still require a scene binding. This is deliberately not a live weapon factory.
public sealed record RifleStage(string SourceId, int Index, int ClipSize, int ReserveAmmo,
    float ReloadSeconds, float Damage, float CadenceSeconds, float CriticalProbability,
    float PlayerDamageRatio, float OvertimePlayerDamageRatio);

public sealed class RifleStatCatalog
{
    private static readonly (string Name, int Count)[] Expected =
    [
        ("AssaultRifle_AK47",26), ("AssaultRifle_Famas",56), ("AssaultRifle_G36",76),
        ("AssaultRifle_M16",36), ("AssaultRifle_QBZ95",46), ("AssaultRifle_SteyrAUG",66),
        ("AssaultRifle_AKS47U",76), ("AssaultRifle_G36Elite",76), ("AssaultRifle_FamasElite",56),
        ("AssaultRifle_QBZ95Elite",46), ("AssaultRifle_AK47Elite",26)
    ];
    private readonly Dictionary<string, RifleStage[]> stages;
    public string Revision { get; }
    public string SceneRevision { get; }
    public int WeaponCount => stages.Count;
    public int StageCount => stages.Values.Sum(x => x.Length);
    private RifleStatCatalog(Dictionary<string, RifleStage[]> rows, string revision, string scene)
    { stages = rows; Revision = revision; SceneRevision = scene; }

    public RifleStage Get(string sourceId, int zeroBasedUpgrade)
    {
        if (sourceId == null || !stages.TryGetValue(sourceId, out var rows) ||
            zeroBasedUpgrade < 0 || zeroBasedUpgrade >= rows.Length)
            throw new InvalidDataException("Unsupported rifle or upgrade index.");
        return rows[zeroBasedUpgrade];
    }

    // Allocator input must resolve an owned upgrade index before calling this.
    // Never construct ammunition/cadence from the client's asserted numbers.
    public WeaponManifest CreateManifest(string sourceId, int zeroBasedUpgrade)
    {
        var row = Get(sourceId,zeroBasedUpgrade);
        return new(row.SourceId,row.ClipSize,row.ReserveAmmo,row.CadenceSeconds,row.ReloadSeconds);
    }

    public static RifleStatCatalog Load(string path, string expectedRevision, string expectedSceneRevision)
    {
        using var input = File.OpenRead(path);
        if (input.Length is < 2 or > 16_000_000) throw new InvalidDataException("Invalid rifle content size.");
        byte[] bytes = new byte[checked((int)input.Length)];
        input.ReadExactly(bytes);
        string revision = Convert.ToHexStringLower(SHA256.HashData(bytes));
        if (revision != expectedRevision) throw new InvalidDataException("Rifle content revision mismatch.");
        try
        {
            using var document = JsonDocument.Parse(bytes);
            var root = document.RootElement;
            if (root.GetProperty("client").GetString() != "1.4.0" ||
                root.GetProperty("mainSceneSha256").GetString() != expectedSceneRevision ||
                expectedSceneRevision == null || expectedSceneRevision.Length != 64 || expectedSceneRevision.Any(c => !char.IsAsciiHexDigitLower(c)))
                throw new InvalidDataException("Rifle scene provenance mismatch.");
            var sheets = new Dictionary<string, JsonElement>(StringComparer.Ordinal);
            foreach (var sheet in root.GetProperty("sheets").EnumerateArray())
                if (!sheets.TryAdd(sheet.GetProperty("type").GetString()!, sheet.GetProperty("rows")))
                    throw new InvalidDataException("Duplicate source sheet.");
            var definitions = new Dictionary<string, JsonElement>(StringComparer.Ordinal);
            foreach (var row in sheets["Google2u.WeaponUpgrades"].EnumerateArray())
                if (!definitions.TryAdd(row.GetProperty("NAME").GetString()!, row))
                    throw new InvalidDataException("Duplicate weapon definition.");
            if (definitions.Count != 66) throw new InvalidDataException("Incomplete weapon definitions.");
            var result = new Dictionary<string, RifleStage[]>(StringComparer.Ordinal);
            foreach (var (name, count) in Expected)
            {
                string id = "Google2u." + name;
                var definition = definitions[id];
                var rows = sheets[id];
                if (rows.GetArrayLength() != count) throw new InvalidDataException("Incomplete rifle upgrade lane.");
                var lane = new RifleStage[count];
                for (int i = 0; i < count; i++)
                {
                    var row = rows[i];
                    lane[i] = new(id, i, Integer(row,"CLIPSIZE",1,1000), Integer(row,"AMMO",0,100000),
                        Number(row,"RELOADTIME",0.01f,120), Number(row,"DAMAGE",0,1000000),
                        Number(definition,"RATEOFFIRE",0.01f,60), Number(definition,"CRITICAL",0,1),
                        Number(definition,"DAMAGETOPLAYER",0,100), Number(definition,"DAMAGETOPLAYEROVERTIME",0,100));
                }
                result.Add(id,lane);
            }
            return new(result,revision,expectedSceneRevision);
        }
        catch (Exception e) when (e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or OverflowException or ArgumentException)
        { throw new InvalidDataException("Malformed rifle source catalog.",e); }
    }

    private static float Number(JsonElement row, string key, float min, float max)
    {
        float value = row.GetProperty(key).GetSingle();
        if (!float.IsFinite(value) || value < min || value > max) throw new InvalidDataException("Invalid rifle " + key);
        return value;
    }
    private static int Integer(JsonElement row, string key, int min, int max)
    {
        if (!row.GetProperty(key).TryGetInt32(out int value) || value < min || value > max)
            throw new InvalidDataException("Invalid rifle " + key);
        return value;
    }
}
