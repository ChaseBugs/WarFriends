using System.Text.Json;
using War.Backend.Legacy;
using War.Persistence.Legacy.State;

namespace War.LegacyContract.Tests;

/// <summary>Checks state defaults, lexical authority, metadata conservation and resource bounds in memory.</summary>
internal static class StoredStateTests
{
    private const int MaximumStateNodes = 65_536;

    internal static int Run()
    {
        CheckAbsence();
        CheckTypesAndAliases();
        CheckMetadata();
        CheckLimits();
        CheckOptions();
        return 5;
    }

    private static void CheckAbsence()
    {
        var states = new Dictionary<string, string>();
        Require(PlayerState.Read<LevelManagerData>(states, "LevelManagerData").SavedWeapons.Count == 0,
            "A missing legacy subsystem did not retain its explicit default path.");
        foreach (string? value in new string?[] { null, "", " ", "null", "[]", "1", "true" })
        {
            states["LevelManagerData"] = value!;
            Reject(() => PlayerState.Read<LevelManagerData>(states, "LevelManagerData"));
        }

        foreach (string value in new[] { "{\"savedWeapons\":null}", "{\"unitDelivery\":null}",
            "{\"savedWeapons\":{\"rifle\":null}}" })
        {
            Reject(() => PlayerState.Read<LevelManagerData>(value));
        }
    }

    private static void CheckTypesAndAliases()
    {
        foreach (string value in new[] { "{\"boughtIndex\":\"1\"}", "{\"boughtIndex\":2147483648}",
            "{\"boughtIndex\":1.5}", "{\"BoughtIndex\":1}", "{\"bought\":true,\"Bought\":false}",
            "{\"bought\":true,\"bought\":false}" })
        {
            Reject(() => PlayerState.Read<SavedWeaponSlots>(value));
        }

        foreach (string key in new[] { "00", "+0", "-0", " 0", "2147483648" })
        {
            Reject(() => PlayerState.Read<InventoryData>("{\"slots\":{\"" + key + "\":{\"name\":null}}}"));
        }

        Require(PlayerState.Read<InventoryData>("{\"slots\":{\"0\":{\"name\":null}}}").Slots[0].Name == null,
            "Canonical integer dictionary keys or valid nullable slot names were rejected.");
        Reject(() => PlayerState.Read<LevelManagerData>("{\"future\":{\"x\":1,\"x\":2}}"));
    }

    private static void CheckMetadata()
    {
        const string input = "{\"savedWeapons\":{\"rifle\":{\"bought\":true,\"futureSlot\":[1,null,3]}}," +
            "\"futureRoot\":{\"number\":9223372036854775807}}";
        LevelManagerData state = PlayerState.Read<LevelManagerData>(input);
        state.SavedWeapons["rifle"].Showed = true;
        using JsonDocument output = JsonDocument.Parse(PlayerState.Write(state));
        JsonElement root = output.RootElement;
        Require(root.GetProperty("futureRoot").GetProperty("number").GetInt64() == long.MaxValue &&
            root.GetProperty("savedWeapons").GetProperty("rifle").GetProperty("futureSlot")[1].ValueKind ==
                JsonValueKind.Null,
            "A known-field mutation discarded or rounded unrelated root/nested metadata.");
        using JsonDocument collision = JsonDocument.Parse("{}");
        state.Unmodeled["savedWeapons"] = collision.RootElement.Clone();
        Reject(() => PlayerState.Write(state));
        var nullContainer = new InventoryData { Slots = null! };
        Reject(() => PlayerState.Write(nullContainer));
    }

    private static void CheckLimits()
    {
        const string prefix = "{\"note\":\"";
        const string suffix = "\"}";
        string limit = prefix + new string('a', LegacyStateJson.MaximumBytes - prefix.Length - suffix.Length) + suffix;
        using (JsonDocument accepted = LegacyStateJson.ParseObject(limit))
        {
            Require(accepted.RootElement.GetProperty("note").GetString()!.Length > 0,
                "Exact state byte limit was rejected.");
        }

        RejectJson(() => LegacyStateJson.ParseObject(limit + " "));
        string oversizedUtf8 = prefix + new string('\u20AC', LegacyStateJson.MaximumBytes / 2) + suffix;
        RejectJson(() => LegacyStateJson.ParseObject(oversizedUtf8));
        RejectJson(() => LegacyStateJson.ParseObject("{\"value\":1e999}"));
        string depth = string.Concat(Enumerable.Repeat("{\"x\":", 31)) + "{}" + new string('}', 31);
        using JsonDocument allowedDepth = LegacyStateJson.ParseObject(depth);
        RejectJson(() => LegacyStateJson.ParseObject("{\"x\":" + depth + "}"));
        string nodes = "{\"x\":[" + string.Join(',', Enumerable.Repeat("0", MaximumStateNodes - 2)) + "]}";
        using JsonDocument allowedNodes = LegacyStateJson.ParseObject(nodes);
        RejectJson(() => LegacyStateJson.ParseObject(nodes[..^2] + ",0]}"));
    }

    private static void CheckOptions()
    {
        try
        {
            PlayerState.Options.PropertyNameCaseInsensitive = true;
        }
        catch (InvalidOperationException)
        {
            return;
        }

        throw new InvalidOperationException("Shared state serializer options remained mutable after publication.");
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

        throw new InvalidOperationException("Damaged state was accepted or normalized into defaults.");
    }

    private static void RejectJson(Action action)
    {
        try
        {
            action();
        }
        catch (JsonException)
        {
            return;
        }

        throw new InvalidOperationException("Unbounded or malformed state JSON was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
