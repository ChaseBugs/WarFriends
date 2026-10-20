using Google.Protobuf;
using War.BattleServer;

/// <summary>Uses synthetic signals on live native frames, without target selection or weapon firing.</summary>
internal static class CoopCrewShotCallbackRuntimeTests
{
    private const float CoroutineOrigin = 100f;
    private const int MaximumCallbackTicks = 5 * MatchManifest.TickRate;
    private const ulong ReservedFixtureActor = 1UL << 61;

    internal static CoopMatchRuntime.TransportCrewNavigationCommand Verify(CoopMatchRuntime runtime,
        CoopMatchRuntime.TransportCrewNavigationCommand command,
        CoopMatchRuntime.TransportCrewObstacleObservation pending, CoopEnemyDestinationState destinations)
    {
        Require(destinations.TryAssignHelicopterAssaulter(ReservedFixtureActor) != null,
            "Fixture needs a held alternate point for the later source change.");
        var preparation = new CoopMatchRuntime.TransportCrewPreparationObservation(
            TransportCrewObstacleClock.PreparationOutcome.Prepared, CoroutineOrigin);
        Reject(() => runtime.ObserveTransportCrewPreparation(command with { }, pending, preparation));
        byte[] before = runtime.Snapshot().ToByteArray();
        TransportCrewObstacleClock.ShotCallbackTicket ticket =
            runtime.ObserveTransportCrewPreparation(command, pending, preparation) ??
                throw new Exception("Observed preparation did not retain its callback ticket.");
        Require(runtime.Snapshot().ToByteArray().AsSpan().SequenceEqual(before),
            "Preparation observation manufactured published combat state.");
        Reject(() => runtime.ObserveTransportCrewPreparation(command, pending, preparation));
        CoopMatchRuntime.TransportCrewObstacleSnapshot prepared = runtime.TransportCrewObstacleState(command) ??
            throw new Exception("Observed source clocks are missing.");
        Require(!prepared.IsCrawling && prepared.HasPendingVolley && !prepared.IsShooting,
            "Observed preparation flags differ from source.");
        var sameFrame = new TransportCrewObstacleClock.ShotObservation(pending.Clock.Frame,
            pending.Clock.ControllerTime, ticket.CoroutineDeadline);
        Reject(() => runtime.ObserveTransportCrewShotStarted(command, ticket, sameFrame));
        TransportCrewObstacleClock.ShotObservation start = ObserveStart(runtime, command, (pending, ticket));
        Reject(() => runtime.ObserveTransportCrewShotStarted(command, ticket, start));
        Reject(() => runtime.ObserveTransportCrewShotEnded(command, ticket, start));
        // Delay a synthetic EndShooting signal to isolate a later point-change branch with real card delays.
        float endTime = MathF.Max(start.ControllerTime, prepared.NextEnemyChangeTime) + 0.1f;
        ulong elapsedTicks = (ulong)MathF.Ceiling((endTime - start.ControllerTime) * MatchManifest.TickRate);
        CoopTransportLandingTests.AdvanceTo(runtime, runtime.Snapshot().ServerTick + elapsedTicks);
        var end = new TransportCrewObstacleClock.ShotObservation(runtime.TransportRopeSnapshot!.RenderFrames,
            endTime, start.CoroutineTime + endTime - start.ControllerTime);
        before = runtime.Snapshot().ToByteArray();
        runtime.ObserveTransportCrewShotEnded(command, ticket, end);
        Require(runtime.Snapshot().ToByteArray().AsSpan().SequenceEqual(before),
            "EndShooting observation was incorrectly treated as round or damage evidence.");
        Reject(() => runtime.ObserveTransportCrewShotEnded(command, ticket, end));
        CoopMatchRuntime.TransportCrewObstacleSnapshot completed = runtime.TransportCrewObstacleState(command) ??
            throw new Exception("Completed source clock is missing.");
        Require(completed.IsCrawling && !completed.HasPendingVolley && !completed.IsShooting &&
            completed.NextShootTime > end.ControllerTime &&
            completed.NextRepositionTime == prepared.NextRepositionTime,
            "Observed return reset the wrong source flags or deadlines.");
        var update = new CoopMatchRuntime.TransportCrewObstacleObservation(
            new TransportCrewObstacleClock.Observation(end.Frame, end.ControllerTime, false, true), pending.Position);
        Require(runtime.AdvanceTransportCrewObstacle(command, update) ==
            TransportCrewObstacleClock.ActionKind.Reposition,
            "EndShooting did not allow the same Update's following obstacle state.");
        Console.WriteLine(
            "PASS: native-frame crew callback ownership and source return clocks without combat mutation.");
        CoopMatchRuntime.TransportCrewNavigationCommand current =
            runtime.TransportCrewNavigation(command.ActorEntityId) ?? throw new Exception("Crew lost navigation.");
        return VerifyPointChange(runtime, current, destinations, new ReturnContext(ticket, end, pending.Position));
    }

