using System.Text.Json.Nodes;
using War.Backend.Legacy;
using War.Persistence;
using War.Persistence.Legacy.Buffers;

namespace War.LegacyContract.Tests;

/// <summary>Small synthetic catalog/actor setup; never a production release or live balance policy.</summary>
internal sealed class CatalogBufferFixture
{
    internal const long Now = 1_700_000_000;
    internal const int RandomSeed = 7;
    internal const string WeaponName = "fixture-weapon-wb";
    internal const string UnitName = "fixture-unit-wb";

    internal static LegacyCatalog DefaultCatalog { get; } = LoadCatalog("legacy-buffer-catalog.json");
    internal static LegacyCatalog MissingPolicyCatalog { get; } = LoadCatalog("legacy-buffer-missing-policy.json");

    internal LegacyCatalog Catalog { get; set; } = DefaultCatalog;
    internal LegacyPlayerDocument Player { get; } = new()
    {
        Id = new string('a', 32),
        Level = 42,
        Gold = 10_000,
        WarBucks = 10_000,
        Scraps = 1_000,
        Vip = (int)Now + 60
    };

    internal LevelManagerData Levels { get; } = new();
    internal CardManagerData Cards { get; } = new();
    internal DecalManagerData Decals { get; } = new();
    internal InventoryData Inventory { get; } = new();
    internal Action<LegacyBufferedMutation>? CheckMutation { get; set; }

    internal CatalogBufferFixture()
    {
        OwnWeapon("fixture-weapon-free");
        OwnUnit("fixture-unit-free");
        Decals.Visuals["fixture-visual-free"] = new SavedPlayerVisual { Bought = true };
        Inventory.Slots[0] = new SerializedSlotDetail { Name = "fixture-weapon-free", WeaponIndex = 1 };
        foreach (string quality in new[] { "bronze", "silver", "gold" })
        {
            Cards.CardData["fixture-card-" + quality] = new SavedCardData { Amount = 3 };
        }
    }

    internal void OwnWeapon(string name = WeaponName)
    {
        Levels.SavedWeapons[name] = new SavedWeaponSlots { Bought = true };
    }

    internal void OwnUnit(string name = UnitName)
    {
        Levels.SavedArmies[name] = new SavedArmySlots { Bought = true, Tier = 1 };
    }

    internal void Prepare()
    {
        Player.Serialized["LevelManagerData"] = PlayerState.Write(Levels);
        Player.Serialized["CardManagerData"] = PlayerState.Write(Cards);
        Player.Serialized["DecalManagerData"] = PlayerState.Write(Decals);
        Player.Serialized["InventoryData"] = PlayerState.Write(Inventory);
        Player.Serialized["PlayerAnalyticsData"] = "{\"lastSeenSquadChatTimeStampDB\":1699999980,\"opaqueCounter\":17}";
    }

    internal void Commit(LegacyBufferedMutation mutation)
    {
        foreach (KeyValuePair<string, string> replacement in mutation.Serialized)
        {
            Player.Serialized[replacement.Key] = replacement.Value;
        }

        Player.Gold = mutation.Gold;
        Player.WarBucks = mutation.WarBucks;
        Player.Scraps = mutation.Scraps;
        Player.ArmyPower = mutation.ArmyPower;
    }

    internal void ChangeCurrentAuthority(BufferedRequest request)
    {
        Player.Gold += 7;
        Player.WarBucks += 11;
        LevelManagerData current = PlayerState.Read<LevelManagerData>(Player.Serialized["LevelManagerData"]);
        foreach (SavedWeaponSlots weapon in current.SavedWeapons.Values)
        {
            weapon.Showed = !weapon.Showed;
        }

        foreach (SavedArmySlots unit in current.SavedArmies.Values)
        {
            unit.WasEquipped = !unit.WasEquipped;
        }

        ChangeRequestedItem(current, request);
        current.SavedWeapons["fixture-weapon-gold"] = new SavedWeaponSlots { Bought = true };
        current.SavedArmies["fixture-unit-gold"] = new SavedArmySlots { Bought = true, Tier = 1 };
        current.WeaponDelivery = NewDelivery("fixture-weapon-gold");
        current.UnitDelivery = NewDelivery("fixture-unit-gold");

        Player.Serialized["LevelManagerData"] = PlayerState.Write(current);
        Cards.CardData["fixture-card-bronze"].Amount = 19;
        Player.Serialized["CardManagerData"] = PlayerState.Write(Cards);
        Inventory.Slots[0].WeaponIndex = 2;
        Player.Serialized["InventoryData"] = PlayerState.Write(Inventory);
        DecalManagerData decals = PlayerState.Read<DecalManagerData>(Player.Serialized["DecalManagerData"]);
        decals.Visuals["fixture-visual-free"].Notificate = true;
        Player.Serialized["DecalManagerData"] = PlayerState.Write(decals);
    }

    private static void ChangeRequestedItem(LevelManagerData levels, BufferedRequest request)
    {
        if (request.Data == null || !request.Data.StartsWith('{') ||
            JsonNode.Parse(request.Data) is not JsonObject payload)
        {
            return;
        }

        string? name = payload["LevelName"]?.GetValue<string>() ?? payload["Name"]?.GetValue<string>();
        if (name?.StartsWith("fixture-weapon-", StringComparison.Ordinal) == true)
        {
            levels.SavedWeapons[name] = new SavedWeaponSlots { Bought = true, BoughtIndex = 1, Showed = true };
        }
        else if (name?.StartsWith("fixture-unit-", StringComparison.Ordinal) == true)
        {
            levels.SavedArmies[name] = new SavedArmySlots { Bought = true, BoughtIndex = 1, Tier = 1, Showed = true };
        }
    }

    private static ItemDelivery NewDelivery(string name) => new()
    {
        ItemId = name,
        Start = Now - 1,
        End = Now + 120,
        ActivationNeeded = true
    };

    private static LegacyCatalog LoadCatalog(string name)
    {
        return LegacyCatalog.Load(Path.Combine(AppContext.BaseDirectory, "Fixtures", name));
    }
}
