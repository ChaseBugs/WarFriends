using System.Globalization;
using System.Text.Json.Nodes;
using MongoDB.Bson;
using MongoDB.Driver;
using War.Backend.Legacy;
using War.Backend.Legacy.Accounts;
using War.Battle.Tests.Support;
using War.Persistence;

namespace War.Battle.Tests.Legacy.Profile;

/// <summary>
/// Exercises canonical profile requests, mandatory callbacks and rejected-form conservation over HTTP.
/// </summary>
internal static class LegacyProfileHttpTests
{
    internal static async Task RunAsync(string uri, string databaseName, string baseUrl)
    {
        await using var fixture = new Fixture(new MongoClient(uri).GetDatabase(databaseName), baseUrl);
        await fixture.SeedAsync();
        await CheckStatusAsync(fixture);
        await CheckDeviceAsync(fixture);
        await CheckCountryAndLanguageAsync(fixture);
        await CheckRenameAsync(fixture);
        Console.WriteLine($"PASS: {fixture.Checks} profile HTTP canonical/alias/tuple/price/callback assertions");
    }

    private static async Task CheckStatusAsync(Fixture fixture)
    {
        JsonObject success = await fixture.SendAsync(29, [("PlayerStatus", "1"), ("Status", "1")]);
        BsonDocument saved = await fixture.ReadAsync();
        fixture.Require(Code(success) == 1 && success["Time"]!.GetValue<int>() > 0 && saved["Status"].AsInt32 == 1,
            "Canonical heartbeat lost mandatory Time or durable status.");
        (string Key, string Value)[][] invalid =
        [
            [], [("Status", "2")], [("PlayerStatus", "2"), ("Status", "1")],
            [("PlayerStatus", "1"), ("PlayerStatus", "1")], [("PlayerStatus", "01")],
            [("PlayerStatus", "2"), ("Status", "2"), ("Status", "2")]
        ];
        foreach ((string Key, string Value)[] fields in invalid)
        {
            BsonDocument before = await fixture.ReadAsync();
            JsonObject response = await fixture.SendAsync(29, fields);
            BsonDocument after = await fixture.ReadAsync();
            fixture.Require(Code(response) == 1 && response["Time"]!.GetValue<int>() > 0 && Same(before, after),
                "Ambiguous/alias-only heartbeat refreshed durable presence or broke its callback.");
        }
    }

    private static async Task CheckDeviceAsync(Fixture fixture)
    {
        JsonObject success = await fixture.SendAsync(13, [("DeviceToken", " padded token "), ("Locale", "ko-KR")]);
        BsonDocument saved = await fixture.ReadAsync();
        fixture.Require(Code(success) == 1 && saved["DeviceToken"] == " padded token " && saved["Locale"] == "ko-KR",
            "Device registration normalized an opaque token or split its locale tuple.");
        (string Key, string Value)[][] invalid =
        [
            [("DeviceToken", "token")], [("Locale", "en")], [("DeviceToken", ""), ("Locale", "en")],
            [("DeviceToken", "token"), ("Locale", "???")], [("DeviceToken", "bad\n"), ("Locale", "en")],
            [("DeviceToken", "token"), ("DeviceToken", "token"), ("Locale", "en")],
            [("DeviceToken", "token"), ("Locale", "en"), ("Locale", "en")]
        ];
        foreach ((string Key, string Value)[] fields in invalid)
        {
            await fixture.RequireRefusalAsync(13, fields);
        }
    }

    private static async Task CheckCountryAndLanguageAsync(Fixture fixture)
    {
        JsonObject country = await fixture.SendAsync(196, [("NewCountryCode", "gb"), ("CountryCode", "gb")]);
        fixture.Require(Code(country) == 1 && (await fixture.ReadAsync())["Country"] == "GB",
            "Canonical country was not persisted with existing uppercase behavior.");
        (string Key, string Value)[][] invalid =
        [
            [("CountryCode", "US")], [("NewCountryCode", "gb"), ("CountryCode", "US")],
            [("NewCountryCode", "gb"), ("Country", "US")], [("NewCountryCode", "GBR")],
            [("NewCountryCode", "gb"), ("NewCountryCode", "gb")]
        ];
        foreach ((string Key, string Value)[] fields in invalid)
        {
            await fixture.RequireRefusalAsync(196, fields);
        }

        JsonObject language = await fixture.SendAsync(150, [("Locale", "fr")]);
        fixture.Require(Code(language) == 1 && (await fixture.ReadAsync())["Locale"] == "fr",
            "Canonical language update failed.");
        await fixture.RequireRefusalAsync(150, [("Locale", "fr"), ("Locale", "fr")]);
        await fixture.RequireRefusalAsync(150, [("Locale", " fr")]);
    }

