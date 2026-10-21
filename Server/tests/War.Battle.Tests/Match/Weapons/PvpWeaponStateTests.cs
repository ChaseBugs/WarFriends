using System.Reflection;
using War.BattleServer;

namespace War.Battle.Tests.Match.Weapons;

internal static class PvpWeaponStateTests
{
    internal static int Run()
    {
        CheckReloadBoundariesAndRounding();
        CheckEmptyMagazineRestart();
        CheckZeroClipTheftCancelsReload();
        CheckAmmoGrantPreflight();
        CheckLoadoutSelectionAndReadOnlyMembership();
        CheckStateOwnership();
        return 6;
    }

    private static PvpWeaponSlotState Slot(int clip = 5, int reserve = 3, double seconds = 0.10000000001)
    {
        return new(new WeaponSlotManifest(0, 0, new("fixture-weapon", clip, reserve, seconds, seconds), 0));
    }

    private static void Consume(PvpWeaponSlotState weapon, int rounds)
    {
        for (int round = 0; round < rounds; round++)
        {
            weapon.ConsumeRound();
        }
    }

    private static void CheckReloadBoundariesAndRounding()
    {
        PvpWeaponSlotState weapon = Slot();
        Require(!weapon.CanReload, "A full magazine offered manual reload.");
        Consume(weapon, 2);
        weapon.BeginReload(10);
        weapon.ScheduleNextFire(10);
        Require(weapon.ReloadEnd == 14 && weapon.NextFire == 14 && !weapon.CanReload,
            "Stored double durations were rounded through a different tick domain.");
        Require(!weapon.CompleteReload(13) && weapon.Clip == 3 && weapon.Reserve == 3,
            "Reload consumed reserve before its deadline.");
        Require(weapon.CompleteReload(14) && weapon.Clip == 5 && weapon.Reserve == 1 && weapon.ReloadEnd == 0,
            "Reload did not conserve magazine and reserve at its inclusive boundary.");
        PvpWeaponSlotState infinite = Slot(reserve: int.MaxValue);
        Consume(infinite, 5);
        infinite.BeginReload(10);
        infinite.CompleteReload(14);
        Require(infinite.Clip == 5 && infinite.Reserve == int.MaxValue,
            "The immutable reserve sentinel was decremented.");
    }

    private static void CheckEmptyMagazineRestart()
    {
        PvpWeaponSlotState weapon = Slot();
        Consume(weapon, 1);
        weapon.BeginReload(1);
        weapon.EmptyMagazine(3);
        Require(weapon.Clip == 0 && weapon.Reserve == 3 && weapon.ReloadEnd == 7,
            "Empty Mag preserved an old deadline or debited reserve before reload.");
        weapon.CompleteReload(7);
        Require(weapon.Clip == 3 && weapon.Reserve == 0, "Empty Mag created a full clip from insufficient reserve.");
        weapon.EmptyMagazine(8);
        Require(weapon.ReloadEnd == 0, "An empty reserve started another reload.");
    }

    private static void CheckZeroClipTheftCancelsReload()
    {
        PvpWeaponSlotState victim = Slot(clip: 5, reserve: 8);
        Consume(victim, 5);
        victim.BeginReload(1);
        victim.CompleteReload(5);
        Consume(victim, 2);
        victim.BeginReload(6);
        victim.CompleteReload(10);
        Consume(victim, 5);
        victim.BeginReload(11);
        Require(victim.Clip == 0 && victim.Reserve == 1 && victim.ReloadEnd == 15,
            "The theft fixture did not reach the pending last-round reload.");
        PvpWeaponSlotState recipient = Slot(reserve: 8);
        AmmoThiefTransfer transfer = AmmoThiefTransferPolicy.Calculate(victim.Definition.Weapon.ReserveAmmo,
            victim.Reserve, victim.Clip, recipient.Reserve);
        Require(transfer.ClipAccessed && transfer.ClipTaken == 0 && transfer.TotalTaken == 1,
            "The source transfer did not exercise the zero-debit clip setter.");
        victim.ApplyAmmoTheftLoss(transfer);
        recipient.AddPlannedReserve(transfer.TotalTaken);
        Require(victim.Reserve == 0 && victim.Clip == 0 && victim.ReloadEnd == 0 && recipient.Reserve == 9,
            "Theft lost actual ammo conservation or the source clip-setter reload cancellation.");
    }

