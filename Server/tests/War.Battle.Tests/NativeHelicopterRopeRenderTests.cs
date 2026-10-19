using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>
/// Verifies source height gating and extension-before-aircraft order against combined Unity captures.
/// </summary>
internal static class NativeHelicopterRopeRenderTests
{
    private const string ReferenceDigest = "10917a8c2672f3b238dc31a14167f2519283b8aaea171d0b7b8ee1370534e0ba";
    private const float PoseTolerance = 0.00002f;

    internal static int Run(string directory)
    {
        string contents = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-rope-combined-unity-reference.json")).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(contents))) != ReferenceDigest)
        {
            throw new Exception("Combined rope capture differs from the reviewed source reference.");
        }
        using JsonDocument document = JsonDocument.Parse(contents);
        JsonElement reference = document.RootElement;
        int count = VerifyGateOrder(reference.GetProperty("initial")[0].GetProperty("state"));
        for (int scenario = 0; scenario < reference.GetProperty("initial").GetArrayLength(); scenario++)
        {
            count += VerifyScenario(reference, scenario);
        }
        return count;
    }

    private static int VerifyScenario(JsonElement reference, int scenario)
    {
        JsonElement initial = reference.GetProperty("initial")[scenario].GetProperty("state");
        using NativeHelicopterRope rope = NativeHelicopterRopeTests.Create(initial);
        rope.BeginExtension(reference.GetProperty("targetHeights")[scenario].GetSingle());
        int count = VerifyRejectedFrames(rope, AircraftFromAttachment(initial.GetProperty("attachment")));
        var maximum = new Difference(0, 0, 0, 0);
        foreach (JsonElement frame in reference.GetProperty("frames").EnumerateArray())
        {
            ulong step = frame.GetProperty("step").GetUInt64();
            JsonElement render = frame.GetProperty("render")[scenario];
            rope.UpdateRenderFrame(reference.GetProperty("deltaTime").GetSingle(), AircraftFromFrame(render));
            if (rope.RenderFrameCount != step || rope.StepCount != step - 1 ||
                rope.IsExtending != render.GetProperty("isExtending").GetBoolean())
            {
                throw new Exception("Render update changed the fixed clock or source height-gate lifecycle.");
            }
            count += Compare(rope.Snapshot(), render.GetProperty("joints"), scenario, ref maximum);
            rope.Advance();
            count += Compare(rope.Snapshot(), frame.GetProperty("after")[scenario].GetProperty("joints"),
                scenario, ref maximum);
            count += 3;
        }
        Console.WriteLine($"Combined rope case {scenario}: {maximum}.");
        return count;
    }

    private static int VerifyRejectedFrames(NativeHelicopterRope rope, HelicopterRopeBodyPose aircraft)
    {
        IReadOnlyList<HelicopterRopeMotionBody> before = rope.Snapshot();
        float[] malformed = { float.NaN, -0.01f, float.PositiveInfinity };
        foreach (float deltaTime in malformed)
        {
            RequireInvalid(() => rope.UpdateRenderFrame(deltaTime, aircraft));
        }
        RequireInvalid(() => rope.UpdateRenderFrame(0.03f, aircraft with { Rotation = default }));
        RequireInvalid(() => rope.BeginExtension(float.NaN));
        if (rope.StepCount != 0 || rope.RenderFrameCount != 0 || !rope.IsExtending ||
            !rope.Snapshot().SequenceEqual(before))
        {
            throw new Exception("Rejected render input consumed extension, physics or a render generation.");
        }
        return malformed.Length + 6;
    }

    private static int VerifyGateOrder(JsonElement initial)
    {
        using NativeHelicopterRope rope = NativeHelicopterRopeTests.Create(initial);
        float targetHeight = rope.Snapshot()[^1].Pose.Position.Y + 0.1f;
        rope.BeginExtension(targetHeight);
        HelicopterRopeBodyPose aircraft = AircraftFromAttachment(initial.GetProperty("attachment"));
        aircraft = aircraft with { Position = aircraft.Position + new Vector3(0, 2, 0) };
        rope.UpdateRenderFrame(0.03f, aircraft);
        if (rope.IsExtending || rope.Snapshot().Count != 4 || rope.Snapshot()[^1].Pose.Position.Y <= targetHeight)
        {
            throw new Exception("The height gate was evaluated after moving the aircraft.");
        }
        rope.UpdateRenderFrame(0.03f, aircraft);
        if (rope.IsExtending || rope.Snapshot().Count != 4)
        {
            throw new Exception("Completed extension resumed without a new ShowRope request.");
        }
        rope.BeginExtension(targetHeight);
        rope.UpdateRenderFrame(0.03f, aircraft);
        if (!rope.IsExtending || rope.Snapshot().Count != 5 || rope.StepCount != 0 || rope.RenderFrameCount != 3)
        {
            throw new Exception("An explicit extension restart did not follow the source gate and insertion order.");
        }
        return 7;
    }

    private static int Compare(IReadOnlyList<HelicopterRopeMotionBody> actual, JsonElement expected,
        int scenario, ref Difference maximum)
    {
        if (actual.Count != expected.GetArrayLength())
        {
            throw new Exception("Combined update inserted a body at a different source render frame.");
        }
        for (int index = 0; index < actual.Count; index++)
        {
            JsonElement source = expected[index];
            Quaternion rotation = Rotation(source.GetProperty("rotation"));
            var difference = new Difference(
                Vector3.Distance(actual[index].Pose.Position, Vector(source.GetProperty("position"))),
                MathF.Min((actual[index].Pose.Rotation - rotation).Length(),
                    (actual[index].Pose.Rotation + rotation).Length()),
                Vector3.Distance(actual[index].Velocity, Vector(source.GetProperty("velocity"))),
                Vector3.Distance(actual[index].AngularVelocity, Vector(source.GetProperty("angularVelocity"))));
            if (!difference.IsFinite || difference.Position > PoseTolerance ||
                scenario < 2 && difference.Rotation > PoseTolerance)
            {
                throw new Exception($"Combined rope case {scenario}, body {index}: {difference}.");
            }
            maximum = maximum.Merge(difference);
        }
        return actual.Count * (scenario < 2 ? 3 : 2);
    }

    private static HelicopterRopeBodyPose AircraftFromAttachment(JsonElement values)
    {
        return new HelicopterRopeBodyPose(Vector(values.GetProperty("connectedPosition")),
            Rotation(values.GetProperty("connectedRotation")));
    }

    private static HelicopterRopeBodyPose AircraftFromFrame(JsonElement values)
    {
        return new HelicopterRopeBodyPose(Vector(values.GetProperty("aircraftPosition")),
            Rotation(values.GetProperty("aircraftRotation")));
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
        throw new Exception("Malformed rope render input was accepted.");
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
