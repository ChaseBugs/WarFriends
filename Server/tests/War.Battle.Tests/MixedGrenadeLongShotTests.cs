using System.Numerics;
using War.BattleServer;
using War.Protocol;

/// <summary>Checks a real delayed rifle kill after its owner selects the recovered FRAG slot.</summary>
internal static class MixedGrenadeLongShotTests
{
    private const string TargetUnit = "ID_UNIT-SHOTGUNNER";
    private const int GrenadeSlot = 2;
    private const int RifleSlot = 0;
    private const ulong StartTick = 60;
    private const ulong MaximumTick = 1500;
    private const ulong FlightWaitTicks = 90;
    private const float TargetHealthFactor = 0.01f;

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        Scenario[] scenarios =
        [
            new("Park_Multiplayer", 1, 0.1f, 1),
            new("City_Multiplayer", 0, 1f, 0)
        ];
        return scenarios.Sum(scenario => CheckScenario(content, directory, scenario));
    }

    private static int CheckScenario(BattleCombatContent content, string directory, Scenario scenario)
    {
        Fixture fixture = CreateFixture(content, directory, scenario);
        ulong tick = StartTick;
        BattleArmyEntityState victim = DeployTarget(fixture, content, ref tick);
        Require(victim.Health == victim.MaxHealth, "The LongShot target did not start at full host health.");
        ulong nextCommand = FireUntilLethal(fixture, victim.EntityKey, ref tick);
        var score = fixture.Host.BonusProgress.ScoreSnapshot(fixture.Shooter);
        Require(score.Counts[PvpArmyKillSkillShotPolicy.Kill] == 1 &&
            score.Counts[PvpArmyKillSkillShotPolicy.OneHitKill] == 1 &&
            score.Counts[PvpArmyKillSkillShotPolicy.LongShot] == scenario.ExpectedLongShotCount,
            $"Delayed kill flags at tick {tick}: Kill={score.Counts[PvpArmyKillSkillShotPolicy.Kill]}, " +
            $"OneHit={score.Counts[PvpArmyKillSkillShotPolicy.OneHitKill]}, " +
            $"LongShot={score.Counts[PvpArmyKillSkillShotPolicy.LongShot]}.");
        Require(fixture.Host.Snapshot().Players.Single(player => player.PlayerId == fixture.Shooter)
            .ActiveWeaponSlot == GrenadeSlot, "The lethal rifle contact did not occur during grenade selection.");
        Require(fixture.Host.Snapshot().Players.Single(player => player.PlayerId == fixture.Shooter)
            .ConfirmedEnemyHits == 1, "The lethal delayed contact did not credit exactly one enemy hit.");
        CheckTerminalEvidence(fixture, nextCommand, scenario.ExpectedLongShotCount);
        Console.WriteLine($"Delayed rifle kill: map={scenario.MapId} tick={tick} " +
            $"LongShot={scenario.ExpectedLongShotCount} target={victim.EntityKey}");
        return 8;
    }

    private static Fixture CreateFixture(BattleCombatContent content, string directory, Scenario scenario)
    {
        MatchManifest starter = MixedGrenadeActorTests.CreateStarterManifest(content, directory);
        string shooter = starter.Players[scenario.ShooterIndex].PlayerId;
        string defender = starter.Players[1 - scenario.ShooterIndex].PlayerId;
        var map = content.Maps.Single(candidate =>
            Path.GetFileNameWithoutExtension(candidate.Source) == scenario.MapId);
        // Small trusted health factors make a full-health source unit a one-hit target; no damage helper is used.
        MatchManifest manifest = starter with
        {
            MatchId = "mixed-grenade-delayed-longshot",
            MapId = scenario.MapId,
            MapRevision = map.SourceHash,
            DurationSeconds = 180,
            SceneMasterPlayerId = defender,
            Players = starter.Players.Select(player => player with
            {
                EquippedArmyUnitIds = [TargetUnit],
                NewArmyUnitIds = null,
                ArmyNormalUpgradeIndexes = [0],
                ArmySpecialUpgradeIndexes = [-1],
                ArmyEliteUpgradeIndexes = [-1],
                ArmyHealthFactors = [new ArmyHealthFactors(TargetHealthFactor, TargetHealthFactor)],
                ArmyDamageScales = [1],
                // The long-range case keeps the target distant during flight; the short case uses ordinary speed.
                ArmySpeedCoefficients = [scenario.SpeedFactor],
                ArmyAccuracyCoefficients = [1],
                ArmyShotSpeedCoefficients = [1],
                ShieldLevel = 0,
                PlayerLevel = 8,
                StartCover = map.Covers.First(cover => cover.Main && cover.Fraction == player.Fraction).SourceIndex
            }).ToArray()
        };
        content.ValidateAllocation(manifest);
        var host = new MatchEngine(manifest, map, content, armyChoice: _ => 0);
        foreach (ParticipantManifest player in manifest.Players)
        {
            Require(host.Admit(player.PlayerId), "LongShot fixture admission failed.");
            Require(host.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 1, Ready = new ReadyCommand { ManifestHash = host.ManifestHash }
            }).Code == "ready", "LongShot fixture readiness failed.");
        }

        host.Advance(StartTick);
        return new Fixture(host, shooter, defender);
    }

    private static BattleArmyEntityState DeployTarget(Fixture fixture, BattleCombatContent content, ref ulong tick)
    {
        int option = fixture.Host.ArmyBatch(fixture.Defender).OptionIndexes
            .OrderBy(index => content.Army.Option(index).Count).First();
        Require(fixture.Host.Command(fixture.Defender, new MatchCommand
        {
            CommandId = 2, DeployArmy = new DeployArmyCommand { OptionIndex = option }
        }).Code == "army-deploying", "The LongShot target did not enter source deployment.");
        while (tick < StartTick + MatchManifest.TickRate)
        {
            fixture.Host.Advance(++tick);
            BattleArmyEntityState? victim = fixture.Host.ArmyEntityBatch(fixture.Defender, 0, 0)
                .Entities.SingleOrDefault();
            if (victim != null)
            {
                return victim;
            }
        }

        throw new InvalidOperationException("The source infantry target never spawned.");
    }

    private static ulong FireUntilLethal(Fixture fixture, ulong target, ref ulong tick)
    {
        ulong command = 2;
        while (tick < MaximumTick && fixture.Host.ArmyHealth(target) != null && !fixture.Host.Terminal)
        {
            Vector3 aim = fixture.Host.GroundVehicleShotTargets(fixture.Shooter)
                .Single(row => row.EntityId == target && row.Hitbox.SourcePath == EnemyPoseCatalog.ArmyHeadSourcePath)
                .Hitbox.Center;
            ulong before = fixture.Host.Snapshot().Players
                .Single(player => player.PlayerId == fixture.Shooter).ShotsFired;
            Require(fixture.Host.Command(fixture.Shooter, new MatchCommand
            {
                CommandId = command++, Fire = new FireCommand { TargetX = aim.X, TargetY = aim.Y, TargetZ = aim.Z }
            }).Code == "shot-scheduled", "The delayed rifle fixture could not schedule its next source shot.");
            while (tick < MaximumTick && !fixture.Host.Terminal && fixture.Host.ArmyHealth(target) != null &&
                fixture.Host.Snapshot().Players
                    .Single(player => player.PlayerId == fixture.Shooter).ShotsFired == before)
            {
                fixture.Host.Advance(++tick);
            }

            Require(fixture.Host.ArmyHealth(target) != null, "The target died before grenade selection.");
            SelectSlot(fixture, GrenadeSlot, command++);
            ulong until = tick + FlightWaitTicks;
            while (tick < until && fixture.Host.ArmyHealth(target) != null && !fixture.Host.Terminal)
            {
                fixture.Host.Advance(++tick);
            }

            if (fixture.Host.ArmyHealth(target) != null)
            {
                SelectSlot(fixture, RifleSlot, command++);
            }
        }

        Require(!fixture.Host.Terminal && fixture.Host.ArmyHealth(target) == null,
            "Normal rifle flight did not kill the deployed infantry during grenade selection.");
        return command;
    }

    private static void CheckTerminalEvidence(Fixture fixture, ulong command, int expectedLongShotCount)
    {
        fixture.Host.Command(fixture.Shooter, new MatchCommand
        {
            CommandId = command, Forfeit = new ForfeitCommand()
        });
        Require(fixture.Host.Terminal, "The delayed kill fixture did not publish terminal evidence.");
        var evidence = fixture.Host.TerminalEvidenceSnapshot().Players
            .Single(player => player.PlayerId == fixture.Shooter);
        long longShots = evidence.ConfirmedSkillShotCounts
            .Where(row => row.Flag == PvpArmyKillSkillShotPolicy.LongShot).Sum(row => row.Count);
        Require(longShots == expectedLongShotCount,
            "Private terminal evidence changed the confirmed delayed LongShot count.");
        Require(fixture.Host.Snapshot().Players.Single(player => player.PlayerId == fixture.Shooter)
            .ConfirmedSkillShotCounts.Count == 0, "Public snapshot exposed private settlement counters.");
    }

    private static void SelectSlot(Fixture fixture, int slot, ulong command)
    {
        Require(fixture.Host.Command(fixture.Shooter, new MatchCommand
        {
            CommandId = command, SwitchWeapon = new SwitchWeaponCommand { Slot = slot }
        }).Code == "weapon-selected", "The LongShot fixture could not select its source weapon slot.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private sealed record Fixture(MatchEngine Host, string Shooter, string Defender);

    private sealed record Scenario(string MapId, int ShooterIndex, float SpeedFactor, int ExpectedLongShotCount);
}
