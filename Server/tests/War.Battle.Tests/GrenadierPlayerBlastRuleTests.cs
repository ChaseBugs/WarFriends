using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks native overlap ordering and the recovered one-percent shield attenuation boundary.</summary>
internal static class GrenadierPlayerBlastRuleTests
{
    private const string NativeRevision = "7262cef2a0d05ac35ea1fedd08cce387cf644a8f48767f0715c0a3a260dc761a";
    private const float GeometryTolerance = 0.00001f;
    private const float AboveProtectionRatio = 0.0101f;
    private const float BelowProtectionRatio = 0.0099f;

    internal static int Run(BattleCombatContent content, string directory)
    {
        int checks = CheckNativeGeometry(directory);
        checks += CheckShieldProtection(content);
        return checks;
    }

    private static int CheckNativeGeometry(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "grenadier-explosion-overlap-unity-reference.json"));
        int checks = Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == NativeRevision,
            "The native overlap/bounds evidence changed.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement evidence = document.RootElement;
        var position = new Vector3(0.8f, 0f, 0.8f);
        var box = new PlayerHitbox("boundary/box", PlayerHitboxKind.Box, 1, Vector3.Zero,
            new Vector3(2f, 0.1f, 0.1f), Quaternion.CreateFromAxisAngle(Vector3.UnitY, MathF.PI / 4),
            0, Vector3.Zero, 0);
        var unusedPart = new PlayerHitbox("boundary/sphere", PlayerHitboxKind.Sphere, 1,
            new Vector3(10f, 0f, 0f), Vector3.Zero, Quaternion.Identity, 0.1f, Vector3.Zero, 0);
        PlayerCollisionModel pose = PlayerCollisionModel.InitializedFrame(new string('a', 64), "boundary",
            Vector3.Zero, Quaternion.Identity, [box, unusedPart]);
        var setup = new ArmyCardGrenadierRuntime(3f, 45f, 0f, 0.9f, 1.2f, 0.5f, 0.4f);
        var damage = new ArmyGrenadeDamageStats(10f, 100f);
        checks += Require(box.OverlapsSphere(position, setup.OuterRadius) &&
            !box.OverlapsSphere(position, setup.OuterRadius * 0.7f) &&
            Math.Abs(box.BoundsDistanceToPoint(position) - evidence.GetProperty("boundsDistance").GetSingle()) <
                GeometryTolerance, "Host rotated-box overlap and bounds inputs differ from actual Unity queries.");
        checks += Require(CardGrenadierExplosionDamage.ResolvePlayer(position, pose, Vector3.Zero,
            damage, setup, false) is { Kind: CombatDamageType.Explosion, RawDamage: 100f },
            "Full-radius collection must preserve the source candidate before the scaled bounds-distance gate.");
        checks += Require(CardGrenadierExplosionDamage.ResolvePlayer(position, pose, Vector3.Zero,
            damage, setup, true) is { RawDamage: 50f }, "A valid shield must attenuate the selected player blast.");
        var outsideGate = new Vector3(0f, 0f, 1.65f);
        checks += Require(box.OverlapsSphere(outsideGate, setup.OuterRadius) &&
            Math.Abs(box.BoundsDistanceToPoint(outsideGate) -
                evidence.GetProperty("outsideBoundsDistance").GetSingle()) < GeometryTolerance &&
            CardGrenadierExplosionDamage.ResolvePlayer(outsideGate, pose, Vector3.Zero, damage, setup, false) == null,
            "A full-radius candidate outside the scaled player bounds gate must receive no damage.");
        return checks;
    }

    private static int CheckShieldProtection(BattleCombatContent content)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        WeaponManifest weapon = content.Stats.CreateManifest("Google2u.AssaultRifle_AK47", 0);
        var manifest = new MatchManifest("shield-protection-rule", "component", "Park_Multiplayer",
            map.SourceHash, content.Revision, MatchManifest.RifleCombatMode, 10, 120, 120,
            [new ParticipantManifest(new string('a', 32), weapon, 1, ShieldLevel: 0),
             new ParticipantManifest(new string('b', 32), weapon, 2, ShieldLevel: 0)]);
        var shields = new ShieldMatchSimulation(map, content.Shields, manifest);
        CoverNode cover = map.Covers.First(candidate => candidate.Fraction == 2 && candidate.Main);
        string owner = cover.SourcePath + "/riot_shield";
        int checks = Require(shields.HasExplosionProtection(owner), "A full source shield lost explosion attenuation.");
        ReduceToRatio(shields, owner, (cover.SourceIndex, AboveProtectionRatio), content.Shields);
        checks += Require(shields.HasExplosionProtection(owner), "A shield above one percent must protect players.");
        ReduceToRatio(shields, owner, (cover.SourceIndex, BelowProtectionRatio), content.Shields);
        checks += Require(shields.IsLiveShield(owner) && shields.ColliderEnabled(owner) &&
            !shields.HasExplosionProtection(owner),
            "A live shield below one percent must remain collidable without reducing player blast damage.");
        float maximum = shields.Snapshot().Single(shield => shield.CoverIndex == cover.SourceIndex).MaxHealth;
        _ = shields.ApplyUnitExplosion(owner, 1, maximum, 0);
        checks += Require(!shields.IsLiveShield(owner) && !shields.HasExplosionProtection(owner),
            "A destroyed shield cannot reduce player explosion damage.");
        return checks;
    }

    private static void ReduceToRatio(ShieldMatchSimulation shields, string owner,
        (int CoverIndex, float Ratio) target, ShieldSourceCatalog policy)
    {
        (int coverIndex, float ratio) = target;
        ShieldMutation current = shields.Snapshot().Single(shield => shield.CoverIndex == coverIndex);
        float targetHealth = current.MaxHealth * ratio;
        float sourceDamage = (current.Health - targetHealth) /
            (policy.ExplosionCoefficient * policy.UnitToShieldCoefficient);
        _ = shields.ApplyUnitExplosion(owner, 1, sourceDamage, 0);
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }
}
