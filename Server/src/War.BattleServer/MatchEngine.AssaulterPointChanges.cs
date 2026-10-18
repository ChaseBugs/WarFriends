using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const ulong AssaulterUnavailablePointDelayTicks = 10 * MatchManifest.TickRate;

    private void AdvanceAssaulterPointChanges()
    {
        foreach (var (entityKey, corner) in _assaulterCorners.OrderBy(row => row.Key).ToArray())
        {
            if (tick < corner.FirstPointChangeEligibleTick ||
                (_assaulterVolleys.TryGetValue(entityKey, out var volley) && !volley.CompletedTick.HasValue))
            {
                continue;
            }

            CardEnemyPointOccupancy occupancy = cardEnemyPoints ??
                throw new InvalidDataException("Assaulter point change lost shared occupancy.");
            IReadOnlyList<CardUnitInitialPoint> candidates = occupancy.NextAssaulterPoints(entityKey);
            if (candidates.Count == 0)
            {
                // CornerHidingUpdate adds ten seconds to the old deadline, not to the current time.
                _assaulterCorners[entityKey] = corner with
                {
                    FirstPointChangeEligibleTick = checked(corner.FirstPointChangeEligibleTick +
                        AssaulterUnavailablePointDelayTicks)
                };
                continue;
            }

            int index = armyChoice(candidates.Count);
            if (index < 0 || index >= candidates.Count)
            {
                throw new InvalidDataException("Assaulter point-change draw left the source collection.");
            }

            MoveAssaulterToPoint(entityKey, candidates[index], occupancy);
        }
    }

    private void MoveAssaulterToPoint(ulong entityKey, CardUnitInitialPoint next, CardEnemyPointOccupancy occupancy)
    {
        var entity = activeArmyEntities[entityKey];
        occupancy.TransferAssaulter(entityKey, next);
        _assaulterCorners.Remove(entityKey);
        _settledAssaulterCorners.Remove(entityKey);
        _assaulterAttempts.Remove(entityKey);
        _assaulterVolleys.Remove(entityKey);
        _assaulterCallbacks.Remove(entityKey);
        // Preserve weapon state and airborne projectile authority while the source soldier walks.
        StartAssaulterWalk(entity, next, new Vector3(entity.X, entity.Y, entity.Z));
    }
}
