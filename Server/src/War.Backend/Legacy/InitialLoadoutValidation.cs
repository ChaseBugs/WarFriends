using System.Globalization;
using System.Text.Json;

namespace War.Backend.Legacy;

/// <summary>Checks complete initial shapes and forbids purchase, borrowing, delivery and parts grants.</summary>
internal static class InitialLoadoutValidation
{
    internal const int SubsystemCount = 3;
    private const int WeaponCount = 66;
    private const int UnitCount = 24;
    private const int VisualCount = 86;
    private const int SlotCount = 4;
    private static readonly string[] InitialWeapons =
    ["Google2u.AssaultRifle_AK47", "Google2u.SniperRifle_M24", "Google2u.Grenade_FRAG", "Google2u.Pistol_Remmington51"];
    private static readonly string[] InitialVisuals =
    ["CAMOS_DEFAULT", "HELMETS_EMPTY", "HEAD_EMPTY", "BANDS_EMPTY"];
    private static readonly HashSet<string> InitiallyEquippedUnits = new(StringComparer.Ordinal)
    {
        "Google2u.DBUpgradeSlotsAssaulter", "Google2u.DBUpgradeSlotsShotgunner",
        "Google2u.DBUpgradeSlotsGrennader", "Google2u.DBUpgradeSlotsMachineGunner"
    };

    internal static void Validate(JsonElement serialized)
    {
        Exact(serialized, "InventoryData", "LevelManagerData", "DecalManagerData");
        ValidateInventory(serialized.GetProperty("InventoryData"));
        JsonElement levels = serialized.GetProperty("LevelManagerData");
        Exact(levels, "savedArmies", "savedWeapons", "unitDelivery", "weaponDelivery");
        ValidateWeapons(levels.GetProperty("savedWeapons"));
        ValidateUnits(levels.GetProperty("savedArmies"));
        ValidateDelivery(levels.GetProperty("unitDelivery"));
        ValidateDelivery(levels.GetProperty("weaponDelivery"));
        ValidateDecals(serialized.GetProperty("DecalManagerData"));
    }

    private static void ValidateInventory(JsonElement inventory)
    {
        Exact(inventory, "slots");
        JsonElement slots = inventory.GetProperty("slots");
        RequireObjectCount(slots, SlotCount);
        for (int i = 0; i < SlotCount; i++)
        {
            JsonElement slot = slots.GetProperty(i.ToString(CultureInfo.InvariantCulture));
            Exact(slot, "name", "weaponIndex");
            if (slot.GetProperty("name").GetString() != InitialWeapons[i])
            {
                throw new InvalidDataException("An initial equipped weapon differs from the source selection.");
            }
            BattleClientWeaponIndices.ResolveInventoryIndex(
                InitialWeapons[i], slot.GetProperty("weaponIndex").GetInt32());
        }
    }

    private static void ValidateWeapons(JsonElement weapons)
    {
        RequireObjectCount(weapons, WeaponCount);
        foreach (JsonProperty weapon in weapons.EnumerateObject())
        {
            if (!BattleClientWeaponIndices.IsKnownSource(weapon.Name))
            {
                throw new InvalidDataException("An initial weapon identity is unknown.");
            }
            Exact(weapon.Value, "bought", "boughtIndex", "showed", "borrowed");
            RequireFalse(weapon.Value, "bought", "borrowed");
            RequireZero(weapon.Value, "boughtIndex");
            _ = weapon.Value.GetProperty("showed").GetBoolean();
        }
    }

