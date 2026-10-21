using System.Numerics;

using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const float AssaulterFakeMinimumOffset = 0.5f;
    private const float AssaulterFakeOffsetRange = 0.5f;
    private const float MaximumAssaulterDamage = 10_000_000f;

    private void LaunchAssaulterRound(ulong entityKey, AssaulterVolleyState volley)
    {
        if (PendingProjectileCount >= MaximumProjectiles || !EventCapacityForShot() ||
            stateRevision == ulong.MaxValue || projectileId == ulong.MaxValue || lastEventId == ulong.MaxValue)
        {
            End("assaulter-shot-backpressure", "", false);
            return;
        }

        var entity = activeArmyEntities[entityKey];
        if (!armyDamage.TryGetValue(entityKey, out float damage) || !float.IsFinite(damage) ||
            damage < 0f || damage > MaximumAssaulterDamage || assaulterWeapon == null || volley.Prediction == null)
        {
            throw new InvalidDataException("Assaulter shot lost its current weapon damage or source setup.");
        }

        int round = volley.RoundOffsets.Count;
        bool isReal = (volley.Attempt.Batch.RealShotMask & (1 << round)) != 0;
        Vector3 origin = AssaulterVolleyMuzzle(entityKey, volley) + assaulterWeapon.ShotOffset;
        Vector3 target = volley.Prediction.TargetPosition;
        if (!isReal)
        {
            target = AssaulterFakeTarget(new Vector3(entity.X, entity.Y, entity.Z), target);
        }

        ulong id = checked(projectileId + 1);
        float speed = isReal ? volley.Prediction.Inputs.BulletSpeed : assaulterWeapon.FakeBulletSpeed;
        var flight = new ArmyProjectileFlight(id, entityKey, origin, target, speed, tick,
            (from, direction, range) => TraceArmyShot(entity.OwnerPlayerId, from, direction, range),
            extraCollisionDistance: isReal ? assaulterWeapon.CollisionCheckDistance : 0f, cosmeticTrail: !isReal);
        _armyBullets.AddActive(id, flight, new PvpArmyBulletPayload
        {
            EntityKey = entityKey, OwnerPlayerId = entity.OwnerPlayerId, OwnerFraction = entity.OwnerFraction,
            Damage = damage, PoisonRatio = 0f, UnitId = entity.UnitId, SourceCardId = entity.SourceCardId,
            IsCosmetic = !isReal, PlayerPolicy = armyCatalog!.PlayerDamagePolicy(entity.UnitId)
        });
        projectileId = id;
        Emit(MatchEventKind.Shot, entity.OwnerPlayerId, volley.Attempt.Aim.Target.OwnerPlayerId, id, origin, 0, "army");
        stateRevision++;
    }

    private Vector3 AssaulterFakeTarget(Vector3 actorPosition, Vector3 target)
    {
        Vector3 lateral = Vector3.Cross(actorPosition - target, Vector3.UnitY);
        lateral = lateral.LengthSquared() > 0f ? Vector3.Normalize(lateral) : Vector3.Zero;
        lateral *= AssaulterFakeMinimumOffset + NextArmyFloat() * AssaulterFakeOffsetRange;
        if (NextArmyFloat() < 0.5f)
        {
            lateral = -lateral;
        }

        return target + lateral + Vector3.UnitY * AssaulterFakeMinimumOffset;
    }
}
