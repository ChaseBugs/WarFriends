namespace War.BattleServer;

internal sealed record TransportRopeMember(ulong EntityId, float SpawnRealtime,
    HelicopterRopeBodyPose Aircraft, CoopMatchRuntime.TransportLanding? Landing);

/// <summary>Match-owned native ropes, delayed source activation and one-shot arrival commands.</summary>
internal sealed class CoopTransportRopeWorld : IDisposable
{
    private const int ExpectedNativeAbi = 4;
    private const int MaximumRopes = 64;
    private readonly HelicopterRopeDefinition _definition;
    private readonly NativeHelicopterPhysicsWorld _world = new();
    private readonly Dictionary<ulong, Entry> _entries = new();
    private float _lastRealtime;
    private bool _isDisposed;

    internal CoopTransportRopeWorld(HelicopterRopeDefinition definition)
    {
        ArgumentNullException.ThrowIfNull(definition);
        if (NativeRopeMethods.GetAbiVersion() != ExpectedNativeAbi)
        {
            throw new InvalidOperationException("Transport ropes require the verified native physics ABI.");
        }
        _definition = definition;
    }

    internal HelicopterPhysicsWorldSnapshot Render(float realtime, float deltaTime,
        HelicopterPhysicsMode mode, IReadOnlyList<TransportRopeMember> members)
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);
        ValidateFrame(realtime, deltaTime, mode, members);
        try
        {
            SynchronizeMembers(members);
            HelicopterPhysicsRenderInput[] inputs = PrepareInputs(members);
            _world.AdvanceFrame(deltaTime, inputs, mode);
            foreach (TransportRopeMember member in members)
            {
                Entry entry = _entries[member.EntityId];
                if (entry.Activation.ActiveLease.HasValue && member.Landing != null)
                {
                    entry.HasAppliedLanding = true;
                }
                entry.Activation.TryActivateAfterRender(_world, realtime, member.Aircraft);
            }
            _lastRealtime = realtime;
            return _world.Snapshot();
        }
        catch
        {
            // A prior member may already have moved. Close the complete owner instead of replaying a partial frame.
            Dispose();
            throw;
        }
    }

    internal void Remove(ulong entityId)
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);
        if (!_entries.Remove(entityId, out Entry? entry))
        {
            return;
        }
        if (entry.Activation.ActiveLease is HelicopterPhysicsLease lease)
        {
            _world.Remove(lease);
        }
        else
        {
            entry.Activation.CancelPending();
        }
    }

    internal HelicopterPhysicsWorldSnapshot Snapshot()
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);
        return _world.Snapshot();
    }

    /// <summary>Releases active scenes and suppresses pending callbacks once.</summary>
    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }
        _isDisposed = true;
        foreach (Entry entry in _entries.Values.Where(entry => !entry.Activation.ActiveLease.HasValue))
        {
            entry.Activation.CancelPending();
        }
        _entries.Clear();
        _world.Dispose();
    }

    private void ValidateFrame(float realtime, float deltaTime, HelicopterPhysicsMode mode,
        IReadOnlyList<TransportRopeMember> members)
    {
        ArgumentNullException.ThrowIfNull(members);
        if (!float.IsFinite(realtime) || realtime < _lastRealtime || members.Count > MaximumRopes)
        {
            throw new InvalidDataException("Transport rope frame has invalid realtime or roster size.");
        }
        HelicopterPhysicsFrameClock.ValidateDeltaTime(deltaTime);
        _ = HelicopterPhysicsTiming.Seconds(mode);
        var seen = new HashSet<ulong>();
        foreach (TransportRopeMember member in members)
        {
            if (member == null || member.EntityId == 0 || !seen.Add(member.EntityId) ||
                !float.IsFinite(member.SpawnRealtime) || member.SpawnRealtime < 0 || member.SpawnRealtime > realtime)
            {
                throw new InvalidDataException("Transport rope frame has an invalid member identity or birth time.");
            }
            NativeHelicopterRope.ValidateAircraftTransform(member.Aircraft);
            if (_entries.TryGetValue(member.EntityId, out Entry? entry) && entry.SpawnRealtime != member.SpawnRealtime)
            {
                throw new InvalidDataException("An existing transport identity changed its birth time.");
            }
        }
    }

    private void SynchronizeMembers(IReadOnlyList<TransportRopeMember> members)
    {
        var present = members.Select(member => member.EntityId).ToHashSet();
        foreach (ulong entityId in _entries.Keys.Where(entityId => !present.Contains(entityId)).ToArray())
        {
            Remove(entityId);
        }
        foreach (TransportRopeMember member in members)
        {
            if (!_entries.ContainsKey(member.EntityId))
            {
                _entries.Add(member.EntityId, new Entry(member.SpawnRealtime,
                    new HelicopterRopeActivationState(_definition, member.EntityId, member.SpawnRealtime)));
            }
        }
    }

    private HelicopterPhysicsRenderInput[] PrepareInputs(IReadOnlyList<TransportRopeMember> members)
    {
        var inputs = new List<HelicopterPhysicsRenderInput>();
        foreach (TransportRopeMember member in members)
        {
            Entry entry = _entries[member.EntityId];
            if (entry.Activation.ActiveLease is not HelicopterPhysicsLease lease)
            {
                if (member.Landing != null)
                {
                    throw new InvalidDataException(
                        "Arrival before source rope activation needs separate source proof.");
                }
                continue;
            }
            bool hasArrival = member.Landing != null && !entry.HasAppliedLanding;
            inputs.Add(new HelicopterPhysicsRenderInput(lease, member.Aircraft,
                hasArrival ? member.Landing?.Surface?.Y : null,
                HasFailedLandingSample: hasArrival && member.Landing?.Surface == null));
        }
        return inputs.ToArray();
    }

    private sealed class Entry(float spawnRealtime, HelicopterRopeActivationState activation)
    {
        internal float SpawnRealtime { get; } = spawnRealtime;
        internal HelicopterRopeActivationState Activation { get; } = activation;
        internal bool HasAppliedLanding { get; set; }
    }
}
