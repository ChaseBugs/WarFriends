using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private void ApplyCardGrenadierExplosion(CardGrenadierExplosion explosion,
        CardGrenadierLaunchAuthority launch)
    {
        if (rifleCombat == null || damageRoll == null)
            throw new InvalidDataException(
                "Card Grenadier has no host damage authority.");
        Player attacker = Find(launch.OwnerPlayerId) ??
            throw new InvalidDataException(
                "Card Grenadier owner left the match.");

        bool shieldNearby = ApplyCardGrenadierMapDamage(explosion, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;
        ApplyCardGrenadierArmyDamage(explosion, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;

        foreach (Player victim in players.Where(player => !player.Dead)
                     .ToArray())
        {
            var pose = rifleCombat.Pose(victim.Definition.PlayerId).Collision;
            CardGrenadierBlastHit? hit =
                CardGrenadierExplosionDamage.ResolvePlayer(
                    explosion.Position, pose, victim.Position,
                    launch.Damage, launch.Setup, shieldNearby);
            if (hit == null)
                continue;
            bool enemy = attacker.Definition.Fraction !=
                victim.Definition.Fraction;
            var damage = new ResolvedPlayerDamage(hit.RawDamage,
                hit.Kind, HasWeapon: true, FriendKill: false,
                PlayerCoefficient: launch.PlayerPolicy.PlayerDamageRatio,
                PlayerOvertimeCoefficient:
                    launch.PlayerPolicy.OvertimePlayerDamageRatio,
                Overtime: overtime);
            ApplyResolvedPlayerDamage(launch.OwnerPlayerId,
                victim.Definition.PlayerId, damage, damageRoll(), enemy);
            if (Terminal)
                return;
        }
    }

    private bool ApplyCardGrenadierMapDamage(
        CardGrenadierExplosion explosion,
        CardGrenadierLaunchAuthority launch, int attackerFraction)
    {
        if (map == null)
            return false;
        Func<int, bool>? enabled = barrels == null ? null :
            index => barrels.ColliderEnabled(index);
        Func<int, int, int>? layer = barrels == null ? null :
            (index, source) => barrels.RuntimeLayer(index, source);
        var overlaps = map.DynamicSphereOverlaps(explosion.Position,
            launch.Setup.OuterRadius, uint.MaxValue, enabled, layer);
        var closest = CardRocketExplosion.ClosestColliders(
            explosion.Position, overlaps);
        bool shieldNearby = shields != null && closest.Any(collider =>
            shields.IsLiveShield(collider.DynamicOwner));

        foreach (var collider in closest)
        {
            float closestDistance = Vector3.Distance(explosion.Position,
                Vector3.Clamp(explosion.Position,
                    collider.BoundsMin, collider.BoundsMax));
            CardGrenadierBlastHit? hit =
                CardGrenadierExplosionDamage.ResolveDynamic(
                    explosion.Position, closestDistance,
                    collider.TransformPosition, launch.Damage,
                    launch.Setup);
            if (hit == null)
                continue;
            if (shields != null &&
                shields.IsLiveShield(collider.DynamicOwner))
            {
                var shield = shields.ApplyUnitExplosion(
                    collider.DynamicOwner, attackerFraction,
                    hit.RawDamage, tick);
                if (shield != null)
                {
                    stateRevision++;
                    EmitShield(shield.Destroyed ?
                        MatchEventKind.ShieldDestroyed :
                        MatchEventKind.ShieldDamaged,
                        launch.OwnerPlayerId, shield,
                        explosion.ProjectileId);
                }
            }
            else if (barrels?.Contains(collider.ColliderIndex) == true)
            {
                ApplyBarrelDamage(launch.OwnerPlayerId,
                    explosion.ProjectileId, collider.ColliderIndex,
                    hit.RawDamage, hit.Kind ==
                    CombatDamageType.Explosion ?
                        BarrelChainCause.Explosion :
                        BarrelChainCause.Shiver);
                if (Terminal)
                    return shieldNearby;
            }
        }
        return shieldNearby;
    }

    private void ApplyCardGrenadierArmyDamage(
        CardGrenadierExplosion explosion,
        CardGrenadierLaunchAuthority launch, int attackerFraction)
    {
        var targets = GroundVehicleShotTargets(
                launch.OwnerPlayerId, true)
            .Where(target => target.ArmyInfantry || target.DroneRoot ||
                target.HelicopterBody)
            .GroupBy(target => target.EntityId)
            .OrderBy(group => group.Key);
        foreach (var group in targets)
        {
            if (!activeArmyEntities.TryGetValue(group.Key, out var army))
                throw new InvalidDataException(
                    "Card Grenadier blast lost its army target.");
            bool infantry = infantryAnimations.ContainsKey(group.Key) &&
                group.All(target => target.ArmyInfantry);
            bool drone = army.UnitId == "ID_UNIT-DRONE" &&
                group.All(target => target.DroneRoot);
            bool helicopter = army.UnitId is
                ("ID_UNIT-HELICOPTER" or "ID_UNIT-ASSAULTHELI") &&
                group.All(target => target.HelicopterBody);
            if (!infantry && !drone && !helicopter)
                throw new InvalidDataException(
                    "Card Grenadier blast has mismatched hitboxes.");
            if (army.OwnerFraction == attackerFraction)
                continue;

            var nearest = group.Select(target => target.Hitbox)
                .Where(hitbox => hitbox.OverlapsSphere(
                    explosion.Position, launch.Setup.OuterRadius))
                .OrderBy(hitbox => hitbox.BoundsDistanceToPoint(
                    explosion.Position))
                .ThenBy(hitbox => hitbox.SourcePath,
                    StringComparer.Ordinal)
                .FirstOrDefault();
            if (nearest == null)
                continue;
            Vector3 root = new(army.X, army.Y, army.Z);
            CardGrenadierBlastHit? hit =
                CardGrenadierExplosionDamage.ResolveDynamic(
                    explosion.Position,
                    nearest.BoundsDistanceToPoint(explosion.Position),
                    root, launch.Damage, launch.Setup);
            if (hit == null)
                continue;
            ApplyArmyHostDamage(group.Key, hit.RawDamage);
            if (Terminal)
                return;
        }
    }
}
