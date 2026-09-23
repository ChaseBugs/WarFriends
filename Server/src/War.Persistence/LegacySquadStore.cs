using System.Text.RegularExpressions;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace War.Persistence;

/// <summary>One squad member. Mirrors what <c>DatabasePlayer.CreateFromDatabase</c> needs to know
/// about a player's squad standing, kept separately from <see cref="LegacyPlayerDocument"/> so a
/// squad's roster is a single, atomically-updatable list.</summary>
public sealed class LegacySquadMember
{
    public string PlayerId { get; set; } = "";

    /// <summary><c>SquadRank</c>: 0=Member, 1=Veteran, 2=Leader, 3=Coleader.</summary>
    public int Rank { get; set; }
}

/// <summary>
/// A squad. Field names follow <c>DatabaseSquad</c>/<c>CreateSquad</c>'s request builder, not a
/// guess: the client sends the squad's display name as <c>SquadId</c> itself (there is no separate
/// generated id), so the name doubles as this document's <see cref="Id"/> and Mongo's own unique
/// <c>_id</c> constraint is exactly the uniqueness <c>CheckUniqueSquadName</c> needs to answer.
/// </summary>
/// <remarks>
/// Battle-derived squad statistics (<c>DatabaseSquad.experience</c>/<c>kills</c>/<c>battlesWon</c>/
/// <c>squadPoints</c>/Squad Wars division and round data) are deliberately not modeled here: they
/// are meaningless without Battle Server result trust, the same reason Ranked PvP/Player Leagues
/// and War Arena are out of scope for this pass. A squad this store creates is a real, joinable
/// membership group with no war-derived history yet — omitted fields default to zero/empty on
/// projection, which is the correct "never played a squad war" state, not a placeholder.
/// </remarks>
public sealed class LegacySquadDocument
{
    /// <summary>The squad's display name. <c>DatabaseSquad.maxSquadName</c> caps this at 15 chars client-side.</summary>
    [BsonId] public string Id { get; set; } = "";
    public string Message { get; set; } = "";
    public bool IsPublic { get; set; } = true;
    public string Icon { get; set; } = "";
    public int SkillRequirement { get; set; }
    public List<LegacySquadMember> Members { get; set; } = [];

    /// <summary>
    /// Player ids a current member has invited (<c>InvitePlayerToSquad</c>). Accepting one is
    /// exactly <c>JoinSquad</c> against a private squad — the recovered enum has no separate
    /// "accept invite" action, matching <c>SquadCreateScreen</c>'s own single join path.
    /// </summary>
    public List<string> PendingInvites { get; set; } = [];

    /// <summary>Player ids who asked to join (<c>JoinSquadRequest</c>) and await a leader's <c>AcceptSquadJoinRequest</c>/<c>DeclineSquadJoinRequest</c>.</summary>
    public List<string> PendingRequests { get; set; } = [];

    public DateTime CreatedUtc { get; set; }
    public long Revision { get; set; }
}

public sealed class LegacySquadStore
{
    private readonly IMongoCollection<LegacySquadDocument> squads;

    public LegacySquadStore(IMongoDatabase database) => squads = database.GetCollection<LegacySquadDocument>("legacySquads");

    public LegacySquadStore(string uri, string databaseName)
    {
        if (!Regex.IsMatch(databaseName, @"\A[A-Za-z0-9_]{1,64}\z")) throw new ArgumentException("Invalid Mongo database name.");
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
        squads = new MongoClient(settings).GetDatabase(databaseName).GetCollection<LegacySquadDocument>("legacySquads");
    }

    // Mongo's own _id uniqueness already enforces one squad per name; no separate index needed.
    public Task Initialize(CancellationToken ct) => squads.Indexes.CreateManyAsync([
        new CreateIndexModel<LegacySquadDocument>(Builders<LegacySquadDocument>.IndexKeys.Ascending("Members.PlayerId"))
    ], ct);

