using System.Numerics;
using War.BattleServer;

/// <summary>Uses synthetic host observations to check callback ownership, not actual walked positions.</summary>
internal static class CoopCrewArrivalTests
{
    internal static void VerifyIssued(CoopMatchRuntime runtime,
        CoopMatchRuntime.TransportCrewNavigationCommand command)
    {
        var observation = new CoopMatchRuntime.TransportCrewWalkObservation(
            command.IssuedRenderFrame, command.Destination + Vector3.UnitY, false);
        Reject(() => runtime.ObserveTransportCrewWalk(command with { }, observation));
        Reject(() => runtime.ObserveTransportCrewWalk(command, observation with
        {
            Frame = observation.Frame + 1,
        }));
        try
        {
            runtime.ObserveTransportCrewWalk(command, observation with { Position = new Vector3(float.NaN) });
            throw new Exception("Invalid host position was accepted.");
        }
        catch (InvalidDataException)
        {
            // Rejected input must not consume this frame's real callback.
        }

        CoopMatchRuntime.TransportCrewPointArrival? arrival = runtime.ObserveTransportCrewWalk(command, observation);
        if (command.PointComponentFileId.HasValue)
        {
            if (arrival == null || arrival.PointComponentFileId != command.PointComponentFileId ||
                arrival.ObservedPosition != observation.Position || arrival.Frame != observation.Frame ||
                arrival.State is not (CoopInfantryPointState.ObstacleHiding or CoopInfantryPointState.CornerHiding))
            {
                throw new Exception("Crew point arrival lost its authored target, frame or source state.");
            }
            VerifyEntry(runtime, command, arrival);
        }
        else if (arrival != null)
        {
            throw new Exception("Fallback walk incorrectly entered a ground-point state.");
        }
        Reject(() => runtime.ObserveTransportCrewWalk(command, observation));
    }

    private static void VerifyEntry(CoopMatchRuntime runtime,
        CoopMatchRuntime.TransportCrewNavigationCommand command, CoopMatchRuntime.TransportCrewPointArrival arrival)
    {
        const float ControllerTime = 1.25f;
        Reject(() => runtime.EnterTransportCrewPoint(command, arrival with { }, ControllerTime));
        Reject(() => runtime.EnterTransportCrewPoint(command, arrival, float.NaN));
        TransportCrewPointEntry entry = runtime.EnterTransportCrewPoint(command, arrival, ControllerTime);
        if (entry.State != arrival.State || !entry.IsAgentStopped || entry.NextShootTime < ControllerTime ||
            entry.NextEnemyChangeTime < ControllerTime + 10 || entry.NextEnemyChangeTime >= ControllerTime + 20 ||
            (entry.IsCrawling && entry.NextRepositionTime is null) ||
            (entry.IsHidingBehindCorner && entry.CornerTweenPosition?.Y != arrival.ObservedPosition.Y))
        {
            throw new Exception("Runtime point entry changed its accepted source state or scaled clocks.");
        }
        Reject(() => runtime.EnterTransportCrewPoint(command, arrival, ControllerTime));
    }

    internal static void VerifyRetired(CoopMatchRuntime runtime,
        CoopMatchRuntime.TransportCrewNavigationCommand command)
    {
        var observation = new CoopMatchRuntime.TransportCrewWalkObservation(
            command.IssuedRenderFrame, command.Destination, false);
        Reject(() => runtime.ObserveTransportCrewWalk(command, observation));
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidOperationException)
        {
            return;
        }
        throw new Exception("Obsolete, copied or repeated walking callback was accepted.");
    }
}
