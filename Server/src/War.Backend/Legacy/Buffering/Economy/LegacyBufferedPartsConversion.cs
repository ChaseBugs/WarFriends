using System.Text.Json.Nodes;
using static War.Backend.Legacy.Buffering.LegacyBufferedCatalogValues;
using static War.Backend.Legacy.Buffering.LegacyBufferedResults;
using static War.Backend.Legacy.Buffering.LegacyBufferedSlots;

namespace War.Backend.Legacy.Buffering.Economy;

internal static class LegacyBufferedPartsConversion
{
    /// <summary>
    /// Answers <see cref="DatabaseAction.ConvertPartsToScraps"/> (208). Sells all of a unit's
    /// accumulated Elite Parts for Scraps at <c>Google2u.Constants.PartToScrapsSell</c> (verified
    /// <c>5</c>: 1 part = 5 scraps) — <c>ArmyLeftBuffDialog.BuffButtonConvertToScrapsClick</c> always
    /// converts the entire current amount, never a partial one, so the client's asserted
    /// <c>PartsToConvert</c>/<c>Scraps</c> must match the server's own stored parts count and
    /// recomputed total exactly, or the request is refused as <c>IncorrectPartsAmount</c> rather
    /// than trusting either client number.
    /// </summary>
    internal static (DatabaseResult, JsonObject) ConvertPartsToScraps(
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
            return Fail(request, DatabaseResult.EliteSlotLocked);
        }
        if (catalog.Constant("PartToScrapsSell") is not double sellRate)
        {
            return Fail(request, DatabaseResult.ServerMaintenance);
        }

        var unit = state.Levels.SavedArmies.GetValueOrDefault(name) ?? new SavedArmySlots();
        int currentParts = unit.Parts;
        int expectedScraps = (int)((float)currentParts * (float)sellRate);
        if (currentParts <= 0 ||
            RowInt(payload, "PartsToConvert") != currentParts || RowLong(payload, "Scraps") != expectedScraps)
        {
            return Fail(request, DatabaseResult.IncorrectPartsAmount);
        }

        Slot(state.Levels.SavedArmies, name).Parts = 0;
        state.AddScraps(expectedScraps);
        state.LevelsChanged();
        return Ok(request);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.ConvertScrapsToParts"/> (207). Fills a unit's Elite Parts
    /// the rest of the way to its current elite level's requirement, spending Scraps at
    /// <c>Google2u.Constants.PartToScrapsUpgrade</c> (verified <c>24</c> scraps per missing part) —
    /// <c>ArmyLeftBuffDialog.BuffButtonConvertToPartsClick</c> always fills the gap completely, so
    /// there is nothing to assert from the client: <c>Request.data</c> is just the unit's bare sheet
    /// name, matching <c>UpgradeSlots.GetSheetName()</c> being passed directly as <c>objData</c>, not
    /// wrapped in JSON like most other buffered payloads in this file.
    /// </summary>
    internal static (DatabaseResult, JsonObject) ConvertScrapsToParts(
        BufferedRequest request, LegacyBufferedState state, LegacyCatalog catalog)
    {
        string? name = request.Data;
        if (string.IsNullOrEmpty(name))
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
        if (track?.CanUpgradeElite(unit.EliteSlot) != true)
        {
            return Fail(request, DatabaseResult.WrongIndexToActivate);
        }

        var row = eliteRows![unit.EliteSlot];
        long upgradePriceParts = RowLong(row, "NEXTUPGRADEPRICEGOLD");
        long missingParts = upgradePriceParts - unit.Parts;
        if (missingParts <= 0)
        {
            return Fail(request, DatabaseResult.WrongIndexToActivate);
        }

        if (catalog.Constant("PartToScrapsUpgrade") is not double upgradeRate)
        {
            return Fail(request, DatabaseResult.ServerMaintenance);
        }
        long requiredScraps = (long)((float)missingParts * (float)upgradeRate);
        if (!state.TrySpendScraps(requiredScraps))
        {
            return Fail(request, DatabaseResult.NotEnoughScraps);
        }

        Slot(state.Levels.SavedArmies, name).Parts = (int)upgradePriceParts;
        state.LevelsChanged();
        return Ok(request);
    }
}
