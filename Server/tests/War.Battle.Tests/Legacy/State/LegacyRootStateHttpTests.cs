using System.Globalization;
using System.Text.Json.Nodes;
using MongoDB.Bson;
using MongoDB.Driver;
using War.Backend.Legacy;
using War.Backend.Legacy.Accounts;
using War.Battle.Tests.Support;
using War.Persistence;
using War.Persistence.Legacy.Buffers;

namespace War.Battle.Tests.Legacy.State;

/// <summary>
/// Tests malformed root BSON and economy snapshots through real authentication and transaction boundaries.
/// </summary>
internal static class LegacyRootStateHttpTests
{
    internal static async Task RunAsync(string uri, string databaseName, string baseUrl)
    {
        using var fixture = new Fixture(new MongoClient(uri).GetDatabase(databaseName), baseUrl);
        try
        {
            await CheckInvalidRootsAsync(fixture);
            await CheckCanonicalIdentitiesAsync(fixture);
            await CheckReadSetAsync(fixture);
            await CheckTransactionsAsync(fixture);
            await CheckCachedReceiptAsync(fixture);
            await CheckRegistrationAndLoginAsync(fixture);
            await CheckArmyPowerRequestsAsync(fixture);
            await CheckArmyPowerPublicationAsync(fixture);
            Console.WriteLine($"PASS: {fixture.Checks} root BSON/economy/authentication/transaction HTTP assertions");
        }
        finally
        {
            await fixture.CleanupAsync();
        }
    }

    private static async Task CheckInvalidRootsAsync(Fixture fixture)
    {
        Damage[] cases =
        [
            new("Gold", new BsonString("100")), new("Gold", new BsonDouble(100)),
            new("Gold", new BsonDouble(0.5)), new("Gold", new BsonDouble(double.NaN)),
            new("Gold", BsonNull.Value), new("Gold", null), new("Level", new BsonInt64((long)int.MaxValue + 1)),
            new("Gold", new BsonInt64(-1)), new("Tickets", new BsonInt64(-1)),
            new("Scraps", new BsonInt64(-1)), new("Level", 43), new("LevelExperience", -1),
            new("ArmyPower", int.MaxValue / 10 + 1), new("Skill", -1), new("MedalsBalance", -1),
            new("BeginnersLeague", 4), new("PlacementMatchesRequired", 10), new("LeagueId", "17-local1"),
            new("Status", new BsonDouble(1)), new("LastAction", new BsonString("0")),
            new("Status", null), new("LastAction", null), new("Status", 3), new("LastAction", -1)
        ];
        foreach (Damage damage in cases)
        {
            LegacyPlayerDocument player = await fixture.SeedAsync();
            await fixture.DamageAsync(player.Id, damage);
            BsonDocument before = await fixture.RawAsync(player.Id);
            foreach (int action in new[] { 34, 129, 167 })
            {
                JsonObject response = await fixture.SendAsync(player, action, []);
                fixture.Require(Code(response) == (int)DatabaseResult.ServerMaintenance,
                    "Malformed root reached a legacy success or nonlegacy error body: " + damage.Field);
            }

            await ExpectInvalidAsync(() => fixture.Store.AuthenticateToken(
                fixture.Token(player.Id), CancellationToken.None));
            BsonDocument after = await fixture.RawAsync(player.Id);
            fixture.Require(before.ToBson().AsSpan().SequenceEqual(after.ToBson()),
                "Refused root BSON changed: " + damage.Field + "/" + damage.Value?.BsonType);
        }
    }

    private static async Task CheckReadSetAsync(Fixture fixture)
    {
        LegacyPlayerDocument valid = await fixture.SeedAsync();
        LegacyPlayerDocument damaged = await fixture.SeedAsync();
        await fixture.DamageAsync(damaged.Id, new Damage("MedalsBalance", -1));
        await ExpectInvalidAsync(() => fixture.Store.ByIds([valid.Id, damaged.Id], CancellationToken.None));
        JsonObject response = await fixture.SendAsync(valid, (int)DatabaseAction.GetPlayerInfo,
            [("PlayerInfoId", damaged.Id)]);
        fixture.Require(Code(response) == (int)DatabaseResult.ServerMaintenance,
            "A selected corrupt peer was projected as valid player information.");
    }

