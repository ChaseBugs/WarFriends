using System.Text.Json.Nodes;
using War.Backend.Legacy;
using War.Persistence;
using War.Persistence.Legacy.Buffers;

namespace War.Battle.Tests.Legacy;

internal static class LegacyBufferedCosmeticResponseTests
{
    private const int Now = 1_700_000_000;
    private const string VisualName = "CAMOS_DEFAULT";

    internal static int Run()
    {
        var request = new BufferedRequest(0, DatabaseAction.BuyDecal, "{\"Name\":\"CAMOS_DEFAULT\"}");
        LegacyBufferedActionResult receipt = CreateReceipt();
        string original = receipt.ResponseJson!;
        JsonObject repaired = LegacyBufferedResponse.Project(receipt, Now, request);
        Require(repaired["DecalId"]!.GetValue<string>() == VisualName &&
            repaired["ExpiresOn"]!.GetValue<int>() == Now + 120 && receipt.ResponseJson == original,
            "Old no-op receipt lost mandatory fields or replaced current expiry/canonical evidence.");

        Reject(() => LegacyBufferedResponse.Project(receipt, Now));
        var mismatch = new BufferedRequest(0, DatabaseAction.BuyDecal, "{\"Name\":\"other-visual\"}");
        Reject(() => LegacyBufferedResponse.Project(receipt, Now, mismatch));
        Reject(() => LegacyBufferedResponse.Project(receipt, Now,
            new BufferedRequest(0, DatabaseAction.BuyWeapon, request.Data)));

        receipt.Player.Serialized["DecalManagerData"] = "{\"visuals\":{\"CAMOS_DEFAULT\":{\"bought\":false}}}";
        Reject(() => LegacyBufferedResponse.Project(receipt, Now, request));
        receipt.Player.Serialized["DecalManagerData"] =
            "{\"visuals\":{\"CAMOS_DEFAULT\":{\"bought\":true,\"expiresOn\":-1}}}";
        Reject(() => LegacyBufferedResponse.Project(receipt, Now, request));
        receipt.Player.Serialized["DecalManagerData"] = "{\"visuals\":null}";
        Reject(() => LegacyBufferedResponse.Project(receipt, Now, request));
        receipt.Player.Serialized["DecalManagerData"] = "{\"visuals\":{\"CAMOS_DEFAULT\":null}}";
        Reject(() => LegacyBufferedResponse.Project(receipt, Now, request));

        receipt = CreateReceipt();
        JsonObject response = JsonNode.Parse(receipt.ResponseJson!)!.AsObject();
        response["DecalId"] = "other-visual";
        receipt = receipt with { ResponseJson = response.ToJsonString() };
        Reject(() => LegacyBufferedResponse.Project(receipt, Now, request));
        return 9;
    }

    private static LegacyBufferedActionResult CreateReceipt()
    {
        var decals = new DecalManagerData();
        decals.Visuals[VisualName] = new SavedPlayerVisual { Bought = true, ExpiresOn = Now + 120 };
        var player = new LegacyPlayerDocument();
        player.Serialized["DecalManagerData"] = PlayerState.Write(decals);
        var response = new JsonObject
        {
            ["ActionId"] = (int)DatabaseAction.BuyDecal,
            ["Result"] = (int)DatabaseResult.Success
        };
        return new LegacyBufferedActionResult(player, response.ToJsonString(), null);
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

        throw new InvalidOperationException("Unbound or damaged cosmetic evidence was projected as success.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
