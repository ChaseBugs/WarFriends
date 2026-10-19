namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private readonly Dictionary<ulong, TransportCrewActorState> _transportCrewActors = new();

    internal int TransportCrewActorCount => _transportCrewActors.Count;

    private void RegisterInitialTransportCrewActors(ulong aircraftId)
    {
        if (!transportHelicopterCrew.TryGetValue(aircraftId, out HelicopterCrewState? crew))
        {
            return;
        }

        IReadOnlyList<TransportCrewIdentity> identities = TransportCrewIdentities(aircraftId);
        IReadOnlyList<HelicopterCrewMemberSnapshot> members = crew.Snapshot();
        var actors = new List<TransportCrewActorState>(members.Count);
        foreach (TransportCrewIdentity identity in identities)
        {
            actors.Add(new TransportCrewActorState(identity, aircraftId, members[identity.Slot], tick));
        }

        // Reservations alone were not actors. Health initialization now creates the
        // initial source cohort, after its parent has entered mission accounting.
        ulong[] actorIds = actors.Select(actor => actor.EntityId).ToArray();
        if (actors.Count != members.Count ||
            actorIds.Any(actorId => _transportCrewActors.ContainsKey(actorId)) ||
            !mission.ConfirmInitialTransportCrew(aircraftId, actorIds, tick))
        {
            throw new InvalidDataException("Initial transport crew could not enter host mission accounting.");
        }

        foreach (TransportCrewActorState actor in actors)
        {
            _transportCrewActors.Add(actor.EntityId, actor);
        }
    }
}
