using System.Globalization;
using System.Text.Json.Nodes;
using MongoDB.Bson;
using MongoDB.Driver;
using War.Backend.Legacy;
using War.Battle.Tests.Support;
using War.Persistence;
using War.Persistence.Legacy.Tutorial;

namespace War.Battle.Tests.Legacy.Tutorial;

/// <summary>
/// Tests real tutorial callback bodies, identity-bound replay, no rewards and explicit legacy refusal.
/// </summary>
internal static class LegacyTutorialHttpTests
{
    internal static async Task RunAsync(string uri, string databaseName, string baseUrl)
    {
        await using var fixture = new Fixture(new MongoClient(uri).GetDatabase(databaseName), baseUrl);
        await CheckLifecycleAsync(fixture);
        await CheckLegacyAsync(fixture);
        await CheckDamagedAsync(fixture);
        Console.WriteLine($"PASS: {fixture.Checks} tutorial HTTP identity/callback/replay/migration/no-reward checks");
    }

    private static async Task CheckLifecycleAsync(Fixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        JsonObject start = await fixture.SendAsync(player, 119, [("Name", "untrusted replacement")]);
        string id = start["BattleId"]!.GetValue<string>();
        BsonDocument pending = await fixture.ReadAsync(player.Id);
        fixture.Require(Code(start) == 1 && LegacyTutorialAuthority.IsBattleId(id) && pending["Name"] == "Recruit",
            "Start omitted mandatory identity or trusted the diagnostic name.");
        JsonObject repeatStart = await fixture.SendAsync(player, 119, []);
        fixture.Require(Code(repeatStart) == 1 && repeatStart["BattleId"]!.GetValue<string>() == id &&
            Same(pending, await fixture.ReadAsync(player.Id)),
            "Duplicate start replaced its ID or consumed a revision.");
        await fixture.RequireWrongBattleAsync(player, [("BattleId", new string('b', 32))]);

        JsonObject end = await fixture.SendAsync(player, 120,
            [("BattleId", id), ("EndReason", "999"), ("Experience", "999999"), ("Gold", "999999"),
             ("Warbucks", "999999"), ("GoldBoxes", "999999"), ("ArmyPower", "999999")]);
        BsonDocument completed = await fixture.ReadAsync(player.Id);
        fixture.Require(Code(end) == 1 && end["LevelExperience"]!.GetValue<int>() == 17 &&
            end["TutorialData"]!.GetValue<bool>() && !end.ContainsKey("IsWarArena") && !end.ContainsKey("GameReward") &&
            completed["TutorialCompleted"].AsBoolean && completed["PendingTutorialBattleId"].IsBsonNull &&
            completed["TutorialState"]["BattleId"] == id && completed["Gold"].AsInt64 == 100 &&
            completed["WarBucks"].AsInt64 == 50 && completed["Experience"].AsInt64 == 0 &&
            completed["LevelExperience"].AsInt32 == 17,
            "End omitted callback fields, granted assertions or failed to bind terminal identity.");
        JsonObject replay = await fixture.SendAsync(player, 120, [("BattleId", id), ("Gold", "123")]);
        fixture.Require(JsonNode.DeepEquals(end, replay) && Same(completed, await fixture.ReadAsync(player.Id)),
            "Identity-bound end replay applied again or changed its unchanged-state wire view.");
        JsonObject completedStart = await fixture.SendAsync(player, 119, []);
        fixture.Require(completedStart["BattleId"]!.GetValue<string>() == id &&
            Same(completed, await fixture.ReadAsync(player.Id)), "Start reopened a completed tutorial identity.");
        foreach ((string Key, string Value)[] fields in new (string, string)[][]
        {
            [], [("BattleId", new string('A', 32))], [("BattleId", " " + id)],
            [("BattleId", id), ("BattleId", id)], [("BattleId", new string('c', 32))]
        })
        {
            await fixture.RequireWrongBattleAsync(player, fields);
        }

        fixture.Change(player.Id, Builders<BsonDocument>.Update.Set("LevelExperience", 33).Inc("Revision", 1L));
        replay = await fixture.SendAsync(player, 120, [("BattleId", id)]);
        fixture.Require(replay["LevelExperience"]!.GetValue<int>() == 33,
            "A delayed tutorial receipt returned obsolete XP after later progress.");
        JsonObject boot = await fixture.SendAsync(player, 34, []);
        fixture.Require(Code(boot) == 1 && boot["PlayerData"]!["TutorialData"] != null,
            "Completed tutorial no longer survived the existing boot marker.");
    }

