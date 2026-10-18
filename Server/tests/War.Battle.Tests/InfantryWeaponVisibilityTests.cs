using System.Security.Cryptography;
using System.Text.Json;
using Google.Protobuf;
using War.BattleServer;
using War.Protocol;
using War.Shared;

/// <summary>Checks source coroutine timing, mask validation and actual Grenadier selection/return projection.</summary>
internal static class InfantryWeaponVisibilityTests
{
    private const string CardId = "GREATGRENADIER";
    private const string UnitId = "ID_UNIT-GRENADIER";
    private const string NativeRevision = "651bcf5b3c909eb9613e67c7b0f2f57de276c1ecb580226d95515f8587302800";
    private const ulong MaximumTick = 3000;
    private const ulong NativeReturnTicks = 15;
    private static readonly string OwnerId = new('a', 32);

    internal static int Run(string directory)
    {
        int checks = CheckClock(directory);
        checks += CheckProtocol();
        checks += CheckIndependentReturns();
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        checks += CheckLifecycle(content);
        checks += CheckCancelledReturn(content);
        checks += CheckRetainedSelection(content);
        return checks;
    }

    private static int CheckClock(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "grenadier-weapon-return-unity-reference.json"));
        int checks = Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == NativeRevision,
            "The native half-second coroutine evidence changed.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        foreach (JsonElement row in document.RootElement.GetProperty("observations").EnumerateArray())
        {
            checks += Require(row.GetProperty("callbackTick").GetUInt64() ==
                row.GetProperty("scheduledTick").GetUInt64() + NativeReturnTicks,
                "The source coroutine callback must return fifteen gameplay ticks later.");
        }

        return checks;
    }

    private static int CheckIndependentReturns()
    {
        const ulong actorKey = 1;
        var state = new GrenadierWeaponState();
        state.SelectSecondary(actorKey);
        state.ScheduleReturn(actorKey, 100);
        state.ScheduleReturn(actorKey, 105);

        state.Advance(114, key => key == actorKey);
        int checks = Require(state.IsSecondary(actorKey), "An overlapping return fired too early.");
        state.Advance(115, key => key == actorKey);
        checks += Require(!state.IsSecondary(actorKey) && state.HasPendingReturns,
            "The first shot must return independently without cancelling the second callback.");

        state.SelectSecondary(actorKey);
        state.Advance(119, key => key == actorKey);
        checks += Require(state.IsSecondary(actorKey), "A new selection must remain until the older callback.");
        state.Advance(120, key => key == actorKey);
        checks += Require(!state.IsSecondary(actorKey) && !state.HasPendingReturns,
            "The older callback must restore primary even after a newer selection.");

        state.SelectSecondary(actorKey);
        state.ScheduleReturn(actorKey, 121);
        state.Remove(actorKey);
        state.Advance(136, _ => false);
        checks += Require(!state.IsSecondary(actorKey) && !state.HasPendingReturns,
            "Actor removal must cancel every callback before the next authority lookup.");
        return checks;
    }

    private static int CheckProtocol()
    {
        var row = new BattleArmyEntityState { SourceCardId = CardId, UnitId = UnitId, InfantryWeaponMask = 2 };
        BattleArmyEntityState decoded = BattleArmyEntityState.Parser.ParseFrom(row.ToByteArray());
        int checks = Require(decoded.InfantryWeaponMask == 2 && InfantryWeaponVisibility.IsValid(decoded),
            "Grenadier secondary visibility must survive protobuf and SDK validation.");
        foreach (uint mask in new uint[] { 0, 3, uint.MaxValue })
        {
            decoded.InfantryWeaponMask = mask;
            checks += Require(!InfantryWeaponVisibility.IsValid(decoded),
                "The SDK accepted an invalid Grenadier mask.");
        }

        decoded.SourceCardId = "ELITESWAT";
        decoded.UnitId = "ID_UNIT-SWAT";
        decoded.InfantryWeaponMask = 2;
        checks += Require(!InfantryWeaponVisibility.IsValid(decoded), "A single-weapon card accepted a secondary bit.");
        decoded.InfantryWeaponMask = 1;
        checks += Require(InfantryWeaponVisibility.IsValid(decoded), "A single-weapon card lost its primary bit.");
        decoded.SourceCardId = "";
        checks += Require(!InfantryWeaponVisibility.IsValid(decoded), "Card masks widened ordinary unit authority.");
        decoded.InfantryWeaponMask = 0;
        checks += Require(InfantryWeaponVisibility.IsValid(decoded),
            "The ordinary omitted field must remain compatible.");
        return checks;
    }

    private static (MatchEngine Host, ulong Key, ulong ShotTick) ObserveSecondaryShot(BattleCombatContent content)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate => candidate.Source.EndsWith("/Park_Multiplayer.unity"));
        MatchEngine host = GrenadierPrimaryDamageTests.CreateRealShotHost(content, map, _ => 0);
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, UseUnitCard = new() { RequestId = new string('d', 32), SourceCardId = CardId }
        }).Code == "unit-card-activated", "The visibility fixture could not activate its authoritative card.");
        bool hasObservedPrimary = false;
        bool hasObservedSecondary = false;
        ulong key = 0;
        ulong shotTick = 0;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            BattleArmyEntityState? actor = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.FirstOrDefault();
            if (actor == null)
            {
                continue;
            }

            key = actor.EntityKey;
            hasObservedPrimary |= actor.InfantryWeaponMask == 1;
            hasObservedSecondary |= actor.InfantryWeaponMask == 2;
            if (host.CardGrenadierShotIntents().Any(intent => intent.EntityKey == key && intent.Aim.ThrowGrenade))
            {
                shotTick = host.Snapshot().ServerTick;
                break;
            }
        }

        Require(!host.Terminal && shotTick != 0 && hasObservedPrimary && hasObservedSecondary,
            "Real card deployment must move from its gun to a source-selected grenade and launch it.");
        return (host, key, shotTick);
    }

    private static int CheckLifecycle(BattleCombatContent content)
    {
        var (host, key, shotTick) = ObserveSecondaryShot(content);
        int checks = Require(Entity(host, key).InfantryWeaponMask == 2,
            "The actual secondary shot must retain its selected grenade until the callback.");
        while (host.Snapshot().ServerTick < shotTick + NativeReturnTicks - 1)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        checks += Require(Entity(host, key).InfantryWeaponMask == 2,
            "The grenade returned before its source callback.");
        host.Advance(shotTick + NativeReturnTicks);
        checks += Require(Entity(host, key).InfantryWeaponMask == 1,
            "The source callback failed to restore the basic gun.");
        Console.WriteLine($"Grenadier weapon selection: launch {shotTick}, " +
            $"primary return {shotTick + NativeReturnTicks}.");
        return checks;
    }

    private static int CheckCancelledReturn(BattleCombatContent content)
    {
        var (host, key, shotTick) = ObserveSecondaryShot(content);
        int checks = Require(host.ApplyArmyHostDamage(key, 1_000_000),
            "Trusted lethal damage must remove the pending secondary-shot owner.");
        while (host.Snapshot().ServerTick < shotTick + NativeReturnTicks)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }
        checks += Require(!host.Terminal &&
            host.ArmyEntityBatch(OwnerId, 0, 0).Entities.All(row => row.EntityKey != key),
            "A removed actor must not retain a callback that terminates the live match.");
        return checks;
    }

    private static BattleArmyEntityState Entity(MatchEngine host, ulong key)
    {
        return host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(entity => entity.EntityKey == key);
    }

    private static int CheckRetainedSelection(BattleCombatContent content)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate => candidate.Source.EndsWith("/Park_Multiplayer.unity"));
        bool shouldChooseSecondary = true;
        int Choice(int maximum)
        {
            return maximum == 1_000_000 && !shouldChooseSecondary ? 400_000 : 0;
        }

        MatchEngine host = GrenadierPrimaryDamageTests.CreateRealShotHost(content, map, Choice);
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, UseUnitCard = new() { RequestId = new string('e', 32), SourceCardId = CardId }
        }).Code == "unit-card-activated", "The retained-selection fixture could not activate its source card.");
        BattleArmyEntityState? selected = null;
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            selected = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.FirstOrDefault();
            if (selected?.InfantryWeaponMask == 2)
            {
                break;
            }
        }

        if (selected == null)
        {
            throw new InvalidOperationException("The retained-selection fixture spawned no card actor.");
        }

        int checks = Require(selected.InfantryWeaponMask == 2 && host.CardGrenadierShotIntents().Count == 0,
            "The source must select its secondary weapon before firing.");
        shouldChooseSecondary = false;
        MatchEngine.CardGrenadierAim? retry = host.CardGrenadierChooseTarget(selected.EntityKey);
        checks += Require(retry?.ThrowGrenade == true,
            "A later non-secondary choice must not silently undo the retained source inventory selection.");
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
