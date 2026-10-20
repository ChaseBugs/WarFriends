namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    /// <summary>Samples the local rifle pose before OnShot, without granting root or hit authority.</summary>
    internal CoopQueuedMuzzleSample? ObserveTransportCrewLocalRifleMuzzle(TransportCrewNavigationCommand command,
        TransportCrewObstacleClock.ShotObservation observation)
    {
        ArgumentNullException.ThrowIfNull(observation);
        TransportCrewNavigationOwner owner = RequireCrewShotOwner(command, observation.Frame);
        if (!float.IsFinite(observation.ControllerTime) || observation.ControllerTime < 0 ||
            !float.IsFinite(observation.CoroutineTime) || observation.CoroutineTime < 0)
        {
            throw new InvalidDataException("Crew muzzle observation requires a finite source controller clock.");
        }
        if (owner.PreparedCrewShot is not TransportCrewPreparedShot prepared || enemyPoses == null ||
            enemyMuzzles == null || _obstaclePoseCatalog == null ||
            owner.CrewPreparationControllerTime is not float preparationTime ||
            owner.CrewPreparationScaledTime is not float scaledPreparationTime ||
            owner.PointEntry is not TransportCrewPointEntry entry || !entry.IsCrawling ||
            !owner.ObstacleClock!.HasPendingVolley || tick < prepared.Target.Tick || owner.HasPriorCrewShotReturn)
        {
            return null;
        }
        // The reviewed sampler starts with a completed crawl. Interrupted entry/return needs its own mixer proof.
        float priorCrawlSeconds = preparationTime - entry.ControllerTime;
        float latestAnimationTime = owner.CrewLastRoundScaledTime ?? scaledPreparationTime;
        float hideDelay = owner.CrewLastRoundScaledTime.HasValue ? SourceRoundHideSeconds : SourceInitialHideSeconds;
        if (priorCrawlSeconds < enemyPoses.Clip("stand_up_crawl").Length ||
            observation.CoroutineTime < latestAnimationTime ||
            observation.CoroutineTime > latestAnimationTime + hideDelay)
        {
            return null;
        }
        var clock = new CoopObstaclePoseClock(tick - prepared.Target.Tick,
            owner.CrewExecutedRoundOffsets, PreparationPhase: CoopObstaclePreparationPhase.GameplayUpdate);
        return _obstaclePoseCatalog.GameplayFiringMuzzle(clock, enemyMuzzles);
    }
}
