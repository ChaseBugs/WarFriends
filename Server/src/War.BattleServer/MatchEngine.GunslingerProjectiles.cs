using System.Numerics;

using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const float GunslingerShotHeight = 0.05f;

    private void LaunchGunslingerRound(ulong entityKey, GunslingerShotAttempt attempt)
    {
        if (PendingProjectileCount >= MaximumProjectiles || !EventCapacityForShot() ||
            stateRevision == ulong.MaxValue || projectileId == ulong.MaxValue || lastEventId == ulong.MaxValue)
        {
            End("gunslinger-shot-backpressure", "", false);
            return;
        }

        var entity = activeArmyEntities[entityKey];
        CoopAssaulterWeaponCatalog source = assaulterWeapon ??
            throw new InvalidDataException("Gunslinger lost its shared source rifle binding.");
        GunslingerAimPrediction prediction = attempt.Prediction ??
            throw new InvalidDataException("Gunslinger projectile has no executed callback prediction.");
        float damage = armyDamage[entityKey];
        if (!float.IsFinite(damage) || damage < 0f || damage > MaximumAssaulterDamage)
        {
            throw new InvalidDataException("Gunslinger projectile lost current source damage.");
        }

        bool isReal = (attempt.Batch.RealShotMask & 1) != 0;
        Vector3 origin = GunslingerFiringMuzzle(entityKey, attempt) + Vector3.UnitY * GunslingerShotHeight;
        Vector3 target = prediction.TargetPosition;
        if (!isReal)
        {
            target = AssaulterFakeTarget(new Vector3(entity.X, entity.Y, entity.Z), target);
        }

        float baseSpeed = _gunslingerAimWeapons[entityKey].BaseBulletSpeed;
        float speed = isReal ? prediction.Inputs.BulletSpeed :
            source.FakeBulletSpeed * (baseSpeed / source.RealBulletSpeed);
        ulong id = checked(projectileId + 1);
        var flight = new ArmyProjectileFlight(id, entityKey, origin, target, speed, tick,
            (from, direction, range) => TraceArmyShot(entity.OwnerPlayerId, from, direction, range),
            extraCollisionDistance: isReal ? source.CollisionCheckDistance : 0f, cosmeticTrail: !isReal);
        armyProjectiles.Add(id, flight);
        armyProjectileAuthority.Add(id, new ArmyProjectileAuthority(entityKey, entity.OwnerPlayerId,
            entity.OwnerFraction, damage, 0f, entity.UnitId, entity.SourceCardId, !isReal)
        {
            PlayerPolicy = armyCatalog!.PlayerDamagePolicy(entity.UnitId)
        });
        projectileId = id;
        Emit(MatchEventKind.Shot, entity.OwnerPlayerId, attempt.Aim.Target.OwnerPlayerId, id, origin, 0, "army");
        stateRevision++;
    }
}
