using System.Numerics;

namespace War.BattleServer;

/// <summary>Owns native rope leases and one match clock; live collision/flight/Worker registration remains separate.</summary>
internal sealed class NativeHelicopterPhysicsWorld : IDisposable
{
    private const int MaximumRopes = 64;
    private readonly object _gate = new();
    private readonly Guid _worldId = Guid.NewGuid();
    private readonly HelicopterPhysicsFrameClock _clock = new();
    private readonly SortedDictionary<ulong, Member> _members = new();
    private ulong _lastGeneration;
    private bool _hasFailed;
    private bool _isDisposed;

    internal HelicopterPhysicsLease Add(ulong entityId, HelicopterRopeInitialState initial,
        HelicopterRopeBodyPose aircraft, Quaternion attachmentConnectedRestRotation)
    {
        lock (_gate)
        {
            RequireAvailable();
            if (entityId == 0 || _members.ContainsKey(entityId) || _members.Count >= MaximumRopes)
            {
                throw new InvalidOperationException("Native world entity identity is invalid, duplicate or over capacity.");
            }
            ulong generation = checked(_lastGeneration + 1);
            var lease = new HelicopterPhysicsLease(_worldId, entityId, generation);
            var rope = new NativeHelicopterRope(initial, aircraft, attachmentConnectedRestRotation);
            try
            {
                _members.Add(entityId, new Member(lease, _clock.PhysicsSteps, rope));
            }
            catch
            {
                rope.Dispose();
                throw;
            }
            _lastGeneration = generation;
            return lease;
        }
    }

    internal void Remove(HelicopterPhysicsLease lease)
    {
        lock (_gate)
        {
            RequireAvailable();
            Member member = RequireMember(lease);
            _members.Remove(lease.EntityId);
            member.Rope.Dispose();
        }
    }

    internal void BeginExtension(HelicopterPhysicsLease lease, float targetHeight)
    {
        lock (_gate)
        {
            RequireAvailable();
            RequireMember(lease).Rope.BeginExtension(targetHeight);
        }
    }

    internal HelicopterPhysicsWorldSnapshot AdvanceFrame(float scaledDeltaTime,
        IReadOnlyList<HelicopterPhysicsRenderInput> inputs, HelicopterPhysicsMode modeAfterRender)
    {
        lock (_gate)
        {
            RequireAvailable();
            HelicopterPhysicsFrameClock.ValidateDeltaTime(scaledDeltaTime);
            _ = HelicopterPhysicsTiming.Seconds(modeAfterRender);
            HelicopterPhysicsRenderInput[] prepared = PrepareInputs(inputs);
            try
            {
                ExecutePhysics(scaledDeltaTime);
                ExecuteRender(prepared, scaledDeltaTime, modeAfterRender);
                _clock.CompleteRenderFrame();
                return CreateSnapshot();
            }
            catch
            {
                // Earlier scenes may already have advanced. Release the whole world instead of replaying a partial frame.
                _hasFailed = true;
                _clock.Fault();
                ReleaseMembers();
                throw;
            }
        }
    }

    internal HelicopterPhysicsWorldSnapshot Snapshot()
    {
        lock (_gate)
        {
            RequireAvailable();
            try
            {
                return CreateSnapshot();
            }
            catch
            {
                _hasFailed = true;
                _clock.Fault();
                ReleaseMembers();
                throw;
            }
        }
    }

    /// <summary>Releases every native scene once; disposal remains available after a failed frame.</summary>
    public void Dispose()
    {
        lock (_gate)
        {
            if (_isDisposed)
            {
                return;
            }
            _isDisposed = true;
            ReleaseMembers();
        }
    }

    private HelicopterPhysicsRenderInput[] PrepareInputs(IReadOnlyList<HelicopterPhysicsRenderInput> inputs)
    {
        ArgumentNullException.ThrowIfNull(inputs);
        if (inputs.Count != _members.Count)
        {
            throw new InvalidDataException("A render frame requires exactly one pose per owned helicopter.");
        }
        HelicopterPhysicsRenderInput[] prepared = inputs.ToArray();
        var seen = new HashSet<ulong>();
        foreach (HelicopterPhysicsRenderInput input in prepared)
        {
            if (input == null || !seen.Add(input.Lease.EntityId))
            {
                throw new InvalidDataException("A render frame contains a missing or duplicate helicopter pose.");
            }
            _ = RequireMember(input.Lease);
            NativeHelicopterRope.ValidateAircraftTransform(input.Aircraft);
            if (input.ExtensionTargetHeight is float height &&
                (!float.IsFinite(height) || !PlayerHitbox.Finite(new Vector3(0, height, 0))))
            {
                throw new InvalidDataException("A render extension target must be finite and bounded.");
            }
        }
        return prepared.OrderBy(input => input.Lease.EntityId).ToArray();
    }

    private void ExecutePhysics(float scaledDeltaTime)
    {
        _clock.BeginFrame(scaledDeltaTime);
        while (_clock.TakePhysicsStep() is HelicopterPhysicsQuantum quantum)
        {
            foreach (Member member in _members.Values)
            {
                member.Rope.SetPhysicsMode(quantum.Mode);
                member.Rope.Advance();
            }
        }
    }

    private void ExecuteRender(HelicopterPhysicsRenderInput[] inputs, float deltaTime,
        HelicopterPhysicsMode modeAfterRender)
    {
        _clock.SetPhysicsMode(modeAfterRender);
        foreach (HelicopterPhysicsRenderInput input in inputs)
        {
            NativeHelicopterRope rope = _members[input.Lease.EntityId].Rope;
            rope.SetPhysicsMode(modeAfterRender);
            rope.UpdateRenderFrame(deltaTime, input.Aircraft);
            if (input.ExtensionTargetHeight is float height)
            {
                // StopPointReached runs during Steer, after this frame's rope extension branch.
                // ShowRope can therefore enable extension only for the following render update.
                rope.BeginExtension(height);
            }
        }
    }

    private HelicopterPhysicsWorldSnapshot CreateSnapshot()
    {
        var snapshots = new List<HelicopterPhysicsMemberSnapshot>(_members.Count);
        foreach (Member member in _members.Values)
        {
            snapshots.Add(new HelicopterPhysicsMemberSnapshot(member.Lease, member.BirthPhysicsStep,
                member.Rope.StepCount, member.Rope.RenderFrameCount, member.Rope.IsExtending, member.Rope.Snapshot()));
        }
        return new HelicopterPhysicsWorldSnapshot(_clock.PhysicsSteps, _clock.RenderFrames,
            _clock.NominalPhysicsMilliseconds, snapshots.AsReadOnly());
    }

    private Member RequireMember(HelicopterPhysicsLease lease)
    {
        if (!_members.TryGetValue(lease.EntityId, out Member? member) || member.Lease != lease)
        {
            throw new InvalidOperationException("Helicopter lease is stale or belongs to another world generation.");
        }
        return member;
    }

    private void RequireAvailable()
    {
        ObjectDisposedException.ThrowIf(_isDisposed, this);
        if (_hasFailed)
        {
            throw new InvalidOperationException("A partially executed native world cannot resume or publish state.");
        }
    }

    private void ReleaseMembers()
    {
        foreach (Member member in _members.Values)
        {
            member.Rope.Dispose();
        }
        _members.Clear();
    }

    private sealed record Member(HelicopterPhysicsLease Lease, ulong BirthPhysicsStep, NativeHelicopterRope Rope);
}
