using System.Numerics;
using System.Text.Json;
using War.BattleServer;

/// <summary>Compares source tween writes with actual Play Mode frames before native rotation takes over.</summary>
internal static class CoopShotRootTweenTests
{
    private const float TurnSeconds = 0.2f;
    private const float FrameSeconds = 1f / MatchManifest.TickRate;
    private const float RotationTolerance = 0.000001f;
    private const int LastTweenFrame = 6;

    internal static void Run(string directory)
    {
        using JsonDocument plan = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory, "coop-obstacle-turn-source-plan.json")));
        using JsonDocument reference = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory, "coop-obstacle-turn-unity-reference.json")));
        Quaternion start = Rotation(plan.RootElement.GetProperty("startRotation"));
        Quaternion target = Rotation(plan.RootElement.GetProperty("targetRotation"));
        var tween = new CoopShotRootTween(TurnSeconds);
        tween.Begin(start, target);
        JsonElement samples = reference.RootElement.GetProperty("samples");
        for (int tick = 0; tick <= LastTweenFrame; tick++)
        {
            if (tick > 0)
            {
                tween.AdvanceFrame(FrameSeconds);
            }

            Require(1f - Math.Abs(Quaternion.Dot(tween.Rotation, Rotation(samples[tick].GetProperty("rotation")))) <
                RotationTolerance && tween.IsRunning == samples[tick].GetProperty("tweenEnabled").GetBoolean(),
                "The source first Start/Update sequence must reproduce every observed tween write.");
        }

        VerifyRestart(tween, start, target);
        VerifyRejectedInputs(tween);
        Console.WriteLine("PASS: source root tween first-frame lifecycle, Unity rotation parity and reuse");
    }

    private static void VerifyRestart(CoopShotRootTween reused, Quaternion start, Quaternion target)
    {
        reused.Begin(start, target);
        reused.AdvanceFrame(FrameSeconds);
        var fresh = new CoopShotRootTween(TurnSeconds);
        fresh.Begin(start, target);
        fresh.AdvanceFrame(FrameSeconds);
        Require(1f - Math.Abs(Quaternion.Dot(fresh.Rotation, reused.Rotation)) > RotationTolerance,
            "A reused source component must not invoke its one-time Start update again.");
        Quaternion beforePause = reused.Rotation;
        reused.AdvanceFrame(0f);
        Require(reused.Rotation == beforePause, "Paused source time must preserve the current rotation.");
    }

    private static void VerifyRejectedInputs(CoopShotRootTween tween)
    {
        Quaternion rotation = tween.Rotation;
        foreach (float delta in new[] { float.NaN, float.PositiveInfinity, -FrameSeconds })
        {
            Reject(() => tween.AdvanceFrame(delta));
        }

        Reject(() => tween.Begin(default, Quaternion.Identity));
        Require(tween.Rotation == rotation && tween.IsRunning,
            "Rejected source tween input must preserve the active rotation and lifecycle.");
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new Exception("Invalid source root tween input was accepted.");
    }

    private static Quaternion Rotation(JsonElement values)
    {
        return new Quaternion(
            values[0].GetSingle(), values[1].GetSingle(), values[2].GetSingle(), values[3].GetSingle());
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
