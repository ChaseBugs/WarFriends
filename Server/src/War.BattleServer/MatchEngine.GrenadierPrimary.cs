using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const float MaximumGrenadierPrimaryDamage = 10_000_000f;

    private void LaunchCardGrenadierPrimary(CardGrenadierShotIntent intent)
    {
        if (!activeArmyEntities.TryGetValue(intent.EntityKey, out var soldier) ||
            soldier.SourceCardId != "GREATGRENADIER" ||
            !armyDamage.TryGetValue(intent.EntityKey, out float damage) ||
            !float.IsFinite(damage) || damage < 0f || damage > MaximumGrenadierPrimaryDamage)
        {
            throw new InvalidDataException("Grenadier primary shot lost its current weapon authority.");
        }

        if (PendingProjectileCount >= MaximumProjectiles || !EventCapacityForShot() ||
            stateRevision == ulong.MaxValue || lastEventId == ulong.MaxValue)
        {
            return;
        }

        if (projectileId == ulong.MaxValue)
        {
            throw new InvalidDataException("Grenadier primary projectile identities exhausted.");
        }

        GrenadierPrimaryWeapon weapon = GrenadierPrimaryWeapon.Instance;
        Vector3 position = new(soldier.X, soldier.Y, soldier.Z);
        Vector3 origin = weapon.PlaceMuzzle(position, intent.Aim.Target.Position - position);
        AddGrenadierPrimaryFlight(intent, soldier, origin, damage);
    }

    private void AddGrenadierPrimaryFlight(CardGrenadierShotIntent intent, BattleArmyEntityState soldier,
        Vector3 origin, float damage)
    {
        GrenadierPrimaryWeapon weapon = GrenadierPrimaryWeapon.Instance;
        ulong id = ++projectileId;
        // BulletBase uses the same doubled-distance cosmetic tween for fake pistol
        // bullets and shotgun trails. That flight mode performs no collision queries.
        var flight = new ArmyProjectileFlight(id, intent.EntityKey, origin, intent.Aim.Target.Position,
            intent.IsReal ? weapon.Speed : weapon.FakeSpeed, tick,
            (from, direction, range) => TraceArmyShot(soldier.OwnerPlayerId, from, direction, range),
            extraCollisionDistance: intent.IsReal ? weapon.CollisionDistance : 0f,
            cosmeticTrail: !intent.IsReal);
        armyProjectiles.Add(id, flight);
        armyProjectileAuthority.Add(id, new ArmyProjectileAuthority(intent.EntityKey,
            soldier.OwnerPlayerId, soldier.OwnerFraction, damage, 0f,
            soldier.UnitId, soldier.SourceCardId, !intent.IsReal)
        {
            PlayerPolicy = armyCatalog!.PlayerDamagePolicy(soldier.UnitId)
        });
        Emit(MatchEventKind.Shot, soldier.OwnerPlayerId, intent.Aim.Target.PlayerId,
            id, origin, 0, "army");
        stateRevision++;
    }
}
