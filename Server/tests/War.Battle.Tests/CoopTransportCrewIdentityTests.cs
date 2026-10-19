using War.BattleServer;

/// <summary>
/// Checks child identity claims against the actual match cohort rather than caller-provided actor IDs.
/// </summary>
internal static class CoopTransportCrewIdentityTests
{
    internal static void VerifyClaims(CoopMatchRuntime runtime, ulong aircraftId,
        IReadOnlyList<CoopMatchRuntime.TransportCrewIdentity> identities)
    {
        foreach (CoopMatchRuntime.TransportCrewIdentity identity in identities)
        {
            Require(runtime.RequireTransportCrewIdentity(aircraftId, identity.Slot, identity.EntityId) == identity,
                "Reserved crew actor could not resolve its own live aircraft/seat binding.");
        }
        CoopMatchRuntime.TransportCrewIdentity first = identities[0];
        Action[] invalid =
        {
            () => runtime.RequireTransportCrewIdentity(0, first.Slot, first.EntityId),
            () => runtime.RequireTransportCrewIdentity(aircraftId, -1, first.EntityId),
            () => runtime.RequireTransportCrewIdentity(aircraftId, first.Slot, 0),
            () => runtime.RequireTransportCrewIdentity(aircraftId, first.Slot, aircraftId),
        };
        foreach (Action action in invalid)
        {
            Reject(action);
        }
        if (identities.Count > 1)
        {
            Reject(() => runtime.RequireTransportCrewIdentity(aircraftId, first.Slot, identities[1].EntityId));
        }
        Require(runtime.RequireTransportCrewIdentity(aircraftId, first.Slot, first.EntityId) == first,
            "Rejected child identity claim changed the accepted cohort binding.");
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new Exception("Crew identity claim accepted a missing aircraft, wrong seat or substituted actor.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
