namespace War.BattleServer;

/// <summary>Owns flame burst lifetime and separates preflight, clock commit and effect completion.</summary>
internal sealed class PvpArmyFlameSystem
{
    private readonly Dictionary<ulong, ArmyFlameBurst> _bursts = [];

    internal int Count => _bursts.Count;

    internal void StartBurst(ulong id, ulong entityKey, string ownerPlayerId, float sourceSeconds)
    {
        _bursts.Add(id, new ArmyFlameBurst(id, entityKey, ownerPlayerId, sourceSeconds));
    }

    internal IReadOnlyList<(ulong ProjectileId, int PulseIndex, float NextPulseSeconds)> CreateProgress(ulong entityKey)
    {
        return _bursts.Values.Where(burst => burst.EntityKey == entityKey).OrderBy(burst => burst.ProjectileId)
            .Select(burst => (burst.ProjectileId, burst.PulseIndex, burst.NextPulseSeconds)).ToArray();
    }

    internal PulseFrame BeginFrame(float sourceSeconds)
    {
        return new PulseFrame(this, sourceSeconds);
    }

    internal void Clear()
    {
        _bursts.Clear();
    }

    internal struct PulseFrame
    {
        private readonly PvpArmyFlameSystem _system;
        private readonly float _sourceSeconds;
        private readonly KeyValuePair<ulong, ArmyFlameBurst>[] _bursts;
        private ArmyFlameBurst? _current;
        private ulong _currentId;
        private int _nextIndex;
        private bool _isCommitted;

        internal PulseFrame(PvpArmyFlameSystem system, float sourceSeconds)
        {
            _system = system;
            _sourceSeconds = sourceSeconds;
            _bursts = system._bursts.OrderBy(entry => entry.Key).ToArray();
            _current = null;
            _currentId = 0;
            _nextIndex = 0;
            _isCommitted = false;
        }

        internal bool TryNextDue(out ArmyFlameSource source)
        {
            if (_current != null)
            {
                throw new InvalidOperationException("Finish or discard the current flame observation first.");
            }
            source = default;
            while (_nextIndex < _bursts.Length)
            {
                KeyValuePair<ulong, ArmyFlameBurst> entry = _bursts[_nextIndex++];
                if (!entry.Value.Due(_sourceSeconds))
                {
                    continue;
                }
                _current = entry.Value;
                _currentId = entry.Key;
                source = new(_current.ProjectileId, _current.EntityKey, _current.OwnerPlayerId);
                return true;
            }
            return false;
        }

        internal ArmyFlamePulse CommitCurrent()
        {
            ArmyFlameBurst current = RequireCurrent();
            if (_isCommitted)
            {
                throw new InvalidOperationException("The current flame pulse was already committed.");
            }
            // Resolve the live source/geometry first; only an accepted observation advances the source deadline.
            current.CommitPulse(_sourceSeconds);
            _isCommitted = true;
            return ArmyFlamePulse.FromBurst(current);
        }

        internal void CompleteCurrent()
        {
            ArmyFlameBurst current = RequireCurrent();
            if (!_isCommitted)
            {
                throw new InvalidOperationException("Flame world effects require a committed pulse.");
            }
            if (current.Finished)
            {
                _system._bursts.Remove(_currentId);
            }
            ResetCurrent();
        }

        internal void DiscardCurrent()
        {
            RequireCurrent();
            if (_isCommitted)
            {
                throw new InvalidOperationException("Complete a committed flame pulse instead of discarding it.");
            }
            _system._bursts.Remove(_currentId);
            ResetCurrent();
        }

        private ArmyFlameBurst RequireCurrent()
        {
            return _current ?? throw new InvalidOperationException("No captured flame observation is active.");
        }

        private void ResetCurrent()
        {
            _current = null;
            _currentId = 0;
            _isCommitted = false;
        }
    }
}
