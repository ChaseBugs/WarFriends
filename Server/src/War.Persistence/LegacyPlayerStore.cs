using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace War.Persistence;

/// <summary>
/// The persisted account behind the 1.4.0 client's legacy HTTP channel.
/// </summary>
/// <remarks>
/// Field names and types are taken from the client's own loaders — <c>DatabasePlayer.CreateFromDatabase</c>
/// for the <c>Player</c> object and <c>ServerResponseHandler.LoadPlayerData</c> for <c>PlayerData</c> —
/// so that emitting a response is a direct projection of this document rather than a translation.
/// <para>This is deliberately separate from <see cref="AccountDocument"/>. That type backs the new
/// protobuf <c>/v1</c> API and has no legacy contract to honour; merging them would force one of the
/// two wire formats to compromise.</para>
/// </remarks>
public sealed class LegacyPlayerDocument
{
    /// <summary>The client's <c>Player.Id</c> (<c>S</c>) and the <c>PlayerId</c> envelope field.</summary>
    [BsonId] public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public int AccountType { get; set; }
    public string Locale { get; set; } = "en";
    public string Country { get; set; } = "";

    /// <summary>
    /// Credential material for the guest password the server issues at account creation and the
    /// client replays through <c>LoginToCustomAccount</c>. Same posture as <see cref="AccountStore"/>:
    /// PBKDF2-SHA256, 600k iterations, 16-byte salt, 32-byte derived key.
    /// </summary>
    public byte[] Salt { get; set; } = [];
    public byte[] PasswordHash { get; set; } = [];
    public int PasswordIterations { get; set; } = 600_000;

    /// <summary>The issued <c>Token</c>, stored hashed. The plaintext never touches the database.</summary>
    public string SessionHash { get; set; } = "";
    public DateTime SessionExpiresUtc { get; set; }

    // Progression — server-owned. Never assigned from a client-reported value.
    public int Level { get; set; } = 1;
    public int LevelExperience { get; set; }
    public long Experience { get; set; }
    public int ArmyPower { get; set; }
    public int Reputation { get; set; }
    public int Skill { get; set; }
    public int MedalsBalance { get; set; }
    public int BeginnersLeague { get; set; } = 1;
    public int PlacementMatchesRequired { get; set; }
    public string LeagueId { get; set; } = "";

    // Wallet — server-owned.
    public long Gold { get; set; }
    public long WarBucks { get; set; }
    public long Tickets { get; set; }
    public long Scraps { get; set; }

    // VIP and dog tags, as unix seconds / counts.
    public int Vip { get; set; }
    public int VipStart { get; set; }
    public int DogTagSeconds { get; set; }
    public int DogTagLastUpdate { get; set; }
    public int DogTagMax { get; set; }

    // Presentation and social.
    public string DeviceToken { get; set; } = "";
    public string VisualType { get; set; } = "";
    public int VisualTimestamp { get; set; }
    public string SquadId { get; set; } = "";

    /// <summary>
    /// Cards this player has deposited into their squad's shared pool (<c>DepositCards</c>/
    /// <c>WithdrawCard</c>), keyed by card id. Lives on the <em>player</em> document, not the squad
    /// — <c>DatabasePlayer.CreateFromDatabase</c> parses <c>Player.DepositedCards</c> off each
    /// squad member's own player record, so a squad's "pool" is really the union of its members'
    /// individually-tracked deposits, visible via <c>GetAllSquadMembers</c>. Buddy-card deposits (a
    /// distinct wire shape keyed by a <c>"start-end"</c> numeric range rather than a card id) are
    /// out of scope.
    /// </summary>
    public Dictionary<string, int> DepositedCards { get; set; } = [];
    public int SquadPoints { get; set; }
    public int SquadRank { get; set; }
    public int Status { get; set; }
    public int LastAction { get; set; }
    public int SendLogs { get; set; }
    public int Position { get; set; }
    public int BattlesLostInRow { get; set; }

