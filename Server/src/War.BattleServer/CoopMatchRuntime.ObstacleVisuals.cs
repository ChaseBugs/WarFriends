using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private BattleInfantryAnimationFrame? ProjectObstacleAnimation(BattleCoopEnemySpawn enemy)
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

        if (!_obstacleCrawlStates.TryGetValue(enemy.EntityId, out ObstacleCrawlState? crawl) || tick < windup.StartTick)
        {
            return null;
        }

        if (crawl.HasInterruptedReturn)
        {
            // Observed visual evidence does not authorize fresh-clock hitboxes or muzzle placement.
            // The candidate selector also closes this preparation path once a new round is emitted.
            return crawl.ReturnTick == null && HasObservedPreparationOrigin(windup)
                ? ProjectObservedPreparation(enemy.EntityId) : null;
        }

        if (crawl.ReturnTick is ulong returnTick && tick >= returnTick)
        {
            // The recovered Update uses Play, so return replaces fire without a queued idle blend.
            return CreateVisualFrame("stand_up_crawl", (tick - returnTick) / (float)MatchManifest.TickRate,
                BattleInfantryAnimationWrap.ClampForever);
        }

        if (!infantryRoundIntents.TryGetValue(enemy.EntityId, out List<CoopInfantryRoundIntent>? rounds) ||
            rounds.Count == 0)
        {
            if (HasObservedPreparationOrigin(windup))
            {
                // Capture the reference now, including in retained command replies; never retime it at delivery.
                // Once the observed domain ends, absence is safer than extrapolating an unmeasured mixer pose.
                return ProjectObservedPreparation(enemy.EntityId);
            }
            return HasCompletedPriorCrawl(enemy)
                ? _obstaclePoseCatalog?.PreparationAnimationFrame(tick - windup.StartTick, tick)
                : null;
        }

        // ShootFromCrawl resets ordinary fire after an emitted round.
        // Preparation and interrupted crawl still need their own transition frames.
        // This post-notification visual does not change the preceding gameplay muzzle observation or hit authority.
        ulong latestRoundTick = rounds[^1].Tick;
        return CreateVisualFrame("rifle_shot_loop", (tick - latestRoundTick) / (float)MatchManifest.TickRate,
            BattleInfantryAnimationWrap.ClampForever);
    }
}
