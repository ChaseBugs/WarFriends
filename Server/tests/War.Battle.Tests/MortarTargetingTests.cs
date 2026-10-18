using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Checks captured shield coordinates during real host cover movement on every recovered map.</summary>
internal static class MortarTargetingTests
{
    private const string UnitId = "ID_UNIT-MORTAR";
    private const ulong MaximumSpawnTick = 600;

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        int checks = 0;
        foreach (RecoveredBattleMap map in content.Maps)
        {
            checks += CheckMap(content, map, 1);
            checks += CheckMap(content, map, 2);
        }
        return checks;
    }

    private static int CheckMap(BattleCombatContent content, RecoveredBattleMap map, int fraction)
    {
        string scene = Path.GetFileNameWithoutExtension(map.Source).Replace("_Multiplayer", "");
        string ownerId = new(fraction == 1 ? 'a' : 'b', 32);
        string opponentId = new(fraction == 1 ? 'b' : 'a', 32);
        var draws = new List<int>();
        MatchEngine host = OrdinaryArmyTestHost.Create(content, UnitId, scene, count =>
        {
            draws.Add(count);
            return 0;
        });
        int checks = Require(host.SelectMortarShotTarget(ulong.MaxValue) == null,
            "An unknown army identity acquired a Mortar target.");
        Require(host.Command(ownerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = host.ArmyBatch(ownerId).OptionIndexes.First() }
        }).Code == "army-deploying", "The target fixture could not deploy its ordinary Mortar.");
        BattleArmyEntityState? soldier = null;
        while (soldier == null && !host.Terminal && host.Snapshot().ServerTick < MaximumSpawnTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            soldier = host.ArmyEntityBatch(ownerId, 0, 0).Entities.SingleOrDefault();
        }
        Require(soldier != null, "The target fixture never spawned its ordinary Mortar.");
        draws.Clear();
        MortarShotTarget captured = host.SelectMortarShotTarget(soldier!.EntityKey) ??
            throw new InvalidOperationException("Mortar failed to select its source Shield target.");
        checks += Require(draws.SequenceEqual(new[] { 1, 1 }) && captured.PlayerId == opponentId &&
            captured.Position == map.Covers[captured.CoverIndex].ShotPosition - Vector3.UnitY * 0.4f,
            "Mortar lost the opponent/Shield draws, height offset or owner-bound identity.");

        BattlePlayerState opponent = host.Snapshot().Players.Single(player => player.PlayerId == opponentId);
        int direction = map.Adjacent(opponent.CoverIndex, 1, 3 - fraction) >= 0 ? 1 : -1;
        int destination = map.Adjacent(opponent.CoverIndex, direction, 3 - fraction);
        Require(destination >= 0 && host.Command(opponentId, new MatchCommand
        {
            CommandId = 3, MoveCover = new() { Direction = direction }
        }).Code == "moving", "The target fixture could not start its real cover movement.");
        MortarShotTarget moving = host.SelectMortarShotTarget(soldier.EntityKey) ??
            throw new InvalidOperationException("Walking opponent lost its Shield target.");
        checks += Require(moving.CoverIndex == destination && moving.Position ==
            map.Covers[destination].ShotPosition - Vector3.UnitY * 0.4f &&
            host.Snapshot().Players.Single(player => player.PlayerId == opponentId).CoverIndex == captured.CoverIndex,
            "Mortar selected the old physical cover instead of the accepted logical destination.");
        host.Advance(host.Snapshot().ServerTick + 1);
        checks += Require(captured.Position == map.Covers[captured.CoverIndex].ShotPosition - Vector3.UnitY * 0.4f &&
            captured.CoverIndex != moving.CoverIndex,
            "A previously captured Mortar target changed with later opponent movement.");
        checks += Require(host.ConfirmArmyDeath(soldier.EntityKey, false) &&
            host.SelectMortarShotTarget(soldier.EntityKey) == null,
            "A removed Mortar retained target-selection authority.");
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
