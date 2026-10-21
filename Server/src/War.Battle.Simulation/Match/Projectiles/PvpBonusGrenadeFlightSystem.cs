using System.Collections.ObjectModel;
using War.Protocol;

namespace War.BattleServer;

/// <summary>Owns bonus/card grenade flights, next-frame collisions and completed frame observations.</summary>
internal sealed class PvpBonusGrenadeFlightSystem
{
    private readonly Dictionary<ulong, GrenadeFlight> _active = [];
    private readonly List<GrenadeFlightImpact> _pendingExplosions = [];
    private IReadOnlyList<GrenadeFlightImpact> _impacts = Array.Empty<GrenadeFlightImpact>();
    private IReadOnlyList<PvpBonusGrenadeExplosionQuote> _explosions = Array.Empty<PvpBonusGrenadeExplosionQuote>();

    internal int Count => checked(_active.Count + _pendingExplosions.Count);

    internal IReadOnlyList<GrenadeFlightImpact> Impacts => _impacts;

    internal IReadOnlyList<PvpBonusGrenadeExplosionQuote> Explosions => _explosions;

    internal void ResetIdleObservations()
    {
        _impacts = Array.Empty<GrenadeFlightImpact>();
        _explosions = Array.Empty<PvpBonusGrenadeExplosionQuote>();
    }

    internal IReadOnlyList<PvpBonusGrenadeExplosionQuote> PreparePendingExplosions(
        ulong tick, PvpBonusGrenadeBurstClock? clock, PvpBonusCatalog? catalog)
    {
        _impacts = Array.Empty<GrenadeFlightImpact>();
        var explosions = new List<PvpBonusGrenadeExplosionQuote>();
        // GrenadeAmmoBase's zero-second fuse reads shared setup in the following Update.
        // A later burst mutation must be visible here, not frozen when the flight was launched.
        foreach (GrenadeFlightImpact impact in _pendingExplosions)
        {
            explosions.Add(PvpBonusGrenadeExplosionPolicy.AfterCollision(impact,
                clock?.CurrentSharedDamage ?? throw new InvalidDataException("Shared grenade setup is missing."),
                catalog ?? throw new InvalidDataException("Bonus grenade catalog is missing."), tick));
        }

        // Validate every quote before consuming any pending collision or publishing the replacement list.
        _pendingExplosions.Clear();
        _explosions = new ReadOnlyCollection<PvpBonusGrenadeExplosionQuote>(explosions);
        return _explosions;
    }

    internal FlightFrame BeginFlightFrame(ulong tick)
    {
        // Called after pending explosions have applied their world effects, preserving the capture point.
        return new FlightFrame(this, tick);
    }

    internal void AddActive(GrenadeFlight flight)
    {
        _active.Add(flight.Id, flight);
    }

    internal IEnumerable<BattleProjectileState> CreateSnapshot()
    {
        foreach (KeyValuePair<ulong, GrenadeFlight> entry in _active.OrderBy(entry => entry.Key))
        {
            GrenadeFlight flight = entry.Value;
            yield return new BattleProjectileState
            {
                ProjectileId = entry.Key,
                OwnerPlayerId = flight.OwnerId,
                Kind = "pvp-bonus-grenade",
                X = flight.Position.X,
                Y = flight.Position.Y,
                Z = flight.Position.Z,
                VelocityX = flight.Velocity.X,
                VelocityY = flight.Velocity.Y,
                VelocityZ = flight.Velocity.Z
            };
        }
    }

    internal struct FlightFrame
    {
        private readonly PvpBonusGrenadeFlightSystem _system;
        private readonly ulong _tick;
        private readonly GrenadeFlight[] _flights;
        private readonly List<GrenadeFlightImpact> _impacts;
        private int _nextIndex;
        private bool _isPublished;
        private bool _hasFailed;

        internal FlightFrame(PvpBonusGrenadeFlightSystem system, ulong tick)
        {
            _system = system;
            _tick = tick;
            _flights = system._active.Values.ToArray();
            _impacts = new List<GrenadeFlightImpact>();
            _nextIndex = 0;
            _isPublished = false;
            _hasFailed = false;
        }

        internal bool TryAdvanceNext(out GrenadeFlightImpact impact)
        {
            if (_isPublished)
            {
                throw new InvalidOperationException("A published grenade frame cannot advance again.");
            }
            impact = null!;
            while (_nextIndex < _flights.Length)
            {
                GrenadeFlight flight = _flights[_nextIndex++];
                GrenadeFlightImpact? collision;
                try
                {
                    collision = flight.Advance(_tick);
                }
                catch
                {
                    _hasFailed = true;
                    throw;
                }
                if (collision == null)
                {
                    continue;
                }

                _system._active.Remove(flight.Id);
                _impacts.Add(collision);
                _system._pendingExplosions.Add(collision);
                impact = collision;
                return true;
            }
            return false;
        }

        internal void PublishImpacts()
        {
            if (_hasFailed || _isPublished || _nextIndex != _flights.Length)
            {
                throw new InvalidOperationException("Grenade impacts require one fully advanced frame.");
            }
            _system._impacts = new ReadOnlyCollection<GrenadeFlightImpact>(_impacts);
            _isPublished = true;
        }
    }
}