    private static async Task CheckCanonicalIdentitiesAsync(Fixture fixture)
    {
        string canonical = "abcdef" + Guid.NewGuid().ToString("N")[6..];
        string[] aliases = [" " + canonical + " ", canonical.ToUpperInvariant(), canonical + "\n",
            Guid.ParseExact(canonical, "N").ToString("D")];
        LegacyPlayerDocument valid = await fixture.SeedAsync();
        foreach (string alias in aliases)
        {
            LegacyPlayerDocument damaged = await fixture.SeedAsync(alias);
            BsonDocument before = await fixture.RawAsync(alias);
            await ExpectInvalidAsync(() => fixture.Store.ById(alias, CancellationToken.None));
            await ExpectInvalidAsync(() => fixture.Store.ByIds([valid.Id, alias], CancellationToken.None));
            await ExpectInvalidAsync(() => fixture.Store.VerifyPassword(alias, "ignored", CancellationToken.None));
            await ExpectInvalidAsync(() => fixture.Store.AuthenticateToken(fixture.Token(alias), CancellationToken.None));
            int calculations = 0;
            await ExpectInvalidAsync(() => fixture.Buffers.ExecuteAsync(Request(alias, "invalid-identity"), current =>
            {
                calculations++;
                return NoOp(current);
            }, CancellationToken.None));
            foreach (int action in new[] { 34, 129, 167 })
            {
                JsonObject response = await fixture.SendAsync(damaged, action, []);
                fixture.Require(Code(response) == (int)DatabaseResult.ServerMaintenance,
                    "A noncanonical durable identity authorized HTTP projection or mutation.");
            }
            BsonDocument after = await fixture.RawAsync(alias);
            fixture.Require(calculations == 0 && before.ToBson().AsSpan().SequenceEqual(after.ToBson()) &&
                await fixture.ReceiptCountAsync(alias) == 0, "Rejected identity changed state or consumed a receipt.");
        }
    }

    private static async Task CheckTransactionsAsync(Fixture fixture)
    {
        LegacyPlayerDocument damaged = await fixture.SeedAsync();
        await fixture.DamageAsync(damaged.Id, new Damage("PlacementMatchesRequired", 10));
        int calculations = 0;
        await ExpectInvalidAsync(() => fixture.Buffers.ExecuteAsync(Request(damaged.Id, "invalid-root"), current =>
        {
            calculations++;
            return NoOp(current);
        }, CancellationToken.None));
        fixture.Require(calculations == 0 && await fixture.ReceiptCountAsync(damaged.Id) == 0,
            "Buffered calculation/receipt ran before root validation.");

        LegacyPlayerDocument player = await fixture.SeedAsync();
        await ExpectInvalidAsync(() => fixture.Buffers.ExecuteAsync(Request(player.Id, "invalid-successor"), current =>
            NoOp(current) with { ArmyPower = int.MaxValue / 10 + 1 }, CancellationToken.None));
        BsonDocument saved = await fixture.RawAsync(player.Id);
        fixture.Require(saved["Revision"].ToInt64() == 1 && await fixture.ReceiptCountAsync(player.Id) == 0,
            "An out-of-domain buffered successor published state or consumed its receipt.");
    }

    private static async Task CheckCachedReceiptAsync(Fixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        LegacyBufferedAction request = Request(player.Id, "recorded-before-damage");
        await fixture.Buffers.ExecuteAsync(request, NoOp, CancellationToken.None);
        await fixture.DamageAsync(player.Id, new Damage("Tickets", new BsonInt64(-1)));
        BsonDocument before = await fixture.RawAsync(player.Id);
        await ExpectInvalidAsync(() => fixture.Buffers.ExecuteAsync(request, _ =>
            throw new InvalidOperationException("A recorded receipt must not recalculate."),
            CancellationToken.None));
        fixture.Require(before.Equals(await fixture.RawAsync(player.Id)) &&
            await fixture.ReceiptCountAsync(player.Id) == 1,
            "Cached success bypassed root validation or changed the existing receipt.");
    }

