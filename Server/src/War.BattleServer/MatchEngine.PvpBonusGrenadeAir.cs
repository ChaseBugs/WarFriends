using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private void ApplyPvpBonusGrenadeAirBodies(
        PvpBonusGrenadeExplosionQuote explosion, GrenadeStage stage, Player owner)
    {
        var groups = GroundVehicleShotTargets(explosion.OwnerId, true)
            .Where(target => target.DroneRoot || target.HelicopterBody)
            .GroupBy(target => target.EntityId)
            .OrderBy(group => group.Key).ToArray();
        if (groups.Length > 0 &&
            (droneColliders == null || helicopterBodyColliders == null))
            throw new InvalidDataException("Bonus grenade air-body colliders are missing.");
        foreach (var group in groups)
        {
            if (!activeArmyEntities.TryGetValue(group.Key, out var army) ||
                army.UnitId is not ("ID_UNIT-DRONE" or "ID_UNIT-HELICOPTER" or
                    "ID_UNIT-ASSAULTHELI") ||
                group.Any(target => army.UnitId == "ID_UNIT-DRONE"
                    ? !target.DroneRoot : target.DroneRoot))
                throw new InvalidDataException("Bonus grenade air body lost host authority.");
            if (army.OwnerFraction == owner.Definition.Fraction) continue;

            var position = new Vector3(army.X, army.Y, army.Z);
            var effect = GrenadeExplosion.ResolveArmy(explosion.Position,
                position, group.Select(target => target.Hitbox).ToArray(), stage);
            if (effect == null) continue;
            if (!float.IsFinite(effect.RawDamage) ||
                effect.RawDamage is <= 0f or > 10_000_000f)
                throw new InvalidDataException("Bonus grenade air-body damage is invalid.");

            ApplyArmyHostDamage(group.Key, effect.RawDamage);
            if (Terminal) return;
            if (activeArmyEntities.ContainsKey(group.Key)) continue;
            if (directArmyKills.Count >= 256)
            {
                End("source-kill-backpressure", "", false);
                return;
            }
            directArmyKills.Add((group.Key, army.UnitId, army.OwnerPlayerId,
                explosion.OwnerId, "player-grenade", tick));
        }
    }

    private void ApplyPvpBonusGrenadeAssaultGlass(
        PvpBonusGrenadeExplosionQuote explosion, GrenadeStage stage, Player owner)
    {
        var aircraft = activeArmyEntities.Values
            .Where(row => row.UnitId == "ID_UNIT-ASSAULTHELI")
            .OrderBy(row => row.EntityKey).ToArray();
        if (aircraft.Length == 0) return;
        if (assaultHelicopterMeshColliders == null)
            throw new InvalidDataException("Bonus grenade assault glass source is missing.");

        foreach (var target in aircraft)
        {
            if (!armyAssaultHelicopterPaths.TryGetValue(target.EntityKey, out var path) ||
                !armyAssaultGlass.TryGetValue(target.EntityKey, out var glass))
                throw new InvalidDataException("Bonus grenade assault glass lost host authority.");
            if (target.OwnerFraction == owner.Definition.Fraction || glass.Current <= 0)
                continue;

            var front = assaultHelicopterMeshColliders.PlaceFrontGlass(
                new Vector3(target.X, target.Y, target.Z), path.Rotation);
            var effect = GrenadeExplosion.ResolveArmy(explosion.Position,
                front.Hitbox.Center, [front.Hitbox], stage);
            if (effect == null) continue;
            if (!float.IsFinite(effect.RawDamage) ||
                effect.RawDamage is <= 0f or > 10_000_000f)
                throw new InvalidDataException("Bonus grenade assault-glass damage is invalid.");
            if (ApplyAssaultGlassDamage(target.EntityKey, effect.RawDamage))
                owner.ConfirmedEnemyHits = checked(owner.ConfirmedEnemyHits + 1);
        }
    }
}
