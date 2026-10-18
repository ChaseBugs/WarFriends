using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Checks normal host deployments against source Corner reservations and NavMesh destinations.</summary>
internal static class AssaulterNavigationTests
{
    private const ulong FirstSpawnTick = 61;
    private const ulong MaximumArrivalTick = 1800;
    private const float ArrivalTolerance = 0.06f;
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = CheckParkRoute(content);
        checks += CheckMissingSnowPoint(content);
        return checks;
    }

    private static MatchEngine CreateDeployment(BattleCombatContent content, string scene)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith($"/{scene}_Multiplayer.unity", StringComparison.Ordinal));
        MatchEngine host = GrenadierPrimaryDamageTests.CreateRealShotHost(content, map, _ => 0);
        int option = host.ArmyBatch(OpponentId).OptionIndexes.First();
        Require(host.Command(OpponentId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The navigation fixture failed its normal deployment command.");
        host.Advance(FirstSpawnTick);
        return host;
    }

    private static int CheckParkRoute(BattleCombatContent content)
    {
        MatchEngine host = CreateDeployment(content, "Park");
        BattleArmyEntityState first = host.ArmyEntityBatch(OpponentId, 0, 0).Entities.Single();
        CardUnitInitialPoint point = host.AssaulterPoint(first.EntityKey) ??
            throw new InvalidOperationException("A normal Assaulter did not reserve a source Corner.");
        Vector3 start = Position(first);
        int checks = Require(point.Fraction == first.OwnerFraction && point.ComponentType == "EnemyPointCorner",
            "Normal Assaulter reserved a wrong-fraction or wrong-type point.");
        checks += Require(first.PositionTick == FirstSpawnTick && first.InfantryClip == "run_0",
            "The accepted normal soldier did not publish its source walking base clip.");

        while (!host.Terminal && host.Snapshot().ServerTick < MaximumArrivalTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            var entities = host.ArmyEntityBatch(OpponentId, 0, 0).Entities;
            if (entities.Count == content.Army.Option(first.OptionIndex).Count &&
                entities.All(entity => entity.InfantryClip == "idle_1"))
            {
                checks += CheckArrival(host, entities, start);
                checks += CheckCornerEntry(host, entities, content);
                checks += Require(host.ConfirmArmyDeath(first.EntityKey, false),
                    "The host could not remove its completed Assaulter.");
                checks += Require(host.AssaulterPoint(first.EntityKey) == null,
                    "A removed Assaulter retained a shared destination reservation.");
                checks += Require(host.AssaulterCorner(first.EntityKey) == null,
                    "A removed Assaulter retained Corner entry state.");
                Console.WriteLine($"PASS: normal Assaulter Corner arrival at tick {host.Snapshot().ServerTick}.");
                return checks;
            }
        }

        throw new InvalidOperationException("Normal Assaulter route did not finish: " +
            $"{host.Snapshot().TerminalReason}.");
    }

    private static int CheckArrival(MatchEngine host, IEnumerable<BattleArmyEntityState> entities, Vector3 start)
    {
        var reserved = new HashSet<int>();
        int checks = 0;
        foreach (BattleArmyEntityState entity in entities)
        {
            CardUnitInitialPoint point = host.AssaulterPoint(entity.EntityKey) ??
                throw new InvalidOperationException("An arrived normal Assaulter lost its point.");
            checks += Require(reserved.Add(point.ComponentFileId), "Two soldiers occupied one shared Corner.");
            var actual = new Vector2(entity.X, entity.Z);
            var destination = new Vector2(point.Position.X, point.Position.Z);
            checks += Require(Vector2.Distance(actual, destination) < ArrivalTolerance,
                "An idle normal Assaulter did not reach its source NavMesh destination.");
            checks += Require(Vector3.Distance(Position(entity), start) > ArrivalTolerance,
                "A normal Assaulter stayed at its initial spawn instead of navigating.");
        }

        return checks;
    }

    private static int CheckCornerEntry(MatchEngine host, IEnumerable<BattleArmyEntityState> entities,
        BattleCombatContent content)
    {
        BattleArmyEntityState entity = entities.MaxBy(row => host.AssaulterCorner(row.EntityKey)?.Entry.StartTick) ??
            throw new InvalidOperationException("No actual normal Assaulter reached its Corner.");
        AssaulterCornerState state = host.AssaulterCorner(entity.EntityKey) ??
            throw new InvalidOperationException("An arrived normal Assaulter lost its Corner clocks.");
        CardUnitInitialPoint point = host.AssaulterPoint(entity.EntityKey) ??
            throw new InvalidOperationException("The Corner clock lost its shared source point.");
        ArmyBaseShotStats shot = content.Army.ComposeShot("ID_UNIT-ASSAULT", 0, null, null, 1f);
        ulong expectedShot = state.Entry.StartTick +
            (ulong)MathF.Floor(shot.MinShootTime * MatchManifest.TickRate) + 1;
        int checks = Require(state.FirstShotEligibleTick == expectedShot,
            "The initial Corner shot clock lost its composed minimum or strict source time comparison.");
        checks += Require(state.FirstPointChangeEligibleTick == state.Entry.StartTick + 10 * MatchManifest.TickRate + 1,
            "The initial Corner change clock lost the source ten-second integer minimum or strict comparison.");
        checks += Require(state.Entry.EndTick == state.Entry.StartTick + MatchManifest.TickRate / 2,
            "The root Corner transition lost its source half-second duration.");

        while (host.Snapshot().ServerTick <= state.Entry.EndTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }
        BattleArmyEntityState after = host.ArmyEntityBatch(OpponentId, 0, 0).Entities.Single(row =>
            row.EntityKey == entity.EntityKey);
        checks += Require(after.X == point.Position.X && after.Z == point.Position.Z && after.Y == entity.Y,
            "Corner entry did not reach the authored X/Z while preserving the agent's current Y.");
        Vector3 facing = host.InfantryPose(entity.EntityKey)?.Facing ??
            throw new InvalidOperationException("The Corner entry lost its actual host root pose.");
        Vector3 sourceDirection = point.CornerDirection ??
            throw new InvalidOperationException("The source Corner lost its direction.");
        checks += Require(Vector3.Dot(facing, Vector3.Normalize(-sourceDirection)) > 0.9999f,
            "Corner entry did not turn the real host root opposite the source direction.");
        checks += Require(after.Health == entity.Health && after.MaxHealth == entity.MaxHealth,
            "A presentation transition changed combat vitality.");
        return checks;
    }

    private static int CheckMissingSnowPoint(BattleCombatContent content)
    {
        MatchEngine host = CreateDeployment(content, "Snow");
        BattleArmyEntityState first = host.ArmyEntityBatch(OpponentId, 0, 0).Entities.Single();
        ulong retryObservation = FirstSpawnTick + 6 * MatchManifest.TickRate;
        while (!host.Terminal && host.Snapshot().ServerTick < retryObservation)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        int checks = Require(!host.Terminal && host.AssaulterPoint(first.EntityKey) == null,
            "Snow fabricated a Corner outside its pinned source inventory.");
        checks += Require(host.ArmyEntityBatch(OpponentId, 0, 0).Entities.All(entity =>
            entity.InfantryClip == "idle_1"), "A point-less soldier entered a fabricated walking route.");
        return checks;
    }

    private static Vector3 Position(BattleArmyEntityState entity)
    {
        return new Vector3(entity.X, entity.Y, entity.Z);
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
