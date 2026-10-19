namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    /// <summary>
    /// Last accepted host pose; animation completion does not establish landing or combat eligibility.
    /// </summary>
    internal sealed record TransportCrewDescentSnapshot
    {
        internal required int Slot { get; init; }
        internal required ulong StartTick { get; init; }
        internal required ulong RenderFrame { get; init; }
        internal required ulong PhysicsSequence { get; init; }
        internal required HelicopterDescentResult Pose { get; init; }
    }

    private readonly Dictionary<(ulong EntityId, int Slot), TransportCrewDescentOwner> _transportCrewDescents = new();

    internal int TransportCrewDescentCount => _transportCrewDescents.Count;

    internal IReadOnlyList<TransportCrewDescentSnapshot> TransportCrewDescentSnapshots(ulong entityId)
    {
        return Array.AsReadOnly(_transportCrewDescents.Where(entry => entry.Key.EntityId == entityId)
            .OrderBy(entry => entry.Key.Slot).Select(entry => entry.Value.Snapshot).ToArray());
    }

    /// <summary>Starts once from host-observed entry pose at the current drop publication.</summary>
    internal void BeginTransportCrewDescent(ulong entityId, int slot, HelicopterRopeBodyPose observedRoot)
    {
        var key = (entityId, slot);
        if (Terminal || _transportCrewDescents.ContainsKey(key) ||
            !_transportCrewDrops.TryGetValue(key, out TransportCrewDrop? drop))
        {
            throw new InvalidOperationException("Crew descent requires one unconsumed live drop.");
        }
        HelicopterPhysicsWorldSnapshot physics = TransportRopeSnapshot ??
            throw new InvalidOperationException("Crew descent requires the match-owned native world.");
        HelicopterCrewDescentState state = HelicopterCrewDescentState.FromDrop(drop, observedRoot, physics);
        var snapshot = new TransportCrewDescentSnapshot
        {
            Slot = slot, StartTick = drop.StartTick, RenderFrame = physics.RenderFrames,
            PhysicsSequence = physics.PhysicsSteps,
            Pose = new HelicopterDescentResult(observedRoot.Position, observedRoot.Rotation, state.Progress),
        };
        _transportCrewDescents.Add(key, new TransportCrewDescentOwner(state, snapshot));
    }

    /// <summary>
    /// Uses this match's current native publication; pose is a host observation, never a client assertion.
    /// </summary>
    internal HelicopterDescentResult AdvanceTransportCrewDescent(ulong entityId, int slot,
        HelicopterDescentFrame observedPose, float scaledDelta)
    {
        if (Terminal || !_transportCrewDescents.TryGetValue((entityId, slot), out TransportCrewDescentOwner? owner))
        {
            throw new InvalidOperationException("Crew descent has no live match-owned start.");
        }
        HelicopterPhysicsWorldSnapshot physics = TransportRopeSnapshot ??
            throw new InvalidOperationException("Crew descent lost its match-owned native world.");
        HelicopterDescentResult result = owner.State.Advance(
            new HelicopterCrewDescentObservation(observedPose, physics, scaledDelta));
        owner.Snapshot = owner.Snapshot with
        {
            RenderFrame = physics.RenderFrames, PhysicsSequence = physics.PhysicsSteps, Pose = result,
        };
        return result;
    }

    private sealed class TransportCrewDescentOwner
    {
        internal HelicopterCrewDescentState State { get; }

        internal TransportCrewDescentSnapshot Snapshot { get; set; }

        internal TransportCrewDescentOwner(HelicopterCrewDescentState state, TransportCrewDescentSnapshot snapshot)
        {
            State = state;
            Snapshot = snapshot;
        }
    }
}
