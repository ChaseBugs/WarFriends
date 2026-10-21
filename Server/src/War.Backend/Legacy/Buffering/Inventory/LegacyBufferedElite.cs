using System.Text.Json.Nodes;
using War.Backend.Legacy.Catalog;
using static War.Backend.Legacy.Buffering.LegacyBufferedCatalogValues;
using static War.Backend.Legacy.Buffering.LegacyBufferedResults;
using static War.Backend.Legacy.Buffering.LegacyBufferedSlots;

namespace War.Backend.Legacy.Buffering.Inventory;

internal static class LegacyBufferedElite
{
    /// <summary>
    /// Answers <see cref="DatabaseAction.UpgradeEliteSlot"/> (209). Confirmed by source: the elite
    /// track's validated <c>LegacyUpgradeTrack.EliteRows</c> lane repurposes the same two price
    /// columns the normal track uses for currency: <c>NEXTUPGRADEPRICEGOLD</c> is actually the
    /// <b>Elite Parts</b> required (<c>UpgradeSlotElite.upgradePriceParts</c>), and
    /// <c>NEXTUPGRADEPRICE</c> is the <b>Warbucks</b> price to buy the level outright instead of
    /// grinding parts (<c>ArmyScreen.UpgradeUnitElite</c>) — column names are exactly as recovered,
    /// not renamed. <c>ArmyScreen.BuyUnitElite</c>/<c>UpgradeUnitElite</c> both always assert
    /// <c>SpentParts == upgradePriceParts</c> and decrement <c>currentParts</c> by that amount
    /// regardless of which path is used (clamped at 0 here — a defensive floor, not new gameplay
    /// logic, since the client's own unclamped local subtraction can go negative). No client-visible
    /// discount field exists for this action (unlike <c>BuyWeaponUpgrade</c>/<c>BuyUnitUpgrade</c>'s
    /// <c>discount</c>), so <c>SpentWarbucks</c> must be exactly <c>0</c> or the row's undiscounted
    /// price — <c>OfferManager.DiscountedUnit</c>'s special-offer system is untraced and out of
    /// scope, matching every other discount/offer path in this file. None of this action's evidenced
    /// failure branches (<c>WrongIndexToActivate</c>/<c>NotEnoughWarbucks</c>/<c>NotEnoughParts</c>/
    /// <c>IncorrectValuesOnClient</c>) read any response field — each just shows an error dialog and
    /// forces a relog, which re-syncs everything via a fresh <c>GetPlayerData</c> — so a bare
    /// <c>Result</c> is the entire failure contract, unlike most other economy actions in this file.
    /// </summary>
    internal static (DatabaseResult, JsonObject) UpgradeEliteSlot(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = LegacyBufferPayload.ReadString(payload?["LevelName"]);
        if (payload == null || string.IsNullOrEmpty(name))
        {
            return Fail(request, DatabaseResult.WrongPlayerData);
        }

        var armyRow = catalog.PlayerUnit(name);
        if (armyRow == null || RowInt(armyRow, "STARTINGELITE") <= 0)
        {
            return Fail(request, DatabaseResult.WrongIndexToActivate);
        }

        var track = catalog.UnitUpgrades(name);
        var eliteRows = track?.EliteRows;
        var unit = state.Levels.SavedArmies.GetValueOrDefault(name) ?? new SavedArmySlots();
        if (RowInt(payload, "BoughtIndex") != unit.EliteSlot)
        {
            return Fail(request, DatabaseResult.WrongIndexToActivate);
        }
        if (track?.CanUpgradeElite(unit.EliteSlot) != true)
        {
            return Fail(request, DatabaseResult.WrongIndexToActivate);
        }

        var row = eliteRows![unit.EliteSlot];
        long requiredParts = RowLong(row, "NEXTUPGRADEPRICEGOLD");
        long fullPrice = RowLong(row, "NEXTUPGRADEPRICE");

        if (RowLong(payload, "SpentParts") != requiredParts)
        {
            return Fail(request, DatabaseResult.IncorrectValuesOnClient);
        }
        long spentWarbucks = RowLong(payload, "SpentWarbucks");
        if (spentWarbucks != 0 && spentWarbucks != fullPrice)
        {
            return Fail(request, DatabaseResult.IncorrectValuesOnClient);
        }

        if (spentWarbucks > 0)
        {
            if (!state.TrySpendWarBucks(spentWarbucks))
            {
                return Fail(request, DatabaseResult.NotEnoughWarbucks);
            }
        }
        else if (unit.Parts < requiredParts)
        {
            return Fail(request, DatabaseResult.NotEnoughParts);
        }

        var slot = Slot(state.Levels.SavedArmies, name);
        slot.Parts = Math.Max(0, slot.Parts - (int)requiredParts);
        slot.EliteSlot++;
        state.LevelsChanged();
        return Ok(request);
    }

}
