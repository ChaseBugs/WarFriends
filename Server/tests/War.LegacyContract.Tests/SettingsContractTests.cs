using System.Text.Json;
using System.Text.Json.Nodes;
using War.LegacyContract.Tests.Recovered;
using War.Persistence.Legacy.Preferences;

namespace War.LegacyContract.Tests;

/// <summary>Checks exact source fields/defaults and rejects partial, coercive or conflicting replacements.</summary>
internal static class SettingsContractTests
{
    internal static string Complete => RecoveredSettingsOracle.SerializeDefaults();

    internal static int Run()
    {
        string source = Complete;
        LegacySettingsSnapshot.Parse(source);
        LegacySettingsSnapshot.Parse(RecoveredSettingsOracle.SerializeAllFalse());
        using JsonDocument defaults = JsonDocument.Parse(source);
        Require(defaults.RootElement.EnumerateObject().Count() == 6 &&
            defaults.RootElement.GetProperty("challenge").GetBoolean() &&
            !defaults.RootElement.GetProperty("maintenance").GetBoolean(),
            "Recovered absent-subsystem defaults differ from an explicit all-false Settings snapshot.");
        CheckMalformedReplacements();
        CheckDurableBoundary();
        return 3;
    }

    private static void CheckMalformedReplacements()
    {
        foreach (string json in new[] { "null", "{}", "[]", "{\"challenge\":true}", "not json" })
        {
            Reject(() => LegacySettingsSnapshot.Parse(json));
        }

        foreach (string value in new[] { "null", "0", "1", "\"true\"", "[]", "{}" })
        {
            JsonObject input = JsonNode.Parse(Complete)!.AsObject();
            input["challenge"] = JsonNode.Parse(value);
            Reject(() => LegacySettingsSnapshot.Parse(input.ToJsonString()));
        }

        JsonObject unknown = JsonNode.Parse(Complete)!.AsObject();
        unknown["futureFlag"] = true;
        Reject(() => LegacySettingsSnapshot.Parse(unknown.ToJsonString()));
        string duplicate = Complete[..^1] + ",\"challenge\":false}";
        Reject(() => LegacySettingsSnapshot.Parse(duplicate));
        string alias = Complete.Replace("\"challenge\"", "\"Challenge\"", StringComparison.Ordinal);
        Reject(() => LegacySettingsSnapshot.Parse(alias));
        Reject(() => LegacySettingsSnapshot.Parse(Complete + new string(' ', 4096)));
    }

    private static void CheckDurableBoundary()
    {
        LegacySettingsSnapshot.ValidateContainer(new Dictionary<string, string>());
        var metadata = JsonNode.Parse(Complete)!.AsObject();
        metadata["futureMetadata"] = new JsonObject { ["revision"] = 9223372036854775807L };
        LegacySettingsSnapshot.ValidateContainer(
            new Dictionary<string, string> { ["Settings"] = metadata.ToJsonString() });
        foreach (string? value in new string?[] { null, "null", "{}", "{\"challenge\":true}" })
        {
            try
            {
                LegacySettingsSnapshot.ValidateContainer(new Dictionary<string, string> { ["Settings"] = value! });
            }
            catch (InvalidDataException)
            {
                continue;
            }

            throw new InvalidOperationException("Damaged durable Settings normalized into a fresh snapshot.");
        }

        metadata["Challenge"] = false;
        try
        {
            LegacySettingsSnapshot.ValidateContainer(
            new Dictionary<string, string> { ["Settings"] = metadata.ToJsonString() });
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidOperationException("Conflicting stored case alias was accepted.");
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (JsonException)
        {
            return;
        }

        throw new InvalidOperationException("Malformed complete Settings request was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
