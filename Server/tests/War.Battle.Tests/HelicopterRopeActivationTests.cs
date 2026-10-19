using System.Numerics;
using War.BattleServer;

/// <summary>Exercises actual native allocation after the source strict realtime/end-of-frame boundary.</summary>
internal static class HelicopterRopeActivationTests
{
    internal static int Run(string directory)
    {
        HelicopterRopeDefinition definition = HelicopterRopeDefinition.Load(
            Path.Combine(directory, "recovered-helicopter-rope-definition.json"));
        var state = new HelicopterRopeActivationState(definition, 1, 0);
        using var world = new NativeHelicopterPhysicsWorld();
        var aircraft = new HelicopterRopeBodyPose(new Vector3(5, 2, 0), Quaternion.Identity);
        world.AdvanceFrame(0.03f, Array.Empty<HelicopterPhysicsRenderInput>(), HelicopterPhysicsMode.Normal);
        Require(state.TryActivateAfterRender(world, 2, aircraft) == null);
        Require(world.Snapshot().Members.Count == 0);

        // The callback can finish on a paused render; it uses realtime, not accumulated scaled game time.
        world.AdvanceFrame(0, Array.Empty<HelicopterPhysicsRenderInput>(), HelicopterPhysicsMode.Normal);
        HelicopterPhysicsLease lease = state.TryActivateAfterRender(world, float.BitIncrement(2), aircraft)
            ?? throw new Exception("Source activation did not fire strictly after its deadline.");
        HelicopterPhysicsWorldSnapshot born = world.Snapshot();
        Require(born.PhysicsSteps == 1 && born.RenderFrames == 2);
        Require(born.Members[0].BirthPhysicsStep == 1 && born.Members[0].PhysicsSteps == 0 &&
            born.Members[0].RenderFrames == 0);
        Require(Vector3.Distance(born.Members[0].Bodies[0].Pose.Position,
            definition.RootPositionAt(aircraft)) < 0.000001f);
        Require(state.TryActivateAfterRender(world, 3, aircraft) == null && world.Snapshot().Members.Count == 1);
        HelicopterPhysicsWorldSnapshot advanced = world.AdvanceFrame(0.02f,
            new[] { new HelicopterPhysicsRenderInput(lease, aircraft) }, HelicopterPhysicsMode.Normal);
        Require(advanced.PhysicsSteps == 2 && advanced.Members[0].PhysicsSteps == 1 &&
            advanced.Members[0].RenderFrames == 1);
        VerifyCancellation(definition, world, aircraft);
        world.Remove(lease);
        Require(world.Snapshot().Members.Count == 0);
        var reused = new HelicopterRopeActivationState(definition, 1, 3);
        HelicopterPhysicsLease replacement = reused.TryActivateAfterRender(world, 6, aircraft)
            ?? throw new Exception("A fresh activation lifecycle could not reuse the removed entity identity.");
        Require(replacement.Generation > lease.Generation);
        Require(state.TryActivateAfterRender(world, 10, aircraft) == null && world.Snapshot().Members.Count == 1);
        world.Remove(replacement);
        Require(world.Snapshot().Members.Count == 0);
        return 13;
    }

    private static void VerifyCancellation(HelicopterRopeDefinition definition, NativeHelicopterPhysicsWorld world,
        HelicopterRopeBodyPose aircraft)
    {
        var canceled = new HelicopterRopeActivationState(definition, 2, 0);
        canceled.CancelPending();
        canceled.CancelPending();
        Require(canceled.TryActivateAfterRender(world, 10, aircraft) == null && !canceled.ActiveLease.HasValue);
        var rejected = new HelicopterRopeActivationState(definition, 3, 0);
        try
        {
            rejected.TryActivateAfterRender(world, float.NaN, aircraft);
            throw new Exception("Malformed realtime was accepted by activation.");
        }
        catch (InvalidDataException)
        {
            Require(!rejected.ActiveLease.HasValue && world.Snapshot().Members.Count == 1);
        }
    }

    private static void Require(bool condition)
    {
        if (!condition)
        {
            throw new Exception("Source rope activation boundary, current pose or match clock ownership changed.");
        }
    }
}
