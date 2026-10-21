using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using War.Battle.Tests.Support;
using War.Persistence;

namespace War.Battle.Tests.Legacy.Profile;

/// <summary>Shares one owned smoke replica, with observed writes and a separate trusted conflict client.</summary>
internal sealed class LegacyProfileStoreFixture : IAsyncDisposable
{
    private readonly MongoClient _trusted;
    private readonly string _databaseName = "war_profile_" + Guid.NewGuid().ToString("N");
    private readonly CancellationTokenSource _deadline = new(TimeSpan.FromSeconds(120));

    internal LegacyProfileStoreFixture(string uri)
    {
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ClusterConfigurator = cluster => cluster.Subscribe<CommandStartedEvent>(command =>
        {
            if (command.CommandName == "findAndModify")
            {
                BeforeWrite?.Invoke();
            }
        });
        Database = new MongoClient(settings).GetDatabase(_databaseName);
        _trusted = new MongoClient(uri);
        Store = new LegacyPlayerStore(Database);
    }

    internal IMongoDatabase Database { get; }

    internal LegacyPlayerStore Store { get; }

    internal DateTimeOffset Time { get; } = DateTimeOffset.UtcNow;

    internal CancellationToken Token => _deadline.Token;

    internal Action? BeforeWrite { get; set; }

    internal IMongoCollection<BsonDocument> Raw =>
        _trusted.GetDatabase(_databaseName).GetCollection<BsonDocument>("legacyPlayers");

    internal async Task<LegacyPlayerDocument> SeedAsync(int renameCount = 0, long gold = 100)
    {
        var player = new LegacyPlayerDocument
        {
            Id = Guid.NewGuid().ToString("N"), Name = "Recruit", Locale = "en", Country = "US",
            Gold = gold, RenameCount = renameCount, CreatedUtc = Time.UtcDateTime.AddMinutes(-1),
            LastAction = (int)Time.ToUnixTimeSeconds() - 1,
            Serialized = new() { ["PlayerAnalyticsData"] = "{\"future\":9223372036854775807}" }
        };
        await LegacyTestAccounts.InsertAsync(Database, player, Token);
        return player;
    }

    internal Task<BsonDocument> ReadAsync(string id) => Raw.Find(new BsonDocument("_id", id)).SingleAsync(Token);

    internal void Change(string id, UpdateDefinition<BsonDocument> update) =>
        Raw.UpdateOne(new BsonDocument("_id", id), update, cancellationToken: Token);

    public async ValueTask DisposeAsync()
    {
        BeforeWrite = null;
        await _trusted.DropDatabaseAsync(_databaseName, CancellationToken.None);
        _deadline.Dispose();
    }
}
