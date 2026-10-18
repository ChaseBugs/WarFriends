using War.BattleServer;
using War.Protocol;
using War.Shared;

/// <summary>Creates trusted ordinary-unit fixtures with real readiness and selected owner upgrade lanes.</summary>
internal static class OrdinaryArmyTestHost
{
    private const ulong StartTick = 60;
    private const int PlayerLevel = 22;
    private const int PlayerHealth = 1000;
    private const int MatchDurationSeconds = 180;
    private const int IdleSeconds = 120;
    private const int AdmissionSeconds = 10;
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static MatchEngine Create(BattleCombatContent content, string unitId, string scene = "Park",
        Func<int, int>? armyChoice = null)
    {
        return CreateConfigured(content, new Setup(unitId, scene, armyChoice, new UpgradeSelection(0, -1, -1)));
    }

    internal static MatchEngine CreateUpgraded(BattleCombatContent content, string unitId, UpgradeSelection upgrades)
    {
        return CreateConfigured(content, new Setup(unitId, "Park", null, upgrades));
    }

    private static MatchEngine CreateConfigured(BattleCombatContent content, Setup setup)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith($"/{setup.Scene}_Multiplayer.unity", StringComparison.Ordinal));
        ParticipantManifest[] players =
        [
            Participant(content, map, (1, setup.UnitId), setup.Upgrades),
            Participant(content, map, (2, setup.UnitId), setup.Upgrades)
        ];
        var manifest = new MatchManifest("ordinary-army-test", "native-test", $"{setup.Scene}_Multiplayer",
            map.SourceHash, content.Revision, MatchManifest.RifleCombatMode, AdmissionSeconds,
            MatchDurationSeconds, IdleSeconds, players)
        {
            SceneMasterPlayerId = OwnerId
        };
        var host = new MatchEngine(manifest, map, content,
            armyChoice: setup.ArmyChoice ?? (_ => 0), combatRandom: () => 1f);
        host.ConfigureBattleAllocations(players.Select(player => new BattleAllocationProjection(player.PlayerId,
            [], [], [setup.Upgrades.Normal], [setup.Upgrades.Special], [setup.Upgrades.Elite])).ToArray());
        foreach (ParticipantManifest player in players)
        {
            host.Admit(player.PlayerId);
            var cards = new SelectCardsCommand();
            cards.NormalUpgradeIndexes.Add(setup.Upgrades.Normal);
            cards.SpecialUpgradeIndexes.Add(setup.Upgrades.Special);
            cards.EliteUpgradeIndexes.Add(setup.Upgrades.Elite);
            Require(host.Command(player.PlayerId, new() { CommandId = 1, SelectCards = cards }).Code ==
                "cards-selected",
                "The primary-weapon fixture could not select its trusted upgrade lanes.");
            Require(host.Command(player.PlayerId, new()
            {
                CommandId = 2, Ready = new() { ManifestHash = host.ManifestHash }
            }).Code == "ready", "The primary-weapon fixture failed readiness.");
        }

        host.Advance(StartTick);
        return host;
    }

    private static ParticipantManifest Participant(BattleCombatContent content, RecoveredBattleMap map,
        (int Fraction, string UnitId) source, UpgradeSelection upgrades)
    {
        return new ParticipantManifest(source.Fraction == 1 ? OwnerId : OpponentId,
            content.Stats.CreateManifest("Google2u.AssaultRifle_AK47", 0), source.Fraction,
            map.Covers.First(cover => cover.Main && cover.Fraction == source.Fraction).SourceIndex,
            1f, new PlayerCombatManifest(PlayerHealth), 0, 0, PlayerLevel)
        {
            EquippedArmyUnitIds = [source.UnitId], ArmyNormalUpgradeIndexes = [upgrades.Normal],
            ArmySpecialUpgradeIndexes = [upgrades.Special], ArmyEliteUpgradeIndexes = [upgrades.Elite],
            ArmyHealthFactors = [new ArmyHealthFactors(1f, 1f)], ArmyDamageScales = [upgrades.DamageScale],
            ArmySpeedCoefficients = [1f], ArmyAccuracyCoefficients = [1f]
        };
    }

    internal sealed record UpgradeSelection(int Normal, int Special, int Elite, float DamageScale = 1f);

    private sealed record Setup(string UnitId, string Scene, Func<int, int>? ArmyChoice, UpgradeSelection Upgrades);

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
