using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Exercises real source extension commands before and after physical solving, including insertion.</summary>
internal static class NativeHelicopterRopeExtensionTests
{
    private const string ReferenceDigest = "afad253ab565ae80c3add9d230dbe160615bf0f8a46ebc59ef5a61ec7d9eb97a";
    private const float CommandTolerance = 0.00002f;

    internal static int Run(string directory)
    {
        string contents = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-rope-extension-physics-unity-reference.json")).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(contents))) != ReferenceDigest)
        {
            throw new Exception("Physical extension fixture differs from the reviewed native source capture.");
        }
        using JsonDocument document = JsonDocument.Parse(contents);
        JsonElement reference = document.RootElement;
        int count = VerifyInsertionCapacity(reference.GetProperty("initial")[0].GetProperty("state"));
        for (int scenario = 0; scenario < reference.GetProperty("initial").GetArrayLength(); scenario++)
        {
            count += VerifyZeroDelta(reference.GetProperty("initial")[scenario].GetProperty("state"));
            count += VerifyScenario(reference, scenario);
        }
        return count;
    }

    private static int VerifyScenario(JsonElement reference, int scenario)
    {
        using NativeHelicopterRope rope = NativeHelicopterRopeTests.Create(
            reference.GetProperty("initial")[scenario].GetProperty("state"));
        float deltaTime = reference.GetProperty("deltaTime").GetSingle();
        int count = VerifyRejectedDeltas(rope);
        int insertions = 0;
        var maximum = new Difference(0, 0, 0, 0);
        foreach (JsonElement frame in reference.GetProperty("frames").EnumerateArray())
        {
            IReadOnlyList<HelicopterRopeMotionBody> before = rope.Snapshot();
            ulong previousStep = rope.StepCount;
            rope.Extend(deltaTime);
            IReadOnlyList<HelicopterRopeMotionBody> command = rope.Snapshot();
            bool hasInserted = command.Count == before.Count + 1;
            int movedIndex = hasInserted ? 2 : 1;
            if (rope.StepCount != previousStep || command.Count != before.Count && !hasInserted ||
                command[0] != before[0] || command[movedIndex].Velocity != Vector3.Zero ||
                command[movedIndex].AngularVelocity != Vector3.Zero)
            {
                throw new Exception("Extension changed the fixed-step clock, root, or source velocity-reset behavior.");
            }
            JsonElement expected = frame.GetProperty("command")[scenario];
            count += CompareCommand(command, expected.GetProperty("state").GetProperty("joints"),
                new CommandFrame(scenario, frame.GetProperty("step").GetInt32()));
            if (hasInserted)
            {
                insertions++;
                if (command[1].Velocity != Vector3.Zero || command[1].AngularVelocity != Vector3.Zero)
                {
                    throw new Exception("A newly inserted source body inherited unproven velocity.");
                }
                count += VerifyInsertedSettings(expected.GetProperty("settings")[1]);
            }
            rope.Advance();
            count += VerifySolvedState(rope.Snapshot(), frame.GetProperty("after")[scenario].GetProperty("state")
                .GetProperty("joints"), scenario, ref maximum);
            count++;
        }
        if (insertions != 1)
        {
            throw new Exception("The native extension sequence did not reproduce the captured first insertion.");
        }
        Console.WriteLine($"PASS: extension positions case {scenario}: " +
            $"insertions {insertions}, {maximum}. Tilted rotation/angular velocity remain diagnostic.");
        return count + 1;
    }

    private static int VerifyInsertionCapacity(JsonElement initial)
    {
        const int MaximumBodies = 128;
        const int MaximumCommands = 1000;
        using NativeHelicopterRope rope = NativeHelicopterRopeTests.Create(initial);
        int commands = 0;
        while (rope.Snapshot().Count < MaximumBodies && commands < MaximumCommands)
        {
            rope.Extend(0.25f);
            commands++;
        }
        IReadOnlyList<HelicopterRopeMotionBody> before = rope.Snapshot();
        if (before.Count != MaximumBodies)
        {
            throw new Exception("Capacity fixture did not reach the adapter body limit.");
        }
        try
        {
            rope.Extend(2f);
            throw new Exception("Extension exceeded its body capacity.");
        }
        catch (InvalidOperationException exception) when (exception.Message.Contains("capacity"))
        {
            // Capacity is adapter policy, not permission to truncate the source insertion.
        }
        if (rope.StepCount != 0 || !rope.Snapshot().SequenceEqual(before))
        {
            throw new Exception("Rejected capacity overflow changed native bodies or physical time.");
        }
        return 3;
    }

