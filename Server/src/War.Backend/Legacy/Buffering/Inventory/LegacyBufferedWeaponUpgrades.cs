using System.Text.Json.Nodes;
using static War.Backend.Legacy.Buffering.LegacyBufferedCatalogValues;
using static War.Backend.Legacy.Buffering.LegacyBufferedDeliveryRules;
using static War.Backend.Legacy.Buffering.LegacyBufferedResults;
using static War.Backend.Legacy.Buffering.LegacyBufferedSlots;
using static War.Backend.Legacy.Buffering.LegacyBufferedUpgradeAdmission;

namespace War.Backend.Legacy.Buffering.Inventory;

internal static class LegacyBufferedWeaponUpgrades
{
    /// <summary>
    /// Starts a timed weapon upgrade delivery. Price and delivery time come from the weapon's own
    /// per-level Google2u sheet, whose type name is the same as the weapon's (e.g.
    /// <c>Google2u.AssaultRifle_AK47</c>), row <c>NEXTUPGRADEPRICE</c>/<c>NEXTUPGRADEPRICEGOLD</c>/
    /// <c>DELIVERYTIME</c> at the row index equal to the weapon's current <c>BoughtIndex</c>.
    /// </summary>
    /// <remarks>
    /// <para>This per-weapon sheet is a genuinely separate export from <c>Google2u.WeaponUpgrades</c>
    /// (the base weapon-info sheet) — confirmed from
    /// <c>WeaponLevelsSetup.uprgradesExcel = GetComponent&lt;Google2uComponentBase&gt;()</c>, a
    /// distinct component per weapon prefab. The map exporter captured essentially the full weapon
    /// (and, via <see cref="BuyUnitUpgrade"/>, unit) roster this way — an entirely unrecognised
    /// name is still the correct <see cref="DatabaseResult.PriceNotFound"/> case, not the expected
    /// common case. Field spelling is exactly as recovered: this sheet uses <c>DELIVERYTIME</c>,
    /// the base sheets use <c>DELIVERTIME</c> — not a typo to "fix".</para>
    /// <para>Only one weapon delivery is in flight at a time, matching the client's single shared
    /// <c>LevelManager.weaponDelivery</c> slot (not per-weapon): a second <c>BuyWeaponUpgrade</c>
    /// while one is pending is refused with <see cref="DatabaseResult.AlreadyUpgrading"/>. The
    /// client's own <c>BoughtIndex</c> assertion must match the server's stored value, or the
    /// request is stale relative to a change the server already applied
    /// (<see cref="DatabaseResult.WrongIndexToActivate"/>).</para>
    /// </remarks>
    internal static (DatabaseResult, JsonObject) BuyWeaponUpgrade(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["LevelName"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }
        if (RowLong(payload, "discount") > 0)
        {
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.NoDiscountFound);
        }

        var track = catalog.WeaponUpgrades(name);
        if (track == null)
        {
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.PriceNotFound);
        }
        var rows = track.NormalRows;

        var weapon = state.Levels.SavedWeapons.GetValueOrDefault(name) ?? new SavedWeaponSlots();
        if (!weapon.Bought)
        {
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.WeaponNotBought);
        }
        if (RowInt(payload, "BoughtIndex") != weapon.BoughtIndex)
        {
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        }
        if (!track.CanUpgradeNormal(weapon.BoughtIndex))
        {
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.AlreadyMaximumUpgrade);
        }
        if (!string.IsNullOrEmpty(state.Levels.WeaponDelivery.ItemId))
        {
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.AlreadyUpgrading);
        }

        var row = rows[weapon.BoughtIndex];
        long priceGold = RowLong(row, "NEXTUPGRADEPRICEGOLD");
        long priceWarbucks = RowLong(row, "NEXTUPGRADEPRICE");
        if (priceGold > 0)
        {
            if (!state.TrySpendGold(priceGold))
            {
                return WeaponUpgradeRollback(request, state, name, DatabaseResult.NotEnoughGold);
            }
        }
        else if (priceWarbucks > 0)
        {
            if (!state.TrySpendWarBucks(priceWarbucks))
            {
                return WeaponUpgradeRollback(request, state, name, DatabaseResult.NotEnoughWarbucks);
            }
        }

        long deliverySeconds = RowLong(row, "DELIVERYTIME");
        long now = state.Now;
        var delivery = state.Levels.WeaponDelivery;
        delivery.ItemId = name;
        delivery.SlotId = 0;
        delivery.BoughtIndex = weapon.BoughtIndex;
        delivery.Start = now;
        delivery.End = now + deliverySeconds;
        delivery.ActivationNeeded = true;
        state.LevelsChanged();

        var success = Result(request.Action, DatabaseResult.Success);
        success["DeliveryTime"] = deliverySeconds;
        return (DatabaseResult.Success, success);
    }

    /// <summary>
    /// Completes a weapon upgrade delivery once its timer has naturally elapsed. No charge — the
    /// price was already paid when the delivery started (<see cref="BuyWeaponUpgrade"/>).
    /// </summary>
    internal static (DatabaseResult, JsonObject) ActivateWeaponUpgrade(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["LevelName"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        var delivery = state.Levels.WeaponDelivery;
        if (!CanCompleteWeaponUpgrade(state, catalog.WeaponUpgrades(name), RowInt(payload, "BoughtIndex")))
        {
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        }
        if (state.Now < delivery.End)
        {
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.TooSoonToActivate);
        }

        Slot(state.Levels.SavedWeapons, name).BoughtIndex++;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// Pays Gold to complete a weapon upgrade delivery immediately, skipping the remaining wait.
    /// Price reproduces <c>MiscTools.ConvertTimeIntoGold</c>: <c>ceil(GoldCoefficient *
    /// minutes^GoldExpCoefficient * minutes)</c> over the seconds actually remaining, using the
    /// verified catalog constants — never the client's own <c>ExpectedPrice</c> assertion.
    /// </summary>
    internal static (DatabaseResult, JsonObject) InstantWeaponUpgrade(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["LevelName"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        var delivery = state.Levels.WeaponDelivery;
        if (!CanCompleteWeaponUpgrade(state, catalog.WeaponUpgrades(name), RowInt(payload, "BoughtIndex")))
        {
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        }

        if (catalog.Constant("GoldCoefficient") is not double goldCoefficient ||
            catalog.Constant("GoldExpCoefficient") is not double goldExpCoefficient)
        {
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.ServerMaintenance);
        }

        long remainingSeconds = Math.Max(0, delivery.End - state.Now);
        long price = ConvertTimeIntoGold(remainingSeconds, goldCoefficient, goldExpCoefficient);
        if (price > 0 && !state.TrySpendGold(price))
        {
            return WeaponUpgradeRollback(request, state, name, DatabaseResult.NotEnoughGold);
        }

        Slot(state.Levels.SavedWeapons, name).BoughtIndex++;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    private static (DatabaseResult, JsonObject) WeaponUpgradeRollback(
        BufferedRequest request, LegacyBufferedState state, string name, DatabaseResult code)
    {
        var rollback = Result(request.Action, code);
        rollback["LevelName"] = name;
        rollback["Weapon"] = PlayerState.Write(
            state.Levels.SavedWeapons.GetValueOrDefault(name) ?? new SavedWeaponSlots());
        rollback["weaponDelivery"] = PlayerState.Write(state.Levels.WeaponDelivery);
        rollback["WarBucks"] = state.CurrentWarBucks;
        rollback["Gold"] = state.CurrentGold;
        return (code, rollback);
    }
}
