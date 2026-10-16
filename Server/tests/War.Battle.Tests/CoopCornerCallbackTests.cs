using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

/// <summary>Checks both source cover callbacks and two emitted-round muzzles against native Unity.</summary>
internal static class CoopCornerCallbackTests
{
    private const float PositionTolerance = 0.00002f;
    private const float RotationTolerance = 0.000001f;
    private const float TimeTolerance = 0.00001f;

    internal static void Run(string directory, BattleCombatContent content)
    {
        const string ReviewedHash = "f5db29d3cf852d5fde8e53de7d0496f948a7fdb3bd7ba554a03926e9b9374a37";
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "coop-corner-callback-unity-reference.json"));
        Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == ReviewedHash,
            "The corner callback observation must match the reviewed native capture.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        Require(root.GetProperty("version").GetInt32() == 1 &&
            root.GetProperty("prefabSha256").GetString() == content.EnemyPoses.SourceSha256 &&
            root.GetProperty("captureRate").GetInt32() == MatchManifest.TickRate &&
            root.GetProperty("timeScale").GetSingle() == 1f,
            "The native corner observation must bind the recovered rig and fixed clock.");
        JsonElement scenarios = root.GetProperty("scenarios");
        Require(scenarios.GetArrayLength() == 2, "Both native cover sides are required.");
        foreach (JsonElement scenario in scenarios.EnumerateArray())
        {
            VerifyScenario(content, scenario);
        }

        VerifyInvalidClocks(content);
        Console.WriteLine("PASS: both native corner callbacks, first polls and two-round muzzle resets");
    }

    private static void VerifyScenario(BattleCombatContent content, JsonElement scenario)
    {
        string startClip = scenario.GetProperty("startClip").GetString()
            ?? throw new InvalidDataException("Missing corner start clip.");
        string fireClip = scenario.GetProperty("fireClip").GetString()
            ?? throw new InvalidDataException("Missing corner fire clip.");
        ulong callbackTick = scenario.GetProperty("callbackTick").GetUInt64();
        ulong firstReadyTick = scenario.GetProperty("firstReadyTick").GetUInt64();
        float uncoverLength = content.EnemyPoses.Clip("player_look_right3").Length;
        Require(CoopShotCallbackClock.CallbackTick(0, uncoverLength) == callbackTick &&
            CoopShotCallbackClock.FirstGameplayPollTick(callbackTick) == firstReadyTick,
            "Both cover sides must use the source right-side uncover callback length.");
        var clock = new CoopCornerFiringClock(startClip, fireClip, callbackTick, []);
        ComparePose(content, clock, scenario.GetProperty("callbackPose"));
        ComparePose(content, clock with { ElapsedTick = firstReadyTick }, scenario.GetProperty("firstReadyPose"));
        var emitted = new List<ulong>();
        foreach (JsonElement round in scenario.GetProperty("rounds").EnumerateArray())
        {
            ulong tick = round.GetProperty("tick").GetUInt64();
            ulong expectedTick = emitted.Count == 0 ? firstReadyTick
                : content.CoopAssaulterWeapon.NextRoundEligibleTick(emitted[^1]);
            Require(tick == expectedTick, "The observed reset schedule must match the validated host rifle cadence.");
            ComparePose(content, clock with { ElapsedTick = tick, EmittedRoundTicks = emitted },
                round.GetProperty("pose"));
            emitted.Add(tick);
        }

        Require(emitted.Count == 2, "Each source cover side must exercise queued-clone replacement.");
    }

    private static void ComparePose(BattleCombatContent content, CoopCornerFiringClock clock, JsonElement expected)
    {
        CoopQueuedMuzzleSample actual = CoopCornerFiringMuzzle.Sample(clock, content.CoopAssaulterQueue,
            content.CoopEnemyMuzzles)
            ?? throw new InvalidDataException("A native corner shot must have a host muzzle.");
        JsonElement position = expected.GetProperty("position");
        JsonElement rotation = expected.GetProperty("rotation");
        var expectedPosition = new Vector3(position[0].GetSingle(), position[1].GetSingle(), position[2].GetSingle());
        var expectedRotation = new Quaternion(rotation[0].GetSingle(), rotation[1].GetSingle(),
            rotation[2].GetSingle(), rotation[3].GetSingle());
        Require(Vector3.Distance(actual.LocalPosition, expectedPosition) <= PositionTolerance &&
            1f - Math.Abs(Quaternion.Dot(actual.LocalRotation, expectedRotation)) <= RotationTolerance,
            $"The selected source corner muzzle differs at tick {clock.ElapsedTick} for {clock.StartClip}.");
        JsonElement state = expected.GetProperty("states").EnumerateArray().Single(candidate =>
            candidate.GetProperty("name").GetString() == clock.FireClip ||
            candidate.GetProperty("name").GetString() == clock.FireClip + " - Queued Clone");
        Require(Math.Abs(actual.FireClipSeconds - state.GetProperty("time").GetSingle()) <= TimeTolerance,
            "The corner muzzle clock must match actual animation time, including after OnShot resets.");
    }

    private static void VerifyInvalidClocks(BattleCombatContent content)
    {
        const string StartClip = "player_look_right3";
        const string FireClip = "player_fire_right3";
        CoopCornerFiringClock[] invalid =
        [
            new(StartClip, "player_fire_left3", 18, []),
            new(StartClip, FireClip, 29, [18, 18]),
            new(StartClip, FireClip, 29, [29, 18]),
            new(StartClip, FireClip, 29, [30]),
            new(StartClip, FireClip, 29, [5])
        ];
        foreach (CoopCornerFiringClock clock in invalid)
        {
            try
            {
                CoopCornerFiringMuzzle.Sample(clock, content.CoopAssaulterQueue, content.CoopEnemyMuzzles);
            }
            catch (InvalidDataException)
            {
                continue;
            }

            throw new InvalidDataException("An invalid corner round clock was accepted.");
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
