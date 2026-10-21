using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    // Preserve the existing diagnostic route lookahead; it is not a recovered native steering parameter.
    private const float InfantryFacingLookDistance = 0.6f;

    private static void UpdateInfantryFacingEstimate(BattleCoopEnemySpawn enemy, CoopInfantryPathState path,
        Vector3 previousPosition, Vector3 position)
    {
        if (previousPosition.X == position.X && previousPosition.Z == position.Z)
        {
            return;
        }

        Vector3 direction = path.SmoothedPlanarDirectionAt(enemy.PoseTick, InfantryFacingLookDistance);
        var current = new Quaternion(enemy.CurrentRotation.X, enemy.CurrentRotation.Y,
            enemy.CurrentRotation.Z, enemy.CurrentRotation.W);
        Quaternion estimate = CoopInfantryFacingEstimate.Advance(current, direction);
        enemy.CurrentRotation = new BattleJointRotation
        {
            X = estimate.X, Y = estimate.Y, Z = estimate.Z, W = estimate.W
        };
    }
}
