using System.Numerics;
using System.Text.Json;
using War.BattleServer;

internal static class PvpBonusGrenadeBurstTests
{
    internal static int Run(string directory)
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }

        var content = BattleCombatContent.Load(
            Path.Combine(directory, "combat-content-manifest.json"));
        var catalog = content.PvpBonuses;
        Check(catalog.GrenadeCount == 3 && catalog.GrenadeTargetDistance == 3f &&
              catalog.GrenadeFallbackDamageMinimum == 50f &&
              catalog.GrenadeFallbackDamageMaximum == 872f,
            "grenade count, strict target radius and fallback damage rows are source pinned");

        var policy = new PvpBonusGrenadeBurstPolicy(catalog);
        Check(PvpBonusGrenadeBurstPolicy.FallbackOffsetFromUnitDraw(0f) == -1.5f &&
              PvpBonusGrenadeBurstPolicy.FallbackOffsetFromUnitDraw(0.5f) == 0f &&
              PvpBonusGrenadeBurstPolicy.FallbackOffsetFromUnitDraw(1f) == 1.5f,
            "host unit draws map to the source grenade offset interval");
        var box = Vector3.Zero;
        PvpBonusGrenadeTarget Target(string id, int fraction, float distance,
            bool alive = true, bool visible = true, bool mainOwner = true) =>
            new(id, fraction, mainOwner, alive, visible, new Vector3(distance, 0f, 0f));
        var shootables = new[] {
            Target("far", 1, 3f), Target("friend", 2, 0.2f),
            Target("close2", 1, 2f), Target("hidden", 1, 0.1f, visible: false),
            Target("close1", 1, 1f), Target("dead", 1, 0.1f, alive: false),
            Target("non-main", 1, 0.1f, mainOwner: false)
        };
        var offsets = new Queue<float>([0.25f, -0.5f]);
        var launches = policy.Plan(2, 0, box, shootables, () => offsets.Dequeue());
        Check(launches.Count == 3 && launches[0] ==
                  new PvpBonusGrenadeLaunch(0, 1f, "close1", new Vector3(1f, 0f, 0f), null) &&
              launches[1] ==
                  new PvpBonusGrenadeLaunch(1, 1.2f, "close2", new Vector3(2f, 0f, 0f), null) &&
              launches[2] ==
                  new PvpBonusGrenadeLaunch(2, 1.4f, null,
                      new Vector3(0.25f, 0f, -0.5f),
                      new PvpBonusGrenadeDamageOverride(50f, 5f)) &&
              offsets.Count == 0,
            "visible living opponents are nearest first; the strict-radius remainder falls around the box");
        try
        {
            ((IList<PvpBonusGrenadeLaunch>)launches)[0] = launches[1];
            throw new Exception("Grenade launch plan was mutable.");
        }
        catch (NotSupportedException) { checks++; }

        int unnecessaryDraws = 0;
        var nearest = policy.Plan(2, 42, box, [Target("third", 1, 2.5f),
            Target("first", 1, 1f), Target("fourth", 1, 2.9f),
            Target("second", 1, 2f)], () => { unnecessaryDraws++; return 0f; });
        Check(nearest.Select(launch => launch.TargetId).SequenceEqual(
                  ["first", "second", "third"]) && unnecessaryDraws == 0,
            "three nearest eligible targets consume no fallback random draws");
        var equalDistance = policy.Plan(2, 3, box,
            [Target("registered-first", 1, 1f), Target("registered-second", 1, -1f)],
            () => 0f);
        Check(equalDistance[0].TargetId == "registered-first" &&
              equalDistance[1].TargetId == "registered-second",
            "equal-distance targets retain host registry order");

        int fallbackDraws = 0;
        var allFallback = policy.Plan(2, 0, box,
            [Target("friend", 2, 1f), Target("dead", 1, 1f, alive: false)],
            () => { fallbackDraws++; return 0f; });
        Check(allFallback.Count == 3 && allFallback.All(launch => launch.TargetId == null) &&
              fallbackDraws == 6 && allFallback[2].DelayScaledSeconds == 1.4f,
            "three fallback grenades use two source draws each after the one-second delay");

        var burst = new PvpBonusGrenadeBurstPlan("box", "recipient", allFallback);
        var clock = new PvpBonusGrenadeBurstClock();
        Check(clock.AdvanceFrame(1, 0f).Count == 0,
            "a new grenade clock starts without firing");
        clock.Schedule(burst, 1);
        Check(clock.AdvanceFrame(2, 0.5f).Count == 0 &&
              clock.AdvanceFrame(3, 0.49f).Count == 0,
            "the first shot waits for one full scaled second");
        var firstDue = clock.AdvanceFrame(4, 0.01f);
        Check(firstDue.Count == 1 && firstDue[0].Launch.ShotIndex == 0 &&
              firstDue[0].FrameId == 4 &&
              ReferenceEquals(firstDue, clock.AdvanceFrame(4, 0.01f)),
            "the first scheduled shot is emitted once and a frame replay is stable");
        Check(clock.AdvanceFrame(5, 0.2f).Single().Launch.ShotIndex == 1 &&
              clock.AdvanceFrame(6, 0.2f).Single().Launch.ShotIndex == 2 &&
              clock.PendingCount == 0,
            "later shots each wait another 0.2 scaled seconds");
        var slowClock = new PvpBonusGrenadeBurstClock();
        slowClock.AdvanceFrame(1, 0f);
        slowClock.Schedule(burst, 1);
        Check(slowClock.AdvanceFrame(2, 5f).Single().Launch.ShotIndex == 0 &&
              slowClock.AdvanceFrame(3, 0f).Count == 0 &&
              slowClock.AdvanceFrame(4, 0.2f).Single().Launch.ShotIndex == 1,
            "a long frame cannot fire multiple coroutine shots at once");

        using var reference = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory, "unity-pvp-bonus-reference.json")));
        var damageSamples = reference.RootElement.GetProperty("grenadeSamples");
        Check(damageSamples.GetArrayLength() == catalog.RankCount,
            "Unity provides a fallback grenade damage sample for every rank");
        for (int level = 0; level < catalog.RankCount; level++)
        {
            var sample = damageSamples[level];
            var damage = policy.Plan(2, level, box, [], () => 0f)[0].DamageOverride!;
            Check(sample.GetProperty("recipientLevelIndex").GetInt32() == level &&
                  BitConverter.SingleToInt32Bits(damage.Explosion) ==
                      sample.GetProperty("explosionBits").GetInt32() &&
                  BitConverter.SingleToInt32Bits(damage.Direct) ==
                      sample.GetProperty("directBits").GetInt32(),
                $"rank {level} grenade fallback damage matches the Unity probe");
        }

        void Reject(Action attempt)
        {
            try { attempt(); throw new Exception("Invalid grenade burst authority was accepted."); }
            catch (InvalidDataException) { checks++; }
        }
        Reject(() => policy.Plan(0, 0, box, shootables, () => 0f));
        Reject(() => PvpBonusGrenadeBurstPolicy.FallbackOffsetFromUnitDraw(-0.01f));
        Reject(() => PvpBonusGrenadeBurstPolicy.FallbackOffsetFromUnitDraw(1.01f));
        Reject(() => PvpBonusGrenadeBurstPolicy.FallbackOffsetFromUnitDraw(float.NaN));
        Reject(() => policy.Plan(2, -1, box, shootables, () => 0f));
        Reject(() => policy.Plan(2, 43, box, shootables, () => 0f));
        Reject(() => policy.Plan(2, 0, new Vector3(float.NaN, 0f, 0f), shootables, () => 0f));
        Reject(() => policy.Plan(2, 0, box,
            [Target("same", 1, 1f), Target("same", 1, 2f)], () => 0f));
        Reject(() => policy.Plan(2, 0, box, [Target("bad", 3, 1f)], () => 0f));
        Reject(() => policy.Plan(2, 0, box, [], () => 1.5001f));
        Reject(() => policy.Plan(2, 0, box, [], () => float.NaN));
        Reject(() => clock.AdvanceFrame(6, 0.3f));
        Reject(() => clock.AdvanceFrame(8, 0.2f));
        Reject(() => clock.AdvanceFrame(7, float.NaN));
        Reject(() => policy.Plan(2, 0, box,
            Enumerable.Range(1, 257).Select(index => Target("t" + index, 1, 1f)).ToArray(),
            () => 0f));
        return checks;
    }
}