    private static async Task CheckRegistrationAndLoginAsync(Fixture fixture)
    {
        JsonObject created = await fixture.SendPublicAsync(118, [("Locale", "en"), ("UtcOffset", "0")]);
        string id = created["Player"]!["Id"]!["S"]!.GetValue<string>();
        fixture.Track(id);
        BsonDocument before = await fixture.RawAsync(id);
        fixture.Require(Code(created) == 1 && before["PlacementMatchesRequired"].ToInt32() == 1 &&
            created["Player"]!["PlacementMatchesRequired"]!["N"]!.GetValue<string>() == "1",
            "New account retained the unevidenced ten-match placement default.");
        await fixture.DamageAsync(id, new Damage("Skill", -1));
        JsonObject login = await fixture.SendPublicAsync(30,
            [("Id", id), ("Password", created["Password"]!.GetValue<string>())]);
        BsonDocument after = await fixture.RawAsync(id);
        fixture.Require(Code(login) == (int)DatabaseResult.ServerMaintenance &&
            after["SessionHash"] == before["SessionHash"] && after["Revision"] == before["Revision"],
            "Login rotated credentials/session before rejecting corrupt root authority.");
    }

    private static async Task CheckArmyPowerRequestsAsync(Fixture fixture)
    {
        LegacyPlayerDocument player = await fixture.SeedAsync();
        string[] invalid = ["-1", "214748365", "2147483647", " 1", "1 ", "+1", "01", "1.0", "1e1", "null", ""];
        foreach (string value in invalid)
        {
            BsonDocument before = await fixture.RawAsync(player.Id);
            JsonObject response = await fixture.SendAsync(player, (int)DatabaseAction.UpdateArmyPower,
                [("ArmyPower", value)]);
            BsonDocument after = await fixture.RawAsync(player.Id);
            fixture.Require(Code(response) == (int)DatabaseResult.JsonFailure &&
                before.ToBson().AsSpan().SequenceEqual(after.ToBson()),
                "Malformed display assertion changed root authority: " + value);
        }

        foreach ((string Key, string Value)[] fields in new (string, string)[][]
        {
            [], [("ArmyPower", "1"), ("ArmyPower", "2")]
        })
        {
            BsonDocument before = await fixture.RawAsync(player.Id);
            JsonObject response = await fixture.SendAsync(player, (int)DatabaseAction.UpdateArmyPower, fields);
            BsonDocument after = await fixture.RawAsync(player.Id);
            fixture.Require(Code(response) == (int)DatabaseResult.JsonFailure &&
                before.ToBson().AsSpan().SequenceEqual(after.ToBson()),
                "Missing/repeated display assertion changed root authority.");
        }

        foreach (int value in new[] { 0, int.MaxValue / 10, 42 })
        {
            JsonObject response = await fixture.SendAsync(player, (int)DatabaseAction.UpdateArmyPower,
                [("ArmyPower", value.ToString(CultureInfo.InvariantCulture))]);
            fixture.Require(Code(response) == 1 && (await fixture.RawAsync(player.Id))["ArmyPower"].AsInt32 == value,
                "Canonical bounded display assertion failed publication.");
        }
    }

    private static async Task CheckArmyPowerPublicationAsync(Fixture fixture)
    {
        Damage[] conflicts =
        [
            new("Revision", new BsonInt64(2)),
            new("SessionHash", LegacyPlayerStore.HashToken(LegacyPlayerStore.NewToken())),
            new("SessionExpiresUtc", new BsonDateTime(DateTime.UtcNow.AddSeconds(-1)))
        ];
        foreach (Damage conflict in conflicts)
        {
            LegacyPlayerDocument player = await fixture.SeedAsync();
            await fixture.DamageAsync(player.Id, conflict);
            BsonDocument before = await fixture.RawAsync(player.Id);
            LegacyPlayerDocument? result = await fixture.Store.UpdateArmyPowerAsync(player, 42, CancellationToken.None);
            BsonDocument after = await fixture.RawAsync(player.Id);
            fixture.Require(result == null && before.ToBson().AsSpan().SequenceEqual(after.ToBson()),
                "Display assertion ignored changed revision/session/expiry: " + conflict.Field);
        }

        LegacyPlayerDocument valid = await fixture.SeedAsync();
        BsonDocument original = await fixture.RawAsync(valid.Id);
        await ExpectInvalidAsync(() => fixture.Store.UpdateArmyPowerAsync(
            valid, int.MaxValue / 10 + 1, CancellationToken.None));
        BsonDocument saved = await fixture.RawAsync(valid.Id);
        fixture.Require(original.ToBson().AsSpan().SequenceEqual(saved.ToBson()),
            "Reusable publication accepted an overflowing display successor.");
    }

