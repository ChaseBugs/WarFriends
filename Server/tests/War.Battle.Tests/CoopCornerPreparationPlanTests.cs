using System.IO.Compression;
using System.Text.Json;
using Google.Protobuf;
using War.BattleServer;
using War.Protocol;

/// <summary>Checks retained preparation against actual source reset and interrupted-return observations.</summary>
internal static class CoopCornerPreparationPlanTests
{
    private static int _checks;

    internal static void Run(string directory)
    {
        _checks = 0;
        using FileStream source = File.OpenRead(Path.Combine(directory, "coop-corner-volley-rig-reference.json.gz"));
        using var compressed = new GZipStream(source, CompressionMode.Decompress);
        using JsonDocument document = JsonDocument.Parse(compressed);
        foreach (JsonElement scenario in document.RootElement.GetProperty("scenarios").EnumerateArray().Skip(1))
        {
            JsonElement frames = scenario.GetProperty("frames");
            JsonElement cover = frames[43].GetProperty("rig").GetProperty("states")[0];
            JsonElement look = frames[44].GetProperty("rig").GetProperty("states")[0];
            var clips = new CoopCornerPreparationPlan.Clips(scenario.GetProperty("startClip").GetString()!,
                scenario.GetProperty("fireClip").GetString()!, look.GetProperty("clipLength").GetSingle(),
                cover.GetProperty("clipLength").GetSingle());
            VerifySequence(CoopCornerPreparationPlan.FromIdle(clips), frames, 0, 17);
            CoopCornerPreparationPlan reversed = CoopCornerPreparationPlan.FromFrame(clips, ReadFrame(frames[43]));
            Require(!reversed.UsesFreshLookClock, "A return reversal must not advertise a fresh diagnostic clock.");
            VerifySequence(reversed, frames, 43, 8);
            if (clips.Look == "player_look_right3")
            {
                string output = Path.GetFullPath(Path.Combine(directory, "../.local/corner-interruption-sample.bin"));
                Directory.CreateDirectory(Path.GetDirectoryName(output)!);
                File.WriteAllBytes(output, reversed.Sample(1, 23).ToByteArray());
            }
            CoopCornerPreparationPlan restarted = CoopCornerPreparationPlan.FromFrame(clips, ReadFrame(frames[24]));
            VerifySequence(restarted, frames, 24, 3);
            VerifyRetainedLook(clips);
            VerifyRejectedFrames(clips);
        }
        Console.WriteLine($"PASS: {_checks} retained corner preparation source checks");
    }

    private static void VerifySequence(CoopCornerPreparationPlan plan, JsonElement frames, int epoch,
        int lastOffset)
    {
        for (int offset = 1; offset <= lastOffset; offset++)
        {
            BattleInfantryAnimationFrame actual = plan.Sample((ulong)offset, (ulong)(epoch + offset));
            BattleInfantryAnimationFrame expected = ReadFrame(frames[epoch + offset]);
            Require(actual.Clips.Count == expected.Clips.Count &&
                actual.Clips[0].ClipName == expected.Clips[0].ClipName &&
                MathF.Abs(actual.Clips[0].TimeSeconds - expected.Clips[0].TimeSeconds) < 0.00001f &&
                actual.Clips[0].Weight == expected.Clips[0].Weight && actual.Clips[0].Wrap == expected.Clips[0].Wrap,
                "Retained source preparation and queue time must match the independent full-rig trace.");
        }
    }

    private static void VerifyRetainedLook(CoopCornerPreparationPlan.Clips clips)
    {
        var before = new BattleInfantryAnimationFrame();
        before.Clips.Add(new BattleInfantryAnimationClip
        {
            ClipName = clips.Look, TimeSeconds = 0.1f, Weight = 1f, Wrap = BattleInfantryAnimationWrap.Clamp
        });
        CoopCornerPreparationPlan plan = CoopCornerPreparationPlan.FromFrame(clips, before);
        Require(MathF.Abs(plan.Sample(1, 1).Clips[0].TimeSeconds - (0.1f + 1f / 30f)) < 0.00001f,
            "An already playing source look must retain its phase instead of restarting.");
    }

