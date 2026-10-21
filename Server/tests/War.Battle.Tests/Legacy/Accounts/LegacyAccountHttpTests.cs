using System.Text.Json.Nodes;
using MongoDB.Bson;
using MongoDB.Driver;
using War.Persistence;

namespace War.Battle.Tests.Legacy.Accounts;

/// <summary>Checks actual unauthenticated registration, session rotation and damaged-row refusal over HTTP.</summary>
internal static class LegacyAccountHttpTests
{
    internal static async Task RunAsync(string uri, string databaseName, string baseUrl)
    {
        using var fixture = new Fixture(new MongoClient(uri).GetDatabase(databaseName), baseUrl);
        try
        {
            await CheckRejectedRegistrationAsync(fixture);
            await CheckCreationAndLoginAsync(fixture);
            await CheckConcurrentHttpCreationAsync(fixture);
            Console.WriteLine($"PASS: {fixture.Checks} account HTTP input, session and historical-damage assertions");
        }
        finally
        {
            await fixture.CleanupAsync();
        }
    }

    private static async Task CheckRejectedRegistrationAsync(Fixture fixture)
    {
        long before = await fixture.CountAsync();
        Dictionary<string, string>[] malformed =
        [
            new() { ["Locale"] = "en" }, new() { ["UtcOffset"] = "0" },
            new() { ["Locale"] = " en ", ["UtcOffset"] = "0" },
            new() { ["Locale"] = "en", ["UtcOffset"] = "NaN" },
            new() { ["Locale"] = "en", ["UtcOffset"] = "1e309" },
            new() { ["Locale"] = "en", ["UtcOffset"] = "25" },
            new() { ["Locale"] = "en", ["UtcOffset"] = "0", ["DeviceToken"] = "" },
            new() { ["Locale"] = "en", ["UtcOffset"] = "0", ["DeviceToken"] = "bad\ntoken" }
        ];
        foreach (Dictionary<string, string> fields in malformed)
        {
            JsonObject response = await fixture.SendAsync(118, fields);
            fixture.Require(Code(response) == 11301, "Malformed registration did not return WrongPlayerData.");
        }

        JsonObject provider = await fixture.SendAsync(146, new Dictionary<string, string>
        {
            ["Locale"] = "en",
            ["UtcOffset"] = "0",
            ["GameCenterId"] = " exact-platform-id ",
            ["GameCenterPassword"] = "unsupported"
        });
        fixture.Require(Code(provider) == 503, "Provider registration must retain its closed compatibility boundary.");
        fixture.Require(await fixture.CountAsync() == before,
            "Rejected metadata/provider requests created an account.");
    }

    private static async Task CheckCreationAndLoginAsync(Fixture fixture)
    {
        long before = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        JsonObject created = await fixture.CreateAsync();
        string id = created["Player"]!["Id"]!["S"]!.GetValue<string>();
        string token = created["Token"]!.GetValue<string>();
        string password = created["Password"]!.GetValue<string>();
        long time = created["Time"]!.GetValue<long>();
        fixture.Require(Code(created) == 1 && created["PlayerData"] is JsonObject && password.Length == 32 &&
            token.Length == 64 && time >= before && time <= DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
            "Registration omitted mandatory callbacks or applied the client's UTC offset to server time.");
        LegacyPlayerDocument saved = await fixture.ReadAsync(id);
        fixture.Require(saved.Revision == 1 && saved.Gold == 75 && saved.WarBucks == 15000 && saved.Locale == "kr" &&
            saved.DeviceToken == " padded-token " && saved.InitialUtcOffsetHours == 9.0000001 &&
            saved.LastAction == time && saved.DogTagLastUpdate == time,
            "Initial session, source starter state and exact registration metadata were not published together.");
        fixture.Require(saved.SessionHash == LegacyPlayerStore.HashToken(token),
            "Returned initial token differs from storage.");
        JsonObject login = await fixture.SendAsync(30,
            new Dictionary<string, string> { ["Id"] = id, ["Password"] = password });
        string rotatedToken = login["Token"]!.GetValue<string>();
        fixture.Require(Code(login) == 1 && login["AccountType"]!.GetValue<int>() == 0 &&
            login["Player"] is JsonObject && login["Password"]!.GetValue<string>() == password && rotatedToken != token,
            "Login omitted mandatory callbacks or failed to rotate the token.");
        LegacyPlayerDocument rotated = await fixture.ReadAsync(id);
        fixture.Require(rotated.Revision == 2 && rotated.SessionHash == LegacyPlayerStore.HashToken(rotatedToken),
            "Login returned an uncommitted token or revision.");
        fixture.Require(await fixture.Store.Authenticate(token, id, CancellationToken.None) == null &&
            await fixture.Store.Authenticate(rotatedToken, id, CancellationToken.None) != null,
            "Token rotation did not retire the previous session.");
        JsonObject wrong = await fixture.SendAsync(30,
            new Dictionary<string, string> { ["Id"] = id, ["Password"] = "wrong" });
        fixture.Require(Code(wrong) == 3001, "Wrong password must not receive a session.");
        await CheckDeviceTupleAsync(fixture, id, rotatedToken);
        await fixture.DamageSessionAsync(id);
        string damaged = (await fixture.ReadAsync(id)).ToBsonDocument().ToJson();
        JsonObject refused = await fixture.SendAsync(30,
            new Dictionary<string, string> { ["Id"] = id, ["Password"] = password });
        fixture.Require(Code(refused) == 503 && (await fixture.ReadAsync(id)).ToBsonDocument().ToJson() == damaged,
            "A historical empty session hash was silently repaired instead of refused.");
    }

