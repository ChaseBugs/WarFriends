using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private sealed record AssaultHelicopterProjectile(string Owner, BulletFlight? Real,
        HelicopterFakeProjectileFlight? Fake, Vector3 Velocity, float Damage,
        float PlayerRatio, float OvertimeRatio);

    private readonly Dictionary<ulong, AssaultHelicopterProjectile> assaultHelicopterProjectiles = [];
    internal int PendingAssaultHelicopterProjectiles => assaultHelicopterProjectiles.Count;

    private void LaunchAssaultHelicopterRounds(BattleArmyEntityState unit,
        IReadOnlyList<AssaultHelicopterVolleyState.RoundIntent> rounds,
        ArmyVehicleShotStats stats)
    {
        foreach (var round in rounds)
        {
            if (projectileId == ulong.MaxValue || PendingProjectileCount >= MaximumProjectiles ||
                !EventCapacityForShot())
                continue;

            Vector3 direction = round.Target - round.Muzzle;
            if (!PlayerHitbox.Finite(direction) || direction.LengthSquared() < 1e-10f)
                continue;

            float speed = stats.ShotSpeed * (round.IsReal ? 1f : 1.5f);
            Vector3 velocity = Vector3.Normalize(direction) * speed;
            ulong id = checked(projectileId + 1);
            BulletFlight? real = null;
            HelicopterFakeProjectileFlight? fake = null;
            float damage = 0;
            float playerRatio = 0;
            float overtimeRatio = 0;

            if (round.IsReal)
            {
                if (!armyDamage.TryGetValue(unit.EntityKey, out damage) ||
                    !float.IsFinite(damage) || damage <= 0)
                    throw new InvalidDataException("Assault Helicopter lacks source damage authority.");
                var policy = (armyCatalog ?? throw new InvalidDataException(
                    "Assault Helicopter damage policy is absent.")).PlayerDamagePolicy(unit.UnitId);
                playerRatio = policy.PlayerDamageRatio;
                overtimeRatio = policy.OvertimePlayerDamageRatio;
                real = new BulletFlight(id, unit.OwnerPlayerId,
                    new(stats.ShotSpeed, 1f, false), round.Muzzle, round.Target, tick,
                    (origin, ray, range) => TraceHeavyTurretShot(
                        unit.OwnerPlayerId, origin, ray, range));
            }
            else
            {
                fake = new HelicopterFakeProjectileFlight(round.Muzzle, round.Target,
                    stats.ShotSpeed, tick);
            }

            assaultHelicopterProjectiles.Add(id, new(unit.OwnerPlayerId, real, fake,
                velocity, damage, playerRatio, overtimeRatio));
            projectileId = id;
            stateRevision++;
            Emit(MatchEventKind.AssaultHelicopterFired, unit.OwnerPlayerId,
                round.TargetId, id, round.Target, 0, "assault-helicopter");
            events[^1].AssaultHelicopterShot = new AssaultHelicopterShotPresentation
            {
                ArmyEntityKey = unit.EntityKey,
                MuzzleX = round.Muzzle.X,
                MuzzleY = round.Muzzle.Y,
                MuzzleZ = round.Muzzle.Z,
                Speed = speed,
                Fake = !round.IsReal,
                Shield = round.Shield,
                GunIndex = (uint)round.GunIndex
            };
        }
    }

    private void AdvanceAssaultHelicopterProjectiles()
    {
        foreach (var pair in assaultHelicopterProjectiles.OrderBy(entry => entry.Key).ToArray())
        {
            var projectile = pair.Value;
            if (projectile.Fake is { } fake)
            {
                fake.Advance(tick);
                if (fake.Finished) assaultHelicopterProjectiles.Remove(pair.Key);
                continue;
            }

            var flight = projectile.Real ?? throw new InvalidDataException(
                "Assault Helicopter projectile lacks flight authority.");
            var impact = flight.Advance(tick);
            if (flight.Finished) assaultHelicopterProjectiles.Remove(pair.Key);
            if (impact == null) continue;

            stateRevision++;
            Emit(MatchEventKind.Impact, impact.OwnerId, impact.Hit.PlayerId ?? "",
                impact.ProjectileId, impact.Hit.Position, 0, "assault-helicopter");
            ApplyHeavyTurretEnvironmentImpact(impact, projectile.Damage);
            if (Terminal) return;
            var hit = impact.Hit;
            if (hit.PlayerId is { } player)
                ApplyResolvedPlayerDamage(impact.OwnerId, player,
                    new(projectile.Damage, CombatDamageType.Shot, PartWeight: hit.PartWeight,
                        FriendKill: true, PlayerCoefficient: projectile.PlayerRatio,
                        PlayerOvertimeCoefficient: projectile.OvertimeRatio, Overtime: overtime),
                    damageRoll?.Invoke() ?? 1, true);
            else if (hit is { DynamicDecoy: true, DynamicEntityId: ulong decoy })
                ApplyDecoyProjectileImpact(impact.OwnerId, decoy, projectile.Damage,
                    hit.PartWeight, impact.ProjectileId);
            else if (hit is { DynamicArmyInfantry: true, DynamicEntityId: ulong infantry })
                ApplyArmyProjectileImpact(impact.OwnerId, infantry, projectile.Damage, hit.PartWeight);
            else if (hit is { DynamicHelicopterGunner: true, DynamicEntityId: ulong gunner })
                ApplyHelicopterGunnerProjectileImpact(impact.OwnerId, gunner, projectile.Damage, hit.PartWeight);
            else if (hit is { DynamicHeavyTurret: true, DynamicEntityId: ulong turret })
                ApplyHeavyTurretProjectileImpact(impact.OwnerId, turret, projectile.Damage,
                    hit.PartWeight, impact.ProjectileId);
            else if (hit is { DynamicPassengerRole: { } role, DynamicEntityId: ulong vehicle })
                ApplyGroundVehiclePassengerProjectileImpact(impact.OwnerId, vehicle, role,
                    projectile.Damage, hit.PartWeight);
            else if (hit is { DynamicRepairDronePathIndex: int path, DynamicEntityId: ulong repairVehicle })
                ApplyTransporterRepairDroneProjectileImpact(impact.OwnerId, repairVehicle,
                    path, projectile.Damage, hit.PartWeight);
            else if (hit is { DynamicPartId: int part, DynamicEntityId: ulong body })
                ApplyArmyBodyProjectileImpact(impact.OwnerId, body, part, projectile.Damage);
            if (Terminal) return;
        }
    }
}
