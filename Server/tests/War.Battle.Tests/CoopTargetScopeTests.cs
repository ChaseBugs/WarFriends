using System.Numerics;
using War.BattleServer;
using War.Protocol;

/// <summary>Guards the restricted entity-world assumption and the SoldierBehaviour shield boundary.</summary>
internal static class CoopTargetScopeTests
{
    internal static int Run()
    {
        Require(CoopCommandCapabilities.CanConfirmPlayerOnlyOpposition,
            "Current co-op command scope is not player-only.");
        int checks = 1;
        foreach (var producer in new[]
        {
            MatchCommand.IntentOneofCase.DeployArmy,
            MatchCommand.IntentOneofCase.UseUnitCard,
            MatchCommand.IntentOneofCase.UseDecoy,
            MatchCommand.IntentOneofCase.UseHeavyTurret,
            (MatchCommand.IntentOneofCase)999,
        })
        {
            Require(!CoopCommandCapabilities.Supports(producer) &&
                !CoopCommandCapabilities.IsPlayerOnlyScope([MatchCommand.IntentOneofCase.Ready, producer]),
                "A new entity-producing command retained the empty-opponent-entity assumption.");
            checks++;
        }
        Require(MatchEngine.SoldierStationaryTargetMask(Vector3.UnitZ, Vector3.UnitZ, 0, () => 0) == 2 &&
            MatchEngine.HeavyTurretStationaryTargetMask(Vector3.UnitZ, Vector3.UnitZ, 0, () => 0) == 9,
            "Soldier's inclusive shield roll was confused with the turret's strict comparison.");
        return checks + 1;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
