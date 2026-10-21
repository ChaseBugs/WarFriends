using War.Protocol;

namespace War.BattleServer;

/// <summary>Owns army bullet flights together with their launch authority and detached projections.</summary>
internal sealed class PvpArmyBulletSystem
{
    private readonly Dictionary<ulong, FlightState> _active = [];

    internal int Count => _active.Count;

    internal void AddActive(ulong id, ArmyProjectileFlight flight, PvpArmyBulletPayload payload)
    {
        _active.Add(id, new FlightState(flight, payload));
    }

    internal PvpArmyBulletPayload? FindPayload(ulong id)
    {
        return _active.TryGetValue(id, out FlightState state) ? state.Payload : null;
    }

    internal float? FindSpeed(ulong id)
    {
        return _active.TryGetValue(id, out FlightState state) ? state.Flight.Speed : null;
    }

    internal FlightFrame BeginFlightFrame(ulong tick)
    {
        return new FlightFrame(this, tick);
    }

    internal IEnumerable<BattleProjectileState> CreateSnapshot()
    {
        foreach (KeyValuePair<ulong, FlightState> entry in _active.OrderBy(entry => entry.Key))
        {
            ArmyProjectileFlight flight = entry.Value.Flight;
            PvpArmyBulletPayload payload = entry.Value.Payload;
            yield return new BattleProjectileState
            {
                ProjectileId = entry.Key,
                OwnerPlayerId = payload.OwnerPlayerId,
                Kind = payload.IsCosmetic ? "army-fake-bullet" : "army-bullet",
                ArmyUnitId = payload.UnitId,
                ArmySourceCardId = payload.SourceCardId,
                ArmyPoison = payload.UnitId == "ID_UNIT-COMMANDO" && payload.PoisonRatio > 0,
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

    private PvpArmyBulletStep Advance(KeyValuePair<ulong, FlightState> entry, ulong tick)
    {
        FlightState state = entry.Value;
        ArmyProjectileImpact? impact;
        try
        {
            impact = state.Flight.Advance(tick);
        }
        catch (InvalidDataException)
        {
            return new(state.Payload, null) { HasInvalidAuthority = true };
        }

        if (state.Flight.Finished)
        {
            _active.Remove(entry.Key);
        }
        return new(state.Payload, impact);
    }

    private readonly record struct FlightState(ArmyProjectileFlight Flight, PvpArmyBulletPayload Payload);

    internal struct FlightFrame
    {
        private readonly PvpArmyBulletSystem _system;
        private readonly ulong _tick;
        private readonly KeyValuePair<ulong, FlightState>[] _flights;
        private int _nextIndex;
        private bool _hasInvalidAuthority;

        internal FlightFrame(PvpArmyBulletSystem system, ulong tick)
        {
            _system = system;
            _tick = tick;
            _flights = system._active.ToArray();
            _nextIndex = 0;
            _hasInvalidAuthority = false;
        }

        internal bool TryAdvanceNext(out PvpArmyBulletStep step)
        {
            step = default;
            if (_hasInvalidAuthority || _nextIndex >= _flights.Length)
            {
                return false;
            }

            step = _system.Advance(_flights[_nextIndex++], _tick);
            _hasInvalidAuthority = step.HasInvalidAuthority;
            return true;
        }
    }
}
