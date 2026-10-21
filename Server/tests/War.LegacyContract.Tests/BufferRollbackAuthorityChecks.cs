using Newtonsoft.Json.Linq;
using War.Backend.Legacy;
using War.LegacyContract.Tests.Recovered;
using War.Persistence;
using ServerAction = War.Backend.Legacy.DatabaseAction;
using ServerResult = War.Backend.Legacy.DatabaseResult;

namespace War.LegacyContract.Tests;

internal static class BufferRollbackAuthorityChecks
{
    internal static void Verify(JObject response, LegacyPlayerDocument player, JObject matrix, BufferedRequest request)
    {
        string action = ((ServerAction)(int)response["ActionId"]!).ToString();
        string result = ((ServerResult)(int)response["Result"]!).ToString();
        JObject group = matrix["groups"]!.Children<JObject>()
            .Single(row => row["actions"]!.Values<string>().Contains(action));
        bool isHandledFailure = group["failures"]!.Values<string>().Contains(result);
        if (isHandledFailure)
        {
            foreach (string? field in group["required"]!.Values<string>())
            {
                Require(response[field!] != null, "Producer omitted mandatory rollback " + field);
            }

            RequireWallet(response, group, "Gold");
            RequireWallet(response, group, "WarBucks");
        }

        CheckBalance(response, "Gold", player.Gold, isHandledFailure);
        CheckBalance(response, "WarBucks", player.WarBucks, isHandledFailure);
        foreach (string field in new[] { "CardManagerData", "DecalManagerData", "InventoryData" })
        {
            bool shouldConsume = isHandledFailure ||
                (action == nameof(ServerAction.EquipDecal) && result == "Success");
            CheckBlob(response, field, player.Serialized[field], shouldConsume);
        }

        CheckItems(response, player, isHandledFailure, request);
        if (result == "Success" && action == nameof(ServerAction.BuyDecal))
        {
            string name = (string)response["DecalId"]!;
            DecalManagerData decals = PlayerState.Read<DecalManagerData>(player.Serialized["DecalManagerData"]);
            Require(decals.Visuals[name].Bought &&
                (int)response["ExpiresOn"]! == decals.Visuals[name].ExpiresOn &&
                CamosManager.instance.data.visuals[name].expiresOn == decals.Visuals[name].ExpiresOn,
                "Client cosmetic expiry disagrees with current ownership.");
        }
    }

    private static void CheckItems(
        JObject response, LegacyPlayerDocument player, bool isHandled, BufferedRequest request)
    {
        LevelManagerData levels = PlayerState.Read<LevelManagerData>(player.Serialized["LevelManagerData"]);
        string name = (string?)response["LevelName"] ?? "";
        if (response["LevelName"] != null)
        {
            JObject payload = JObject.Parse(request.Data!);
            string? expectedName = (string?)payload["LevelName"] ?? (string?)payload["Name"];
            Require(name == expectedName, "Rollback item identity disagrees with its bound request.");
        }

        CheckBlob(response, "Weapon", PlayerState.Write(
            levels.SavedWeapons.GetValueOrDefault(name) ?? new SavedWeaponSlots()), isHandled);
        CheckBlob(response, "Unit", PlayerState.Write(
            levels.SavedArmies.GetValueOrDefault(name) ?? new SavedArmySlots()), isHandled);
        CheckBlob(response, "weaponDelivery", PlayerState.Write(levels.WeaponDelivery), isHandled);
        CheckBlob(response, "unitDelivery", PlayerState.Write(levels.UnitDelivery), isHandled);
        if (response["data"] != null)
        {
            var expected = new JObject();
            foreach (KeyValuePair<string, SavedArmySlots> unit in levels.SavedArmies)
            {
                expected[unit.Key] = PlayerState.Write(unit.Value);
                Require(OracleTrace.Items.TryGetValue("unit:" + unit.Key, out JObject? consumed) &&
                    JToken.DeepEquals(consumed, JObject.Parse(PlayerState.Write(unit.Value))),
                    "Client army identity/state disagrees with current authority.");
            }

            Require(JToken.DeepEquals(JObject.Parse((string)response["data"]!), expected),
                "Equipped-army rollback disagrees with current authority.");
        }
    }

    private static void RequireWallet(JObject response, JObject group, string field)
    {
        if (group["guarded"]!.Values<string>().Contains(field))
        {
            Require(response[field] != null, "Producer omitted authoritative wallet rollback " + field);
        }
    }

    private static void CheckBalance(JObject response, string field, long expected, bool shouldConsume)
    {
        if (response[field] != null)
        {
            Require((long)response[field]! == expected, "Wire rollback disagrees with current " + field);
            if (shouldConsume)
            {
                long? consumed = field == "Gold" ? OracleTrace.Gold : OracleTrace.WarBucks;
                Require(consumed == expected, "Client consumed stale " + field);
            }
        }
    }

    private static void CheckBlob(JObject response, string field, string expected, bool shouldConsume)
    {
        if (response[field] == null)
        {
            return;
        }

        Require(response[field]!.Type == JTokenType.String &&
            JToken.DeepEquals(JObject.Parse((string)response[field]!), JObject.Parse(expected)),
            "Wire rollback disagrees with current " + field);
        if (shouldConsume)
        {
            Require(OracleTrace.Blobs.TryGetValue(field, out JObject? consumed) &&
                JToken.DeepEquals(consumed, JObject.Parse(expected)), "Client consumed stale " + field);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
