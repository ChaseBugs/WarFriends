using System.Reflection;

using War.BattleServer;
using War.Protocol;

/// <summary>Rejects a damaged second owner's due batch before the first owner's spawn is committed.</summary>
internal static class ArmySpawnPreflightTests
{
    private static readonly string FirstOwnerId = new('a', 32);
    private static readonly string SecondOwnerId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        MatchEngine host = OrdinaryArmyTestHost.Create(content, "ID_UNIT-MORTAR");
        Require(Deploy(host, FirstOwnerId) == "army-deploying" &&
            Deploy(host, SecondOwnerId) == "army-deploying", "Both owners must have due source spawns.");
        ArmyDeploymentState[] armies = ReadOwnedArmies(host);
        int firstEnergy = armies[0].Energy;
        int firstPending = armies[0].PendingCount;
        // Fault injection targets host authority, not a client command or production mutation API.
        typeof(ArmyDeploymentState).GetProperty(nameof(ArmyDeploymentState.Energy))!.SetValue(armies[1], 0);

        host.Advance(host.Snapshot().ServerTick + 1);

        Require(host.Terminal && host.Snapshot().Phase == BattlePhase.Aborted &&
            host.Snapshot().TerminalReason == "invalid-army-authority",
            "The damaged second owner's energy did not abort the match without a scored outcome.");
        Require(armies[0].Energy == firstEnergy && armies[0].PendingCount == firstPending,
            "A later owner's failed preflight spent the first owner's energy or dequeued its reservation.");
        Require(armies[0].ActiveCount == 0 && armies[1].ActiveCount == 0,
            "A soldier was committed before both owners passed due-spawn validation.");
        return 4;
    }

    private static string Deploy(MatchEngine host, string ownerId)
    {
        return host.Command(ownerId, new MatchCommand
        {
            CommandId = 3,
            DeployArmy = new() { OptionIndex = host.ArmyBatch(ownerId).OptionIndexes.First() }
        }).Code;
    }

    private static ArmyDeploymentState[] ReadOwnedArmies(MatchEngine host)
    {
        var players = (Array)typeof(MatchEngine).GetField("players",
            BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(host)!;
        return players.Cast<object>()
            .Select(player => (ArmyDeploymentState)player.GetType().GetField("Army")!.GetValue(player)!)
            .ToArray();
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
