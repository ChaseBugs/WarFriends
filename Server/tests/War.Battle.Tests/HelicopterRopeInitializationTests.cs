using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>
/// Checks generated prefab geometry, connection intent and composed extension commands against Unity.
/// </summary>
internal static class HelicopterRopeInitializationTests
{
    private const string ReferenceDigest = "dcd98cbe299229188790412d601a2ebef4ded4e8aa2fc0ab75286bda346563e4";
    private const int ExpectedCases = 9;
    private const int ExpectedExtensionSteps = 8;
    private const float PoseTolerance = 0.00001f;
    private const float DistanceTolerance = 0.000001f;

    internal static int Run(string directory)
    {
        string reference = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-rope-initialization-unity-reference.json")).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(reference))) != ReferenceDigest)
        {
            throw new InvalidDataException("The native rope initialization reference changed without review.");
        }
        using JsonDocument document = JsonDocument.Parse(reference);
        JsonElement root = document.RootElement;
        JsonElement[] cases = root.GetProperty("cases").EnumerateArray().ToArray();
        if (cases.Length != ExpectedCases)
        {
            throw new Exception("Native rope initialization cases are incomplete.");
        }
        int count = 0;
        foreach (JsonElement scenario in cases)
        {
            count += VerifyCase(scenario, root.GetProperty("extensionDeltaTime").GetSingle());
        }
        VerifyInvalidInputs();
        VerifyMeasuredDistanceAndOwnership(cases[0]);
        Console.WriteLine("PASS: nine native rope initializations, 36 joint setups and 72 composed extensions");
        return count + 10;
    }

    private static int VerifyCase(JsonElement scenario, float deltaTime)
    {
        HelicopterRopeInitialState state = Create(scenario);
        JsonElement[] expected = scenario.GetProperty("joints").EnumerateArray().ToArray();
        if (state.Joints.Count != expected.Length || MathF.Abs(state.InitialJointDistance -
            scenario.GetProperty("initialDistance").GetSingle()) > DistanceTolerance)
        {
            throw new Exception("Generated joint count or initial measured spacing differs from Unity.");
        }
        int count = 2;
        for (int index = 0; index < expected.Length; index++)
        {
            VerifyJoint(state.Joints[index], expected[index]);
            count += 4;
        }
        return count + VerifyExtensions(state, scenario, deltaTime);
    }

    private static void VerifyJoint(HelicopterRopeInitialJoint actual, JsonElement expected)
    {
        float[] components = expected.GetProperty("rotation").EnumerateArray()
            .Select(value => value.GetSingle()).ToArray();
        var rotation = new Quaternion(components[0], components[1], components[2], components[3]);
        float rotationError = MathF.Min(
            (actual.Rotation - rotation).Length(), (actual.Rotation + rotation).Length());
        float positionError = Vector3.Distance(actual.Position, Vector(expected.GetProperty("position")));
        if (!float.IsFinite(positionError) || !float.IsFinite(rotationError) ||
            positionError > PoseTolerance || rotationError > PoseTolerance)
        {
            throw new Exception(
                $"Native rope joint pose mismatch: position {positionError}, rotation {rotationError}.");
        }
        HelicopterRopeBodySetup body = actual.Body;
        if (body.Mass != expected.GetProperty("mass").GetSingle() ||
            body.Drag != expected.GetProperty("drag").GetSingle() ||
            body.AngularDrag != expected.GetProperty("angularDrag").GetSingle() ||
            body.ShouldUseGravity != expected.GetProperty("useGravity").GetBoolean() ||
            body.IsKinematic != expected.GetProperty("isKinematic").GetBoolean() ||
            body.HasFrozenAxes || expected.GetProperty("constraints").GetString() != "None")
        {
            throw new Exception("Host rope body setup differs from the source prefab.");
        }
        VerifyConnection(actual.Connection, expected.GetProperty("connection"));
    }

