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
        }

        return view;
    }
}
