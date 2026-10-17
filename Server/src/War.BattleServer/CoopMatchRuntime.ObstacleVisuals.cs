using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private BattleInfantryAnimationFrame? ProjectObstacleFireAnimation(BattleCoopEnemySpawn enemy)
    {
        if (phase != BattlePhase.Running || enemy.Behaviour != "Assaulter" ||
            enemy.Health <= 0f || enemy.DeathTick != 0 || enemy.CurrentRotation == null ||
            infantryPaths.ContainsKey(enemy.EntityId) || movingObstacleRepositions.Contains(enemy.EntityId) ||
            !infantryShotWindups.TryGetValue(enemy.EntityId, out CoopInfantryShotWindup? windup) ||
            windup.AnimationClip != "stand_up_begin" || windup.HasNavigationRotationConflict ||
            (windup.NextEligibleTick is ulong nextEligible && tick >= nextEligible))
        {
            return null;
        }

        if (!_obstacleCrawlStates.TryGetValue(enemy.EntityId, out ObstacleCrawlState? crawl) ||
            crawl.HasInterruptedReturn || (crawl.ReturnTick is ulong returnTick && tick >= returnTick) ||
            !infantryRoundIntents.TryGetValue(enemy.EntityId, out List<CoopInfantryRoundIntent>? rounds) ||
            rounds.Count == 0)
        {
            return null;
        }

        // ShootFromCrawl resets ordinary fire after an emitted round.
        // Preparation and crawl blends need separate frames.
        // This post-notification visual does not change the preceding gameplay muzzle observation or hit authority.
        ulong latestRoundTick = rounds[^1].Tick;
        return CreateVisualFrame("rifle_shot_loop", (tick - latestRoundTick) / (float)MatchManifest.TickRate,
            BattleInfantryAnimationWrap.ClampForever);
    }
}
