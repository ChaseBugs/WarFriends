using System.Reflection;
using War.BattleServer;
using War.Protocol;

/// <summary>Checks actual host death retention, scaled return and shared spawn preflight.</summary>
internal static class MortarWeaponPoolHostTests
{
    private const ulong FirstSpawnTick = 61;
    private const ulong CorpseReturnTick = FirstSpawnTick + 120;
    private const ulong FirstActorKey = (1UL << 32) | 1;
    private static readonly string OwnerId = new('a', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        return CheckReturn(content) + CheckExhaustion(content) + CheckPause(content) + CheckSameFrameReuse(content);
    }

    private static int CheckReturn(BattleCombatContent content)
    {
        MatchEngine host = OrdinaryArmyTestHost.Create(content, "ID_UNIT-MORTAR");
        Deploy(host);
        host.Advance(FirstSpawnTick);
        Require(host.RetainedMortarWeaponCount == 1 && host.RetainedMortarCorpseCount == 0,
            "A live Mortar did not acquire its physical weapon.");
        Require(host.ConfirmArmyDeath(FirstActorKey, false) && host.ArmyBatch(OwnerId).ActiveCount == 0 &&
            host.RetainedMortarWeaponCount == 1 && host.RetainedMortarCorpseCount == 1,
            "Death released the weapon with the live army count.");
        for (ulong tick = FirstSpawnTick + 1; tick < CorpseReturnTick; tick++)
        {
            host.Advance(tick);
        }
        Require(!host.Terminal && host.RetainedMortarWeaponCount == 1,
            "The source three-second hide plus one-second return finished early.");
        host.Advance(CorpseReturnTick);
        Require(host.RetainedMortarWeaponCount == 0 && host.RetainedMortarCorpseCount == 0,
            "The completed body waits did not return the physical weapon.");
        return 4;
    }

    private static int CheckExhaustion(BattleCombatContent content)
    {
        MatchEngine host = OrdinaryArmyTestHost.Create(content, "ID_UNIT-MORTAR");
        var pool = (MortarWeaponPool)typeof(MatchEngine).GetField("_mortarWeaponPool",
            BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(host)!;
        for (ulong actor = 1; actor <= (ulong)pool.Capacity; actor++)
        {
            pool.TryAllocateForMaster(actor, out _);
        }
        // Deliberately provision an exhausted retained ledger to exercise shared preflight.
        int energy = host.ArmyBatch(OwnerId).Energy;
        Deploy(host);
        host.Advance(FirstSpawnTick);
        MatchArmyBatch rejected = host.ArmyBatch(OwnerId);
        Require(host.Terminal && host.Snapshot().TerminalReason == "invalid-army-authority" &&
            rejected.Energy == energy && rejected.ActiveCount == 0 && rejected.PendingCount == 1,
            "An exhausted shared pool spent energy or published a source entity.");
        Require(host.RetainedMortarWeaponCount == 0,
            "Terminal cleanup retained physical weapon ownership.");
        return 2;
    }

    private static int CheckPause(BattleCombatContent content)
    {
        MatchEngine host = OrdinaryArmyTestHost.CreateWithIdleTimeout(content, "ID_UNIT-MORTAR", 2);
        Deploy(host);
        host.Advance(FirstSpawnTick);
        host.ConfirmArmyDeath(FirstActorKey, false);
        for (ulong tick = FirstSpawnTick + 1; tick <= 119; tick++)
        {
            host.Resume(OwnerId);
            host.Advance(tick);
        }
        ulong frozenTick = host.Snapshot().ServerTick;
        host.Advance(120, 100d);
        Require(host.Snapshot().ServerTick == frozenTick && host.RetainedMortarWeaponCount == 1 &&
            host.RetainedMortarCorpseCount == 1, "Raw time returned a body during scaled-time pause.");
        host.Resume(OwnerId);
        host.Resume(new string('b', 32));
        host.Advance(121, 100d);
        Require(host.Snapshot().ServerTick == frozenTick + 1 && host.RetainedMortarWeaponCount == 1,
            "Resume carried wall-time backlog into corpse return.");
        host.Command(OwnerId, new MatchCommand { CommandId = 4, Forfeit = new ForfeitCommand() });
        Require(host.Terminal && host.RetainedMortarWeaponCount == 0 && host.RetainedMortarCorpseCount == 0,
            "Terminal pause cleanup retained body waits or weapon ownership.");
        return 3;
    }

    private static void Deploy(MatchEngine host)
    {
        int option = host.ArmyBatch(OwnerId).OptionIndexes[0];
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new DeployArmyCommand { OptionIndex = option }
        }).Code == "army-deploying", "The physical weapon fixture rejected its initial source wave.");
    }

    private static int CheckSameFrameReuse(BattleCombatContent content)
    {
        MatchEngine host = OrdinaryArmyTestHost.Create(content, "ID_UNIT-MORTAR");
        Deploy(host);
        host.Advance(FirstSpawnTick);
        host.ConfirmArmyDeath(FirstActorKey, false);
        for (ulong tick = FirstSpawnTick + 1; tick < CorpseReturnTick; tick++)
        {
            host.Advance(tick);
        }
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 4,
            DeployArmy = new DeployArmyCommand { OptionIndex = host.ArmyBatch(OwnerId).OptionIndexes[0] }
        }).Code == "army-deploying", "The same-frame slot successor was not accepted.");
        host.Advance(CorpseReturnTick);
        const ulong SuccessorActorKey = (1UL << 32) | 2;
        Require(!host.Terminal && host.RetainedMortarWeaponCount == 1 && host.RetainedMortarCorpseCount == 0 &&
            host.RetainedMortarWeaponSlot(SuccessorActorKey) == 0,
            "Same-frame spawning ran before body return or failed to reuse the released front slot.");
        return 2;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
