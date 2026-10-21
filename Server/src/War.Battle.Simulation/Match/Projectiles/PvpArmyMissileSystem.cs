using War.Protocol;

namespace War.BattleServer;

/// <summary>Owns paired Rocket Soldier/Mortar flights and their last source-frame impact observations.</summary>
internal sealed class PvpArmyMissileSystem
{
    private readonly Dictionary<ulong, FlightState> _active = [];
    private readonly List<CardRocketMissileImpact> _impacts = [];

    internal int Count => _active.Count;

    internal bool HasImpacts => _impacts.Count > 0;

    internal void AddActive(ulong id, CardRocketMissileFlight flight, CardRocketLaunchAuthority launch)
    {
        _active.Add(id, new FlightState(flight, launch));
    }

    internal CardRocketLaunchAuthority? FindLaunch(ulong id)
    {
        return _active.TryGetValue(id, out FlightState state) ? state.Launch : null;
    }

    internal IReadOnlyList<CardRocketMissileImpact> CreateImpactSnapshot()
    {
        return _impacts.ToArray();
    }

    internal FlightFrame BeginFlightFrame(ulong tick)
    {
        // Impact diagnostics describe the last executed source frame, including an empty cleanup frame.
        _impacts.Clear();
        return new FlightFrame(this, tick);
    }

    internal IEnumerable<BattleProjectileState> CreateSnapshot()
    {
        foreach (KeyValuePair<ulong, FlightState> entry in _active.OrderBy(entry => entry.Key))
        {
            CardRocketMissileFlight flight = entry.Value.Flight;
            CardRocketLaunchAuthority launch = entry.Value.Launch;
            yield return new BattleProjectileState
            {
                ProjectileId = entry.Key,
                OwnerPlayerId = launch.OwnerPlayerId,
                Kind = flight.IsFake ? launch.ProjectileKind + "-fake" : launch.ProjectileKind,
                ArmyUnitId = launch.Mortar == null ? "" : "ID_UNIT-MORTAR",
                X = flight.Position.X,
                Y = flight.Position.Y,
                Z = flight.Position.Z,
                VelocityX = flight.Velocity.X,
                VelocityY = flight.Velocity.Y,
                VelocityZ = flight.Velocity.Z
            };
        }
    }

    internal void ClearFlights()
    {
        // The prior terminal boundary clears active authority but retains the last impact diagnostics.
        _active.Clear();
    }

    private PvpArmyMissileStep Advance(KeyValuePair<ulong, FlightState> entry, ulong tick)
    {
        CardRocketMissileImpact? impact = entry.Value.Flight.Advance(tick);
        if (impact == null)
        {
            return new(entry.Key, entry.Value.Launch, null);
        }

        bool wasActive = _active.Remove(entry.Key, out FlightState completed);
        _impacts.Add(impact);
        if (!wasActive)
        {
            // An earlier terminal callback may have cleared later captured flights and their authority.
            throw new InvalidDataException("Card Rocket lost its launch authority.");
        }
        return new(entry.Key, completed.Launch, impact);
    }

    private readonly record struct FlightState(CardRocketMissileFlight Flight, CardRocketLaunchAuthority Launch);

    internal struct FlightFrame
    {
        private readonly PvpArmyMissileSystem _system;
        private readonly ulong _tick;
        private readonly KeyValuePair<ulong, FlightState>[] _flights;
        private int _nextIndex;

        internal FlightFrame(PvpArmyMissileSystem system, ulong tick)
        {
            _system = system;
            _tick = tick;
            _flights = system._active.OrderBy(entry => entry.Key).ToArray();
            _nextIndex = 0;
        }

        internal bool TryAdvanceNext(out PvpArmyMissileStep step)
        {
            step = default;
            if (_nextIndex >= _flights.Length)
            {
                return false;
            }
            step = _system.Advance(_flights[_nextIndex++], _tick);
            return true;
        }
    }
}