    private static CoopMatchRuntime.TransportCrewNavigationCommand VerifyPointChange(CoopMatchRuntime runtime,
        CoopMatchRuntime.TransportCrewNavigationCommand command, CoopEnemyDestinationState destinations,
        ReturnContext source)
    {
        Require(runtime.BeginTransportCrewNavigation(command), "Post-return reposition handoff did not begin.");
        CoopTransportLandingTests.AdvanceTo(runtime, runtime.Snapshot().ServerTick + 1);
        var observation = new CoopMatchRuntime.TransportCrewObstacleObservation(
            new TransportCrewObstacleClock.Observation(runtime.TransportRopeSnapshot!.RenderFrames,
                source.End.ControllerTime + 1f / MatchManifest.TickRate, false, true), source.RootPosition);
        Require(runtime.AdvanceTransportCrewObstacle(command, observation) ==
            TransportCrewObstacleClock.ActionKind.PointChangeRequired,
            "Post-return source clocks did not reach point-change eligibility.");
        Require(destinations.Release(ReservedFixtureActor), "Fixture alternate point was lost before its release.");
        TransportCrewPointChange.Result result = runtime.ResolveTransportCrewPointChange(command, observation);
        Require(result.Destination != null && result.Destination.PointComponentFileId != command.PointComponentFileId &&
            result.NextWalkingShotTime > observation.Clock.ControllerTime,
            "Observed source return did not bind the replacement walk and its card shot delay.");
        CoopMatchRuntime.TransportCrewNavigationCommand walk = runtime.TransportCrewNavigation(command.ActorEntityId) ??
            throw new Exception("Post-return change did not issue walking navigation.");
        Require(runtime.TransportCrewHiddenEntry(walk) == null && runtime.BeginTransportCrewNavigation(walk),
            "New walking state retained the old hidden owner.");
        Reject(() => runtime.ObserveTransportCrewWalk(walk, new CoopMatchRuntime.TransportCrewWalkObservation(
            observation.Clock.Frame, walk.Destination, false)));
        Reject(() => runtime.ResolveTransportCrewPointChange(command, observation));
        Reject(() => runtime.ObserveTransportCrewShotStarted(walk, source.Ticket, source.End with
        {
            Frame = observation.Clock.Frame,
        }));
        Console.WriteLine(
            "PASS: observed crew shot return reaches runtime point change with card delays and frame guards.");
        return walk;
    }

    private static TransportCrewObstacleClock.ShotObservation ObserveStart(CoopMatchRuntime runtime,
        CoopMatchRuntime.TransportCrewNavigationCommand command,
        (CoopMatchRuntime.TransportCrewObstacleObservation Pending,
            TransportCrewObstacleClock.ShotCallbackTicket Ticket) source)
    {
        ulong scheduledTick = runtime.Snapshot().ServerTick;
        for (int offset = 1; offset <= MaximumCallbackTicks; offset++)
        {
            CoopTransportLandingTests.AdvanceTo(runtime, scheduledTick + (ulong)offset);
            float elapsed = offset / (float)MatchManifest.TickRate;
            var observation = new TransportCrewObstacleClock.ShotObservation(
                runtime.TransportRopeSnapshot!.RenderFrames,
                source.Pending.Clock.ControllerTime + elapsed,
                CoroutineOrigin + elapsed);
            if (observation.CoroutineTime < source.Ticket.CoroutineDeadline)
            {
                Reject(() => runtime.ObserveTransportCrewShotStarted(command, source.Ticket, observation));
                continue;
            }
            runtime.ObserveTransportCrewShotStarted(command, source.Ticket, observation);
            return observation;
        }
        throw new Exception("Source callback deadline exceeded the bounded native fixture.");
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (exception is InvalidOperationException or InvalidDataException)
        {
            return;
        }
        throw new Exception("Invalid or replayed native-frame shot observation was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private sealed record ReturnContext(TransportCrewObstacleClock.ShotCallbackTicket Ticket,
        TransportCrewObstacleClock.ShotObservation End, System.Numerics.Vector3 RootPosition);
}
