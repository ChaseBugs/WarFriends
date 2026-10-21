using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private CoopCornerPreparationPlan? CaptureCornerPreparation(BattleCoopEnemySpawn enemy,
        CoopInfantryPointArrival arrival, string lookClip, string fireClip)
    {
        if (arrival.State != CoopInfantryPointState.CornerHiding || enemyPoses == null)
        {
            return null;
        }
        string coverClip = lookClip == "player_look_right3" ? "player_right_coverBack3" : "player_left_coverBack3";
        var clips = new CoopCornerPreparationPlan.Clips(lookClip, fireClip,
            enemyPoses.Clip(lookClip).Length, enemyPoses.Clip(coverClip).Length);
        if (!infantryShotWindups.TryGetValue(enemy.EntityId, out CoopInfantryShotWindup? previous))
        {
            return tick >= arrival.Tick + CornerEntryTweenTicks ? CoopCornerPreparationPlan.FromIdle(clips) : null;
        }

        // Read the previous hide deadline before its round ledger is cleared by the new volley.
        BattleInfantryAnimationFrame? before = ReadCornerAnimation(enemy, previous);
        return before == null ? null : CoopCornerPreparationPlan.FromFrame(clips, before);
    }
}
