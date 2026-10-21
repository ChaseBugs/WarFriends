using System.Numerics;

namespace War.BattleServer;

/// <summary>Pure GrenadeAmmoBase launch calculation shared by recovered source definitions and flights.</summary>
internal static class GrenadeBallistics
{
    internal const float Gravity = 9.81f;
    private const float TargetHeightOffset = 0.2f;
    private const float MinimumVelocitySquared = 1e-10f;

    internal static Vector3 CalculateVelocity(Vector3 origin, Vector3 target, float angleDegrees)
    {
        if (!PlayerHitbox.Finite(origin) || !PlayerHitbox.Finite(target) ||
            !float.IsFinite(angleDegrees) || angleDegrees is <= 0f or >= 90f)
        {
            throw new InvalidDataException("Invalid grenade ballistic input.");
        }

        target += TargetHeightOffset * Vector3.UnitY;
        Vector3 direction = target - origin;
        float height = Math.Max(direction.Y, 0);
        direction.Y = 0;
        float planarDistance = direction.Length();
        float angle = angleDegrees * MathF.PI / 180;
        direction.Y = planarDistance * MathF.Tan(angle);
        float adjustedDistance = planarDistance + height / MathF.Tan(angle);
        float denominator = MathF.Sin(2 * angle);
        if (planarDistance <= 0 || adjustedDistance < 0 || denominator <= 0)
        {
            throw new InvalidDataException("Degenerate grenade trajectory.");
        }

        float speed = MathF.Sqrt(adjustedDistance * Gravity / denominator);
        Vector3 velocity = speed * Vector3.Normalize(direction);
        if (!PlayerHitbox.Finite(velocity) || velocity.LengthSquared() < MinimumVelocitySquared)
        {
            throw new InvalidDataException("Invalid grenade ballistic velocity.");
        }
        return velocity;
    }
}