    private static async Task CheckConcurrentHttpCreationAsync(Fixture fixture)
    {
        JsonObject[] replies = await Task.WhenAll(fixture.CreateAsync(), fixture.CreateAsync(), fixture.CreateAsync());
        fixture.Require(replies.All(reply => Code(reply) == 1) && replies.Select(reply =>
            reply["Token"]!.GetValue<string>()).Distinct().Count() == replies.Length,
            "Concurrent HTTP registrations collided with a historical empty session hash.");
        foreach (JsonObject reply in replies)
        {
            LegacyPlayerDocument player = await fixture.ReadAsync(reply["Player"]!["Id"]!["S"]!.GetValue<string>());
            fixture.Require(player.Revision == 1 && player.SessionHash ==
                LegacyPlayerStore.HashToken(reply["Token"]!.GetValue<string>()),
                "Initial HTTP session was not one insert.");
        }
    }

    private static async Task CheckDeviceTupleAsync(Fixture fixture, string id, string token)
    {
        string before = (await fixture.ReadAsync(id)).ToBsonDocument().ToJson();
        Dictionary<string, string>[] malformed = [new() { ["Locale"] = "en" },
            new() { ["DeviceToken"] = "token" }, new() { ["Locale"] = "en", ["DeviceToken"] = "" },
            new() { ["Locale"] = "en", ["DeviceToken"] = "bad\ntoken" }];
        foreach (Dictionary<string, string> fields in malformed)
        {
            fields["PlayerId"] = id;
            fields["Token"] = token;
            fixture.Require(Code(await fixture.SendAsync(13, fields)) == 11301,
                "Device registration requires its complete validated Locale/DeviceToken tuple.");
        }

        fixture.Require((await fixture.ReadAsync(id)).ToBsonDocument().ToJson() == before,
            "A rejected device tuple changed metadata, revision or durable presence.");
        JsonObject valid = await fixture.SendAsync(13, new Dictionary<string, string>
        {
            ["PlayerId"] = id,
            ["Token"] = token,
            ["Locale"] = "en_US",
            ["DeviceToken"] = " exact-next-token "
        });
        LegacyPlayerDocument saved = await fixture.ReadAsync(id);
        fixture.Require(Code(valid) == 1 && saved.Locale == "en_US" && saved.DeviceToken == " exact-next-token ",
            "A valid device tuple must preserve opaque token bytes and publish both fields together.");
    }

    private static int Code(JsonObject response) => response["Result"]!.GetValue<int>();

    private sealed class Fixture(IMongoDatabase database, string baseUrl) : IDisposable
    {
        private const int RequestTimeoutSeconds = 15;
        private readonly HttpClient _http = new()
        {
            BaseAddress = new Uri(baseUrl),
            Timeout = TimeSpan.FromSeconds(RequestTimeoutSeconds)
        };
        private readonly List<string> _identities = [];

        internal int Checks { get; private set; }

        internal LegacyPlayerStore Store { get; } = new(database);

        internal async Task<JsonObject> SendAsync(int action, Dictionary<string, string> fields)
        {
            fields["requestId"] = action.ToString(System.Globalization.CultureInfo.InvariantCulture);
            using var content = new FormUrlEncodedContent(fields);
            using HttpResponseMessage response = await _http.PostAsync("/index_09_25_2015.php", content);
            response.EnsureSuccessStatusCode();
            return JsonNode.Parse(await response.Content.ReadAsStringAsync())!.AsObject();
        }

        internal async Task<JsonObject> CreateAsync()
        {
            JsonObject response = await SendAsync(118, new Dictionary<string, string>
            {
                ["Locale"] = "kr",
                ["UtcOffset"] = "9.0000001",
                ["DeviceToken"] = " padded-token ",
                ["StartingGold"] = "Infinity",
                ["StartingWarbucks"] = "9999999999999999999999999"
            });
            if (Code(response) == 1)
            {
                lock (_identities)
                {
                    _identities.Add(response["Player"]!["Id"]!["S"]!.GetValue<string>());
                }
            }

            return response;
        }

        internal Task<LegacyPlayerDocument> ReadAsync(string id) =>
            database.GetCollection<LegacyPlayerDocument>("legacyPlayers").Find(row => row.Id == id).SingleAsync();

        internal Task<long> CountAsync() => database.GetCollection<LegacyPlayerDocument>("legacyPlayers")
            .CountDocumentsAsync(FilterDefinition<LegacyPlayerDocument>.Empty);

        internal Task DamageSessionAsync(string id) => database.GetCollection<LegacyPlayerDocument>("legacyPlayers")
            .UpdateOneAsync(row => row.Id == id, Builders<LegacyPlayerDocument>.Update
                .Set(row => row.SessionHash, "").Inc(row => row.Revision, 1));

        internal async Task CleanupAsync()
        {
            await database.GetCollection<LegacyPlayerDocument>("legacyPlayers").DeleteManyAsync(
                Builders<LegacyPlayerDocument>.Filter.In(row => row.Id, _identities));
        }

        internal void Require(bool condition, string message)
        {
            LegacyAccountTestFixture.Require(condition, message);
            Checks++;
        }

        public void Dispose() => _http.Dispose();
    }
}
