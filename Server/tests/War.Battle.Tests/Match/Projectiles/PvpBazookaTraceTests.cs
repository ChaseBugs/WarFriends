using System.Numerics;
using System.Text.Json;
using Google.Protobuf;
using War.Battle.Tests.Match.Tracing;
using War.Battle.Tests.Startup;
using War.Protocol;
using static War.Battle.Tests.Match.Projectiles.PvpBazookaFixture;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpBazookaTraceTests
{
    internal static IReadOnlyList<MatchEngineTraceResult> Capture()
    {
        return [RpgFlight(), M202Volley(), CancelHold(), PausedMissile(), ForfeitVolley(), TwoOwnerVolleys()];
    }

    internal static int Run()
    {
        string server = BackendStartupPolicyTests.FindServerDirectory();
        string file = Path.Combine(server, "tests/War.Battle.Tests/Match/Projectiles/pvp-bazooka-baseline.json");
        MatchEngineTraceResult[] expected =
            JsonSerializer.Deserialize<MatchEngineTraceResult[]>(File.ReadAllText(file))!;
        IReadOnlyList<MatchEngineTraceResult> actual = Capture();
        Require(expected.Length == 6 && actual.Count == expected.Length, "The reviewed bazooka traces changed.");
        for (int index = 0; index < expected.Length; index++)
        {
            Require(expected[index] == actual[index], "Bazooka trace differs: " + expected[index].Scenario);
        }
        return actual.Count;
    }

    private static MatchEngineTraceResult RpgFlight()
    {
        using MatchEngineTrace trace = Started("source-rpg-hold-flight-impact");
        Launch(trace);
        Require(trace.Engine.Snapshot().Projectiles.Single(row => row.Kind == "bazooka").WeaponSourceId == Rpg,
            "The launch-bound RPG identity was not published.");
        Hold(trace, First, 2, Target(trace));
        AdvanceThrough(trace, 250);
        Require(trace.Engine.Snapshot().Players[0].ShotsFired == 1, "A replay launched another RPG.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult M202Volley()
    {
        using MatchEngineTrace trace = Started("m202-delayed-order-and-switch-lock", M202);
        ulong launch = Launch(trace);
        var select = new MatchCommand { CommandId = 3, SwitchWeapon = new() { Slot = 0 } };
        Require(trace.Command(First, select).Code == "shooting", "Delayed launch authority did not lock selection.");
        AdvanceThrough(trace, launch + 12);
        MatchEvent[] shots = Shots(trace);
        Require(shots.Length == 4 && shots.Select(item => item.Reason).SequenceEqual(
            new[] { "bazooka", "bazooka-fake", "bazooka", "bazooka-fake" }),
            "The source primary/fake/real/fake sequence changed.");
        Require(trace.Command(First, new MatchCommand { CommandId = 4, SwitchWeapon = new() { Slot = 0 } }).Code ==
            "weapon-selected", "An exhausted delayed volley kept weapon selection locked.");
        AdvanceThrough(trace, 250);
        return trace.Finish();
    }

    private static MatchEngineTraceResult CancelHold()
    {
        using MatchEngineTrace trace = Started("cancel-before-source-hold-deadline");
        Hold(trace, First, 2, Target(trace));
        trace.Advance(61);
        Require(trace.Command(First, new MatchCommand { CommandId = 3, BazookaHold = new() }).Code ==
            "bazooka-cancelled", "The source hold could not be cancelled.");
        AdvanceThrough(trace, 90);
        Require(trace.Engine.Snapshot().Players[0].ShotsFired == 0 && trace.Engine.Snapshot().Projectiles.Count == 0,
            "A cancelled hold spent ammo or published a flight.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult PausedMissile()
    {
        using MatchEngineTrace trace = Started("pause-freezes-launched-missile", idleSeconds: 10);
        AdvanceThrough(trace, 260);
        Vector3 origin = trace.Engine.CombatPose(First).Collision.RootPosition;
        Vector3 direction = Vector3.Normalize(Target(trace) - origin);
        Vector3 far = origin + direction * 40 + Vector3.UnitY * 20;
        Require(Hold(trace, First, 2, far).Code == "bazooka-targeting", "The pause fixture lost its source aim.");
        AdvanceToFirstShot(trace);
        AdvanceThrough(trace, 299);
        Require(trace.Engine.Snapshot().Projectiles.Any(row => row.Kind == "bazooka"),
            "The pause fixture had no active missile.");
        byte[] beforePause = Projectiles(trace);
        trace.Poll(First);
        trace.Advance(300);
        trace.Advance(600);
        Require(beforePause.SequenceEqual(Projectiles(trace)), "Paused host time advanced the missile.");
        trace.Observe("resume-second", trace.Engine.Resume(Second));
        trace.Poll(First);
        trace.Advance(601);
        Require(trace.Engine.Snapshot().ServerTick == 300, "Resume consumed the host-time backlog.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult ForfeitVolley()
    {
        using MatchEngineTrace trace = Started("terminal-clears-active-and-delayed-m202", M202);
        Launch(trace);
        trace.Command(Second, new MatchCommand { CommandId = 2, Forfeit = new() });
        Require(trace.Engine.Terminal && trace.Engine.Snapshot().Projectiles.Count == 0 &&
            trace.Engine.PendingProjectileCount == 0, "Terminal cleanup retained a launch or missile.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult TwoOwnerVolleys()
    {
        using MatchEngineTrace trace = Started("two-owner-m202-global-curve-and-delay", M202);
        Hold(trace, First, 2, Target(trace));
        Vector3 target = trace.Engine.CombatPose(First).Collision.Parts[1].Center;
        Require(Hold(trace, Second, 2, target).Code == "bazooka-targeting", "The second source hold was refused.");
        ulong launch = AdvanceToFirstShot(trace);
        AdvanceThrough(trace, launch + 12);
        MatchEvent[] shots = Shots(trace);
        Require(shots.Length == 8 && shots.Select(item => item.ProjectileId).Distinct().Count() == 8,
            "Two delayed volleys lost their shared identity ordering.");
        AdvanceThrough(trace, 250);
        return trace.Finish();
    }

    private static byte[] Projectiles(MatchEngineTrace trace)
    {
        return trace.Engine.Snapshot().Projectiles.SelectMany(projectile => projectile.ToByteArray()).ToArray();
    }

    private static MatchEvent[] Shots(MatchEngineTrace trace)
    {
        var shots = new List<MatchEvent>();
        ulong cursor = 0;
        while (true)
        {
            MatchEventBatch page = trace.Engine.EventBatch(First, cursor);
            shots.AddRange(page.Events.Where(item => item.Kind == MatchEventKind.Shot));
            if (page.Events.Count == 0 || page.Events[^1].EventId == page.LatestEventId)
            {
                return shots.ToArray();
            }
            cursor = page.Events[^1].EventId;
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
