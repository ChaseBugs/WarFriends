using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Checks source entity priority, whole-list draws and real host registration/death cleanup.</summary>
internal static class AssaulterTargetTests
{
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(string directory)
    {
        int checks = CheckPriorities();
        checks += CheckFallbackOrdering();
        checks += CheckSourceBuckets();
        checks += CheckRejectedAuthority();
        checks += CheckShotTransformRules();
        checks += CheckHost(BattleArmyManifestProjectionTests.LoadContent(directory));
        return checks;
    }

    private static DroneTargetCandidate Unit(string identity, int? unitType)
    {
        return new DroneTargetCandidate(identity, 2, true, true, false, unitType, Vector3.Zero);
    }

    private static int CheckPriorities()
    {
        DroneTargetCandidate rusher = Unit("rusher", 3);
        DroneTargetCandidate firstDecoy = Unit("first-decoy", null) with { IsDecoy = true };
        DroneTargetCandidate secondDecoy = firstDecoy with { Id = "second-decoy" };
        int checks = Require(AssaulterTargetPolicy.Select(1, [rusher, firstDecoy, secondDecoy], count =>
        {
            Require(count == 2, "A Decoy draw included non-Decoy opponents.");
            return 1;
        }) == secondDecoy, "Assaulter did not choose a random source Decoy before Rushers.");

        DroneTargetCandidate farRusher = rusher with { Id = "far-rusher", Position = new Vector3(100f, 0f, 0f) };
        checks += Require(AssaulterTargetPolicy.Select(1, [Unit("defender", 0), farRusher, rusher], count =>
        {
            Require(count == 2, "The preferred Rusher draw included another unit family.");
            return 0;
        }) == farRusher, "Assaulter sorted preferred opponents by distance instead of source order.");
        checks += Require(AssaulterTargetPolicy.Select(1, [firstDecoy with { Alive = false },
            secondDecoy with { Visible = false }, rusher], _ => 0) == rusher,
            "Dead or invisible Decoys prevented a valid Rusher choice.");
        return checks;
    }

    private static int CheckFallbackOrdering()
    {
        DroneTargetCandidate defender = Unit("defender", 0);
        DroneTargetCandidate shooter = Unit("shooter", 2);
        DroneTargetCandidate explosive = Unit("explosive", 1);
        DroneTargetCandidate[] expected = [explosive, shooter, defender];
        int checks = 0;
        for (int index = 0; index < expected.Length; index++)
        {
            DroneTargetCandidate? selected = AssaulterTargetPolicy.Select(1, [defender, shooter, explosive], count =>
            {
                Require(count == expected.Length, "Fallback selected only the first nonempty unit group.");
                return index;
            });
            checks += Require(selected == expected[index], "The fallback lost source anyUnit group ordering.");
        }

        checks += Require(AssaulterTargetPolicy.Select(1, [Unit("player", null),
            explosive with { Fraction = 1 }, defender with { Alive = false }],
            _ => throw new InvalidOperationException("Empty source unit fallback consumed a random draw.")) == null,
            "Players, friendly units or dead units incorrectly blocked source player fallback.");
        return checks;
    }

    private static int CheckSourceBuckets()
    {
        var registry = new DroneTargetRegistry();
        registry.Enable("EnemyController", Unit("first", 3));
        registry.Enable("OtherSourceType", Unit("other", 3));
        registry.Enable("EnemyController", Unit("second-in-first-bucket", 3));
        return Require(AssaulterTargetPolicy.Select(1, registry.Snapshot(), _ => 1)?.Id ==
            "second-in-first-bucket", "Assaulter flattened source owner-type registration buckets.");
    }

    private static int CheckRejectedAuthority()
    {
        DroneTargetCandidate valid = Unit("unit", 3);
        int checks = Reject(() => AssaulterTargetPolicy.Select(1, [valid], _ => -1));
        checks += Reject(() => AssaulterTargetPolicy.Select(1, [valid], _ => 1));
        checks += Reject(() => AssaulterTargetPolicy.Select(1, [valid, valid], _ => 0));
        checks += Reject(() => AssaulterTargetPolicy.Select(1,
            [valid with { Position = new Vector3(float.NaN) }], _ => 0));
        checks += Reject(() => AssaulterTargetPolicy.Select(1, [valid with { UnitType = 4 }], _ => 0));
        return checks;
    }

