using System.Numerics;

namespace War.BattleServer;

/// <summary>Preserves EnemyPoint.IsEnemyPointReached and WalkingUpdate's shot-preparation guard.</summary>
internal static class EnemyPointArrivalPolicy
{
    private const float ArrivalDistance = 0.04f;

    internal static bool HasReached(Vector3 position, Vector3 destination, bool isPreparingShot)
    {
        if (!PlayerHitbox.Finite(position) || !PlayerHitbox.Finite(destination))
        {
            throw new InvalidDataException("Enemy arrival requires finite host and authored point positions.");
        }

        float horizontalDifference = destination.X - position.X;
        float depthDifference = destination.Z - position.Z;
        float distanceSquared = horizontalDifference * horizontalDifference + depthDifference * depthDifference;
        if (!float.IsFinite(distanceSquared))
        {
            throw new InvalidDataException("Enemy arrival exceeds finite source planar arithmetic.");
        }

        // VectorEx.PlanarDistance ignores height; do not substitute the projected path endpoint.
        return !isPreparingShot && MathF.Sqrt(distanceSquared) < ArrivalDistance;
    }
}
