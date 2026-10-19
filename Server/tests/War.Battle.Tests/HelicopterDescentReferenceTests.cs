using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares descent ordering and poses with the recovered method invoked inside Unity.</summary>
internal static class HelicopterDescentReferenceTests
{
    private const string ReferenceDigest = "5b34f17ec3bb4c85ccbd785e6957473a6d25bbfc0d5a0af991b34a6cd90dd0ca";
    private const string ControllerDigest = "175413835772f6c538132930f5c5b3fbe93d147a737a5087d265622acb74aae0";
    private const float PositionTolerance = 0.00001f;
    private const float RotationTolerance = 0.00001f;

    internal static int Run(string directory)
    {
        string filename = Path.Combine(directory, "recovered-helicopter-descent-unity-reference.json");
        string text = File.ReadAllText(filename).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) != ReferenceDigest)
        {
            throw new Exception("Source descent reference changed without review.");
        }
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement root = document.RootElement;
        JsonElement frames = root.GetProperty("frames");
        if (root.GetProperty("descentControllerSha256").GetString() != ControllerDigest ||
            frames.GetArrayLength() != 16 || !root.GetProperty("visibilityProbe").GetBoolean())
        {
            throw new Exception("Source descent reference lost its source, timing or visibility coverage.");
        }
        for (int scenario = 0; scenario < 3; scenario++)
        {
            VerifyScenario(frames, scenario);
        }
        Console.WriteLine("PASS: 45 descent steps match the actual recovered Unity method with animated palms.");
        return 45 * 3;
    }

    private static void VerifyScenario(JsonElement frames, int scenario)
    {
        JsonElement initial = frames[0].GetProperty("scenarios")[scenario].GetProperty("descent");
        var state = new HelicopterDescentState(initial.GetProperty("startHeight").GetSingle(),
            initial.GetProperty("landingHeight").GetSingle());
        Vector3 previousPosition = ReadVector(initial.GetProperty("position"));
        Quaternion previousRotation = ReadRotation(initial.GetProperty("rotation"));
        for (int index = 1; index < frames.GetArrayLength(); index++)
        {
            JsonElement frame = frames[index];
            JsonElement row = frame.GetProperty("scenarios")[scenario].GetProperty("descent");
            JsonElement input = row.GetProperty("input");
            var pose = new HelicopterDescentFrame(ReadVector(input.GetProperty("root")),
                ReadRotation(input.GetProperty("rotation")), ReadVector(input.GetProperty("palm")),
                ReadVector(input.GetProperty("helicopterRight")));
            if (pose.RootPosition != previousPosition || pose.RootRotation != previousRotation ||
                !row.GetProperty("advanced").GetBoolean())
            {
                throw new Exception("Source descent lost the previous output pose before its next alignment.");
            }
            Vector3[] joints = input.GetProperty("joints").EnumerateArray().Select(ReadVector).ToArray();
            HelicopterDescentResult result = state.Advance(pose, frame.GetProperty("deltaTime").GetSingle(), joints);
            previousPosition = ReadVector(row.GetProperty("position"));
            previousRotation = ReadRotation(row.GetProperty("rotation"));
            float rotationDifference = MathF.Min((result.Rotation - previousRotation).Length(),
                (result.Rotation + previousRotation).Length());
            if (Vector3.Distance(result.Position, previousPosition) > PositionTolerance ||
                rotationDifference > RotationTolerance || result.Progress != row.GetProperty("progress").GetSingle())
            {
                throw new Exception($"Source descent differs at scenario {scenario}, frame {index}: {result}.");
            }
        }
    }

    private static Vector3 ReadVector(JsonElement value)
    {
        return new Vector3(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
    }

    private static Quaternion ReadRotation(JsonElement value)
    {
        return new Quaternion(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle(), value[3].GetSingle());
    }
}
