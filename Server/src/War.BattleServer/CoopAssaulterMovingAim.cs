using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// The recovered Gun computes distance / bullet speed + 0.1 seconds.
/// AimingHelper adds 0.1 seconds at target selection, then the Assaulter
/// adds 0.3 seconds at the later ShootJustStarted callback.
/// The caller must supply the enemy weapon's current animated muzzle.
/// </summary>
internal static class CoopAssaulterMovingAim
{
    internal static Vector3 AtTargetSelection(Vector3 weaponMuzzle,
        Vector3 movingTarget, Vector3 targetVelocity, float bulletSpeed)
    {
        return Predict(weaponMuzzle, movingTarget, targetVelocity,
            bulletSpeed, extraLeadSeconds: 0.1f);
    }

    internal static Vector3 AtShotStart(Vector3 weaponMuzzle,
        Vector3 preparedTarget, Vector3 currentTargetVelocity,
        float bulletSpeed)
    {
        return Predict(weaponMuzzle, preparedTarget,
            currentTargetVelocity, bulletSpeed,
            extraLeadSeconds: 0.3f);
    }

    private static Vector3 Predict(Vector3 weaponMuzzle,
        Vector3 movingTarget, Vector3 targetVelocity, float bulletSpeed,
        float extraLeadSeconds)
    {
        if (!PlayerHitbox.Finite(weaponMuzzle) ||
            !PlayerHitbox.Finite(movingTarget) ||
            !PlayerHitbox.Finite(targetVelocity) ||
            !float.IsFinite(bulletSpeed) ||
            bulletSpeed is < 0.01f or > 10_000f)
            throw new InvalidDataException(
                "Co-op moving aim needs a finite host pose and bullet speed.");

        float flightSeconds = Vector3.Distance(
            weaponMuzzle, movingTarget) / bulletSpeed + 0.1f;
        float leadSeconds = flightSeconds + extraLeadSeconds;
        Vector3 predicted = movingTarget + leadSeconds * targetVelocity;
        if (!float.IsFinite(leadSeconds) ||
            !PlayerHitbox.Finite(predicted))
            throw new InvalidDataException(
                "Co-op moving aim exceeds finite source coordinates.");
        return predicted;
    }
}
