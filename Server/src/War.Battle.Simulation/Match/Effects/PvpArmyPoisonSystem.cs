using System.Numerics;

namespace War.BattleServer;

/// <summary>Owns independent poison coroutines and their outstanding event reservations.</summary>
internal sealed class PvpArmyPoisonSystem
{
    private readonly Dictionary<ulong, ArmyPoisonEffect> _effects = [];

    internal int Count => _effects.Count;

    internal int PendingPulseCount
    {
        get
        {
            int count = 0;
            foreach (ArmyPoisonEffect effect in _effects.Values)
            {
                count = checked(count + effect.Remaining);
            }
            return count;
        }
    }

    internal void StartEffect(ArmyPoisonSource source, float damagePerPulse, Vector3 position, ulong impactTick)
    {
        _effects.Add(source.ProjectileId, new ArmyPoisonEffect(source.ProjectileId, source.EntityKey,
            source.AttackerPlayerId, source.VictimPlayerId, damagePerPulse, position, impactTick));
    }

    internal IReadOnlyList<(ulong ProjectileId, int Remaining)> CreateProgress(ulong entityKey)
    {
        return _effects.Values.Where(effect => effect.EntityKey == entityKey).OrderBy(effect => effect.ProjectileId)
            .Select(effect => (effect.ProjectileId, effect.Remaining)).ToArray();
    }

    internal PulseFrame BeginFrame(ulong tick)
    {
        return new PulseFrame(this, tick);
    }

    internal struct PulseFrame
    {
        private readonly PvpArmyPoisonSystem _system;
        private readonly ulong _tick;
        private readonly KeyValuePair<ulong, ArmyPoisonEffect>[] _effects;
        private ArmyPoisonEffect? _current;
        private ulong _currentId;
        private int _nextIndex;

        internal PulseFrame(PvpArmyPoisonSystem system, ulong tick)
        {
            _system = system;
            _tick = tick;
            _effects = system._effects.OrderBy(entry => entry.Key).ToArray();
            _current = null;
            _currentId = 0;
            _nextIndex = 0;
        }

        internal bool TryTakeNext(out ArmyPoisonPulse pulse)
        {
            if (_current != null)
            {
                throw new InvalidOperationException("Finish or discard the current poison observation first.");
            }
            pulse = default;
            while (_nextIndex < _effects.Length)
            {
                KeyValuePair<ulong, ArmyPoisonEffect> entry = _effects[_nextIndex++];
                // BulletPoison consumes this coroutine pulse before the engine checks the current victim.
                if (!entry.Value.TryTakePulse(_tick))
                {
                    continue;
                }
                _current = entry.Value;
                _currentId = entry.Key;
                var source = new ArmyPoisonSource(_current.ProjectileId, _current.EntityKey,
                    _current.AttackerPlayerId, _current.VictimPlayerId);
                pulse = new(source, _current.DamagePerPulse, _current.Position, _current.Remaining);
                return true;
            }
            return false;
        }

        internal void CompleteCurrent()
        {
            ArmyPoisonEffect current = RequireCurrent();
            if (current.Remaining == 0)
            {
                _system._effects.Remove(_currentId);
            }
            ResetCurrent();
        }

        internal void DiscardCurrent()
        {
            RequireCurrent();
            _system._effects.Remove(_currentId);
            ResetCurrent();
        }

        private ArmyPoisonEffect RequireCurrent()
        {
            return _current ?? throw new InvalidOperationException("No captured poison observation is active.");
        }

        private void ResetCurrent()
        {
            _current = null;
            _currentId = 0;
        }
    }
}
