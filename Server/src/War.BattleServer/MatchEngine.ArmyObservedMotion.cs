using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private sealed record ArmyObservedMotion(Vector3 Position, Vector3 Velocity);
    private readonly Dictionary<ulong, ArmyObservedMotion> _armyObservedMotion = [];

    private void ObserveArmyRootMotion()
    {
        foreach (var (entityKey, entity) in activeArmyEntities)
        {
            Vector3 position = new(entity.X, entity.Y, entity.Z);
            Vector3 velocity = _armyObservedMotion.TryGetValue(entityKey, out ArmyObservedMotion? previous)
                ? (position - previous.Position) * MatchManifest.TickRate : Vector3.Zero;
            if (!PlayerHitbox.Finite(velocity))
            {
                throw new InvalidDataException("Observed army root velocity lost finite host authority.");
            }

            _armyObservedMotion[entityKey] = new ArmyObservedMotion(position, velocity);
        }

        ulong[] inactive = _armyObservedMotion.Keys.Where(key => !activeArmyEntities.ContainsKey(key)).ToArray();
        foreach (ulong entityKey in inactive)
        {
            // An inactive source GameShootableEntity stops updating its last motion.
            // Retain it only while an outstanding callback still references that entity.
            bool isReferenced = _assaulterVolleys.Values.Any(volley => volley.Prediction == null &&
                volley.Attempt.Aim.Target.EntityId == DroneArmyId(entityKey));
            if (!isReferenced)
            {
                _armyObservedMotion.Remove(entityKey);
            }
        }
    }

    private Vector3 AssaulterCallbackTargetVelocity(AssaulterShotTarget target)
    {
        if (target.IsPlayer)
        {
            Player player = Find(target.OwnerPlayerId) ??
                throw new InvalidDataException("Assaulter callback lost its source player.");
            return HeavyTurretPlayerVelocity(player);
        }

        if (target.EntityId.StartsWith("decoy:", StringComparison.Ordinal))
        {
            return Vector3.Zero;
        }

        ArmyObservedMotion motion = _armyObservedMotion.SingleOrDefault(pair =>
            DroneArmyId(pair.Key) == target.EntityId).Value ??
            throw new InvalidDataException("Assaulter callback lost its observed target motion.");
        return motion.Velocity;
    }
}
