using System.Globalization;
using System.Text.Json.Nodes;
using MongoDB.Bson;
using MongoDB.Driver;
using War.Backend.Legacy;
using War.Battle.Tests.Support;
using War.Persistence;

namespace War.Battle.Tests.Legacy.Preferences;

/// <summary>Checks the live complete Settings contract, durable metadata and refused corrupt buffered state.</summary>
internal static class LegacySettingsHttpTests
{
    internal static async Task RunAsync(string uri, string databaseName, string baseUrl)
    {
        using var fixture = new Fixture(new MongoClient(uri).GetDatabase(databaseName), baseUrl);
        try
        {
            await CheckRequestsAsync(fixture);
            await CheckDamagedSettingsAsync(fixture);
            await CheckDamagedBufferAsync(fixture);
            await CheckLoginAsync(fixture);
            Console.WriteLine($"PASS: {fixture.Checks} Settings/state HTTP contract/preservation/refusal assertions");
        }
        finally
        {
            await fixture.CleanupAsync();
        }
    }

    private static async Task CheckRequestsAsync(Fixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        foreach (string json in new[] { "{}", "[]", "null", "{\"challenge\":true}",
            LegacySettingsStoreTests.AllOn.Replace("true", "\"true\"", StringComparison.Ordinal),
            LegacySettingsStoreTests.AllOn[..^1] + ",\"unknown\":true}",
            LegacySettingsStoreTests.AllOn[..^1] + ",\"challenge\":false}",
            LegacySettingsStoreTests.AllOn.Replace("\"challenge\"", "\"Challenge\"", StringComparison.Ordinal) })
        {
            JsonObject response = await fixture.SendAsync(player, 165, [("Settings", json)]);
            fixture.Require(Code(response) > 10, "Malformed complete Settings request reached success.");
        }

        JsonObject duplicate = await fixture.SendAsync(player, 165,
            [("Settings", LegacySettingsStoreTests.AllOn), ("Settings", LegacySettingsStoreTests.AllOff)]);
        fixture.Require(Code(duplicate) == (int)DatabaseResult.WrongPlayerData,
            "Repeated form fields selected a Settings mutation through joining or precedence.");
        LegacyPlayerDocument unchanged = await fixture.ReadAsync(player.Id);
        fixture.Require(unchanged.Revision == 1 && unchanged.Serialized["Settings"] == player.Serialized["Settings"],
            "Rejected Settings request changed durable state or revision.");
        JsonObject valid = await fixture.SendAsync(player, 165, [("Settings", LegacySettingsStoreTests.AllOn)]);
        fixture.Require(Code(valid) == 1, "Complete source Settings request was rejected.");
        JsonObject boot = await fixture.SendAsync(player, 34, []);
        JsonObject state = JsonNode.Parse(boot["PlayerData"]!["Settings"]!["S"]!.GetValue<string>())!.AsObject();
        fixture.Require(state["challenge"]!.GetValue<bool>() && state["maintenance"]!.GetValue<bool>() &&
            state["futureMetadata"]!["exact"]!.GetValue<long>() == long.MaxValue,
            "Known flags or retained exact metadata were lost at the boot wire boundary.");
    }

    private static async Task CheckDamagedSettingsAsync(Fixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        await fixture.Players.UpdateOneAsync(row => row.Id == player.Id,
            Builders<LegacyPlayerDocument>.Update.Set("Serialized.Settings", "{\"challenge\":true}"));
        foreach (int action in new[] { 165, 34, 167 })
        {
            JsonObject response = await fixture.SendAsync(
                player, action, [("Settings", LegacySettingsStoreTests.AllOn)]);
            fixture.Require(Code(response) == (int)DatabaseResult.ServerMaintenance,
                "Authentication accepted incomplete present Settings as default state.");
        }

        LegacyPlayerDocument saved = await fixture.ReadAsync(player.Id);
        fixture.Require(saved.Revision == 1 && saved.Serialized["Settings"] == "{\"challenge\":true}",
            "Corrupt Settings was silently repaired by an update or boot.");
    }

