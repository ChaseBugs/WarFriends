using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

/// <summary>Prevents treating a moving crew point's rotation as the source soldier's Driving rotation.</summary>
internal static class HelicopterDrivingReferenceTests
{
    private const string ReferenceDigest = "acc7ceb748ad671e31fdae3abb86b3ea06c75848ba9d6d654fa6d5faa23828c6";
    private const float RotationTolerance = 0.00001f;

    internal static int Run(string directory)
    {
        string text = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-driving-unity-reference.json")).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) != ReferenceDigest)
        {
            throw new Exception("Source Driving reference changed without review.");
        }
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement scenarios = document.RootElement.GetProperty("scenarios");
        if (scenarios.GetArrayLength() != 6)
        {
            throw new Exception("Driving reference lost source crew slots.");
        }
        foreach (JsonElement scenario in scenarios.EnumerateArray())
        {
            VerifyScenario(scenario);
        }
        Console.WriteLine("PASS: 96 source Driving observations follow point position " +
            "and retain completed entry rotation.");
        return 96 * 2;
    }

    private static void VerifyScenario(JsonElement scenario)
    {
        Quaternion completed = Rotation(scenario.GetProperty("completedRotation"));
        if (Difference(completed, Rotation(scenario.GetProperty("entryTarget"))) > RotationTolerance)
        {
            throw new Exception("Completed source entry tween differs from its captured initial target.");
        }
        JsonElement frames = scenario.GetProperty("frames");
        if (frames.GetArrayLength() != 16)
        {
            throw new Exception("Driving reference lost its frame coverage.");
        }
        foreach (JsonElement frame in frames.EnumerateArray())
        {
            if (Vector(frame.GetProperty("pointPosition")) != Vector(frame.GetProperty("soldierPosition")) ||
                Difference(completed, Rotation(frame.GetProperty("soldierRotation"))) > RotationTolerance)
            {
                throw new Exception("Source Driving must follow point position " +
                    "without following later point rotation.");
            }
        }
        if (Difference(completed, Rotation(frames[15].GetProperty("pointRotation"))) < 0.1f ||
            Vector(frames[0].GetProperty("pointPosition")) == Vector(frames[15].GetProperty("pointPosition")))
        {
            throw new Exception("Driving fixture never separated moving point position/rotation from the soldier.");
        }
    }

    private static float Difference(Quaternion first, Quaternion second)
    {
        return MathF.Min((first - second).Length(), (first + second).Length());
    }

    private static Vector3 Vector(JsonElement value)
    {
        return new Vector3(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
    }

    private static Quaternion Rotation(JsonElement value)
    {
        return new Quaternion(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle(), value[3].GetSingle());
    }
}
