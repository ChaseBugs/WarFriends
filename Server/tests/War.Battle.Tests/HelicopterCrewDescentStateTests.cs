using System.Numerics;
using War.BattleServer;

/// <summary>Exercises descent against real native joint publications and rejects stale ownership atomically.</summary>
internal static class HelicopterCrewDescentStateTests
{
    private const float FrameDelta = 1f / MatchManifest.TickRate;
    private const float StartingHeight = 2f;
    private const float LandingHeight = -2f;

    internal static int Run()
    {
        var aircraft = new HelicopterRopeBodyPose(Vector3.Zero, Quaternion.Identity);
        HelicopterRopeInitialState initial = HelicopterRopeInitialization.Create(
            Vector3.Zero, new Vector3(0, -3, 0), 1);
        using var world = new NativeHelicopterPhysicsWorld();
        HelicopterPhysicsLease lease = world.Add(1, initial, aircraft, Quaternion.Identity);
        var input = new HelicopterPhysicsRenderInput(lease, aircraft);
        HelicopterPhysicsWorldSnapshot birth = world.Snapshot();
        var state = new HelicopterCrewDescentState(lease, birth, StartingHeight, LandingHeight);
        var root = new HelicopterDescentFrame(new Vector3(0, StartingHeight, 0), Quaternion.Identity,
            new Vector3(0, StartingHeight + 1, 0), Vector3.UnitX);
        Reject(state, new HelicopterCrewDescentObservation(root, birth, FrameDelta));

        HelicopterPhysicsWorldSnapshot physics = world.AdvanceFrame(
            FrameDelta, new[] { input }, HelicopterPhysicsMode.Normal);
        var observation = new HelicopterCrewDescentObservation(root, physics, FrameDelta);
        Reject(state, observation with { Pose = root with { RootRotation = default } });
        Reject(state, observation with { Physics = physics with { RenderFrames = physics.RenderFrames + 1 } });
        Reject(state, observation with
        {
            Physics = physics with { Members = Array.Empty<HelicopterPhysicsMemberSnapshot>() }
        });

        var reference = new HelicopterDescentState(StartingHeight, LandingHeight);
        Vector3[] joints = physics.Members.Single().Bodies.Select(body => body.Pose.Position).ToArray();
        HelicopterDescentResult expected = reference.Advance(root, FrameDelta, joints);
        HelicopterDescentResult result = state.Advance(observation);
        if (result != expected || state.Progress != reference.Progress)
        {
            throw new Exception("Owned descent did not use the published native joint positions.");
        }
        Reject(state, observation);

        using var foreignWorld = new NativeHelicopterPhysicsWorld();
        HelicopterPhysicsLease foreignLease = foreignWorld.Add(1, initial, aircraft, Quaternion.Identity);
        HelicopterPhysicsWorldSnapshot foreign = foreignWorld.AdvanceFrame(
            FrameDelta, new[] { new HelicopterPhysicsRenderInput(foreignLease, aircraft) },
            HelicopterPhysicsMode.Normal);
        Reject(state, observation with { Physics = foreign with { RenderFrames = physics.RenderFrames + 1 } });

        world.Remove(lease);
        HelicopterPhysicsLease replacement = world.Add(1, initial, aircraft, Quaternion.Identity);
        HelicopterPhysicsWorldSnapshot reused = world.AdvanceFrame(
            FrameDelta, new[] { new HelicopterPhysicsRenderInput(replacement, aircraft) },
            HelicopterPhysicsMode.Normal);
        Reject(state, observation with { Physics = reused });
        Console.WriteLine("PASS: crew descent uses real native joints and rejects replay, gaps and reused leases.");
        return 9;
    }

    private static void Reject(HelicopterCrewDescentState state, HelicopterCrewDescentObservation observation)
    {
        float before = state.Progress;
        try
        {
            state.Advance(observation);
        }
        catch (InvalidDataException)
        {
            if (state.Progress != before)
            {
                throw new Exception("Rejected crew observation consumed descent progress.");
            }
            return;
        }
        throw new Exception("Crew descent accepted an invalid or stale observation.");
    }
}
