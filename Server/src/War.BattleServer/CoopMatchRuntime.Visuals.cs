using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
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
            view.InfantryAnimation = ProjectCornerFireVisual(enemy);
        }

        return view;
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
