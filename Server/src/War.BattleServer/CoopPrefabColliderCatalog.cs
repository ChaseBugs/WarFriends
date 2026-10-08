using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopBattlePrefab(
    string PoolField, string Guid, int PooledComponentFileId,
    string Source, string SourceSha256,
    IReadOnlyList<CoopSceneCollider> Colliders, int WheelColliderCount);

public sealed record CoopNetworkPoolEntry(
    string Name, string PrefabField, string Guid, int PooledComponentFileId);

/// <summary>
/// Local collider shapes on the battle prefabs referenced by MainScene's
/// direct and network pools. A spawn, pose, and runtime enablement state must
/// place these shapes before they can participate in a shot.
/// </summary>
public sealed class CoopPrefabColliderCatalog
{
    private const string ArtifactSha256 =
        "4ab361718d06ca8c0ecd9d0bb1553ef4b2d3e1e1a22539f7cdcfc35e6d3bda70";
    private const string MainSceneSha256 =
        "d46f81ff8c3e12bf17f34a1f53dd601bd799102c9f984818031441dfb7a5de43";
    private static readonly (string Field, int Count)[] Expected =
    [
        ("enemy", 7), ("drone", 2), ("humvee", 9), ("buggy", 9),
        ("transporter", 13), ("helicopter", 11), ("tank", 13),
        ("turret", 4), ("turretRockets", 4), ("mech", 5),
        ("heavyTurret", 3), ("assaultHelicopter", 11), ("decoy", 1),
        ("miniDrone", 2), ("player", 15), ("shootableBox", 2),
        ("parachute", 2),
        ("network:GrenadeAmmoEnemy", 1), ("network:MineAmmo", 2),
        ("network:KillStreakBonusBox", 1), ("network:Missile", 0),
        ("network:AssaultRifleEnemy", 1), ("network:BazookaEnemy", 1),
        ("network:ShotgunEnemy", 1), ("network:SniperRifleEnemy", 1),
        ("network:SwatPistolEnemy", 1), ("network:GrenadeEnemy", 1),
        ("network:MiniGun", 1), ("network:PistolEnemy", 1),
        ("network:GrenadeLauncherEnemy", 1),
        ("network:MortarEnemy", 1), ("network:FlamethrowerEnemy", 1)
    ];
    private static readonly string[] ExpectedNetworkNames =
    [
        "enemy", "dronePrototype", "GrenadeAmmoEnemy", "Humvee",
        "PlayerPrefab", "MineAmmo", "KillStreakBonusBox", "Turret",
        "parachute", "Helicopter", "Missile", "AssaultRifleEnemy",
        "BazookaEnemy", "ShotgunEnemy", "SniperRifleEnemy",
        "SwatPistolEnemy", "GrenadeEnemy", "Tank", "MiniGun",
        "assaultHelicopter", "PistolEnemy", "GrenadeLauncherEnemy",
        "Buggy", "Transporter", "TurretRockets", "HeavyTurret",
        "Decoy", "miniDrone", "MortarEnemy", "FlamethrowerEnemy", "Mech"
    ];

    public IReadOnlyList<CoopBattlePrefab> Prefabs { get; }
    public IReadOnlyList<CoopNetworkPoolEntry> NetworkEntries { get; }

    private CoopPrefabColliderCatalog(
        CoopBattlePrefab[] prefabs, CoopNetworkPoolEntry[] networkEntries)
    {
        Prefabs = new ReadOnlyCollection<CoopBattlePrefab>(prefabs);
        NetworkEntries = new ReadOnlyCollection<CoopNetworkPoolEntry>(networkEntries);
    }

    public CoopBattlePrefab ForPoolField(string field)
    {
        return Prefabs.SingleOrDefault(prefab => prefab.PoolField == field)
            ?? throw new InvalidDataException("Unknown battle prefab pool field.");
    }

    public static CoopPrefabColliderCatalog Load(string path)
    {
        byte[] source = File.ReadAllBytes(path);
        if (Convert.ToHexStringLower(SHA256.HashData(source)) != ArtifactSha256)
            throw new InvalidDataException("Battle prefab colliders differ from source.");

        using JsonDocument document = JsonDocument.Parse(source);
        JsonElement root = document.RootElement;
        RequireFields(root, "version", "mainSceneSha256", "prefabs",
            "networkEntries");
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("mainSceneSha256").GetString() != MainSceneSha256)
            throw new InvalidDataException("Battle prefab source scene changed.");
        JsonElement rows = root.GetProperty("prefabs");
        if (rows.ValueKind != JsonValueKind.Array ||
            rows.GetArrayLength() != Expected.Length)
            throw new InvalidDataException("Battle prefab set is incomplete.");

