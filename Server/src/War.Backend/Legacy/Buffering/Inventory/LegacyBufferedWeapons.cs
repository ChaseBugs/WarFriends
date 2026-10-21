using System.Text.Json.Nodes;
using War.Backend.Legacy.Progression;
using static War.Backend.Legacy.Buffering.LegacyBufferedCatalogValues;
using static War.Backend.Legacy.Buffering.LegacyBufferedDeliveryRules;
using static War.Backend.Legacy.Buffering.LegacyBufferedResults;
using static War.Backend.Legacy.Buffering.LegacyBufferedSlots;

namespace War.Backend.Legacy.Buffering.Inventory;

internal static class LegacyBufferedWeapons
{
    /// <summary>
    /// Buys a weapon outright. Price, unlock gating and purchasability come from the recovered
    /// <c>Google2u.WeaponUpgrades</c> catalog by the weapon's <c>NAME</c> — the client's own
    /// asserted <c>Warbucks</c>/<c>Gold</c>/<c>UnlockLevel</c> request fields are never trusted,
    /// the same authority model as every other buffered economy action.
    /// </summary>
    /// <remarks>
    /// <para>Scope: only <c>DELIVERTIME == 0</c> (instant) weapons. A weapon with a nonzero
    /// delivery time needs a separate completion action this pass does not implement, so it is
    /// refused with <see cref="DatabaseResult.ServerMaintenance"/> rather than starting a timer
    /// that can never finish.</para>
    /// <para>Any nonzero client-asserted <c>discount</c> is refused the same way: there is no
    /// verified server-side sale/event system yet to validate a discount percentage against.</para>
    /// <para><c>CANBEBOUGHT</c> is the row's level-gate field, not a boolean, despite the name —
    /// confirmed from <c>WeaponLevelsSetup.canBeBought =&gt; currentLevel.index &gt;=
    /// weaponUpgradesRow.CANBEBOUGHT - 1</c>. Re-buying an already-owned weapon is treated as an
    /// idempotent success (no charge), not an error: the shop UI never offers a buy action for a
    /// weapon already owned, so there is no evidenced failure code for that case to reuse.</para>
    /// </remarks>
    internal static (DatabaseResult, JsonObject) BuyWeapon(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["Name"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        if (RowLong(payload, "discount") > 0)
        {
            return WeaponRollback(request, state, name, DatabaseResult.NoDiscountFound);
        }

        var row = catalog.Row("Google2u.WeaponUpgrades", "NAME", name);
        if (row == null)
        {
            return WeaponRollback(request, state, name, DatabaseResult.PriceNotFound);
        }

        if (!string.Equals(RowString(row, "PURCHASABLE"), "shop", StringComparison.OrdinalIgnoreCase))
        {
            return WeaponRollback(request, state, name, DatabaseResult.WeaponNotBought);
        }

        if (RowLong(row, "DELIVERTIME") > 0)
        {
            return WeaponRollback(request, state, name, DatabaseResult.ServerMaintenance);
        }

        var existing = state.Levels.SavedWeapons.GetValueOrDefault(name);
        if (existing is { Bought: true })
        {
            return Ok(request);
        }

        int requiredDisplayLevel = RowInt(row, "CANBEBOUGHT");
        if (!LegacyRankGate.IsUnlocked(state.PlayerLevel, requiredDisplayLevel))
        {
            return WeaponRollback(request, state, name, DatabaseResult.NotEnoughLevel);
        }

        long priceGold = RowLong(row, "PRICEGOLD");
        long priceWarbucks = RowLong(row, "PRICE");
        if (priceGold > 0)
        {
            if (!state.TrySpendGold(priceGold))
            {
                return WeaponRollback(request, state, name, DatabaseResult.NotEnoughGold);
            }
        }
        else if (priceWarbucks > 0)
        {
            if (!state.TrySpendWarBucks(priceWarbucks))
            {
                return WeaponRollback(request, state, name, DatabaseResult.NotEnoughWarbucks);
            }
        }

        Slot(state.Levels.SavedWeapons, name).Bought = true;
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// Confirms a pending weapon purchase delivery. Shares its response case with
    /// <see cref="BuyWeapon"/> (<c>WeaponWasShown</c>/<c>InstantBuyWeapon</c>/<c>ActivateWeapon</c>/
    /// <c>BuyWeapon</c>/<c>BuyWeaponUpgrade</c>/<c>InstantWeaponUpgrade</c>/
    /// <c>ActivateWeaponUpgrade</c> are all one client-side case block).
    /// </summary>
    /// <remarks>
    /// <c>WeaponLevelsSetup.Buy()</c> only sets <c>bought=true</c> immediately for a
    /// gold-priced weapon; a Warbucks-priced or free one instead starts a delivery
    /// (<c>weaponDeliveryTime = weaponUpgradesRow.DELIVERTIME</c>), and the client's own
    /// <c>BuyWeapon()</c> UI method unconditionally queues this action right after — calling the
    /// local <c>ActivateWeapon()</c> immediately when that delivery time is zero. Since every
    /// weapon in the current export has <c>DELIVERTIME == 0</c>, <see cref="BuyWeapon"/> already
    /// finishes the purchase itself; this handler's job is simply to be safe to call afterward —
    /// an already-bought weapon is an idempotent success, exactly like re-buying one.
    /// </remarks>
    internal static (DatabaseResult, JsonObject) ActivateWeapon(BufferedRequest request, LegacyBufferedState state)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["LevelName"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        var weapon = state.Levels.SavedWeapons.GetValueOrDefault(name);
        if (weapon is { Bought: true })
        {
            return Ok(request);
        }

        var delivery = state.Levels.WeaponDelivery;
        if (delivery.ItemId != name)
        {
            return WeaponRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        }
        if (state.Now < delivery.End)
        {
            return WeaponRollback(request, state, name, DatabaseResult.TooSoonToActivate);
        }

        Slot(state.Levels.SavedWeapons, name).Bought = true;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// >Pays Gold to confirm a pending weapon purchase delivery immediately. See <see cref="ActivateWeapon"/>.
    /// </summary>
    internal static (DatabaseResult, JsonObject) InstantBuyWeapon(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["LevelName"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        var weapon = state.Levels.SavedWeapons.GetValueOrDefault(name);
        if (weapon is { Bought: true })
        {
            return Ok(request);
        }

        var delivery = state.Levels.WeaponDelivery;
        if (delivery.ItemId != name)
        {
            return WeaponRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        }

        if (catalog.Constant("GoldCoefficient") is not double goldCoefficient ||
            catalog.Constant("GoldExpCoefficient") is not double goldExpCoefficient)
        {
            return WeaponRollback(request, state, name, DatabaseResult.ServerMaintenance);
        }

        long remainingSeconds = Math.Max(0, delivery.End - state.Now);
        long price = ConvertTimeIntoGold(remainingSeconds, goldCoefficient, goldExpCoefficient);
        if (price > 0 && !state.TrySpendGold(price))
        {
            return WeaponRollback(request, state, name, DatabaseResult.NotEnoughGold);
        }

        Slot(state.Levels.SavedWeapons, name).Bought = true;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// The rollback shape every BuyWeapon failure branch shares: the current (unpurchased)
    /// authoritative weapon slot and current wallet balances, so the client's optimistic UI
    /// change reverts to true server state instead of an echoed, unvalidated client guess.
    /// </summary>
    private static (DatabaseResult, JsonObject) WeaponRollback(
        BufferedRequest request, LegacyBufferedState state, string name, DatabaseResult code)
    {
        var rollback = Result(request.Action, code);
        rollback["LevelName"] = name;
        rollback["Weapon"] = PlayerState.Write(
            state.Levels.SavedWeapons.GetValueOrDefault(name) ?? new SavedWeaponSlots());
        rollback["WarBucks"] = state.CurrentWarBucks;
        rollback["Gold"] = state.CurrentGold;
        return (code, rollback);
    }
}
