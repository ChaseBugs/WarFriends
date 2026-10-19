using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares fixed-step layer clocks and weights with native Play Mode observations.</summary>
internal static class HelicopterSlideFadeTests
{
    private const string ReferenceDigest = "0a9f8eae7a74d4d7353af3e411055ab7f73537fa4184e88790553090b9ea161c";
    private const int ExpectedFrameCount = 16;
    private const int ExpectedScenarioCount = 3;
    private const float ClockTolerance = 0.0000002f;

    internal static int Run(string directory)
    {
        string reference = File.ReadAllText(Path.Combine(directory,
            "recovered-helicopter-fade-unity-reference.json")).Replace("\r\n", "\n");
        if (Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(reference))) != ReferenceDigest)
        {
            throw new InvalidDataException("The native slide fade reference changed without review.");
        }
        using JsonDocument document = JsonDocument.Parse(reference);
        JsonElement root = document.RootElement;
        JsonElement[] frames = root.GetProperty("frames").EnumerateArray().ToArray();
        if (root.GetProperty("captureRate").GetInt32() != MatchManifest.TickRate ||
            frames.Length != ExpectedFrameCount)
        {
            throw new Exception("The native fade fixture has a different frame domain.");
        }
        for (int frame = 0; frame < frames.Length; frame++)
        {
            VerifyFrame(frames[frame], (ulong)frame);
        }
        VerifyBoundary();
        Console.WriteLine("PASS: 48 native Helicopter fade layer pairs, residual boundary and malformed phases");
        return ExpectedFrameCount * ExpectedScenarioCount * 7 + 6;
    }

    private static void VerifyFrame(JsonElement frame, ulong tick)
    {
        JsonElement[] scenarios = frame.GetProperty("scenarios").EnumerateArray().ToArray();
        if (scenarios.Length != ExpectedScenarioCount)
        {
            throw new Exception("Missing native Helicopter fade scenario.");
        }
        foreach (JsonElement scenario in scenarios)
        {
            float phase = scenario.GetProperty("idlePhase").GetSingle();
            HelicopterSlideFadeSnapshot actual = HelicopterSlideFade.AtFixedTicks(phase, tick);
            JsonElement[] states = scenario.GetProperty("states").EnumerateArray().ToArray();
            JsonElement idle = states.Single(state => state.GetProperty("name").GetString() == "idle");
            JsonElement slide = states.Single(state =>
                state.GetProperty("name").GetString() == "helicopter_jump_pose");
            VerifyLayer(actual.Idle, idle);
            VerifyLayer(actual.Slide, slide);
            if (actual.IsSettled != !idle.GetProperty("enabled").GetBoolean())
            {
                throw new Exception($"Host declared a different settled boundary at tick {tick}.");
            }
        }
    }

    private static void VerifyLayer(HelicopterFadeLayer actual, JsonElement expected)
    {
        if (MathF.Abs(actual.RawTime - expected.GetProperty("time").GetSingle()) > ClockTolerance ||
            actual.Weight != expected.GetProperty("weight").GetSingle() ||
            actual.IsEnabled != expected.GetProperty("enabled").GetBoolean())
        {
            throw new Exception($"Host slide fade differs from native layer: {actual} versus {expected}.");
        }
    }

    private static void VerifyBoundary()
    {
        HelicopterSlideFadeSnapshot ninth = HelicopterSlideFade.AtFixedTicks(0, 9);
        if (ninth.IsSettled || ninth.Idle.Weight <= 0 || ninth.Slide.Weight != 1 ||
            !HelicopterSlideFade.AtFixedTicks(0, 10).IsSettled)
        {
            throw new Exception("The outgoing residual must survive tick nine and retire at tick ten.");
        }
        foreach (float phase in new[] { float.NaN, float.PositiveInfinity, float.NegativeInfinity, -1f, 1f })
        {
            try
            {
                HelicopterSlideFade.AtFixedTicks(phase, 0);
                throw new Exception("Malformed idle phase selected a valid transition.");
            }
            catch (InvalidDataException)
            {
                // Invalid phase must not be rounded or wrapped into a captured starting state.
            }
        }
    }
}