    /// <summary>
    /// Tracks <c>PlayerAnalytics.PlayerAnalyticsData.renameCount</c>. Only its zero/non-zero state
    /// is currently authoritative: <c>PlayerAnalytics.renameGoldPrice</c> is 0 for the first rename
    /// and <c>2^(renameCount-1) * Constants.rowIds.SecondRenameGoldCost</c> afterward. That row
    /// value has not been extracted from the Google2u sheets yet, so a priced rename is refused
    /// rather than charged an invented price — see <c>LegacyEndpoints.ChangePlayerName</c>.
    /// </summary>
    public int RenameCount { get; set; }

    /// <summary>
    /// Tracks <c>PlayerAnalytics.PlayerAnalyticsData.squadCreationsCount</c>. Feeds
    /// <c>CreateSquad</c>'s price: <c>(squadCreationsCount + 1) * WarBucksCreateSquadPrice</c>
    /// (verified <c>Google2u.Constants</c> value 50000) — escalates with every squad the player has
    /// created, matching <c>PlayerAnalytics.createSquadWarBucksPrice</c> exactly.
    /// </summary>
    public int SquadCreationsCount { get; set; }

    /// <summary>
    /// The server-bound battle identity issued by <c>GameStartedTutorial</c> (119) and echoed back
    /// by the client's own <c>TutorialEnded</c> (120) request. Null once no tutorial battle is
    /// outstanding (never started, or already completed) — see <c>LegacyEndpoints.TutorialEnded</c>.
    /// </summary>
    public string? PendingTutorialBattleId { get; set; }

    /// <summary>
    /// Set once the client reports the tutorial finished. Presence of a <c>TutorialData</c> key in
    /// the emitted <c>PlayerData</c> is what tells the client the tutorial is already done, so this
    /// flag alone decides whether a returning player is dropped back into the tutorial.
    /// </summary>
    public bool TutorialCompleted { get; set; }

    /// <summary>
    /// The per-subsystem blobs, keyed by the exact .NET simple type name each
    /// <c>DatabaseSerializedObjectGeneric&lt;T&gt;</c> looks itself up by, with a raw JSON document
    /// as the value. A key that is absent here is absent from the response, which the client
    /// answers with <c>LoadEmpty()</c> — its own default instance.
    /// </summary>
    public Dictionary<string, string> Serialized { get; set; } = [];

    public DateTime CreatedUtc { get; set; }
    public long Revision { get; set; } = 1;
}

/// <summary>
/// Reads and writes <see cref="LegacyPlayerDocument"/>s for the legacy HTTP channel.
/// </summary>
public sealed class LegacyPlayerStore
{
    /// <summary>
    /// The 16 subsystem blob keys the 1.4.0 client registers, each the simple name of the
    /// <c>T</c> in a concrete <c>DatabaseSerializedObjectGeneric&lt;T&gt;</c>. Enumerated from the
    /// recovered client; used to reject writes under keys the client would never read back.
    /// </summary>
    public static readonly IReadOnlySet<string> SerializedKeys = new HashSet<string>(StringComparer.Ordinal)
    {
        "AssignmentData",        // AssignmentsManager
        "DecalManagerData",      // CamosManager
        "CraftData",             // CardCraftingManager
        "CardManagerData",       // CardManager
        "ChatBanData",           // ChatBanManager
        "InAppData",             // InAppDataManager
        "LevelManagerData",      // LevelManager
        "MissionManagerData",    // MissionsManager
        "PlayerAnalyticsData",   // PlayerAnalytics
        "InventoryData",         // PlayerInventory
        "Settings",              // SettingsManager
        "StarterAssignmentsData",// StarterAssignmentsManager
        "StatisticsData",        // StatsManager
        "UserDevices",           // UserDeviceManager
        "WarArenaData",          // WarArena
        "WinStreak"              // WinStreakManager
    };

    private readonly IMongoCollection<LegacyPlayerDocument> players;