    private static async Task CheckRenameAsync(Fixture fixture)
    {
        foreach (string consent in new[] { "", "01", " 1", "+1", "true", "1.0", "1e0" })
        {
            await fixture.RequireRefusalAsync(139, [("Name", "After"), ("PayForRename", consent)]);
        }

        await fixture.RequireRefusalAsync(139, [("Name", "After")]);
        await fixture.RequireRefusalAsync(139,
            [("Name", "After"), ("Name", "After"), ("PayForRename", "0")]);
        await fixture.RequireRefusalAsync(139,
            [("Name", "After"), ("PlayerName", "Other"), ("PayForRename", "0")]);
        JsonObject first = await fixture.SendAsync(139,
            [("Name", " Exact name "), ("PlayerName", " Exact name "), ("PayForRename", "0")]);
        fixture.Require(Code(first) == 1 && first["Name"]!.GetValue<string>() == " Exact name " &&
            first["RenameCount"]!.GetValue<int>() == 1 && first["PayForRename"]!.GetValue<int>() == 0,
            "Free rename lost one of the unchanged callback's three mandatory fields.");
        JsonObject paid = await fixture.SendAsync(139,
            [("Name", "Paid"), ("PayForRename", "1"), ("Price", "0")]);
        BsonDocument saved = await fixture.ReadAsync();
        fixture.Require(Code(paid) == 1 && paid["Name"]!.GetValue<string>() == "Paid" &&
            paid["RenameCount"]!.GetValue<int>() == 2 && paid["PayForRename"]!.GetValue<int>() == 1 &&
            saved["Gold"].AsInt64 == 0 && saved["RenameCount"].AsInt32 == 2 &&
            saved["Serialized"].AsBsonDocument.Equals(fixture.Serialized),
            "Paid rename trusted client price, lost metadata or returned an uncommitted result.");
        JsonObject refused = await fixture.SendAsync(139, [("Name", "Denied"), ("PayForRename", "1")]);
        BsonDocument after = await fixture.ReadAsync();
        fixture.Require(Code(refused) == (int)DatabaseResult.NotEnoughGoldForChangeName &&
            refused["RenameCount"]!.GetValue<int>() == 2 && refused["PlayerGold"]!.GetValue<long>() == 0 &&
            Same(saved, after),
            "Insufficient rename lacked mandatory rollback fields or consumed state.");
    }

    private static int Code(JsonObject response) => response["Result"]!.GetValue<int>();

    private static bool Same(BsonDocument before, BsonDocument after) =>
        before.ToBson().AsSpan().SequenceEqual(after.ToBson());

    private sealed class Fixture(IMongoDatabase database, string baseUrl) : IAsyncDisposable
    {
        private const int RequestTimeoutSeconds = 15;
        private readonly HttpClient _http = new()
        {
            BaseAddress = new Uri(baseUrl), Timeout = TimeSpan.FromSeconds(RequestTimeoutSeconds)
        };
        private readonly string _token = LegacyPlayerStore.NewToken();
        private readonly string _id = Guid.NewGuid().ToString("N");

        internal int Checks { get; private set; }

        internal BsonDocument Serialized { get; private set; } = new();

        private IMongoCollection<BsonDocument> Players => database.GetCollection<BsonDocument>("legacyPlayers");

        internal async Task SeedAsync()
        {
            var player = new LegacyPlayerDocument
            {
                Id = _id, Name = "Recruit", Gold = 25, Country = "US",
                SessionHash = LegacyPlayerStore.HashToken(_token), CreatedUtc = DateTime.UtcNow.AddMinutes(-1),
                LastAction = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds() - 1,
                Serialized = LegacyInitialLoadout.CreateSerializedState()
            };
            await LegacyTestAccounts.InsertAsync(database, player, CancellationToken.None);
            Serialized = (await ReadAsync())["Serialized"].AsBsonDocument.DeepClone().AsBsonDocument;
        }

        internal Task<BsonDocument> ReadAsync() => Players.Find(new BsonDocument("_id", _id)).SingleAsync();

        internal async Task<JsonObject> SendAsync(int action, (string Key, string Value)[] fields)
        {
            IEnumerable<KeyValuePair<string, string>> values = fields.Select(field =>
                new KeyValuePair<string, string>(field.Key, field.Value)).Concat(new Dictionary<string, string>
            {
                ["requestId"] = action.ToString(CultureInfo.InvariantCulture), ["Token"] = _token, ["PlayerId"] = _id
            });
            using var content = new FormUrlEncodedContent(values);
            using HttpResponseMessage response = await _http.PostAsync("/index_09_25_2015.php", content);
            response.EnsureSuccessStatusCode();
            return JsonNode.Parse(await response.Content.ReadAsStringAsync())!.AsObject();
        }

        internal async Task RequireRefusalAsync(int action, (string Key, string Value)[] fields)
        {
            BsonDocument before = await ReadAsync();
            JsonObject response = await SendAsync(action, fields);
            BsonDocument after = await ReadAsync();
            Require(Code(response) == (int)DatabaseResult.WrongPlayerData && Same(before, after),
                "Malformed profile form mutated authority: " + action);
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
            await Players.DeleteOneAsync(new BsonDocument("_id", _id));
            _http.Dispose();
        }
    }
}
