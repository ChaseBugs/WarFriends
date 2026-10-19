using System.Numerics;
using War.BattleServer;

/// <summary>Verifies shared native scheduling, admission lifetime, and rejection before mutation.</summary>
internal static class NativeHelicopterPhysicsWorldTests
{
    internal static int Run()
    {
        return VerifyScheduling() + VerifyNativeFailureCleanup();
    }

    private static int VerifyScheduling()
    {
        var aircraft = new HelicopterRopeBodyPose(Vector3.Zero, Quaternion.Identity);
        HelicopterRopeInitialState initial = HelicopterRopeInitialization.Create(
            Vector3.Zero, new Vector3(0, -3, 0), 1);
        using var world = new NativeHelicopterPhysicsWorld();
        HelicopterPhysicsLease first = world.Add(20, initial, aircraft, Quaternion.Identity);
        var firstInput = new HelicopterPhysicsRenderInput(first, aircraft);
        HelicopterPhysicsWorldSnapshot before = world.AdvanceFrame(
            0.03f, new[] { firstInput }, HelicopterPhysicsMode.Normal);
        Require(before.PhysicsSteps == 1 && before.RenderFrames == 1);

        HelicopterPhysicsLease second = world.Add(10, initial, aircraft, Quaternion.Identity);
        var secondInput = new HelicopterPhysicsRenderInput(second, aircraft);
        HelicopterPhysicsWorldSnapshot joined = world.Snapshot();
        Require(joined.PhysicsSteps == 1 && joined.Members[0].BirthPhysicsStep == 1);
        Require(joined.Members[0].PhysicsSteps == 0 && joined.Members[1].PhysicsSteps == 1);

        Reject(() => world.AdvanceFrame(0.02f, new[] { firstInput }, HelicopterPhysicsMode.Normal));
        Reject(() => world.AdvanceFrame(0.02f, new[] { firstInput, firstInput }, HelicopterPhysicsMode.Normal));
        Reject(() => world.AdvanceFrame(float.NaN,
            new[] { firstInput, secondInput }, HelicopterPhysicsMode.Normal));
        Require(world.Snapshot().PhysicsSteps == joined.PhysicsSteps);

        HelicopterPhysicsWorldSnapshot advanced = world.AdvanceFrame(
            0.02f, new[] { firstInput, secondInput }, HelicopterPhysicsMode.Ragdoll);
        Require(advanced.PhysicsSteps == 2 && advanced.RenderFrames == 2);
        Require(advanced.Members[0].PhysicsSteps == 1 && advanced.Members[1].PhysicsSteps == 2);
        Require(before.Members.Count == 1 && before.Members[0].PhysicsSteps == 1);

        world.Remove(second);
        HelicopterPhysicsLease replacement = world.Add(10, initial, aircraft, Quaternion.Identity);
        Require(replacement.Generation > second.Generation);
        Reject(() => world.Remove(second));
        using var other = new NativeHelicopterPhysicsWorld();
        HelicopterPhysicsLease foreign = other.Add(20, initial, aircraft, Quaternion.Identity);
        Reject(() => world.Remove(foreign));
        var replacementInput = new HelicopterPhysicsRenderInput(replacement, aircraft);
        HelicopterPhysicsWorldSnapshot debt = world.AdvanceFrame(
            0, new[] { firstInput, replacementInput }, HelicopterPhysicsMode.Ragdoll);
        Require(debt.PhysicsSteps == 4 && debt.Members[0].PhysicsSteps == 2);
        world.Dispose();
        world.Dispose();
        Reject(() => world.Snapshot());
        return 16;
    }

    private static int VerifyNativeFailureCleanup()
    {
        const int NativeRopeCapacity = 64;
        const float NativeCoordinateLimit = 10000;
        var aircraft = new HelicopterRopeBodyPose(Vector3.Zero, Quaternion.Identity);
        HelicopterRopeInitialState initial = HelicopterRopeInitialization.Create(
            new Vector3(2, 0, 0), new Vector3(2, -3, 0), 1);
        using var world = new NativeHelicopterPhysicsWorld();
        HelicopterPhysicsLease first = world.Add(1, initial, aircraft, Quaternion.Identity);
        HelicopterPhysicsLease second = world.Add(2, initial, aircraft, Quaternion.Identity);
        HelicopterPhysicsWorldSnapshot retained = world.Snapshot();
        var safeInput = new HelicopterPhysicsRenderInput(first,
            new HelicopterRopeBodyPose(Vector3.UnitX, Quaternion.Identity));
        // The aircraft itself is valid. Its inherited root exceeds the native coordinate bound.
        var failingInput = new HelicopterPhysicsRenderInput(second,
            new HelicopterRopeBodyPose(new Vector3(NativeCoordinateLimit, 0, 0), Quaternion.Identity));
        try
        {
            world.AdvanceFrame(HelicopterPhysicsTiming.NormalSeconds,
                new[] { safeInput, failingInput }, HelicopterPhysicsMode.Normal);
            throw new Exception("Expected the second native transform to reject its inherited root.");
        }
        catch (InvalidOperationException exception) when
            (exception.Message.StartsWith("Native rope operation failed with status", StringComparison.Ordinal))
        {
            // Physics and the first render have run; only the second native transform is rejected.
        }
        Reject(() => world.Snapshot());
        Reject(() => world.AdvanceFrame(0, new[] { safeInput, failingInput }, HelicopterPhysicsMode.Normal));
        Reject(() => world.Add(3, initial, aircraft, Quaternion.Identity));
        Reject(() => world.BeginExtension(first, -10));
        Require(retained.PhysicsSteps == 0 && retained.RenderFrames == 0);
        Require(retained.Members.All(member => member.PhysicsSteps == 0 && member.RenderFrames == 0));

        // Fill the actual process-wide native registry before disposing the failed owner.
        // A leaked scene would prevent reaching the SDK's full capacity here.
        using var replacement = new NativeHelicopterPhysicsWorld();
        for (ulong entityId = 1; entityId <= NativeRopeCapacity; entityId++)
        {
            replacement.Add(entityId, initial, aircraft, Quaternion.Identity);
        }
        Require(replacement.Snapshot().Members.Count == NativeRopeCapacity);
        world.Dispose();
        world.Dispose();
        return 9;
    }

    private static void Require(bool condition)
    {
        if (!condition)
        {
            throw new Exception("Native world scheduling or lease ownership changed.");
        }
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (exception is InvalidOperationException or InvalidDataException
            or ArgumentException or ObjectDisposedException)
        {
            return;
        }
        throw new Exception("Invalid native world operation was accepted.");
    }
}
