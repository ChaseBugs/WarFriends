using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>
/// Primary and card Assaulters share one recovered MainScene rifle. This
/// binding supplies source identity and cadence, not projectile authority.
/// </summary>
internal sealed class CoopAssaulterWeaponCatalog
{
    private const string ArtifactSha256 =
        "72c7ff7191faaeb9eed2e310979b502adab852abc1adf7e05c0f19aee72ca30e";

    internal string WeaponPrefabGuid { get; }
    internal string BulletPrefabGuid { get; }
    internal int MuzzleTransformFileId { get; }
    internal Vector3 MuzzleRestPosition { get; }
    internal Vector3 ShotOffset { get; }
    internal float RealBulletSpeed { get; }
    internal float FakeBulletSpeed { get; }
    internal float CollisionCheckDistance { get; }
    internal float CadenceSeconds { get; }

    private CoopAssaulterWeaponCatalog(string weaponPrefabGuid,
        string bulletPrefabGuid, int muzzleTransformFileId,
        Vector3 muzzleRestPosition, Vector3 shotOffset,
        float realBulletSpeed,
        float fakeBulletSpeed, float collisionCheckDistance,
        float cadenceSeconds)
    {
        WeaponPrefabGuid = weaponPrefabGuid;
        BulletPrefabGuid = bulletPrefabGuid;
        MuzzleTransformFileId = muzzleTransformFileId;
        MuzzleRestPosition = muzzleRestPosition;
        ShotOffset = shotOffset;
        RealBulletSpeed = realBulletSpeed;
        FakeBulletSpeed = fakeBulletSpeed;
        CollisionCheckDistance = collisionCheckDistance;
        CadenceSeconds = cadenceSeconds;
    }

