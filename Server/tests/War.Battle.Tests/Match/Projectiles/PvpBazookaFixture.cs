using System.Numerics;
using War.Battle.Tests.Match.Tracing;
using War.Battle.Tests.Startup;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpBazookaFixture
{
    internal const string First = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    internal const string Second = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    internal const string Rpg = "Google2u.Bazooka_RPG7";
    internal const string M202 = "Google2u.Bazooka_M202";

    private static readonly Lazy<BattleCombatContent> _content = new(LoadContent);

    internal static BattleCombatContent Content => _content.Value;

    internal static MatchEngineTrace Started(string scenario, string source = Rpg, int idleSeconds = 120)
    {
        RecoveredBattleMap map = Content.Maps.Single(candidate => candidate.Source.EndsWith("City_Multiplayer.unity"));
        CoverNode first = map.Covers.First(cover => cover.Main && cover.Fraction == 1);
        CoverNode second = map.Covers.First(cover => cover.Main && cover.Fraction == 2);
        WeaponManifest weapon = Content.Bazookas!.CreateManifest(source, 0);
        var manifest = new MatchManifest("bazooka-trace", "test-host", "City_Multiplayer", map.SourceHash,
            Content.BazookaRevision!, MatchManifest.BazookaCombatMode, 10, 600, idleSeconds,
            [new(First, weapon, 1, first.SourceIndex, 1, new(100_000), 0, PlayerLevel: 0),
                new(Second, weapon, 2, second.SourceIndex, 1, new(100_000), 0, PlayerLevel: 0)])
        {
            SceneMasterPlayerId = First
        };
        var trace = new MatchEngineTrace(scenario, manifest, content: Content);
        trace.AdmitBoth();
        trace.Ready(First);
        trace.Ready(Second);
        trace.Advance(60);
        return trace;
    }

    internal static Vector3 Target(MatchEngineTrace trace)
    {
        return trace.Engine.CombatPose(Second).Collision.Parts[1].Center;
    }

    internal static MatchReply Hold(MatchEngineTrace trace, string owner, ulong commandId, Vector3 target)
    {
        return trace.Command(owner, new MatchCommand
        {
            CommandId = commandId,
            BazookaHold = new() { Pressed = true, TargetX = target.X, TargetY = target.Y, TargetZ = target.Z }
        });
    }

    internal static ulong Launch(MatchEngineTrace trace)
    {
        if (Hold(trace, First, 2, Target(trace)).Code != "bazooka-targeting")
        {
            throw new InvalidOperationException("The source bazooka fixture did not begin targeting.");
        }
        return AdvanceToFirstShot(trace);
    }

    internal static ulong AdvanceToFirstShot(MatchEngineTrace trace)
    {
        ulong start = trace.Engine.Snapshot().ServerTick;
        for (ulong tick = start + 1; tick <= start + 100; tick++)
        {
            trace.Advance(tick);
            if (trace.Engine.Snapshot().Players[0].ShotsFired > 0)
            {
                return tick;
            }
        }
        throw new InvalidOperationException("The source hold never launched its first missile.");
    }

    internal static void AdvanceThrough(MatchEngineTrace trace, ulong tick)
    {
        for (ulong next = trace.Engine.Snapshot().ServerTick + 1; next <= tick; next++)
        {
            trace.Advance(next);
        }
    }

    private static BattleCombatContent LoadContent()
    {
        string directory = Path.Combine(BackendStartupPolicyTests.FindServerDirectory(), "content");
        return BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"),
            bazookaManifestPath: Path.Combine(directory, "bazooka-content-manifest.json"));
    }
}
