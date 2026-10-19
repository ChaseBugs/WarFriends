using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares host rope alignment with the actual recovered Unity method.</summary>
internal static class HelicopterRopeAlignmentTests
{
    private const string ReferenceDigest = "33698f7b21d8f24356fd7829d1031ce756e41115f6c97172982d3e4816fb5c32";
    private const string ControllerDigest = "175413835772f6c538132930f5c5b3fbe93d147a737a5087d265622acb74aae0";
    private const int ExpectedCaseCount = 24;
    private const int OversizedJointCount = 257;
    private const float PositionTolerance = 0.00002f;

    internal static int Run(string directory)
    {
        string reference = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-rope-alignment-unity-reference.json")).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(reference))) != ReferenceDigest)
        {
            throw new Exception("The Unity rope alignment reference changed without review.");
        }
        using JsonDocument document = JsonDocument.Parse(reference);
        JsonElement root = document.RootElement;
        JsonElement[] cases = root.GetProperty("cases").EnumerateArray().ToArray();
        if (root.GetProperty("version").GetInt32() != 1 ||
            root.GetProperty("unity").GetString() != "2018.3.0f2" ||
            root.GetProperty("sourceSha256").GetString() != ControllerDigest || cases.Length != ExpectedCaseCount)
        {
            throw new Exception("The rope reference lost its source identity or complete scenario set.");
        }
        foreach (JsonElement scenario in cases)
        {
            VerifyScenario(scenario);
        }
        int checks = 2 + cases.Length * 2 + VerifyInvalidInputs();
        Console.WriteLine($"PASS: {checks} rope alignment checks, including 24 actual recovered Unity cases");
        return checks + HelicopterDescentStateTests.Run();
    }

    private static void VerifyScenario(JsonElement scenario)
    {
        float[] rotation = scenario.GetProperty("rootRotation").EnumerateArray()
            .Select(value => value.GetSingle()).ToArray();
        var pose = new HelicopterRopeAlignmentPose(Vector(scenario.GetProperty("basePosition")),
            Vector(scenario.GetProperty("rootPosition")), Vector(scenario.GetProperty("leftPalmPosition")),
            new Quaternion(rotation[0], rotation[1], rotation[2], rotation[3]));
        JsonElement jointRows = scenario.GetProperty("joints");
        Vector3[]? joints = jointRows.ValueKind == JsonValueKind.Null
            ? null : jointRows.EnumerateArray().Select(Vector).ToArray();
        Vector3[]? before = joints?.ToArray();
        Vector3 result = HelicopterRopeAlignment.Align(pose, joints);
        if (Vector3.Distance(result, Vector(scenario.GetProperty("expected"))) > PositionTolerance)
        {
            throw new Exception("Host rope alignment differs from the actual recovered Unity method.");
        }
        if (joints != null && !joints.SequenceEqual(before!))
        {
            throw new Exception("Aligning a soldier changed the shared rope's joint positions.");
        }
    }

    private static int VerifyInvalidInputs()
    {
        var pose = new HelicopterRopeAlignmentPose(Vector3.Zero, Vector3.Zero, Vector3.UnitY, Quaternion.Identity);
        RequireInvalid(pose with { RootRotation = default }, null);
        RequireInvalid(pose with { BasePosition = new Vector3(float.NaN, 0, 0) }, null);
        RequireInvalid(pose with
        {
            BasePosition = new Vector3(float.MaxValue), LeftPalmPosition = new Vector3(float.MaxValue)
        }, null);
        RequireInvalid(pose, []);
        RequireInvalid(pose, new Vector3[OversizedJointCount]);
        RequireInvalid(pose, [Vector3.Zero, new Vector3(float.NaN, 0, 0)]);
        return 6;
    }

    private static void RequireInvalid(HelicopterRopeAlignmentPose pose, IReadOnlyList<Vector3>? joints)
    {
        try
        {
            HelicopterRopeAlignment.Align(pose, joints);
            throw new Exception("Invalid host rope alignment authority was accepted.");
        }
        catch (InvalidDataException)
        {
            // Invalid geometry must not be clamped into a plausible soldier position.
        }
    }

    private static Vector3 Vector(JsonElement vector)
    {
        float[] components = vector.EnumerateArray().Select(value => value.GetSingle()).ToArray();
        return new Vector3(components[0], components[1], components[2]);
    }
}
