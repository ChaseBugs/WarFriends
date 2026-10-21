using System.Text.Json.Nodes;
using War.Backend.Legacy;
using War.Persistence;
using War.Persistence.Legacy.Buffers;

namespace War.Battle.Tests.Legacy;

/// <summary>Checks that an old failed outcome cannot undo newer authoritative wallet and ownership state.</summary>
internal static class LegacyBufferedRollbackTests
{
    private const long NowUnixSeconds = 1_700_000_000;

    internal static int Run()
    {
        LegacyPlayerDocument player = CreateCurrentPlayer();
        JsonObject weapon = Project(player, DatabaseAction.EquipWeapon, DatabaseResult.WeaponNotBought, new JsonObject
        {
            ["LevelName"] = "weapon",
            ["Weapon"] = "{}",
            ["InventoryData"] = "{}"
        });
        Require(Read<SavedWeaponSlots>(weapon, "Weapon").Bought &&
            Read<InventoryData>(weapon, "InventoryData").Slots[0].Name == "weapon",
            "An old equip failure removed newer weapon ownership or its inventory slot.");

        JsonObject army = Project(player, DatabaseAction.UpdateEquippedUnits, DatabaseResult.CantEquipUnit,
            new JsonObject { ["data"] = "{}" });
        JsonObject armyData = JsonNode.Parse(army["data"]!.GetValue<string>())!.AsObject();
        Require(PlayerState.Read<SavedArmySlots>(armyData["unit"]!.GetValue<string>()).Bought,
            "An old army failure discarded a subsequently owned unit.");

        JsonObject weaponUpgrade = Project(player, DatabaseAction.BuyWeaponUpgrade,
            DatabaseResult.NotEnoughWarbucks, new JsonObject
        {
            ["LevelName"] = "weapon",
            ["Weapon"] = "{}",
            ["weaponDelivery"] = "{}",
            ["Gold"] = 0,
            ["WarBucks"] = 0
        });
        Require(weaponUpgrade["Gold"]!.GetValue<long>() == player.Gold &&
            weaponUpgrade["WarBucks"]!.GetValue<long>() == player.WarBucks &&
            Read<ItemDelivery>(weaponUpgrade, "weaponDelivery").End == NowUnixSeconds,
            "An old weapon failure restored stale balances or delivery state.");

        JsonObject unitUpgrade = Project(player, DatabaseAction.BuyUnitUpgrade,
            DatabaseResult.NotEnoughWarbucks, new JsonObject
        {
            ["LevelName"] = "unit",
            ["Unit"] = "{}",
            ["unitDelivery"] = "{}"
        });
        Require(Read<SavedArmySlots>(unitUpgrade, "Unit").Bought &&
            Read<ItemDelivery>(unitUpgrade, "unitDelivery").End == NowUnixSeconds,
            "An old unit failure restored stale progression or delivery state.");

        JsonObject visual = Project(player, DatabaseAction.BuyDecal, DatabaseResult.NotEnoughGold,
            new JsonObject { ["DecalManagerData"] = "{}" });
        Require(Read<DecalManagerData>(visual, "DecalManagerData").Visuals["visual"].Bought,
            "An old cosmetic failure removed a subsequently owned visual.");
        JsonObject cards = Project(player, DatabaseAction.BuyCardPack, DatabaseResult.NotEnoughWarbucks,
            new JsonObject { ["CardManagerData"] = "{}" });
        Require(Read<CardManagerData>(cards, "CardManagerData").CardData["card"].Amount == 4,
            "An old pack failure removed cards awarded by a later purchase.");
        player.Serialized["InventoryData"] = "null";
        bool hasRejectedDamage = false;
        try
        {
            Project(player, DatabaseAction.EquipWeapon, DatabaseResult.WeaponNotBought,
                new JsonObject { ["InventoryData"] = "{}" });
        }
        catch (InvalidDataException)
        {
            hasRejectedDamage = true;
        }

        Require(hasRejectedDamage, "Present damaged rollback state was normalized into an empty inventory.");
        return 7;
    }

    private static JsonObject Project(
        LegacyPlayerDocument player, DatabaseAction action, DatabaseResult result, JsonObject fields)
    {
        fields["ActionId"] = (int)action;
        fields["Result"] = (int)result;
        string canonical = fields.ToJsonString();
        var recorded = new LegacyBufferedActionResult(player, canonical);
        JsonObject projected = LegacyBufferedResponse.Project(recorded, NowUnixSeconds);
        Require(recorded.ResponseJson == canonical &&
            projected["Result"]!.GetValue<int>() == (int)result &&
            projected["ActionId"]!.GetValue<int>() == (int)action,
            "Rollback projection modified the stored outcome or action identity.");
        return projected;
    }

    private static LegacyPlayerDocument CreateCurrentPlayer()
    {
        var levels = new LevelManagerData();
        levels.SavedWeapons["weapon"] = new SavedWeaponSlots { Bought = true };
        levels.SavedArmies["unit"] = new SavedArmySlots { Bought = true };
        levels.WeaponDelivery.End = NowUnixSeconds;
        levels.UnitDelivery.End = NowUnixSeconds;
        var inventory = new InventoryData();
        inventory.Slots[0] = new SerializedSlotDetail { Name = "weapon" };
        var cards = new CardManagerData();
        cards.CardData["card"] = new SavedCardData { Amount = 4 };
        var visuals = new DecalManagerData();
        visuals.Visuals["visual"] = new SavedPlayerVisual { Bought = true };
        return new LegacyPlayerDocument
        {
            Gold = 10,
            WarBucks = 20,
            Serialized = new Dictionary<string, string>
            {
                ["LevelManagerData"] = PlayerState.Write(levels),
                ["InventoryData"] = PlayerState.Write(inventory),
                ["CardManagerData"] = PlayerState.Write(cards),
                ["DecalManagerData"] = PlayerState.Write(visuals)
            }
        };
    }

    private static T Read<T>(JsonObject response, string field) where T : new()
    {
        return PlayerState.Read<T>(response[field]!.GetValue<string>());
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