    public Task<LegacySquadDocument?> ById(string id, CancellationToken ct) =>
        squads.Find(x => x.Id == id).FirstOrDefaultAsync(ct)!;

    /// <summary>
    /// Public squads whose name starts with <paramref name="prefix"/> (case-insensitive), matching
    /// <c>BeanstalkServerManager.GetSquads</c>' <c>SquadNameStart</c> field. An empty prefix matches
    /// every public squad, which is also what backs <c>FindSuggestedSquads</c> — no skill-matching
    /// formula was traced from the recovered client, so "suggested" degrades to "any public squad"
    /// rather than a guessed heuristic.
    /// </summary>
    public Task<List<LegacySquadDocument>> SearchPublic(string prefix, int limit, CancellationToken ct)
    {
        var filter = Builders<LegacySquadDocument>.Filter.And(
            Builders<LegacySquadDocument>.Filter.Eq(x => x.IsPublic, true),
            Builders<LegacySquadDocument>.Filter.Regex(x => x.Id, new MongoDB.Bson.BsonRegularExpression($"^{Regex.Escape(prefix)}", "i")));
        return squads.Find(filter).Limit(limit).ToListAsync(ct);
    }

    /// <summary>Inserts a new squad. Returns false without throwing when the name is already taken.</summary>
    public async Task<bool> TryInsert(LegacySquadDocument squad, CancellationToken ct)
    {
        try
        {
            await squads.InsertOneAsync(squad, cancellationToken: ct);
            return true;
        }
        catch (MongoWriteException e) when (e.WriteError.Category == ServerErrorCategory.DuplicateKey)
        {
            return false;
        }
    }

    /// <summary>Adds a member if not already present. Returns false if the squad does not exist or the player is already a member.</summary>
    public async Task<bool> TryAddMember(string squadId, LegacySquadMember member, CancellationToken ct)
    {
        var filter = Builders<LegacySquadDocument>.Filter.And(
            Builders<LegacySquadDocument>.Filter.Eq(x => x.Id, squadId),
            Builders<LegacySquadDocument>.Filter.Not(
                Builders<LegacySquadDocument>.Filter.ElemMatch(x => x.Members, m => m.PlayerId == member.PlayerId)));
        var result = await squads.UpdateOneAsync(filter,
            Builders<LegacySquadDocument>.Update.Push(x => x.Members, member).Inc(x => x.Revision, 1), cancellationToken: ct);
        return result.ModifiedCount == 1;
    }

    public Task Delete(string squadId, CancellationToken ct) => squads.DeleteOneAsync(x => x.Id == squadId, ct);

    public Task RemoveMember(string squadId, string playerId, CancellationToken ct) =>
        squads.UpdateOneAsync(x => x.Id == squadId,
            Builders<LegacySquadDocument>.Update.PullFilter(x => x.Members, m => m.PlayerId == playerId).Inc(x => x.Revision, 1), cancellationToken: ct);

    /// <summary>Updates one member's rank in place. Returns false if the squad or member is missing.</summary>
    public async Task<bool> TrySetMemberRank(string squadId, string playerId, int rank, CancellationToken ct)
    {
        var filter = Builders<LegacySquadDocument>.Filter.And(
            Builders<LegacySquadDocument>.Filter.Eq(x => x.Id, squadId),
            Builders<LegacySquadDocument>.Filter.ElemMatch(x => x.Members, m => m.PlayerId == playerId));
        var result = await squads.UpdateOneAsync(filter,
            Builders<LegacySquadDocument>.Update.Set("Members.$.Rank", rank).Inc(x => x.Revision, 1), cancellationToken: ct);
        return result.ModifiedCount == 1;
    }

    /// <summary>Applies an arbitrary update to a squad document (settings changes), bumping <see cref="LegacySquadDocument.Revision"/>.</summary>
    public Task Update(string squadId, UpdateDefinition<LegacySquadDocument> update, CancellationToken ct) =>
        squads.UpdateOneAsync(x => x.Id == squadId, update.Inc(x => x.Revision, 1), cancellationToken: ct);
}
