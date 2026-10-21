using War.Protocol;

namespace War.BattleServer;

/// <summary>Owns player bullet membership, flight advancement, completion and detached observations.</summary>
internal sealed class PvpPlayerBulletSystem
{
    private readonly Dictionary<ulong, PreparedProjectile> _real = [];
    private readonly Dictionary<ulong, ShotgunFakePelletFlight> _cosmetic = [];

    internal int Count => checked(_real.Count + _cosmetic.Count);

    internal bool HasActiveFlights => _real.Count != 0 || _cosmetic.Count != 0;

    internal void AddReal(ulong projectileId, PreparedProjectile projectile)
    {
        // The engine validates the complete volley before ammo/identity/event publication.
        _real.Add(projectileId, projectile);
    }

    internal void AddCosmetic(ulong projectileId, ShotgunFakePelletFlight projectile)
    {
        _cosmetic.Add(projectileId, projectile);
    }

    internal RealFrame BeginRealFrame(ulong tick)
    {
        // Retain the original insertion-order snapshot. A later impact may end the match or launch
        // another effect; newly inserted flights must not join this already-started frame.
        return new RealFrame(this, tick, _real.ToArray());
    }

    internal bool AdvanceCosmetic(ulong tick)
    {
        foreach (KeyValuePair<ulong, ShotgunFakePelletFlight> entry in _cosmetic.ToArray())
        {
            try
            {
                entry.Value.Advance(tick);
            }
            catch (InvalidDataException)
            {
                return false;
            }

            if (entry.Value.Finished)
            {
                _cosmetic.Remove(entry.Key);
            }
        }
        return true;
    }

    internal IEnumerable<BattleProjectileState> CreateRealShotgunSnapshot()
    {
        foreach (KeyValuePair<ulong, PreparedProjectile> entry in _real.OrderBy(entry => entry.Key))
        {
            PreparedProjectile projectile = entry.Value;
            if (!projectile.WeaponSourceId.StartsWith("Google2u.Shotgun_", StringComparison.Ordinal))
            {
                continue;
            }

            yield return new BattleProjectileState
            {
                ProjectileId = entry.Key,
                OwnerPlayerId = projectile.Flight.OwnerId,
                Kind = "shotgun-bullet",
                WeaponSourceId = projectile.WeaponSourceId,
                X = projectile.Flight.Position.X,
                Y = projectile.Flight.Position.Y,
                Z = projectile.Flight.Position.Z,
                VelocityX = projectile.Flight.Velocity.X,
                VelocityY = projectile.Flight.Velocity.Y,
                VelocityZ = projectile.Flight.Velocity.Z
            };
        }
    }

    internal IEnumerable<BattleProjectileState> CreateCosmeticSnapshot()
    {
        foreach (KeyValuePair<ulong, ShotgunFakePelletFlight> entry in _cosmetic.OrderBy(entry => entry.Key))
        {
            ShotgunFakePelletFlight projectile = entry.Value;
            yield return new BattleProjectileState
            {
                ProjectileId = entry.Key,
                OwnerPlayerId = projectile.OwnerId,
                Kind = "shotgun-fake-bullet",
                WeaponSourceId = projectile.WeaponSourceId,
                X = projectile.Position.X,
                Y = projectile.Position.Y,
                Z = projectile.Position.Z,
                VelocityX = projectile.Velocity.X,
                VelocityY = projectile.Velocity.Y,
                VelocityZ = projectile.Velocity.Z
            };
        }
    }

    internal void Clear()
    {
        _real.Clear();
        _cosmetic.Clear();
    }

    private PvpBulletStep AdvanceRealShot(KeyValuePair<ulong, PreparedProjectile> entry, ulong tick)
    {
        PreparedProjectile projectile = entry.Value;
        BulletImpact? impact;
        try
        {
            impact = projectile.Flight.Advance(tick);
        }
        catch (InvalidDataException)
        {
            return new(entry.Key, projectile.Damage, projectile.WeaponSourceId, null)
            {
                HasInvalidAuthority = true
            };
        }

        if (projectile.Flight.Finished)
        {
            // Completion is committed before world impact callbacks, as in the previous engine loop.
            _real.Remove(entry.Key);
        }
        return new(entry.Key, projectile.Damage, projectile.WeaponSourceId, impact);
    }

    /// <summary>Consumes one captured frame without iterator boxing or a new object per flight step.</summary>
    internal struct RealFrame
    {
        private readonly PvpPlayerBulletSystem _system;
        private readonly ulong _tick;
        private readonly KeyValuePair<ulong, PreparedProjectile>[] _shots;
        private int _nextIndex;
        private bool _hasInvalidAuthority;

        internal RealFrame(PvpPlayerBulletSystem system, ulong tick, KeyValuePair<ulong, PreparedProjectile>[] shots)
        {
            _system = system;
            _tick = tick;
            _shots = shots;
            _nextIndex = 0;
            _hasInvalidAuthority = false;
        }

        internal bool TryAdvanceNext(out PvpBulletStep step)
        {
            step = default;
            if (_hasInvalidAuthority || _nextIndex >= _shots.Length)
            {
                return false;
            }

            step = _system.AdvanceRealShot(_shots[_nextIndex], _tick);
            _nextIndex++;
            _hasInvalidAuthority = step.HasInvalidAuthority;
            return true;
        }
    }
}
