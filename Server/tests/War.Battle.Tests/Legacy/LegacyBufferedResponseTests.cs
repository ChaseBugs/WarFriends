using System.Text.Json.Nodes;
using War.Backend.Legacy;
using War.Persistence;
using War.Persistence.Legacy.Buffers;

namespace War.Battle.Tests.Legacy;

/// <summary>Checks the Client's now-plus-duration rule against fixed, identified delivery deadlines.</summary>
internal static class LegacyBufferedResponseTests
{
    private const long StartedUnixSeconds = 1_700_000_000;
    private const int DurationSeconds = 60;
    private const int ElapsedSeconds = 10;

    internal static int Run()
    {
        int checks = 0;
        foreach (string kind in new[] { "weapon", "unit" })
        {
            LegacyBufferedActionResult original = CreateResponse(kind);
            long receivedAt = StartedUnixSeconds + ElapsedSeconds;
            JsonObject replay = LegacyBufferedResponse.Project(original, receivedAt);
            int remaining = replay["DeliveryTime"]!.GetValue<int>();
            Require(remaining == DurationSeconds - ElapsedSeconds &&
                receivedAt + remaining == original.Delivery!.EndUnixSeconds &&
                JsonNode.Parse(original.ResponseJson!)!["DeliveryTime"]!.GetValue<int>() == DurationSeconds,
                kind + " replay extended the Client deadline or changed the stored response.");
            JsonObject expired = LegacyBufferedResponse.Project(original, StartedUnixSeconds + DurationSeconds + 1);
            Require(expired["DeliveryTime"]!.GetValue<int>() == 0, kind + " expired delivery restarted its timer.");

            ReplaceDelivery(original, "different-item", original.Delivery!.BoughtIndex);
            JsonObject unrelated = LegacyBufferedResponse.Project(original, receivedAt);
            Require(!unrelated.ContainsKey("DeliveryTime"), kind + " old reply affected another delivering item.");
            ReplaceDelivery(original, original.Delivery.ItemId, original.Delivery.BoughtIndex + 1);
            JsonObject successor = LegacyBufferedResponse.Project(original, receivedAt);
            Require(!successor.ContainsKey("DeliveryTime"), kind + " old reply affected a successor upgrade.");
            checks += 4;
        }

        LegacyBufferedActionResult valid = CreateResponse("weapon");
        Reject(() => LegacyBufferedResponse.Project(valid, -1));
        Reject(() => LegacyBufferedResponse.Project(valid, (long)int.MaxValue + 1));
        return checks + 2;
    }

    private static LegacyBufferedActionResult CreateResponse(string kind)
    {
        var evidence = new LegacyBufferedDelivery
        {
            Kind = kind,
            ItemId = "source-item",
            BoughtIndex = 1,
            EndUnixSeconds = StartedUnixSeconds + DurationSeconds
        };
        var player = new LegacyPlayerDocument();
        var response = new JsonObject
        {
            ["ActionId"] = (int)(kind == "weapon" ? DatabaseAction.BuyWeaponUpgrade : DatabaseAction.BuyUnitUpgrade),
            ["Result"] = (int)DatabaseResult.Success,
            ["DeliveryTime"] = DurationSeconds
        };
        var result = new LegacyBufferedActionResult(player, response.ToJsonString(), evidence);
        ReplaceDelivery(result, evidence.ItemId, evidence.BoughtIndex);
        return result;
    }

    private static void ReplaceDelivery(LegacyBufferedActionResult result, string itemId, int boughtIndex)
    {
        var levels = new LevelManagerData();
        ItemDelivery current = result.Delivery!.Kind == "weapon" ? levels.WeaponDelivery : levels.UnitDelivery;
        current.ItemId = itemId;
        current.BoughtIndex = boughtIndex;
        current.End = result.Delivery.EndUnixSeconds;
        result.Player.Serialized["LevelManagerData"] = PlayerState.Write(levels);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidOperationException("Unrepresentable Client time became a valid countdown.");
    }
}
