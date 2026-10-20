using System.Numerics;
using War.BattleServer;

/// <summary>Checks real source destination mutation with synthetic host roots, not a walking motor.</summary>
internal static class CoopCrewObstacleRuntimeTests
{
    internal static CoopMatchRuntime.TransportCrewNavigationCommand VerifyReposition(CoopMatchRuntime runtime,
        CoopMatchRuntime.TransportCrewNavigationCommand previous, CoopEnemyDestinationState destinations)
    {
        TransportCrewPointEntry entry = runtime.TransportCrewHiddenEntry(previous) ??
            throw new Exception("Crew obstacle fixture lost its hidden entry.");
        float time = entry.NextRepositionTime.GetValueOrDefault() + 0.01f;
        Require(entry.IsCrawling && time < entry.NextShootTime,
            "Fixture did not isolate source reposition before shot.");
        CoopTransportLandingTests.AdvanceTo(runtime, runtime.Snapshot().ServerTick + 1);
        var observation = new CoopMatchRuntime.TransportCrewObstacleObservation(
            new TransportCrewObstacleClock.Observation(runtime.TransportRopeSnapshot!.RenderFrames, time, false, true),
            previous.Destination + Vector3.UnitY);
        Reject(() => runtime.AdvanceTransportCrewObstacle(previous with { }, observation));
        Reject(() => runtime.AdvanceTransportCrewObstacle(previous,
            observation with { Position = new Vector3(float.NaN) }));
        Require(runtime.AdvanceTransportCrewObstacle(previous, observation) ==
            TransportCrewObstacleClock.ActionKind.Reposition, "Source obstacle reposition was not applied.");
        CoopMatchRuntime.TransportCrewNavigationCommand replacement =
            runtime.TransportCrewNavigation(previous.ActorEntityId) ??
                throw new Exception("Obstacle reposition did not issue replacement navigation.");
        Require(!ReferenceEquals(previous, replacement) && !runtime.IsTransportCrewNavigationCurrent(previous) &&
            replacement.StartPosition == observation.Position &&
            replacement.Destination != previous.Destination &&
            replacement.PointComponentFileId == previous.PointComponentFileId &&
            destinations.ForEnemy(previous.ActorEntityId)?.Position == replacement.Destination &&
            ReferenceEquals(runtime.TransportCrewHiddenEntry(replacement), entry),
            "Same-obstacle SetFinalTarget changed reservation, observed root or source hidden clocks.");
        Require(runtime.BeginTransportCrewNavigation(replacement), "Replacement motor handoff could not begin.");
        Reject(() => runtime.AdvanceTransportCrewObstacle(replacement, observation));
        CoopTransportLandingTests.AdvanceTo(runtime, runtime.Snapshot().ServerTick + 1);
        var shotObservation = observation with
        {
            Clock = observation.Clock with
            {
                Frame = runtime.TransportRopeSnapshot!.RenderFrames,
                ControllerTime = entry.NextShootTime + 0.01f,
            },
        };
        Require(runtime.AdvanceTransportCrewObstacle(replacement, shotObservation) ==
            TransportCrewObstacleClock.ActionKind.ShotPreparationRequired &&
            ReferenceEquals(runtime.TransportCrewNavigation(previous.ActorEntityId), replacement),
            "Required shot preparation was bypassed by a later due reposition.");
        Reject(() => runtime.ResolveTransportCrewPointChange(replacement, shotObservation));
        Reject(() => runtime.ResolveTransportCrewPointChange(replacement with { }, shotObservation));
        Console.WriteLine(
            "PASS: native crew same-obstacle handoff retains hidden state, clocks and source branch priority.");
        return CoopCrewShotCallbackRuntimeTests.Verify(runtime, replacement, shotObservation, destinations);
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
        throw new Exception("Invalid or copied source obstacle callback was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
