using System.Numerics;

namespace War.BattleServer;

internal sealed record AssaulterAimInputs(Vector3 Muzzle, Vector3 InputPosition, Vector3 Velocity, float BulletSpeed);

internal sealed record AssaulterAimPrediction(AssaulterAimInputs Inputs, Vector3 TargetPosition);

/// <summary>Owns the source BulletSetup speed multiplier across target selection and shot-start callbacks.</summary>
internal sealed class AssaulterWeaponAimState
{
    private const float PlayerSpeedMultiplier = 1f;
    private const float EntitySpeedMultiplier = 3f;
    private readonly CoopAssaulterWeaponCatalog _source;
    private float _speedMultiplier = PlayerSpeedMultiplier;

    internal float RealBulletSpeed => _source.RealBulletSpeed * _speedMultiplier;

    // BulletSetup.fakeSpeed reads speed * fakeSpeedFactor, not speedMultiplayer.
    internal float FakeBulletSpeed => _source.FakeBulletSpeed;

    internal AssaulterWeaponAimState(CoopAssaulterWeaponCatalog source)
    {
        _source = source ?? throw new ArgumentNullException(nameof(source));
    }

    internal AssaulterAimPrediction SelectMovingPlayer(Vector3 muzzle, Vector3 position, Vector3 velocity)
    {
        float speed = RealBulletSpeed;
        Vector3 predicted = CoopAssaulterMovingAim.AtTargetSelection(muzzle, position, velocity, speed);
        return new AssaulterAimPrediction(new AssaulterAimInputs(muzzle, position, velocity, speed), predicted);
    }

    internal AssaulterAimPrediction StartPlayerShot(Vector3 muzzle, Vector3 preparedPosition, Vector3 velocity)
    {
        return StartShot(muzzle, preparedPosition, velocity, PlayerSpeedMultiplier);
    }

    internal AssaulterAimPrediction StartEntityShot(Vector3 muzzle, Vector3 preparedPosition, Vector3 velocity)
    {
        return StartShot(muzzle, preparedPosition, velocity, EntitySpeedMultiplier);
    }

    private AssaulterAimPrediction StartShot(Vector3 muzzle, Vector3 preparedPosition, Vector3 velocity,
        float multiplier)
    {
        float speed = _source.RealBulletSpeed * multiplier;
        Vector3 predicted = CoopAssaulterMovingAim.AtShotStart(muzzle, preparedPosition, velocity, speed);
        // Validate the complete calculation before changing mutable weapon authority.
        _speedMultiplier = multiplier;
        return new AssaulterAimPrediction(new AssaulterAimInputs(muzzle, preparedPosition, velocity, speed), predicted);
    }
}