    private static int VerifyRejectedDeltas(NativeHelicopterRope rope)
    {
        IReadOnlyList<HelicopterRopeMotionBody> original = rope.Snapshot();
        float[] malformed = { float.NaN, -0.01f, float.PositiveInfinity };
        foreach (float deltaTime in malformed)
        {
            try
            {
                rope.Extend(deltaTime);
                throw new Exception("Malformed extension delta was accepted.");
            }
            catch (InvalidDataException)
            {
                // Reject before changing topology, velocities or the physical clock.
            }
        }
        if (rope.StepCount != 0 || !rope.Snapshot().SequenceEqual(original))
        {
            throw new Exception("Rejected extension input changed native state.");
        }
        return malformed.Length + 2;
    }

    private static int VerifyZeroDelta(JsonElement initial)
    {
        using NativeHelicopterRope rope = NativeHelicopterRopeTests.Create(initial);
        rope.Advance();
        IReadOnlyList<HelicopterRopeMotionBody> before = rope.Snapshot();
        rope.Extend(0);
        IReadOnlyList<HelicopterRopeMotionBody> after = rope.Snapshot();
        if (rope.StepCount != 1 || after.Count != before.Count || after[1].Pose != before[1].Pose ||
            after[1].Velocity != Vector3.Zero || after[1].AngularVelocity != Vector3.Zero)
        {
            throw new Exception("Zero-delta source extension must still reset the moved body's velocity.");
        }
        return 3;
    }

    private static int CompareCommand(IReadOnlyList<HelicopterRopeMotionBody> actual,
        JsonElement expected, CommandFrame frame)
    {
        if (actual.Count != expected.GetArrayLength())
        {
            throw new Exception("Native extension inserted at a different source command.");
        }
        for (int index = 0; index < actual.Count; index++)
        {
            JsonElement source = expected[index];
            Vector3 position = Vector(source.GetProperty("position"));
            JsonElement values = source.GetProperty("rotation");
            Quaternion rotation = new(values[0].GetSingle(), values[1].GetSingle(),
                values[2].GetSingle(), values[3].GetSingle());
            float positionError = Vector3.Distance(actual[index].Pose.Position, position);
            float rotationError = MathF.Min((actual[index].Pose.Rotation - rotation).Length(),
                (actual[index].Pose.Rotation + rotation).Length());
            if (positionError > CommandTolerance || frame.Scenario < 2 && rotationError > CommandTolerance)
            {
                throw new Exception($"Native extension command mismatch: case {frame.Scenario}, " +
                    $"step {frame.Step}, body {index}, " +
                    $"position {positionError}, rotation {rotationError}.");
            }
        }
        return actual.Count * (frame.Scenario < 2 ? 2 : 1);
    }

    private static int VerifyInsertedSettings(JsonElement settings)
    {
        if (settings.GetProperty("mass").GetSingle() != 1 || settings.GetProperty("drag").GetSingle() != 0 ||
            settings.GetProperty("angularDrag").GetSingle() != 0.05f ||
            !settings.GetProperty("useGravity").GetBoolean() || settings.GetProperty("isKinematic").GetBoolean())
        {
            throw new Exception("The inserted source Rigidbody no longer has the reviewed default settings.");
        }
        return 5;
    }

    private static int VerifySolvedState(IReadOnlyList<HelicopterRopeMotionBody> actual,
        JsonElement expected, int scenario, ref Difference maximum)
    {
        if (actual.Count != expected.GetArrayLength())
        {
            throw new Exception("Solved extension returned a different source topology.");
        }
        for (int index = 0; index < actual.Count; index++)
        {
            HelicopterRopeMotionBody body = actual[index];
            JsonElement source = expected[index];
            JsonElement rotation = source.GetProperty("rotation");
            Quaternion expectedRotation = new(rotation[0].GetSingle(), rotation[1].GetSingle(),
                rotation[2].GetSingle(), rotation[3].GetSingle());
            var error = new Difference(
                Vector3.Distance(body.Pose.Position, Vector(source.GetProperty("position"))),
                MathF.Min((body.Pose.Rotation - expectedRotation).Length(),
                    (body.Pose.Rotation + expectedRotation).Length()),
                Vector3.Distance(body.Velocity, Vector(source.GetProperty("velocity"))),
                Vector3.Distance(body.AngularVelocity, Vector(source.GetProperty("angularVelocity"))));
            if (!error.IsFinite || error.Position > CommandTolerance || error.Velocity > CommandTolerance ||
                scenario < 2 && (error.Rotation > CommandTolerance || error.AngularVelocity > CommandTolerance))
            {
                throw new Exception($"Solved extension differs from Unity at body {index}: {error}.");
            }
            maximum = maximum.Merge(error);
        }
        return actual.Count * (scenario < 2 ? 5 : 3);
    }

    private static Vector3 Vector(JsonElement values)
    {
        return new Vector3(values[0].GetSingle(), values[1].GetSingle(), values[2].GetSingle());
    }

    private readonly record struct CommandFrame(int Scenario, int Step);

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
