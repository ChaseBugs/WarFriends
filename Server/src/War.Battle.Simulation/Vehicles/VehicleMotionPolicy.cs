using System.Numerics;

namespace War.BattleServer;

public static class VehicleMotionPolicy
{
    public static Vector3 ValidateStep(Vector3 previous, Vector3 next, float sourceSpeed)
    {
        if (!PlayerHitbox.Finite(previous) || !PlayerHitbox.Finite(next) ||
            !float.IsFinite(sourceSpeed) || sourceSpeed <= 0 || sourceSpeed > 20)
            throw new InvalidDataException("Invalid vehicle motion.");
        if (Vector3.Distance(previous, next) > sourceSpeed / MatchManifest.TickRate + .001f)
            throw new InvalidDataException("Vehicle displacement exceeds source speed.");
        return next;
    }
}
