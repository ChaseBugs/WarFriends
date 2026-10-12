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
        ApplyCardGrenadierDecoyDamage(explosion, launch,
            attacker.Definition.Fraction, attacker);
        if (Terminal)
            return;
        ApplyCardGrenadierHeavyTurretDamage(explosion, launch,
            attacker.Definition.Fraction, attacker);
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

            Vector3 root = new(army.X, army.Y, army.Z);
            CardGrenadierBlastHit? hit =
                CardGrenadierExplosionDamage.ResolveArmy(
                    explosion.Position, root,
                    group.Select(target => target.Hitbox).ToArray(),
                    launch.Damage, launch.Setup);
            if (hit == null)
                continue;
            ApplyArmyHostDamage(group.Key, hit.RawDamage);
            if (Terminal)
                return;
        }
    }

    private void ApplyCardGrenadierDecoyDamage(
        CardGrenadierExplosion explosion,
        CardGrenadierLaunchAuthority launch, int attackerFraction,
        Player attacker)
    {
        if (decoySource == null)
            return;
        foreach (var collider in DecoyShotTargets(attacker,
                     includeFriendly: true))
        {
            var target = decoys.Snapshot().SingleOrDefault(value =>
                value.EntityId == collider.EntityId) ??
                throw new InvalidDataException(
                    "Card Grenadier Decoy lost host health.");
            if (target.OwnerFraction == attackerFraction)
                continue;
            CardGrenadierBlastHit? hit =
                CardGrenadierExplosionDamage.ResolveArmy(
                    explosion.Position, target.Position,
                    [collider.Hitbox], launch.Damage, launch.Setup);
            if (hit == null)
                continue;
            if (!decoys.TryDamage(target.EntityId, hit.RawDamage,
                    out var before, out bool destroyed) || before == null)
                throw new InvalidDataException(
                    "Card Grenadier Decoy damage escaped host bounds.");
            stateRevision++;
            if (destroyed)
            {
                droneTargets.Disable(DroneDecoyId(target.EntityId));
                Emit(MatchEventKind.DecoyDestroyed,
                    launch.OwnerPlayerId, before.OwnerPlayerId,
                    target.EntityId, before.Position, 0,
                    "card-grenadier");
            }
        }
    }

    private void ApplyCardGrenadierHeavyTurretDamage(
        CardGrenadierExplosion explosion,
        CardGrenadierLaunchAuthority launch, int attackerFraction,
        Player attacker)
    {
        if (heavyTurretSource == null)
            return;
        var colliders = HeavyTurretShotTargets(attacker,
            includeFriendly: true);
        foreach (var group in colliders.GroupBy(value => value.EntityId)
                     .OrderBy(group => group.Key))
        {
            var target = heavyTurrets.Snapshot().SingleOrDefault(value =>
                value.EntityId == group.Key) ??
                throw new InvalidDataException(
                    "Card Grenadier turret lost host health.");
            if (target.OwnerFraction == attackerFraction)
                continue;
            CardGrenadierBlastHit? hit =
                CardGrenadierExplosionDamage.ResolveArmy(
                    explosion.Position, target.Position,
                    group.Select(value => value.Hitbox).ToArray(),
                    launch.Damage, launch.Setup);
            if (hit == null)
                continue;
            if (!heavyTurrets.TryDamage(group.Key, hit.RawDamage,
                    out var changed, out bool destroyed) ||
                changed == null)
                throw new InvalidDataException(
                    "Card Grenadier turret damage escaped host bounds.");
            stateRevision++;
            Emit(destroyed ? MatchEventKind.HeavyTurretDestroyed :
                    MatchEventKind.HeavyTurretDamaged,
                launch.OwnerPlayerId, changed.OwnerPlayerId,
                group.Key, changed.Position, changed.Health,
                "card-grenadier");
        }
    }
}