    internal static CoopAssaulterWeaponCatalog Load(string path,
        string expectedSceneSha256)
    {
        byte[] source = File.ReadAllBytes(path);
        if (source.Length is < 500 or > 5_000 ||
            Convert.ToHexStringLower(SHA256.HashData(source)) !=
                ArtifactSha256)
            throw new InvalidDataException(
                "Co-op Assaulter rifle artifact differs from recovered sources.");

        using JsonDocument document = JsonDocument.Parse(source);
        JsonElement row = document.RootElement;
        string[] fields =
        [
            "version", "unitId", "sceneSha256", "behaviourComponentFileId",
            "inventoryComponentFileId", "weaponPrefab", "weaponPrefabSha256",
            "weaponPrefabGuid", "weaponComponentFileId", "weaponType",
            "muzzleTransformFileId", "muzzle", "shotOffset",
            "bulletPrefabGuid",
            "bulletComponentFileId", "bulletPrefabSha256",
            "bulletSetupComponentFileId", "realBulletSpeed",
            "fakeBulletSpeed", "collisionCheckDistance",
            "cadenceSeconds", "infiniteAmmo", "reloadableWeapon",
            "soldierSourceSha256", "gunSourceSha256",
            "bulletBaseSourceSha256", "bulletSetupSourceSha256"
        ];
        if (row.ValueKind != JsonValueKind.Object ||
            row.EnumerateObject().Count() != fields.Length ||
            fields.Any(field => !row.TryGetProperty(field, out _)) ||
            row.GetProperty("version").GetInt32() != 1 ||
            row.GetProperty("unitId").GetString() != "ID_UNIT-ASSAULT" ||
            row.GetProperty("sceneSha256").GetString() !=
                expectedSceneSha256 ||
            row.GetProperty("behaviourComponentFileId").GetInt32() != 35664 ||
            row.GetProperty("inventoryComponentFileId").GetInt32() != 42740 ||
            row.GetProperty("weaponPrefab").GetString() !=
                "Assets/GameObject/AssaultRifleEnemy.prefab" ||
            row.GetProperty("weaponPrefabSha256").GetString() !=
                "a55f77d5fc32e948951805b01e13c9193cf852171ec842a2caa6ad3338239de2" ||
            row.GetProperty("weaponPrefabGuid").GetString() !=
                "d03f97fa25701ab42ab60f1fa86421ce" ||
            row.GetProperty("weaponComponentFileId").GetInt32() != 11470521 ||
            row.GetProperty("weaponType").GetInt32() != 0 ||
            row.GetProperty("muzzleTransformFileId").GetInt32() != 455190 ||
            row.GetProperty("bulletPrefabGuid").GetString() !=
                "855689762fa6e774aaee190652b08c6f" ||
            row.GetProperty("bulletComponentFileId").GetInt32() != 11409266 ||
            row.GetProperty("bulletPrefabSha256").GetString() !=
                "5379f6aba1560b8eb3d7d386d1349454b97ea133163ade9a313e2bc34d1adfae" ||
            row.GetProperty("bulletSetupComponentFileId").GetInt32() !=
                11496012 ||
            row.GetProperty("realBulletSpeed").GetSingle() != 5f ||
            row.GetProperty("fakeBulletSpeed").GetSingle() != 7.5f ||
            row.GetProperty("collisionCheckDistance").GetSingle() != 0.35f ||
            row.GetProperty("cadenceSeconds").GetSingle() != 0.35f ||
            row.GetProperty("infiniteAmmo").ValueKind != JsonValueKind.True ||
            row.GetProperty("reloadableWeapon").ValueKind != JsonValueKind.False ||
            row.GetProperty("soldierSourceSha256").GetString() !=
                "26568579f6b4e7994b5a2266009de3e5ccb42e41169546056f71ffe5acb7ae39" ||
            row.GetProperty("gunSourceSha256").GetString() !=
                "2a3c8d6f42707bb8253e6b9f5e5e6ff50068a872b2d33b387520fb2d83efe281" ||
            row.GetProperty("bulletBaseSourceSha256").GetString() !=
                "5c8cb92b8d53b577b4b765dc486d5b94d49cb2f8515dff72e4a8f7fbee5e7b6b" ||
            row.GetProperty("bulletSetupSourceSha256").GetString() !=
                "89aae8dce8b79a4defda00618b9db3fccb27dc369d3b438f57c0435d92d4870a")
            throw new InvalidDataException(
                "Co-op Assaulter rifle lost its source binding.");

        JsonElement muzzle = row.GetProperty("muzzle");
        if (muzzle.ValueKind != JsonValueKind.Object ||
            muzzle.EnumerateObject().Count() != 3 ||
            muzzle.GetProperty("path").GetString() !=
                "AssaultRifleEnemy/HK416/MachinegunMuzzleFlash")
            throw new InvalidDataException("Co-op Assaulter muzzle lost its path.");
        JsonElement position = muzzle.GetProperty("position");
        JsonElement rotation = muzzle.GetProperty("rotation");
        if (position.ValueKind != JsonValueKind.Array ||
            position.GetArrayLength() != 3 ||
            rotation.ValueKind != JsonValueKind.Array ||
            rotation.GetArrayLength() != 4)
            throw new InvalidDataException("Co-op Assaulter muzzle has invalid geometry.");
        var muzzlePosition = new Vector3(position[0].GetSingle(),
            position[1].GetSingle(), position[2].GetSingle());
        var muzzleRotation = new Quaternion(rotation[0].GetSingle(),
            rotation[1].GetSingle(), rotation[2].GetSingle(),
            rotation[3].GetSingle());
        if (!PlayerHitbox.Finite(muzzlePosition) ||
            Vector3.Distance(muzzlePosition,
                new Vector3(0, 0.045f, 0.17f)) > 0.0001f ||
            !float.IsFinite(muzzleRotation.LengthSquared()) ||
            MathF.Abs(muzzleRotation.LengthSquared() - 1f) > 0.0001f)
            throw new InvalidDataException("Co-op Assaulter muzzle differs from source.");
        JsonElement offset = row.GetProperty("shotOffset");
        if (offset.ValueKind != JsonValueKind.Array ||
            offset.GetArrayLength() != 3)
            throw new InvalidDataException("Co-op Assaulter shot offset is malformed.");
        var shotOffset = new Vector3(offset[0].GetSingle(),
            offset[1].GetSingle(), offset[2].GetSingle());
        if (!PlayerHitbox.Finite(shotOffset) || shotOffset != Vector3.Zero)
            throw new InvalidDataException(
                "Co-op Assaulter launch origin differs from source.");

        return new CoopAssaulterWeaponCatalog(
            row.GetProperty("weaponPrefabGuid").GetString()!,
            row.GetProperty("bulletPrefabGuid").GetString()!,
            row.GetProperty("muzzleTransformFileId").GetInt32(),
            muzzlePosition, shotOffset,
            row.GetProperty("realBulletSpeed").GetSingle(),
            row.GetProperty("fakeBulletSpeed").GetSingle(),
            row.GetProperty("collisionCheckDistance").GetSingle(),
            row.GetProperty("cadenceSeconds").GetSingle());
    }

    internal ulong NextRoundEligibleTick(ulong lastRoundTick)
    {
        // Gun.willShoot requires realTime > lastShotTime + cadence. At 30 Hz,
        // 0.35 seconds means eleven ticks after the previous round.
        ulong spacing = (ulong)Math.Floor(
            CadenceSeconds * MatchManifest.TickRate) + 1;
        return checked(lastRoundTick + spacing);
    }

    internal BulletFlightDefinition RealBulletFlight() =>
        new(RealBulletSpeed, CollisionCheckDistance, Fast: false);
}
