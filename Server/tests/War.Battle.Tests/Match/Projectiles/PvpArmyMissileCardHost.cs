using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Projectiles;

internal static class PvpArmyMissileCardHost
{
    internal const string Card = "BIGROCKET";
    private const int PlayerLevel = 22;
    private const int PlayerHealth = 1000;
    private const ulong StartTick = 60;

    internal static MatchEngine Create(BattleCombatContent content)
    {
        RecoveredBattleMap map = content.Maps.Single(row => row.Source.EndsWith("/Park_Multiplayer.unity"));
        ParticipantManifest first = Participant(content, map, 1);
        ParticipantManifest second = Participant(content, map, 2);
        var manifest = new MatchManifest("army-missile-card-trace", "native-test", "Park_Multiplayer",
            map.SourceHash, content.Revision, MatchManifest.RifleCombatMode, 10, 180, 120, [first, second])
        {
            SceneMasterPlayerId = PvpArmyMissileTraceFixture.First
        };
        var engine = new MatchEngine(manifest, map, content, armyChoice: _ => 0, combatRandom: () => 1f);
        engine.ConfigureBattleAllocations([
            new(first.PlayerId, [Card], [], [0], [-1], [-1]) { CardCounts = [1] },
            new(second.PlayerId, [], [], [0], [-1], [-1])
        ]);
        foreach (ParticipantManifest player in manifest.Players)
        {
            engine.Admit(player.PlayerId);
            SelectAndReady(engine, player.PlayerId);
        }
        engine.Advance(StartTick);
        return engine;
    }

    private static ParticipantManifest Participant(BattleCombatContent content, RecoveredBattleMap map, int fraction)
    {
        string player = fraction == 1 ? PvpArmyMissileTraceFixture.First : PvpArmyMissileTraceFixture.Second;
        int cover = map.Covers.First(row => row.Main && row.Fraction == fraction).SourceIndex;
        return new ParticipantManifest(player, content.Stats.CreateManifest("Google2u.AssaultRifle_AK47", 0),
            fraction, cover, 1f, new PlayerCombatManifest(PlayerHealth), 0, 0, PlayerLevel)
        {
            EquippedArmyUnitIds = ["ID_UNIT-ASSAULT"],
            ArmyNormalUpgradeIndexes = [0], ArmySpecialUpgradeIndexes = [-1], ArmyEliteUpgradeIndexes = [-1],
            ArmyHealthFactors = [new ArmyHealthFactors(1f, 1f)], ArmyDamageScales = [1f],
            ArmySpeedCoefficients = [1f], ArmyAccuracyCoefficients = [1f]
        };
    }

    private static void SelectAndReady(MatchEngine engine, string player)
    {
        var cards = new SelectCardsCommand();
        if (player == PvpArmyMissileTraceFixture.First)
        {
            cards.CardIds.Add(Card);
        }
        cards.NormalUpgradeIndexes.Add(0);
        cards.SpecialUpgradeIndexes.Add(-1);
        cards.EliteUpgradeIndexes.Add(-1);
        PvpArmyMissileTraceFixture.Require(engine.Command(player, new()
        {
            CommandId = 1, SelectCards = cards
        }).Code == "cards-selected", "The missile card fixture failed selection.");
        PvpArmyMissileTraceFixture.Require(engine.Command(player, new()
        {
            CommandId = 2, Ready = new() { ManifestHash = engine.ManifestHash }
        }).Code == "ready", "The missile card fixture failed readiness.");
    }
}
