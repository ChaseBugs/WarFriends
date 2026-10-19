using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Exercises the real C ABI, scene ownership, bounded capacity and captured Unity motion.</summary>
internal static class NativeHelicopterRopeTests
{
    private const float NativeTolerance = 0.00002f;
    private const int MaximumRopes = 64;
    private const string ReferenceDigest = "e87743347ee3fa3d7cb75ced89ab8e4d756e853b86e9751c77e3ec421ac4fc11";

    internal static int Run(string directory)
    {
        string contents = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-rope-physics-unity-reference.json")).Replace("\r\n", "\n");
        string digest = Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(contents)));
        if (digest != ReferenceDigest)
        {
            throw new Exception("Native adapter reference differs from the reviewed creation-time capture.");
        }
        using JsonDocument reference = JsonDocument.Parse(contents);
        JsonElement[] initial = reference.RootElement.GetProperty("initial").EnumerateArray().ToArray();
        JsonElement[] frames = reference.RootElement.GetProperty("frames").EnumerateArray().ToArray();
        int checks = 0;
        for (int scenario = 0; scenario < initial.Length; scenario++)
        {
            checks += VerifyTrajectory(initial[scenario], frames, scenario);
        }
        checks += VerifyOwnership(initial[0]);
        checks += VerifyCapacity(initial[0]);
        if (NativeRopeMethods.GetAbiVersion() != 1 ||
            NativeRopeMethods.Create(Array.Empty<float>(), 0, 4, out IntPtr invalid) != 1 || invalid != IntPtr.Zero ||
            NativeRopeMethods.Destroy(IntPtr.Zero) != 1)
        {
            throw new Exception("The native ABI accepted malformed input or an unknown registry identity.");
        }
        return checks + 4;
    }

    private static int VerifyTrajectory(JsonElement initial, JsonElement[] frames, int scenario)
    {
        using NativeHelicopterRope rope = Create(initial);
        float maximumPositionError = 0;
        int checks = 0;
        foreach (JsonElement frame in frames)
        {
            rope.Advance();
            IReadOnlyList<HelicopterRopeMotionBody> actual = rope.Snapshot();
            JsonElement expected = frame.GetProperty("ropes")[scenario].GetProperty("joints");
            if (expected.GetArrayLength() != actual.Count)
            {
                throw new Exception("Native adapter returned a different rope topology.");
            }
            for (int index = 0; index < actual.Count; index++)
            {
                HelicopterRopeMotionBody body = actual[index];
                Quaternion rotation = ReadRotation(expected[index].GetProperty("rotation"));
                float positionError = Vector3.Distance(body.Pose.Position, ReadVector(expected[index], "position"));
                maximumPositionError = MathF.Max(maximumPositionError, positionError);
                if (scenario < 2 && (positionError > NativeTolerance ||
                    Vector3.Distance(body.Velocity, ReadVector(expected[index], "velocity")) > NativeTolerance ||
                    Vector3.Distance(body.AngularVelocity, ReadVector(expected[index], "angularVelocity")) >
                        NativeTolerance ||
                    MathF.Min((body.Pose.Rotation - rotation).Length(),
                        (body.Pose.Rotation + rotation).Length()) > NativeTolerance))
                {
                    throw new Exception(
                        $"Native bridge differs from Unity at scenario {scenario}, step {rope.StepCount}.");
                }
                checks += scenario < 2 ? 4 : 1;
            }
            if (rope.StepCount != frame.GetProperty("step").GetUInt64())
            {
                throw new Exception("Native physics step count differs from its captured fixed-step clock.");
            }
            checks++;
        }
        string label = scenario < 2 ? "PASS" : "DIAGNOSTIC";
        Console.WriteLine($"{label}: native adapter case {scenario}, maximum position error {maximumPositionError}.");
        return checks;
    }

    private static int VerifyOwnership(JsonElement initial)
    {
        using NativeHelicopterRope first = Create(initial);
        using NativeHelicopterRope second = Create(initial);
        IReadOnlyList<HelicopterRopeMotionBody> retained = first.Snapshot();
        Vector3 originalPosition = retained[1].Pose.Position;
        first.Advance();
        if (retained[1].Pose.Position != originalPosition || second.Snapshot()[1].Pose.Position != originalPosition ||
            first.Snapshot()[1].Pose.Position == originalPosition)
        {
            throw new Exception("A native scene step changed another owner or a retained snapshot.");
        }
        first.Dispose();
        first.Dispose();
        RequireDisposed(() => first.Advance());
        RequireDisposed(() => first.Snapshot());
        second.Advance();
        return 5;
    }

    private static int VerifyCapacity(JsonElement initial)
    {
        var owners = new List<NativeHelicopterRope>();
        try
        {
            for (int index = 0; index < MaximumRopes; index++)
            {
                owners.Add(Create(initial));
            }
            try
            {
                using NativeHelicopterRope excess = Create(initial);
                throw new Exception("Native rope capacity was not enforced.");
            }
            catch (InvalidOperationException exception) when (exception.Message.Contains("status 2"))
            {
                // Capacity rejection must leave all existing owners usable.
                owners[0].Advance();
            }
        }
        finally
        {
            foreach (NativeHelicopterRope owner in owners)
            {
                owner.Dispose();
            }
        }
        using NativeHelicopterRope replacement = Create(initial);
        replacement.Advance();
        return MaximumRopes + 3;
    }

    private static NativeHelicopterRope Create(JsonElement scenario)
    {
        JsonElement joints = scenario.GetProperty("joints");
        HelicopterRopeInitialState initial = HelicopterRopeInitialization.Create(
            ReadVector(joints[0], "position"), ReadVector(joints[joints.GetArrayLength() - 1], "position"),
            scenario.GetProperty("requestedSpacing").GetSingle());
        JsonElement attachment = scenario.GetProperty("attachment");
        var aircraft = new HelicopterRopeBodyPose(ReadVector(attachment, "connectedPosition"),
            ReadRotation(attachment.GetProperty("connectedRotation")));
        return new NativeHelicopterRope(initial, aircraft,
            ReadRotation(scenario.GetProperty("attachmentConnectedRestRotation")));
    }

    private static Vector3 ReadVector(JsonElement owner, string property)
    {
        JsonElement values = owner.GetProperty(property);
        return new Vector3(values[0].GetSingle(), values[1].GetSingle(), values[2].GetSingle());
    }

    private static Quaternion ReadRotation(JsonElement values)
    {
        return new Quaternion(values[0].GetSingle(), values[1].GetSingle(),
            values[2].GetSingle(), values[3].GetSingle());
    }

    private static void RequireDisposed(Action action)
    {
        try
        {
            action();
        }
        catch (ObjectDisposedException)
        {
            return;
        }
        throw new Exception("A disposed native rope remained usable.");
    }
}
