using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using War.Backend.Legacy;

namespace War.LegacyContract.Tests;

internal static class CatalogBufferRequests
{
    internal static BufferedRequest Create(DatabaseAction action, string name,
        params (string Field, object Value)[] assertions)
    {
        if (action is DatabaseAction.WeaponWasShown or DatabaseAction.ArmyUnitWasShown or
            DatabaseAction.VisualWasShown or DatabaseAction.EquipDecal or DatabaseAction.ConvertScrapsToParts)
        {
            return new BufferedRequest(0, action, name);
        }

        if (action == DatabaseAction.SaveLastSeenSquadChatTimeStamp)
        {
            return new BufferedRequest(0, action, CatalogBufferFixture.Now.ToString(CultureInfo.InvariantCulture));
        }

        JsonObject payload = CreatePayload(action, name);
        foreach ((string field, object value) in assertions)
        {
            payload[field] = JsonSerializer.SerializeToNode(value);
        }

        return new BufferedRequest(0, action, payload.ToJsonString());
    }

    private static JsonObject CreatePayload(DatabaseAction action, string name)
    {
        if (action == DatabaseAction.BuyCardPack)
        {
            return new JsonObject { ["cardPack"] = name };
        }

        if (action == DatabaseAction.UpdateEquippedUnits)
        {
            return new JsonObject
            {
                ["equips"] = new JsonObject { [name] = new JsonObject { ["equipped"] = true } }
            };
        }

        bool usesName = action is DatabaseAction.BuyWeapon or DatabaseAction.BuyUnit or
            DatabaseAction.BuyDecal or DatabaseAction.EquipWeapon;
        return new JsonObject { [usesName ? "Name" : "LevelName"] = name };
    }
}
