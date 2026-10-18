using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Checks ordinary deployment, source destinations and arrival clocks on all five maps.</summary>
internal static class GunslingerNavigationTests
{
    private const ulong MaximumTick = 3000;
    private const float ArrivalTolerance = 0.04f;
    private const string UnitId = "ID_UNIT-GUNSLINGER";
    private static readonly string PlayerId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = 0;
        foreach (RecoveredBattleMap map in content.Maps)
        {
            checks += CheckMap(content, map);
        }

        return checks;
    }

    private static int CheckMap(BattleCombatContent content, RecoveredBattleMap map)
    {
        string scene = Path.GetFileNameWithoutExtension(map.Source).Replace("_Multiplayer", "");
        MatchEngine host = OrdinaryArmyTestHost.Create(content, UnitId, scene);
        int option = host.ArmyBatch(PlayerId).OptionIndexes.First(index => content.Army.Option(index).Count == 2);
        Require(host.Command(PlayerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The two-Gunslinger deployment was rejected.");
        var arrivals = new Dictionary<ulong, GunslingerArrival>();
        var seen = new HashSet<ulong>();
        var reserved = new HashSet<int>();
        int checks = 0;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && arrivals.Count < 2)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            foreach (BattleArmyEntityState entity in host.ArmyEntityBatch(PlayerId, 0, 0).Entities)
            {
                if (seen.Add(entity.EntityKey))
                {
                    checks += CheckInitialPoint(host, entity, content.GunslingerPoints.ForMap(map)
                        .Where(point => !reserved.Contains(point.ComponentFileId)));
                    reserved.Add(host.GunslingerPoint(entity.EntityKey)?.ComponentFileId ??
                        throw new InvalidOperationException("A new Gunslinger lost its reservation."));
                }
                if (host.GunslingerState(entity.EntityKey) is { } state)
                {
                    arrivals.TryAdd(entity.EntityKey, state);
                }
            }
        }

        checks += Require(!host.Terminal && arrivals.Count == 2,
            $"Gunslingers did not reach both source destinations on {scene}: {host.Snapshot().TerminalReason}; " +
            string.Join("; ", host.ArmyEntityBatch(PlayerId, 0, 0).Entities.Select(entity =>
                $"{entity.EntityKey}: ({entity.X},{entity.Z}), point={host.GunslingerPoint(entity.EntityKey)}")));
        checks += CheckArrivals(content, host, arrivals);
        Console.WriteLine($"PASS: two normal Gunslingers reach source destinations on {scene}, " +
            $"last entry tick {host.Snapshot().ServerTick}.");
        return checks;
    }

    private static int CheckInitialPoint(MatchEngine host, BattleArmyEntityState entity,
        IEnumerable<GunslingerPoint> freePoints)
    {
        Vector3 position = new(entity.X, entity.Y, entity.Z);
        GunslingerPoint expected = freePoints.Where(point => point.Fraction == entity.OwnerFraction)
            .OrderBy(point => Vector3.Distance(position, point.Position)).ThenBy(point => point.Order).First();
        return Require(host.GunslingerPoint(entity.EntityKey) == expected && entity.InfantryClip == "colt_run",
            "The source nearest free same-fraction point or ordinary Gunslinger walking clip changed.");
    }

    private static int CheckArrivals(BattleCombatContent content, MatchEngine host,
        IReadOnlyDictionary<ulong, GunslingerArrival> arrivals)
    {
        var entities = host.ArmyEntityBatch(PlayerId, 0, 0).Entities;
        int checks = Require(entities.Select(entity => host.GunslingerPoint(entity.EntityKey)?.ComponentFileId)
            .Distinct().Count() == 2, "Ordinary Gunslingers shared one exclusive source destination.");
        ArmyBaseShotStats shot = content.Army.ComposeShot(UnitId, 0, null, null, 1f);
        foreach (BattleArmyEntityState entity in entities)
        {
            GunslingerPoint point = host.GunslingerPoint(entity.EntityKey) ??
                throw new InvalidOperationException("Arrived Gunslinger lost its source destination.");
            GunslingerArrival state = arrivals[entity.EntityKey];
            checks += Require(point.Fraction == entity.OwnerFraction &&
                Vector2.Distance(new(entity.X, entity.Z), new(point.Position.X, point.Position.Z)) < ArrivalTolerance,
                "Gunslinger arrival does not match its own-fraction authored source point.");
            checks += Require(state.ShotsRemaining == shot.FireBatchSizeMax &&
                state.FirstShotEligibleTick == state.EnteredTick + 1 &&
                state.FirstPointChangeEligibleTick == state.EnteredTick + 2 * MatchManifest.TickRate + 1,
                "Gunslinger entry did not retain its source maximum attempts and strict initial clocks.");
            checks += Require(host.ConfirmArmyDeath(entity.EntityKey, false) &&
                host.GunslingerPoint(entity.EntityKey) == null && host.GunslingerState(entity.EntityKey) == null,
                "A removed Gunslinger retained its destination or entry state.");
        }

        return checks;
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
