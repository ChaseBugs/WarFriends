using System.Numerics;
using System.Reflection;
using War.Battle.Tests.Match.Tracing;
using War.Battle.Tests.Startup;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Movement;

internal static class PvpMovementStateTests
{
    internal static int Run()
    {
        string server = BackendStartupPolicyTests.FindServerDirectory();
        RecoveredBattleMap map = RecoveredBattleMap.Load(Path.Combine(server, "content/recovered-battle-content.json"))
            .Single(candidate => candidate.Source.EndsWith("Aztec_Multiplayer.unity"));
        CheckDeferredFrameAndVelocity(map);
        CheckSkippedTicksAndArrival(map);
        CheckSpeedChangesRetainProgress(map);
        CheckCancellationRetainsObservation(map);
        CheckPrivateStateAndIndependentPlayers(map);
        CheckMapCannotBeRebound(map);
        CheckActiveRouteExpiry(map);
        CheckLiveMapResolution(server);
        return 8;
    }

    private static PvpPlayerMovementState Started(RecoveredBattleMap map)
    {
        var movement = new PvpPlayerMovementState();
        movement.InitializeCover(map, 5);
        movement.BeginRoute(6, 60, 1);
        return movement;
    }

    private static void ObserveFrame(PvpPlayerMovementState movement, ulong tick, float speed = 1)
    {
        Vector3 previous = movement.Position;
        movement.AdvanceRoute(tick, speed);
        movement.ObserveFrameVelocity(previous);
    }

    private static void CheckDeferredFrameAndVelocity(RecoveredBattleMap map)
    {
        PvpPlayerMovementState movement = Started(map);
        Vector3 origin = movement.Position;
        ObserveFrame(movement, 60);
        ObserveFrame(movement, 61);
        Require(movement.IsMoving && movement.Cover == 5 && movement.Position == origin &&
            movement.Velocity == Vector3.Zero, "Deferred movement changed physical cover or produced velocity.");

        ObserveFrame(movement, 62);
        Require(movement.Position != origin && movement.Velocity == (movement.Position - origin) * 30,
            "The first frame lost source position-delta velocity.");
        Vector3 afterFirstStep = movement.Position;
        ObserveFrame(movement, 62);
        Require(movement.Position == afterFirstStep && movement.Velocity == Vector3.Zero,
            "Repeated simulation time advanced a route or retained stale observed velocity.");
    }

    private static void CheckSkippedTicksAndArrival(RecoveredBattleMap map)
    {
        PvpPlayerMovementState movement = Started(map);
        Vector3 origin = movement.Position;
        ObserveFrame(movement, 65);
        Vector3 expectedVelocity = (movement.Position - origin) * MatchManifest.TickRate;
        Require(expectedVelocity != Vector3.Zero && movement.Velocity == expectedVelocity,
            "Skipped ticks incorrectly divided the source observed frame delta.");

        ulong deadline = movement.MoveEnd;
        ObserveFrame(movement, deadline);
        Require(!movement.IsMoving && movement.Cover == 6 && movement.Position == map.Covers[6].Position &&
            movement.MoveEnd == deadline, "Inclusive arrival lost the authoritative cover or retained deadline.");
        ObserveFrame(movement, deadline + 1);
        Require(movement.Velocity == Vector3.Zero, "An idle post-arrival frame kept movement velocity.");
    }

    private static void CheckSpeedChangesRetainProgress(RecoveredBattleMap map)
    {
        PvpPlayerMovementState movement = Started(map);
        ObserveFrame(movement, 65);
        Vector3 progressed = movement.Position;
        ulong originalEnd = movement.MoveEnd;
        movement.RecalculateDeadline(65, 0.5f);
        Require(movement.Position == progressed && movement.Cover == 5 && movement.MoveEnd > originalEnd,
            "A slower speed restarted the path or failed to extend its remaining deadline.");
        ObserveFrame(movement, 66, 0.5f);
        Require(Vector3.Distance(progressed, movement.Position) <= 0.5f / 30 + 0.00001f,
            "An active route ignored its absolute source speed.");
        movement.RecalculateDeadline(66, 2);
        Require(movement.MoveEnd < originalEnd, "Speed restoration ignored retained route progress.");

        PvpPlayerMovementState deferred = Started(map);
        deferred.RecalculateDeadline(60, 0.5f);
        ObserveFrame(deferred, 61, 0.5f);
        Require(deferred.Position == map.Covers[5].Position,
            "A pre-start speed change removed the deferred destination boundary.");
    }

    private static void CheckCancellationRetainsObservation(RecoveredBattleMap map)
    {
        PvpPlayerMovementState movement = Started(map);
        ObserveFrame(movement, 65);
        Vector3 lastPosition = movement.Position;
        Vector3 lastVelocity = movement.Velocity;
        ulong deadline = movement.MoveEnd;
        movement.CancelRoute();
        Require(!movement.IsMoving && movement.Position == lastPosition && movement.Cover == 5 &&
            movement.Destination == 6 && movement.MoveEnd == deadline && movement.Velocity == lastVelocity,
            "Route cancellation rewrote the last trusted physical/deadline observation.");
        ObserveFrame(movement, 66);
        Require(movement.Position == lastPosition && movement.Velocity == Vector3.Zero,
            "A cancelled route advanced on its next frame.");
        movement.RecalculateDeadline(70, 0.5f);
        Require(movement.MoveEnd == deadline, "A cancelled route acquired a new deadline.");
    }

