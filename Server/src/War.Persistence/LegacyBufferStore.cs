using System.Text.RegularExpressions;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace War.Persistence;

/// <summary>One request's outcome inside a buffer, keyed by its position in that buffer.</summary>
public sealed class LegacyBufferEntry
{
    /// <summary>The request's integer key in the client's <c>Dictionary&lt;int, Request&gt;</c>.</summary>
    public int Index { get; set; }

    /// <summary>The <c>DatabaseAction</c> integer, echoed back to the client as <c>ActionId</c>.</summary>
    public int ActionId { get; set; }

    /// <summary>
    /// The <c>DatabaseResult</c> integer, or null while the request is claimed but not yet applied.
    /// A null that survives a restart means the outcome is unknown — see <see cref="LegacyBufferStore"/>.
    /// </summary>
    public int? Result { get; set; }
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
/// <para><b>Claim before apply.</b> Each request is first claimed by pushing an entry with a null
/// <see cref="LegacyBufferEntry.Result"/>, and the result is set after the effect lands. The claim
/// is conditional on the index being absent, so two concurrent replays cannot both execute the
/// same request. If a process dies between claim and set, the entry stays null and replay reports
/// the outcome as unknown rather than re-applying it: for an economy, failing to grant twice
/// matters more than failing to grant once.</para>
/// <para>Receipts and player state live in different collections, and this deployment targets a
/// standalone Mongo, so the pair is not written in one transaction. The claim ordering is what
/// bounds the damage. Genuine atomicity needs a replica set, which <c>README.md</c> already lists
/// as a prerequisite for economy settlement.</para>
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

public sealed class LegacyBufferStore
{
    /// <summary>
    /// How long a receipt is retained. It must comfortably outlive any window in which a client
    /// could still be replaying a buffer; the client retains unsent buffers across restarts, so
    /// this is deliberately far longer than a session.
    /// </summary>
    public static readonly TimeSpan RetentionPeriod = TimeSpan.FromDays(30);

    private readonly IMongoCollection<LegacyBufferReceipt> receipts;

    public LegacyBufferStore(IMongoDatabase database) => receipts = database.GetCollection<LegacyBufferReceipt>("legacyBufferReceipts");

    public LegacyBufferStore(string uri, string databaseName)
    {
        if (!Regex.IsMatch(databaseName, @"\A[A-Za-z0-9_]{1,64}\z")) throw new ArgumentException("Invalid Mongo database name.");
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
        receipts = new MongoClient(settings).GetDatabase(databaseName).GetCollection<LegacyBufferReceipt>("legacyBufferReceipts");
    }

    public Task Initialize(CancellationToken ct) => receipts.Indexes.CreateManyAsync([
        new CreateIndexModel<LegacyBufferReceipt>(Builders<LegacyBufferReceipt>.IndexKeys.Ascending(x => x.PlayerId)),
        new CreateIndexModel<LegacyBufferReceipt>(Builders<LegacyBufferReceipt>.IndexKeys.Ascending(x => x.CreatedUtc),
            new CreateIndexOptions { ExpireAfter = RetentionPeriod })
    ], ct);

    private static string Key(string playerId, string bufferId) => $"{playerId}:{bufferId}";

    public Task<LegacyBufferReceipt?> Find(string playerId, string bufferId, CancellationToken ct) =>
        receipts.Find(x => x.Id == Key(playerId, bufferId)).FirstOrDefaultAsync(ct)!;

    /// <summary>
    /// Claims one request for execution. Returns true when this caller now owns it; false when the
    /// index was already claimed, in which case the caller must reuse the recorded outcome.
    /// </summary>
    public async Task<bool> TryClaim(string playerId, string bufferId, int index, int actionId, CancellationToken ct)
    {
        string key = Key(playerId, bufferId);
        // Upsert the receipt first so the conditional push below has a document to match.
        await receipts.UpdateOneAsync(x => x.Id == key,
            Builders<LegacyBufferReceipt>.Update
                .SetOnInsert(x => x.PlayerId, playerId)
                .SetOnInsert(x => x.BufferId, bufferId)
                .SetOnInsert(x => x.CreatedUtc, DateTime.UtcNow),
            new UpdateOptions { IsUpsert = true }, ct);

        var filter = Builders<LegacyBufferReceipt>.Filter.And(
            Builders<LegacyBufferReceipt>.Filter.Eq(x => x.Id, key),
            Builders<LegacyBufferReceipt>.Filter.Not(
                Builders<LegacyBufferReceipt>.Filter.ElemMatch(x => x.Entries, e => e.Index == index)));
        var result = await receipts.UpdateOneAsync(filter,
            Builders<LegacyBufferReceipt>.Update.Push(x => x.Entries, new LegacyBufferEntry { Index = index, ActionId = actionId, Result = null }),
            cancellationToken: ct);
        return result.ModifiedCount == 1;
    }

    /// <summary>Records the outcome of a request this caller claimed.</summary>
    public Task Complete(string playerId, string bufferId, int index, int result, CancellationToken ct)
    {
        string key = Key(playerId, bufferId);
        var filter = Builders<LegacyBufferReceipt>.Filter.And(
            Builders<LegacyBufferReceipt>.Filter.Eq(x => x.Id, key),
            Builders<LegacyBufferReceipt>.Filter.ElemMatch(x => x.Entries, e => e.Index == index));
        return receipts.UpdateOneAsync(filter,
            Builders<LegacyBufferReceipt>.Update.Set("Entries.$.Result", result), cancellationToken: ct);
    }
}