    public LegacyPlayerStore(IMongoDatabase database) => players = database.GetCollection<LegacyPlayerDocument>("legacyPlayers");

    public LegacyPlayerStore(string uri, string databaseName)
    {
        if (!Regex.IsMatch(databaseName, @"\A[A-Za-z0-9_]{1,64}\z")) throw new ArgumentException("Invalid Mongo database name.");
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
        players = new MongoClient(settings).GetDatabase(databaseName).GetCollection<LegacyPlayerDocument>("legacyPlayers");
    }

    public Task Initialize(CancellationToken ct) => players.Indexes.CreateManyAsync([
        new CreateIndexModel<LegacyPlayerDocument>(Builders<LegacyPlayerDocument>.IndexKeys.Ascending(x => x.SessionHash),
            new CreateIndexOptions { Unique = true, Sparse = true }),
        new CreateIndexModel<LegacyPlayerDocument>(Builders<LegacyPlayerDocument>.IndexKeys.Ascending(x => x.Name))
    ], ct);

    public static string HashToken(string token) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(token)));

    /// <summary>A 64-hex-character session token. The client stores and replays it verbatim.</summary>
    public static string NewToken() => Convert.ToHexString(RandomNumberGenerator.GetBytes(32));

    /// <summary>
    /// The guest password the server issues and the client replays. It is generated server-side,
    /// never accepted from the client, and returned exactly once in the CreateAccount response.
    /// </summary>
    public static string NewPassword() => Convert.ToHexString(RandomNumberGenerator.GetBytes(16));

    private static byte[] Derive(string password, byte[] salt, int iterations) =>
        Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA256, 32);

    public async Task Insert(LegacyPlayerDocument player, string password, CancellationToken ct)
    {
        player.Salt = RandomNumberGenerator.GetBytes(16);
        player.PasswordIterations = 600_000;
        player.PasswordHash = Derive(password, player.Salt, player.PasswordIterations);
        await players.InsertOneAsync(player, cancellationToken: ct);
    }

    public Task<LegacyPlayerDocument?> ById(string id, CancellationToken ct) =>
        players.Find(x => x.Id == id).FirstOrDefaultAsync(ct)!;

    public Task<List<LegacyPlayerDocument>> ByIds(IEnumerable<string> ids, CancellationToken ct) =>
        players.Find(Builders<LegacyPlayerDocument>.Filter.In(x => x.Id, ids)).ToListAsync(ct);

    /// <summary>
    /// Verifies a replayed guest password. Runs the KDF even when the account is missing so a
    /// wrong id and a wrong password cost the same.
    /// </summary>
    public async Task<LegacyPlayerDocument?> VerifyPassword(string id, string password, CancellationToken ct)
    {
        var player = await ById(id, ct);
        if (player != null && (player.PasswordIterations != 600_000 || player.Salt.Length != 16 || player.PasswordHash.Length != 32))
            throw new InvalidDataException("Invalid persisted credential authority.");
        byte[] computed = Derive(password, player?.Salt ?? new byte[16], 600_000);
        return player != null && CryptographicOperations.FixedTimeEquals(computed, player.PasswordHash) ? player : null;
    }

    /// <summary>
    /// Resolves the <c>Token</c>/<c>PlayerId</c> envelope pair to an account. Both must match the
    /// same unexpired document: a valid token for a different player id is rejected.
    /// </summary>
    public async Task<LegacyPlayerDocument?> Authenticate(string? token, string? playerId, CancellationToken ct)
    {
        if (token == null || playerId == null || !Regex.IsMatch(token, @"\A[A-F0-9]{64}\z")) return null;
        string hash = HashToken(token);
        DateTime now = DateTime.UtcNow;
        var player = await players.Find(x => x.SessionHash == hash && x.SessionExpiresUtc > now).FirstOrDefaultAsync(ct);
        return player != null && player.Id == playerId ? player : null;
    }

    /// <summary>Bearer authentication for the protobuf battle bridge. The session token is unique,
    /// hashed at rest, and already identifies exactly one unexpired legacy player.</summary>
    public async Task<LegacyPlayerDocument?> AuthenticateToken(string? token, CancellationToken ct)
    {
        if (token == null || !Regex.IsMatch(token, @"\A[A-F0-9]{64}\z")) return null;
        string hash = HashToken(token);
        DateTime now = DateTime.UtcNow;
        var player = await players.Find(x => x.SessionHash == hash && x.SessionExpiresUtc > now).FirstOrDefaultAsync(ct);
        if (player != null && (!Guid.TryParseExact(player.Id, "N", out _) || player.Id != player.Id.ToLowerInvariant()))
            throw new InvalidDataException("Legacy player identity cannot enter the protobuf battle channel.");
        return player;
    }

    /// <summary>Rotates the session token, returning the new plaintext for the response.</summary>
    public async Task<string> IssueSession(LegacyPlayerDocument player, TimeSpan lifetime, CancellationToken ct)
    {
        string token = NewToken();
        DateTime expiry = DateTime.UtcNow.Add(lifetime);
        await players.UpdateOneAsync(x => x.Id == player.Id,
            Builders<LegacyPlayerDocument>.Update
                .Set(x => x.SessionHash, HashToken(token))
                .Set(x => x.SessionExpiresUtc, expiry)
                .Inc(x => x.Revision, 1), cancellationToken: ct);
        player.SessionHash = HashToken(token);
        player.SessionExpiresUtc = expiry;
        return token;
    }

    /// <summary>
    /// Replaces one subsystem blob. Rejects keys outside <see cref="SerializedKeys"/> so a
    /// misspelled or client-invented name cannot accumulate as data the client will never read.
    /// </summary>
    public Task SetSerialized(string playerId, string key, string json, CancellationToken ct)
    {
        if (!SerializedKeys.Contains(key)) throw new ArgumentException($"'{key}' is not a subsystem blob the 1.4.0 client reads back.", nameof(key));
        return players.UpdateOneAsync(x => x.Id == playerId,
            Builders<LegacyPlayerDocument>.Update.Set($"Serialized.{key}", json).Inc(x => x.Revision, 1), cancellationToken: ct);
    }

    public Task Update(string playerId, UpdateDefinition<LegacyPlayerDocument> update, CancellationToken ct) =>
        players.UpdateOneAsync(x => x.Id == playerId, update.Inc(x => x.Revision, 1), cancellationToken: ct);

    /// <summary>
    /// Atomically applies <paramref name="update"/> only if <paramref name="condition"/> still
    /// holds on the stored document at the moment of the write, and returns the document as it
    /// exists after the write — or <c>null</c> if the condition failed.
    /// </summary>
    /// <remarks>
    /// Closes a real race a separate "read balance, check it, then <c>$inc</c>" pattern leaves
    /// open: two concurrent requests from the same player (a double-tapped buy button, a client
    /// retry) can both read the same starting balance before either write lands, both pass the
    /// check against that stale snapshot, and both debit — the second landing on a document that
    /// no longer actually affords it. A single-document <c>FindOneAndUpdate</c> with the balance
    /// folded into its filter is atomic on any MongoDB (standalone included, no transaction or
    /// replica set required) because the match and the write happen as one operation.
    /// </remarks>
    public async Task<LegacyPlayerDocument?> TryUpdate(string playerId, Expression<Func<LegacyPlayerDocument, bool>> condition, UpdateDefinition<LegacyPlayerDocument> update, CancellationToken ct) =>
        await players.FindOneAndUpdateAsync(
            Builders<LegacyPlayerDocument>.Filter.Where(x => x.Id == playerId) & Builders<LegacyPlayerDocument>.Filter.Where(condition),
            update.Inc(x => x.Revision, 1),
            new FindOneAndUpdateOptions<LegacyPlayerDocument> { ReturnDocument = ReturnDocument.After },
            ct);
}
