using System.Globalization;
using System.Text.Json.Nodes;
using MongoDB.Driver;
using War.Backend.Legacy;
using War.Battle.Tests.Support;
using War.Persistence;

namespace War.Battle.Tests.Legacy.DogTags;

/// <summary>Checks live callback fields, VIP pricing, debt, boot clocks and damaged-state refusal.</summary>
internal static class LegacyDogTagHttpTests
{
    internal static async Task RunAsync(string uri, string databaseName, string baseUrl)
    {
        using var fixture = new Fixture(new MongoClient(uri).GetDatabase(databaseName), baseUrl);
        try
        {
            await CheckVipAsync(fixture);
            await CheckDebtAndBootAsync(fixture);
            await CheckDamageAsync(fixture);
            Console.WriteLine($"PASS: {fixture.Checks} dog-tag HTTP VIP/debt/clock/corruption assertions");
        }
        finally
        {
            await fixture.CleanupAsync();
        }
    }

    private static async Task CheckVipAsync(Fixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync((int)DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 3600);
        JsonObject refill = await fixture.SendAsync(player, 70);
        fixture.Require(Code(refill) == 1 && refill["Gold"]!.GetValue<long>() == 69,
            "VIP refill must use two bonus tags: 35 - 2*2 = 31 Gold.");
        LegacyPlayerDocument saved = await fixture.ReadAsync(player.Id);
        fixture.Require(saved.Gold == 69 && saved.DogTagSeconds == 4500,
            "Refill must publish wallet and base pool together without storing VIP bonus twice.");
        JsonObject full = await fixture.SendAsync(player, 70);
        fixture.Require(Code(full) == 1 && full["Gold"]!.GetValue<long>() == 69,
            "A full VIP refill must be a no-charge success with its mandatory Gold field.");
        JsonObject penalty = await fixture.SendAsync(player, 129);
        saved = await fixture.ReadAsync(player.Id);
        fixture.Require(Code(penalty) == 1 && penalty["Seconds"]!.GetValue<int>() == 3600 &&
            penalty["LastUpdate"]!.GetValue<int>() == saved.DogTagLastUpdate && saved.Gold == 69,
            "Penalty callback must receive the committed base tuple and must not spend Gold.");
    }

    private static async Task CheckDebtAndBootAsync(Fixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        JsonObject penalty = await fixture.SendAsync(player, 129);
        LegacyPlayerDocument saved = await fixture.ReadAsync(player.Id);
        fixture.Require(Code(penalty) == 1 && saved.DogTagSeconds < 0 &&
            saved.DogTagSeconds == penalty["Seconds"]!.GetValue<int>(),
            "An empty pool must retain source penalty debt in both durable state and callback.");
        JsonObject boot = await fixture.SendAsync(player, 34);
        int now = boot["Time"]!.GetValue<int>();
        JsonObject data = boot["PlayerData"]!.AsObject();
        fixture.Require(ReadNumber(data, "DogTagLastUpdate") == now && ReadNumber(data, "DogTagSeconds") ==
            Math.Min((long)saved.DogTagSeconds + now - saved.DogTagLastUpdate, saved.DogTagMax),
            "Boot must rebase debt with exactly its response Time rather than recapturing a nested clock.");
        fixture.Require(ReadNumber(data, "Midnight") == ((long)now / 86400 + 1) * 86400,
            "Boot midnight must derive from the same captured UTC second.");
        JsonObject expiry = await fixture.SendAsync(player, 195);
        fixture.Require(Code(expiry) == 1 && expiry["DogTagSeconds"] != null && expiry["DogTagLastUpdate"] != null,
            "VIP expiry must supply the exact guarded resynchronization pair.");
        LegacyPlayerDocument after = await fixture.ReadAsync(player.Id);
        fixture.Require(after.Revision == saved.Revision && after.DogTagSeconds == saved.DogTagSeconds,
            "Read-only boot and expiry projection must not erase debt or publish new authority.");
    }

    private static async Task CheckDamageAsync(Fixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        await fixture.Players.UpdateOneAsync(row => row.Id == player.Id,
            Builders<LegacyPlayerDocument>.Update.Set(row => row.DogTagLastUpdate, int.MaxValue));
        foreach (int action in new[] { 70, 129, 195, 34 })
        {
            JsonObject response = await fixture.SendAsync(player, action);
            fixture.Require(Code(response) == (int)DatabaseResult.ServerMaintenance,
                "Future dog-tag authority must fail closed without callback success.");
        }

        LegacyPlayerDocument saved = await fixture.ReadAsync(player.Id);
        fixture.Require(saved.Gold == 100 && saved.DogTagLastUpdate == int.MaxValue && saved.Revision == 1,
            "Corrupt-state refusal must not rewrite the damaged tuple or consume the wallet.");
    }

    private static long ReadNumber(JsonObject data, string name) =>
        long.Parse(data[name]!["N"]!.GetValue<string>(), CultureInfo.InvariantCulture);

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

        internal int Checks { get; private set; }
        internal IMongoCollection<LegacyPlayerDocument> Players { get; } =
            database.GetCollection<LegacyPlayerDocument>("legacyPlayers");

        internal async Task<LegacyPlayerDocument> SeedAsync(int vipExpiry = 0)
        {
            string token = LegacyPlayerStore.NewToken();
            int now = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var player = new LegacyPlayerDocument
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = "DogTag fixture",
                Gold = 100,
                DogTagMax = 4500,
                DogTagLastUpdate = now,
                Vip = vipExpiry,
                SessionHash = LegacyPlayerStore.HashToken(token),
                CreatedUtc = DateTime.UtcNow.AddMinutes(-1)
            };
            await LegacyTestAccounts.InsertAsync(database, player, CancellationToken.None);
            _tokens.Add(player.Id, token);
            return player;
        }

        internal async Task<JsonObject> SendAsync(LegacyPlayerDocument player, int action)
        {
            using var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["requestId"] = action.ToString(CultureInfo.InvariantCulture),
                ["PlayerId"] = player.Id,
                ["Token"] = _tokens[player.Id],
                ["DogTagRefillTime"] = "900",
                ["DogTagCap"] = "5"
            });
            using HttpResponseMessage response = await _http.PostAsync("/index_09_25_2015.php", content);
            response.EnsureSuccessStatusCode();
            return JsonNode.Parse(await response.Content.ReadAsStringAsync())!.AsObject();
        }

        internal Task<LegacyPlayerDocument> ReadAsync(string id) => Players.Find(row => row.Id == id).SingleAsync();

        internal Task CleanupAsync() => Players.DeleteManyAsync(
            Builders<LegacyPlayerDocument>.Filter.In(row => row.Id, _tokens.Keys));

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
