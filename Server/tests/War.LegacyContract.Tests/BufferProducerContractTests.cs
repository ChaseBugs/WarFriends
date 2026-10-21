using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json.Linq;
using War.Backend.Legacy;
using War.Backend.Legacy.Buffering;
using War.Persistence;
using War.Persistence.Legacy.Buffers;

namespace War.LegacyContract.Tests;

/// <summary>Feeds real planner/projection output into the recovered Client callback without Mongo or Unity.</summary>
internal static class BufferProducerContractTests
{
    private const long Now = 1_700_000_000;
    private const int PromotionSeconds = 120;
    private const string MissingName = "missing-source-identity";

    internal static int Run()
    {
        var planner = new LegacyBufferPlanner(LegacyCatalog.Empty, LegacyBufferProcessor.SupportedActions,
            NullLogger.Instance);
        int checks = 0;
        foreach (DatabaseAction action in LegacyBufferProcessor.SupportedActions)
        {
            // These are actual malformed-input outcomes, not synthetic failures from the matrix.
            Check(planner, new BufferedRequest(0, action, null), null);
            checks++;
        }

        foreach (BufferProducerCase scenario in RollbackCases())
        {
            Check(planner, scenario.Request, scenario.Expected);
            checks++;
        }

        LegacyBufferPlanner pricedPlanner = CreatePricedPlanner();
        return checks + CheckOwnedCosmeticSuccess(pricedPlanner) + CheckPermanentCosmeticPurchase(pricedPlanner);
    }

    private static void Check(LegacyBufferPlanner planner, BufferedRequest request, DatabaseResult? expected)
    {
        var player = new LegacyPlayerDocument { Id = new string('a', 32), Gold = 50, WarBucks = 500 };
        LegacyBufferedMutation mutation = planner.Plan(player, request, Now, 7);
        BufferProducerCoverage.Record(request, mutation);
        if (expected != null && mutation.Result != (int)expected)
        {
            throw new InvalidOperationException($"{request.Action}: expected {expected}, got {mutation.Result}.");
        }

        string canonical = mutation.ResponseJson;
        var receipt = new LegacyBufferedActionResult(player, canonical, mutation.Delivery);
        JsonObjectToClient(receipt, request);
        // A later retry must consume the same outcome with the latest wallet, without changing receipt evidence.
        player.Gold = 80;
        player.WarBucks = 800;
        JsonObjectToClient(receipt, request);
        if (receipt.ResponseJson != canonical || mutation.Serialized.Count != 0)
        {
            throw new InvalidOperationException("Failure projection changed receipt evidence or planned a mutation.");
        }
    }

    private static void JsonObjectToClient(LegacyBufferedActionResult receipt, BufferedRequest request)
    {
        string json = LegacyBufferedResponse.Project(receipt, Now + 10, request).ToJsonString();
        BufferContractMatrixTests.Read(JObject.Parse(json), true);
    }

    private static IEnumerable<BufferProducerCase> RollbackCases()
    {
        foreach (DatabaseAction action in new[] { DatabaseAction.BuyWeapon, DatabaseAction.BuyUnit,
            DatabaseAction.BuyWeaponUpgrade, DatabaseAction.BuyUnitUpgrade })
        {
            string field = action is DatabaseAction.BuyWeapon or DatabaseAction.BuyUnit ? "Name" : "LevelName";
            yield return Case(action, "{\"" + field + "\":\"" + MissingName + "\"}", DatabaseResult.PriceNotFound);
            yield return Case(action, "{\"" + field + "\":\"" + MissingName + "\",\"discount\":1}",
                DatabaseResult.NoDiscountFound);
        }

        foreach (DatabaseAction action in new[] { DatabaseAction.ActivateWeapon, DatabaseAction.InstantBuyWeapon,
            DatabaseAction.ActivateUnit, DatabaseAction.InstantBuyUnit, DatabaseAction.ActivateWeaponUpgrade,
            DatabaseAction.InstantWeaponUpgrade, DatabaseAction.ActivateUnitUpgrade,
            DatabaseAction.InstantUnitUpgrade })
        {
            yield return Case(action, "{\"LevelName\":\"" + MissingName + "\"}", DatabaseResult.WrongIndexToActivate);
        }

        yield return Case(DatabaseAction.EquipWeapon, "{\"Name\":\"missing\",\"SlotIndex\":0}",
            DatabaseResult.WeaponNotBought);
        yield return Case(DatabaseAction.UpdateEquippedUnits, "{\"equips\":{\"missing\":{\"equipped\":true}}}",
            DatabaseResult.CantEquipUnit);
        yield return Case(DatabaseAction.EquipDecal, MissingName, DatabaseResult.DecalCategoryNotFound);
        yield return Case(DatabaseAction.BuyDecal, "{\"Name\":\"missing\",\"discount\":1}",
            DatabaseResult.NoDiscountFound);
        yield return Case(DatabaseAction.BuyCardPack, "{\"cardPack\":\"missing\"}", DatabaseResult.CardPackNotFound);
        yield return Case(DatabaseAction.BuyCardPack, "{\"cardPack\":\"missing\",\"discount\":1}",
            DatabaseResult.NoDiscountFound);
        yield return Case(DatabaseAction.UpgradeEliteSlot, "{\"LevelName\":\"missing\"}",
            DatabaseResult.WrongIndexToActivate);
    }