    private static BattleInfantryAnimationFrame ReadFrame(JsonElement frame)
    {
        var result = new BattleInfantryAnimationFrame();
        foreach (JsonElement state in frame.GetProperty("rig").GetProperty("states").EnumerateArray())
        {
            string wrap = state.GetProperty("wrapMode").GetString()!;
            result.Clips.Add(new BattleInfantryAnimationClip
            {
                ClipName = state.GetProperty("clipName").GetString()!,
                TimeSeconds = state.GetProperty("time").GetSingle(),
                Weight = state.GetProperty("weight").GetSingle(),
                Wrap = wrap switch
                {
                    "ClampForever" => BattleInfantryAnimationWrap.ClampForever,
                    "Loop" => BattleInfantryAnimationWrap.Loop,
                    "Clamp" => BattleInfantryAnimationWrap.Clamp,
                    _ => throw new Exception("Unexpected source wrapping mode.")
                }
            });
        }
        return result;
    }

    internal static void VerifyRuntimeInterruption(CoopMatchRuntime runtime, ulong entityId,
        CoopAssaulterWeaponCatalog rifle, EnemyPoseCatalog poses)
    {
        CoopInfantryShotWindup previous = runtime.InfantryShotWindup(entityId)!;
        ulong finalRound = previous.CallbackTick + 1;
        for (int index = 1; index < previous.Batch.Count; index++)
        {
            finalRound = rifle.NextRoundEligibleTick(finalRound);
        }
        runtime.Advance(finalRound);
        previous = runtime.InfantryShotWindup(entityId)!;
        ulong interruptionTick = finalRound + 19;

        // Only the test advances trusted eligibility to cover+3 ticks. No Client field can set this timestamp.
        var field = typeof(CoopMatchRuntime).GetField("infantryShotWindups",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)!;
        var windups = (Dictionary<ulong, CoopInfantryShotWindup>)field.GetValue(runtime)!;
        windups[entityId] = previous with { NextEligibleTick = interruptionTick };
        runtime.Advance(interruptionTick);
        CoopInfantryShotWindup current = runtime.InfantryShotWindup(entityId)!;
        Require(current.StartTick == interruptionTick && current.CornerPreparation is { UsesFreshLookClock: false },
            "The new attempt must capture return before the previous round ledger is cleared.");
        runtime.Advance(interruptionTick + 1);
        BattleInfantryAnimationFrame? frame = runtime.Snapshot().Coop.EnemySpawns
            .Single(enemy => enemy.EntityId == entityId).InfantryAnimation;
        string cover = current.AnimationClip == "player_look_right3"
            ? "player_right_coverBack3" : "player_left_coverBack3";
        float expectedSeconds = (1f - 0.1f / poses.Clip(cover).Length) * poses.Clip(current.AnimationClip).Length +
            1f / MatchManifest.TickRate;
        Require(frame?.Clips[0].ClipName == current.AnimationClip &&
            MathF.Abs(frame.Clips[0].TimeSeconds - expectedSeconds) < 0.00001f,
            "The live runtime must project the interrupted source phase, not look time zero.");
        Require(runtime.PlaceCornerUncoverHitboxes(entityId).Count == 0 &&
            runtime.PlaceCornerFireHitboxes(entityId).Count == 0 &&
            runtime.CurrentEnemyCollisionFrame().UnplacedEnemyIds.Contains(entityId),
            "Interrupted presentation must not reuse fresh-clock diagnostic hitboxes.");
        Console.WriteLine("PASS: live runtime retains interrupted return before clearing its old round ledger");
    }

    private static void VerifyRejectedFrames(CoopCornerPreparationPlan.Clips clips)
    {
        Action<BattleInfantryAnimationFrame>[] changes =
        [
            frame => frame.Clips.Clear(),
            frame => frame.Clips[0].TimeSeconds = float.NaN,
            frame => frame.Clips[0].Weight = 0.5f,
            frame => frame.Clips[0].ClipName = "unknown",
            frame => frame.Clips[0].Wrap = BattleInfantryAnimationWrap.Unspecified,
            frame => frame.Clips.Add(frame.Clips[0].Clone())
        ];
        foreach (Action<BattleInfantryAnimationFrame> change in changes)
        {
            var before = new BattleInfantryAnimationFrame();
            before.Clips.Add(new BattleInfantryAnimationClip
            {
                ClipName = clips.Fire, Weight = 1f, Wrap = BattleInfantryAnimationWrap.ClampForever
            });
            change(before);
            try
            {
                CoopCornerPreparationPlan.FromFrame(clips, before);
            }
            catch (InvalidDataException)
            {
                _checks++;
                continue;
            }
            throw new Exception("Damaged prior animation state was accepted or normalized into a new attempt.");
        }
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
