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
        }
        else if (arrival != null)
        {
            throw new Exception("Fallback walk incorrectly entered a ground-point state.");
        }
        Reject(() => runtime.ObserveTransportCrewWalk(command, observation));
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