    private static LegacyBufferPlanner CreatePricedPlanner()
    {
        LegacyCatalog catalog = RecoveredCatalogFixture.Catalog;
        return new LegacyBufferPlanner(catalog, LegacyBufferProcessor.SupportedActions, NullLogger.Instance);
    }

    private static int CheckOwnedCosmeticSuccess(LegacyBufferPlanner planner)
    {
        var player = new LegacyPlayerDocument { Id = new string('a', 32) };
        var decals = new DecalManagerData();
        decals.Visuals["CAMOS_DEFAULT"] = new SavedPlayerVisual
        {
            Bought = true,
            ExpiresOn = (int)Now + PromotionSeconds
        };
        player.Serialized["DecalManagerData"] = PlayerState.Write(decals);
        var request = new BufferedRequest(0, DatabaseAction.BuyDecal, "{\"Name\":\"CAMOS_DEFAULT\"}");
        LegacyBufferedMutation mutation = planner.Plan(player, request, Now, 7);
        BufferProducerCoverage.Record(request, mutation);
        JObject response = JObject.Parse(mutation.ResponseJson);
        if (mutation.Result != (int)DatabaseResult.Success || (string?)response["DecalId"] != "CAMOS_DEFAULT" ||
            (int?)response["ExpiresOn"] != Now + PromotionSeconds ||
            mutation.Serialized.Count != 0 || mutation.Gold != player.Gold)
        {
            throw new InvalidOperationException("Owned cosmetic lost mandatory fields, expiry or no-op behavior.");
        }

        // The real Client has already created this visual during its optimistic purchase.
        BufferContractMatrixTests.Read(response, true);
        return 1;
    }

    private static int CheckPermanentCosmeticPurchase(LegacyBufferPlanner planner)
    {
        var player = new LegacyPlayerDocument { Id = new string('a', 32), Level = 42 };
        var decals = new DecalManagerData();
        decals.Visuals["CAMOS_DEFAULT"] = new SavedPlayerVisual { ExpiresOn = (int)Now - PromotionSeconds };
        player.Serialized["DecalManagerData"] = PlayerState.Write(decals);
        var request = new BufferedRequest(0, DatabaseAction.BuyDecal, "{\"Name\":\"CAMOS_DEFAULT\"}");

        LegacyBufferedMutation mutation = planner.Plan(player, request, Now, 7);
        BufferProducerCoverage.Record(request, mutation);
        DecalManagerData committed = PlayerState.Read<DecalManagerData>(mutation.Serialized["DecalManagerData"]);
        if (mutation.Result != (int)DatabaseResult.Success || !committed.Visuals["CAMOS_DEFAULT"].Bought ||
            committed.Visuals["CAMOS_DEFAULT"].ExpiresOn != 0)
        {
            throw new InvalidOperationException("Permanent purchase retained an old promotion expiry.");
        }

        player.Serialized["DecalManagerData"] = PlayerState.Write(committed);
        var receipt = new LegacyBufferedActionResult(player, mutation.ResponseJson);
        JObject response = JObject.Parse(LegacyBufferedResponse.Project(receipt, Now, request).ToJsonString());
        BufferContractMatrixTests.Read(response, true);
        if ((int?)response["ExpiresOn"] != 0)
        {
            throw new InvalidOperationException("New permanent ownership projected an old expiry.");
        }

        return 1;
    }

    private static BufferProducerCase Case(DatabaseAction action, string data, DatabaseResult result) =>
        new(new BufferedRequest(0, action, data), result);
}
