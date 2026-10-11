using System.Numerics;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private string UseDisarmed(Player owner, string requestId)
    {
        if (!HasSelectedCard(owner, "CardDisarmedAndLocked"))
            return "disarmed-not-selected";
        if (!Guid.TryParseExact(requestId, "N", out _) ||
            requestId != requestId.ToLowerInvariant())
            return "invalid-disarmed-request";
        if (cardReservations == null)
            return "card-inventory-disabled";
        if (events.Count >= MaximumRetainedEvents || stateRevision > ulong.MaxValue - 2)
            return "event-backpressure";

        Player opponent = players.Single(player => player != owner);
        if (!opponent.Admitted || opponent.Dead)
            return "disarmed-target-unavailable";

        // WeaponInventory.pistol returns the Pistol instance among usedWeapons.
        // Resolve that identity only from the host-signed loadout.
        var pistolSlots = opponent.Weapons
            .Where(slot => PistolCatalog.IsPistolSourceId(slot.Value.Definition.Weapon.SourceId))
            .ToArray();
        if (pistolSlots.Length != 1)
            return "disarmed-pistol-unavailable";

        var pistol = pistolSlots[0];
        var effect = new WarCardEffectRequest("CardDisarmedAndLocked",
            Vector3.Zero, 5, 0, "DISARMED");
        if (!TryApplyCardEffect(requestId, owner.Definition.PlayerId, effect))
            return "disarmed-unavailable";

        // The recovered card forces a pistol, then locks manual selection.
        // It leaves that pistol selected when its five-second timer expires.
        if (opponent.ActiveSlot != pistol.Key)
        {
            rifleCombat?.SwitchWeapon(opponent.Definition.PlayerId,
                pistol.Value.Definition.Weapon,
                pistol.Value.Definition.WeaponUpgrade);
            opponent.ActiveSlot = pistol.Key;
            stateRevision++;
        }
        return "disarmed-active";
    }

    private bool WeaponSwitchLocked(Player player)
    {
        Player opponent = players.Single(other => other != player);
        return cardEffects.HasActiveCard(opponent.Definition.PlayerId,
            "CardDisarmedAndLocked");
    }
}
