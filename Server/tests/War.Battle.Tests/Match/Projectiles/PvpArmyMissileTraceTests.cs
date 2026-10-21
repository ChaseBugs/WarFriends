using System.Text.Json;
using War.Battle.Tests.Match.Tracing;
using War.Battle.Tests.Startup;
using War.BattleServer;
using War.Protocol;
using static War.Battle.Tests.Match.Projectiles.PvpArmyMissileTraceFixture;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpArmyMissileTraceTests
{
    internal static IReadOnlyList<MatchEngineTraceResult> Capture()
    {
        return [Natural(Rocket, MissileTraceMode.Real), Natural(Rocket, MissileTraceMode.Fake),
            Natural(Mortar, MissileTraceMode.Real), Natural(Mortar, MissileTraceMode.Fake),
            SoldierDeath(Rocket), SoldierDeath(Mortar), TerminalClear(Rocket), TerminalClear(Mortar),
            ReconnectPause(), CardRocket()];
    }

    internal static int Run()
    {
        string path = Path.Combine(BackendStartupPolicyTests.FindServerDirectory(),
            "tests/War.Battle.Tests/Match/Projectiles/pvp-army-missile-baseline.json");
        MatchEngineTraceResult[] expected =
            JsonSerializer.Deserialize<MatchEngineTraceResult[]>(File.ReadAllText(path))!;
        IReadOnlyList<MatchEngineTraceResult> actual = Capture();
        Require(expected.Length == 10 && actual.Count == expected.Length,
            "The source missile trace inventory changed.");
        for (int index = 0; index < expected.Length; index++)
        {
            Require(expected[index] == actual[index], "Army missile trace differs: " + expected[index].Scenario);
        }
        return actual.Count;
    }

    private static MatchEngineTraceResult Natural(string unit, MissileTraceMode mode)
    {
        using PvpArmyMissileTraceFixture fixture = Ordinary("natural-" + unit + "-" + mode, unit, mode);
        string kind = Kind(unit) + (mode == MissileTraceMode.Fake ? "-fake" : "");
        BattleProjectileState first = fixture.WaitForLaunch(kind);
        Require(first.ArmyUnitId == (unit == Mortar ? Mortar : ""), "The source missile wire identity changed.");
        WaitForImpact(fixture, first.ProjectileId);
        fixture.Advance();
        Require(!fixture.Engine.CardRocketImpacts().Any(row => row.ProjectileId == first.ProjectileId),
            "A running source frame did not clear the prior missile impact observation.");
        return fixture.Finish();
    }

    private static MatchEngineTraceResult SoldierDeath(string unit)
    {
        using PvpArmyMissileTraceFixture fixture = Ordinary("soldier-death-" + unit, unit, MissileTraceMode.Real);
        BattleProjectileState first = fixture.WaitForLaunch(Kind(unit));
        ArmyCardRocketRuntime? authority = fixture.Engine.CardRocketLaunchMissile(first.ProjectileId);
        fixture.KillSoldier();
        Require(fixture.Engine.CardRocketLaunchMissile(first.ProjectileId) == authority,
            "Shooter removal must preserve the airborne missile's immutable launch authority.");
        WaitForImpact(fixture, first.ProjectileId);
        return fixture.Finish();
    }

    private static MatchEngineTraceResult TerminalClear(string unit)
    {
        using PvpArmyMissileTraceFixture fixture = Ordinary("terminal-flight-clear-" + unit, unit,
            MissileTraceMode.Real);
        BattleProjectileState first = fixture.WaitForLaunch(Kind(unit));
        fixture.Forfeit();
        fixture.Advance();
        Require(fixture.Engine.Terminal && fixture.Engine.CardRocketActiveFlightCount == 0 &&
            fixture.Engine.CardRocketLaunchMissile(first.ProjectileId) == null,
            "Terminal cleanup must release all active missiles and launch authority together.");
        return fixture.Finish();
    }

    private static MatchEngineTraceResult ReconnectPause()
    {
        using PvpArmyMissileTraceFixture fixture = Ordinary("mortar-live-reconnect-clock", Mortar,
            MissileTraceMode.ShortIdle);
        fixture.WaitForLaunch(Kind(Mortar));
        fixture.PauseAndResume();
        return fixture.Finish();
    }

    private static MatchEngineTraceResult CardRocket()
    {
        using PvpArmyMissileTraceFixture fixture = Card();
        BattleProjectileState first = fixture.WaitForLaunch(Kind(Rocket));
        WaitForImpact(fixture, first.ProjectileId);
        return fixture.Finish();
    }

    private static void WaitForImpact(PvpArmyMissileTraceFixture fixture, ulong id)
    {
        fixture.WaitUntil(() => fixture.Engine.CardRocketImpacts().Any(row => row.ProjectileId == id));
        Require(fixture.Engine.CardRocketLaunchMissile(id) == null,
            "Impact publication must remove the matching launch authority first.");
    }

    private static string Kind(string unit)
    {
        return unit == Mortar ? "army-mortar" : "card-rocket";
    }
}
