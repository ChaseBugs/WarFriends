using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

using War.BattleServer;

/// <summary>Replays actual automatic source tween dispatch, including first-frame Start/Update and reuse.</summary>
internal static class HelicopterCrewEntryLifecycleTests
{
    private const string ReferenceDigest = "544867587054596fec9d31fa32996ada4f56a6a06c07ddf4712919b21773bc1b";
    private const float RotationTolerance = 0.00001f;

    internal static int Run(string directory)
    {
        string text = File.ReadAllText(Path.Combine(directory,
            "recovered-crew-entry-lifecycle-unity-reference.json")).Replace("\r\n", "\n");
        Require(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) == ReferenceDigest,
            "Automatic crew entry capture changed without review.");
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement scenarios = document.RootElement.GetProperty("scenarios");
        Require(scenarios.GetArrayLength() == 6, "Automatic entry lost its clock-mode/parent coverage.");
        int checks = 0;
        foreach (JsonElement scenario in scenarios.EnumerateArray())
        {
            JsonElement first = scenario.GetProperty("first");
            var entry = new HelicopterCrewEntryState(Rotation(first.GetProperty("from")),
                Rotation(first.GetProperty("target")), Rotation(scenario.GetProperty("parent")), 0);
            JsonElement firstRows = first.GetProperty("rows");
            Require(firstRows[0].GetProperty("frame").GetInt32() ==
                firstRows[1].GetProperty("frame").GetInt32(),
                "Fresh source tween lost automatic Start plus Update in the same frame.");
            checks += VerifyCycle(first, entry);
            checks += VerifyCycle(scenario.GetProperty("reused"), entry);
        }
        Require(checks == 342, "Automatic crew entry lost evaluated updates or reuse coverage.");
        Console.WriteLine("PASS: 342 automatic source entry updates, first-frame double dispatch and retained reuse.");
        return checks;
    }

    private static int VerifyCycle(JsonElement cycle, HelicopterCrewEntryState entry)
    {
        entry.Restart(Rotation(cycle.GetProperty("from")), Rotation(cycle.GetProperty("target")));
        entry.ReenableAt(cycle.GetProperty("enabledAt").GetSingle());
        bool isUnscaled = cycle.GetProperty("ignoreTimeScale").GetBoolean();
        JsonElement rows = cycle.GetProperty("rows");
        float maximumError = 0;
        foreach (JsonElement row in rows.EnumerateArray())
        {
            HelicopterRopeBodyPose pose = isUnscaled
                ? entry.AdvanceUpdate(row.GetProperty("realtime").GetSingle(), Vector3.One)
                : entry.AdvanceScaledUpdate(row.GetProperty("scaledDelta").GetSingle(), Vector3.One);
            Quaternion expected = Rotation(row.GetProperty("rotation"));
            float error = MathF.Min((pose.Rotation - expected).Length(), (pose.Rotation + expected).Length());
            Require(error < RotationTolerance && pose.Position == Vector3.One &&
                entry.IsRotating == row.GetProperty("enabled").GetBoolean(),
                $"Automatic entry differs at frame {row.GetProperty("frame")}: rotation error {error}.");
            maximumError = MathF.Max(maximumError, error);
        }
        Require(!entry.IsRotating, "Automatic entry did not retain source completion.");
        Console.WriteLine($"PASS: {rows.GetArrayLength()} automatic entry observations; maximum error {maximumError}.");
        return rows.GetArrayLength();
    }

    private static Quaternion Rotation(JsonElement value)
    {
        return new Quaternion(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle(), value[3].GetSingle());
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
