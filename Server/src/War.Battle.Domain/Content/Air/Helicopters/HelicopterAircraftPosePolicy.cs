namespace War.BattleServer;

/// <summary>Managed source-pose validation; admitting content never needs a native physics lease.</summary>
internal static class HelicopterAircraftPosePolicy
{
    private const float UnitRotationTolerance = 0.0001f;

    internal static void Validate(HelicopterRopeBodyPose aircraft)
    {
        ArgumentNullException.ThrowIfNull(aircraft);
        float length = aircraft.Rotation.LengthSquared();
        if (!PlayerHitbox.Finite(aircraft.Position) || !float.IsFinite(length) ||
            MathF.Abs(length - 1) > UnitRotationTolerance)
        {
            throw new InvalidDataException("Aircraft transform requires a finite bounded unit pose.");
        }
    }
}
