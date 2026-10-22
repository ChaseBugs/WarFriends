using War.Protocol;

namespace War.BattleServer;

/// <summary>Owns equipped player grenade flight membership, advancement and detached observations.</summary>
internal sealed class PvpPlayerGrenadeSystem
{
    private readonly Dictionary<ulong, FlightState> _active = [];

    internal int Count => _active.Count;

    internal void AddActive(ulong id, GrenadeFlight flight, PvpGrenadePayload payload)
    {
        _active.Add(id, new FlightState(flight, payload));
    }

    internal FlightFrame BeginFlightFrame(ulong tick)
    {
        return new FlightFrame(this, tick);
    }

    internal IEnumerable<BattleProjectileState> CreateSnapshot()
    {
        foreach (KeyValuePair<ulong, FlightState> entry in _active.OrderBy(entry => entry.Key))
        {
            GrenadeFlight flight = entry.Value.Flight;
            yield return new BattleProjectileState
            {
                ProjectileId = entry.Key,
                OwnerPlayerId = flight.OwnerId,
                Kind = entry.Value.Payload.Binding.Effect == RecoveredGrenadeEffect.Molotov
                    ? "grenade-molotov" : "grenade",
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
        _active.Clear();
    }

    private PvpGrenadeStep Advance(KeyValuePair<ulong, FlightState> entry, ulong tick)
    {
        FlightState state = entry.Value;
        GrenadeFlightImpact? impact;
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

    private sealed record FlightState(GrenadeFlight Flight, PvpGrenadePayload Payload);

    internal struct FlightFrame
    {
        private readonly PvpPlayerGrenadeSystem _system;
        private readonly ulong _tick;
        private readonly KeyValuePair<ulong, FlightState>[] _flights;
        private int _nextIndex;
        private bool _hasInvalidAuthority;

        internal FlightFrame(PvpPlayerGrenadeSystem system, ulong tick)
        {
            _system = system;
            _tick = tick;
            _flights = system._active.ToArray();
            _nextIndex = 0;
            _hasInvalidAuthority = false;
        }

        internal bool TryAdvanceNext(out PvpGrenadeStep step)
        {
            step = default;
            while (!_hasInvalidAuthority && _nextIndex < _flights.Length)
            {
                KeyValuePair<ulong, FlightState> entry = _flights[_nextIndex++];
                // End() clears projectile authority before freezing terminal evidence.
                // A previously captured frame must not simulate removed or replacement flights.
                if (!_system._active.TryGetValue(entry.Key, out FlightState? current) ||
                    !ReferenceEquals(current, entry.Value))
                {
                    continue;
                }
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
