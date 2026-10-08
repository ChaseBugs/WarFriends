using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// The recovered EnemyController.PrepareToShoot corner gate. This checks only
/// whether a chosen target is on the exposed side of a source corner point.
/// It does not authorize a projectile or advance the AI firing animation.
/// </summary>
internal static class CoopCornerShotPolicy
{
    internal static bool CanExpose(CoopEnemyPoint point,
        Vector3 enemyPosition, Vector3 targetPosition)
    {
        if (point.ComponentType != "EnemyPointCorner" ||
            point.CornerDirection is not Vector3 direction ||
            point.CornerRightSide is not bool rightSide ||
            !PlayerHitbox.Finite(enemyPosition) ||
            !PlayerHitbox.Finite(targetPosition))
            return false;

        Vector3 from = -direction;
        Vector3 to = targetPosition - enemyPosition;
        if (from.LengthSquared() < 0.0001f ||
            to.LengthSquared() < 0.0001f)
            return false;

        float crossY = Vector3.Cross(from, to).Y;
        float dot = Vector3.Dot(from, to);
        float angleDegrees = MathF.Atan2(crossY, dot) * 57.29578f;
        return (angleDegrees > 0f) == rightSide &&
            MathF.Abs(angleDegrees) >= 10f;
    }
}
