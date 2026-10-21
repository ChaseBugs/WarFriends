using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using War.Battle.Tests.Support;
using War.Persistence;
using War.Persistence.Legacy.Tutorial;

namespace War.Battle.Tests.Legacy.Tutorial;

/// <summary>Forces tutorial writes against a separate trusted client in the existing owned smoke replica.</summary>
internal sealed class LegacyTutorialStoreFixture : IAsyncDisposable
{
    private readonly MongoClient _trusted;
    private readonly string _name = "war_tutorial_" + Guid.NewGuid().ToString("N");
    private readonly CancellationTokenSource _deadline = new(TimeSpan.FromSeconds(120));

    internal LegacyTutorialStoreFixture(string uri)
    {
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ClusterConfigurator = cluster => cluster.Subscribe<CommandStartedEvent>(command =>
        {
            if (command.CommandName == "findAndModify")
            {
                BeforeWrite?.Invoke();
            }
        });
        _trusted = new MongoClient(uri);
        Database = _trusted.GetDatabase(_name);
        Store = new LegacyPlayerStore(new MongoClient(settings).GetDatabase(_name));
    }

    internal IMongoDatabase Database { get; }

    internal LegacyPlayerStore Store { get; }

    internal DateTimeOffset Time { get; } = DateTimeOffset.UtcNow;

    internal CancellationToken Token => _deadline.Token;

    internal Action? BeforeWrite { get; set; }

    internal IMongoCollection<BsonDocument> Raw => Database.GetCollection<BsonDocument>("legacyPlayers");

    internal async Task<LegacyPlayerDocument> SeedAsync(LegacyPlayerDocument? player = null)
    {
        player ??= new LegacyPlayerDocument();
        player.Id = Guid.NewGuid().ToString("N");
        player.Name = "Recruit";
        player.Gold = 100;
        player.CreatedUtc = Time.UtcDateTime.AddMinutes(-1);
        player.Serialized = new() { ["PlayerAnalyticsData"] = "{\"future\":9223372036854775807}" };
        await LegacyTestAccounts.InsertAsync(Database, player, Token);
        return player;
    }

    internal Task<LegacyTutorialResult> ApplyAsync(LegacyPlayerDocument player, LegacyTutorialOperation operation) =>
        Store.ApplyTutorialAsync(player, operation, Time, Token);

    internal Task<BsonDocument> ReadAsync(string id) => Raw.Find(new BsonDocument("_id", id)).SingleAsync(Token);

    internal void Change(string id, UpdateDefinition<BsonDocument> update) =>
        Raw.UpdateOne(new BsonDocument("_id", id), update, cancellationToken: Token);

    public async ValueTask DisposeAsync()
    {
        BeforeWrite = null;
        await _trusted.DropDatabaseAsync(_name, CancellationToken.None);
        _deadline.Dispose();
    }
}
