using Google.Protobuf;
using War.BattleServer;
using War.Shared;
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
            MatchEngine host = CreateHost(content, map, selection);
            int option = host.ArmyBatch(OwnerId).OptionIndexes.First();
            Require(host.Command(OwnerId, new MatchCommand
            {
                CommandId = 3, DeployArmy = new() { OptionIndex = option }
            }).Code == "army-deploying", "Ordinary Grenadier deployment was not accepted.");
            host.Advance(FirstSpawnTick);
            Require(!host.Terminal,
                "Ordinary Grenadier initialization terminated the match: " + host.Snapshot().TerminalReason);
            BattleArmyEntityState entity = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single();
            var expected = content.Army.ComposeOrdinaryGrenadier(selection.Normal,
                selection.Special >= 0 ? selection.Special : null,
                selection.Elite >= 0 ? selection.Elite : null, DamageScale);
            checks += Require(entity.SourceCardId.Length == 0 && entity.UnitId == "ID_UNIT-GRENADIER",
                "Ordinary spawning must not fabricate a card identity.");
            checks += Require(host.CardGrenadierDamage(entity.EntityKey) == expected.Damage &&
                host.CardGrenadierThrow(entity.EntityKey)?.FuseSeconds == expected.FuseSeconds,
                "Spawned grenade authority lost the admitted owner's upgrade tuple or scale.");
            checks += CheckMovementAndLaunch(host, entity);
            checks += Require(host.ConfirmArmyDeath(entity.EntityKey, false) &&
                host.CardGrenadierDamage(entity.EntityKey) == null &&
                host.CardGrenadierThrow(entity.EntityKey) == null &&
                host.GrenadierPoint(entity.EntityKey) == null && !host.CardGrenadierWalking(entity.EntityKey),
                "Ordinary actor removal retained grenade authority.");
        }

        checks += CheckMissingPoint(content);
        return checks;
    }

    private static int CheckMovementAndLaunch(MatchEngine host, BattleArmyEntityState spawned)
    {
        const ulong maximumShotTick = 1800;
        CardUnitInitialPoint point = host.GrenadierPoint(spawned.EntityKey) ??
            throw new InvalidOperationException("Ordinary Grenadier did not reserve its source point.");
        int checks = Require(point.Fraction == spawned.OwnerFraction && point.ComponentType == "EnemyPointCorner" &&
            host.CardGrenadierWalking(spawned.EntityKey), "Ordinary Grenadier lost its source Corner route.");
        while (!host.Terminal && host.Snapshot().ServerTick < maximumShotTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            if (!host.CardGrenadierShotIntents().Any(intent =>
                intent.EntityKey == spawned.EntityKey && intent.Aim.ThrowGrenade))
            {
                continue;
            }

            BattleArmyEntityState current = host.ArmyEntityBatch(OwnerId, 0, 0).Entities
                .Single(entity => entity.EntityKey == spawned.EntityKey);
            checks += Require(!host.CardGrenadierWalking(spawned.EntityKey) &&
                (current.X != spawned.X || current.Z != spawned.Z),
                "Ordinary Grenadier must move to its Corner before launching.");
            checks += Require(host.CardGrenadierActiveFlightCount > 0,
                "An ordinary secondary shot did not create a real host grenade flight: " +
                host.Snapshot().TerminalReason);
            BattleArmyEntityState decoded = BattleArmyEntityState.Parser.ParseFrom(current.ToByteArray());
            checks += Require(decoded.InfantryWeaponMask == 2 && InfantryWeaponVisibility.IsValid(decoded),
                "Ordinary secondary selection did not survive host/protobuf/SDK projection.");
            ulong launchTick = host.Snapshot().ServerTick;
            const ulong returnDelayTicks = 15;
            while (host.Snapshot().ServerTick < launchTick + returnDelayTicks)
            {
                host.Advance(host.Snapshot().ServerTick + 1);
            }

            BattleArmyEntityState returned = host.ArmyEntityBatch(OwnerId, 0, 0).Entities
                .Single(entity => entity.EntityKey == spawned.EntityKey);
            checks += Require(returned.InfantryWeaponMask == 1,
                "Ordinary Grenadier did not project primary after its source callback.");
            Console.WriteLine($"Ordinary Grenadier launch {launchTick}, " +
                $"primary return {launchTick + returnDelayTicks}.");
            return checks;
        }

        throw new InvalidOperationException("Ordinary Grenadier did not launch: " + host.Snapshot().TerminalReason);
    }

    private static MatchEngine CreateHost(BattleCombatContent content, RecoveredBattleMap map,
        (int Normal, int Special, int Elite) selection)
    {
        ParticipantManifest owner = Participant(content, map, 1) with
        {
            EquippedArmyUnitIds = ["ID_UNIT-GRENADIER"],
            ArmyNormalUpgradeIndexes = [selection.Normal],
            ArmySpecialUpgradeIndexes = [selection.Special], ArmyEliteUpgradeIndexes = [selection.Elite],
            ArmyDamageScales = [DamageScale]
        };
        var manifest = new MatchManifest("ordinary-grenadier-spawn", "source-test",
            Path.GetFileNameWithoutExtension(map.Source),
            map.SourceHash, content.Revision, MatchManifest.RifleCombatMode, 10, 120, 120,
            [owner, Participant(content, map, 2)]) { SceneMasterPlayerId = OwnerId };
        var host = new MatchEngine(manifest, map, content, armyChoice: _ => 0, combatRandom: () => 1f);
        Admit(host, selection);
        return host;
    }

    private static int CheckMissingPoint(BattleCombatContent content)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Snow_Multiplayer.unity", StringComparison.Ordinal));
        MatchEngine host = CreateHost(content, map, (0, -1, -1));
        int option = host.ArmyBatch(OwnerId).OptionIndexes.First();
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "Missing-point deployment failed.");
        host.Advance(FirstSpawnTick);
        BattleArmyEntityState actor = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single();
        int checks = Require(host.GrenadierPoint(actor.EntityKey) == null &&
            !host.CardGrenadierWalking(actor.EntityKey), "Missing points must not create a fabricated route.");
        const ulong retryObservationTick = FirstSpawnTick + 301;
        while (!host.Terminal && host.Snapshot().ServerTick < retryObservationTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        checks += Require(!host.Terminal && host.GrenadierPoint(actor.EntityKey) == null &&
            host.CardGrenadierAttack(actor.EntityKey) == null, "Source point retries must remain callback-safe.");
        checks += Require(host.ConfirmArmyDeath(actor.EntityKey, false), "Waiting Grenadier removal failed.");
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
