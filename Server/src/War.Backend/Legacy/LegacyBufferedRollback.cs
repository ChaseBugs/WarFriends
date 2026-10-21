using System.Text.Json.Nodes;
using War.Persistence;

namespace War.Backend.Legacy;

/// <summary>Preserves a failed outcome while projecting its required rollback fields from current authority.</summary>
public static class LegacyBufferedRollback
{
    /// <summary>Refreshes only rollback fields already present in the recorded action response.</summary>
    public static void Refresh(JsonObject response, LegacyPlayerDocument player)
    {
        if (response["Result"]!.GetValue<int>() == (int)DatabaseResult.Success)
        {
            return;
        }

        RefreshBalance(response, "Gold", player.Gold);
        RefreshBalance(response, "WarBucks", player.WarBucks);
        RefreshBalance(response, "Scraps", player.Scraps);
        RefreshBlob<InventoryData>(response, player, "InventoryData");
        RefreshBlob<CardManagerData>(response, player, "CardManagerData");
        RefreshBlob<DecalManagerData>(response, player, "DecalManagerData");
        if (response.ContainsKey("Weapon") || response.ContainsKey("Unit") || response.ContainsKey("data") ||
            response.ContainsKey("weaponDelivery") || response.ContainsKey("unitDelivery"))
        {
            LevelManagerData levels = ReadBlob<LevelManagerData>(player, "LevelManagerData");
            RefreshItems(response, levels);
        }
    }

    private static void RefreshItems(JsonObject response, LevelManagerData levels)
    {
        string? name = LegacyBufferPayload.ReadString(response["LevelName"]);
        if (response.ContainsKey("Weapon"))
        {
            RequireItemName(name);
            response["Weapon"] = PlayerState.Write(
                levels.SavedWeapons.GetValueOrDefault(name!) ?? new SavedWeaponSlots());
        }

        if (response.ContainsKey("Unit"))
        {
            RequireItemName(name);
            response["Unit"] = PlayerState.Write(levels.SavedArmies.GetValueOrDefault(name!) ?? new SavedArmySlots());
        }

        if (response.ContainsKey("weaponDelivery"))
        {
            response["weaponDelivery"] = PlayerState.Write(levels.WeaponDelivery);
        }

        if (response.ContainsKey("unitDelivery"))
        {
            response["unitDelivery"] = PlayerState.Write(levels.UnitDelivery);
        }

        if (response.ContainsKey("data"))
        {
            var armies = new JsonObject();
            foreach (KeyValuePair<string, SavedArmySlots> entry in levels.SavedArmies)
            {
                armies[entry.Key] = PlayerState.Write(entry.Value);
            }

            response["data"] = armies.ToJsonString();
        }
    }

    private static void RefreshBalance(JsonObject response, string field, long balance)
    {
        if (!response.ContainsKey(field))
        {
            return;
        }

        if (balance < 0)
        {
            throw new InvalidDataException("Invalid current rollback balance.");
        }

        response[field] = balance;
    }

    private static void RefreshBlob<T>(JsonObject response, LegacyPlayerDocument player, string field) where T : new()
    {
        if (response.ContainsKey(field))
        {
            response[field] = PlayerState.Write(ReadBlob<T>(player, field));
        }
    }

    private static T ReadBlob<T>(LegacyPlayerDocument player, string field) where T : new()
    {
        return PlayerState.Read<T>(player.Serialized, field);
    }

    private static void RequireItemName(string? name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new InvalidDataException("Recorded item rollback is missing its identity.");
        }
    }
}
