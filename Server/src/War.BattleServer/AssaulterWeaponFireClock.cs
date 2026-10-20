namespace War.BattleServer;

/// <summary>Retains Gun's global-time cadence across volleys; readiness is not evidence of a projectile.</summary>
internal sealed class AssaulterWeaponFireClock
{
    private readonly float _cadenceSeconds;
    private float _lastObservedTime;
    private float _lastShotTime;

    internal AssaulterWeaponFireClock(float cadenceSeconds)
    {
        if (!float.IsFinite(cadenceSeconds) || cadenceSeconds <= 0)
        {
            throw new InvalidDataException("Assaulter cadence must be a positive finite source duration.");
        }
        _cadenceSeconds = cadenceSeconds;
    }

    internal bool CanFire(float globalTime)
    {
        RequireTime(globalTime);
        // Gun.willShoot uses >, with float addition. Equality must wait for another Update.
        return globalTime > _lastShotTime + _cadenceSeconds;
    }

    /// <summary>Records completed Weapon.Shoot execution, including source pool-allocation failure.</summary>
    internal void ObserveFired(float globalTime)
    {
        if (!CanFire(globalTime))
        {
            throw new InvalidOperationException("Assaulter fire execution preceded its source cadence.");
        }
        _lastShotTime = globalTime;
    }

    private void RequireTime(float globalTime)
    {
        if (!float.IsFinite(globalTime) || globalTime < _lastObservedTime)
        {
            throw new InvalidDataException("Assaulter weapon time must be finite, nonnegative and monotonic.");
        }
        _lastObservedTime = globalTime;
    }
}
