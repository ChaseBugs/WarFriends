using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private const int CompletedObservedReturnPhase = 16;
    private const int FirstVerifiedObservedReturnPhase = 1;
    private readonly CoopObservedObstaclePoseCatalog? _observedObstaclePoseCatalog;

    private bool HasObservedPreparationOrigin(CoopInfantryShotWindup windup)
    {
        // Automatic fire -> ordinary crawl Play matches the nominal catalog for phases 1 through 16.
        // Phase zero still retains the prior fire pose before its first evaluation and needs separate content.
        return _observedObstaclePoseCatalog != null &&
            windup.ObstaclePreparation?.PriorReturnTicks is >= FirstVerifiedObservedReturnPhase
                and <= CompletedObservedReturnPhase;
    }

    private BattleInfantryAnimationFrame? ProjectObservedPreparation(ulong entityId)
    {
        int? sampleId = ObstaclePreparationSampleId(entityId);
        if (sampleId == null || _observedObstaclePoseCatalog == null)
        {
            return null;
        }

        BattleInfantryAnimationFrame frame = _observedObstaclePoseCatalog.GetSample(sampleId.Value).Animation(tick);
        frame.ObservedPose = new BattleInfantryObservedPoseReference
        {
            CatalogRevision = _observedObstaclePoseCatalog.Revision,
            SampleId = (uint)sampleId.Value
        };
        return frame;
    }

    internal int? ObstaclePreparationSampleId(ulong entityId)
    {
        if (phase != BattlePhase.Running ||
            !infantryShotWindups.TryGetValue(entityId, out CoopInfantryShotWindup? windup) ||
            windup.AnimationClip != "stand_up_begin" || windup.HasNavigationRotationConflict ||
            (windup.NextEligibleTick is ulong nextEligible && tick >= nextEligible))
        {
            return null;
        }
        if (infantryRoundIntents.TryGetValue(entityId, out List<CoopInfantryRoundIntent>? rounds) && rounds.Count > 0)
        {
            // The source grid contains preparation without emitted rounds; a confirmed round starts another timeline.
            return null;
        }
        // This is a nominal content candidate; revision loading and validated wire publication remain separate.
        return windup.ObstaclePreparation?.SelectSampleId(tick);
    }

    private CoopObstaclePreparationStart? CaptureObstaclePreparation(ulong entityId, CoopInfantryPointArrival arrival)
    {
        if (arrival.State != CoopInfantryPointState.ObstacleHiding)
        {
            return null;
        }
        bool hasPreviousAttempt = infantryShotWindups.TryGetValue(entityId, out CoopInfantryShotWindup? windup);
        ulong? previousRound = ReadPreviousObstacleRound(entityId, windup);
        if (!hasPreviousAttempt || !_obstacleCrawlStates.TryGetValue(entityId, out ObstacleCrawlState? previous))
        {
            return CoopObstaclePreparationStart.Unresolved(tick, hasPreviousAttempt, previousRoundTick: previousRound);
        }
        if (previous.HasInterruptedReturn || previous.ReturnTick == null || enemyPoses == null ||
            IsObstacleRepositioning(entityId))
        {
            return CoopObstaclePreparationStart.Unresolved(tick, true, previous.ReturnTick, previousRound);
        }
        return CoopObstaclePreparationStart.FromReturn(tick, previous.ReturnTick.Value,
            enemyPoses.Clip("stand_up_crawl").Length, previousRound);
    }

    private ulong? ReadPreviousObstacleRound(ulong entityId, CoopInfantryShotWindup? windup)
    {
        // Retained projectile evidence can outlive a windup and does not prove the new point's animation history.
        if (windup == null || !infantryRoundIntents.TryGetValue(entityId, out List<CoopInfantryRoundIntent>? rounds) ||
            rounds.Count == 0 || rounds[^1].Tick < windup.StartTick)
        {
            return null;
        }
        return rounds[^1].Tick;
    }
}
