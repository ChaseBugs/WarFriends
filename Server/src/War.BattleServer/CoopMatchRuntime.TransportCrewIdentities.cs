namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    /// <summary>
    /// Reserved secondary identity; it does not imply combat registration or a confirmed mission spawn.
    /// </summary>
    internal sealed record TransportCrewIdentity(ulong EntityId, int Slot, int PointComponentFileId);

    private readonly Dictionary<ulong, IReadOnlyList<TransportCrewIdentity>> _transportCrewIdentities = new();

    internal IReadOnlyList<TransportCrewIdentity> TransportCrewIdentities(ulong aircraftId)
    {
        return _transportCrewIdentities.GetValueOrDefault(aircraftId) ?? Array.Empty<TransportCrewIdentity>();
    }

    private void ReserveTransportCrewIdentities(ulong aircraftId, HelicopterCrewState crew)
    {
        if (_transportCrewIdentities.ContainsKey(aircraftId))
        {
            throw new InvalidOperationException("Transport crew identity reservation cannot replace a live cohort.");
        }
        IReadOnlyList<HelicopterCrewMemberSnapshot> members = crew.Snapshot();
        IReadOnlyList<ulong> identities = _enemyIds.Reserve(members.Count);
        TransportCrewIdentity[] rows = members.Select((member, index) =>
            new TransportCrewIdentity(identities[index], member.Slot, member.PointComponentFileId)).ToArray();
        _transportCrewIdentities.Add(aircraftId, Array.AsReadOnly(rows));
    }
}
