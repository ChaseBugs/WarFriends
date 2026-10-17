using System.IO.Compression;
using System.Text.Json;
using War.BattleServer;
using War.Protocol;

/// <summary>Compares runtime return samples to the independent full-rig source capture.</summary>
internal static class CoopCornerReturnAnimationTests
{
    private const int SourceReturnEpoch = 59;
    private const int LastMeasuredOffset = 31;
    private static int _checks;

    internal static void Run(string directory, BattleCombatContent content)
    {
        _checks = 0;
        using FileStream file = File.OpenRead(Path.Combine(directory, "coop-corner-volley-rig-reference.json.gz"));
        using var compressed = new GZipStream(file, CompressionMode.Decompress);
        using JsonDocument capture = JsonDocument.Parse(compressed);
        for (int side = 0; side < 2; side++)
        {
            string coverClip = side == 0 ? "player_right_coverBack3" : "player_left_coverBack3";
            JsonElement sourceFrames = capture.RootElement.GetProperty("scenarios")[side + 1].GetProperty("frames");
            VerifyMeasuredFrames(content.CoopCornerQueuePoses, coverClip, sourceFrames);
            VerifyIsolationAndContinuation(content.CoopCornerQueuePoses, coverClip);
        }
        VerifyInvalidAuthority(directory, content);
        Console.WriteLine($"PASS: {_checks} source-method corner return animation checks");
    }

    private static void VerifyMeasuredFrames(CoopCornerQueuePoseCatalog catalog, string coverClip,
        JsonElement sourceFrames)
    {
        for (int offset = 1; offset <= LastMeasuredOffset; offset++)
        {
            BattleInfantryAnimationFrame actual = catalog.AnimationFrame(coverClip, (ulong)offset, 100);
            JsonElement states = sourceFrames[SourceReturnEpoch + offset].GetProperty("rig").GetProperty("states");
            Require(actual.SampleTick == 100 && actual.Clips.Count == states.GetArrayLength(),
                "The runtime frame must preserve the observed clip set and the requested host clock.");
            for (int index = 0; index < actual.Clips.Count; index++)
            {
                BattleInfantryAnimationClip clip = actual.Clips[index];
                JsonElement expected = states[index];
                Require(clip.ClipName == expected.GetProperty("clipName").GetString() &&
                    clip.TimeSeconds == expected.GetProperty("time").GetSingle() &&
                    clip.Weight == expected.GetProperty("weight").GetSingle() &&
                    clip.Wrap == (clip.ClipName == coverClip
                        ? BattleInfantryAnimationWrap.Clamp : BattleInfantryAnimationWrap.Loop),
                    "Runtime blend scalars must equal the full-rig source observation.");
            }
        }
    }

    private static void VerifyIsolationAndContinuation(CoopCornerQueuePoseCatalog catalog, string coverClip)
    {
        BattleInfantryAnimationFrame start = catalog.AnimationFrame(coverClip, 0, 100);
        Require(start.Clips.Count == 1 && start.Clips[0].ClipName == coverClip && start.Clips[0].TimeSeconds == 0f,
            "Source Play starts cover return at zero without inventing an idle blend.");
        BattleInfantryAnimationFrame last = catalog.AnimationFrame(coverClip, LastMeasuredOffset, 100);
        float measuredIdle = last.Clips[0].TimeSeconds;
        last.Clips[0].TimeSeconds = 999f;
        BattleInfantryAnimationFrame repeated = catalog.AnimationFrame(coverClip, LastMeasuredOffset, 101);
        Require(repeated.Clips[0].TimeSeconds == measuredIdle,
            "Mutating a returned protobuf message must not alter cached source authority.");
        BattleInfantryAnimationFrame continued = catalog.AnimationFrame(coverClip, LastMeasuredOffset + 1, 102);
        Require(continued.Clips.Count == 1 && continued.Clips[0].ClipName == "idle" &&
            continued.Clips[0].TimeSeconds == measuredIdle + 1f / MatchManifest.TickRate,
            "Pure idle continuation must retain its measured phase.");
        RequireInvalid(() => catalog.AnimationFrame(coverClip, 1_000_001, 100));
        RequireInvalid(() => catalog.AnimationFrame("unknown", 1, 100));
    }

    private static void VerifyInvalidAuthority(string directory, BattleCombatContent content)
    {
        string source = Path.Combine(directory, "coop-corner-return-animation-reference.json");
        RequireInvalid(() => CoopCornerReturnAnimationCatalog.Load(source, new string('0', 64)));
        string temporary = Path.GetTempFileName();
        try
        {
            File.WriteAllText(temporary, "{}");
            RequireInvalid(() => CoopCornerReturnAnimationCatalog.Load(temporary, content.EnemyPoses.SourceSha256));
        }
        finally
        {
            File.Delete(temporary);
        }
    }

    private static void RequireInvalid(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            _checks++;
            return;
        }
        throw new Exception("Invalid return animation authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
        _checks++;
    }
}
