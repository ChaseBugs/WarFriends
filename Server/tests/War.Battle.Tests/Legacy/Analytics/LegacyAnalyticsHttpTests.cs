using System.Globalization;
using System.Text.Json.Nodes;
using MongoDB.Bson;
using MongoDB.Driver;
using War.Backend.Legacy;
using War.Battle.Tests.Support;
using War.Persistence;
using War.Persistence.Legacy.Analytics;

namespace War.Battle.Tests.Legacy.Analytics;

/// <summary>Exercises the seven real routes and rejects damaged analytics through authentication and boot.</summary>
internal static class LegacyAnalyticsHttpTests
{
    private static readonly (int Action, LegacyAnalyticsFlag Flag)[] Actions =
    [
        (163, LegacyAnalyticsFlag.Chat), (168, LegacyAnalyticsFlag.Customization),
        (169, LegacyAnalyticsFlag.Warpath), (180, LegacyAnalyticsFlag.CardPool),
        (182, LegacyAnalyticsFlag.LeagueLeaderboards), (183, LegacyAnalyticsFlag.Crafting),
        (213, LegacyAnalyticsFlag.Elites)
    ];

    internal static async Task RunAsync(string uri, string databaseName, string baseUrl)
    {
        await using var fixture = new Fixture(new MongoClient(uri).GetDatabase(databaseName), baseUrl);
        await CheckRoutesAsync(fixture);
        await CheckDamagedStateAsync(fixture);
        Console.WriteLine($"PASS: {fixture.Checks} analytics HTTP flag/replay/metadata/corruption assertions");
    }

    private static async Task CheckRoutesAsync(Fixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync(
            "{\"goldSpent\":5,\"future\":{\"exact\":9223372036854775807,\"fraction\":1.234567890123456789}}");
        var expected = new List<string>();
        foreach (var route in Actions)
        {
            string name = LegacyAnalyticsState.FlagName(route.Flag);
            expected.Add(name);
            JsonObject response = await fixture.SendAsync(player, route.Action,
                [("Name", "goldSpent"), ("Flag", "not-a-source-flag"), ("Value", "0")]);
            BsonDocument saved = await fixture.ReadAsync(player.Id);
            JsonObject state = LegacyAnalyticsState.Parse(saved["Serialized"][LegacyAnalyticsState.Key].AsString);
            fixture.Require(Code(response) == 1 && expected.All(flag => state[flag]!.GetValue<bool>()) &&
                state["goldSpent"]!.GetValue<int>() == 5 &&
                state["future"]!["exact"]!.GetValue<long>() == long.MaxValue && !state.ContainsKey("not-a-source-flag"),
                "A route selected a diagnostic flag or overwrote existing data.");
            response = await fixture.SendAsync(player, route.Action, []);
            fixture.Require(Code(response) == 1 && Same(saved, await fixture.ReadAsync(player.Id)),
                "An acknowledged true flag was charged another revision.");
        }

        JsonObject boot = await fixture.SendAsync(player, 34, []);
        fixture.Require(Code(boot) == 1 && boot["PlayerData"]![LegacyAnalyticsState.Key]!["S"] != null,
            "Valid acknowledged analytics did not survive the ordinary boot projection.");
    }