    private static LegacyBufferedAction Request(string playerId, string bufferId) => new()
    {
        PlayerId = playerId,
        BufferId = bufferId,
        Index = 0,
        ActionId = (int)DatabaseAction.WeaponWasShown,
        PayloadDigest = new string('a', 64)
    };

    private static LegacyBufferedMutation NoOp(LegacyPlayerDocument player) => new()
    {
        Gold = player.Gold,
        WarBucks = player.WarBucks,
        Scraps = player.Scraps,
        ArmyPower = player.ArmyPower,
        Serialized = new Dictionary<string, string>(),
        Result = 1,
        ResponseJson = new JsonObject
        {
            ["ActionId"] = (int)DatabaseAction.WeaponWasShown,
            ["Result"] = 1
        }.ToJsonString()
    };

    private static int Code(JsonObject response) => response["Result"]!.GetValue<int>();

    private static async Task ExpectInvalidAsync(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (Exception exception) when (exception is InvalidDataException or FormatException)
        {
            return;
        }

        throw new InvalidOperationException("Corrupt root authority was accepted at a reusable boundary.");
    }

    private sealed record Damage(string Field, BsonValue? Value);

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
        internal LegacyPlayerStore Store { get; } = new(database);
        internal LegacyBufferStore Buffers { get; } = new(database);
        private IMongoCollection<BsonDocument> RawPlayers => database.GetCollection<BsonDocument>("legacyPlayers");

        internal async Task<LegacyPlayerDocument> SeedAsync(string? identity = null)
        {
            string token = LegacyPlayerStore.NewToken();
            var player = new LegacyPlayerDocument
            {
                Id = identity ?? Guid.NewGuid().ToString("N"),
                Name = "Root fixture",
                Gold = 100,
                WarBucks = 200,
                Tickets = 3,
                Scraps = 4,
                Level = 0,
                ArmyPower = 10,
                DogTagMax = 4500,
                DogTagLastUpdate = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                PlacementMatchesRequired = 1,
                CreatedUtc = DateTime.UtcNow.AddMinutes(-1),
                SessionHash = LegacyPlayerStore.HashToken(token),
                Serialized = LegacyInitialLoadout.CreateSerializedState()
            };
            await LegacyTestAccounts.InsertAsync(database, player, CancellationToken.None);
            _tokens.Add(player.Id, token);
            Track(player.Id);
            return player;
        }

        internal Task DamageAsync(string id, Damage damage)
        {
            UpdateDefinition<BsonDocument> update = damage.Value == null
                ? Builders<BsonDocument>.Update.Unset(damage.Field)
                : Builders<BsonDocument>.Update.Set(damage.Field, damage.Value);
            return RawPlayers.UpdateOneAsync(new BsonDocument("_id", id), update);
        }

        internal string Token(string id) => _tokens[id];
        internal void Track(string id) => _identities.Add(id);
        internal Task<BsonDocument> RawAsync(string id) => RawPlayers.Find(new BsonDocument("_id", id)).SingleAsync();
        internal Task<long> ReceiptCountAsync(string id) => database.GetCollection<BsonDocument>("legacyBufferReceipts")
            .CountDocumentsAsync(new BsonDocument("PlayerId", id));

        internal Task<JsonObject> SendAsync(
            LegacyPlayerDocument player, int action, (string Key, string Value)[] fields) =>
            SendPublicAsync(action, fields.Concat(new[] { ("Token", _tokens[player.Id]), ("PlayerId", player.Id) })
                .ToArray());

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

        internal async Task CleanupAsync()
        {
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.In("_id", _identities);
            await RawPlayers.DeleteManyAsync(filter);
            await database.GetCollection<BsonDocument>("legacyBufferReceipts").DeleteManyAsync(
                Builders<BsonDocument>.Filter.In("PlayerId", _identities));
        }

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
