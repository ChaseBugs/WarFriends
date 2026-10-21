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

    /// <summary>Resolves a claimed child identity only within its live match-owned aircraft and seat binding.</summary>
    internal TransportCrewIdentity RequireTransportCrewIdentity(ulong aircraftId, int slot, ulong actorId)
    {
        if (Terminal || !_transportCrewIdentities.TryGetValue(aircraftId,
            out IReadOnlyList<TransportCrewIdentity>? identities))
        {
            throw new InvalidDataException("Transport crew identity has no live aircraft cohort.");
        }
        TransportCrewIdentity? identity = identities.SingleOrDefault(candidate => candidate.Slot == slot);
        if (identity == null || identity.EntityId != actorId)
        {
            throw new InvalidDataException("Transport crew actor does not belong to the claimed aircraft seat.");
        }
        return identity;
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
