using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using War.Backend.Legacy;
using War.Backend.Legacy.Catalog;

namespace War.LegacyContract.Tests;

/// <summary>Checks rejection, exact arithmetic and immutable authority without a temporary database/export.</summary>
internal static class CatalogValidationTests
{
    internal static int Run()
    {
        CheckImmutability();
        CheckMalformedEnvelopes();
        CheckPriceAuthority();
        CheckExactIntegers();
        CheckConstants();
        CheckProvenance();
        CheckUnboundDuplicateNames();
        CheckUpgradeBindings();
        CheckLaneShape();
        return 9;
    }

    private static void CheckImmutability()
    {
        JsonObject input = PackInput();
        LegacyCatalog catalog = LegacyCatalog.Parse(input.ToJsonString());
        LegacyCatalogRow row = catalog.Row("Google2u.CardPacks", "NAME", "pack")!;
        InputRow(input)["GOLD"] = 999;
        JsonNode.Parse(row.ToJsonString())!["GOLD"] = 888;
        Require(row["GOLD"]!.Value.GetValue<int>() == 10, "Mutable input/copies changed catalog price authority.");
        Require(ReferenceEquals(row, catalog.Row("Google2u.CardPacks", "NAME", "pack")),
            "Indexed identity lookup created a new mutable projection.");
        Require(CatalogBufferFixture.DefaultCatalog.UpgradeStages("Google2u.Constants").Count == 0 &&
            CatalogBufferFixture.DefaultCatalog.UpgradeStages(CatalogBufferFixture.WeaponName).Count == 3,
            "An unrelated table became an item's upgrade-stage authority.");
        var rows = (IList<LegacyCatalogRow>)catalog.Sheet("Google2u.CardPacks");
        try
        {
            rows[0] = row;
        }
        catch (NotSupportedException)
        {
            return;
        }

        throw new InvalidOperationException("Catalog row order was writable.");
    }

    private static void CheckMalformedEnvelopes()
    {
        foreach (string json in new[] { "null", "[]", "{}", "{\"sheets\":null}",
            "{\"sheets\":[null]}", "{\"sheets\":[{\"type\":2,\"rows\":[]}]}",
            "{\"sheets\":[{\"type\":\"x\",\"rows\":[2]}]}",
            "{\"sheets\":[],\"sheets\":[]}" })
        {
            Reject(() => LegacyCatalog.Parse(json));
        }

        JsonObject input = PackInput();
        JsonArray sheets = input["sheets"]!.AsArray();
        sheets.Add(sheets[0]!.DeepClone());
        Reject(() => LegacyCatalog.Parse(input.ToJsonString()));
        input = PackInput();
        JsonArray rows = input["sheets"]![0]!["rows"]!.AsArray();
        rows.Add(rows[0]!.DeepClone());
        Reject(() => LegacyCatalog.Parse(input.ToJsonString()));
        Reject(() => LegacyCatalog.Parse("{\"sheets\":[{\"type\":\"x\",\"rows\":[{\"A\":1,\"A\":2}]}]}"));
    }

    private static void CheckPriceAuthority()
    {
        foreach (string number in new[] { "-1", "1.5", "10.000000000000000000001", "1e-400", "1e999",
            "2147483648", "true", "\"10\"", "null", "[]" })
        {
            JsonObject input = PackInput();
            InputRow(input)["GOLD"] = JsonNode.Parse(number);
            Reject(() => LegacyCatalog.Parse(input.ToJsonString()));
        }

        JsonObject missing = PackInput();
        InputRow(missing).Remove("GOLD");
        Reject(() => LegacyCatalog.Parse(missing.ToJsonString()));
        JsonObject exact = PackInput();
        InputRow(exact)["GOLD"] = JsonNode.Parse("1.0e1");
        Require(LegacyCatalog.Parse(exact.ToJsonString()).Sheet("Google2u.CardPacks")[0]["GOLD"]!
            .Value.GetValue<long>() == 10, "Exact integral exponent price was rejected or rounded.");
    }

    private static void CheckExactIntegers()
    {
        const string json = "{\"sheets\":[{\"type\":\"numbers\",\"rows\":[{\"Min\":-9223372036854775808," +
            "\"Max\":9223372036854775807,\"Fraction\":75.0000000000000000000001,\"Overflow\":9223372036854775808}]}]}";
        LegacyCatalogRow row = LegacyCatalog.Parse(json).Sheet("numbers")[0];
        Require(row["Min"]!.Value.GetValue<long>() == long.MinValue &&
            row["Max"]!.Value.GetValue<long>() == long.MaxValue, "Int64 boundary identity was rounded.");
        Reject(() => row["Fraction"]!.Value.GetValue<long>());
        Reject(() => row["Overflow"]!.Value.GetValue<long>());
        Reject(() => row["Max"]!.Value.GetValue<int>());
    }

    private static void CheckConstants()
    {
        foreach ((string key, string number) in new[] { ("SecondRenameGoldCost", "1.1"), ("DogTagCap", "0"),
            ("StartingGold", "-1"), ("StartingGold", "75.000000000000000001"), ("CardsInPack", "257"),
            ("GoldCoefficient", "0"), ("GoldExpCoefficient", "1e100"), ("SilverCardRarity", "1.1") })
        {
            Reject(() => LegacyCatalog.Parse(ConstantInput(key, number).ToJsonString()));
        }

        LegacyCatalog catalog = LegacyCatalog.Parse(ConstantInput("GoldExpCoefficient", "-0.175").ToJsonString());
        Require(catalog.Constant("GoldExpCoefficient") == -0.175,
            "The recovered negative exponent was mistaken for a negative price.");
        JsonObject input = ConstantInput("UnmodeledFraction", "0.5");
        LegacyCatalog fraction = LegacyCatalog.Parse(input.ToJsonString());
        Reject(() => fraction.ConstantInt("UnmodeledFraction"));
        Require(fraction.Constant("UnmodeledFraction") == 0.5, "A legitimate scalar float was truncated.");
    }

