using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private const float SourceRoundHideSeconds = 0.5f;
    private readonly CoopObstaclePoseCatalog? _obstaclePoseCatalog;
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

    internal bool IsObstacleRepositioning(ulong entityId)
    {
        return movingObstacleRepositions.Contains(entityId) && infantryPaths.ContainsKey(entityId);
    }

    internal IReadOnlyList<PlayerHitbox> PlaceObstacleVolleyHitboxes(ulong entityId)
    {
        if (_obstaclePoseCatalog == null || phase != BattlePhase.Running || IsObstacleRepositioning(entityId) ||
            !infantryShotWindups.TryGetValue(entityId, out CoopInfantryShotWindup? windup) ||
            windup.AnimationClip != "stand_up_begin" || windup.HasNavigationRotationConflict ||
            tick < windup.StartTick ||
            !CoopAssaulterShotRotation.FinalRotationReached(CoopInfantryPointState.ObstacleHiding,
                tick - windup.StartTick))
        {
            return [];
        }
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.Health > 0 && spawn.DeathTick == 0);
        if (enemy == null || !HasCompletedPriorCrawl(enemy))
        {
            return [];
        }
        IReadOnlyList<CoopInfantryRoundIntent> rounds = InfantryRoundIntents(entityId);
        if (!_obstacleCrawlStates.TryGetValue(entityId, out ObstacleCrawlState? crawl) ||
            crawl.HasInterruptedReturn)
        {
            return [];
        }
        ulong[] offsets = rounds.Select(round => round.Tick - windup.StartTick).ToArray();
        ulong? returnOffset = crawl.ReturnTick.HasValue ? crawl.ReturnTick.Value - windup.StartTick : null;
        var clock = new CoopObstaclePoseClock(tick - windup.StartTick, offsets, returnOffset);
        var position = new Vector3(enemy.CurrentX, enemy.CurrentY, enemy.CurrentZ);
        return _obstaclePoseCatalog.Place(clock, position, windup.FinalRootRotation, $"coop/{entityId}/");
    }

    private bool HasCompletedPriorCrawl(BattleCoopEnemySpawn enemy)
    {
        if (enemyPoses == null)
        {
            return false;
        }
        ArmyBaseShotStats shot = enemy.CardUnit
            ? combat.CardShot(enemy.Behaviour, enemy.CardProgress)
            : combat.OrdinaryShot(enemy.Behaviour, enemy.Level);
        // The measured transition begins from fully completed crawl, not an interrupted return clip.
        float completeReturnSeconds = SourceRoundHideSeconds + enemyPoses.Clip("stand_up_crawl").Length;
        return shot.MinShootTime >= completeReturnSeconds;
    }

    private void BeginObstacleVolleyClock(ulong entityId, CoopInfantryPointArrival arrival)
    {
        if (arrival.State != CoopInfantryPointState.ObstacleHiding || enemyPoses == null)
        {
            return;
        }
        if (!_obstacleVolleyClocks.TryGetValue(entityId, out CoopObstacleVolleyClock? clock))
        {
            throw new InvalidDataException("Obstacle arrival has no source volley clock.");
        }
        clock.BeginShot(tick, chooseInfantryRepositionFraction());
        nextObstacleRepositionTicks[entityId] = clock.NextPositionTick;
        BeginObstacleCrawlClock(entityId);
    }

    private bool IsObstacleShotReady(ulong entityId, CoopInfantryPointArrival arrival)
    {
        if (arrival.State != CoopInfantryPointState.ObstacleHiding)
        {
            return false;
        }
        if (!_obstacleVolleyClocks.TryGetValue(entityId, out CoopObstacleVolleyClock? clock))
        {
            throw new InvalidDataException("Obstacle arrival has no source volley clock.");
        }
        return clock.Decide(tick) == CoopObstacleAction.Shoot;
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
