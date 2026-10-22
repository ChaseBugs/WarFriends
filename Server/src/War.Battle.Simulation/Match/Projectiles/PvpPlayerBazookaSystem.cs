using War.Protocol;

namespace War.BattleServer;

/// <summary>Owns scheduled and active player missiles, frame advancement and alternating curve state.</summary>
internal sealed class PvpPlayerBazookaSystem
{
    private const int FirstSecondaryShotIndex = 1;
    private const int RealSecondaryShotIndex = 2;

    private readonly Dictionary<ulong, FlightState> _active = [];
    private readonly List<PvpBazookaLaunch> _scheduled = [];
    private ulong _curveCounter;
    private ulong _clearRevision;

    internal int Count => checked(_active.Count + _scheduled.Count);

    internal int ActiveCount => _active.Count;

    internal int ScheduledCount => _scheduled.Count;

    internal bool HasActiveOrScheduled => _active.Count != 0 || _scheduled.Count != 0;

    internal bool HasPendingLaunchFor(string owner)
    {
        return _scheduled.Any(launch => launch.Owner == owner);
    }

    internal int NextCurveSign()
    {
        return (++_curveCounter & 1) == 0 ? -1 : 1;
    }

    internal void AddActive(ulong id, BazookaMissileFlight flight, PvpBazookaPayload payload)
    {
        _active.Add(id, new FlightState(flight, payload));
    }

    internal void ScheduleRemainingShots(PvpBazookaLaunch primary, BazookaBinding binding)
    {
        // BazookaFangs schedules three secondary shots at source 0.1-second intervals,
        // alternating fake, real, fake after its immediately launched real primary.
        for (int index = FirstSecondaryShotIndex; index < binding.ProjectileCount; index++)
        {
            PvpBazookaShotKind kind = index == RealSecondaryShotIndex
                ? PvpBazookaShotKind.SecondaryReal
                : PvpBazookaShotKind.SecondaryFake;
            _scheduled.Add(primary with
            {
                LaunchTick = checked(primary.LaunchTick +
                    (ulong)Math.Ceiling(binding.ProjectileDelaySeconds * MatchManifest.TickRate * index)),
                Shot = primary.Shot with { Kind = kind }
            });
        }
    }

    internal DueLaunchFrame BeginDueLaunches(ulong tick)
    {
        return new DueLaunchFrame(this, _scheduled.Where(launch => launch.LaunchTick <= tick).ToArray());
    }

    internal ActiveFrame BeginActiveFrame(ulong tick)
    {
        return new ActiveFrame(this, tick);
    }

    internal IEnumerable<BattleProjectileState> CreateSnapshot()
    {
        foreach (KeyValuePair<ulong, FlightState> entry in _active.OrderBy(entry => entry.Key))
        {
            BazookaMissileFlight flight = entry.Value.Flight;
            yield return new BattleProjectileState
            {
                ProjectileId = entry.Key,
                OwnerPlayerId = flight.OwnerId,
                Kind = flight.Fake ? "bazooka-fake" : "bazooka",
                WeaponSourceId = entry.Value.Payload.WeaponSourceId,
                X = flight.Position.X,
                Y = flight.Position.Y,
                Z = flight.Position.Z,
                VelocityX = flight.Velocity.X,
                VelocityY = flight.Velocity.Y,
                VelocityZ = flight.Velocity.Z
            };
        }
    }

    internal void Clear()
    {
        _clearRevision = checked(_clearRevision + 1);
        _active.Clear();
        _scheduled.Clear();
        // The previous engine cleanup retained the curve counter. Do not restart its sequence here.
    }

    private PvpBazookaStep Advance(KeyValuePair<ulong, FlightState> entry, ulong tick)
    {
        FlightState state = entry.Value;
        BazookaMissileImpact? impact;
        try
        {
            impact = state.Flight.Advance(tick);
        }
        catch (Exception error) when (error is InvalidDataException or InvalidOperationException)
        {
            return new(state.Payload, null) { HasInvalidAuthority = true };
        }

        if (state.Flight.Finished)
        {
            _active.Remove(entry.Key);
        }
        return new(state.Payload, impact);
    }

    private sealed record FlightState(BazookaMissileFlight Flight, PvpBazookaPayload Payload);

    internal struct DueLaunchFrame
    {
        private readonly PvpPlayerBazookaSystem _system;
        private readonly PvpBazookaLaunch[] _launches;
        private readonly ulong _clearRevision;
        private int _nextIndex;

        internal DueLaunchFrame(PvpPlayerBazookaSystem system, PvpBazookaLaunch[] launches)
        {
            _system = system;
            _launches = launches;
            _clearRevision = system._clearRevision;
            _nextIndex = 0;
        }

        internal bool TryTakeNext(out PvpBazookaLaunch launch)
        {
            launch = null!;
            if (_clearRevision != _system._clearRevision || _nextIndex >= _launches.Length)
            {
                return false;
            }

            launch = _launches[_nextIndex++];
            // Release this reservation immediately before the engine's trusted launch callback.
            _system._scheduled.Remove(launch);
            return true;
        }
    }

    internal struct ActiveFrame
    {
        private readonly PvpPlayerBazookaSystem _system;
        private readonly ulong _tick;
        private readonly KeyValuePair<ulong, FlightState>[] _flights;
        private readonly ulong _clearRevision;
        private int _nextIndex;
        private bool _hasInvalidAuthority;

        internal ActiveFrame(PvpPlayerBazookaSystem system, ulong tick)
        {
            _system = system;
            _tick = tick;
            _flights = system._active.ToArray();
            _clearRevision = system._clearRevision;
            _nextIndex = 0;
            _hasInvalidAuthority = false;
        }

        internal bool TryAdvanceNext(out PvpBazookaStep step)
        {
            step = default;
            while (_clearRevision == _system._clearRevision && !_hasInvalidAuthority && _nextIndex < _flights.Length)
            {
                KeyValuePair<ulong, FlightState> entry = _flights[_nextIndex++];
                if (entry.Value.Flight.CurrentTick == _tick)
                {
                    continue;
                }

                step = _system.Advance(entry, _tick);
                _hasInvalidAuthority = step.HasInvalidAuthority;
                return true;
            }
            return false;
        }
    }
}
