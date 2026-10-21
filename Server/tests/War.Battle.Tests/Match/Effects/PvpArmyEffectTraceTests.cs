using System.Text.Json;
using War.Battle.Tests.Match.Tracing;
using War.Battle.Tests.Startup;
using static War.Battle.Tests.Match.Effects.PvpArmyEffectTraceFixture;

namespace War.Battle.Tests.Match.Effects;

internal static class PvpArmyEffectTraceTests
{
    internal static IReadOnlyList<MatchEngineTraceResult> Capture()
    {
        return [FlameNatural(), FlameDeath(), FlameTerminal(), FlameDeferred(), PoisonNatural(),
            PoisonDeath(), PoisonTerminal(), PoisonStacked(), PoisonPause()];
    }

    internal static int Run()
    {
        string path = Path.Combine(BackendStartupPolicyTests.FindServerDirectory(),
            "tests/War.Battle.Tests/Match/Effects/pvp-army-effect-baseline.json");
        MatchEngineTraceResult[] expected =
            JsonSerializer.Deserialize<MatchEngineTraceResult[]>(File.ReadAllText(path))!;
        IReadOnlyList<MatchEngineTraceResult> actual = Capture();
        Require(expected.Length == 9 && actual.Count == expected.Length, "The effect trace inventory changed.");
        for (int index = 0; index < expected.Length; index++)
        {
            Require(expected[index] == actual[index], "Army effect trace differs: " + expected[index].Scenario);
        }
        return actual.Count;
    }

    private static MatchEngineTraceResult FlameNatural()
    {
        using var fixture = new PvpArmyEffectTraceFixture("source-flame-natural-completion", Flame);
        fixture.WaitUntil(() => fixture.Engine.ArmyFlameProgress(fixture.Actor).Count > 0);
        ulong first = fixture.Engine.ArmyFlameProgress(fixture.Actor)[0].ProjectileId;
        fixture.AdvanceFrames(120);
        Require(!fixture.Engine.ArmyFlameProgress(fixture.Actor).Any(row => row.ProjectileId == first),
            "The original flame burst failed to complete.");
        return fixture.Finish();
    }

    private static MatchEngineTraceResult FlameDeath()
    {
        using var fixture = new PvpArmyEffectTraceFixture("flame-missing-soldier-removes-on-due-frame", Flame);
        fixture.WaitUntil(() => fixture.Engine.ArmyFlameProgress(fixture.Actor).Count > 0);
        fixture.KillActor();
        Require(fixture.Engine.ArmyFlameProgress(fixture.Actor).Count > 0,
            "Soldier death removed the burst before its due-frame check.");
        fixture.AdvanceFrames(20);
        Require(fixture.Engine.ArmyFlameProgress(fixture.Actor).Count == 0,
            "A due burst retained its missing source soldier.");
        return fixture.Finish();
    }

    private static MatchEngineTraceResult FlameTerminal()
    {
        using var fixture = new PvpArmyEffectTraceFixture("flame-terminal-clears-bursts", Flame);
        fixture.WaitUntil(() => fixture.Engine.ArmyFlameProgress(fixture.Actor).Count > 0);
        fixture.Forfeit();
        Require(fixture.Engine.Terminal && fixture.Engine.ArmyFlameProgress(fixture.Actor).Count == 0,
            "Terminal cleanup retained a flame burst.");
        fixture.Advance();
        return fixture.Finish();
    }

    private static MatchEngineTraceResult FlameDeferred()
    {
        using var fixture = new PvpArmyEffectTraceFixture("flame-deferred-source-frame-observations", Flame);
        fixture.WaitUntil(() => fixture.Engine.ArmyFlameProgress(fixture.Actor).Count > 0);
        ulong tick = fixture.Engine.Snapshot().ServerTick;
        for (int frame = 0; frame < 14; frame++)
        {
            fixture.DeferFrame();
        }
        Require(fixture.Engine.Snapshot().ServerTick == tick &&
            fixture.Engine.ArmyFlameProgress(fixture.Actor).Count == 0,
            "Deferred source frames failed to finish a burst without advancing combat ticks.");
        return fixture.Finish();
    }

    private static PvpArmyEffectTraceFixture Poison(string scenario, int idleSeconds = 120)
    {
        var fixture = new PvpArmyEffectTraceFixture(scenario, Commando, idleSeconds);
        fixture.WaitUntil(() => fixture.Engine.ArmyPoisonProgress(fixture.Actor).Count > 0);
        Require(fixture.Engine.ArmyPoisonProgress(fixture.Actor)[0].Remaining == 4,
            "Bullet impact did not execute its first poison pulse in the same frame.");
        return fixture;
    }

    private static MatchEngineTraceResult PoisonNatural()
    {
        using PvpArmyEffectTraceFixture fixture = Poison("poison-immediate-and-four-following-pulses");
        ulong first = fixture.Engine.ArmyPoisonProgress(fixture.Actor)[0].ProjectileId;
        fixture.AdvanceFrames(125);
        Require(!fixture.Engine.ArmyPoisonProgress(fixture.Actor).Any(row => row.ProjectileId == first) &&
            fixture.Events.Count(row => row.ProjectileId == first && row.Reason == "army-poison") == 5,
            "The source poison effect failed its independent five-pulse lifetime.");
        return fixture.Finish();
    }

    private static MatchEngineTraceResult PoisonDeath()
    {
        using PvpArmyEffectTraceFixture fixture = Poison("poison-survives-source-soldier-death");
        ulong first = fixture.Engine.ArmyPoisonProgress(fixture.Actor)[0].ProjectileId;
        fixture.KillActor();
        Require(fixture.Engine.ArmyPoisonProgress(fixture.Actor).Any(row => row.ProjectileId == first),
            "Source soldier death removed independent poison authority.");
        fixture.AdvanceFrames(125);
        Require(fixture.Events.Count(row => row.ProjectileId == first && row.Reason == "army-poison") == 5,
            "A removed soldier's poison coroutine did not finish normally.");
        return fixture.Finish();
    }

    private static MatchEngineTraceResult PoisonTerminal()
    {
        using PvpArmyEffectTraceFixture fixture = Poison("existing-poison-terminal-retention-boundary");
        var before = fixture.Engine.ArmyPoisonProgress(fixture.Actor).ToArray();
        fixture.Forfeit();
        fixture.Advance();
        Require(fixture.Engine.Terminal && fixture.Engine.ArmyPoisonProgress(fixture.Actor).SequenceEqual(before),
            "Extraction changed the prior server's terminal poison retention boundary.");
        return fixture.Finish();
    }

    private static MatchEngineTraceResult PoisonStacked()
    {
        using PvpArmyEffectTraceFixture fixture = Poison("independent-stacked-poison-receipts");
        fixture.WaitUntil(() => fixture.Engine.ArmyPoisonProgress(fixture.Actor).Count >= 2);
        fixture.AdvanceFrames(65);
        return fixture.Finish();
    }

    private static MatchEngineTraceResult PoisonPause()
    {
        using PvpArmyEffectTraceFixture fixture = Poison("poison-reconnect-freezes-fixed-tick-coroutines", 2);
        fixture.PauseObservation();
        return fixture.Finish();
    }
}
