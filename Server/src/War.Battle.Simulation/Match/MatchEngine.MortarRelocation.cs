using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private void AdvanceMortarRelocations()
    {
        foreach (ulong entityKey in _mortarAttempts.Keys.Order().ToArray())
        {
            if (enemyPoses == null || _mortarPointCatalog == null)
            {
                throw new InvalidDataException("Mortar relocation lost its source animation or point catalog.");
            }
            // FireMortar uses the soldier's accumulated mTime, not absolute tick-to-second conversion.
            if (!_mortarRelocationTimes.TryGetValue(entityKey, out float deadline))
            {
                throw new InvalidDataException("Mortar relocation lost its accumulated source deadline.");
            }
            if (_mortarControllerTimes[entityKey].Clock.Time <= deadline)
            {
                continue;
            }
            RelocateMortar(entityKey);
        }
    }

    private void RelocateMortar(ulong entityKey)
    {
        var entity = activeArmyEntities[entityKey];
        MortarPoint current = _mortarPoints[entityKey];
        Vector3 position = new(entity.X, entity.Y, entity.Z);
        MortarPoint destination = current;
        if (Vector2.Distance(new(position.X, position.Z), new(current.Position.X, current.Position.Z)) <
            MortarArrivalDistance)
        {
            MortarPoint[] candidates = _mortarPointCatalog!.ForMap(map!).Where(point =>
                point.Fraction == entity.OwnerFraction && point.ComponentFileId != current.ComponentFileId &&
                !_mortarOccupants.ContainsKey(point.ComponentFileId)).OrderBy(point => point.Order).ToArray();
            if (candidates.Length == 0)
            {
                // GetNextFreeEnemyPoint can return null. Keep the reservation and retry next Update.
                return;
            }
            int index = armyChoice(candidates.Length);
            if (index < 0 || index >= candidates.Length)
            {
                throw new InvalidDataException("Mortar relocation draw left its source point range.");
            }
            destination = candidates[index];
        }

        ArmyNavMeshCorridor route = PlanMortarRoute(position, destination);
        float speed = ArmySpeed(entityKey) ?? armyCatalog!.EffectiveSpeed(entity.UnitId, 1f);
        var motion = new CardSoldierWalkState(destination.ComponentFileId, route, armyCatalog!.InfantryAgent, speed);
        if (_mortarOccupants.GetValueOrDefault(current.ComponentFileId) != entityKey)
        {
            throw new InvalidDataException("Mortar relocation lost its previous point reservation.");
        }
        _mortarOccupants.Remove(current.ComponentFileId);
        _mortarOccupants.Add(destination.ComponentFileId, entityKey);
        _mortarPoints[entityKey] = destination;
        _mortarConstruction.Remove(entityKey);
        _mortarFacings.Remove(entityKey);
        _mortarAttempts.Remove(entityKey);
        _mortarDetachedWeapons.Remove(entityKey);
        _mortarRelocationTimes.Remove(entityKey);
        _mortarWalks.Add(entityKey, new MortarWalk(motion, checked(tick + 1)));
    }
}
