using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private string UseEmptyMag(Player owner, string requestId)
    {
        if (!HasSelectedCard(owner, "CardEmptyMag"))
            return "empty-mag-not-selected";
        if (!War.Shared.CanonicalGuid.IsCanonical(requestId))
            return "invalid-empty-mag-request";
        if (cardReservations == null)
            return "card-inventory-disabled";
        if (events.Count >= MaximumRetainedEvents || stateRevision > ulong.MaxValue - 2)
            return "event-backpressure";

        Player opponent = players.Single(player => player != owner);
        if (!opponent.Admitted || opponent.Dead || opponent.Weapons.Count == 0)
            return "empty-mag-target-unavailable";

        // CardEmptyMag targets WeaponInventory.usedWeapons[0], even when the
        // opponent is holding another slot. The signed loadout orders slots.
        var firstSlot = opponent.Weapons.OrderBy(pair => pair.Key).First();
        PvpWeaponSlotState firstWeapon = firstSlot.Value;
        if (firstWeapon.Clip < 0 || firstWeapon.Reserve < 0)
            return "empty-mag-target-unavailable";

        var effect = new WarCardEffectRequest("CardEmptyMag",
            Vector3.Zero, 0, 0, "EMPTYMAG");
        if (!TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect))
            return "empty-mag-unavailable";

        // The recovered ammoLeftInClip setter cancels an existing reload.
        // Weapon.Reload then starts a fresh one only with reserve ammunition.
        firstWeapon.EmptyMagazine(tick);
        if (opponent.ActiveSlot == firstSlot.Key)
            rifleCombat?.StopShooting(opponent.Definition.PlayerId);
        stateRevision++;
        return "enemy-mag-emptied";
    }
}
