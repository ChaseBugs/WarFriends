using System.Numerics;
using War.BattleServer;

/// <summary>Checks the source separation between realtime steering and scaled Transform translation.</summary>
internal static class HelicopterFlightClockTests
{
    private const float FlightSpeed = 3f;
    private const float SourceMass = 150f;
    private const float FrameSeconds = 0.033f;
    private const float Tolerance = 0.0000001f;

    internal static int Run()
    {
        var points = new[]
        {
            new DroneWaypoint(1, Vector3.Zero, 0),
            new DroneWaypoint(2, new Vector3(10, 0, 0), 0),
        };
        var route = new AirWaypointRoute(1, 2, 0, 1, 0.2f, points);
        var flight = new HelicopterWaypointState(route, Vector3.Zero, FlightSpeed);
        flight.Advance(0, 1);
        flight.Advance(FrameSeconds, 1);
        Vector3 beforePause = flight.Position;
        float expectedVelocity = FlightSpeed * FrameSeconds / SourceMass;
        RequireNear(flight.Velocity.X, expectedVelocity);

        flight.Advance(FrameSeconds * 2, 0);
        expectedVelocity += (FlightSpeed * FrameSeconds - expectedVelocity) / SourceMass;
        RequireNear(flight.Velocity.X, expectedVelocity);
        Require(flight.Position == beforePause);

        const float SlowTimeScale = 0.5f;
        flight.Advance(FrameSeconds * 3, SlowTimeScale);
        expectedVelocity += (FlightSpeed * FrameSeconds - expectedVelocity) / SourceMass;
        RequireNear(flight.Velocity.X, expectedVelocity);
        RequireNear(flight.Position.X, beforePause.X + expectedVelocity * SlowTimeScale);
        VerifyRejectedInputs(flight);
        return 10;
    }

    private static void VerifyRejectedInputs(HelicopterWaypointState flight)
    {
        Vector3 retainedPosition = flight.Position;
        Vector3 retainedVelocity = flight.Velocity;
        float nextRealtime = FrameSeconds * 4;
        foreach (float invalidScale in new[] { float.NaN, float.PositiveInfinity, -1f })
        {
            try
            {
                flight.Advance(nextRealtime, invalidScale);
                throw new Exception("Malformed source flight time scale was accepted.");
            }
            catch (InvalidDataException)
            {
                Require(flight.Position == retainedPosition && flight.Velocity == retainedVelocity);
            }
        }
        flight.Advance(nextRealtime, 1);
        float expectedVelocity = retainedVelocity.X +
            (FlightSpeed * FrameSeconds - retainedVelocity.X) / SourceMass;
        RequireNear(flight.Velocity.X, expectedVelocity);
        RequireNear(flight.Position.X, retainedPosition.X + expectedVelocity);
    }

    private static void RequireNear(float actual, float expected)
    {
        Require(MathF.Abs(actual - expected) < Tolerance);
    }

    private static void Require(bool condition)
    {
        if (!condition)
        {
            throw new Exception("Helicopter realtime steering and scaled translation diverged from source.");
        }
    }
}
