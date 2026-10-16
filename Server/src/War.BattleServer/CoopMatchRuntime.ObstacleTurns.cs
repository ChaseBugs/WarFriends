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

            tween.AdvanceFrame(ScaledFrameSeconds);
            if (windup.HasNavigationRotationConflict)
            {
                // The source tween alone does not determine the root after native navigation writes.
                continue;
            }

            BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(row => row.EntityId == entityId &&
                row.Health > 0 && row.DeathTick == 0);
            if (enemy == null)
            {
                continue;
            }

            enemy.CurrentRotation = new BattleJointRotation
            {
                X = tween.Rotation.X, Y = tween.Rotation.Y, Z = tween.Rotation.Z, W = tween.Rotation.W
            };
            enemy.PoseTick = tick;
            stateRevision++;
        }
    }
}
