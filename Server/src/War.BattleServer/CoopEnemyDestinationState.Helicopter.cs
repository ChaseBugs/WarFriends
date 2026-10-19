namespace War.BattleServer;

public sealed partial class CoopEnemyDestinationState
{
    /// <summary>
    /// Reserves the ordinary Assaulter's random next scene point after leaving an external helicopter seat.
    /// </summary>
    internal CoopAssignedEnemyDestination? TryAssignHelicopterAssaulter(ulong entityId)
    {
        if (entityId == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(entityId));
        }
        if (assigned.ContainsKey(entityId))
        {
            throw new InvalidOperationException("Helicopter soldier already owns a destination.");
        }
        // MainScene's first LevelBehaviourManager entry is SoldierBehaviourAssaulter;
        // Helicopter.SpawnAssaulter creates that family, not the aircraft's own behaviour.
        string unitId = combat.UnitIdFor("Assaulter");
        CoopSoldierPointMask soldier = masks.Soldiers.Single(row => row.UnitId == unitId);
        if (soldier.BehaviorType != "SoldierBehaviourAssaulter")
        {
            throw new InvalidDataException("Helicopter crew lost its recovered Assaulter point mask.");
        }
        CoopEnemyPoint? point = CoopEnemyPointSelection.SelectFromExternalPoint(map, soldier.Mask,
            reservations.OccupiedPointIds, chooseNextPoint);
        if (point == null)
        {
            return null;
        }
        if (!reservations.TryReserve(entityId, point))
        {
            throw new InvalidOperationException("Selected helicopter soldier point became occupied.");
        }
        try
        {
            float fraction = point.ComponentType == "EnemyPointObstacle" ? chooseObstacleFraction() : 0f;
            var destination = new CoopAssignedEnemyDestination(point.ComponentFileId,
                CoopEnemyPointSelection.GeneratePosition(point, fraction));
            assigned.Add(entityId, destination);
            return destination;
        }
        catch
        {
            reservations.Release(entityId);
            throw;
        }
    }
}
