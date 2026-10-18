using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Deploys real ordinary Mortars and follows natural routes to exclusive authored destinations.</summary>
internal static class MortarNavigationTests
{
    private const string UnitId = "ID_UNIT-MORTAR";
    private const ulong MaximumArrivalTick = 3000;
    private const float ArrivalDistance = 0.04f;
    private const float SourceBuildSeconds = 2f;

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = 0;
        foreach (RecoveredBattleMap map in content.Maps)
        {
            foreach (int fraction in new[] { 1, 2 })
            {
                checks += CheckMap(content, map, fraction);
            }
        }

        return checks + CheckArtifactRejection(directory, content);
    }

    private static int CheckMap(BattleCombatContent content, RecoveredBattleMap map, int fraction)
    {
        string scene = Path.GetFileNameWithoutExtension(map.Source).Replace("_Multiplayer", "");
        string playerId = new(fraction == 1 ? 'a' : 'b', 32);
        MatchEngine host = OrdinaryArmyTestHost.Create(content, UnitId, scene);
        int option = host.ArmyBatch(playerId).OptionIndexes.First(index => content.Army.Option(index).Count == 2);
        int checks = Require(host.Command(playerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The two-Mortar deployment was rejected.");
        var seen = new HashSet<ulong>();
        var reserved = new HashSet<int>();
        var arrivals = new HashSet<ulong>();
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumArrivalTick && arrivals.Count < 2)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            if (host.Terminal)
            {
                throw new InvalidOperationException($"Mortar {scene}/{fraction} terminated: " +
                    host.Snapshot().TerminalReason);
            }
            foreach (BattleArmyEntityState entity in host.ArmyEntityBatch(playerId, 0, 0).Entities)
            {
                if (seen.Add(entity.EntityKey))
                {
                    checks += CheckInitialPoint((content, map), host, entity, reserved);
                    MortarPoint point = host.MortarDestination(entity.EntityKey) ??
                        throw new InvalidOperationException("New Mortar lost its checked destination.");
                    reserved.Add(point.ComponentFileId);
                }
                if (host.MortarConstruction(entity.EntityKey) != null)
                {
                    arrivals.Add(entity.EntityKey);
                }
            }
        }

        checks += Require(!host.Terminal && arrivals.Count == 2,
            $"Mortar arrival failed on {scene}, fraction {fraction}: {host.Snapshot().TerminalReason}; " +
            string.Join("; ", host.ArmyEntityBatch(playerId, 0, 0).Entities.Select(entity =>
                $"{entity.EntityKey}=({entity.X},{entity.Z}), " +
                $"destination={host.MortarDestination(entity.EntityKey)}, " +
                $"projected={content.ArmyNavMeshConnectivity.SampleNearest(
                    map, host.MortarDestination(entity.EntityKey)?.Position ?? Vector3.Zero, 0.5f)}")));
        foreach (BattleArmyEntityState entity in host.ArmyEntityBatch(playerId, 0, 0).Entities)
        {
            checks += CheckArrivalAndDeath(host, entity);
        }

        Console.WriteLine($"PASS: two ordinary Mortars arrive on {scene}, fraction {fraction}, " +
            $"tick {host.Snapshot().ServerTick}.");
        return checks;
    }

    private static int CheckInitialPoint((BattleCombatContent Content, RecoveredBattleMap Map) source,
        MatchEngine host, BattleArmyEntityState entity, IReadOnlySet<int> reserved)
    {
        Vector3 position = new(entity.X, entity.Y, entity.Z);
        MortarPoint expected = source.Content.MortarPoints.ForMap(source.Map).Where(point =>
            point.Fraction == entity.OwnerFraction && !reserved.Contains(point.ComponentFileId))
            .OrderBy(point => Vector3.Distance(position, point.Position)).ThenBy(point => point.Order).First();
        return Require(host.MortarDestination(entity.EntityKey) == expected && entity.InfantryClip == "mortar_run" &&
            host.MortarDestinationOccupant(expected.ComponentFileId) == entity.EntityKey &&
            host.MortarConstruction(entity.EntityKey) == null,
            $"Mortar {source.Map.Source}/{entity.EntityKey}: actual={host.MortarDestination(entity.EntityKey)}, " +
            $"expected={expected}, clip={entity.InfantryClip}, " +
            $"construction={host.MortarConstruction(entity.EntityKey)}.");
    }

    private static int CheckArrivalAndDeath(MatchEngine host, BattleArmyEntityState entity)
    {
        MortarPoint point = host.MortarDestination(entity.EntityKey) ??
            throw new InvalidOperationException("Arrived Mortar lost its destination.");
        MortarConstructionState state = host.MortarConstruction(entity.EntityKey) ??
            throw new InvalidOperationException("Arrived Mortar lost its construction state.");
        MortarShotAttempt? attempt = host.MortarAttempt(entity.EntityKey);
        bool hasExpectedPose = attempt == null
            ? entity.InfantryClip is "mortar_down" or "mortar_down_idle"
            : attempt.PreparedTick >= state.FirstFireEligibleTick &&
                entity.InfantryClip is "mortar_hide" or "mortar_up";
        ulong buildTicks = state.FirstFireEligibleTick - state.EnteredTick;
        ulong minimumBuildTicks = (ulong)(SourceBuildSeconds * MatchManifest.TickRate);
        int checks = Require(Vector2.Distance(new(entity.X, entity.Z), new(point.Position.X, point.Position.Z)) <
            ArrivalDistance && buildTicks >= minimumBuildTicks && buildTicks <= minimumBuildTicks + 1 &&
            hasExpectedPose,
            "Mortar stopped outside the authored arrival or lost the strict source construction deadline.");
        checks += Require(host.ConfirmArmyDeath(entity.EntityKey, false) &&
            host.MortarDestination(entity.EntityKey) == null && host.MortarConstruction(entity.EntityKey) == null &&
            host.MortarDestinationOccupant(point.ComponentFileId) == null &&
            host.OrdinaryMortarWeapon(entity.EntityKey) == null,
            "Mortar death retained destination occupancy, construction or current weapon authority.");
        return checks;
    }

    private static int CheckArtifactRejection(string directory, BattleCombatContent content)
    {
        string temporary = Path.GetTempFileName();
        try
        {
            string original = File.ReadAllText(Path.Combine(directory, "recovered-mortar-points.json"));
            File.WriteAllText(temporary, original + " ");
            try
            {
                MortarPointCatalog.Load(temporary, content.Maps);
                throw new InvalidOperationException("Mortar accepted altered source point bytes.");
            }
            catch (InvalidDataException)
            {
                return 1;
            }
        }
        finally
        {
            File.Delete(temporary);
        }
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
