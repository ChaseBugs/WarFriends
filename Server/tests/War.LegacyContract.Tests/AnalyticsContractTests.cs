using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Logging.Abstractions;
using War.Backend.Legacy;
using War.Backend.Legacy.Buffering;
using RecoveredAnalyticsOracle = War.LegacyContract.Tests.Recovered.RecoveredAnalyticsOracle;
using War.Persistence;
using War.Persistence.Legacy.Analytics;

namespace War.LegacyContract.Tests;

/// <summary>Executes original acknowledgements and checks bounded analytics without metadata loss or repair.</summary>
internal static class AnalyticsContractTests
{
    internal static int Run()
    {
        CheckSourceAcknowledgements();
        CheckKnownFields();
        CheckEnvelopesAndMetadata();
        CheckSourceChatMarker();
        return 4;
    }

    private static void CheckSourceAcknowledgements()
    {
        foreach (LegacyAnalyticsFlag flag in Enum.GetValues<LegacyAnalyticsFlag>())
        {
            string name = LegacyAnalyticsState.FlagName(flag);
            Require(RecoveredAnalyticsOracle.Acknowledge(name), "Original builder/callback did not mark: " + name);
            JsonObject absent = LegacyAnalyticsState.Read(new Dictionary<string, string>());
            absent[name] = true;
            LegacyAnalyticsState.ValidateJson(LegacyAnalyticsState.Write(absent));
        }

        Reject(() => LegacyAnalyticsState.FlagName((LegacyAnalyticsFlag)int.MaxValue));
        using JsonDocument defaults = JsonDocument.Parse(RecoveredAnalyticsOracle.Defaults());
        Require(!defaults.RootElement.GetProperty("chatShown").GetBoolean() &&
            defaults.RootElement.GetProperty("transactions").ValueKind == JsonValueKind.Null &&
            defaults.RootElement.GetProperty("elitePackDeadlines").ValueKind == JsonValueKind.Object,
            "Recovered constructor flags or nullable history changed.");
    }

    private static void CheckKnownFields()
    {
        JsonObject complete = JsonNode.Parse(RecoveredAnalyticsOracle.Defaults())!.AsObject();
        // Present zero countdowns are refused by reviewed authority; absence is a separate migration input.
        complete["matchesToNextLootboxes"] = 4;
        LegacyAnalyticsState.ValidateJson(complete.ToJsonString());
        LegacyAnalyticsState.ValidateJson(RecoveredAnalyticsOracle.Complete());
        Require(RecoveredAnalyticsOracle.Fields().Count == 33, "Recovered analytics member set changed.");
        foreach (string name in RecoveredAnalyticsOracle.Fields().Keys)
        {
            JsonObject alias = complete.DeepClone().AsObject();
            string spelling = char.ToUpperInvariant(name[0]) + name[1..];
            alias[spelling] = alias[name]?.DeepClone();
            Reject(() => LegacyAnalyticsState.ValidateJson(alias.ToJsonString()));
            JsonObject badType = complete.DeepClone().AsObject();
            badType[name] = name == "transactions" ? JsonValue.Create(1) : new JsonArray();
            Reject(() => LegacyAnalyticsState.ValidateJson(badType.ToJsonString()));
        }

        foreach (string json in new[]
        {
            "{\"goldSpent\":-1}", "{\"totalBattles\":2147483648}", "{\"goldSpent\":\"1\"}",
            "{\"lastSeenSquadChatTimeStampDB\":1.0}", "{\"chatShown\":null}", "{\"chatShown\":1}",
            "{\"elitePackDeadlines\":null}", "{\"collectedRewards\":{\"x\":-1}}",
            "{\"transactions\":[{\"id\":142}]}", "{\"transactions\":[null]}",
            "{\"realMoneySpent\":1e100}", "{\"realMoneySpent\":1e-1000}", "{\"realMoneySpent\":-0.0}",
            "{\"matchesToNextLootboxes\":0}", "{\"matchesToNextLootboxes\":5}",
            "{\"paidInstantBattles\":1,\"instantBattles\":4}"
        })
        {
            Reject(() => LegacyAnalyticsState.ValidateJson(json));
        }

        LegacyAnalyticsState.ValidateJson("{\"realMoneySpent\":1.99,\"paidInstantBattles\":1,\"instantBattles\":5}");
        LegacyAnalyticsState.ValidateJson(
            "{\"transactions\":[{\"id\":142,\"p\":null,\"gold\":0,\"wb\":0,\"money\":1.99}]}");
    }

    private static void CheckEnvelopesAndMetadata()
    {
        string?[] malformed = [null, "null", "", " ", "[]", "{\"chatShown\":true,\"chatShown\":false}"];
        foreach (string? json in malformed)
        {
            Reject(() => LegacyAnalyticsState.Read(
                new Dictionary<string, string> { [LegacyAnalyticsState.Key] = json! }));
        }

        const string metadata = "{\"future\":{\"exact\":9223372036854775807,\"fraction\":1.234567890123456789}}";
        JsonObject state = LegacyAnalyticsState.Parse(metadata);
        state["chatShown"] = true;
        using JsonDocument saved = JsonDocument.Parse(LegacyAnalyticsState.Write(state));
        Require(saved.RootElement.GetProperty("future").GetProperty("exact").GetRawText() == "9223372036854775807" &&
            saved.RootElement.GetProperty("future").GetProperty("fraction").GetRawText() == "1.234567890123456789",
            "Analytics acknowledgement rounded unmodeled numeric metadata.");
    }

    private static void CheckSourceChatMarker()
    {
        var source = RecoveredAnalyticsOracle.Advance(123, 456);
        Require(source == (456, 1, "456") && RecoveredAnalyticsOracle.Advance(456, 123).Calls == 0,
            "Original chat setter did not use monotonic canonical integer text.");
        var player = new LegacyPlayerDocument { Id = new string('a', 32), Serialized = new() };
        var planner = new LegacyBufferPlanner(LegacyCatalog.Empty, LegacyBufferProcessor.SupportedActions,
            NullLogger.Instance);
        var mutation = planner.Plan(player,
            new BufferedRequest(0, DatabaseAction.SaveLastSeenSquadChatTimeStamp, "456"), 1_700_000_000, 7);
        JsonObject state = LegacyAnalyticsState.Parse(mutation.Serialized[LegacyAnalyticsState.Key]);
        Require(mutation.Result == 1 && state["lastSeenSquadChatTimeStampDB"]!.GetValue<int>() == source.Value,
            "Buffered marker could not initialize a genuinely absent analytics object.");
        foreach (string value in new[] { "-1", "01", "+1", " 1", "1.0", "1e0" })
        {
            mutation = planner.Plan(player,
                new BufferedRequest(0, DatabaseAction.SaveLastSeenSquadChatTimeStamp, value), 1_700_000_000, 7);
            Require(mutation.Result == (int)DatabaseResult.WrongPlayerData && mutation.Serialized.Count == 0,
                "Malformed chat marker published analytics state.");
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

        throw new InvalidOperationException("Malformed analytics authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
