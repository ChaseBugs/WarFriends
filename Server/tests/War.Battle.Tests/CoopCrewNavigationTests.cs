using System.Numerics;
using War.BattleServer;

/// <summary>Checks captured navigation input ownership without inventing an agent pose or arrival.</summary>
internal static class CoopCrewNavigationTests
{
    internal static CoopMatchRuntime.TransportCrewNavigationCommand VerifyIssued(CoopMatchRuntime runtime,
        ulong actorId, HelicopterCrewRetryObservation observation, CoopHelicopterExitTarget target)
    {
        CoopMatchRuntime.TransportCrewNavigationCommand command = runtime.TransportCrewNavigation(actorId) ??
            throw new Exception("Source crew transition lost its navigation handoff.");
        Vector3 expectedDestination = target switch
        {
            CoopHelicopterEnemyTarget point => point.Destination.Position,
            CoopHelicopterFallbackTarget fallback => fallback.Spawn.Position,
            _ => throw new Exception("Unknown fixture navigation target."),
        };
        int? expectedPoint = target is CoopHelicopterEnemyTarget assigned
            ? assigned.Destination.PointComponentFileId : null;
        ulong parentId = runtime.Snapshot().Coop.EnemySpawns
            .Single(parent => parent.CrewActors.Any(actor => actor.EntityId == actorId)).EntityId;
        if (command.ActorEntityId != actorId || command.OriginalAircraftId != parentId ||
            command.StartPosition != observation.Position ||
            command.Destination != expectedDestination || command.PointComponentFileId != expectedPoint ||
            command.IssuedTick != runtime.Snapshot().ServerTick || command.IssuedRenderFrame != observation.Frame ||
            command.IssuedPhysicsSequence != runtime.TransportRopeSnapshot!.PhysicsSteps ||
            command.MaximumSpeed <= 0 || command.StoppingDistance != 0 ||
            !runtime.IsTransportCrewNavigationCurrent(command))
        {
            throw new Exception("Navigation handoff changed its accepted root, target or source movement inputs.");
        }

        if (runtime.BeginTransportCrewNavigation(command with { }) ||
            !runtime.BeginTransportCrewNavigation(command) || runtime.BeginTransportCrewNavigation(command))
        {
            throw new Exception("Crew navigation accepted a copied handoff or began its current input twice.");
        }
        return command;
    }

    internal static void VerifyRetired(CoopMatchRuntime runtime,
        CoopMatchRuntime.TransportCrewNavigationCommand previous)
    {
        if (runtime.IsTransportCrewNavigationCurrent(previous) || runtime.BeginTransportCrewNavigation(previous))
        {
            throw new Exception("Retired or superseded crew navigation remained consumable.");
        }
    }
}
