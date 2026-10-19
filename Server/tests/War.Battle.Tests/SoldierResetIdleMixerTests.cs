using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks actual Reset/Idle calls through the fade and across the ordinary idle loop boundary.</summary>
internal static class SoldierResetIdleMixerTests
{
    private const string ReferenceDigest = "8490940e2e5173766160714a483dbbd43a6b08db09a027eb0d7c0f21d48d26c1";
    private const float ClockTolerance = 0.0000002f;

    internal static int Run(string directory)
    {
        string text = File.ReadAllText(Path.Combine(directory,
            "recovered-soldier-reset-idle-unity-reference.json")).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(text))) != ReferenceDigest)
        {
            throw new Exception("Source Reset-to-Idle reference changed without review.");
        }
        using JsonDocument document = JsonDocument.Parse(text);
        JsonElement root = document.RootElement;
        JsonElement frames = root.GetProperty("frames");
        if (!root.GetProperty("idleResetProbe").GetBoolean() || frames.GetArrayLength() != 37)
        {
            throw new Exception("Reset-to-Idle capture lost its source sequence or loop-boundary coverage.");
        }
        for (int index = 0; index < frames.GetArrayLength(); index++)
        {
            SoldierResetIdleSnapshot state = SoldierResetIdleMixer.AtFixedTicks((ulong)index);
            JsonElement scenarios = frames[index].GetProperty("scenarios");
            if (scenarios.GetArrayLength() != 3)
            {
                throw new Exception("Reset-to-Idle capture lost a prior sampled slide phase.");
            }
            foreach (JsonElement scenario in scenarios.EnumerateArray())
            {
                VerifyLayer(state.Idle, scenario, "idle");
                VerifyLayer(state.StoppedSlide, scenario, "helicopter_jump_pose");
            }
        }
        Console.WriteLine("PASS: 111 source Reset-to-Idle layer snapshots, fade-in and raw clock beyond one loop.");
        return 37 * 3 * 4;
    }

    private static void VerifyLayer(HelicopterFadeLayer actual, JsonElement scenario, string name)
    {
        JsonElement expected = scenario.GetProperty("states").EnumerateArray()
            .Single(state => state.GetProperty("name").GetString() == name);
        if (!scenario.GetProperty("componentEnabled").GetBoolean() ||
            actual.IsEnabled != expected.GetProperty("enabled").GetBoolean() ||
            MathF.Abs(actual.Weight - expected.GetProperty("weight").GetSingle()) > ClockTolerance ||
            MathF.Abs(actual.RawTime - expected.GetProperty("time").GetSingle()) > ClockTolerance)
        {
            throw new Exception($"Source Reset-to-Idle {name} state differs: {actual}, expected {expected}.");
        }
    }
}
