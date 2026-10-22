using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using Google.Protobuf;
using War.Client;
using War.Protocol;

namespace War.Battle.Tests.Legacy.Dispatch;

internal static class LegacyProtobufHttpTests
{
    internal static async Task RunAsync(string baseUrl)
    {
        using var http = new HttpClient { BaseAddress = new Uri(baseUrl), Timeout = TimeSpan.FromSeconds(15) };
        string probe = await PostAsync(http, "check.php", []);
        Require(probe == "ok", "Protobuf boot probe failed.");
        string config = await ActionAsync(http, new() { ["requestId"] = "157" });
        Require(config.StartsWith("success;", StringComparison.Ordinal), "Configuration callback contract changed.");
        var registration = new Dictionary<string, string>
        {
            ["requestId"] = "118", ["Locale"] = "en", ["UtcOffset"] = "0",
            ["Version"] = "1.4.0", ["Os"] = "android"
        };
        JsonObject created = JsonNode.Parse(await ActionAsync(http, registration))!.AsObject();
        Require(created["Result"]!.GetValue<int>() == 1, "Protobuf account creation failed.");
        string playerId = created["Player"]!["Id"]!["S"]!.GetValue<string>();
        string token = created["Token"]!.GetValue<string>();
        JsonObject state = JsonNode.Parse(await ActionAsync(http, new()
        {
            ["requestId"] = "34", ["PlayerId"] = playerId, ["Token"] = token, ["Buffers"] = "null"
        }))!.AsObject();
        Require(state["Result"]!.GetValue<int>() == 1 && state["PlayerData"] != null,
            "Protobuf account session must reach the existing player-state projection.");
        JsonObject refused = JsonNode.Parse(await ActionAsync(http, new()
        {
            ["requestId"] = "34", ["PlayerId"] = playerId, ["Token"] = "invalid"
        }))!.AsObject();
        Require(refused["Result"]!.GetValue<int>() == 99990, "Protobuf must not bypass authentication.");
        var duplicate = new ClientActionRequest { FormatVersion = 1 };
        duplicate.Fields.Add(new ClientActionField { Name = "requestId", Value = "157" });
        duplicate.Fields.Add(new ClientActionField { Name = "requestId", Value = "118" });
        refused = JsonNode.Parse(await PostAsync(http, "index_09_25_2015.php", duplicate.ToByteArray()))!.AsObject();
        Require(refused["Result"]!.GetValue<int>() > 10, "Duplicate action fields were accepted.");
        Console.WriteLine("PASS: native protobuf probe/config/account/player-state/authentication/duplicate-field checks");
    }

    private static Task<string> ActionAsync(HttpClient http, Dictionary<string, string> fields) =>
        PostAsync(http, "index_09_25_2015.php", BackendActionCodec.Encode(fields));

    private static async Task<string> PostAsync(HttpClient http, string path, byte[] bytes)
    {
        using var content = new ByteArrayContent(bytes);
        content.Headers.ContentType = new MediaTypeHeaderValue(BackendActionCodec.ContentType);
        using HttpResponseMessage response = await http.PostAsync(path, content);
        response.EnsureSuccessStatusCode();
        Require(response.Content.Headers.ContentType?.MediaType == BackendActionCodec.ContentType,
            "Native Backend returned a non-protobuf body.");
        return BackendActionCodec.Decode(await response.Content.ReadAsByteArrayAsync());
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
