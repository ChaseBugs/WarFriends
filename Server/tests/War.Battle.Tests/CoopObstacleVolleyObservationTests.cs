using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

/// <summary>Binds actual controller frame observations to the recovered rig and host volley plan.</summary>
internal static class CoopObstacleVolleyObservationTests
{
    private const string ReviewedSha256 = "f156748b15b84d6554fa19c9cce1af05089e6ef15c45971eb3761e6dfa1a398d";
    private const int ColliderPartCount = 3;
    private const float QuaternionTolerance = 0.0001f;
    private const double FrameTimeTolerance = 0.00001;

    internal static void Run(string directory, BattleCombatContent content)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "coop-obstacle-volley-unity-reference.json"));
        Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == ReviewedSha256,
            "The reviewed controller observation changed.");
        byte[] planBytes = File.ReadAllBytes(Path.Combine(directory, "coop-obstacle-volley-source-plan.json"));
        using JsonDocument observation = JsonDocument.Parse(bytes);
        using JsonDocument plan = JsonDocument.Parse(planBytes);
        JsonElement root = observation.RootElement;
        Require(root.GetProperty("planSha256").GetString() == Convert.ToHexStringLower(SHA256.HashData(planBytes)) &&
            root.GetProperty("prefabSha256").GetString() == content.EnemyPoses.SourceSha256,
            "The frame observation must bind both the actual host plan and recovered enemy rig.");
        JsonElement samples = root.GetProperty("samples");
        Require(samples.GetArrayLength() == plan.RootElement.GetProperty("captureFrames").GetInt32(),
            "The complete planned frame window is required.");
        ValidateFrames(samples, root.GetProperty("captureRate").GetInt32());
        VerifyRoundResets(samples, plan.RootElement.GetProperty("roundTicks"));
        Require(root.GetProperty("observedReturnToCrawl").GetBoolean() && HasCrawlPlayback(samples),
            "The actual controller must replay crawl after firing.");
        Console.WriteLine("PASS: 82-frame source-bound obstacle controller observation");
    }

    private static void ValidateFrames(JsonElement samples, int captureRate)
    {
        int tick = 0;
        foreach (JsonElement frame in samples.EnumerateArray())
        {
            Require(frame.GetProperty("tick").GetInt32() == tick &&
                Math.Abs(frame.GetProperty("seconds").GetDouble() - tick / (double)captureRate) < FrameTimeTolerance,
                "The observed frames must be ordered at the declared capture rate.");
            JsonElement parts = frame.GetProperty("parts");
            Require(parts.GetArrayLength() == ColliderPartCount,
                "Every frame needs both body shapes and the head shape.");
            foreach (JsonElement part in parts.EnumerateArray())
            {
                Require(part.GetProperty("center").EnumerateArray().All(value => float.IsFinite(value.GetSingle())),
                    "Observed collider centers must remain finite.");
                float[] values = part.GetProperty("rotation").EnumerateArray()
                    .Select(value => value.GetSingle()).ToArray();
                var rotation = new Quaternion(values[0], values[1], values[2], values[3]);
                Require(float.IsFinite(rotation.LengthSquared()) &&
                    Math.Abs(rotation.LengthSquared() - 1f) < QuaternionTolerance,
                    "Observed collider orientations must be finite unit quaternions.");
            }
            tick++;
        }
    }

    private static void VerifyRoundResets(JsonElement samples, JsonElement rounds)
    {
        foreach (JsonElement round in rounds.EnumerateArray())
        {
            JsonElement frame = samples[round.GetInt32()];
            Require(frame.GetProperty("roundInvoked").GetBoolean() &&
                frame.GetProperty("states").EnumerateArray().Any(state =>
                    state.GetProperty("name").GetString() == "rifle_shot_loop" &&
                    state.GetProperty("time").GetSingle() == 0),
                "Each scheduled source shot animation call must reset the recovered fire loop.");
        }
    }

    private static bool HasCrawlPlayback(JsonElement samples)
    {
        foreach (JsonElement frame in samples.EnumerateArray())
        {
            foreach (JsonElement state in frame.GetProperty("states").EnumerateArray())
            {
                if (state.GetProperty("name").GetString() == "stand_up_crawl" &&
                    state.GetProperty("time").GetSingle() > 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
