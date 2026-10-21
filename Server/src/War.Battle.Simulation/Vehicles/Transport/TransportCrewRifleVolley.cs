using System.Numerics;

namespace War.BattleServer;

/// <summary>Executes source rifle rounds through a host weapon producer, without inventing a launch origin.</summary>
internal sealed class TransportCrewRifleVolley
{
    private const float FakeVerticalOffset = 0.5f;
    private const float NormalizeEpsilon = 0.00001f;
    private readonly CoopInfantryShotBatch _batch;
    private readonly AssaulterAimPrediction _aim;
    private readonly AssaulterWeaponFireClock _weaponClock;
    private ulong _lastFrame;
    private int _roundIndex;
    private bool _faulted;

    internal bool IsComplete => _roundIndex == _batch.Count;

    internal TransportCrewRifleVolley(CoopInfantryShotBatch batch, AssaulterAimPrediction aim,
        AssaulterWeaponFireClock weaponClock, ulong startedFrame)
    {
        ArgumentNullException.ThrowIfNull(batch);
        ArgumentNullException.ThrowIfNull(aim);
        ArgumentNullException.ThrowIfNull(weaponClock);
        if (batch.Count is < 1 or > 14 || batch.RealShotMask < 0 ||
            (batch.RealShotMask >> batch.Count) != 0 || !PlayerHitbox.Finite(aim.TargetPosition))
        {
            throw new InvalidDataException("Crew rifle volley requires a bounded source batch and finite aim.");
        }
        _batch = batch;
        _aim = aim;
        _weaponClock = weaponClock;
        _lastFrame = startedFrame;
    }

    /// <summary>Calls Weapon.Shoot before advancing cadence/counter; a throwing producer cannot be retried.</summary>
    internal bool TryFire(FireObservation observation, FakeDraws draws, Action<Round> fire)
    {
        ArgumentNullException.ThrowIfNull(observation);
        ArgumentNullException.ThrowIfNull(draws);
        ArgumentNullException.ThrowIfNull(fire);
        if (_faulted || IsComplete || observation.Frame <= _lastFrame ||
            !PlayerHitbox.Finite(observation.ActorPosition))
        {
            throw new InvalidOperationException("Crew round requires a live volley and a later source Update.");
        }
        if (!_weaponClock.CanFire(observation.GlobalTime))
        {
            _lastFrame = observation.Frame;
            return false;
        }
        bool real = (_batch.RealShotMask & (1 << _roundIndex)) != 0;
        Vector3 target = real ? _aim.TargetPosition : FakeTarget(observation.ActorPosition, draws);
        var round = new Round(_roundIndex, real, target);
        // A producer may have emitted before throwing. Retrying would risk a second authoritative projectile.
        _faulted = true;
        fire(round);
        _weaponClock.ObserveFired(observation.GlobalTime);
        _roundIndex++;
        _lastFrame = observation.Frame;
        _faulted = false;
        return true;
    }

    private Vector3 FakeTarget(Vector3 actorPosition, FakeDraws draws)
    {
        float distance = draws.Distance();
        float side = draws.Side();
        if (!float.IsFinite(distance) || distance is < 0.5f or > 1f ||
            !float.IsFinite(side) || side is < 0f or > 1f)
        {
            throw new InvalidDataException("Crew fake shot requires its source distance and side draws.");
        }
        Vector3 lateral = Vector3.Cross(actorPosition - _aim.TargetPosition, Vector3.UnitY);
        float length = lateral.Length();
        lateral = length > NormalizeEpsilon ? lateral / length * distance : Vector3.Zero;
        if (side < 0.5f)
        {
            lateral = -lateral;
        }
        Vector3 target = _aim.TargetPosition + lateral + Vector3.UnitY * FakeVerticalOffset;
        if (!PlayerHitbox.Finite(target))
        {
            throw new InvalidDataException("Crew fake target exceeded finite source coordinates.");
        }
        return target;
    }

    internal sealed record FireObservation(ulong Frame, float GlobalTime, Vector3 ActorPosition);

    internal sealed record FakeDraws(Func<float> Distance, Func<float> Side);

    /// <summary>A call to the host weapon producer; not independently a projectile or damage receipt.</summary>
    internal sealed record Round(int Index, bool Real, Vector3 TargetPosition);
}