    private static void CheckPrivateStateAndIndependentPlayers(RecoveredBattleMap map)
    {
        PvpPlayerMovementState first = Started(map);
        PvpPlayerMovementState second = Started(map);
        ObserveFrame(first, 65);
        Require(second.Position == map.Covers[5].Position && second.Velocity == Vector3.Zero && second.IsMoving,
            "Two players shared mutable movement state.");

        const BindingFlags Members = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        Type player = typeof(MatchEngine).GetNestedType("Player", BindingFlags.NonPublic)!;
        foreach (string name in new[] { "Cover", "Position", "MoveVelocity", "MoveEnd", "Destination", "IsMoving" })
        {
            Require(player.GetField(name, Members) == null && player.GetProperty(name, Members)?.SetMethod == null,
                "The engine retained writable movement state: " + name);
        }
        foreach (string name in new[] { "Cover", "Position", "Velocity", "MoveEnd", "Destination" })
        {
            Require(typeof(PvpPlayerMovementState).GetProperty(name, Members)?.SetMethod?.IsPrivate == true,
                "Movement authority can be assigned outside its owner: " + name);
        }
        Require(!typeof(PvpPlayerMovementState).GetProperties(Members).Any(property => property.PropertyType.IsArray),
            "The private movement route escaped through an array property.");
        foreach (string removed in new[] { "Route", "RouteLength", "RouteTravelled", "MoveStart", "LastMoveTick" })
        {
            Require(player.GetMember(removed, Members).Length == 0, "The engine retained route storage: " + removed);
        }
    }

    private static void CheckMapCannotBeRebound(RecoveredBattleMap map)
    {
        PvpPlayerMovementState movement = Started(map);
        try
        {
            movement.InitializeCover(map, 6);
        }
        catch (InvalidOperationException)
        {
            Require(movement.Cover == 5 && movement.IsMoving, "Rejected map rebinding changed an active route.");
            return;
        }
        throw new InvalidOperationException("An allocated movement owner accepted a second map binding.");
    }

    private static void CheckLiveMapResolution(string server)
    {
        BattleCombatContent content = BattleCombatContent.Load(
            Path.Combine(server, "content/combat-content-manifest.json"));
        RecoveredBattleMap map = content.Maps.Single(candidate => candidate.Source.EndsWith("Aztec_Multiplayer.unity"));
        WeaponManifest weapon = content.Stats.CreateManifest("Google2u.AssaultRifle_AK47", 0);
        var manifest = new MatchManifest("movement-bound-map", "test-host", "Aztec_Multiplayer", map.SourceHash,
            content.Revision, MatchManifest.RifleCombatMode, 10, 600, 120,
            [new(new string('a', 32), weapon, 2, 5, 1, new(100), 0),
                new(new string('b', 32), weapon, 1, 1, 1, new(100), 0)]);
        var engine = new MatchEngine(manifest, content: content);
        Require(engine.Snapshot().Players[0].PositionX == map.Covers[5].Position.X,
            "Movement bound the optional constructor map before live content resolved its authoritative map.");
    }

    private static void CheckActiveRouteExpiry(RecoveredBattleMap map)
    {
        using MatchEngineTrace trace = PvpMovementTraceTests.Started("active-route-expiry", map, 0.1f);
        const string First = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        const string Second = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
        MatchReply slow = trace.Command(Second, new MatchCommand
        {
            CommandId = 3,
            UseSlowMove = new() { RequestId = "22222222222222222222222222222222" }
        });
        Require(slow.Code == "slow-move-active", "The active-expiry fixture did not apply its source card.");
        for (ulong tick = 61; tick <= 350; tick++)
        {
            trace.Advance(tick);
        }
        trace.Command(First, new MatchCommand { CommandId = 2, MoveCover = new() { Direction = 1 } });
        ulong slowedEnd = trace.Engine.Snapshot().Players[0].MoveEndTick;
        for (ulong tick = 351; tick <= 359; tick++)
        {
            trace.Advance(tick);
        }
        Require(trace.Engine.Snapshot().Players[0].Moving, "The active-expiry route arrived before card expiry.");
        trace.Advance(360);
        MatchSnapshot expired = trace.Engine.Snapshot();
        Require(expired.CardEffects.Count == 0 && expired.Players[0].Moving &&
            expired.Players[0].MoveEndTick > slowedEnd,
            "Card expiry failed to reschedule the active route using its restored absolute speed.");
        Vector3 beforeStep = new(expired.Players[0].PositionX, expired.Players[0].PositionY,
            expired.Players[0].PositionZ);
        trace.Advance(361);
        BattlePlayerState player = trace.Engine.Snapshot().Players[0];
        float distance = Vector3.Distance(beforeStep, new(player.PositionX, player.PositionY, player.PositionZ));
        Require(distance > 0 && distance <= 0.1f / MatchManifest.TickRate + 0.00001f,
            "The first post-expiry frame retained the old speed or restarted movement.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
