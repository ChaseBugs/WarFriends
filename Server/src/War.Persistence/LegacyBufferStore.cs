using System.Text.RegularExpressions;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using War.Persistence.Legacy.Buffers;

namespace War.Persistence;

/// <summary>One request's outcome inside a buffer, keyed by its position in that buffer.</summary>
public sealed class LegacyBufferEntry
{
    /// <summary>The request's integer key in the client's <c>Dictionary&lt;int, Request&gt;</c>.</summary>
    public int Index { get; set; }

    /// <summary>The <c>DatabaseAction</c> integer, echoed back to the client as <c>ActionId</c>.</summary>
    public int ActionId { get; set; }

    /// <summary>
    /// The committed <c>DatabaseResult</c> integer. A null is an old, incomplete claim whose outcome
    /// is unknown and must never authorize reapplication.
    /// </summary>
    public int? Result { get; set; }

    public string? PayloadDigest { get; set; }

    public string? ResponseJson { get; set; }

    public LegacyBufferedDelivery? Delivery { get; set; }
}

/// <summary>
/// Receipts for buffered request replay.
/// </summary>
/// <remarks>
/// <para>The client resends buffers: <c>RequestBufferManager.GetJsonData()</c> attaches every
/// unsent buffer to the next <c>GetPlayerData</c>, and a buffer is only removed locally once a
/// response arrives. A dropped response therefore replays the whole buffer, so every buffered
/// effect must apply at most once. Idempotency is keyed by player + buffer id + request index,
/// exactly as <c>Server/AGENTS.md</c> requires.</para>
/// <para>Player mutation and the complete response commit in one replica-set transaction. Historical
/// entries lacking payload/response evidence remain closed to replay; they cannot safely be upgraded
/// by guessing whether their separately written effect landed.</para>
/// </remarks>
public sealed class LegacyBufferReceipt
{
    /// <summary>Composite key: <c>&lt;playerId&gt;:&lt;bufferId&gt;</c>.</summary>
    [BsonId] public string Id { get; set; } = "";
    public string PlayerId { get; set; } = "";
    public string BufferId { get; set; } = "";
    public List<LegacyBufferEntry> Entries { get; set; } = [];
    public DateTime CreatedUtc { get; set; }
}

public sealed partial class LegacyBufferStore
{
    private readonly IMongoCollection<LegacyBufferReceipt> receipts;
    private readonly IMongoDatabase _database;

    public LegacyBufferStore(IMongoDatabase database)
    {
        _database = database;
        receipts = database.GetCollection<LegacyBufferReceipt>("legacyBufferReceipts");
    }

    public LegacyBufferStore(string uri, string databaseName)
    {
        if (!Regex.IsMatch(databaseName, @"\A[A-Za-z0-9_]{1,64}\z")) throw new ArgumentException("Invalid Mongo database name.");
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
        _database = new MongoClient(settings).GetDatabase(databaseName);
        receipts = _database.GetCollection<LegacyBufferReceipt>("legacyBufferReceipts");
    }

    public async Task Initialize(CancellationToken ct)
    {
        await receipts.Indexes.CreateOneAsync(new CreateIndexModel<LegacyBufferReceipt>(
            Builders<LegacyBufferReceipt>.IndexKeys.Ascending(x => x.PlayerId)), cancellationToken: ct);
        // The Client persists unsent buffers indefinitely. Expiry would reopen a paid request.
        using var cursor = await receipts.Indexes.ListAsync(ct);
        var indexes = await cursor.ToListAsync(ct);
        foreach (var index in indexes)
        {
            if (index.Contains("expireAfterSeconds"))
            {
                await receipts.Indexes.DropOneAsync(index["name"].AsString, ct);
            }
        }
    }

    private static string Key(string playerId, string bufferId) => $"{playerId}:{bufferId}";

    public Task<LegacyBufferReceipt?> Find(string playerId, string bufferId, CancellationToken ct) =>
        receipts.Find(x => x.Id == Key(playerId, bufferId)).FirstOrDefaultAsync(ct)!;
}
