using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

using War.BattleServer;

/// <summary>Checks real native Colt coroutine timing and current-rig muzzle phases in both update orders.</summary>
internal static class GunslingerStandTimingTests
{
    private const string VerifiedRevision = "af44551af0ed8b417bc6baab03bd5e4f0db000f22e518412df8d80992bd35020";
    private const string FireClip = "colt_shooting_loop";
    private const string QueuedFire = FireClip + " - Queued Clone";
    private const float PoseTolerance = 0.00001f;
    private const int AttemptsPerScenario = 4;

    internal static int Run(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "gunslinger-stand-unity-reference.json"));
        int checks = Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == VerifiedRevision,
            "Native Gunslinger source observation revision changed.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        float startLength = content.EnemyPoses.Clip("colt_shooting_start").Length;
        foreach (JsonElement scenario in document.RootElement.GetProperty("scenarios").EnumerateArray())
        {
            checks += CheckScenario(scenario, content, startLength);
        }

        checks += CheckInvalidClocks();
        return checks;
    }

    private static int CheckScenario(JsonElement scenario, BattleCombatContent content, float startLength)
    {
        JsonElement preparations = scenario.GetProperty("preparations");
        JsonElement callbacks = scenario.GetProperty("callbacks");
        JsonElement shots = scenario.GetProperty("shots");
        int checks = Require(preparations.GetArrayLength() == AttemptsPerScenario &&
            callbacks.GetArrayLength() == AttemptsPerScenario && shots.GetArrayLength() == AttemptsPerScenario,
            "Native Gunslinger observation lost a complete four-attempt sequence.");
        for (int index = 0; index < AttemptsPerScenario; index++)
        {
            ulong preparation = preparations[index].GetProperty("tick").GetUInt64();
            ulong callback = callbacks[index].GetProperty("tick").GetUInt64();
            ulong shot = shots[index].GetProperty("tick").GetUInt64();
            float selectedDelay = preparations[index].GetProperty("delaySeconds").GetSingle();
            checks += Require(selectedDelay == (index == 0 ? startLength : 0f) &&
                GunslingerFiringClock.CallbackTick(preparation, selectedDelay) == callback &&
                GunslingerFiringClock.GameplayPollTick(callback) == shot,
                "The source Colt callback or next gameplay poll acquired Corner padding or a same-frame shot.");
            if (index + 1 < AttemptsPerScenario)
            {
                checks += Require(GunslingerFiringClock.NextPreparationTick(shot) ==
                    preparations[index + 1].GetProperty("tick").GetUInt64(),
                    "The strict 0.18-second source interval between one-shot attempts changed.");
            }

            GunslingerFireLoopEntry entry = EntryKind(scenario, preparation);
            var clock = new PoseClock(entry, preparation, startLength);
            checks += CheckPose(callbacks[index], clock, content.CoopEnemyMuzzles);
            checks += CheckPose(shots[index], clock, content.CoopEnemyMuzzles);
        }

        ulong lastPreparation = preparations[AttemptsPerScenario - 1].GetProperty("tick").GetUInt64();
        JsonElement firstStop = scenario.GetProperty("frames").EnumerateArray().First(row =>
            row.GetProperty("phase").GetString() == "probe-late-update" &&
            row.GetProperty("pose").GetProperty("states").EnumerateArray().Any(state =>
                state.GetProperty("name").GetString() == "colt_shooting_stop"));
        checks += Require(GunslingerFiringClock.HideTick(lastPreparation) == firstStop.GetProperty("tick").GetUInt64(),
            "The strict binary32 source hide clock diverged from the native stop transition.");
        string? scenarioName = scenario.GetProperty("scenario").GetString();
        Console.WriteLine($"PASS: native Gunslinger {scenarioName} callback/poll phases.");
        return checks;
    }

    private static GunslingerFireLoopEntry EntryKind(JsonElement scenario, ulong tick)
    {
        JsonElement frame = scenario.GetProperty("frames").EnumerateArray().Single(row =>
            row.GetProperty("tick").GetUInt64() == tick &&
            row.GetProperty("phase").GetString() == "probe-update-entry");
        string?[] names = frame.GetProperty("pose").GetProperty("states").EnumerateArray()
            .Select(state => state.GetProperty("name").GetString()).ToArray();
        if (names.Contains(QueuedFire))
        {
            return GunslingerFireLoopEntry.ReplaceQueuedClone;
        }

        return names.Contains(FireClip) ? GunslingerFireLoopEntry.RestartEnabledFire :
            GunslingerFireLoopEntry.FreshQueuedFire;
    }

    private static int CheckPose(JsonElement observed, PoseClock clock, CoopEnemyMuzzleCatalog muzzles)
    {
        ulong tick = observed.GetProperty("tick").GetUInt64();
        float seconds = GunslingerFiringClock.FireLoopSeconds(clock.Entry, tick - clock.PreparationTick,
            clock.StartLength) ??
            throw new InvalidOperationException("A native shot/callback has no source firing phase.");
        JsonElement pose = observed.GetProperty("pose");
        JsonElement state = pose.GetProperty("states").EnumerateArray().Single();
        int checks = Require(MathF.Abs(seconds - state.GetProperty("time").GetSingle()) < PoseTolerance,
            "Queued-clone replacement and retained-loop restart lost their distinct native time offsets.");
        CoopMuzzlePose expected = muzzles.Place(FireClip, Vector3.Zero, Quaternion.Identity, seconds);
        JsonElement position = pose.GetProperty("position");
        var actualPosition = new Vector3(position[0].GetSingle(), position[1].GetSingle(), position[2].GetSingle());
        JsonElement rotation = pose.GetProperty("rotation");
        var actualRotation = new Quaternion(rotation[0].GetSingle(), rotation[1].GetSingle(),
            rotation[2].GetSingle(), rotation[3].GetSingle());
        checks += Require(Vector3.Distance(expected.Position, actualPosition) < PoseTolerance &&
            MathF.Abs(Quaternion.Dot(expected.Rotation, actualRotation)) > 1f - PoseTolerance,
            "The existing native reference rifle muzzle does not match the actual Colt-phase observation.");
        return checks;
    }

    private static int CheckInvalidClocks()
    {
        int checks = Reject(() => GunslingerFiringClock.CallbackTick(0, float.NaN));
        checks += Reject(() => GunslingerFiringClock.CallbackTick(0, float.PositiveInfinity));
        checks += Reject(() => GunslingerFiringClock.CallbackTick(0, -1f));
        checks += Reject(() => GunslingerFiringClock.FireLoopSeconds((GunslingerFireLoopEntry)99, 1, 1f));
        checks += Reject(() => GunslingerFiringClock.FireLoopSeconds(GunslingerFireLoopEntry.FreshQueuedFire, 1, 0f));
        return checks;
    }

    private static int Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return 1;
        }

        throw new InvalidOperationException("An invalid Gunslinger source clock was accepted.");
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }

    private sealed record PoseClock(GunslingerFireLoopEntry Entry, ulong PreparationTick, float StartLength);
}
