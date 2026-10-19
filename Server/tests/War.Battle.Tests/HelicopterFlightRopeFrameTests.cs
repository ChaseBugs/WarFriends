using System.Numerics;
using War.BattleServer;

/// <summary>Composes source flight, stop callbacks, native physics and delayed rope activation.</summary>
internal static class HelicopterFlightRopeFrameTests
{
    private const float FrameSeconds = 0.033f;
    private const float LandingHeight = -10f;

    internal static int Run()
    {
        Vector3 start = new(9.5f, 0, 0);
        var route = new AirWaypointRoute(1, 2, 0, 1, 0.2f, new[]
        {
            new DroneWaypoint(1, Vector3.Zero, 0),
            new DroneWaypoint(2, new Vector3(10, 0, 0), 0),
        });
        var flight = new HelicopterWaypointState(route, start, 3);
        var orientation = new HelicopterOrientationState();
        var initialPose = new HelicopterRopeBodyPose(start, Quaternion.Identity);
        HelicopterRopeInitialState initial = HelicopterRopeInitialization.Create(
            start, start - Vector3.UnitY * 3, 1);
        using var world = new NativeHelicopterPhysicsWorld();
        using var reference = new NativeHelicopterRope(initial, initialPose, Quaternion.Identity);
        HelicopterPhysicsLease lease = world.Add(1, initial, initialPose, Quaternion.Identity);
        VerifyTargetPreflight(world, lease, initialPose);
        var referenceClock = new HelicopterPhysicsFrameClock();
        int checks = 3;
        foreach (int frame in Enumerable.Range(0, 12))
        {
            float timeScale = frame is >= 3 and <= 5 ? 0 : 1;
            float deltaTime = FrameSeconds * timeScale;
            DrainReferencePhysics(referenceClock, reference, deltaTime);
            Quaternion previousRotation = orientation.Rotation;
            bool hasArrived = flight.Advance(frame * FrameSeconds, timeScale);
            orientation.Advance(flight.Position, flight.Velocity, flight.Steering,
                flight.TargetPosition, flight.Breaking, deltaTime);
            var pose = new HelicopterRopeBodyPose(flight.Position, orientation.Rotation);
            reference.UpdateRenderFrame(deltaTime, pose);
            if (hasArrived)
            {
                reference.BeginExtension(LandingHeight);
            }
            float? target = hasArrived ? LandingHeight : null;
            HelicopterPhysicsWorldSnapshot actual = world.AdvanceFrame(deltaTime,
                new[] { new HelicopterPhysicsRenderInput(lease, pose, target) }, HelicopterPhysicsMode.Normal);
            VerifyFrame(actual, reference, hasArrived, frame);
            if (timeScale == 0 && previousRotation != orientation.Rotation)
            {
                throw new Exception("Paused source orientation changed despite a zero interpolation delta.");
            }
            checks += 4;
        }
        return checks;
    }

    private static void VerifyTargetPreflight(NativeHelicopterPhysicsWorld world,
        HelicopterPhysicsLease lease, HelicopterRopeBodyPose pose)
    {
        HelicopterPhysicsWorldSnapshot before = world.Snapshot();
        foreach (float target in new[] { float.NaN, float.PositiveInfinity, 10001f })
        {
            try
            {
                world.AdvanceFrame(FrameSeconds,
                    new[] { new HelicopterPhysicsRenderInput(lease, pose, target) }, HelicopterPhysicsMode.Normal);
                throw new Exception("Malformed arrival target was accepted.");
            }
            catch (InvalidDataException)
            {
                HelicopterPhysicsWorldSnapshot after = world.Snapshot();
                if (after.PhysicsSteps != before.PhysicsSteps || after.RenderFrames != before.RenderFrames ||
                    after.Members[0].IsExtending || !after.Members[0].Bodies.SequenceEqual(before.Members[0].Bodies))
                {
                    throw new Exception("Rejected arrival target mutated the native frame.");
                }
            }
        }
    }

    private static void DrainReferencePhysics(HelicopterPhysicsFrameClock clock,
        NativeHelicopterRope rope, float deltaTime)
    {
        clock.BeginFrame(deltaTime);
        while (clock.TakePhysicsStep() is HelicopterPhysicsQuantum quantum)
        {
            rope.SetPhysicsMode(quantum.Mode);
            rope.Advance();
        }
        clock.CompleteRenderFrame();
    }

    private static void VerifyFrame(HelicopterPhysicsWorldSnapshot actual,
        NativeHelicopterRope reference, bool hasArrived, int frame)
    {
        HelicopterPhysicsMemberSnapshot member = actual.Members.Single();
        if (!member.Bodies.SequenceEqual(reference.Snapshot()) || member.PhysicsSteps != reference.StepCount ||
            member.RenderFrames != reference.RenderFrameCount || member.IsExtending != reference.IsExtending)
        {
            throw new Exception("Composed world diverged from source-ordered native operations.");
        }
        if (hasArrived != (frame == 0))
        {
            throw new Exception("Stop callback repeated or failed to arm the source rope on arrival.");
        }
    }
}
