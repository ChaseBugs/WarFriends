using System.Globalization;
using System.Text.Json.Nodes;
using War.Backend.Legacy;

namespace War.Battle.Tests;

/// <summary>Exercises the actual recovered start callback through the running legacy HTTP endpoint.</summary>
internal static class LegacyBattleStartChecks
{
    private const string ActionPath = "index_09_25_2015.php";

    internal static async Task RequireUnavailableAsync(Uri endpoint, string playerId, string token)
    {
        using var http = new HttpClient { BaseAddress = endpoint };
        Dictionary<string, string> fields = CreateFields(playerId, token);
        JsonObject response = await SendAsync(http, fields);
        Require((int?)response["Result"] == (int)DatabaseResult.ServerDidntRespondBeforeGame,
            "Unpublished or absent battle authority must not acknowledge a start.");
    }

    internal static async Task VerifyPublishedAsync(Uri endpoint, string playerId, string token, string matchId)
    {
        using var http = new HttpClient { BaseAddress = endpoint };
        Dictionary<string, string> fields = CreateFields(playerId, token);
        foreach (string action in new[] { "64", "65" })
        {
            fields["requestId"] = action;
            fields["BattleId"] = matchId;
            if (action == "64")
            {
                fields.Remove("IsHitList");
            }
            else
            {
                fields["IsHitList"] = "0";
            }
            JsonObject first = await SendAsync(http, fields);
            JsonObject replay = await SendAsync(http, fields);
            Require((int?)first["Result"] == (int)DatabaseResult.Success &&
                (string?)first["BattleId"] == matchId && (long?)first["Time"] > 0 &&
                (int?)replay["Result"] == (int)DatabaseResult.Success && (string?)replay["BattleId"] == matchId,
                "Both recovered callback actions must acknowledge only the existing match, including retry.");
            Require(!first.ContainsKey("Seconds") && !first.ContainsKey("Gold") && !first.ContainsKey("WarBucks"),
                "A start acknowledgement must not invent an economy mutation.");
        }

        foreach (var invalid in new Dictionary<string, string>
        {
            ["BattleId"] = "m" + Guid.NewGuid().ToString("N"),
            ["IsMatchMaking"] = "01",
            ["IsWarArenaBattle"] = "1",
            ["DogTagCap"] = " 5",
            ["DogTagRefillTime"] = "900.0",
            ["BotId"] = "0"
        })
        {
            var malformed = new Dictionary<string, string>(fields) { [invalid.Key] = invalid.Value };
            JsonObject rejected = await SendAsync(http, malformed);
            Require((int?)rejected["Result"] == (int)DatabaseResult.ServerDidntRespondBeforeGame,
                "Malformed or conflicting start assertions must remain callback-safe failures.");
        }
        fields.Remove("BattleId");
        JsonObject missingIdentity = await SendAsync(http, fields);
        Require((int?)missingIdentity["Result"] == (int)DatabaseResult.ServerDidntRespondBeforeGame,
            "An omitted battle identity must not select the account's current allocation implicitly.");
        fields["Token"] = "invalid-session";
        JsonObject unauthenticated = await SendAsync(http, fields);
        Require((int?)unauthenticated["Result"] == (int)DatabaseResult.InvalidToken,
            "A start acknowledgement must retain legacy session authentication.");
        Console.WriteLine("PASS: recovered start acknowledgements bind published match authority and reject conflicts");
    }

    private static Dictionary<string, string> CreateFields(string playerId, string token)
    {
        return new Dictionary<string, string>
        {
            ["requestId"] = ((int)DatabaseAction.GameStartedClient).ToString(CultureInfo.InvariantCulture),
            ["PlayerId"] = playerId,
            ["Token"] = token,
            ["IsMatchMaking"] = "1",
            ["IsHitList"] = "0",
            ["IsWarArenaBattle"] = "0",
            ["DogTagCap"] = "5",
            ["DogTagRefillTime"] = "900"
        };
    }

    private static async Task<JsonObject> SendAsync(HttpClient http, Dictionary<string, string> fields)
    {
        using var body = new FormUrlEncodedContent(fields);
        using HttpResponseMessage response = await http.PostAsync(ActionPath, body);
        response.EnsureSuccessStatusCode();
        return JsonNode.Parse(await response.Content.ReadAsStringAsync()) as JsonObject
            ?? throw new InvalidDataException("The legacy start response is not a JSON object.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
