using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private const float SourceObstacleTurnSeconds = 0.2f;
    private const float ScaledFrameSeconds = 1f / MatchManifest.TickRate;
    private readonly Dictionary<ulong, CoopShotRootTween> _obstacleRootTweens = [];

    private void BeginObstacleRootTween(ulong entityId, CoopInfantryShotWindup windup)
    {
        if (windup.AnimationClip != "stand_up_begin")
        {
            return;
        }

        if (!_obstacleRootTweens.TryGetValue(entityId, out CoopShotRootTween? tween))
        {
            tween = new CoopShotRootTween(SourceObstacleTurnSeconds);
            _obstacleRootTweens.Add(entityId, tween);
        }

        tween.Begin(windup.StartRootRotation, windup.FinalRootRotation);
    }

    private void AdvanceObstacleRootTweens()
    {
        foreach ((ulong entityId, CoopShotRootTween tween) in _obstacleRootTweens)
        {
            if (!tween.IsRunning || !infantryShotWindups.TryGetValue(entityId, out CoopInfantryShotWindup? windup) ||
                windup.AnimationClip != "stand_up_begin" || tick <= windup.StartTick)
            {
                continue;
            }

            if (windup.HasNavigationRotationConflict)
            {
                // The source tween alone does not determine the root after native navigation writes.
                tween.AdvanceFrame(ScaledFrameSeconds);
                continue;
            }

            BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(row => row.EntityId == entityId &&
                row.Health > 0 && row.DeathTick == 0);
            if (enemy == null)
            {
                tween.AdvanceFrame(ScaledFrameSeconds);
                continue;
            }

            var rootBeforeUpdate = new Quaternion(enemy.CurrentRotation.X, enemy.CurrentRotation.Y,
                enemy.CurrentRotation.Z, enemy.CurrentRotation.W);
            Quaternion root = CoopShotRootComposition.AfterFrame(tween, rootBeforeUpdate, ScaledFrameSeconds);
            enemy.CurrentRotation = new BattleJointRotation
            {
                X = root.X, Y = root.Y, Z = root.Z, W = root.W
            };
            enemy.PoseTick = tick;
            stateRevision++;
        }
    }
}
