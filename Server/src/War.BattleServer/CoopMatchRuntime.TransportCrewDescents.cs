namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private readonly Dictionary<(ulong EntityId, int Slot), HelicopterCrewDescentState> _transportCrewDescents = new();

    internal int TransportCrewDescentCount => _transportCrewDescents.Count;

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
        _transportCrewDescents.Add(key, state);
    }

    /// <summary>
    /// Uses this match's current native publication; pose is a host observation, never a client assertion.
    /// </summary>
    internal HelicopterDescentResult AdvanceTransportCrewDescent(ulong entityId, int slot,
        HelicopterDescentFrame observedPose, float scaledDelta)
    {
        if (Terminal || !_transportCrewDescents.TryGetValue((entityId, slot), out HelicopterCrewDescentState? state))
        {
            throw new InvalidOperationException("Crew descent has no live match-owned start.");
        }
        HelicopterPhysicsWorldSnapshot physics = TransportRopeSnapshot ??
            throw new InvalidOperationException("Crew descent lost its match-owned native world.");
        return state.Advance(new HelicopterCrewDescentObservation(observedPose, physics, scaledDelta));
    }
}