    private static async Task CheckLegacyAsync(Fixture fixture)
    {
        string id = new('d', 32);
        LegacyPlayerDocument pending = await fixture.SeedAsync(new() { PendingTutorialBattleId = id });
        JsonObject start = await fixture.SendAsync(pending, 119, []);
        fixture.Require(Code(start) == 1 && start["BattleId"]!.GetValue<string>() == id &&
            (await fixture.ReadAsync(pending.Id))["TutorialState"]["Version"].AsInt32 == 1,
            "Legacy pending migration fabricated another identity.");
        LegacyPlayerDocument unbound = await fixture.SeedAsync(new() { TutorialCompleted = true });
        BsonDocument before = await fixture.ReadAsync(unbound.Id);
        JsonObject boot = await fixture.SendAsync(unbound, 34, []);
        JsonObject blockedStart = await fixture.SendAsync(unbound, 119, []);
        JsonObject blockedEnd = await fixture.SendAsync(unbound, 120, [("BattleId", id)]);
        fixture.Require(Code(boot) == 1 && boot["PlayerData"]!["TutorialData"] != null &&
            Code(blockedStart) == (int)DatabaseResult.ServerMaintenance &&
            Code(blockedEnd) == (int)DatabaseResult.ServerMaintenance &&
            Same(before, await fixture.ReadAsync(unbound.Id)),
            "Legacy unbound completion was reset, made unreadable or promoted into replay proof.");
    }

    private static async Task CheckDamagedAsync(Fixture fixture)
    {
        (string Field, BsonValue Value)[] cases =
        [
            ("TutorialCompleted", 1), ("TutorialCompleted", BsonNull.Value), ("PendingTutorialBattleId", "bad"),
            ("TutorialState", BsonNull.Value), ("TutorialState", new BsonDocument())
        ];
        foreach (var damage in cases)
        {
            LegacyPlayerDocument player = await fixture.SeedAsync();
            fixture.Change(player.Id, Builders<BsonDocument>.Update.Set(damage.Field, damage.Value));
            BsonDocument before = await fixture.ReadAsync(player.Id);
            JsonObject start = await fixture.SendAsync(player, 119, []);
            JsonObject end = await fixture.SendAsync(player, 120, [("BattleId", new string('e', 32))]);
            JsonObject boot = await fixture.SendAsync(player, 34, []);
            fixture.Require(Code(start) == (int)DatabaseResult.ServerMaintenance &&
                Code(end) == (int)DatabaseResult.ServerMaintenance &&
                Code(boot) == (int)DatabaseResult.ServerMaintenance && Same(before, await fixture.ReadAsync(player.Id)),
                "Damaged tutorial authority reached a success or was reset.");
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

        internal async Task<LegacyPlayerDocument> SeedAsync(LegacyPlayerDocument? player = null)
        {
            string token = LegacyPlayerStore.NewToken();
            player ??= new LegacyPlayerDocument();
            player.Id = Guid.NewGuid().ToString("N");
            player.Name = "Recruit";
            player.Gold = 100;
            player.WarBucks = 50;
            player.LevelExperience = 17;
            player.DogTagMax = 4500;
            player.DogTagLastUpdate = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            player.CreatedUtc = DateTime.UtcNow.AddMinutes(-1);
            player.SessionHash = LegacyPlayerStore.HashToken(token);
            player.Serialized = LegacyInitialLoadout.CreateSerializedState();
            await LegacyTestAccounts.InsertAsync(database, player, CancellationToken.None);
            _tokens.Add(player.Id, token);
            _ids.Add(player.Id);
            return player;
        }

        internal Task<BsonDocument> ReadAsync(string id) => Players.Find(new BsonDocument("_id", id)).SingleAsync();

        internal void Change(string id, UpdateDefinition<BsonDocument> update) =>
            Players.UpdateOne(new BsonDocument("_id", id), update);

        internal async Task<JsonObject> SendAsync(
            LegacyPlayerDocument player, int action, (string Key, string Value)[] fields)
        {
            IEnumerable<KeyValuePair<string, string>> values = fields.Select(field =>
                new KeyValuePair<string, string>(field.Key, field.Value)).Concat(new Dictionary<string, string>
            {
                ["requestId"] = action.ToString(CultureInfo.InvariantCulture),
                ["PlayerId"] = player.Id, ["Token"] = _tokens[player.Id]
            });
            using var content = new FormUrlEncodedContent(values);
            using HttpResponseMessage response = await _http.PostAsync("/index_09_25_2015.php", content);
            response.EnsureSuccessStatusCode();
            return JsonNode.Parse(await response.Content.ReadAsStringAsync())!.AsObject();
        }

        internal async Task RequireWrongBattleAsync(LegacyPlayerDocument player, (string Key, string Value)[] fields)
        {
            BsonDocument before = await ReadAsync(player.Id);
            JsonObject response = await SendAsync(player, 120, fields);
            Require(Code(response) == (int)DatabaseResult.GameDidntExist && Same(before, await ReadAsync(player.Id)),
                "Missing, ambiguous or unrelated battle ID reached tutorial completion.");
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
