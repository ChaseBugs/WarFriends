using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using War.Backend.Legacy;

namespace War.Battle.Tests.Legacy;

/// <summary>Checks complete rejection of malformed envelopes instead of silently dropping entries.</summary>
internal static class LegacyBufferParserTests
{
    internal static int Run()
    {
        int checks = 0;
        IReadOnlyList<BufferedRequest> ordered = LegacyBufferParser.ParseRequests(
            "{\"2\":{\"action\":104,\"data\":null},\"0\":{\"action\":104,\"data\":\"weapon\"}}");
        Require(ordered.Count == 2 && ordered[0].Index == 0 && ordered[1].Data == null,
            "Source request dictionary was not decoded in index order.");
        checks++;

        string[] malformedRequests =
        [
            "[]", "null", "true", "{", "{\"-1\":{\"action\":104}}", "{\"01\":{\"action\":104}}",
            "{\"+1\":{\"action\":104}}", "{\" 1\":{\"action\":104}}", "{\"2147483648\":{\"action\":104}}",
            "{\"0\":null}", "{\"0\":{\"action\":\"104\"}}", "{\"0\":{\"action\":true}}",
            "{\"0\":{\"action\":1.5}}", "{\"0\":{\"action\":999999}}", "{\"0\":{\"data\":\"x\"}}",
            "{\"0\":{\"action\":104,\"data\":{}}}", "{\"0\":{\"action\":104,\"data\":1}}",
            "{\"0\":{\"action\":104,\"action\":104}}",
            "{\"0\":{\"action\":104,\"data\":null},\"0\":{\"action\":104,\"data\":null}}",
            "{\"0\":{\"action\":104,\"data\":null},\"1\":{\"action\":[],\"data\":null}}",
            "{\"0\":{\"action\":104}}", "{\"0\":{\"action\":104,\"data\":null,\"extra\":true}}"
        ];
        foreach (string json in malformedRequests)
        {
            Reject(() => LegacyBufferParser.ParseRequests(json));
            checks++;
        }

        string maximum = CreateRequests(LegacyBufferParser.MaxRequestsPerBuffer).ToJsonString();
        Require(LegacyBufferParser.ParseRequests(maximum).Count == LegacyBufferParser.MaxRequestsPerBuffer,
            "The exact request-count boundary was rejected.");
        Reject(() => LegacyBufferParser.ParseRequests(
            CreateRequests(LegacyBufferParser.MaxRequestsPerBuffer + 1).ToJsonString()));
        checks += 2;

        Require(LegacyBufferParser.IsValidBufferId(new string('a', 128)), "Valid buffer ID boundary was rejected.");
        Require(!LegacyBufferParser.IsValidBufferId(new string('a', 129)), "Oversized buffer ID was accepted.");
        Require(!LegacyBufferParser.IsValidBufferId(null), "Missing buffer ID was accepted.");
        checks += 3;

        var buffers = new JsonObject();
        for (int index = 0; index < LegacyBufferParser.MaxBuffers; index++)
        {
            buffers[index.ToString(CultureInfo.InvariantCulture)] = new JsonObject { ["requests"] = CreateRequests(1) };
        }

        Require(LegacyBufferParser.ParseBuffers(buffers.ToJsonString()).Count == LegacyBufferParser.MaxBuffers,
            "The exact buffer-count boundary was rejected.");
        buffers["overflow"] = new JsonObject { ["requests"] = CreateRequests(1) };
        Reject(() => LegacyBufferParser.ParseBuffers(buffers.ToJsonString()));
        checks += 2;

        string[] malformedBuffers =
        [
            "[]", "{\"x\":null}", "{\"\":{\"requests\":{}}}", "{\"x\":{}}",
            "{\"x\":{\"requests\":[]}}", "{\"x\":{\"requests\":{},\"id\":\"other\"}}",
            "{\"x\":{\"requests\":{},\"requestCount\":1}}", "{\"x\":{\"requests\":{},\"alreadySent\":1}}",
            "{\"x\":{\"requests\":{}},\"x\":{\"requests\":{}}}",
            "{\"first\":{\"requests\":{}},\"last\":{\"requests\":{\"0\":{\"action\":true}}}}",
            "{\"x\":{\"requests\":{},\"extra\":true}}", "{\"x\\u0001\":{\"requests\":{}}}"
        ];
        foreach (string json in malformedBuffers)
        {
            Reject(() => LegacyBufferParser.ParseBuffers(json));
            checks++;
        }

        return checks + CheckPayloadValueTypes();
    }

    private static int CheckPayloadValueTypes()
    {
        Require(LegacyBufferPayload.ReadString(JsonValue.Create("weapon")) == "weapon",
            "A valid source string was rejected.");
        Reject(() => LegacyBufferPayload.ReadString(JsonValue.Create(true)));
        Reject(() => LegacyBufferPayload.ReadString(new JsonObject()));
        Require(LegacyBufferPayload.ReadFlag(new JsonObject { ["equipped"] = true }, "equipped"),
            "A valid source equipped flag was rejected.");
        Reject(() => LegacyBufferPayload.ReadFlag(JsonValue.Create(true), "equipped"));
        Reject(() => LegacyBufferPayload.ReadFlag(new JsonObject { ["equipped"] = "true" }, "equipped"));
        return 6;
    }

    private static JsonObject CreateRequests(int count)
    {
        var requests = new JsonObject();
        for (int index = 0; index < count; index++)
        {
            requests[index.ToString(CultureInfo.InvariantCulture)] =
                new JsonObject { ["action"] = (int)DatabaseAction.WeaponWasShown, ["data"] = "weapon" };
        }

        return requests;
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

        throw new InvalidOperationException("Malformed buffer was accepted or silently truncated.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
