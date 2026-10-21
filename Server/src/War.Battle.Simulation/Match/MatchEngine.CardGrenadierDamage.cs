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
        ApplyCardGrenadierBonusBoxes(launch.OwnerPlayerId,
            explosion.ProjectileId, explosion.Position, launch.Damage,
            launch.Setup);
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
        ApplyCardGrenadierRepairDroneExplosion(explosion, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;
        ApplyCardGrenadierAssaultGlassExplosion(explosion, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;
        ApplyCardGrenadierGroundVehicleExplosion(explosion, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;
        ApplyCardGrenadierPassengerExplosion(explosion, launch,
            attacker.Definition.Fraction);
        if (Terminal)
            return;
        ApplyCardGrenadierHelicopterGunnerExplosion(explosion, launch,
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
            shields.HasExplosionProtection(collider.DynamicOwner));

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

    internal void ApplyCardGrenadierRepairDroneExplosion(
        CardGrenadierExplosion explosion,
        CardGrenadierLaunchAuthority launch, int attackerFraction)
    {
        if (phase != BattlePhase.Running || groundVehicleWeapons == null)
            throw new InvalidDataException(
                "Card Grenadier has no repair-drone blast authority.");
        Player attacker = Find(launch.OwnerPlayerId) ??
            throw new InvalidDataException(
                "Card Grenadier repair-drone owner disappeared.");
        if (attacker.Definition.Fraction != attackerFraction)
            throw new InvalidDataException(
                "Card Grenadier repair-drone owner fraction changed.");
        if (vehicles == null)
            return;

        foreach (var vehicle in vehicles.Snapshot()
                     .Where(row => row.UnitId == "ID_UNIT-TRANSPORTER")
                     .OrderBy(row => row.EntityId).ToArray())
        {
            if (!activeArmyEntities.TryGetValue(vehicle.EntityId,
                    out var army) ||
                army.UnitId != vehicle.UnitId ||
                army.OwnerPlayerId != vehicle.OwnerPlayerId ||
                !transporterRepairDrones.TryGetValue(vehicle.EntityId,
                    out var drones))
                throw new InvalidDataException(
                    "Card Grenadier repair drone lost host authority.");
            Player owner = Find(vehicle.OwnerPlayerId) ??
                throw new InvalidDataException(
                    "Card Grenadier repair-drone owner disappeared.");
            if (owner.Definition.Fraction == attackerFraction)
                continue;
            int layer = owner.Definition.Fraction switch
            {
                1 => 23,
                2 => 22,
                _ => throw new InvalidDataException(
                    "Card Grenadier repair drone has invalid faction.")
            };

            foreach (var drone in drones.OrderBy(row => row.PathIndex))
            {
                if (!drone.Active)
                    continue;
                var snapshot = drone.Snapshot();
                var collider = groundVehicleWeapons.PlaceRepairDrone(
                    vehicle.EntityId, drone.PathIndex, layer, snapshot);
                CardGrenadierBlastHit? hit =
                    CardGrenadierExplosionDamage.ResolveArmy(
                        explosion.Position, snapshot.Position,
                        [collider.Hitbox], launch.Damage,
                        launch.Setup);
                if (hit == null)
                    continue;
                if (!ApplyTransporterRepairDroneHostDamage(
                        vehicle.EntityId, drone.PathIndex,
                        hit.RawDamage))
                    throw new InvalidDataException(
                        "Card Grenadier repair-drone damage failed.");
                if (!drone.Active)
                    Emit(MatchEventKind.VehicleRepairDroneDown,
                        vehicle.OwnerPlayerId, "", vehicle.EntityId,
                        drone.Position, 0,
                        "vehicle-repair-drone-down:" + drone.PathIndex);
            }
        }
    }

    internal void ApplyCardGrenadierAssaultGlassExplosion(
        CardGrenadierExplosion explosion,
        CardGrenadierLaunchAuthority launch, int attackerFraction)
    {
        if (phase != BattlePhase.Running)
            throw new InvalidDataException(
                "Card Grenadier has no front-glass blast authority.");
        Player attacker = Find(launch.OwnerPlayerId) ??
            throw new InvalidDataException(
                "Card Grenadier glass owner disappeared.");
        if (attacker.Definition.Fraction != attackerFraction)
            throw new InvalidDataException(
                "Card Grenadier glass owner fraction changed.");
        var aircraft = activeArmyEntities.Values
            .Where(row => row.UnitId == "ID_UNIT-ASSAULTHELI")
            .OrderBy(row => row.EntityKey).ToArray();
        if (aircraft.Length == 0)
            return;
        if (assaultHelicopterMeshColliders == null)
            throw new InvalidDataException(
                "Card Grenadier front-glass source is missing.");

        foreach (var helicopter in aircraft)
        {
            if (!armyAssaultHelicopterPaths.TryGetValue(
                    helicopter.EntityKey, out var path) ||
                !armyAssaultGlass.TryGetValue(helicopter.EntityKey,
                    out var glass))
                throw new InvalidDataException(
                    "Card Grenadier glass lost aircraft authority.");
            if (glass.Current <= 0 ||
                helicopter.OwnerFraction == attackerFraction)
                continue;
            var front = assaultHelicopterMeshColliders.PlaceFrontGlass(
                new Vector3(helicopter.X, helicopter.Y, helicopter.Z),
                path.Rotation);
            CardGrenadierBlastHit? hit =
                CardGrenadierExplosionDamage.ResolveArmy(
                    explosion.Position, front.Hitbox.Center,
                    [front.Hitbox], launch.Damage, launch.Setup);
            if (hit != null)
                ApplyAssaultGlassDamage(helicopter.EntityKey,
                    hit.RawDamage);
        }
    }

    internal void ApplyCardGrenadierGroundVehicleExplosion(
        CardGrenadierExplosion explosion,
        CardGrenadierLaunchAuthority launch, int attackerFraction)
    {
        if (phase != BattlePhase.Running ||
            groundVehicleWeapons == null)
            throw new InvalidDataException(
                "Card Grenadier has no vehicle blast authority.");
        Player attacker = Find(launch.OwnerPlayerId) ??
            throw new InvalidDataException(
                "Card Grenadier vehicle owner disappeared.");
        if (attacker.Definition.Fraction != attackerFraction)
            throw new InvalidDataException(
                "Card Grenadier vehicle owner fraction changed.");
        if (vehicles == null)
            return;

        foreach (var vehicle in vehicles.Snapshot()
                     .OrderBy(row => row.EntityId).ToArray())
        {
            if (!activeArmyEntities.TryGetValue(vehicle.EntityId,
                    out var army) ||
                army.UnitId != vehicle.UnitId ||
                army.OwnerPlayerId != vehicle.OwnerPlayerId ||
                !groundVehicleFacing.TryGetValue(vehicle.EntityId,
                    out var facing))
                throw new InvalidDataException(
                    "Card Grenadier vehicle lost shared host authority.");
            Player owner = Find(vehicle.OwnerPlayerId) ??
                throw new InvalidDataException(
                    "Card Grenadier vehicle owner disappeared.");
            if (owner.Definition.Fraction == attackerFraction)
                continue;

            var body = groundVehicleWeapons.PlaceBody(vehicle.UnitId,
                vehicle.EntityId, vehicle.Position, facing,
                owner.Definition.Fraction);
            CardGrenadierBlastHit? hit =
                CardGrenadierExplosionDamage.ResolveArmy(
                    explosion.Position, vehicle.Position,
                    body.Select(part => part.Hitbox).ToArray(),
                    launch.Damage, launch.Setup);
            if (hit == null)
                continue;

            float before = ArmyHealth(vehicle.EntityId) ??
                throw new InvalidDataException(
                    "Card Grenadier vehicle lacks shared vitality.");
            ApplyArmyHostDamage(vehicle.EntityId, hit.RawDamage);
            if (Terminal)
                return;
            if (!activeArmyEntities.ContainsKey(vehicle.EntityId))
                continue;
            float after = ArmyHealth(vehicle.EntityId) ??
                throw new InvalidDataException(
                    "Card Grenadier vehicle vitality disappeared.");
            float applied = before - after;
            if (applied > 0f &&
                (!vehicles.TryDamage(vehicle.EntityId, applied,
                    out float registryApplied,
                    out bool destroyed) || destroyed ||
                 Math.Abs(applied - registryApplied) > .001f))
                throw new InvalidDataException(
                    "Card Grenadier vehicle health stores diverged.");
        }
    }

    internal void ApplyCardGrenadierPassengerExplosion(
        CardGrenadierExplosion explosion,
        CardGrenadierLaunchAuthority launch, int attackerFraction)
    {
        if (phase != BattlePhase.Running ||
            groundVehicleWeapons == null)
            throw new InvalidDataException(
                "Card Grenadier has no passenger blast authority.");
        Player attacker = Find(launch.OwnerPlayerId) ??
            throw new InvalidDataException(
                "Card Grenadier passenger owner disappeared.");
        if (attacker.Definition.Fraction != attackerFraction)
            throw new InvalidDataException(
                "Card Grenadier passenger owner fraction changed.");
        if (vehicles == null)
            return;

        foreach (var vehicle in vehicles.Snapshot()
                     .OrderBy(row => row.EntityId).ToArray())
        {
            if (!activeArmyEntities.TryGetValue(vehicle.EntityId,
                    out var army) ||
                army.UnitId != vehicle.UnitId ||
                army.OwnerPlayerId != vehicle.OwnerPlayerId ||
                !groundVehicleFacing.TryGetValue(vehicle.EntityId,
                    out var facing) ||
                !vehiclePassengers.TryGetValue(vehicle.EntityId,
                    out var passengers))
                throw new InvalidDataException(
                    "Card Grenadier passenger lost shared host authority.");
            Player owner = Find(vehicle.OwnerPlayerId) ??
                throw new InvalidDataException(
                    "Card Grenadier passenger owner disappeared.");
            if (owner.Definition.Fraction == attackerFraction)
                continue;

            foreach (var passenger in passengers.Values
                         .OrderBy(row =>
                             row.Binding.PointComponentFileId))
            {
                if (!passenger.Active)
                    continue;
                if (passenger.AnimationStartTick > tick)
                    throw new InvalidDataException(
                        "Card Grenadier passenger animation starts after match time.");
                ulong animationTick = tick -
                    passenger.AnimationStartTick;
                var hitboxes = groundVehicleWeapons.PassengerPoses.Place(
                    vehicle.UnitId, passenger.Binding,
                    vehicle.Position, facing, animationTick);
                Vector3 position = PassengerWorldPosition(
                    vehicle.EntityId, passenger.Binding);
                CardGrenadierBlastHit? hit =
                    CardGrenadierExplosionDamage.ResolveArmy(
                        explosion.Position, position, hitboxes,
                        launch.Damage, launch.Setup);
                if (hit != null)
                    ApplyVehiclePassengerHostDamage(vehicle.EntityId,
                        passenger.Binding.Role, hit.RawDamage);
            }
        }
    }

    internal void ApplyCardGrenadierHelicopterGunnerExplosion(
        CardGrenadierExplosion explosion,
        CardGrenadierLaunchAuthority launch, int attackerFraction)
    {
        if (phase != BattlePhase.Running ||
            groundVehicleWeapons == null ||
            helicopterCrewPoints == null ||
            helicopterGunnerExplosions == null)
            throw new InvalidDataException(
                "Card Grenadier has no helicopter gunner blast authority.");
        Player attacker = Find(launch.OwnerPlayerId) ??
            throw new InvalidDataException(
                "Card Grenadier gunner owner disappeared.");
        if (attacker.Definition.Fraction != attackerFraction)
            throw new InvalidDataException(
                "Card Grenadier gunner owner fraction changed.");

        foreach (var helicopter in activeArmyEntities.Values
                     .Where(row => row.UnitId == "ID_UNIT-HELICOPTER")
                     .OrderBy(row => row.EntityKey).ToArray())
        {
            if (!armyHelicopterGunners.TryGetValue(
                    helicopter.EntityKey, out var gunner))
                continue;
            var state = gunner.Snapshot();
            if (!state.TurretEnabled ||
                helicopter.OwnerFraction == attackerFraction)
                continue;
            if (state.SpawnTick > tick ||
                helicopter.HelicopterRotation == null)
                throw new InvalidDataException(
                    "Card Grenadier gunner lost its current pose.");

            var rotation = helicopter.HelicopterRotation;
            var seat = helicopterCrewPoints.PlaceTurret(
                new Vector3(helicopter.X, helicopter.Y, helicopter.Z),
                new Quaternion(rotation.X, rotation.Y,
                    rotation.Z, rotation.W));
            ulong animationTick = tick - state.SpawnTick;
            var parts = groundVehicleWeapons.PassengerPoses
                .PlaceHelicopterGunner(seat, animationTick);
            var positions = helicopterGunnerExplosions
                .PlaceTransformPositions(seat, animationTick);
            if (parts.Count != 3 || positions.Length != 3)
                throw new InvalidDataException(
                    "Card Grenadier gunner has incomplete hitboxes.");

            var nearest = parts.Select((part, index) => new
                {
                    Part = part,
                    Index = index,
                    Distance = part.BoundsDistanceToPoint(
                        explosion.Position)
                })
                .Where(row => row.Part.OverlapsSphere(
                    explosion.Position, launch.Setup.OuterRadius))
                .OrderBy(row => row.Distance)
                .ThenBy(row => row.Index)
                .FirstOrDefault();
            if (nearest == null)
                continue;
            CardGrenadierBlastHit? hit =
                CardGrenadierExplosionDamage.ResolveDynamic(
                    explosion.Position, nearest.Distance,
                    positions[nearest.Index], launch.Damage,
                    launch.Setup);
            if (hit != null)
                DamageHelicopterGunner(helicopter.EntityKey,
                    hit.RawDamage);
        }
    }
}
