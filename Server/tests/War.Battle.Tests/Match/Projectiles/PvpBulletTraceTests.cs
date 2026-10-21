using System.Numerics;
using System.Text.Json;
using War.Battle.Tests.Match.Tracing;
using War.Battle.Tests.Startup;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpBulletTraceTests
{
    private const string First = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string Second = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private const string ShotgunSource = "Google2u.Shotgun_Fixture";

    private sealed record Options(float Damage = 5, float Speed = 30, bool IsFast = true,
        Func<Vector3, Vector3, float, ShotCollision?>? Trace = null);

    internal static IReadOnlyList<MatchEngineTraceResult> Capture()
    {
        return [VisualVolley(), MultipleVolleys(), LethalFirstPellet(), SlowMiss(),
            InvalidTrace(), PausedFlight(), ForfeitCleanup()];
    }

    internal static int Run()
    {
        string server = BackendStartupPolicyTests.FindServerDirectory();
        string file = Path.Combine(server, "tests/War.Battle.Tests/Match/Projectiles/pvp-bullet-baseline.json");
        MatchEngineTraceResult[] expected =
            JsonSerializer.Deserialize<MatchEngineTraceResult[]>(File.ReadAllText(file))!;
        IReadOnlyList<MatchEngineTraceResult> actual = Capture();
        Require(expected.Length == 7 && actual.Count == expected.Length, "The reviewed player-bullet traces changed.");
        for (int index = 0; index < expected.Length; index++)
        {
            Require(expected[index] == actual[index], "Player-bullet trace differs: " + expected[index].Scenario);
        }
        return actual.Count;
    }

    private static MatchEngineTraceResult VisualVolley()
    {
        using MatchEngineTrace trace = Started("real-and-cosmetic-expiry-and-replay", Visual);
        Fire(trace, First, 2);
        Require(trace.Engine.PendingProjectileCount == 3 && trace.Engine.Snapshot().Projectiles.Count == 3,
            "The full real/cosmetic volley was not published.");
        Fire(trace, First, 2);
        Require(trace.Engine.PendingProjectileCount == 3, "Command replay duplicated a volley.");
        for (ulong tick = 61; tick <= 73; tick++)
        {
            trace.Advance(tick);
        }
        Require(trace.Engine.PendingProjectileCount == 0 && trace.Engine.Snapshot().Players[1].Health == 95,
            "Cosmetic pellets damaged a player or finished flights remained active.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult MultipleVolleys()
    {
        using MatchEngineTrace trace = Started("shared-ids-with-two-owners", Visual);
        Fire(trace, First, 2);
        Fire(trace, Second, 2);
        trace.Advance(61);
        trace.Advance(62);
        trace.Advance(63);
        Fire(trace, First, 3);
        Require(trace.Engine.Snapshot().Projectiles.Select(projectile => projectile.ProjectileId).Distinct().Count()
            == trace.Engine.PendingProjectileCount, "Coexisting volleys reused an active projectile identity.");
        for (ulong tick = 64; tick <= 77; tick++)
        {
            trace.Advance(tick);
        }
        Require(trace.Engine.PendingProjectileCount == 0, "A coexisting volley failed to expire.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult LethalFirstPellet()
    {
        using MatchEngineTrace trace = Started("lethal-first-real-clears-later-flights", (id, owner, target, tick) =>
            new([Real(id, owner, tick, new(Damage: 1000, Trace: PlayerHit)),
                    Real(id + 1, owner, tick, new(Trace: PlayerHit))],
                [new(id + 2, owner, ShotgunSource, Vector3.Zero, target, 30, tick)]));
        Fire(trace, First, 2);
        for (ulong tick = 61; tick <= 64; tick++)
        {
            trace.Advance(tick);
        }
        Require(trace.Engine.Terminal && trace.Engine.PendingProjectileCount == 0 &&
            trace.Engine.EventBatch(First, 0).Events.Count(item => item.Kind == MatchEventKind.Impact) == 1,
            "Lethal impact advanced a later pellet or retained cosmetic flights.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult SlowMiss()
    {
        using MatchEngineTrace trace = Started("slow-miss-check-and-tail", (id, owner, _, tick) =>
            new([Real(id, owner, tick, new(IsFast: false))], []));
        Fire(trace, First, 2);
        for (ulong tick = 61; tick <= 73; tick++)
        {
            trace.Advance(tick);
        }
        Require(trace.Engine.PendingProjectileCount == 0 && trace.Engine.Snapshot().Players[1].Health == 100,
            "A missed slow flight damaged a player or retained its tail.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult InvalidTrace()
    {
        int calls = 0;
        ShotCollision? InvalidAfterLaunch(Vector3 origin, Vector3 direction, float distance)
        {
            calls++;
            return calls == 1 ? null : new(float.NaN, origin + direction, "fixture/invalid", Second, 1);
        }
        using MatchEngineTrace trace = Started("invalid-step-aborts-and-clears", (id, owner, target, tick) =>
            new([Real(id, owner, tick, new(IsFast: false, Trace: InvalidAfterLaunch))],
                [new(id + 1, owner, ShotgunSource, Vector3.Zero, target, 30, tick)]));
        Fire(trace, First, 2);
        for (ulong tick = 61; tick <= 70 && !trace.Engine.Terminal; tick++)
        {
            trace.Advance(tick);
        }
        Require(trace.Engine.Snapshot().TerminalReason == "invalid-projectile-authority" &&
            trace.Engine.PendingProjectileCount == 0, "Malformed flight geometry did not fail closed.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult PausedFlight()
    {
        using MatchEngineTrace trace = Started("projectile-pause-and-single-step-resume", (id, owner, _, tick) =>
            new([Real(id, owner, tick, new(Speed: 0.1f))], []));
        Fire(trace, First, 2);
        for (ulong tick = 61; tick <= 299; tick++)
        {
            trace.Advance(tick);
        }
        float position = trace.Engine.Snapshot().Projectiles[0].Z;
        trace.Poll(First);
        trace.Advance(300);
        trace.Advance(600);
        Require(trace.Engine.Snapshot().Projectiles[0].Z == position, "Paused host time advanced the bullet.");
        trace.Observe("resume-second", trace.Engine.Resume(Second));
        trace.Poll(First);
        trace.Advance(601);
        Require(trace.Engine.Snapshot().ServerTick == 300 &&
            trace.Engine.Snapshot().Projectiles[0].Z > position, "Resume failed to advance exactly one flight step.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult ForfeitCleanup()
    {
        using MatchEngineTrace trace = Started("terminal-clears-real-and-cosmetic", Visual);
        Fire(trace, First, 2);
        trace.Command(Second, new MatchCommand { CommandId = 2, Forfeit = new() });
        Require(trace.Engine.Terminal && trace.Engine.PendingProjectileCount == 0 &&
            trace.Engine.Snapshot().Projectiles.Count == 0, "Terminal cleanup retained player flights.");
        return trace.Finish();
    }

    private static MatchEngineTrace Started(string scenario,
        Func<ulong, string, Vector3, ulong, PreparedVolley> prepare)
    {
        var weapon = new WeaponManifest(ShotgunSource, 10, 10, 0.1, 0.2);
        string hash = new('a', 64);
        var manifest = new MatchManifest("bullet-trace", "test-host", "fixture-map", hash, hash,
            MatchManifest.PrototypeMode, 10, 600, 10,
            [new(First, weapon, 1, Combat: new(100)), new(Second, weapon, 2, Combat: new(100))]);
        var trace = new MatchEngineTrace(scenario, manifest);
        trace.Engine.ConfigureVisualVolley(prepare, () => 1);
        trace.AdmitBoth();
        trace.Ready(First);
        trace.Ready(Second);
        trace.Advance(60);
        return trace;
    }

    private static PreparedVolley Visual(ulong id, string owner, Vector3 target, ulong tick)
    {
        return new([Real(id, owner, tick, new(Trace: PlayerHit))],
            [new(id + 1, owner, ShotgunSource, Vector3.Zero, target, 30, tick),
                new(id + 2, owner, ShotgunSource, Vector3.Zero, target + Vector3.UnitX * 0.1f, 30, tick)]);
    }

    private static PreparedProjectile Real(ulong id, string owner, ulong tick, Options options)
    {
        var flight = new BulletFlight(id, owner, new(options.Speed, 1, options.IsFast), Vector3.Zero,
            new(0, 0, 3), tick, options.Trace ?? ((_, _, _) => null));
        return new(flight, new(options.Damage, CombatDamageType.Shot), ShotgunSource);
    }

    private static ShotCollision? PlayerHit(Vector3 origin, Vector3 direction, float range)
    {
        float distance = (3 - origin.Z) / direction.Z;
        return distance < 0 || distance > range ? null :
            new(distance, origin + direction * distance, "fixture/player", Second, 1, SourceDestroyable: true);
    }

    private static MatchReply Fire(MatchEngineTrace trace, string owner, ulong commandId)
    {
        return trace.Command(owner, new MatchCommand { CommandId = commandId, Fire = new() { TargetZ = 3 } });
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
