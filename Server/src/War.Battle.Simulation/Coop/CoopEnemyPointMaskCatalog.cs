using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Serialized starting masks from MainScene, bound to the army catalog.</summary>
public sealed class CoopEnemyPointMaskCatalog
{
    private const string ArtifactSha256 =
        "af006a1b961d38addc05ca60e90aa63b881467145c7e88fe35e9afb481eb853b";

    public IReadOnlyList<CoopSoldierPointMask> Soldiers { get; }

    private CoopEnemyPointMaskCatalog(CoopSoldierPointMask[] soldiers)
    {
        Soldiers = Array.AsReadOnly(soldiers);
    }

    public static CoopEnemyPointMaskCatalog Load(string path, ArmyDeploymentCatalog army)
    {
        ArgumentNullException.ThrowIfNull(army);
        byte[] source = File.ReadAllBytes(path);
        if (source.Length is < 1_000 or > 10_000 ||
            Convert.ToHexStringLower(SHA256.HashData(source)) != ArtifactSha256)
            throw new InvalidDataException("Co-op soldier masks differ from MainScene.");

        using JsonDocument document = JsonDocument.Parse(source);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "sceneSha256", "soldiers");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("sceneSha256").GetString() !=
                "d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43")
            throw new InvalidDataException("Co-op soldier mask source changed.");

        JsonElement rows = root.GetProperty("soldiers");
        ArmyDeploymentFamily[] soldierFamilies = army.Families
            .Where(family => family.IsSoldier).ToArray();
        if (rows.ValueKind != JsonValueKind.Array ||
            rows.GetArrayLength() != 16 || soldierFamilies.Length != 16)
            throw new InvalidDataException("Co-op soldier mask inventory changed.");

        var soldiers = new CoopSoldierPointMask[16];
        for (int index = 0; index < soldiers.Length; index++)
        {
            JsonElement row = rows[index];
            ArmyDeploymentFamily family = soldierFamilies[index];
            bool sniper = family.BehaviorType == "SoldierBehaviourSniper";
            if (sniper)
                RequireFields(row, "behaviorFileId", "behaviorType", "unitId",
                    "enemyPointMask", "minimumPlayerDistance");
            else
                RequireFields(row, "behaviorFileId", "behaviorType", "unitId",
                    "enemyPointMask");
            int mask = row.GetProperty("enemyPointMask").GetInt32();
            float? minimumDistance = sniper
                ? row.GetProperty("minimumPlayerDistance").GetSingle() : null;
            if (row.GetProperty("behaviorFileId").GetInt32() != family.BehaviorFileId ||
                row.GetProperty("behaviorType").GetString() != family.BehaviorType ||
                row.GetProperty("unitId").GetString() != family.UnitId ||
                mask is <= 0 or > 0x3FFF ||
                (sniper && minimumDistance != 6f))
                throw new InvalidDataException("Co-op soldier mask is not bound to its unit.");
            soldiers[index] = new CoopSoldierPointMask(family.BehaviorFileId,
                family.BehaviorType, family.UnitId, mask,
                minimumDistance);
        }
        return new CoopEnemyPointMaskCatalog(soldiers);
    }

    private static void RequireFields(JsonElement row, params string[] names)
    {
        if (row.ValueKind != JsonValueKind.Object ||
            row.EnumerateObject().Count() != names.Length ||
            names.Any(name => !row.TryGetProperty(name, out _)))
            throw new InvalidDataException("Co-op soldier mask has unexpected fields.");
    }
}
