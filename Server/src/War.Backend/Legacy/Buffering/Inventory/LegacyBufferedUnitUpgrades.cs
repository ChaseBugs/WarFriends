using System.Text.Json.Nodes;
using War.Backend.Legacy.Catalog;
using static War.Backend.Legacy.Buffering.LegacyBufferedCatalogValues;
using static War.Backend.Legacy.Buffering.LegacyBufferedDeliveryRules;
using static War.Backend.Legacy.Buffering.LegacyBufferedResults;
using static War.Backend.Legacy.Buffering.LegacyBufferedSlots;
using static War.Backend.Legacy.Buffering.LegacyBufferedUnitResults;
using static War.Backend.Legacy.Buffering.LegacyBufferedUpgradeAdmission;

namespace War.Backend.Legacy.Buffering.Inventory;

internal static class LegacyBufferedUnitUpgrades
{
    /// <summary>
    /// Starts a timed unit upgrade delivery for the unit's <b>normal</b> upgrade track. Same
    /// pattern as <see cref="BuyWeaponUpgrade"/>: price/delivery time from the unit's own
    /// per-level <c>Google2u.DBUpgradeSlots&lt;Type&gt;</c> sheet (confirmed against
    /// <c>DBUpgradeSlotsAssaulter</c>: 136 rows, same <c>NEXTUPGRADEPRICE</c>/
    /// <c>NEXTUPGRADEPRICEGOLD</c>/<c>DELIVERYTIME</c> field names as the per-weapon sheets), at
    /// the row index equal to the unit's current <c>BoughtIndex</c>.
    /// </summary>
    /// <remarks>
    /// <para>The client also has a <b>special</b> upgrade track (<c>UpgradeSlots.upgradeSlotSpecial</c>,
    /// requested with <c>IsSpecial=1</c>, tracked by <c>SavedArmySlots.specialSlot</c>), priced from
    /// the <i>same</i> per-unit sheet at a different validated lane. It
    /// remains refused here: reproducing <c>UpgradeSlots.actualMaxLevel</c>'s further tier-gating of
    /// that track (itself gated by <see cref="PromoteUnit"/>'s tier) is out of scope for this pass.
    /// </para>
    /// <para><b>Found and fixed a real bug while tracing that track</b>: the per-unit sheet's row
    /// count is <i>not</i> the normal track's true maximum whenever a unit also has special/elite
    /// rows appended after it (confirmed on <c>DBUpgradeSlotsAssaulter</c>: 136 raw rows split into
    /// 101 normal + 26 special + 6 elite + 3 unused padding, via the row's own <c>TIER</c> column —
    /// <c>UpgradeSlot.maxPower</c> counts only rows where <c>Tier / 10</c> matches the track).
    /// Using the raw row count as the ceiling would have let a sufficiently-leveled unit buy past
    /// its real normal-track max and silently price from a special/elite row instead. See
    /// <c>LegacyUpgradeTrack.NormalRows</c>, bound and cached at catalog load.</para>
    /// </remarks>
    internal static (DatabaseResult, JsonObject) BuyUnitUpgrade(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["LevelName"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }
        if (LegacyBufferPayload.ReadString(payload["IsSpecial"]) == "1")
        {
            return UnitRollback(request, state, name, DatabaseResult.ServerMaintenance);
        }
        if (RowLong(payload, "discount") > 0)
        {
            return UnitRollback(request, state, name, DatabaseResult.NoDiscountFound);
        }

        var track = catalog.UnitUpgrades(name);
        if (track == null)
        {
            return UnitRollback(request, state, name, DatabaseResult.PriceNotFound);
        }
        var rows = track.NormalRows;

        // Unlike the weapon-side failure set, the client's BuyUnit/upgrade case block has no
        // WeaponNotBought-equivalent code for "you don't own this" — the shop UI never offers an
        // upgrade action for an unowned unit. An unowned unit's BoughtIndex is always its zero
        // default, so a genuine client would never assert a match here either way; treat it as
        // the same state-mismatch case as an outdated BoughtIndex.
        var unit = state.Levels.SavedArmies.GetValueOrDefault(name) ?? new SavedArmySlots();
        if (!unit.Bought || RowInt(payload, "BoughtIndex") != unit.BoughtIndex)
        {
            return UnitRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        }
        if (!track.CanUpgradeNormal(unit.BoughtIndex, unit.Tier))
        {
            return UnitRollback(request, state, name, DatabaseResult.AlreadyMaximumUpgrade);
        }
        if (!string.IsNullOrEmpty(state.Levels.UnitDelivery.ItemId))
        {
            return UnitRollback(request, state, name, DatabaseResult.AlreadyUpgrading);
        }

        var row = rows[unit.BoughtIndex];
        long priceGold = RowLong(row, "NEXTUPGRADEPRICEGOLD");
        long priceWarbucks = RowLong(row, "NEXTUPGRADEPRICE");
        if (priceGold > 0)
        {
            if (!state.TrySpendGold(priceGold))
            {
                return UnitRollback(request, state, name, DatabaseResult.NotEnoughGold);
            }
        }
        else if (priceWarbucks > 0)
        {
            if (!state.TrySpendWarBucks(priceWarbucks))
            {
                return UnitRollback(request, state, name, DatabaseResult.NotEnoughWarbucks);
            }
        }

        long deliverySeconds = RowLong(row, "DELIVERYTIME");
        long now = state.Now;
        var delivery = state.Levels.UnitDelivery;
        delivery.ItemId = name;
        delivery.SlotId = 0;
        delivery.BoughtIndex = unit.BoughtIndex;
        delivery.Start = now;
        delivery.End = now + deliverySeconds;
        delivery.ActivationNeeded = true;
        state.LevelsChanged();

        var success = Result(request.Action, DatabaseResult.Success);
        success["DeliveryTime"] = deliverySeconds;
        return (DatabaseResult.Success, success);
    }

