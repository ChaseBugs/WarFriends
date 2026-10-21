using System.Text.Json.Nodes;
using War.Backend.Legacy;

namespace War.LegacyContract.Tests;

/// <summary>Checks the real configured release in memory without extra exports or database instances.</summary>
internal static class CatalogReleaseTests
{
    internal static int Run()
    {
        Require(RecoveredCatalogFixture.Catalog.Source != null, "Reviewed release did not load at the host boundary.");
        Reject(input => input["sheets"]!.AsArray().RemoveAt(0));
        Reject(input => Rows(input, "Google2u.PlayerBots").RemoveAt(0));
        Reject(input => Rows(input, "Google2u.PlayerBots")[0]!["UnknownField"] = 1);
        CheckSourceTypes();
        CheckIdentityOrder();
        Reject(input => Rows(input, "Google2u.WeaponUpgrades")[0]!["PRICE"] = 12345,
            "does not match the reviewed source snapshot");
        Reject(input => input["mainSceneSha256"] = new string('a', 64),
            "does not match the reviewed source snapshot");
        return 8;
    }

    private static void CheckSourceTypes()
    {
        // These unconsumed fields still have recovered row-class types at the configured release boundary.
        Reject(input => Rows(input, "Google2u.PlayerBots")[0]!["DIFFICULTY"] = 0.5);
        Reject(input => Rows(input, "Google2u.PlayerBots")[0]!["PRIMARY"] = 1);
        Reject(input => Rows(input, "Google2u.Packs")[0]!["PRICE"] = 1e100);
    }

    private static void CheckIdentityOrder()
    {
        Reject(input =>
        {
            JsonArray rows = Rows(input, "Google2u.WeaponUpgrades");
            JsonNode first = rows[0]!.DeepClone();
            rows[0] = rows[1]!.DeepClone();
            rows[1] = first;
        }, "identity/order differs");
    }

    private static JsonArray Rows(JsonObject input, string type) => input["sheets"]!.AsArray()
        .OfType<JsonObject>().Single(sheet => sheet["type"]!.GetValue<string>() == type)["rows"]!.AsArray();

    private static void Reject(Action<JsonObject> damage, string? expectedMessage = null)
    {
        JsonObject input = JsonNode.Parse(RecoveredCatalogFixture.SourceJson)!.AsObject();
        damage(input);
        try
        {
            LegacyCatalog.ParseConfigured(input.ToJsonString());
        }
        catch (InvalidDataException exception)
        {
            Require(expectedMessage == null || exception.Message.Contains(expectedMessage, StringComparison.Ordinal),
                "Release was rejected for an unexpected reason: " + exception.Message);
            return;
        }

        throw new InvalidOperationException("Damaged configured release was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
