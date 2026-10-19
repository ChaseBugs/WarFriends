using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares aircraft Transform inheritance and subsequent physical steps with original Unity bodies.</summary>
internal static class NativeHelicopterRopeMotionTests
{
    private const string ReferenceDigest = "83f71afc33e30d9b632578afa2023d65ad93de40393cc9bc1d0f230b0486d376";
    private const float NativeTolerance = 0.00002f;

    internal static int Run(string directory)
    {
        string contents = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-rope-motion-unity-reference.json")).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(contents))) != ReferenceDigest)
        {
            throw new Exception("Moving-aircraft capture differs from its reviewed source fixture.");
        }
        using JsonDocument reference = JsonDocument.Parse(contents);
        JsonElement root = reference.RootElement;
        int count = 0;
        for (int scenario = 0; scenario < root.GetProperty("initial").GetArrayLength(); scenario++)
        {
            bool[] children = root.GetProperty("aircraftChildren")[scenario].EnumerateArray()
                .Select(value => value.GetBoolean()).ToArray();
            if (!children.SequenceEqual(new[] { true, false, false, true }))
            {
                throw new Exception("Source root/end inheritance differs from the native adapter's hierarchy.");
            }
            count += VerifyScenario(root, scenario) + 1;
        }
        return count;
    }

    private static int VerifyScenario(JsonElement reference, int scenario)
    {
        using NativeHelicopterRope rope = Create(reference.GetProperty("initial")[scenario]);
        var maximum = new Difference(0, 0, 0, 0);
        int count = VerifyRejectedTransforms(rope);
        foreach (JsonElement frame in reference.GetProperty("frames").EnumerateArray())
        {
            JsonElement before = frame.GetProperty("before")[scenario];
            IReadOnlyList<HelicopterRopeMotionBody> previous = rope.Snapshot();
            ulong previousStep = rope.StepCount;
            rope.ApplyAircraftTransform(Aircraft(before));
            IReadOnlyList<HelicopterRopeMotionBody> moved = rope.Snapshot();
            if (rope.StepCount != previousStep || moved[1] != previous[1] || moved[2] != previous[2] ||
                moved[0].Velocity != previous[0].Velocity || moved[^1].Velocity != previous[^1].Velocity ||
                moved[0].AngularVelocity != previous[0].AngularVelocity ||
                moved[^1].AngularVelocity != previous[^1].AngularVelocity)
            {
                throw new Exception("Aircraft Transform changed unparented bodies, physical time or linear velocity.");
            }
            count += Compare(moved, before.GetProperty("joints"),
                new ComparisonFrame(scenario, previousStep), ref maximum);
            rope.Advance();
            count += Compare(rope.Snapshot(), frame.GetProperty("after")[scenario].GetProperty("joints"),
                new ComparisonFrame(scenario, rope.StepCount), ref maximum);
            count++;
        }
        string label = scenario < 2 ? "PASS: source positions/rotations" : "DIAGNOSTIC: tilted moving-aircraft";
        Console.WriteLine($"{label} case {scenario}: {maximum}. Accumulated speeds remain diagnostic.");
        return count;
    }

    private static int VerifyRejectedTransforms(NativeHelicopterRope rope)
    {
        IReadOnlyList<HelicopterRopeMotionBody> original = rope.Snapshot();
        HelicopterRopeBodyPose[] malformed =
        {
            new(new Vector3(float.NaN), Quaternion.Identity),
            new(Vector3.Zero, default),
            new(Vector3.Zero, new Quaternion(0, 0, 0, 2))
        };
        foreach (HelicopterRopeBodyPose pose in malformed)
        {
            try
            {
                rope.ApplyAircraftTransform(pose);
                throw new Exception("Invalid aircraft pose was accepted.");
            }
            catch (InvalidDataException)
            {
                // Validation must reject before changing the owned SDK scene.
            }
        }
        if (rope.StepCount != 0 || !rope.Snapshot().SequenceEqual(original))
        {
            throw new Exception("Rejected aircraft pose changed native state or physics time.");
        }
        return malformed.Length + 2;
    }

    private static int Compare(IReadOnlyList<HelicopterRopeMotionBody> actual, JsonElement expected,
        ComparisonFrame frame, ref Difference maximum)
    {
        if (actual.Count != expected.GetArrayLength())
        {
            throw new Exception("Moving-aircraft rope topology differs from Unity.");
        }
        int count = 0;
        for (int index = 0; index < actual.Count; index++)
        {
            HelicopterRopeMotionBody body = actual[index];
            JsonElement source = expected[index];
            float positionError = Vector3.Distance(body.Pose.Position, Vector(source.GetProperty("position")));
            Quaternion rotation = Rotation(source.GetProperty("rotation"));
            float rotationError = MathF.Min((body.Pose.Rotation - rotation).Length(),
                (body.Pose.Rotation + rotation).Length());
            float velocityError = Vector3.Distance(body.Velocity, Vector(source.GetProperty("velocity")));
            float angularError = Vector3.Distance(body.AngularVelocity, Vector(source.GetProperty("angularVelocity")));
            var difference = new Difference(positionError, rotationError, velocityError, angularError);
            if (!difference.IsFinite)
            {
                throw new Exception("Moving-aircraft motion difference is not finite.");
            }
            maximum = maximum.Merge(difference);
            count++;
            if ((frame.Scenario < 2 || frame.Step == 0) &&
                (positionError > NativeTolerance || rotationError > NativeTolerance))
            {
                throw new Exception(
                    $"Moving-aircraft mismatch: case {frame.Scenario}, step {frame.Step}, body {index}: " +
                    $"position {positionError}, rotation {rotationError}, " +
                    $"velocity {velocityError}, angular {angularError}.");
            }
            if (frame.Scenario < 2 || frame.Step == 0)
            {
                count += 2;
            }
            // Accumulated speeds retain diagnostic differences between the SDK and Unity at translated coordinates.
            if (frame.Scenario < 2 && frame.Step <= 1)
            {
                if (velocityError > NativeTolerance || angularError > NativeTolerance)
                {
                    throw new Exception("The initial moving-aircraft physical step differs from Unity.");
                }
                count += 2;
            }
        }
        return count;
    }

    private static NativeHelicopterRope Create(JsonElement scenario)
    {
        JsonElement joints = scenario.GetProperty("joints");
        HelicopterRopeInitialState initial = HelicopterRopeInitialization.Create(
            Vector(joints[0].GetProperty("position")),
            Vector(joints[joints.GetArrayLength() - 1].GetProperty("position")),
            scenario.GetProperty("requestedSpacing").GetSingle());
        return new NativeHelicopterRope(initial, Aircraft(scenario),
            Rotation(scenario.GetProperty("attachmentConnectedRestRotation")));
    }

    private static HelicopterRopeBodyPose Aircraft(JsonElement scenario)
    {
        JsonElement attachment = scenario.GetProperty("attachment");
        return new HelicopterRopeBodyPose(Vector(attachment.GetProperty("connectedPosition")),
            Rotation(attachment.GetProperty("connectedRotation")));
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

    private readonly record struct ComparisonFrame(int Scenario, ulong Step);

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