    private static async Task CheckDamagedBufferAsync(Fixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        string requests = new JsonObject
        {
            ["0"] = new JsonObject { ["action"] = (int)DatabaseAction.WeaponWasShown, ["data"] = "source-rifle" }
        }.ToJsonString();
        foreach (string? damaged in new string?[] { null, "null", "{\"savedWeapons\":null}",
            "{\"savedWeapons\":{\"rifle\":{\"boughtIndex\":\"1\"}}}" })
        {
            await fixture.Players.UpdateOneAsync(row => row.Id == player.Id,
                Builders<LegacyPlayerDocument>.Update.Set("Serialized.LevelManagerData", damaged));
            JsonObject response = await fixture.SendAsync(player, 98,
                [("BufferId", "invalid-state"), ("Count", "1"), ("Requests", requests)]);
            fixture.Require(Code(response) == (int)DatabaseResult.ServerMaintenance,
                "Present damaged state became a default model or a completed client-input failure receipt.");
            LegacyPlayerDocument saved = await fixture.ReadAsync(player.Id);
            fixture.Require(saved.Revision == 1 && saved.Serialized["LevelManagerData"] == damaged,
                "Refused buffered state was rewritten into a fresh authority snapshot.");
            fixture.Require(await fixture.ReceiptCountAsync(player.Id) == 0,
                "Corrupt durable state consumed a buffered intent receipt before rejection.");
        }
    }

    private static async Task CheckLoginAsync(Fixture fixture)
    {
        JsonObject created = await fixture.SendPublicAsync(118, [("Locale", "en"), ("UtcOffset", "0")]);
        fixture.Require(Code(created) == 1, "Credential-bound Settings fixture registration failed.");
        string id = created["Player"]!["Id"]!["S"]!.GetValue<string>();
        fixture.Track(id);
        LegacyPlayerDocument before = await fixture.ReadAsync(id);
        await fixture.Players.UpdateOneAsync(row => row.Id == id,
            Builders<LegacyPlayerDocument>.Update.Set("Serialized.Settings", "null"));
        JsonObject login = await fixture.SendPublicAsync(30,
            [("Id", id), ("Password", created["Password"]!.GetValue<string>())]);
        LegacyPlayerDocument after = await fixture.ReadAsync(id);
        fixture.Require(Code(login) == (int)DatabaseResult.ServerMaintenance &&
            after.SessionHash == before.SessionHash && after.Revision == before.Revision,
            "Login rotated a session before validating present Settings authority.");
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
        private readonly Dictionary<string, string> _tokens = [];
        private readonly List<string> _identities = [];
        internal int Checks { get; private set; }
        internal IMongoCollection<LegacyPlayerDocument> Players { get; } =
            database.GetCollection<LegacyPlayerDocument>("legacyPlayers");

        internal async Task<LegacyPlayerDocument> SeedAsync()
        {
            string token = LegacyPlayerStore.NewToken();
            var player = new LegacyPlayerDocument
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "Settings fixture",
                Gold = 100,
                DogTagMax = 4500,
                DogTagLastUpdate = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                CreatedUtc = DateTime.UtcNow.AddMinutes(-1),
                SessionHash = LegacyPlayerStore.HashToken(token)
            };
            JsonObject state = JsonNode.Parse(LegacySettingsStoreTests.AllOff)!.AsObject();
            state["futureMetadata"] = new JsonObject { ["exact"] = long.MaxValue };
            player.Serialized["Settings"] = state.ToJsonString();
            await LegacyTestAccounts.InsertAsync(database, player, CancellationToken.None);
            _tokens.Add(player.Id, token);
            Track(player.Id);
            return player;
        }

        internal Task<JsonObject> SendAsync(
            LegacyPlayerDocument player, int action, (string Key, string Value)[] fields) =>
            SendPublicAsync(action, fields.Concat(new[]
            {
                ("Token", _tokens[player.Id]), ("PlayerId", player.Id)
            }).ToArray());

        internal async Task<JsonObject> SendPublicAsync(int action, (string Key, string Value)[] fields)
        {
            IEnumerable<KeyValuePair<string, string>> form = fields.Select(field =>
                new KeyValuePair<string, string>(field.Key, field.Value)).Append(
                new KeyValuePair<string, string>("requestId", action.ToString(CultureInfo.InvariantCulture)));
            using var content = new FormUrlEncodedContent(form);
            using HttpResponseMessage response = await _http.PostAsync("/index_09_25_2015.php", content);
            response.EnsureSuccessStatusCode();
            return JsonNode.Parse(await response.Content.ReadAsStringAsync())!.AsObject();
        }

        internal Task<LegacyPlayerDocument> ReadAsync(string id) => Players.Find(row => row.Id == id).SingleAsync();
        internal Task<long> ReceiptCountAsync(string id) => database.GetCollection<BsonDocument>("legacyBufferReceipts")
            .CountDocumentsAsync(new BsonDocument("PlayerId", id));
        internal void Track(string id) => _identities.Add(id);
        internal Task CleanupAsync() => Players.DeleteManyAsync(
            Builders<LegacyPlayerDocument>.Filter.In(player => player.Id, _identities));

        internal void Require(bool condition, string message)
        {
            if (!condition)
            {
                throw new InvalidOperationException(message);
            }

            Checks++;
        }

        public void Dispose() => _http.Dispose();
    }
}