    private static void CheckAmmoGrantPreflight()
    {
        PvpWeaponSlotState weapon = Slot(reserve: 3);
        Require(weapon.TryPlanAmmoBoxGrant(out int amount) && amount == 1 && weapon.Reserve == 3,
            "Ammo Box changed ceiling/starting-reserve math or mutated during preflight.");
        weapon.AddPlannedReserve(amount);
        Require(weapon.Reserve == 4 && weapon.TryPlanAmmoBoxGrant(out amount) && amount == 1,
            "Ammo Box used current reserve instead of source starting ammunition.");
        PvpWeaponSlotState overflow = Slot(reserve: int.MaxValue);
        Require(!overflow.TryPlanAmmoBoxGrant(out amount) && amount == 0 && overflow.Reserve == int.MaxValue,
            "An overflowing source grant changed state or produced a valid plan.");
        weapon.ApplyCappedAmmoGrant(1);
        Require(weapon.Reserve == 4, "A capped ammo grant consumed valid reserve already above the starting amount.");
        overflow.ApplyCappedAmmoGrant(1);
        Require(overflow.Reserve == int.MaxValue,
            "A capped grant overflowed or changed the immutable reserve sentinel.");
        PvpWeaponSlotState nearMaximum = Slot(reserve: int.MaxValue - 1);
        nearMaximum.ConsumeRound();
        nearMaximum.BeginReload(10);
        nearMaximum.CompleteReload(14);
        nearMaximum.ApplyCappedAmmoGrant(100_000);
        Require(nearMaximum.Reserve == int.MaxValue - 1,
            "A valid positive grant overflowed instead of saturating below the reserve sentinel.");
    }

    private static void CheckLoadoutSelectionAndReadOnlyMembership()
    {
        var first = new WeaponManifest("fixture-first", 2, 3, 0.1, 0.2);
        var second = new WeaponManifest("fixture-second", 4, 8, 0.2, 0.3);
        var definition = new ParticipantManifest(new string('a', 32), first)
        {
            WeaponSlots = [new(0, 0, first, 0), new(2, 1, second, 0)]
        };
        var loadout = new PvpWeaponLoadout(definition);
        loadout.Current.ConsumeRound();
        loadout.Current.BeginReload(60);
        loadout.SelectSlot(2);
        loadout.CompleteReloads(66);
        loadout.SelectSlot(0);
        Require(loadout.Current.Clip == 2 && loadout.Current.Reserve == 2 && loadout.Current.ReloadEnd == 0,
            "Inactive slot reload failed or changed selected-slot authority.");
        try
        {
            loadout.SelectSlot(7);
            throw new Exception("An unsigned slot was selected.");
        }
        catch (InvalidOperationException)
        {
            Require(loadout.ActiveSlot == 0, "Rejected slot selection changed the current slot.");
        }
        var dictionary = (IDictionary<int, PvpWeaponSlotState>)loadout.Slots;
        try
        {
            dictionary.Remove(0);
        }
        catch (NotSupportedException)
        {
            return;
        }
        throw new InvalidOperationException("Read-only loadout membership exposed its mutable dictionary.");
    }

    private static void CheckStateOwnership()
    {
        const BindingFlags Members = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        Type player = typeof(MatchEngine).GetNestedType("Player", BindingFlags.NonPublic)!;
        foreach (string name in new[] { "Clip", "Reserve", "ReloadEnd", "NextFire", "ActiveSlot", "Weapons" })
        {
            Require(player.GetField(name, Members) == null && player.GetProperty(name, Members)?.SetMethod == null,
                "The engine retained independently writable weapon state: " + name);
        }
        foreach (string name in new[] { "Clip", "Reserve", "ReloadEnd", "NextFire" })
        {
            Require(typeof(PvpWeaponSlotState).GetProperty(name, Members)?.SetMethod?.IsPrivate == true,
                "A weapon slot can be assigned outside its owner: " + name);
        }
        Require(typeof(MatchEngine).GetNestedType("WeaponRuntime", BindingFlags.NonPublic) == null,
            "The engine retained a duplicate weapon-state owner.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