    private static void ValidateUnits(JsonElement units)
    {
        RequireObjectCount(units, UnitCount);
        int equippedCount = 0;
        foreach (JsonProperty unit in units.EnumerateObject())
        {
            Exact(unit.Value, "bought", "boughtIndex", "specialSlot", "showed", "tier", "borrowed",
                "wasEquipped", "equipped", "eliteSlot", "parts");
            RequireFalse(unit.Value, "bought", "borrowed");
            RequireZero(unit.Value, "boughtIndex", "specialSlot", "eliteSlot", "parts");
            bool equipped = InitiallyEquippedUnits.Contains(unit.Name);
            int tier = unit.Value.GetProperty("tier").GetInt32();
            if (!unit.Name.StartsWith("Google2u.DBUpgradeSlots", StringComparison.Ordinal) ||
                tier < 1 || tier > 6 || unit.Value.GetProperty("equipped").GetBoolean() != equipped ||
                unit.Value.GetProperty("wasEquipped").GetBoolean() != equipped)
            {
                throw new InvalidDataException("An initial unit differs from the source equipment state.");
            }
            _ = unit.Value.GetProperty("showed").GetBoolean();
            if (equipped)
            {
                equippedCount++;
            }
        }
        if (equippedCount != InitiallyEquippedUnits.Count)
        {
            throw new InvalidDataException("An initial equipped unit is missing.");
        }
    }

    private static void ValidateDecals(JsonElement decals)
    {
        Exact(decals, "visuals", "slots", "previousHeadDecal");
        JsonElement visuals = decals.GetProperty("visuals");
        RequireObjectCount(visuals, VisualCount);
        foreach (JsonProperty visual in visuals.EnumerateObject())
        {
            Exact(visual.Value, "bought", "showed", "expiresOn", "borrowed", "parts", "notificate");
            RequireFalse(visual.Value, "bought", "showed", "borrowed", "notificate");
            RequireZero(visual.Value, "expiresOn", "parts");
        }
        JsonElement slots = decals.GetProperty("slots");
        RequireObjectCount(slots, SlotCount);
        for (int i = 0; i < SlotCount; i++)
        {
            JsonElement slot = slots.GetProperty(i.ToString(CultureInfo.InvariantCulture));
            Exact(slot, "equippedID");
            if (slot.GetProperty("equippedID").GetString() != InitialVisuals[i] ||
                !visuals.TryGetProperty(InitialVisuals[i], out _))
            {
                throw new InvalidDataException("An initial visual selection differs from the source.");
            }
        }
        if (decals.GetProperty("previousHeadDecal").GetString() != "")
        {
            throw new InvalidDataException("Initial visual history is not empty.");
        }
    }

    private static void ValidateDelivery(JsonElement delivery)
    {
        Exact(delivery, "activationNeeded", "boughtIndex", "end", "itemId", "slotId", "start");
        RequireFalse(delivery, "activationNeeded");
        RequireZero(delivery, "boughtIndex", "end", "slotId", "start");
        if (delivery.GetProperty("itemId").ValueKind != JsonValueKind.Null)
        {
            throw new InvalidDataException("Initial state must not create a delivery.");
        }
    }

    internal static void Exact(JsonElement value, params string[] fields)
    {
        RequireObjectCount(value, fields.Length);
        if (!value.EnumerateObject().Select(field => field.Name).Order(StringComparer.Ordinal)
            .SequenceEqual(fields.Order(StringComparer.Ordinal)))
        {
            throw new InvalidDataException("The initial state has unknown or missing fields.");
        }
    }

    private static void RequireObjectCount(JsonElement value, int count)
    {
        if (value.ValueKind != JsonValueKind.Object || value.EnumerateObject().Count() != count ||
            value.EnumerateObject().Select(field => field.Name).Distinct(StringComparer.Ordinal).Count() != count)
        {
            throw new InvalidDataException("The initial state has an invalid or duplicate record set.");
        }
    }

    private static void RequireFalse(JsonElement value, params string[] fields)
    {
        foreach (string field in fields)
        {
            if (value.GetProperty(field).GetBoolean())
            {
                throw new InvalidDataException("Initial state must not grant purchased or borrowed items.");
            }
        }
    }

    private static void RequireZero(JsonElement value, params string[] fields)
    {
        foreach (string field in fields)
        {
            if (value.GetProperty(field).GetInt64() != 0)
            {
                throw new InvalidDataException("Initial state must not grant progression, parts or delivery time.");
            }
        }
    }
}