    private static void VerifyConnection(HelicopterRopeConnectionSetup? actual, JsonElement expected)
    {
        if (expected.ValueKind == JsonValueKind.Null && actual == null)
        {
            return;
        }
        if (actual == null || expected.ValueKind == JsonValueKind.Null ||
            actual.ConnectedJointIndex != expected.GetProperty("connectedIndex").GetInt32() ||
            actual.ShouldAutoConfigureConnectedAnchor !=
                expected.GetProperty("autoConfigureConnectedAnchor").GetBoolean())
        {
            throw new Exception("Host rope connection identity differs from Unity.");
        }
        if (!actual.ShouldLockLinearMotion || !actual.ShouldLimitAngularMotion ||
            new[] { "xMotion", "yMotion", "zMotion" }.Any(name => expected.GetProperty(name).GetString() != "Locked") ||
            new[] { "angularX", "angularY", "angularZ" }
                .Any(name => expected.GetProperty(name).GetString() != "Limited") ||
            actual.AngularLimits.MinimumX != expected.GetProperty("lowX").GetSingle() ||
            actual.AngularLimits.MaximumX != expected.GetProperty("highX").GetSingle() ||
            actual.AngularLimits.MaximumY != expected.GetProperty("limitY").GetSingle() ||
            actual.AngularLimits.MaximumZ != expected.GetProperty("limitZ").GetSingle())
        {
            throw new Exception("Host rope translation/angle limits differ from Unity.");
        }
    }

    private static int VerifyExtensions(HelicopterRopeInitialState state, JsonElement scenario, float deltaTime)
    {
        var positions = state.Joints.Select(joint => joint.Position).ToList();
        JsonElement[] steps = scenario.GetProperty("extensions").EnumerateArray().ToArray();
        if (steps.Length != ExpectedExtensionSteps)
        {
            throw new Exception("Native composed rope extension sequence is truncated.");
        }
        int count = 0;
        foreach (JsonElement step in steps)
        {
            var head = new HelicopterRopeHead(positions[0], positions[1], positions[2]);
            HelicopterRopeExtensionResult command = HelicopterRopeExtension.Prepare(
                head, state.InitialJointDistance, deltaTime);
            positions[1] = command.MovedFirst;
            if (command.InsertedPosition is Vector3 inserted)
            {
                positions.Insert(1, inserted);
            }
            JsonElement[] expected = step.GetProperty("positions").EnumerateArray().ToArray();
            if (positions.Count != expected.Length || positions.Where((position, index) =>
                Vector3.Distance(position, Vector(expected[index])) > PoseTolerance).Any())
            {
                throw new Exception("Initialized rope extension sequence differs from recovered Unity calls.");
            }
            count += positions.Count + 1;
        }
        return count;
    }

    private static void VerifyMeasuredDistanceAndOwnership(JsonElement scenario)
    {
        HelicopterRopeInitialState state = Create(scenario);
        if (state.InitialJointDistance - scenario.GetProperty("requestedSpacing").GetSingle() <= DistanceTolerance)
        {
            throw new Exception("Requested spacing replaced the source's measured distance.");
        }
        if (state.Joints is not IList<HelicopterRopeInitialJoint> owned || !owned.IsReadOnly)
        {
            throw new Exception("A caller can change the generated joint sequence after measurement.");
        }
    }

    private static void VerifyInvalidInputs()
    {
        foreach (float spacing in new[] { 0f, -1f, float.NaN, float.PositiveInfinity })
        {
            RequireInvalid(() => HelicopterRopeInitialization.Create(Vector3.Zero, -Vector3.UnitY, spacing));
        }
        RequireInvalid(() => HelicopterRopeInitialization.Create(new Vector3(float.NaN), -Vector3.UnitY, 0.35f));
        RequireInvalid(() => HelicopterRopeInitialization.Create(Vector3.Zero, new Vector3(float.NaN), 0.35f));
        RequireInvalid(() => HelicopterRopeInitialization.Create(Vector3.Zero, Vector3.Zero, 0.35f));
        RequireInvalid(() => HelicopterRopeInitialization.Create(
            new Vector3(float.MaxValue), new Vector3(-float.MaxValue), 0.35f));
    }

    private static void RequireInvalid(Action action)
    {
        try
        {
            action();
            throw new Exception("Invalid rope endpoints or spacing produced a valid setup.");
        }
        catch (InvalidDataException)
        {
            // Reject before publishing any generated body or connection state.
        }
    }

    private static HelicopterRopeInitialState Create(JsonElement scenario)
    {
        return HelicopterRopeInitialization.Create(Vector(scenario.GetProperty("anchor")),
            Vector(scenario.GetProperty("end")), scenario.GetProperty("requestedSpacing").GetSingle());
    }

    private static Vector3 Vector(JsonElement value)
    {
        return new Vector3(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
    }
}
