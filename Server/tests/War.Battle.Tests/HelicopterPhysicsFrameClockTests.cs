using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares due quanta and render boundaries with actual automatic Unity callback traces.</summary>
internal static class HelicopterPhysicsFrameClockTests
{
    internal static int Run(string directory)
    {
        int count = VerifyLifecycle();
        count += VerifyTrace(directory, "recovered-helicopter-clock-unity-reference.json",
            "3f71e40e662eea6051dd5ebe3f0993df2b673dce415bd99f06b95a5b28fe5c8f");
        count += VerifyTrace(directory, "recovered-helicopter-clock-pause-unity-reference.json",
            "3c16d9cb90eb2bd67064cc690279b0759a938b7921135812b340fb9f931871d4");
        return count;
    }

    private static int VerifyTrace(string directory, string filename, string digest)
    {
        string contents = File.ReadAllText(Path.Combine(directory, filename)).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(contents))) != digest)
        {
            throw new Exception("Automatic clock trace differs from the reviewed native capture.");
        }
        using JsonDocument document = JsonDocument.Parse(contents);
        JsonElement reference = document.RootElement;
        double initialDebt = reference.GetProperty("initialTime").GetDouble() -
            reference.GetProperty("initialFixedTime").GetDouble();
        var clock = new HelicopterPhysicsFrameClock(initialDebt);
        using JsonDocument ropeReference = JsonDocument.Parse(File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-rope-physics-unity-reference.json")));
        using NativeHelicopterRope rope = NativeHelicopterRopeTests.Create(
            ropeReference.RootElement.GetProperty("initial")[0]);
        var pending = new List<JsonElement>();
        int count = 0;
        foreach (JsonElement callback in reference.GetProperty("events").EnumerateArray())
        {
            if (callback.GetProperty("kind").GetString() == "fixed")
            {
                pending.Add(callback);
                continue;
            }
            count += ReplayFrame(clock, rope, new RecordedFrame(callback, pending.ToArray()));
            pending.Clear();
        }
        if (pending.Count != 0 || clock.RenderFrames != 30 || rope.RenderFrameCount != clock.RenderFrames ||
            rope.StepCount != clock.PhysicsSteps || rope.NominalPhysicsMilliseconds != clock.NominalPhysicsMilliseconds)
        {
            throw new Exception("Automatic trace ended with unmatched native work or an incomplete render frame.");
        }
        Console.WriteLine($"PASS: automatic clock {filename}: {clock.RenderFrames} renders, " +
            $"{clock.PhysicsSteps} physics steps, {clock.NominalPhysicsMilliseconds} nominal ms.");
        return count + 5;
    }

    private static int ReplayFrame(HelicopterPhysicsFrameClock clock, NativeHelicopterRope rope,
        RecordedFrame frame)
    {
        float deltaTime = frame.Render.GetProperty("deltaTime").GetSingle();
        clock.BeginFrame(deltaTime);
        int index = 0;
        while (clock.TakePhysicsStep() is HelicopterPhysicsQuantum quantum)
        {
            if (index >= frame.Fixed.Length)
            {
                throw new Exception("The clock scheduled more physical steps than Unity.");
            }
            JsonElement source = frame.Fixed[index++];
            HelicopterPhysicsMode expectedMode = source.GetProperty("ragdoll").GetBoolean()
                ? HelicopterPhysicsMode.Ragdoll : HelicopterPhysicsMode.Normal;
            if (quantum.Mode != expectedMode || quantum.DeltaTime != source.GetProperty("deltaTime").GetSingle() ||
                source.GetProperty("frame").GetInt32() != frame.Render.GetProperty("frame").GetInt32())
            {
                throw new Exception("A physical quantum crossed its source mode or render boundary.");
            }
            rope.SetPhysicsMode(quantum.Mode);
            rope.Advance();
            if (rope.StepCount != quantum.Sequence)
            {
                throw new Exception("The native scene did not execute exactly one scheduled quantum.");
            }
        }
        if (index != frame.Fixed.Length)
        {
            throw new Exception("The clock omitted a source physical callback.");
        }
        HelicopterPhysicsMode nextMode = frame.Render.GetProperty("ragdoll").GetBoolean()
            ? HelicopterPhysicsMode.Ragdoll : HelicopterPhysicsMode.Normal;
        clock.SetPhysicsMode(nextMode);
        rope.SetPhysicsMode(nextMode);
        rope.UpdateRenderFrame(deltaTime, new HelicopterRopeBodyPose(Vector3.Zero, Quaternion.Identity));
        clock.CompleteRenderFrame();
        return index * 4 + 1;
    }

    private static int VerifyLifecycle()
    {
        var clock = new HelicopterPhysicsFrameClock();
        RequireOrder(() => clock.TakePhysicsStep());
        RequireOrder(() => clock.CompleteRenderFrame());
        float[] malformed = { float.NaN, -0.01f, float.PositiveInfinity, 0.21f };
        foreach (float delta in malformed)
        {
            RequireInvalid(() => clock.BeginFrame(delta));
        }
        RequireInvalid(() => new HelicopterPhysicsFrameClock(double.NaN));
        RequireInvalid(() => new HelicopterPhysicsFrameClock(-0.001));
        clock.SetPhysicsMode(HelicopterPhysicsMode.Ragdoll);
        RequireInvalid(() => clock.SetPhysicsMode((HelicopterPhysicsMode)99));
        clock.BeginFrame(0.008f);
        RequireOrder(() => clock.BeginFrame(0));
        RequireOrder(() => clock.CompleteRenderFrame());
        if (clock.TakePhysicsStep() is not { Mode: HelicopterPhysicsMode.Ragdoll })
        {
            throw new Exception("Rejected mode changed the previously selected quantum.");
        }
        clock.SetPhysicsMode(HelicopterPhysicsMode.Normal);
        if (clock.TakePhysicsStep() != null)
        {
            throw new Exception("A sub-normal remainder was consumed prematurely.");
        }
        clock.SetPhysicsMode(HelicopterPhysicsMode.Ragdoll);
        RequireOrder(() => clock.TakePhysicsStep());
        clock.CompleteRenderFrame();
        clock.BeginFrame(0);
        if (clock.TakePhysicsStep() == null || clock.TakePhysicsStep() != null ||
            clock.PhysicsSteps != 2 || clock.NominalPhysicsMilliseconds != 8)
        {
            throw new Exception("A zero-delta frame discarded owed physics after a render-phase mode change.");
        }
        clock.CompleteRenderFrame();
        clock.Fault();
        clock.Fault();
        RequireOrder(() => clock.BeginFrame(0));
        RequireOrder(() => clock.SetPhysicsMode(HelicopterPhysicsMode.Normal));
        RequireOrder(() => clock.TakePhysicsStep());
        RequireOrder(() => clock.CompleteRenderFrame());
        return malformed.Length + 17;
    }

    private static void RequireOrder(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidOperationException)
        {
            return;
        }
        throw new Exception("An invalid clock phase or a faulted clock accepted work.");
    }

    private static void RequireInvalid(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new Exception("Malformed clock input was accepted.");
    }

    private sealed record RecordedFrame(JsonElement Render, JsonElement[] Fixed);
}