        var prefabs = new CoopBattlePrefab[Expected.Length];
        var seenGuids = new HashSet<string>(StringComparer.Ordinal);
        int meshCount = 0;
        int boxCount = 0;
        int capsuleCount = 0;
        int sphereCount = 0;
        int wheelCount = 0;
        for (int index = 0; index < prefabs.Length; index++)
        {
            prefabs[index] = ReadPrefab(rows[index], Expected[index]);
            if (!seenGuids.Add(prefabs[index].Guid))
                throw new InvalidDataException("Battle prefab GUID is duplicated.");
            wheelCount += prefabs[index].WheelColliderCount;
            foreach (CoopSceneCollider collider in prefabs[index].Colliders)
            {
                switch (collider.ComponentType)
                {
                    case "MeshCollider": meshCount++; break;
                    case "BoxCollider": boxCount++; break;
                    case "CapsuleCollider": capsuleCount++; break;
                    case "SphereCollider": sphereCount++; break;
                }
            }
        }
        if (meshCount != 8 || boxCount != 78 || capsuleCount != 31 ||
            sphereCount != 11 || wheelCount != 14)
            throw new InvalidDataException("Battle prefab collider shapes changed.");
        CoopNetworkPoolEntry[] networkEntries = ReadNetworkEntries(
            root.GetProperty("networkEntries"), prefabs);
        return new CoopPrefabColliderCatalog(prefabs, networkEntries);
    }

    private static CoopNetworkPoolEntry[] ReadNetworkEntries(
        JsonElement rows, CoopBattlePrefab[] prefabs)
    {
        if (rows.ValueKind != JsonValueKind.Array ||
            rows.GetArrayLength() != ExpectedNetworkNames.Length)
            throw new InvalidDataException("Network prefab pool is incomplete.");
        var result = new CoopNetworkPoolEntry[ExpectedNetworkNames.Length];
        var seenGuids = new HashSet<string>(StringComparer.Ordinal);
        for (int index = 0; index < result.Length; index++)
        {
            JsonElement row = rows[index];
            RequireFields(row, "name", "guid", "pooledComponentFileId",
                "prefabField");
            string name = row.GetProperty("name").GetString() ?? "";
            string field = row.GetProperty("prefabField").GetString() ?? "";
            string guid = row.GetProperty("guid").GetString() ?? "";
            int componentId = row.GetProperty("pooledComponentFileId").GetInt32();
            CoopBattlePrefab? prefab = prefabs.SingleOrDefault(candidate =>
                candidate.PoolField == field);
            if (name != ExpectedNetworkNames[index] || prefab == null ||
                guid != prefab.Guid || componentId != prefab.PooledComponentFileId ||
                !seenGuids.Add(guid))
                throw new InvalidDataException("Network prefab identity changed.");
            result[index] = new CoopNetworkPoolEntry(name, field, guid,
                componentId);
        }
        return result;
    }

    private static CoopBattlePrefab ReadPrefab(
        JsonElement row, (string Field, int Count) expected)
    {
        RequireFields(row, "poolField", "guid", "pooledComponentFileId",
            "source", "sourceSha256", "colliders", "wheelColliderCount");
        string field = row.GetProperty("poolField").GetString() ?? "";
        string guid = row.GetProperty("guid").GetString() ?? "";
        string source = row.GetProperty("source").GetString() ?? "";
        string digest = row.GetProperty("sourceSha256").GetString() ?? "";
        int componentId = row.GetProperty("pooledComponentFileId").GetInt32();
        int wheelCount = row.GetProperty("wheelColliderCount").GetInt32();
        int expectedWheels = expected.Field switch
        {
            "humvee" or "buggy" => 4,
            "transporter" => 6,
            _ => 0
        };
        JsonElement colliderRows = row.GetProperty("colliders");
        if (field != expected.Field || !IsLowerHex(guid, 32) ||
            componentId <= 0 || !source.StartsWith("Assets/GameObject/",
                StringComparison.Ordinal) ||
            !source.EndsWith(".prefab", StringComparison.Ordinal) ||
            source.Contains("..", StringComparison.Ordinal) ||
            !IsLowerHex(digest, 64) ||
            colliderRows.ValueKind != JsonValueKind.Array ||
            colliderRows.GetArrayLength() != expected.Count ||
            wheelCount != expectedWheels)
            throw new InvalidDataException("Battle prefab source identity changed.");

        var colliders = new CoopSceneCollider[expected.Count];
        int previousId = 0;
        for (int index = 0; index < colliders.Length; index++)
        {
            colliders[index] = CoopSceneColliderCatalog.ReadCollider(
                colliderRows[index]);
            if (colliders[index].ComponentFileId <= previousId)
                throw new InvalidDataException("Battle prefab colliders are unordered.");
            previousId = colliders[index].ComponentFileId;
        }
        return new CoopBattlePrefab(field, guid, componentId, source, digest,
            new ReadOnlyCollection<CoopSceneCollider>(colliders), wheelCount);
    }

    private static bool IsLowerHex(string value, int length)
    {
        return value.Length == length && value.All(character =>
            character is >= '0' and <= '9' or >= 'a' and <= 'f');
    }

    private static void RequireFields(JsonElement row, params string[] fields)
    {
        if (row.ValueKind != JsonValueKind.Object)
            throw new InvalidDataException("Battle prefab record must be an object.");
        var required = new HashSet<string>(fields, StringComparer.Ordinal);
        foreach (JsonProperty property in row.EnumerateObject())
        {
            if (!required.Remove(property.Name))
                throw new InvalidDataException("Battle prefab has an extra field.");
        }
        if (required.Count != 0)
            throw new InvalidDataException("Battle prefab is missing a field.");
    }
}