    private static void CheckProvenance()
    {
        JsonObject input = PackInput();
        input["client"] = "1.4.0";
        input["unity"] = "2018.3.0f2";
        input["mainSceneSha256"] = new string('a', 64);
        string json = input.ToJsonString();
        LegacyCatalog catalog = LegacyCatalog.Parse(json);
        string expectedDigest = Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(json)));
        Require(catalog.Source?.ContentSha256 == expectedDigest,
            "Recorded source identity did not bind the exact catalog bytes.");
        input["client"] = "4.9.5";
        Reject(() => LegacyCatalog.Parse(input.ToJsonString()));
        input["client"] = "1.4.0";
        input["mainSceneSha256"] = new string('A', 64);
        Reject(() => LegacyCatalog.Parse(input.ToJsonString()));
        input.Remove("mainSceneSha256");
        Reject(() => LegacyCatalog.Parse(input.ToJsonString()));
    }

    private static void CheckUnboundDuplicateNames()
    {
        const string json = "{\"sheets\":[{\"type\":\"Google2u.Packs\",\"rows\":[" +
            "{\"NAME\":\"variant\",\"PRICE\":4.99},{\"NAME\":\"variant\",\"PRICE\":9.99}]}]}";
        LegacyCatalog catalog = LegacyCatalog.Parse(json);
        Require(catalog.Sheet("Google2u.Packs").Count == 2, "Unconsumed source variants were lost.");
        Reject(() => catalog.Row("Google2u.Packs", "NAME", "variant"));
    }

    private static void CheckUpgradeBindings()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "Fixtures", "legacy-buffer-catalog.json");
        JsonObject input = JsonNode.Parse(File.ReadAllText(path))!.AsObject();
        JsonObject weapon = input["sheets"]!.AsArray().OfType<JsonObject>()
            .Single(sheet => sheet["type"]!.GetValue<string>() == CatalogBufferFixture.WeaponName);
        JsonObject stage = weapon["rows"]![0]!.AsObject();
        stage.Remove("NEXTUPGRADEPRICE");
        stage.Remove("NEXTUPGRADEPRICEGOLD");
        stage.Remove("DELIVERYTIME");
        Reject(() => LegacyCatalog.Parse(input.ToJsonString()));

        input = JsonNode.Parse(File.ReadAllText(path))!.AsObject();
        JsonObject unit = input["sheets"]!.AsArray().OfType<JsonObject>()
            .Single(sheet => sheet["type"]!.GetValue<string>() == CatalogBufferFixture.UnitName);
        unit["rows"]![0]!.AsObject().Remove("TIER");
        Reject(() => LegacyCatalog.Parse(input.ToJsonString()));
    }

    private static void CheckLaneShape()
    {
        string path = Path.Combine(AppContext.BaseDirectory, "Fixtures", "legacy-buffer-catalog.json");
        foreach (string field in new[] { "STARTINGSPECIAL", "STARTINGELITE" })
        {
            JsonObject input = JsonNode.Parse(File.ReadAllText(path))!.AsObject();
            JsonObject units = input["sheets"]!.AsArray().OfType<JsonObject>()
                .Single(sheet => sheet["type"]!.GetValue<string>() == "Google2u.ArmyUpgrades");
            units["rows"]!.AsArray().OfType<JsonObject>()
                .Single(row => row["NAME"]!.GetValue<string>() == CatalogBufferFixture.UnitName)[field] = 99;
            Reject(() => LegacyCatalog.Parse(input.ToJsonString()));
        }

        foreach (int tier in new[] { -2, -1, 10, 30 })
        {
            JsonObject input = JsonNode.Parse(File.ReadAllText(path))!.AsObject();
            JsonObject unit = input["sheets"]!.AsArray().OfType<JsonObject>()
                .Single(sheet => sheet["type"]!.GetValue<string>() == CatalogBufferFixture.UnitName);
            unit["rows"]![0]!["TIER"] = tier;
            Reject(() => LegacyCatalog.Parse(input.ToJsonString()));
        }
    }

    private static JsonObject PackInput() => new()
    {
        ["sheets"] = new JsonArray(new JsonObject
        {
            ["type"] = "Google2u.CardPacks",
            ["rows"] = new JsonArray(new JsonObject { ["NAME"] = "pack", ["GOLD"] = 10, ["WARBUCKS"] = 0 })
        })
    };

    private static JsonObject InputRow(JsonObject input) => input["sheets"]![0]!["rows"]![0]!.AsObject();

    private static JsonObject ConstantInput(string key, string number) => new()
    {
        ["sheets"] = new JsonArray(new JsonObject
        {
            ["type"] = "Google2u.Constants",
            ["rows"] = new JsonArray(new JsonObject { ["DBKEY"] = key, ["FLOATVALUE"] = JsonNode.Parse(number) })
        })
    };

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

        throw new InvalidOperationException("Invalid catalog authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