    /// <summary>Completes a unit upgrade delivery once its timer has naturally elapsed. No charge.</summary>
    internal static (DatabaseResult, JsonObject) ActivateUnitUpgrade(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["LevelName"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        var delivery = state.Levels.UnitDelivery;
        if (!CanCompleteUnitUpgrade(state, catalog.UnitUpgrades(name), RowInt(payload, "BoughtIndex")))
        {
            return UnitRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        }
        if (state.Now < delivery.End)
        {
            return UnitRollback(request, state, name, DatabaseResult.TooSoonToActivate);
        }

        Slot(state.Levels.SavedArmies, name).BoughtIndex++;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// >Pays Gold to complete a unit upgrade delivery immediately. Same formula as <see
    /// cref="LegacyBufferedWeaponUpgrades.InstantWeaponUpgrade"/>.
    /// </summary>
    internal static (DatabaseResult, JsonObject) InstantUnitUpgrade(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["LevelName"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        var delivery = state.Levels.UnitDelivery;
        if (!CanCompleteUnitUpgrade(state, catalog.UnitUpgrades(name), RowInt(payload, "BoughtIndex")))
        {
            return UnitRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        }

        if (catalog.Constant("GoldCoefficient") is not double goldCoefficient ||
            catalog.Constant("GoldExpCoefficient") is not double goldExpCoefficient)
        {
            return UnitRollback(request, state, name, DatabaseResult.ServerMaintenance);
        }

        long remainingSeconds = Math.Max(0, delivery.End - state.Now);
        long price = ConvertTimeIntoGold(remainingSeconds, goldCoefficient, goldExpCoefficient);
        if (price > 0 && !state.TrySpendGold(price))
        {
            return UnitRollback(request, state, name, DatabaseResult.NotEnoughGold);
        }

        Slot(state.Levels.SavedArmies, name).BoughtIndex++;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }
}
