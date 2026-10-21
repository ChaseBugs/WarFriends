using System.Numerics;
using System.Text.Json;
using War.Battle.Tests.Match.Tracing;
using War.Battle.Tests.Startup;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Movement;

internal static class PvpMovementTraceTests
{
    private const string First = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string Second = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private const string RequestId = "11111111111111111111111111111111";
    private const string SlowCard = "SLOWMOVE";

    internal static IReadOnlyList<MatchEngineTraceResult> Capture()
    {
        string server = BackendStartupPolicyTests.FindServerDirectory();
        IReadOnlyList<RecoveredBattleMap> maps = RecoveredBattleMap.Load(
            Path.Combine(server, "content/recovered-battle-content.json"));
        List<MatchEngineTraceResult> results = maps.Select(TraverseMap).ToList();
        RecoveredBattleMap aztec = maps.Single(map => map.Source.EndsWith("Aztec_Multiplayer.unity"));
        results.Add(SlowDuringRoute(aztec));
        results.Add(PauseDuringRoute(aztec));
        results.Add(DeathDuringRoute(aztec));
        return results;
    }

    internal static int Run()
    {
        string server = BackendStartupPolicyTests.FindServerDirectory();
        string path = Path.Combine(server, "tests/War.Battle.Tests/Match/Movement/pvp-movement-baseline.json");
        MatchEngineTraceResult[] expected =
            JsonSerializer.Deserialize<MatchEngineTraceResult[]>(File.ReadAllText(path))!;
        IReadOnlyList<MatchEngineTraceResult> actual = Capture();
        Require(expected.Length == 8 && actual.Count == expected.Length, "The reviewed movement traces changed.");
        for (int index = 0; index < expected.Length; index++)
        {
            Require(expected[index] == actual[index], "Movement trace differs: " + expected[index].Scenario);
        }
        return actual.Count;
    }

