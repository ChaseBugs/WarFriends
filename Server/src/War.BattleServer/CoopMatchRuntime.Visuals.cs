using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private const ulong CornerEntryTweenTicks = 15;

    private CoopInfantryPathState? GetWalkingPresentationPath(BattleCoopEnemySpawn enemy)
    {
        if (phase != BattlePhase.Running || enemyPoses == null || enemy.Behaviour != "Assaulter" ||
            enemy.Health <= 0 || enemy.DeathTick != 0 || enemy.PoseTick != tick || enemy.CurrentRotation == null ||
            movingObstacleRepositions.Contains(enemy.EntityId))
        {
            return null;
        }

        return infantryPaths.GetValueOrDefault(enemy.EntityId);
    }

    private BattleCoopEnemySpawn ProjectEnemyVisual(BattleCoopEnemySpawn enemy)
    {
        BattleCoopEnemySpawn view = enemy.Clone();
        CoopInfantryPathState? path = GetWalkingPresentationPath(enemy);
        if (path != null)
        {
            // Match the existing diagnostic walking sample, never promote this estimated facing to collision authority.
            view.InfantryVisualClip = ArmyInfantryPosePolicy.For(combat.UnitIdFor(enemy.Behaviour)).Walk;
            view.InfantryVisualStartTick = path.StartTick;
            view.InfantryVisualSampleTick = tick;
            view.InfantryAnimation = CreateVisualFrame(view.InfantryVisualClip,
                (float)((tick - path.StartTick) / (double)MatchManifest.TickRate), BattleInfantryAnimationWrap.Loop);
        }
        else
        {
            view.InfantryAnimation = ProjectCornerPreparationVisual(enemy) ??
                ProjectCornerFireVisual(enemy) ?? ProjectCornerReturnVisual(enemy);
        }

        return view;
    }

    private BattleInfantryAnimationFrame? ProjectCornerPreparationVisual(BattleCoopEnemySpawn enemy)
    {
        if (infantryPaths.ContainsKey(enemy.EntityId) ||
            !infantryShotWindups.TryGetValue(enemy.EntityId, out CoopInfantryShotWindup? windup) ||
            !infantryFirstTargets.TryGetValue(enemy.EntityId, out CoopInfantryPlayerTargetPlan? firstTarget) ||
            !infantryPointArrivals.TryGetValue(enemy.EntityId, out CoopInfantryPointArrival? arrival) ||
            firstTarget.Tick < arrival.Tick + CornerEntryTweenTicks ||
            firstTarget.Tick != windup.StartTick || windup.HasNavigationRotationConflict ||
            PlaceCornerUncoverHitboxes(enemy.EntityId).Count == 0)
        {
            return null;
        }

        // The first accepted corner attempt follows source idle. Later attempts may reverse an active return;
        // they cannot reuse a zero-based look clock without retaining the prior animation state.
        ulong elapsed = tick - windup.StartTick;
        float lookTicks = enemyPoses!.Clip(windup.AnimationClip).Length * MatchManifest.TickRate;
        float roundedLookTicks = MathF.Round(lookTicks);
        if (MathF.Abs(lookTicks - roundedLookTicks) > 0.0001f)
        {
            throw new InvalidDataException("Source corner preparation must end on the reviewed fixed-tick boundary.");
        }
        ulong queuedStart = (ulong)roundedLookTicks;
        if (elapsed == queuedStart)
        {
            // Both measured source corner queues switch to their fire clone at this exact 30 Hz frame.
            return CreateVisualFrame(windup.QueuedFireClip, 0f, BattleInfantryAnimationWrap.ClampForever);
        }

        float seconds = elapsed / (float)MatchManifest.TickRate;
        return CreateVisualFrame(windup.AnimationClip, seconds, BattleInfantryAnimationWrap.Clamp);
    }

    private BattleInfantryAnimationFrame? ProjectCornerFireVisual(BattleCoopEnemySpawn enemy)
    {
        if (infantryPaths.ContainsKey(enemy.EntityId) ||
            !infantryShotWindups.TryGetValue(enemy.EntityId, out CoopInfantryShotWindup? windup) ||
            windup.HasNavigationRotationConflict || PlaceCornerFireHitboxes(enemy.EntityId).Count == 0)
        {
            return null;
        }

        float lookTicks = enemyPoses!.Clip(windup.AnimationClip).Length * MatchManifest.TickRate;
        ulong fireStartTick = windup.StartTick + (ulong)MathF.Round(lookTicks);
        if (infantryRoundIntents.TryGetValue(enemy.EntityId, out List<CoopInfantryRoundIntent>? rounds) &&
            rounds.Count > 0)
        {
            fireStartTick = rounds[^1].Tick;
            if (fireStartTick == tick)
            {
                // Source OnShot resets animation between evaluations; this transition frame is not represented yet.
                return null;
            }
        }

        return CreateVisualFrame(windup.QueuedFireClip,
            (tick - fireStartTick) / (float)MatchManifest.TickRate, BattleInfantryAnimationWrap.ClampForever);
    }

    private BattleInfantryAnimationFrame? ProjectCornerReturnVisual(BattleCoopEnemySpawn enemy)
    {
        if (cornerQueuePoses == null || infantryPaths.ContainsKey(enemy.EntityId) ||
            !infantryShotWindups.TryGetValue(enemy.EntityId, out CoopInfantryShotWindup? windup) ||
            windup.HasNavigationRotationConflict ||
            windup.AnimationClip is not ("player_look_right3" or "player_look_left3") ||
            (windup.NextEligibleTick is ulong nextEligible && tick >= nextEligible))
        {
            return null;
        }

        ulong startTick = CornerCoverBackStartTick(enemy.EntityId, windup);
        if (tick < startTick ||
            (PlaceCornerCoverBackHitboxes(enemy.EntityId).Count == 0 &&
                PlaceCornerQueuedIdleHitboxes(enemy.EntityId).Count == 0))
        {
            return null;
        }

        string coverClip = windup.AnimationClip == "player_look_right3"
            ? "player_right_coverBack3" : "player_left_coverBack3";
        return cornerQueuePoses.AnimationFrame(coverClip, tick - startTick, tick);
    }

    private BattleInfantryAnimationFrame CreateVisualFrame(string clip, float seconds, BattleInfantryAnimationWrap wrap)
    {
        var frame = new BattleInfantryAnimationFrame { SampleTick = tick };
        frame.Clips.Add(new BattleInfantryAnimationClip
        {
            ClipName = clip,
            TimeSeconds = seconds,
            Weight = 1f,
            Wrap = wrap
        });
        return frame;
    }
}