    private static int CheckHost(BattleCombatContent content)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        MatchEngine host = GrenadierPrimaryDamageTests.CreateRealShotHost(content, map, _ => 0);
        int option = host.ArmyBatch(OpponentId).OptionIndexes.First();
        Require(host.Command(OpponentId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The opponent fixture failed normal Assaulter deployment.");
        host.Advance(61);
        ulong attacker = host.ArmyEntityBatch(OpponentId, 0, 0).Entities.Single().EntityKey;
        int checks = Require(host.SelectAssaulterOpponent(attacker).Kind == AssaulterOpponentKind.PlayerFallback,
            "A normal Assaulter without opposing units did not retain player fallback.");
        checks += CheckPlayerTransform(host, attacker, map);
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, UseUnitCard = new() { RequestId = new string('e', 32), SourceCardId = "GREATGRENADIER" }
        }).Code == "unit-card-activated", "The opponent fixture failed its real card-unit command.");
        BattleArmyEntityState grenadier = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(row =>
            row.SourceCardId == "GREATGRENADIER");
        checks += Require(host.SelectAssaulterOpponent(attacker).Candidate?.Id == ArmyId(grenadier.EntityKey),
            "An actually spawned card soldier was missing from Assaulter source opponents.");
        checks += CheckInfantryTransform(host, attacker, grenadier.EntityKey);
        checks += CheckHostDeathCleanup(host, attacker, grenadier.EntityKey);
        return checks;
    }

    private static int CheckHostDeathCleanup(MatchEngine host, ulong attacker, ulong grenadier)
    {
        int option = host.ArmyBatch(OwnerId).OptionIndexes.First();
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 4, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The fallback fixture failed its normal opposing deployment.");
        host.Advance(62);
        int checks = Require(host.SelectAssaulterOpponent(attacker).Candidate?.Id == ArmyId(grenadier),
            "Source explosive-before-defender fallback ordering changed in the actual host.");
        checks += CheckInfantryTransform(host, attacker, grenadier);
        checks += Require(host.ConfirmArmyDeath(grenadier, false) &&
            host.DroneTargetSnapshot().All(candidate => candidate.Id != ArmyId(grenadier)),
            "Host card-unit death left a stale source target registration.");
        var normal = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(row => row.OwnerPlayerId == OwnerId);
        checks += Require(host.SelectAssaulterOpponent(attacker).Candidate?.Id == ArmyId(normal.EntityKey),
            "Removing the card target did not reveal the remaining normal source opponent.");
        checks += Require(host.ConfirmArmyDeath(normal.EntityKey, false) &&
            host.SelectAssaulterOpponent(attacker).Kind == AssaulterOpponentKind.PlayerFallback,
            "Removing all spawned opponents did not restore source player fallback.");
        return checks;
    }

    private static int CheckShotTransformRules()
    {
        DroneShotTarget[] targets =
        [
            new(454546, 8, new Vector3(0f, 1f, 0f)),
            new(436299, 1, Vector3.Zero),
            new(496281, 4, Vector3.UnitZ)
        ];
        int checks = Require(AssaulterTargetPolicy.SelectShotTarget(targets,
            AssaulterTargetPolicy.AllInMask, count =>
            {
                Require(count == 2, "AllIn included the source Out target.");
                return 1;
            }) == targets[1], "Unit shot-target selection used nearest geometry instead of its random source index.");
        checks += Require(AssaulterTargetPolicy.SelectShotTarget(targets,
            AssaulterTargetPolicy.AllMask, _ => 2) == targets[2], "All incorrectly removed the source Out target.");
        checks += Reject(() => AssaulterTargetPolicy.SelectShotTarget(targets,
            AssaulterTargetPolicy.AllInMask, _ => 2));
        checks += Reject(() => AssaulterTargetPolicy.SelectShotTarget([targets[0], targets[0]],
            AssaulterTargetPolicy.AllInMask, _ => 0));
        return checks;
    }

    private static int CheckPlayerTransform(MatchEngine host, ulong attacker, RecoveredBattleMap map)
    {
        AssaulterShotTarget target = host.SelectAssaulterShotTarget(attacker) ??
            throw new InvalidOperationException("The source player fallback produced no current transform.");
        int cover = host.Snapshot().Players.Single(player => player.PlayerId == OwnerId).CoverIndex;
        int checks = Require(target.IsPlayer && target.OwnerPlayerId == OwnerId && target.ShotTargetType == 2,
            "The fixed player fallback lost its source Shield target branch.");
        checks += Require(Vector3.Distance(target.TransformPosition, map.Covers[cover].ShotPosition) < 0.0001f,
            "The Shield target used a serialized player-child reference instead of the current cover shot position.");
        return checks;
    }

    private static int CheckInfantryTransform(MatchEngine host, ulong attacker, ulong targetEntity)
    {
        AssaulterShotTarget target = host.SelectAssaulterShotTarget(attacker) ??
            throw new InvalidOperationException("A selected infantry opponent produced no current source transform.");
        DroneShotTarget head = host.InfantryShotTargets(targetEntity)?.Single(row => row.Type == 8) ??
            throw new InvalidOperationException("The current source infantry Head target disappeared.");
        int checks = Require(!target.IsPlayer && target.EntityId == ArmyId(targetEntity) &&
            target.TransformFileId == head.TransformFileId && target.ShotTargetType == head.Type,
            "The selected infantry transform lost its owning entity or serialized target identity.");
        checks += Require(target.TransformPosition == head.Position,
            "The selected infantry target used a stale/reference transform instead of its current sampled pose.");
        return checks;
    }

    private static string ArmyId(ulong entityKey)
    {
        return "army:" + entityKey.ToString(System.Globalization.CultureInfo.InvariantCulture);
    }

    private static int Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return 1;
        }

        throw new InvalidOperationException("Invalid Assaulter target authority was accepted.");
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
