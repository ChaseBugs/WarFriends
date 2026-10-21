using System.Text.Json;
using War.Battle.Tests.Match.Tracing;
using War.Battle.Tests.Startup;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpArmyBulletTraceTests
{
    private const string First = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string Second = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private const string Assault = "ID_UNIT-ASSAULT";
    private const string Gunslinger = "ID_UNIT-GUNSLINGER";
    private const string Shotgunner = "ID_UNIT-SHOTGUNNER";
    private const string Commando = "ID_UNIT-COMMANDO";
    private const int RandomScale = 1_000_000;
    private const ulong MaximumLaunchTick = 1800;
    private const ulong ResolutionTicks = 400;
    private const int GrenadierPistolDraw = 400_000;
    private const int ShotgunPelletCount = 5;
    private static readonly Lazy<BattleCombatContent> ContentCache = new(LoadContent);

    internal static IReadOnlyList<MatchEngineTraceResult> Capture()
    {
        return [Ordinary(Assault), Ordinary(Assault, true), Ordinary(Gunslinger), Ordinary(Gunslinger, true),
            Ordinary(Shotgunner), Ordinary(Commando), DeathSurvival(), TerminalClear(), CardGrenadier()];
    }

    internal static int Run()
    {
        string server = BackendStartupPolicyTests.FindServerDirectory();
        string path = Path.Combine(server, "tests/War.Battle.Tests/Match/Projectiles/pvp-army-bullet-baseline.json");
        MatchEngineTraceResult[] expected =
            JsonSerializer.Deserialize<MatchEngineTraceResult[]>(File.ReadAllText(path))!;
        IReadOnlyList<MatchEngineTraceResult> actual = Capture();
        Require(expected.Length == 9 && actual.Count == expected.Length, "The reviewed army bullet traces changed.");
        for (int index = 0; index < expected.Length; index++)
        {
            Require(expected[index] == actual[index], "Army bullet trace differs: " + expected[index].Scenario);
        }
        return actual.Count;
    }

    private static BattleCombatContent LoadContent()
    {
        return BattleArmyManifestProjectionTests.LoadContent(
            Path.Combine(BackendStartupPolicyTests.FindServerDirectory(), "content"));
    }

    private static MatchEngineTrace CreateOrdinary(string scenario, string unit, bool isCosmetic = false)
    {
        int Choose(int maximum) => isCosmetic && maximum == RandomScale ? RandomScale - 1 : 0;
        MatchEngine engine = unit == Commando
            ? OrdinaryArmyTestHost.CreateUpgraded(ContentCache.Value, unit, new(0, 71, -1))
            : OrdinaryArmyTestHost.Create(ContentCache.Value, unit, armyChoice: Choose);
        var trace = new MatchEngineTrace(scenario, engine);
        int option = engine.ArmyBatch(Second).OptionIndexes
            .OrderBy(index => ContentCache.Value.Army.Option(index).Count).First();
        var command = new MatchCommand { CommandId = 3, DeployArmy = new() { OptionIndex = option } };
        Require(trace.Command(Second, command).Code == "army-deploying", "Source army deployment failed.");
        trace.Command(Second, command);
        return trace;
    }

    private static MatchEngineTraceResult Ordinary(string unit, bool isCosmetic = false)
    {
        using MatchEngineTrace trace = CreateOrdinary("source-army-" + unit + "-" + isCosmetic, unit, isCosmetic);
        BattleProjectileState first = WaitForFlight(trace, unit);
        Require(first.Kind == (isCosmetic ? "army-fake-bullet" : "army-bullet"), "The source bullet kind differs.");
        if (unit == Shotgunner)
        {
            Require(trace.Engine.Snapshot().Projectiles.Count(row => row.Kind == "army-fake-bullet") >=
                ShotgunPelletCount - 1,
                "The source shotgun did not launch four cosmetic trails beside its real pellet.");
        }
        if (unit == Commando)
        {
            Require(first.ArmyPoison, "The upgraded Commando lost its launch-bound poison identity.");
        }
        ObserveAuthority(trace, first);
        AdvanceFor(trace, ResolutionTicks);
        Require(!trace.Engine.Snapshot().Projectiles.Any(row => row.ProjectileId == first.ProjectileId),
            "The captured source army bullet failed to complete.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult DeathSurvival()
    {
        using MatchEngineTrace trace = CreateOrdinary("launched-army-bullet-survives-soldier", Assault);
        BattleProjectileState first = WaitForFlight(trace, Assault);
        ulong entity = trace.Engine.ArmyProjectileSourceEntity(first.ProjectileId)!.Value;
        (string OwnerPlayerId, int OwnerFraction, float Damage)? authority =
            trace.Engine.ArmyProjectileLaunch(first.ProjectileId);
        trace.Observe("confirmed-soldier-death", trace.Engine.ConfirmArmyDeath(entity, false));
        Require(trace.Engine.ArmyProjectileLaunch(first.ProjectileId) == authority,
            "Soldier death removed a launched bullet's authority.");
        AdvanceFor(trace, ResolutionTicks);
        Require(!trace.Engine.Terminal && trace.Engine.ArmyProjectileLaunch(first.ProjectileId) == null,
            "A dead soldier's launched bullet failed to complete normally.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult TerminalClear()
    {
        using MatchEngineTrace trace = CreateOrdinary("terminal-clears-real-and-cosmetic-army-bullets", Shotgunner);
        WaitForFlight(trace, Shotgunner);
        ulong[] ids = trace.Engine.Snapshot().Projectiles.Select(row => row.ProjectileId).ToArray();
        Require(ids.Length >= ShotgunPelletCount,
            "The terminal fixture did not capture a complete source pellet group.");
        trace.Command(First, new MatchCommand { CommandId = 3, Forfeit = new() });
        Require(trace.Engine.Terminal && trace.Engine.PendingProjectileCount == 0 && ids.All(id =>
            trace.Engine.ArmyProjectileLaunch(id) == null && trace.Engine.ArmyProjectileSpeed(id) == null),
            "Terminal cleanup retained army flights or their launch authority.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult CardGrenadier()
    {
        RecoveredBattleMap map = ContentCache.Value.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        int Choose(int maximum) => maximum == RandomScale ? GrenadierPistolDraw : 0;
        MatchEngine engine = GrenadierPrimaryDamageTests.CreateRealShotHost(ContentCache.Value, map, Choose);
        using var trace = new MatchEngineTrace("card-grenadier-primary-army-bullet", engine);
        Require(trace.Command(First, new MatchCommand { CommandId = 3, UseUnitCard = new()
        {
            RequestId = "cccccccccccccccccccccccccccccccc", SourceCardId = "GREATGRENADIER"
        } }).Code == "unit-card-activated", "The source Grenadier card was refused.");
        BattleProjectileState first = WaitForFlight(trace, "ID_UNIT-GRENADIER");
        Require(first.ArmySourceCardId == "GREATGRENADIER", "Card launch metadata was lost.");
        ObserveAuthority(trace, first);
        AdvanceFor(trace, ResolutionTicks);
        return trace.Finish();
    }

    private static BattleProjectileState WaitForFlight(MatchEngineTrace trace, string unit)
    {
        while (!trace.Engine.Terminal && trace.Engine.Snapshot().ServerTick < MaximumLaunchTick)
        {
            trace.Advance(trace.Engine.Snapshot().ServerTick + 1);
            BattleProjectileState? flight = trace.Engine.Snapshot().Projectiles.FirstOrDefault(row =>
                row.ArmyUnitId == unit && row.Kind is "army-bullet" or "army-fake-bullet");
            if (flight != null)
            {
                return flight;
            }
        }
        throw new InvalidOperationException("Source army launch was absent: " + unit + "/" +
            trace.Engine.Snapshot().TerminalReason);
    }

    private static void ObserveAuthority(MatchEngineTrace trace, BattleProjectileState first)
    {
        Require(trace.Engine.ArmyProjectileLaunch(first.ProjectileId) is { } launch &&
            launch.OwnerPlayerId == first.OwnerPlayerId && launch.Damage >= 0 &&
            trace.Engine.ArmyProjectileSourceEntity(first.ProjectileId).HasValue &&
            trace.Engine.ArmyProjectileSpeed(first.ProjectileId) > 0,
            "The source snapshot has no matching detached launch metadata.");
        trace.Observe("source-launch-authority", true);
    }

    private static void AdvanceFor(MatchEngineTrace trace, ulong count)
    {
        ulong target = trace.Engine.Snapshot().ServerTick + count;
        while (!trace.Engine.Terminal && trace.Engine.Snapshot().ServerTick < target)
        {
            trace.Advance(trace.Engine.Snapshot().ServerTick + 1);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
