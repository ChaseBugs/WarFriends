using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Exercises recovered normal/ragdoll timing transitions against actual Unity physics samples.</summary>
internal static class NativeHelicopterRopeTimingTests
{
    private const string ReferenceDigest = "bbb4eaa63fc13b2a51f4a6d7228805d267f050c9400d2e0b2aba1666fb10d8d7";
    private const float PoseTolerance = 0.00002f;
    private const ulong ExpectedDurationMilliseconds = 96;

    internal static int Run(string directory)
    {
        string contents = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-rope-timing-unity-reference.json")).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(contents))) != ReferenceDigest)
        {
            throw new Exception("Source timing capture differs from the reviewed active-profile reference.");
        }
        using JsonDocument document = JsonDocument.Parse(contents);
        JsonElement reference = document.RootElement;
        if (reference.GetProperty("defaultDeltaTime").GetSingle() != HelicopterPhysicsTiming.NormalSeconds)
        {
            throw new Exception("The fixture did not use the active Client's normal physics profile.");
        }
        int count = VerifyModeGuards(reference.GetProperty("initial")[0]);
        for (int scenario = 0; scenario < reference.GetProperty("initial").GetArrayLength(); scenario++)
        {
            count += VerifyScenario(reference, scenario);
        }
        return count;
    }

    private static int VerifyScenario(JsonElement reference, int scenario)
    {
        using NativeHelicopterRope rope = NativeHelicopterRopeTests.Create(reference.GetProperty("initial")[scenario]);
        ulong expectedMilliseconds = 0;
        int count = 0;
        var maximum = new Difference(0, 0, 0, 0);
        foreach (JsonElement frame in reference.GetProperty("frames").EnumerateArray())
        {
            HelicopterPhysicsMode mode = frame.GetProperty("ragdoll").GetBoolean()
                ? HelicopterPhysicsMode.Ragdoll : HelicopterPhysicsMode.Normal;
            if (frame.GetProperty("deltaTime").GetSingle() != HelicopterPhysicsTiming.Seconds(mode))
            {
                throw new Exception("Native physics mode differs from the original TimeManager selection.");
            }
            IReadOnlyList<HelicopterRopeMotionBody> before = rope.Snapshot();
            ulong beforeStep = rope.StepCount;
            rope.SetPhysicsMode(mode);
            if (rope.StepCount != beforeStep || rope.NominalPhysicsMilliseconds != expectedMilliseconds ||
                rope.RenderFrameCount != 0 || !rope.Snapshot().SequenceEqual(before))
            {
                throw new Exception("Physics mode selection advanced time or mutated body state.");
            }
            rope.Advance();
            expectedMilliseconds += HelicopterPhysicsTiming.Milliseconds(mode);
            if (rope.StepCount != frame.GetProperty("step").GetUInt64() ||
                rope.NominalPhysicsMilliseconds != expectedMilliseconds || rope.RenderFrameCount != 0)
            {
                throw new Exception("Mixed physics steps lost their nominal clock or changed the render clock.");
            }
            count += Compare(rope.Snapshot(), frame.GetProperty("ropes")[scenario].GetProperty("joints"),
                scenario, ref maximum) + 7;
        }
        if (expectedMilliseconds != ExpectedDurationMilliseconds)
        {
            throw new Exception("The source mode transition fixture has a different total duration.");
        }
        Console.WriteLine($"Timing case {scenario}, nominal {expectedMilliseconds} ms: {maximum}. " +
            "Tilted poses and speeds remain diagnostic.");
        return count + 1;
    }

    private static int VerifyModeGuards(JsonElement initial)
    {
        using NativeHelicopterRope rope = NativeHelicopterRopeTests.Create(initial);
        rope.SetPhysicsMode(HelicopterPhysicsMode.Ragdoll);
        IReadOnlyList<HelicopterRopeMotionBody> before = rope.Snapshot();
        RequireInvalid(() => rope.SetPhysicsMode((HelicopterPhysicsMode)99));
        RequireInvalid(() => HelicopterPhysicsTiming.Milliseconds((HelicopterPhysicsMode)99));
        if (rope.StepCount != 0 || rope.NominalPhysicsMilliseconds != 0 || !rope.Snapshot().SequenceEqual(before))
        {
            throw new Exception("Rejected physics mode mutated the native scene.");
        }
        rope.Advance();
        if (rope.NominalPhysicsMilliseconds != 4 || rope.StepCount != 1)
        {
            throw new Exception("Rejected mode replaced the previously selected ragdoll timing.");
        }
        rope.SetPhysicsMode(HelicopterPhysicsMode.Normal);
        rope.Advance();
        if (rope.NominalPhysicsMilliseconds != 24 || rope.StepCount != 2)
        {
            throw new Exception("Returning to normal mode did not restore the source step.");
        }
        float[] malformed = { 0, -0.004f, float.NaN, float.PositiveInfinity, 1f / 30f };
        using var invalidIdentity = new NativeRopeHandle(IntPtr.Zero);
        foreach (float delta in malformed)
        {
            if (NativeRopeMethods.Step(invalidIdentity, delta) != 1)
            {
                throw new Exception("The C ABI accepted an unsupported physics quantum.");
            }
        }
        return malformed.Length + 7;
    }

    private static int Compare(IReadOnlyList<HelicopterRopeMotionBody> actual, JsonElement expected,
        int scenario, ref Difference maximum)
    {
        if (actual.Count != expected.GetArrayLength())
        {
            throw new Exception("Timing transition changed the source topology.");
        }
        for (int index = 0; index < actual.Count; index++)
        {
            JsonElement source = expected[index];
            Quaternion rotation = Rotation(source.GetProperty("rotation"));
            var error = new Difference(
                Vector3.Distance(actual[index].Pose.Position, Vector(source.GetProperty("position"))),
                MathF.Min((actual[index].Pose.Rotation - rotation).Length(),
                    (actual[index].Pose.Rotation + rotation).Length()),
                Vector3.Distance(actual[index].Velocity, Vector(source.GetProperty("velocity"))),
                Vector3.Distance(actual[index].AngularVelocity, Vector(source.GetProperty("angularVelocity"))));
            if (!error.IsFinite || scenario < 2 && (error.Position > PoseTolerance || error.Rotation > PoseTolerance))
            {
                throw new Exception($"Timing fixture differs: case {scenario}, body {index}, {error}.");
            }
            maximum = maximum.Merge(error);
        }
        return actual.Count * (scenario < 2 ? 3 : 1);
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
        throw new Exception("Unsupported source physics mode was accepted.");
    }

    private static Vector3 Vector(JsonElement values)
    {
        return new Vector3(values[0].GetSingle(), values[1].GetSingle(), values[2].GetSingle());
    }

    private static Quaternion Rotation(JsonElement values)
    {
        return new Quaternion(values[0].GetSingle(), values[1].GetSingle(),
            values[2].GetSingle(), values[3].GetSingle());
    }

    private readonly record struct Difference(float Position, float Rotation, float Velocity, float AngularVelocity)
    {
        internal bool IsFinite => float.IsFinite(Position) && float.IsFinite(Rotation) &&
            float.IsFinite(Velocity) && float.IsFinite(AngularVelocity);

        internal Difference Merge(Difference other)
        {
            return new Difference(MathF.Max(Position, other.Position), MathF.Max(Rotation, other.Rotation),
                MathF.Max(Velocity, other.Velocity), MathF.Max(AngularVelocity, other.AngularVelocity));
        }
    }
}
