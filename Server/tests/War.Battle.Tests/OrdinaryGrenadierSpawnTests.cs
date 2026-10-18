using War.BattleServer;
using War.Protocol;

/// <summary>Exercises ordinary deployments without card entities or injected spawn callbacks.</summary>
internal static class OrdinaryGrenadierSpawnTests
{
    private const ulong FirstSpawnTick = 61;
    private const int PlayerLevel = 22;
    private const float DamageScale = 1.5f;
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(BattleCombatContent content)
    {
        int checks = 0;
        foreach (var selection in new (int Normal, int Special, int Elite)[]
        {
            (0, -1, -1), (39, 101, -1), (39, 126, 127)
        })
        {
            RecoveredBattleMap map = content.Maps.Single(candidate =>
                candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
            ParticipantManifest owner = Participant(content, map, 1) with
            {
                EquippedArmyUnitIds = ["ID_UNIT-GRENADIER"],
                ArmyNormalUpgradeIndexes = [selection.Normal],
                ArmySpecialUpgradeIndexes = [selection.Special], ArmyEliteUpgradeIndexes = [selection.Elite],
                ArmyDamageScales = [DamageScale]
            };
            var manifest = new MatchManifest("ordinary-grenadier-spawn", "source-test", "Park_Multiplayer",
                map.SourceHash, content.Revision, MatchManifest.RifleCombatMode, 10, 120, 120,
                [owner, Participant(content, map, 2)]) { SceneMasterPlayerId = OwnerId };
            var host = new MatchEngine(manifest, map, content, armyChoice: _ => 0, combatRandom: () => 1f);
            Admit(host, selection);
            int option = host.ArmyBatch(OwnerId).OptionIndexes.First();
            Require(host.Command(OwnerId, new MatchCommand
            {
                CommandId = 3, DeployArmy = new() { OptionIndex = option }
            }).Code == "army-deploying", "Ordinary Grenadier deployment was not accepted.");
            host.Advance(FirstSpawnTick);
            Require(!host.Terminal, "Ordinary Grenadier initialization terminated the match: " + host.Snapshot().TerminalReason);
            BattleArmyEntityState entity = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single();
            var expected = content.Army.ComposeOrdinaryGrenadier(selection.Normal,
                selection.Special >= 0 ? selection.Special : null,
                selection.Elite >= 0 ? selection.Elite : null, DamageScale);
            checks += Require(entity.SourceCardId.Length == 0 && entity.UnitId == "ID_UNIT-GRENADIER",
                "Ordinary spawning must not fabricate a card identity.");
            checks += Require(host.CardGrenadierDamage(entity.EntityKey) == expected.Damage &&
                host.CardGrenadierThrow(entity.EntityKey)?.FuseSeconds == expected.FuseSeconds,
                "Spawned grenade authority lost the admitted owner's upgrade tuple or scale.");
            checks += Require(host.ConfirmArmyDeath(entity.EntityKey, false) &&
                host.CardGrenadierDamage(entity.EntityKey) == null && host.CardGrenadierThrow(entity.EntityKey) == null,
                "Ordinary actor removal retained grenade authority.");
        }

        return checks;
    }

    private static ParticipantManifest Participant(BattleCombatContent content, RecoveredBattleMap map, int fraction)
    {
        var weapon = content.Stats.CreateManifest("Google2u.AssaultRifle_AK47", 0);
        CoverNode cover = map.Covers.First(candidate => candidate.Main && candidate.Fraction == fraction);
        return new ParticipantManifest(fraction == 1 ? OwnerId : OpponentId, weapon, fraction,
            cover.SourceIndex, 1f, new PlayerCombatManifest(10_000), 0, 0, PlayerLevel)
        {
            EquippedArmyUnitIds = ["ID_UNIT-ASSAULT"], ArmyNormalUpgradeIndexes = [0],
            ArmySpecialUpgradeIndexes = [-1], ArmyEliteUpgradeIndexes = [-1],
            ArmyHealthFactors = [new ArmyHealthFactors(1f, 1f)], ArmyDamageScales = [1f],
            ArmySpeedCoefficients = [1f], ArmyAccuracyCoefficients = [1f]
        };
    }

    private static void Admit(MatchEngine host, (int Normal, int Special, int Elite) selection)
    {
        host.ConfigureBattleAllocations([
            new(OwnerId, [], [], [selection.Normal], [selection.Special], [selection.Elite]),
            new(OpponentId, [], [], [0], [-1], [-1])
        ]);
        foreach (string player in new[] { OwnerId, OpponentId })
        {
            host.Admit(player);
            var cards = new SelectCardsCommand();
            cards.NormalUpgradeIndexes.Add(player == OwnerId ? selection.Normal : 0);
            cards.SpecialUpgradeIndexes.Add(player == OwnerId ? selection.Special : -1);
            cards.EliteUpgradeIndexes.Add(player == OwnerId ? selection.Elite : -1);
            Require(host.Command(player, new() { CommandId = 1, SelectCards = cards }).Code == "cards-selected",
                "Ordinary deployment selection failed.");
            Require(host.Command(player, new()
            {
                CommandId = 2, Ready = new() { ManifestHash = host.ManifestHash }
            }).Code == "ready", "Ordinary deployment readiness failed.");
        }

        host.Advance(FirstSpawnTick - 1);
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }
}
