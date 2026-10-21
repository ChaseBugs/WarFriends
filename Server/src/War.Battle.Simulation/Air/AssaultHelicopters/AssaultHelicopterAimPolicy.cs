using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// AimingHelper.PredictPosition uses gun zero's spawn point for both halves
/// of AssaultHelicopter.Shoot. The delayed half reads its target again.
/// </summary>
internal static class AssaultHelicopterAimPolicy
{
    internal static Vector3 First(Vector3 firstGunMuzzle, Vector3 target,
        Vector3 capturedVelocity, float bulletSpeed)
        => DroneShotTargetPolicy.Predict(firstGunMuzzle, target,
            capturedVelocity, bulletSpeed, 1f);

    internal static Vector3 Second(Vector3 firstGunMuzzle, Vector3 refreshedTarget,
        Vector3 capturedVelocity, float bulletSpeed, bool firstTargetIsShield)
    {
        if (!PlayerHitbox.Finite(refreshedTarget))
            throw new InvalidDataException("Invalid delayed Assault Helicopter target.");
        // The recovered callback skips prediction only when t (the first
        // target) is Shield. It still reads t2's current transform position.
        return firstTargetIsShield ? refreshedTarget :
            DroneShotTargetPolicy.Predict(firstGunMuzzle, refreshedTarget,
                capturedVelocity, bulletSpeed, 1f);
    }
}
