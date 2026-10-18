namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private void AdvanceGunslingerPointChanges()
    {
        foreach (var (entityKey, arrival) in _gunslingerArrivals.OrderBy(row => row.Key).ToArray())
        {
            if (arrival.ShotsRemaining != 0 || tick < arrival.FirstPointChangeEligibleTick ||
                (GunslingerAttempt(entityKey) is { } pending && !pending.CompletedTick.HasValue))
            {
                continue;
            }

            GunslingerPoint current = _gunslingerPoints[entityKey];
            GunslingerPointCatalog catalog = _gunslingerPointCatalog ??
                throw new InvalidDataException("Gunslinger point change lost its scene catalog.");
            GunslingerPoint? next = GunslingerPointSelection.SelectNext(catalog.ForMap(map!), current,
                _gunslingerOccupants.ContainsKey, armyChoice);
            if (next == null)
            {
                // GunslingerUpdate has no unavailable-point delay. Retain the old
                // deadline and reservation, then retry on the next gameplay Update.
                continue;
            }

            MoveGunslingerToPoint(entityKey, current, next);
        }
    }

    private void MoveGunslingerToPoint(ulong entityKey, GunslingerPoint current, GunslingerPoint next)
    {
        // Validate the new route before releasing the old reservation. Weapon
        // multipliers and already launched projectiles survive this movement.
        CardSoldierWalkState motion = CreateGunslingerWalk(entityKey, next);
        if (_gunslingerOccupants.GetValueOrDefault(current.ComponentFileId) != entityKey ||
            _gunslingerOccupants.ContainsKey(next.ComponentFileId))
        {
            throw new InvalidDataException("Gunslinger point transfer lost exclusive source occupancy.");
        }

        _gunslingerOccupants.Remove(current.ComponentFileId);
        _gunslingerOccupants.Add(next.ComponentFileId, entityKey);
        _gunslingerPoints[entityKey] = next;
        _gunslingerArrivals.Remove(entityKey);
        _gunslingerAttempts.Remove(entityKey);
        _gunslingerWalks.Add(entityKey, new GunslingerWalk(motion, checked(tick + 1)));
    }
}
