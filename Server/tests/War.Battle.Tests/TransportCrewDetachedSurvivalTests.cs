using War.BattleServer;

/// <summary>Checks shared scene-point ownership and actor lifetime across actual parent destruction.</summary>
internal static class TransportCrewDetachedSurvivalTests
{
    internal static void Verify(CoopMatchRuntime runtime, CoopEnemyDestinationState destinations,
        ulong aircraftId, ulong tick)
    {
        CoopMatchRuntime.TransportCrewIdentity[] identities = runtime.TransportCrewIdentities(aircraftId).ToArray();
        ulong detachedId = identities[0].EntityId;
        TransportCrewActorSnapshot before = runtime.TransportCrewActor(detachedId) ??
            throw new Exception("Detached-survival fixture lost its initial actor.");
        CoopAssignedEnemyDestination destination = destinations.TryAssignHelicopterAssaulter(detachedId) ??
            throw new Exception("Source map has no free Assaulter destination for the survival fixture.");
        if (!runtime.ConfirmTransportCrewSeatReleased(detachedId, tick) ||
            runtime.ConfirmTransportCrewSeatReleased(detachedId, tick) ||
            runtime.TransportCrewMembers(aircraftId)[0].IsAttached ||
            runtime.AttachedTransportCrewPoses(aircraftId).Any(pose => pose.Slot == 0))
        {
            throw new Exception("A confirmed scene destination did not release the source seat exactly once.");
        }

        var aircraft = runtime.Snapshot().Coop.EnemySpawns.Single(enemy => enemy.EntityId == aircraftId);
        if (!runtime.ApplyHostEnemyDamage(aircraftId, aircraft.MaxHealth, tick) ||
            runtime.TransportCrewActor(detachedId) is not { IsAttached: false, DeathTick: 0 } survivor ||
            survivor.Health != before.Health || destinations.ForEnemy(detachedId) != destination ||
            identities.Skip(1).Any(identity => runtime.TransportCrewActor(identity.EntityId) is not { Health: 0 }))
        {
            throw new Exception("Parent destruction killed detached crew, lost its point, or spared attached crew.");
        }

        if (!runtime.ApplyHostEnemyDamage(detachedId, before.Health, tick) ||
            runtime.TransportCrewActor(detachedId) is not { Health: 0 } ||
            destinations.ForEnemy(detachedId) != null || runtime.ApplyHostEnemyDamage(detachedId, 1, tick))
        {
            throw new Exception("Detached actor lost independent damage, one-time death or destination cleanup.");
        }
        var publishedParent = runtime.Snapshot().Coop.EnemySpawns.Single(enemy => enemy.EntityId == aircraftId);
        if (publishedParent.CrewActors.Any(actor => actor.Health != 0) ||
            publishedParent.CrewActors.Single(actor => actor.EntityId == detachedId).IsAttached)
        {
            throw new Exception("Detached actor death was lost after its parent's active registry was removed.");
        }
    }
}
