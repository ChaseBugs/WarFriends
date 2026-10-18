using System.Numerics;

using War.Shared;

namespace War.BattleServer;

/// <summary>Owns one weapon's warning across shots, missile impacts and the soldier's later death.</summary>
internal sealed class MortarIndicatorRuntime
{
    private const ulong MaximumTick = 10000000;
    private const float MaximumStopSeconds = 1800f;
    private const float IndicatorHeight = 0.04f;
    private readonly ulong _entityKey;
    private readonly string _ownerPlayerId;
    private readonly int _ownerFraction;
    private readonly MortarIndicatorClock _clock;
    private MortarMissileLaunch? _launch;
    private ulong _lastAdvanceTick;

    internal bool IsVisible => _clock.IsVisible;

    internal MortarIndicatorRuntime(ulong entityKey, string ownerPlayerId, int ownerFraction, ulong firstLaunchTick)
        : this(new Owner(entityKey, ownerPlayerId, ownerFraction), firstLaunchTick, new MortarIndicatorClock())
    {
    }

    internal MortarIndicatorRuntime(Owner owner, ulong firstLaunchTick, MortarIndicatorClock clock)
    {
        ArgumentNullException.ThrowIfNull(owner);
        ArgumentNullException.ThrowIfNull(clock);
        if (owner.EntityKey == 0 || !Guid.TryParseExact(owner.PlayerId, "N", out _) ||
            owner.PlayerId != owner.PlayerId.ToLowerInvariant() || owner.Fraction is < 1 or > 2 ||
            firstLaunchTick == 0 || firstLaunchTick > MaximumTick)
        {
            throw new InvalidDataException("Mortar warning lost its host actor, owner or initial tick.");
        }
        _entityKey = owner.EntityKey;
        _ownerPlayerId = owner.PlayerId;
        _ownerFraction = owner.Fraction;
        _clock = clock;
        _lastAdvanceTick = firstLaunchTick - 1;
    }

    internal void BeginLaunch(MortarMissileLaunch launch)
    {
        ArgumentNullException.ThrowIfNull(launch);
        if (launch.SoldierEntityKey != _entityKey || launch.ProjectileId == 0 ||
            launch.LaunchTick != _lastAdvanceTick + 1 || launch.LaunchTick > MaximumTick ||
            _launch != null && (launch.ProjectileId <= _launch.ProjectileId ||
                launch.LaunchTick <= _launch.LaunchTick) ||
            !PlayerHitbox.Finite(launch.TargetPosition) || launch.Weapon == null ||
            !float.IsFinite(launch.Weapon.StopTime) || launch.Weapon.StopTime <= 0f ||
            launch.Weapon.StopTime > MaximumStopSeconds)
        {
            throw new InvalidDataException("Mortar warning lost its ordered frozen launch authority.");
        }
        _clock.BeginShot(launch.Weapon.StopTime);
        _launch = launch;
    }

    internal void Advance(ulong tick)
    {
        if (_launch == null || tick != _lastAdvanceTick + 1 || tick > MaximumTick)
        {
            throw new InvalidDataException("Advance each Mortar warning exactly once per simulation tick.");
        }
        _clock.Advance(1f / MatchManifest.TickRate);
        _lastAdvanceTick = tick;
    }

    internal MortarIndicatorObservation? Observe()
    {
        if (!_clock.IsVisible || _launch == null || _lastAdvanceTick < _launch.LaunchTick)
        {
            return null;
        }
        return new MortarIndicatorObservation
        {
            EntityKey = _entityKey,
            OwnerPlayerId = _ownerPlayerId,
            OwnerFraction = _ownerFraction,
            ProjectileId = _launch.ProjectileId,
            LaunchTick = _launch.LaunchTick,
            ObservedTick = _lastAdvanceTick,
            Position = _launch.TargetPosition + Vector3.UnitY * IndicatorHeight,
            StopSeconds = _launch.Weapon.StopTime,
            IsFake = _launch.IsFake,
            RotationFactor = _clock.RotationFactor,
            Scale = _clock.Scale,
            Alpha = _clock.Alpha
        };
    }

    internal sealed record Owner(ulong EntityKey, string PlayerId, int Fraction);
}
