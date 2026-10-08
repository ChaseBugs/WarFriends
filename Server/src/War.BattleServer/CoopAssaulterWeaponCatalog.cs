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
        "a46c788867d3f0c2bae1fbf33aba4f1d73c73da100dbace0dfcef53976037b09";

    internal string WeaponPrefabGuid { get; }
    internal string BulletPrefabGuid { get; }
    internal int MuzzleTransformFileId { get; }
    internal float CadenceSeconds { get; }

    private CoopAssaulterWeaponCatalog(string weaponPrefabGuid,
        string bulletPrefabGuid, int muzzleTransformFileId,
        float cadenceSeconds)
    {
        WeaponPrefabGuid = weaponPrefabGuid;
        BulletPrefabGuid = bulletPrefabGuid;
        MuzzleTransformFileId = muzzleTransformFileId;
        CadenceSeconds = cadenceSeconds;
    }

    internal static CoopAssaulterWeaponCatalog Load(string path,
        string expectedSceneSha256)
    {
        byte[] source = File.ReadAllBytes(path);
        if (source.Length is < 500 or > 4_000 ||
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
            "muzzleTransformFileId", "bulletPrefabGuid",
            "bulletComponentFileId", "cadenceSeconds", "infiniteAmmo",
            "reloadableWeapon", "soldierSourceSha256", "gunSourceSha256"
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
            row.GetProperty("cadenceSeconds").GetSingle() != 0.35f ||
            row.GetProperty("infiniteAmmo").ValueKind != JsonValueKind.True ||
            row.GetProperty("reloadableWeapon").ValueKind != JsonValueKind.False ||
            row.GetProperty("soldierSourceSha256").GetString() !=
                "26568579f6b4e7994b5a2266009de3e5ccb42e41169546056f71ffe5acb7ae39" ||
            row.GetProperty("gunSourceSha256").GetString() !=
                "2a3c8d6f42707bb8253e6b9f5e5e6ff50068a872b2d33b387520fb2d83efe281")
            throw new InvalidDataException(
                "Co-op Assaulter rifle lost its source binding.");

        return new CoopAssaulterWeaponCatalog(
            row.GetProperty("weaponPrefabGuid").GetString()!,
            row.GetProperty("bulletPrefabGuid").GetString()!,
            row.GetProperty("muzzleTransformFileId").GetInt32(),
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
}