    private static async Task CheckDamagedStateAsync(Fixture fixture)
    {
        LegacyPlayerDocument viewer = await fixture.SeedAsync("{}");
        foreach (string? json in new string?[]
        {
            null, "null", "[]", "{\"chatShown\":1}", "{\"ChatShown\":true}",
            "{\"future\":1,\"future\":2}", "{\"goldSpent\":\"5\"}", "{\"transactions\":[null]}"
        })
        {
            LegacyPlayerDocument player = await fixture.SeedAsync(json);
            BsonDocument before = await fixture.ReadAsync(player.Id);
            foreach (var route in Actions)
            {
                JsonObject response = await fixture.SendAsync(player, route.Action, []);
                fixture.Require(Code(response) == (int)DatabaseResult.ServerMaintenance,
                    "Damaged analytics reached acknowledgement success.");
            }

            JsonObject boot = await fixture.SendAsync(player, 34, []);
            JsonObject peer = await fixture.SendAsync(viewer, 170, [("PlayerInfoId", player.Id)]);
            BsonDocument after = await fixture.ReadAsync(player.Id);
            fixture.Require(Code(boot) == (int)DatabaseResult.ServerMaintenance &&
                Code(peer) == (int)DatabaseResult.ServerMaintenance && Same(before, after) &&
                await fixture.ReceiptCountAsync(player.Id) == 0,
                "Boot/peer read repaired, projected or consumed damaged analytics authority.");
        }
    }

    private static int Code(JsonObject response) => response["Result"]!.GetValue<int>();

    private static bool Same(BsonDocument before, BsonDocument after) =>
        before.ToBson().AsSpan().SequenceEqual(after.ToBson());

    private sealed class Fixture(IMongoDatabase database, string baseUrl) : IAsyncDisposable
    {
        private const int TimeoutSeconds = 15;
        private readonly HttpClient _http = new()
        {
            BaseAddress = new Uri(baseUrl), Timeout = TimeSpan.FromSeconds(TimeoutSeconds)
        };
        private readonly Dictionary<string, string> _tokens = [];
        private readonly List<string> _ids = [];

        internal int Checks { get; private set; }

        private IMongoCollection<BsonDocument> Players => database.GetCollection<BsonDocument>("legacyPlayers");

        internal async Task<LegacyPlayerDocument> SeedAsync(string? json)
        {
            string token = LegacyPlayerStore.NewToken();
            var player = new LegacyPlayerDocument
            {
                Id = Guid.NewGuid().ToString("N"), Name = "Recruit", Gold = 100, DogTagMax = 4500,
                DogTagLastUpdate = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                SessionHash = LegacyPlayerStore.HashToken(token), CreatedUtc = DateTime.UtcNow.AddMinutes(-1),
                Serialized = LegacyInitialLoadout.CreateSerializedState()
            };
            player.Serialized[LegacyAnalyticsState.Key] = json!;
            await LegacyTestAccounts.InsertAsync(database, player, CancellationToken.None);
            _tokens.Add(player.Id, token);
            _ids.Add(player.Id);
            return player;
        }

        internal Task<BsonDocument> ReadAsync(string id) => Players.Find(new BsonDocument("_id", id)).SingleAsync();

        internal Task<long> ReceiptCountAsync(string id) => database.GetCollection<BsonDocument>("legacyBufferReceipts")
            .CountDocumentsAsync(new BsonDocument("PlayerId", id));

        internal async Task<JsonObject> SendAsync(
            LegacyPlayerDocument player, int action, (string Key, string Value)[] fields)
        {
            IEnumerable<KeyValuePair<string, string>> values = fields.Select(field =>
                new KeyValuePair<string, string>(field.Key, field.Value)).Concat(new Dictionary<string, string>
            {
                ["requestId"] = action.ToString(CultureInfo.InvariantCulture),
                ["Token"] = _tokens[player.Id], ["PlayerId"] = player.Id
            });
            using var content = new FormUrlEncodedContent(values);
            using HttpResponseMessage response = await _http.PostAsync("/index_09_25_2015.php", content);
            response.EnsureSuccessStatusCode();
            return JsonNode.Parse(await response.Content.ReadAsStringAsync())!.AsObject();
        }

        internal void Require(bool condition, string message)
        {
            if (!condition)
            {
                throw new InvalidOperationException(message);
            }

            Checks++;
        }

        public async ValueTask DisposeAsync()
        {
            await Players.DeleteManyAsync(Builders<BsonDocument>.Filter.In("_id", _ids));
            _http.Dispose();
        }
    }
}
