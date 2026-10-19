using System.Numerics;

namespace War.BattleServer;

/// <summary>Places a sampled palm at original unit scale without granting descent or landing authority.</summary>
internal static class HelicopterPalmFramePlacement
{
    private const float RotationTolerance = 0.0001f;

    internal static HelicopterDescentFrame Create(
        Vector3 localPalm, Vector3 rootPosition, Quaternion rootRotation, Vector3 helicopterRight)
    {
        float rotationLength = rootRotation.LengthSquared();
        if (!PlayerHitbox.Finite(localPalm) || !PlayerHitbox.Finite(rootPosition) ||
            !PlayerHitbox.Finite(helicopterRight) || !float.IsFinite(rotationLength) ||
            MathF.Abs(rotationLength - 1f) > RotationTolerance)
        {
            throw new InvalidDataException("Invalid sampled Helicopter palm placement.");
        }
        Vector3 palm = rootPosition + Vector3.Transform(localPalm, rootRotation);
        if (!PlayerHitbox.Finite(palm))
        {
            throw new InvalidDataException("Helicopter palm placement overflow.");
        }
        return new HelicopterDescentFrame(rootPosition, rootRotation, palm, helicopterRight);
    }
}
