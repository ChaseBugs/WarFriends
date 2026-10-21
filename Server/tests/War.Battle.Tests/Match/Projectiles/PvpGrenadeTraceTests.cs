using System.Text.Json;
using Google.Protobuf;
using War.Battle.Tests.Match.Tracing;
using War.Battle.Tests.Startup;
using War.BattleServer;
using War.Protocol;
using static War.Battle.Tests.Match.Projectiles.PvpGrenadeFixture;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpGrenadeTraceTests
{
    internal static IReadOnlyList<MatchEngineTraceResult> Capture()
    {
        return [WeaponFlight(Frag), WeaponFlight(Launcher), WeaponFlight(Molotov), OrdinaryForfeit(),
            BurstReplayAndDelayedExplosion(), BurstTerminalFreeze(), BurstPause()];
    }

    internal static int Run()
    {
        string server = BackendStartupPolicyTests.FindServerDirectory();
        string path = Path.Combine(server, "tests/War.Battle.Tests/Match/Projectiles/pvp-grenade-baseline.json");
        MatchEngineTraceResult[] expected =
            JsonSerializer.Deserialize<MatchEngineTraceResult[]>(File.ReadAllText(path))!;
        IReadOnlyList<MatchEngineTraceResult> actual = Capture();
        Require(expected.Length == 7 && actual.Count == expected.Length, "The reviewed grenade traces changed.");
        for (int index = 0; index < expected.Length; index++)
        {
            Require(expected[index] == actual[index], "Grenade trace differs: " + expected[index].Scenario);
        }
        return actual.Count;
    }

    private static MatchEngineTraceResult WeaponFlight(string source)
    {
        using MatchEngineTrace trace = Ordinary("source-flight-" + source, source);
        MatchCommand command = Throw(trace, source);
        int initialAmmo = trace.Engine.Snapshot().Players[0].ClipAmmo;
        Require(trace.Command(First, command).Code == "grenade-throwing" &&
            trace.Engine.Snapshot().Players[0].ClipAmmo == initialAmmo,
            "A grenade spent ammunition before its recovered animation launch.");
        trace.Command(First, command);
        AdvanceThrough(trace, 250);
        Require(trace.Engine.Snapshot().Players[0].ShotsFired == 1 && trace.Engine.PendingProjectileCount == 0,
            "The source throw replayed its launch or retained a completed flight.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult OrdinaryForfeit()
    {
        using MatchEngineTrace trace = Ordinary("ordinary-terminal-clears-flight", Launcher);
        Require(trace.Command(First, Throw(trace, Launcher)).Code == "grenade-throwing",
            "The ordinary terminal fixture could not throw.");
        for (ulong tick = 61; tick <= 120; tick++)
        {
            trace.Advance(tick);
            if (trace.Engine.Snapshot().Players[0].ShotsFired > 0)
            {
                break;
            }
        }
        Require(trace.Engine.Snapshot().Projectiles.Any(), "The ordinary terminal fixture had no active flight.");
        trace.Command(Second, new MatchCommand { CommandId = 2, Forfeit = new() });
        Require(trace.Engine.Terminal && trace.Engine.PendingProjectileCount == 0,
            "Ordinary terminal cleanup retained its active flight.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult BurstReplayAndDelayedExplosion()
    {
        using MatchEngineTrace trace = Burst("burst-replay-collision-then-later-explosion");
        Require(trace.Command(First, UseBurst()).Code == "grenades-burst-active", "The source card was refused.");
        trace.Command(First, UseBurst());
        int collisions = 0;
        int explosions = 0;
        for (ulong tick = 61; tick <= 250; tick++)
        {
            trace.Advance(tick);
            foreach (GrenadeFlightImpact impact in trace.Engine.PvpGrenadeImpacts)
            {
                Require(impact.Tick == tick, "A collision observation escaped its current frame.");
                collisions++;
            }
            foreach (PvpBonusGrenadeExplosionQuote explosion in trace.Engine.PvpGrenadeExplosions)
            {
                Require(explosion.CollisionTick + 1 == explosion.ExplosionTick && explosion.ExplosionTick == tick,
                    "The source zero-second fuse lost its next-frame shared-setup read.");
                explosions++;
            }
        }
        Require(collisions == 3 && explosions == 3 && trace.Engine.PendingPvpGrenadeFlights == 0,
            "Card replay duplicated grenades or a collision/explosion transition was lost.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult BurstTerminalFreeze()
    {
        using MatchEngineTrace trace = Burst("existing-burst-terminal-freeze-boundary");
        trace.Command(First, UseBurst());
        AdvanceThrough(trace, 68);
        Require(trace.Engine.Snapshot().Projectiles.Any(row => row.Kind == "pvp-bonus-grenade"),
            "The bonus terminal fixture had no active flight.");
        byte[] flights = Projectiles(trace);
        trace.Command(Second, new MatchCommand { CommandId = 2, Forfeit = new() });
        // This records existing server retention, not a recovered Client terminal-cleanup requirement.
        Require(trace.Engine.Terminal && flights.SequenceEqual(Projectiles(trace)),
            "The refactor changed the existing bonus terminal freeze boundary.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult BurstPause()
    {
        using MatchEngineTrace trace = Burst("pause-preserves-card-clock-and-live-flights", 10);
        AdvanceThrough(trace, 280);
        trace.Command(First, UseBurst());
        AdvanceThrough(trace, 299);
        Require(trace.Engine.PendingPvpGrenadeFlights > 0, "The pause fixture lost every live grenade.");
        byte[] before = Projectiles(trace);
        trace.Poll(First);
        trace.Advance(300);
        trace.Advance(600);
        Require(before.SequenceEqual(Projectiles(trace)), "Reconnect host time advanced bonus grenade motion.");
        trace.Observe("resume-second", trace.Engine.Resume(Second));
        trace.Poll(First);
        trace.Advance(601);
        Require(trace.Engine.Snapshot().ServerTick == 300, "Resume consumed the paused host-time backlog.");
        return trace.Finish();
    }

    private static byte[] Projectiles(MatchEngineTrace trace)
    {
        return trace.Engine.Snapshot().Projectiles.SelectMany(row => row.ToByteArray()).ToArray();
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
