using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private void AdvanceMortarRelocations()
    {
        foreach (var (entityKey, attempt) in _mortarAttempts.OrderBy(row => row.Key).ToArray())
        {
            if (enemyPoses == null || _mortarPointCatalog == null)
            {
                throw new InvalidDataException("Mortar relocation lost its source animation or point catalog.");
            }
            // Preserve the left-associative binary32 deadline from FireMortar, then its strict Update comparison.
            float deadline = attempt.PreparedTick / (float)MatchManifest.TickRate +
                enemyPoses.Clip("mortar_hide").Length + enemyPoses.Clip("mortar_up").Length;
            if (tick / (float)MatchManifest.TickRate <= deadline)
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
        _mortarWalks.Add(entityKey, new MortarWalk(motion, checked(tick + 1)));
    }
}
