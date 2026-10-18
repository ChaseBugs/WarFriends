using System.Security.Cryptography;
using System.Text.Json;

using War.BattleServer;

/// <summary>Compares source-body waits and forced cancellation with independent native Unity callbacks.</summary>
internal static class MortarCorpseReturnClockTests
{
    private const string ReferenceDigest = "99bb693df99b0a0afafda949705ccd8bbc46336228425d09ef6d3b4f281d9712";
    private const int LastTick = 300;
    private const float FrameSeconds = 1f / 30f;

    internal static int Run(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "pool-return-clock-unity-reference.json"));
        int checks = Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == ReferenceDigest,
            "Native return-clock evidence changed without review.");
        using JsonDocument reference = JsonDocument.Parse(bytes);
        foreach (JsonElement scenario in reference.RootElement.GetProperty("scenarios").EnumerateArray())
        {
            checks += CompareNativeScenario(scenario);
        }
        return checks + CheckRejectedInputs() + CheckFrameOvershoot() + CheckPoolRejections();
    }

    private static int CompareNativeScenario(JsonElement scenario)
    {
        var clock = new MortarCorpseReturnClock(scenario.GetProperty("delay").GetSingle());
        bool shouldForceReturn = scenario.GetProperty("forcedReturn").GetBoolean();
        int forcedTick = scenario.GetProperty("forcedReturnTick").GetInt32();
        var pool = new MortarWeaponPool(1);
        pool.TryAllocateForMaster(11, out _);
        pool.BeginCorpseReturn(11, 0, scenario.GetProperty("delay").GetSingle());
        bool hasRetainedOwnership = true;
        var events = new List<(string Transition, int Tick)> { ("scheduled", 0) };
        for (int tick = 1; tick <= LastTick; tick++)
        {
            if (shouldForceReturn && tick == forcedTick)
            {
                clock.ForceReturn();
                hasRetainedOwnership &= pool.Release(11) && pool.TryAllocateForPeer(22, out int slot) && slot == 0;
                events.Add(("forced-return", tick));
                events.Add(("successor-allocated", tick));
            }
            MortarCorpseReturnClock.Transition transition = clock.Advance(DeltaSeconds(tick));
            hasRetainedOwnership &= pool.AdvanceCorpseReturn(11, (ulong)tick, DeltaSeconds(tick)) == transition;
            if (!clock.HasReturned)
            {
                hasRetainedOwnership &= pool.OccupiedCount == 1 && pool.PendingCorpseCount == 1 &&
                    !pool.TryAllocateForMaster(33, out _);
            }
            if (transition == MortarCorpseReturnClock.Transition.Hidden)
            {
                events.Add(("hide-callback", tick));
            }
            else if (transition == MortarCorpseReturnClock.Transition.Returned)
            {
                events.Add(("delayed-return", tick));
            }
        }
        events.Add(("finished", LastTick));
        var expected = scenario.GetProperty("events").EnumerateArray()
            .Select(row => (row.GetProperty("transition").GetString()!, row.GetProperty("tick").GetInt32()));
        int checks = Require(events.SequenceEqual(expected) && clock.HasReturned,
            "Corpse callbacks differ from native pause, slow motion or forced-reuse boundaries.");
        return checks + Require(hasRetainedOwnership && pool.PendingCorpseCount == 0 &&
            (shouldForceReturn ? pool.SlotFor(22) == 0 && pool.OccupiedCount == 1 : pool.OccupiedCount == 0),
            "A retained corpse freed its slot early, or an old callback freed its reused successor.");
    }

    private static float DeltaSeconds(int tick)
    {
        // The probe changes timeScale during Update; the next frame uses the new scale.
        if (tick > 30 && tick <= 60)
        {
            return 0f;
        }
        if (tick > 60 && tick <= 120)
        {
            return FrameSeconds * 0.5f;
        }
        return FrameSeconds;
    }

    private static int CheckRejectedInputs()
    {
        int checks = 0;
        foreach (float delay in new[] { float.NaN, float.PositiveInfinity, 0f, 1.99f, 3.01f })
        {
            checks += RequireRejected(() => new MortarCorpseReturnClock(delay));
        }
        var clock = new MortarCorpseReturnClock(2f);
        foreach (float delta in new[] { float.NaN, float.PositiveInfinity, -1f })
        {
            checks += RequireRejected(() => clock.Advance(delta));
        }
        checks += Require(clock.Advance(0f) == MortarCorpseReturnClock.Transition.None &&
            !clock.HasHidden && !clock.HasReturned,
            "An invalid or paused delta changed the corpse's wait state.");
        return checks;
    }

    private static int CheckFrameOvershoot()
    {
        var clock = new MortarCorpseReturnClock(2f);
        return Require(clock.Advance(2.5f) == MortarCorpseReturnClock.Transition.Hidden &&
            clock.Advance(0.5f) == MortarCorpseReturnClock.Transition.None &&
            clock.Advance(0.5f) == MortarCorpseReturnClock.Transition.Returned &&
            clock.Advance(1f) == MortarCorpseReturnClock.Transition.None,
            "The second wait reused the first wait's overshoot or returned twice.");
    }

    private static int CheckPoolRejections()
    {
        var pool = new MortarWeaponPool(1);
        pool.TryAllocateForMaster(11, out _);
        int checks = RequireRejected(() => pool.BeginCorpseReturn(11, 10, float.NaN));
        checks += Require(pool.PendingCorpseCount == 0 && pool.SlotFor(11) == 0,
            "A malformed death delay changed weapon ownership.");
        pool.BeginCorpseReturn(11, 10, 2f);
        checks += RequireAuthorityRejected(() => pool.BeginCorpseReturn(11, 11, 3f));
        checks += RequireAuthorityRejected(() => pool.BeginCorpseReturn(12, 10, 2f));
        checks += RequireAuthorityRejected(() => pool.AdvanceCorpseReturn(11, 12, FrameSeconds));
        checks += Require(pool.AdvanceCorpseReturn(11, 10, FrameSeconds) == MortarCorpseReturnClock.Transition.None,
            "The body consumed its death frame as a later coroutine frame.");
        pool.AdvanceCorpseReturn(11, 11, FrameSeconds);
        checks += RequireAuthorityRejected(() => pool.AdvanceCorpseReturn(11, 11, FrameSeconds));
        checks += RequireAuthorityRejected(() => pool.AdvanceCorpseReturn(11, 10, FrameSeconds));
        for (ulong tick = 12; tick < 70; tick++)
        {
            pool.AdvanceCorpseReturn(11, tick, FrameSeconds);
        }
        checks += Require(pool.AdvanceCorpseReturn(11, 70, FrameSeconds) ==
            MortarCorpseReturnClock.Transition.Hidden && pool.OccupiedCount == 1,
            "Rejected frames reset the original death clock or released its weapon at hide.");
        pool.Release(11);
        pool.TryAllocateForPeer(12, out _);
        checks += Require(pool.AdvanceCorpseReturn(11, 71, FrameSeconds) ==
            MortarCorpseReturnClock.Transition.None && pool.SlotFor(12) == 0,
            "A retired actor advanced the successor's slot.");
        pool.BeginCorpseReturn(12, 100, 2f);
        pool.Clear();
        checks += Require(pool.PendingCorpseCount == 0 && pool.OccupiedCount == 0 &&
            pool.AdvanceCorpseReturn(12, 101, FrameSeconds) == MortarCorpseReturnClock.Transition.None,
            "Terminal reset retained a delayed return from the old scene.");
        return checks;
    }

    private static int RequireAuthorityRejected(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return 1;
        }
        throw new InvalidOperationException("A stale or unowned corpse transition was accepted.");
    }

    private static int RequireRejected(Action action)
    {
        try
        {
            action();
        }
        catch (ArgumentOutOfRangeException)
        {
            return 1;
        }
        throw new InvalidOperationException("Malformed corpse timing was accepted.");
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        return 1;
    }
}
