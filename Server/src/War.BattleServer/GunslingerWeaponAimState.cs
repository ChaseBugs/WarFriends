using System.Numerics;

namespace War.BattleServer;

internal sealed record GunslingerAimInputs(Vector3 Muzzle, Vector3 Position, Vector3 Velocity, float BulletSpeed);

internal sealed record GunslingerAimPrediction(GunslingerAimInputs Inputs, Vector3 TargetPosition);

/// <summary>Owns Colt speed changes and predicts from the current callback transform, without Corner padding.</summary>
internal sealed class GunslingerWeaponAimState
{
    private const float PlayerSpeedMultiplier = 0.5f;
    private const float EntitySpeedMultiplier = 1f;
    private const float GunFlightPaddingSeconds = 0.1f;
    private const float SelectionPaddingSeconds = 0.1f;
    private const float MaximumBulletSpeed = 10_000f;
    private readonly float _baseSpeed;
    private float _speedMultiplier = EntitySpeedMultiplier;

    internal float RealBulletSpeed => _baseSpeed * _speedMultiplier;

    internal GunslingerWeaponAimState(float baseSpeed)
    {
        ValidateSpeed(baseSpeed);
        _baseSpeed = baseSpeed;
    }

    internal GunslingerAimPrediction SelectMovingPlayer(Vector3 muzzle, Vector3 position, Vector3 velocity)
    {
        return Predict(new GunslingerAimInputs(muzzle, position, velocity, RealBulletSpeed), SelectionPaddingSeconds);
    }

    internal GunslingerAimPrediction StartPlayerShot(Vector3 muzzle, Vector3 currentPosition, Vector3 velocity)
    {
        return StartShot(new GunslingerAimInputs(muzzle, currentPosition, velocity,
            _baseSpeed * PlayerSpeedMultiplier), PlayerSpeedMultiplier);
    }

    internal GunslingerAimPrediction StartEntityShot(Vector3 muzzle, Vector3 currentPosition, Vector3 velocity)
    {
        return StartShot(new GunslingerAimInputs(muzzle, currentPosition, velocity,
            _baseSpeed * EntitySpeedMultiplier), EntitySpeedMultiplier);
    }

    private GunslingerAimPrediction StartShot(GunslingerAimInputs inputs, float multiplier)
    {
        // ShootJustStarted reads mShotTarget.transform.position again. The caller
        // supplies that current position, never the earlier predicted targetPosition.
        GunslingerAimPrediction prediction = Predict(inputs, 0f);
        _speedMultiplier = multiplier;
        return prediction;
    }

    private static GunslingerAimPrediction Predict(GunslingerAimInputs inputs, float extraSeconds)
    {
        ValidateSpeed(inputs.BulletSpeed);
        if (!PlayerHitbox.Finite(inputs.Muzzle) || !PlayerHitbox.Finite(inputs.Position) ||
            !PlayerHitbox.Finite(inputs.Velocity))
        {
            throw new InvalidDataException("Gunslinger prediction requires finite current source poses.");
        }

        float leadSeconds = Vector3.Distance(inputs.Muzzle, inputs.Position) / inputs.BulletSpeed +
            GunFlightPaddingSeconds + extraSeconds;
        Vector3 position = inputs.Position + inputs.Velocity * leadSeconds;
        if (!float.IsFinite(leadSeconds) || !PlayerHitbox.Finite(position))
        {
            throw new InvalidDataException("Gunslinger prediction exceeds finite source coordinates.");
        }

        return new GunslingerAimPrediction(inputs, position);
    }

    private static void ValidateSpeed(float speed)
    {
        if (!float.IsFinite(speed) || speed <= 0f || speed > MaximumBulletSpeed)
        {
            throw new InvalidDataException("Gunslinger requires a positive bounded source bullet speed.");
        }
    }
}
