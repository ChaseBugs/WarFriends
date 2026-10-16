using System.Numerics;

namespace War.BattleServer;

/// <summary>Provides bounded visual route facing; it does not reproduce native NavMeshAgent steering.</summary>
internal static class CoopInfantryFacingEstimate
{
    // The pinned enemy prefab's NavMeshAgent has m_AngularSpeed: 600.
    private const float SourceAngularDegreesPerSecond = 600f;
    private const float DegreesToRadians = MathF.PI / 180f;
    private const float UnitRotationTolerance = 0.0002f;

    internal static Quaternion Advance(Quaternion currentRotation, Vector3 routeDirection)
    {
        float lengthSquared = currentRotation.LengthSquared();
        if (!float.IsFinite(lengthSquared) || Math.Abs(lengthSquared - 1f) > UnitRotationTolerance ||
            !PlayerHitbox.Finite(routeDirection))
        {
            throw new InvalidDataException("Infantry facing requires a unit root and finite route direction.");
        }

        var planar = new Vector3(routeDirection.X, 0, routeDirection.Z);
        Quaternion current = Quaternion.Normalize(currentRotation);
        if (planar == Vector3.Zero)
        {
            return current;
        }

        float heading = MathF.Atan2(planar.X, planar.Z);
        Quaternion target = Quaternion.CreateFromAxisAngle(Vector3.UnitY, heading);
        float cosine = Math.Clamp(Math.Abs(Quaternion.Dot(current, target)), 0f, 1f);
        float remainingRadians = 2f * MathF.Acos(cosine);
        float maximumRadians = SourceAngularDegreesPerSecond * DegreesToRadians / MatchManifest.TickRate;
        if (remainingRadians <= maximumRadians)
        {
            return target;
        }

        return Quaternion.Normalize(Quaternion.Slerp(current, target, maximumRadians / remainingRadians));
    }
}
