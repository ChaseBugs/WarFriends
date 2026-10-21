using Microsoft.Extensions.Logging.Abstractions;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using War.Backend.Legacy;
using War.Backend.Legacy.Buffering;
using War.Battle.Tests.Support;
using War.Persistence;
using War.Persistence.Legacy.Buffers;

namespace War.Battle.Tests.Legacy.Analytics;

/// <summary>Observes acknowledgement writes while a separate client publishes real buffered conflicts.</summary>
internal sealed class LegacyAnalyticsStoreFixture : IAsyncDisposable
{
    private readonly MongoClient _trusted;
    private readonly string _name = "war_analytics_" + Guid.NewGuid().ToString("N");
    private readonly CancellationTokenSource _deadline = new(TimeSpan.FromSeconds(120));

    internal LegacyAnalyticsStoreFixture(string uri)
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
        Buffers = new LegacyBufferStore(Database);
    }

    internal IMongoDatabase Database { get; }

    internal LegacyPlayerStore Store { get; }

    internal LegacyBufferStore Buffers { get; }

    internal DateTimeOffset Time { get; } = DateTimeOffset.UtcNow;

    internal CancellationToken Token => _deadline.Token;

    internal Action? BeforeWrite { get; set; }

    internal IMongoCollection<BsonDocument> Raw => Database.GetCollection<BsonDocument>("legacyPlayers");

    internal async Task<LegacyPlayerDocument> SeedAsync(Dictionary<string, string>? states = null)
    {
        var player = new LegacyPlayerDocument
        {
            Id = Guid.NewGuid().ToString("N"), Name = "Recruit", Gold = 100,
            CreatedUtc = Time.UtcDateTime.AddMinutes(-1), Serialized = states ?? new()
        };
        await LegacyTestAccounts.InsertAsync(Database, player, Token);
        return player;
    }

    internal Task<BsonDocument> ReadAsync(string id) => Raw.Find(new BsonDocument("_id", id)).SingleAsync(Token);

    internal Task<long> ReceiptCountAsync(string id) => Database.GetCollection<BsonDocument>("legacyBufferReceipts")
        .CountDocumentsAsync(new BsonDocument("PlayerId", id), cancellationToken: Token);

    internal LegacyBufferedAction Request(string id) => new()
    {
        PlayerId = id, BufferId = "analytics-" + Guid.NewGuid().ToString("N"), Index = 0,
        ActionId = (int)DatabaseAction.SaveLastSeenSquadChatTimeStamp, PayloadDigest = new string('a', 64)
    };

    internal LegacyBufferedMutation Plan(LegacyPlayerDocument player)
    {
        var planner = new LegacyBufferPlanner(LegacyCatalog.Empty, LegacyBufferProcessor.SupportedActions,
            NullLogger.Instance);
        return planner.Plan(player, new BufferedRequest(0, DatabaseAction.SaveLastSeenSquadChatTimeStamp, "123"),
            Time.ToUnixTimeSeconds(), 7);
    }

    public async ValueTask DisposeAsync()
    {
        BeforeWrite = null;
        await _trusted.DropDatabaseAsync(_name, CancellationToken.None);
        _deadline.Dispose();
    }
}
