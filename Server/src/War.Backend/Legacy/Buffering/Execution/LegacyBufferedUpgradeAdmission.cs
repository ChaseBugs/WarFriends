using System.Text.Json.Nodes;
using War.Backend.Legacy.Catalog;

namespace War.Backend.Legacy.Buffering;

internal static class LegacyBufferedUpgradeAdmission
{
    internal static bool CanCompleteWeaponUpgrade(
        LegacyBufferedState state, LegacyUpgradeTrack? track, int assertedIndex)
    {
        if (track == null || !state.Levels.SavedWeapons.TryGetValue(track.Identity, out SavedWeaponSlots? weapon) ||
            !weapon.Bought || !track.CanUpgradeNormal(weapon.BoughtIndex))
        {
            return false;
        }

        return MatchesNormalDelivery(state.Levels.WeaponDelivery, track.Identity, weapon.BoughtIndex) &&
            assertedIndex == weapon.BoughtIndex;
    }

    internal static bool CanCompleteUnitUpgrade(
        LegacyBufferedState state, LegacyUpgradeTrack? track, int assertedIndex)
    {
        if (track == null || !state.Levels.SavedArmies.TryGetValue(track.Identity, out SavedArmySlots? unit) ||
            !unit.Bought || !track.CanUpgradeNormal(unit.BoughtIndex, unit.Tier))
        {
            return false;
        }

        return MatchesNormalDelivery(state.Levels.UnitDelivery, track.Identity, unit.BoughtIndex) &&
            assertedIndex == unit.BoughtIndex;
    }

    private static bool MatchesNormalDelivery(ItemDelivery delivery, string identity, int currentIndex) =>
        delivery.ActivationNeeded && delivery.SlotId == 0 && delivery.ItemId == identity &&
        delivery.BoughtIndex == currentIndex;
}
