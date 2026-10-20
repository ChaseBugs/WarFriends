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
        VerifyAgentCallback(runtime, command);
        return command;
    }

    private static void VerifyAgentCallback(CoopMatchRuntime runtime,
        CoopMatchRuntime.TransportCrewNavigationCommand command)
    {
        Vector3 nativeDestination = command.Destination + Vector3.UnitY;
        var observation = new NavigationAgentRecoveryState.Observation
        {
            Frame = command.IssuedRenderFrame,
            WrapperIsStopped = false,
            Status = NavigationAgentRecoveryState.PathStatus.Complete,
            PathPending = false,
            PathEndPosition = command.Destination,
            NativeDestination = nativeDestination,
            RawVelocity = Vector3.Zero,
        };
        try
        {
            runtime.ObserveTransportCrewNavigationAgent(command with { }, observation);
            throw new Exception("Copied command authorized a native agent callback.");
        }
        catch (InvalidOperationException)
        {
            // The copied command must not consume the real owner's callback frame.
        }
        NavigationAgentRecoveryState.Recovery? recovery =
            runtime.ObserveTransportCrewNavigationAgent(command, observation);
        if (recovery?.NativeDestination != nativeDestination)
        {
            throw new Exception("Agent recovery replaced the native temporary destination with its final target.");
        }
        try
        {
            runtime.ObserveTransportCrewNavigationAgent(command, observation);
            throw new Exception("Duplicate native agent callback was accepted.");
        }
        catch (InvalidOperationException)
        {
            // A callback frame belongs to one source wrapper update.
        }
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
