using System.Text.Json.Nodes;
using static War.Backend.Legacy.Buffering.LegacyBufferedResults;

namespace War.Backend.Legacy.Buffering.Inventory;

internal static class LegacyBufferedEquipment
{
    /// <summary>
    /// Moves a weapon into an inventory slot. The server checks ownership, which is why the client
    /// has a <see cref="DatabaseResult.WeaponNotBought"/> branch for this action carrying the state
    /// to revert to.
    /// </summary>
    internal static (DatabaseResult, JsonObject) EquipWeapon(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["Name"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }
        if (!int.TryParse(payload["SlotIndex"]?.ToString(), out int slotIndex) || slotIndex is < 0 or > 32)
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }
        int.TryParse(payload["Index"]?.ToString(), out int weaponIndex);

        if (catalog.Row("Google2u.WeaponUpgrades", "NAME", name) == null ||
            !state.Levels.SavedWeapons.TryGetValue(name, out var weapon) || !(weapon.Bought || weapon.Borrowed))
        {
            // Hand back the authoritative weapon and inventory so the client reverts its slot.
            var rollback = Result(request.Action, DatabaseResult.WeaponNotBought);
            rollback["LevelName"] = name;
            rollback["Weapon"] = PlayerState.Write(
                state.Levels.SavedWeapons.GetValueOrDefault(name) ?? new SavedWeaponSlots());
            rollback["InventoryData"] = PlayerState.Write(state.Inventory);
            return (DatabaseResult.WeaponNotBought, rollback);
        }

        state.Inventory.Slots[slotIndex] = new SerializedSlotDetail { Name = name, WeaponIndex = weaponIndex };
        state.InventoryChanged();
        state.RecordClientArmyPower(payload["ArmyPower"]);
        return Ok(request);
    }

    /// <summary>
    /// Replaces the equipped/was-equipped flags across the army. The client sends only the units
    /// that carry a flag, so units it omits must have theirs cleared.
    /// </summary>
    internal static (DatabaseResult, JsonObject) UpdateEquippedUnits(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        if (payload?["equips"] is not JsonObject equips)
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        // Reject the whole request if any named unit is not owned, and hand back the stored army so
        // the client can revert — this is the CantEquipUnit branch of its ProcessBuffer.
        foreach (var (unitName, _) in equips)
        {
            if (catalog.PlayerUnit(unitName) == null ||
                !state.Levels.SavedArmies.TryGetValue(unitName, out var unit) || !(unit.Bought || unit.Borrowed))
            {
                var stored = new JsonObject();
                foreach (var (name, slots) in state.Levels.SavedArmies)
                {
                    stored[name] = PlayerState.Write(slots);
                }
                var rollback = Result(request.Action, DatabaseResult.CantEquipUnit);
                rollback["data"] = stored.ToJsonString();
                return (DatabaseResult.CantEquipUnit, rollback);
            }
        }

        foreach (var (_, slots) in state.Levels.SavedArmies)
        {
            slots.Equipped = false;
            slots.WasEquipped = false;
        }
        foreach (var (unitName, flags) in equips)
        {
            var slots = state.Levels.SavedArmies[unitName];
            slots.Equipped = LegacyBufferPayload.ReadFlag(flags, "equipped");
            slots.WasEquipped = LegacyBufferPayload.ReadFlag(flags, "wasEquipped");
        }
        state.LevelsChanged();
        state.RecordClientArmyPower(payload["armyPower"]);
        return Ok(request);
    }
}
