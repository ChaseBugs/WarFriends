using System.Numerics;

namespace War.BattleServer;

internal sealed record CardRocketPlayerHit(CombatDamageType Kind, float RawDamage);

/// <summary>
/// The Rocket card uses Explosion.MissileExplode with the BazookaEnemy
/// prefab's 0.8/1.2 unit radii. Its damage comes from the card at launch.
/// </summary>
internal static class CardRocketExplosion
{
    private const float DeadRadius = .8f;
    private const float HurtRadius = 1.2f;

    internal static CardRocketPlayerHit? ResolvePlayer(Vector3 impact,
        PlayerCollisionModel pose, Vector3 playerRoot,
        ArmyCardRocketRuntime missile, bool shieldBetween)
    {
        if (!PlayerHitbox.Finite(impact) || !PlayerHitbox.Finite(playerRoot) ||
            pose == null || pose.Role != "gameplay" ||
            pose.PoseKind == "serialized-reference-only" || missile == null ||
            !float.IsFinite(missile.DirectDamage) || missile.DirectDamage < 0 ||
            !float.IsFinite(missile.ExplosionDamage) ||
            missile.ExplosionDamage < missile.DirectDamage ||
            !float.IsFinite(missile.PlayerBehindShieldRatio) ||
            missile.PlayerBehindShieldRatio is < 0 or > 1)
            throw new InvalidDataException("Rocket explosion needs valid launch and pose authority.");

        var closest = pose.Parts
            .Where(part => part.OverlapsSphere(impact, HurtRadius))
            .Select(part => new { Part = part,
                Distance = part.BoundsDistanceToPoint(impact) })
            .OrderBy(row => row.Distance)
            .ThenBy(row => row.Part.SourcePath, StringComparer.Ordinal)
            .FirstOrDefault();
        if (closest == null)
            return null;

        float multiplier = shieldBetween ? missile.PlayerBehindShieldRatio : 1f;
        if (closest.Distance < DeadRadius)
            return new CardRocketPlayerHit(CombatDamageType.Explosion,
                missile.ExplosionDamage * multiplier);

        // The collider chooses the victim, while the root transform sets the
        // falloff in the recovered client's Shiver branch.
        float rootDistance = Vector3.Distance(playerRoot, impact);
        float fraction = Math.Clamp(1f - (rootDistance - DeadRadius) /
            (HurtRadius - DeadRadius), 0f, 1f);
        float rawDamage = missile.DirectDamage +
            (missile.ExplosionDamage - missile.DirectDamage) * fraction * fraction;
        return new CardRocketPlayerHit(CombatDamageType.Shiver,
            rawDamage * multiplier);
    }
}
