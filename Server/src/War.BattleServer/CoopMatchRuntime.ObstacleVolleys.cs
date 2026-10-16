using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private readonly Dictionary<ulong, CoopObstacleVolleyClock> _obstacleVolleyClocks = [];

    internal CoopObstacleVolleySnapshot? ObstacleVolleyState(ulong entityId)
    {
        if (!_obstacleVolleyClocks.TryGetValue(entityId, out CoopObstacleVolleyClock? clock))
        {
            return null;
        }
        return new CoopObstacleVolleySnapshot(clock.NextShotTick, clock.NextPositionTick,
            clock.IsCrawling, clock.HasPendingShot);
    }

    private void BeginObstacleVolleyClock(ulong entityId, CoopInfantryPointArrival arrival)
    {
        if (arrival.State != CoopInfantryPointState.ObstacleHiding || enemyPoses == null)
        {
            return;
        }
        if (!arrival.FirstRepositionTick.HasValue)
        {
            throw new InvalidDataException("Obstacle volley has no source position deadline.");
        }
        var clock = new CoopObstacleVolleyClock(arrival.FirstShootEligibleTick,
            arrival.FirstRepositionTick.Value);
        // ObstacleHidingUpdate draws this delay after accepted shot preparation.
        clock.BeginShot(tick, chooseInfantryRepositionFraction());
        _obstacleVolleyClocks.Add(entityId, clock);
    }

    private ulong CompleteInfantryVolleyClock(BattleCoopEnemySpawn enemy)
    {
        if (!_obstacleVolleyClocks.TryGetValue(enemy.EntityId, out CoopObstacleVolleyClock? clock))
        {
            return FirstInfantryShotEligibleTick(enemy, tick);
        }
        // Share one source draw with the windup; independent draws would disagree on readiness.
        clock.CompleteShot(tick, DrawInfantryShotDelay(enemy));
        return clock.NextShotTick;
    }
}

internal sealed record CoopObstacleVolleySnapshot(ulong NextShotTick, ulong NextPositionTick,
    bool IsCrawling, bool HasPendingShot);
