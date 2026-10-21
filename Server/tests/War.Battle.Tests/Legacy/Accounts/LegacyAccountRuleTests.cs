using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using War.Backend.Legacy;
using War.Backend.Legacy.Accounts;
using War.Persistence.Legacy.Accounts;

namespace War.Battle.Tests.Legacy.Accounts;

/// <summary>Checks registration metadata, frozen startup state and exact source/time arithmetic.</summary>
internal static class LegacyAccountRuleTests
{
    internal static void Run()
    {
        CheckRegistration();
        CheckSourceConstants();
        CheckFrozenPolicy();
        CheckSessionDates();
        Console.WriteLine("PASS: 4 account metadata, exact source-integer, frozen policy and session-date scenarios");
    }

    private static void CheckRegistration()
    {
        Dictionary<string, StringValues> fields = Fields();
        fields["DeviceToken"] = "  opaque-token  ";
        fields["UtcOffset"] = "-1E-07";
        LegacyAccountRegistration registration = Parse(fields);
        Require(registration.DeviceToken == "  opaque-token  " && registration.UtcOffsetHours == -1E-07,
            "Opaque token bytes and invariant fractional clock diagnostics must be preserved.");
        string[] invalidOffsets = ["NaN", "Infinity", "-Infinity", "25", "-25", "1e309", "1,5", " 0", "0 "];
        foreach (string offset in invalidOffsets)
        {
            fields["UtcOffset"] = offset;
            ExpectInvalid(() => Parse(fields));
        }

        fields = Fields();
        fields.Remove("Locale");
        ExpectInvalid(() => Parse(fields));
        fields = Fields();
        fields.Remove("UtcOffset");
        ExpectInvalid(() => Parse(fields));
        fields = Fields();
        fields["Locale"] = " en ";
        ExpectInvalid(() => Parse(fields));
        fields = Fields();
        fields["DeviceToken"] = new StringValues(["first", "second"]);
        ExpectInvalid(() => Parse(fields));
        fields["DeviceToken"] = "";
        ExpectInvalid(() => Parse(fields));
        fields["DeviceToken"] = "bad\ntoken";
        ExpectInvalid(() => Parse(fields));
        fields["DeviceToken"] = "unpaired-\ud800";
        ExpectInvalid(() => Parse(fields));
        fields = Fields();
        fields["requestId"] = "146";
        ExpectInvalid(() => Parse(fields));
        fields["GameCenterId"] = " padded-platform-id ";
        Require(Parse(fields).GameCenterId == " padded-platform-id ", "Platform IDs must never be trimmed.");
    }

    private static void CheckSourceConstants()
    {
        LegacyCatalog catalog = LegacyAccountTestFixture.Catalog();
        LegacyStarterState source = LegacyStarterState.FromCatalog(catalog);
        Require(source.Gold == 75 && source.WarBucks == 15000 && source.DogTagMax == 4500,
            "Source starter numbers must retain 75 Gold, 15000 WarBucks and 5 * 900 dog-tag seconds.");
        var constants = new JsonArray(catalog.Sheet("Google2u.Constants")
            .Select(row => JsonNode.Parse(row.ToJsonString())).ToArray());
        var input = new JsonObject
        {
            ["sheets"] = new JsonArray(new JsonObject { ["type"] = "Google2u.Constants", ["rows"] = constants })
        };
        JsonObject row = constants.OfType<JsonObject>().Single(value => value["DBKEY"]!.GetValue<string>() == "StartingGold");
        string[] badNumbers = ["75.1", "1e-100", "75.0000000000000000000000000001", "-1", "9223372036854775808"];
        foreach (string number in badNumbers)
        {
            row["FLOATVALUE"] = JsonNode.Parse(number);
            ExpectInvalid(() => LegacyStarterState.FromCatalog(LegacyCatalog.Parse(input.ToJsonString())));
        }

        row["FLOATVALUE"] = JsonNode.Parse("7.5e1");
        Require(LegacyStarterState.FromCatalog(LegacyCatalog.Parse(input.ToJsonString())).Gold == 75,
            "Exact integral exponent notation must work.");
        row["FLOATVALUE"] = 75;
        constants.OfType<JsonObject>().Single(value => value["DBKEY"]!.GetValue<string>() == "DogTagCap")["FLOATVALUE"] =
            int.MaxValue;
        ExpectInvalid(() => LegacyStarterState.FromCatalog(LegacyCatalog.Parse(input.ToJsonString())));
    }

    private static void CheckFrozenPolicy()
    {
        var options = new LegacyStarterState();
        LegacyStarterPolicy frozen = LegacyStarterPolicy.FromOptions(options);
        options.Gold = -1;
        options.SessionLifetimeHours = 0;
        Require(frozen.Gold == 500 && frozen.SessionLifetimeHours == 24, "Mutable options leaked into traffic policy.");
        ExpectInvalid(() => LegacyStarterPolicy.FromOptions(options));
        ExpectInvalid(() => (frozen with { DogTagMax = 0 }).Validate());
        ExpectInvalid(() => (frozen with { Level = 43 }).Validate());
        ExpectInvalid(() => (frozen with { SheetConfiguration = "bad;version" }).Validate());
        ExpectInvalid(() => (frozen with { SessionLifetimeHours = int.MaxValue }).Validate());
        Require(!LegacyCatalog.LoadConfigured(null).IsLoaded,
            "An omitted catalog retains explicit compatibility behavior.");
        string absent = Path.Combine(Path.GetTempPath(), "war-missing-" + Guid.NewGuid().ToString("N") + ".json");
        bool hasRejected = false;
        try
        {
            LegacyCatalog.LoadConfigured(absent);
        }
        catch (FileNotFoundException)
        {
            hasRejected = true;
        }

        Require(hasRejected, "A configured missing catalog silently changed starter currency to fallback policy.");
    }

    private static void CheckSessionDates()
    {
        DateTime now = DateTime.UnixEpoch.AddDays(1);
        Require(LegacySessionAuthority.Expiry(now, 24) == now.AddDays(1), "Session expiry must use exact hour ticks.");
        ExpectInvalid(() => LegacySessionAuthority.Expiry(now, 0));
        ExpectInvalid(() => LegacySessionAuthority.Expiry(now, -1));
        DateTime lastUtc = DateTime.SpecifyKind(DateTime.MaxValue, DateTimeKind.Utc);
        ExpectInvalid(() => LegacySessionAuthority.Expiry(lastUtc, 1));
    }

    private static Dictionary<string, StringValues> Fields() => new()
    {
        ["requestId"] = "118",
        ["Locale"] = "kr",
        ["UtcOffset"] = "9"
    };

    private static LegacyAccountRegistration Parse(Dictionary<string, StringValues> fields)
    {
        var context = new DefaultHttpContext();
        context.Request.ContentType = "application/x-www-form-urlencoded";
        context.Request.Form = new FormCollection(fields);
        Require(LegacyRequest.TryParse(context.Request, out LegacyRequest? request), "Invalid account parser fixture.");
        return LegacyAccountParser.Parse(request!);
    }

    private static void ExpectInvalid(Action action) => LegacyAccountTestFixture.ExpectInvalid(action);

    private static void Require(bool condition, string message) => LegacyAccountTestFixture.Require(condition, message);
}
