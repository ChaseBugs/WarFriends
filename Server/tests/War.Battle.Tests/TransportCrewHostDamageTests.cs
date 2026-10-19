using War.BattleServer;

/// <summary>Exercises the real co-op host damage seam against a source-created crew actor.</summary>
internal static class TransportCrewHostDamageTests
{
    internal static void Verify(CoopMatchRuntime runtime, ulong aircraftId, ulong tick)
    {
        CoopMatchRuntime.TransportCrewIdentity identity = runtime.TransportCrewIdentities(aircraftId).First();
        TransportCrewActorSnapshot before = runtime.TransportCrewActor(identity.EntityId) ??
            throw new Exception("Source aircraft did not register its actor health.");
        if (runtime.ApplyHostEnemyDamage(identity.EntityId, float.NaN, tick) ||
            runtime.ApplyHostEnemyDamage(identity.EntityId, 1, tick - 1) ||
            runtime.ConfirmTransportCrewSeatReleased(identity.EntityId, tick) ||
            runtime.TransportCrewActor(identity.EntityId) != before)
        {
            throw new Exception("Invalid crew impacts or an unreserved destination changed host state.");
        }

        float firstDamage = before.Health / 2;
        if (!runtime.ApplyHostEnemyDamage(identity.EntityId, firstDamage, tick) ||
            runtime.TransportCrewActor(identity.EntityId) is not { Health: > 0, DeathTick: 0 } partial ||
            partial.Health != before.Health - firstDamage ||
            runtime.TransportCrewMembers(aircraftId)[identity.Slot].Health != partial.Health)
        {
            throw new Exception("Host crew damage did not preserve its independent source health.");
        }

        if (!runtime.ApplyHostEnemyDamage(identity.EntityId, before.Health, tick) ||
            runtime.TransportCrewActor(identity.EntityId) is not { Health: 0 } dead || dead.DeathTick != tick ||
            runtime.ApplyHostEnemyDamage(identity.EntityId, 1, tick) ||
            runtime.TransportCrewMembers(aircraftId)[identity.Slot].Health != 0)
        {
            throw new Exception("Host crew death failed confirmation, publication or duplicate protection.");
        }
    }
}
