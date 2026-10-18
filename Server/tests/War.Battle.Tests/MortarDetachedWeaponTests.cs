using War.BattleServer;
using War.Protocol;

/// <summary>Checks frozen preparation authority through real opponent movement and the native hand deadline.</summary>
internal static class MortarDetachedWeaponTests
{
    private const string UnitId = "ID_UNIT-MORTAR";
    private const ulong MaximumTick = 1200;
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        RecoveredBattleMap map = content.Maps.Single(row => row.Source.EndsWith("/Park_Multiplayer.unity"));
        var (host, entityKey, frozen) = CreatePrepared(content);
        BattlePlayerState opponent = host.Snapshot().Players.Single(player => player.PlayerId == OpponentId);
        int direction = map.Adjacent(opponent.CoverIndex, 1, 2) >= 0 ? 1 : -1;
        int destination = map.Adjacent(opponent.CoverIndex, direction, 2);
        Require(destination >= 0 && host.Command(OpponentId, new MatchCommand
        {
            CommandId = 3, MoveCover = new() { Direction = direction }
        }).Code == "moving", "Detached-weapon fixture could not move its opponent during windup.");
        int checks = 0;
        while (!host.Terminal && host.Snapshot().ServerTick < frozen.HandReturnTick - 1)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            checks += Require(host.MortarDetachedWeapon(entityKey) == frozen &&
                host.MortarFacing(entityKey)?.TargetCoverIndex == destination,
                "Windup retargeting changed the frozen world transform or lost the new logical cover.");
        }
        checks += Require(!host.Terminal && host.MortarDetachedWeapon(entityKey) == frozen,
            "Detached weapon disappeared before the source hand-return callback.");
        host.Advance(frozen.HandReturnTick);
        checks += Require(!host.Terminal && host.MortarDetachedWeapon(entityKey) == null,
            "The native hand-return deadline retained detached authority.");
        return checks + CheckTerminalCleanup(content);
    }

    private static int CheckTerminalCleanup(BattleCombatContent content)
    {
        var (host, entityKey, _) = CreatePrepared(content);
        host.Command(OwnerId, new MatchCommand { CommandId = 4, Forfeit = new ForfeitCommand() });
        return Require(host.Terminal && host.MortarDetachedWeapon(entityKey) == null,
            "Terminal match retained detached weapon authority after its simulation clock stopped.");
    }

    private static (MatchEngine Host, ulong EntityKey, MortarDetachedWeaponPose Pose) CreatePrepared(
        BattleCombatContent content)
    {
        MatchEngine host = OrdinaryArmyTestHost.Create(content, UnitId);
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = host.ArmyBatch(OwnerId).OptionIndexes.First() }
        }).Code == "army-deploying", "Detached-weapon fixture rejected its ordinary Mortar deployment.");
        host.Advance(61);
        ulong entityKey = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && host.MortarAttempt(entityKey) == null)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }
        MortarDetachedWeaponPose frozen = host.MortarDetachedWeapon(entityKey) ??
            throw new InvalidOperationException("Natural preparation did not capture detached weapon authority.");
        return (host, entityKey, frozen);
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