    private static MatchEngineTraceResult TraverseMap(RecoveredBattleMap map)
    {
        using MatchEngineTrace trace = Started("path-" + Path.GetFileNameWithoutExtension(map.Source), map);
        Require(Move(trace, 2, 2).Code == "cover-unavailable", "An unsupported direction selected a route.");
        var mismatch = new MatchCommand { CommandId = 3, MoveCover = new()
        {
            Direction = 1, TargetCoverIndex = 4
        } };
        Require(trace.Command(First, mismatch).Code == "cover-target-mismatch",
            "A mismatched client cover assertion selected a route.");
        MatchReply accepted = Move(trace, 4, 1);
        Require(accepted.Code == "moving" && Player(trace).CoverIndex == 5 && Player(trace).Moving,
            "Movement did not retain its physical source cover.");
        trace.Command(First, new MatchCommand { CommandId = 4, MoveCover = new() { Direction = 1 } });
        Require(Move(trace, 5, -1).Code == "already-moving", "An active route was replaced.");
        Vector3 origin = Position(trace);
        trace.Advance(60);
        trace.Advance(61);
        Require(Position(trace) == origin, "Deferred movement advanced at its start boundary.");
        trace.Advance(62);
        Require(Position(trace) != origin && Player(trace).Moving, "The first movement step was skipped.");
        trace.Advance(62);
        ulong end = Player(trace).MoveEndTick;
        trace.Advance(end);
        Require(Player(trace).CoverIndex == 6 && !Player(trace).Moving,
            "The route did not snap to its authoritative destination.");
        Require(Move(trace, 6, -1).Code == "moving", "The reverse recovered path was unavailable.");
        trace.Advance(Player(trace).MoveEndTick);
        Require(Player(trace).CoverIndex == 5 && Position(trace) == origin, "Reverse traversal did not arrive.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult SlowDuringRoute(RecoveredBattleMap map)
    {
        using MatchEngineTrace trace = Started("slow-route-replay-and-expiry", map, 0.1f);
        Move(trace, 2, 1);
        trace.Advance(62);
        ulong originalEnd = Player(trace).MoveEndTick;
        var slow = new MatchCommand { CommandId = 3, UseSlowMove = new() { RequestId = RequestId } };
        Require(trace.Command(Second, slow).Code == "slow-move-active", "The source slow card was refused.");
        ulong changedEnd = Player(trace).MoveEndTick;
        // Source BelovedEnemy assigns absolute speed 0.5, so a slower fixture actually accelerates.
        Require(changedEnd < originalEnd, "The absolute source speed became a multiplier or minimum.");
        trace.Command(Second, slow);
        Require(Player(trace).MoveEndTick == changedEnd, "Card replay changed the movement deadline.");
        for (ulong tick = 63; tick <= 362; tick++)
        {
            trace.Advance(tick);
        }
        Require(trace.Engine.Snapshot().CardEffects.Count == 0, "The ten-second card did not expire.");
        Require(Player(trace).CoverIndex == 6 && !Player(trace).Moving, "The adjusted route never arrived.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult PauseDuringRoute(RecoveredBattleMap map)
    {
        using MatchEngineTrace trace = Started("paused-route-has-no-catch-up", map, 0.05f, 10);
        Move(trace, 2, 1);
        trace.Advance(299);
        Vector3 beforePause = Position(trace);
        ulong end = Player(trace).MoveEndTick;
        trace.Poll(First);
        trace.Advance(300);
        trace.Advance(600);
        Require(Position(trace) == beforePause && Player(trace).MoveEndTick == end,
            "Reconnect host time advanced or rescheduled the route.");
        trace.Observe("resume-second", trace.Engine.Resume(Second));
        trace.Poll(First);
        trace.Advance(601);
        Require(trace.Engine.Snapshot().ServerTick == 300 && Vector3.Distance(beforePause, Position(trace)) < 0.01f,
            "Resume replayed the paused movement backlog.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult DeathDuringRoute(RecoveredBattleMap map)
    {
        using MatchEngineTrace trace = Started("death-cancels-route-before-terminal", map);
        Move(trace, 2, 1);
        trace.Advance(62);
        PlayerDamageResult? damage = trace.Engine.ApplyResolvedPlayerDamage(Second, First,
            new ResolvedPlayerDamage(1000, CombatDamageType.Basic), 0.5f);
        trace.Observe("trusted-lethal-hit", damage?.Dead == true);
        Require(trace.Engine.Terminal && !Player(trace).Moving && Player(trace).Dead,
            "Death published terminal evidence with an active route.");
        return trace.Finish();
    }

    internal static MatchEngineTrace Started(string scenario, RecoveredBattleMap map, float speed = 1,
        int idleSeconds = 120)
    {
        var weapon = new WeaponManifest("fixture-weapon", 5, 10, 0.1, 0.2);
        var manifest = new MatchManifest("movement-trace", "test-host",
            Path.GetFileNameWithoutExtension(map.Source), map.SourceHash, new string('a', 64),
            MatchManifest.PrototypeMode, 10, 600, idleSeconds,
            [new(First, weapon, 2, 5, speed, new(100)), new(Second, weapon, 1, 1, 1, new(100))]);
        var trace = new MatchEngineTrace(scenario, manifest, map);
        trace.Engine.ConfigureCardSelection([SlowCard]);
        trace.Engine.ConfigureCardInventory([(Second, SlowCard, 1)]);
        trace.AdmitBoth();
        var selection = new SelectCardsCommand();
        selection.CardIds.Add(SlowCard);
        Require(trace.Command(Second, new MatchCommand { CommandId = 1, SelectCards = selection }).Code ==
            "cards-selected", "The movement fixture could not select the source card.");
        trace.Ready(First);
        trace.Command(Second, new MatchCommand { CommandId = 2,
            Ready = new() { ManifestHash = trace.Engine.ManifestHash } });
        trace.Advance(60);
        return trace;
    }

    private static MatchReply Move(MatchEngineTrace trace, ulong commandId, int direction)
    {
        return trace.Command(First, new MatchCommand { CommandId = commandId,
            MoveCover = new() { Direction = direction } });
    }

    private static BattlePlayerState Player(MatchEngineTrace trace)
    {
        return trace.Engine.Snapshot().Players[0];
    }

    private static Vector3 Position(MatchEngineTrace trace)
    {
        BattlePlayerState player = Player(trace);
        return new(player.PositionX, player.PositionY, player.PositionZ);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
