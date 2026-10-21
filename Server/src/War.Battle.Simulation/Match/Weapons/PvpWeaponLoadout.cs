using System.Collections.ObjectModel;

namespace War.BattleServer;

/// <summary>Owns fixed slot membership/selection and advances reloads on active and inactive weapons.</summary>
internal sealed class PvpWeaponLoadout
{
    private readonly Dictionary<int, PvpWeaponSlotState> _slots;

    internal PvpWeaponLoadout(ParticipantManifest participant)
    {
        WeaponSlotManifest[] definitions = participant.WeaponSlots ??
            [new WeaponSlotManifest(0, 0, participant.Weapon, participant.WeaponUpgrade ?? 0)];
        _slots = definitions.ToDictionary(slot => slot.Slot, slot => new PvpWeaponSlotState(slot));
        Slots = new ReadOnlyDictionary<int, PvpWeaponSlotState>(_slots);
        ActiveSlot = definitions[0].Slot;
    }

    internal IReadOnlyDictionary<int, PvpWeaponSlotState> Slots { get; }
    internal int ActiveSlot { get; private set; }
    internal PvpWeaponSlotState Current => _slots[ActiveSlot];

    internal void SelectSlot(int slot)
    {
        if (!_slots.ContainsKey(slot))
        {
            throw new InvalidOperationException("The selected weapon slot is not in the signed loadout.");
        }
        ActiveSlot = slot;
    }

    internal void CompleteReloads(ulong tick)
    {
        // Preserve manifest insertion order; replacing the dictionary with a frozen table could reorder it.
        foreach (PvpWeaponSlotState weapon in _slots.Values)
        {
            weapon.CompleteReload(tick);
        }
    }

    internal void CancelAllReloads()
    {
        foreach (PvpWeaponSlotState weapon in _slots.Values)
        {
            weapon.CancelReload();
        }
    }
}
