using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares tween completion and later root handoff with actual before/after Unity frames.</summary>
internal static class CoopShotRootCompositionTests
{
    private const float TurnSeconds = 0.2f;
    private const float RotationTolerance = 0.000001f;
    private const int ExpectedPhaseFrames = 59;
    private const int ExpectedTweenWrites = 6;
    private const string PlanHash = "d1f134406bf00517c79877dc621a7234cb40b406616c73fc5339587381f05ec5";

    internal static void Run(string directory)
    {
        using JsonDocument plan = Read(directory, "coop-obstacle-turn-source-plan.json", PlanHash);
        using JsonDocument phases = Read(directory, "coop-moving-root-phase-unity-reference.json",
            "8d7c3201bbfcdd7d55ec316b95b7c42e27caf55de51d734e28429687001a85e7");
        using JsonDocument post = Read(directory, "coop-moving-root-phase-post-reference.json",
            "b6f88677bdbb625a63c15d050ea3c5cd589a035f70c3b023a32923e45f5b2edd");
        Require(phases.RootElement.GetProperty("version").GetInt32() == 1 &&
            post.RootElement.GetProperty("version").GetInt32() == 2 &&
            post.RootElement.GetProperty("planSha256").GetString() == PlanHash,
            "The phase observations must bind the reviewed host route and capture schemas.");
        Quaternion start = Rotation(plan.RootElement.GetProperty("startRotation"));
        Quaternion target = Rotation(plan.RootElement.GetProperty("targetRotation"));
        var tween = new CoopShotRootTween(TurnSeconds);
        tween.Begin(start, target);
        JsonElement samples = phases.RootElement.GetProperty("samples");
        VerifyFrames(tween, samples, post.RootElement.GetProperty("samples"));
        VerifyInvalidInputs(start, target, samples[0]);
        Console.WriteLine("PASS: 59 native root frame compositions, completion write and navigation handoff");
    }

    private static void VerifyFrames(CoopShotRootTween tween, JsonElement samples, JsonElement postSamples)
    {
        Require(samples.GetArrayLength() == ExpectedPhaseFrames &&
            postSamples.GetArrayLength() == ExpectedPhaseFrames + 1, "Every captured root frame is required.");
        int tick = 0;
        int tweenWrites = 0;
        int externalWrites = 0;
        foreach (JsonElement sample in samples.EnumerateArray())
        {
            tick++;
            Require(sample.GetProperty("tick").GetInt32() == tick &&
                sample.GetProperty("tweenEnabledBefore").GetBoolean() == tween.IsRunning,
                "Root composition must preserve frame order and the pre-Update component state.");
            bool writesThisFrame = tween.IsRunning;
            Quaternion before = Rotation(sample.GetProperty("beforeRotation"));
            Quaternion actual = CoopShotRootComposition.AfterFrame(tween, before,
                sample.GetProperty("deltaSeconds").GetSingle());
            Require(SameRotation(actual, Rotation(sample.GetProperty("afterRotation"))) &&
                SameRotation(actual, Rotation(postSamples[tick].GetProperty("rotation"))) &&
                tween.IsRunning == sample.GetProperty("tweenEnabledAfter").GetBoolean(),
                "Composed roots must match both native LateUpdate and the same post-frame observation.");
            if (writesThisFrame)
            {
                tweenWrites++;
            }
            else
            {
                externalWrites++;
                Require(SameRotation(actual, before), "A disabled tween must preserve the incoming root write.");
            }
        }

        Require(tweenWrites == ExpectedTweenWrites && externalWrites == ExpectedPhaseFrames - ExpectedTweenWrites,
            "The completion frame must retain its final write before handing off subsequent frames.");
    }

    private static void VerifyInvalidInputs(Quaternion start, Quaternion target, JsonElement firstFrame)
    {
        var tween = new CoopShotRootTween(TurnSeconds);
        tween.Begin(start, target);
        Quaternion before = Rotation(firstFrame.GetProperty("beforeRotation"));
        ExpectInvalid(() => CoopShotRootComposition.AfterFrame(tween, default, 1f / MatchManifest.TickRate));
        ExpectInvalid(() => CoopShotRootComposition.AfterFrame(tween, before, float.NaN));
        Require(tween.IsRunning && tween.Rotation == start,
            "Invalid composition input must not consume the source Start or alter the tween.");
        Quaternion actual = CoopShotRootComposition.AfterFrame(tween, before,
            firstFrame.GetProperty("deltaSeconds").GetSingle());
        Require(SameRotation(actual, Rotation(firstFrame.GetProperty("afterRotation"))),
            "The first valid frame after rejection must still match native Start and Update.");
    }

    private static JsonDocument Read(string directory, string fileName, string expectedHash)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, fileName));
        Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == expectedHash,
            "Root phase evidence must match the reviewed native capture.");
        return JsonDocument.Parse(bytes);
    }

    private static Quaternion Rotation(JsonElement value)
    {
        return new Quaternion(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle(), value[3].GetSingle());
    }

    private static bool SameRotation(Quaternion left, Quaternion right)
    {
        return 1f - Math.Abs(Quaternion.Dot(left, right)) <= RotationTolerance;
    }

    private static void ExpectInvalid(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidDataException("Invalid root composition input was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
