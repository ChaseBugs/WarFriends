using System.Text.Json.Nodes;
using War.Backend.Legacy.Progression;
using War.Backend.Legacy.Catalog;
using static War.Backend.Legacy.Buffering.LegacyBufferedCatalogValues;
using static War.Backend.Legacy.Buffering.LegacyBufferedDeliveryRules;
using static War.Backend.Legacy.Buffering.LegacyBufferedResults;
using static War.Backend.Legacy.Buffering.LegacyBufferedSlots;
using static War.Backend.Legacy.Buffering.LegacyBufferedUnitResults;

namespace War.Backend.Legacy.Buffering.Inventory;

internal static class LegacyBufferedUnits
{
    /// <summary>
    /// Buys an army unit outright. Same shape and authority model as <see cref="BuyWeapon"/>,
    /// priced from <c>Google2u.ArmyUpgrades</c> by the unit's <c>NAME</c> (its DBUpgradeSlots
    /// sheet type name, from <c>UpgradeSlots.GetSheetName()</c> = <c>excel.GetType().ToString()</c>).
    /// </summary>
    /// <remarks>
    /// Unlike weapons, unit rows carry no <c>PURCHASABLE</c> field at all — confirmed against the
    /// recovered <c>ArmyUpgrades</c> sheet — so there is no "not sold in the shop" gate to check;
    /// <c>CANBEBOUGHT</c> (again a level-gate index, not a boolean) is the only purchasability
    /// check. Same scope limits as <c>BuyWeapon</c>: instant delivery only, no discount validation.
    /// </remarks>
    internal static (DatabaseResult, JsonObject) BuyUnit(
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
            return UnitRollback(request, state, name, DatabaseResult.NoDiscountFound);
        }

        var row = catalog.PlayerUnit(name);
        if (row == null)
        {
            return UnitRollback(request, state, name, DatabaseResult.PriceNotFound);
        }

        if (RowLong(row, "DELIVERTIME") > 0)
        {
            return UnitRollback(request, state, name, DatabaseResult.ServerMaintenance);
        }

        var existing = state.Levels.SavedArmies.GetValueOrDefault(name);
        if (existing is { Bought: true })
        {
            return Ok(request);
        }

        int requiredDisplayLevel = RowInt(row, "CANBEBOUGHT");
        if (!LegacyRankGate.IsUnlocked(state.PlayerLevel, requiredDisplayLevel))
        {
            return UnitRollback(request, state, name, DatabaseResult.NotEnoughLevel);
        }

        long priceGold = RowLong(row, "PRICEGOLD");
        long priceWarbucks = RowLong(row, "PRICE");
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

        Slot(state.Levels.SavedArmies, name).Bought = true;
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// >Confirms a pending unit purchase delivery. See <see cref="LegacyBufferedWeapons.ActivateWeapon"/> —
    /// identical reasoning, unit side.
    /// </summary>
    internal static (DatabaseResult, JsonObject) ActivateUnit(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["LevelName"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        if (catalog.PlayerUnit(name) == null)
        {
            return UnitRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        }

        var unit = state.Levels.SavedArmies.GetValueOrDefault(name);
        if (unit is { Bought: true })
        {
            return Ok(request);
        }

        var delivery = state.Levels.UnitDelivery;
        if (delivery.ItemId != name)
        {
            return UnitRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        }
        if (state.Now < delivery.End)
        {
            return UnitRollback(request, state, name, DatabaseResult.TooSoonToActivate);
        }

        Slot(state.Levels.SavedArmies, name).Bought = true;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// >Pays Gold to confirm a pending unit purchase delivery immediately. See <see cref="ActivateUnit"/>.
    /// </summary>
    internal static (DatabaseResult, JsonObject) InstantBuyUnit(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["LevelName"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        if (catalog.PlayerUnit(name) == null)
        {
            return UnitRollback(request, state, name, DatabaseResult.WrongIndexToActivate);
        }

        var unit = state.Levels.SavedArmies.GetValueOrDefault(name);
        if (unit is { Bought: true })
        {
            return Ok(request);
        }

        var delivery = state.Levels.UnitDelivery;
        if (delivery.ItemId != name)
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

        Slot(state.Levels.SavedArmies, name).Bought = true;
        ClearDelivery(delivery);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// Promotes a unit to its next tier. Priced by nothing but a level gate: unlike every other
    /// action in this file, <c>UpgradeSlots.PromoteUnit()</c> has <b>no response reader at all</b>
    /// in the recovered client (confirmed: zero matches for "PromoteUnit" anywhere in
    /// <c>ServerResponseHandler.cs</c>) — so the returned <c>Result</c> code only needs to land on
    /// the correct side of the client's <c>&gt; 10</c> success/failure split; no rollback fields
    /// are ever read.
    /// </summary>
    /// <remarks>
    /// Gate is the player's <c>Level</c> against <c>Google2u.ArmyUpgrades</c>'
    /// <c>UNLOCKTIER2..UNLOCKTIER6</c> (tier 6 is max — <c>UpgradeSlots.GetUnlockTierLevel</c>
    /// returns the sentinel <c>999</c> beyond it, which no player level can ever reach). Current
    /// tier is <c>SavedArmySlots.Tier</c> if nonzero, else the row's <c>STARTINGTIER</c> — matching
    /// <c>UpgradeSlots.actualTier</c>'s own "0 means not yet set" fallback.
    /// </remarks>
    internal static (DatabaseResult, JsonObject) PromoteUnit(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["LevelName"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        var row = catalog.PlayerUnit(name);
        if (row == null)
        {
            return Fail(request, DatabaseResult.PriceNotFound);
        }

        var unit = state.Levels.SavedArmies.GetValueOrDefault(name);
        if (unit is not { Bought: true })
        {
            return Fail(request, DatabaseResult.WrongIndexToActivate);
        }

        int currentTier = unit.Tier != 0 ? unit.Tier : RowInt(row, "STARTINGTIER");
        int requiredDisplayLevel = GetUnlockTierLevel(row, currentTier);
        if (!LegacyRankGate.IsUnlocked(state.PlayerLevel, requiredDisplayLevel))
        {
            return Fail(request, DatabaseResult.NotEnoughLevel);
        }

        Slot(state.Levels.SavedArmies, name).Tier = currentTier + 1;
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>Reproduces <c>UpgradeSlots.GetUnlockTierLevel</c> exactly, including its tier-6-max sentinel.</summary>
    private static int GetUnlockTierLevel(LegacyCatalogRow row, int tier) => tier switch
    {
        1 => RowInt(row, "UNLOCKTIER2"),
        2 => RowInt(row, "UNLOCKTIER3"),
        3 => RowInt(row, "UNLOCKTIER4"),
        4 => RowInt(row, "UNLOCKTIER5"),
        5 => RowInt(row, "UNLOCKTIER6"),
        > 5 => 999,
        _ => 0
    };
}
