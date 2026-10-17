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
            view.InfantryAnimation = ProjectCornerAnimation(enemy);
        }

        return view;
    }

    private BattleInfantryAnimationFrame? ProjectCornerAnimation(BattleCoopEnemySpawn enemy)
    {
        if (!infantryShotWindups.TryGetValue(enemy.EntityId, out CoopInfantryShotWindup? windup) ||
            (windup.NextEligibleTick is ulong nextEligible && tick >= nextEligible))
        {
            return null;
        }
        return ReadCornerAnimation(enemy, windup);
    }

    private BattleInfantryAnimationFrame? ReadCornerAnimation(BattleCoopEnemySpawn enemy, CoopInfantryShotWindup windup)
    {
        if (!HasCornerVisualRoot(enemy, windup))
        {
            return null;
        }
        ulong returnStart = CornerCoverBackStartTick(enemy.EntityId, windup);
        if (tick >= returnStart)
        {
            if (cornerQueuePoses == null)
            {
                return null;
            }
            string cover = windup.AnimationClip == "player_look_right3"
                ? "player_right_coverBack3" : "player_left_coverBack3";
            return cornerQueuePoses.AnimationFrame(cover, tick - returnStart, tick);
        }
        if (windup.CornerPreparation == null)
        {
            return null;
        }
        if (infantryRoundIntents.TryGetValue(enemy.EntityId, out List<CoopInfantryRoundIntent>? rounds) &&
            rounds.Count > 0)
        {
            ulong lastRound = rounds[^1].Tick;
            // This is the confirmed post-notification visual. Gameplay muzzles still use their prior evaluation.
            return CreateVisualFrame(windup.QueuedFireClip,
                (tick - lastRound) / (float)MatchManifest.TickRate, BattleInfantryAnimationWrap.ClampForever);
        }
        return windup.CornerPreparation.Sample(tick - windup.StartTick, tick);
    }

    private bool HasCornerVisualRoot(BattleCoopEnemySpawn enemy, CoopInfantryShotWindup windup)
    {
        if (phase != BattlePhase.Running || enemyPoses == null || enemy.Behaviour != "Assaulter" ||
            enemy.Health <= 0f || enemy.DeathTick != 0 || enemy.CurrentRotation == null ||
            infantryPaths.ContainsKey(enemy.EntityId) || windup.HasNavigationRotationConflict ||
            windup.AnimationClip is not ("player_look_right3" or "player_look_left3") || tick <= windup.StartTick)
        {
            return false;
        }
        return enemy.PoseTick == windup.StartTick + Math.Min(tick - windup.StartTick, 9UL);
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
