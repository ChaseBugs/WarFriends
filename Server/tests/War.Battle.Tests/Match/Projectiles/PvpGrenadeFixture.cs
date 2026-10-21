using System.Numerics;
using War.Battle.Tests.Match.Tracing;
using War.Battle.Tests.Startup;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpGrenadeFixture
{
    internal const string First = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    internal const string Second = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    internal const string Frag = "Google2u.Grenade_FRAG";
    internal const string Launcher = "Google2u.GrenadeLauncher_M320";
    internal const string Molotov = "Google2u.Grenade_Molotov";
    internal const string RequestId = "11111111111111111111111111111111";

    private static readonly Lazy<BattleCombatContent> _content = new(LoadContent);

    internal static BattleCombatContent Content => _content.Value;

    internal static MatchEngineTrace Ordinary(string scenario, string source = Frag)
    {
        return Started(scenario, CreateManifest(source, MatchManifest.GrenadeCombatMode, 120));
    }

    internal static MatchEngineTrace Burst(string scenario, int idleSeconds = 120)
    {
        MatchManifest manifest = CreateManifest(
            "Google2u.AssaultRifle_AK47", MatchManifest.RifleCombatMode, idleSeconds);
        var trace = new MatchEngineTrace(scenario, manifest, content: Content);
        trace.Engine.ConfigureCardSelection(["CLUSTERGRENADE"]);
        trace.Engine.ConfigureCardInventory([(First, "CLUSTERGRENADE", 1)]);
        trace.AdmitBoth();
        var selection = new SelectCardsCommand();
        selection.CardIds.Add("CLUSTERGRENADE");
        Require(trace.Command(First, new MatchCommand { CommandId = 1, SelectCards = selection }).Code ==
            "cards-selected", "The source burst fixture did not select its allocated card.");
        trace.Command(First, new MatchCommand { CommandId = 2,
            Ready = new() { ManifestHash = trace.Engine.ManifestHash } });
        trace.Ready(Second);
        trace.Advance(60);
        return trace;
    }

    internal static MatchCommand Throw(MatchEngineTrace trace, string source)
    {
        BattlePlayerState player = trace.Engine.Snapshot().Players[0];
        BattlePlayerState opponent = trace.Engine.Snapshot().Players[1];
        Vector3 start = new(player.PositionX, player.PositionY, player.PositionZ);
        Vector3 target = new(opponent.PositionX, opponent.PositionY, opponent.PositionZ);
        GrenadeBinding binding = Content.Grenades!.Binding(source);
        var gesture = new GrenadeThrowCommand();
        if (binding.Swipe)
        {
            Vector3 planar = target - start;
            planar.Y = 0;
            Vector3 end = start + Vector3.Normalize(planar) * 7;
            gesture.Swipe = true;
            gesture.SwipeStartX = start.X;
            gesture.SwipeStartY = start.Y;
            gesture.SwipeStartZ = start.Z;
            gesture.SwipeEndX = end.X;
            gesture.SwipeEndY = end.Y;
            gesture.SwipeEndZ = end.Z;
            gesture.HeldSeconds = 0.05f;
        }
        else
        {
            gesture.TargetX = target.X;
            gesture.TargetY = target.Y;
            gesture.TargetZ = target.Z;
        }
        return new MatchCommand { CommandId = 2, GrenadeThrow = gesture };
    }

    internal static MatchCommand UseBurst()
    {
        return new MatchCommand { CommandId = 3, UseGrenadesBurst = new() { RequestId = RequestId } };
    }

    internal static void AdvanceThrough(MatchEngineTrace trace, ulong tick)
    {
        for (ulong next = trace.Engine.Snapshot().ServerTick + 1; next <= tick; next++)
        {
            trace.Advance(next);
        }
    }

    private static MatchEngineTrace Started(string scenario, MatchManifest manifest)
    {
        var trace = new MatchEngineTrace(scenario, manifest, content: Content);
        trace.AdmitBoth();
        trace.Ready(First);
        trace.Ready(Second);
        trace.Advance(60);
        return trace;
    }

    private static MatchManifest CreateManifest(string source, string mode, int idleSeconds)
    {
        RecoveredBattleMap map = Content.Maps.Single(candidate => candidate.Source.EndsWith("City_Multiplayer.unity"));
        CoverNode first = map.Covers.First(cover => cover.Main && cover.Fraction == 1);
        CoverNode second = map.Covers.First(cover => cover.Main && cover.Fraction == 2);
        WeaponManifest weapon = mode == MatchManifest.GrenadeCombatMode
            ? Content.Grenades!.CreateManifest(source, 0) : Content.Stats.CreateManifest(source, 0);
        string revision = mode == MatchManifest.GrenadeCombatMode ? Content.GrenadeRevision! : Content.Revision;
        return new MatchManifest("grenade-trace", "test-host", "City_Multiplayer", map.SourceHash, revision,
            mode, 10, 600, idleSeconds,
            [new(First, weapon, 1, first.SourceIndex, 1, new(100_000), 0, PlayerLevel: 22),
                new(Second, weapon, 2, second.SourceIndex, 1, new(100_000), 0, PlayerLevel: 22)])
        {
            SceneMasterPlayerId = First
        };
    }

    private static BattleCombatContent LoadContent()
    {
        string directory = Path.Combine(BackendStartupPolicyTests.FindServerDirectory(), "content");
        return BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"),
            grenadeManifestPath: Path.Combine(directory, "grenade-content-manifest.json"));
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
