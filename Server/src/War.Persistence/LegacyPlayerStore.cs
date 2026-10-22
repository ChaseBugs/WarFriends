using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.Analytics;
using War.Persistence.Legacy.Preferences;
using War.Persistence.Legacy.State;
using War.Persistence.Legacy.Tutorial;

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
    /// <summary>Permanent per-device high-water marks prevent offline reward replay after reconnect.</summary>
    public Dictionary<string, long> OfflineBotStreams { get; set; } = new();
    public War.Persistence.Legacy.Progression.DailyRewardCalendar? DailyRewards { get; set; }
    public int AccountType { get; set; }
    public string Locale { get; set; } = "en";
    /// <summary>Registration diagnostic only; never used for clocks, calendars or eligibility.</summary>
    public double? InitialUtcOffsetHours { get; set; }
    public string Country { get; set; } = "";

    /// <summary>
    /// Credential material for the guest password the server issues at account creation and the
    /// client replays through <c>LoginToCustomAccount</c>. Same posture as <see cref="AccountStore"/>:
    /// PBKDF2-SHA256, 600k iterations, 16-byte salt, 32-byte derived key.
    /// </summary>
    public byte[] Salt { get; set; } = [];
    public byte[] PasswordHash { get; set; } = [];
    public int PasswordIterations { get; set; } = LegacyPasswordAuthority.Iterations;

    /// <summary>The issued <c>Token</c>, stored hashed. The plaintext never touches the database.</summary>
    public string SessionHash { get; set; } = "";
    public DateTime SessionExpiresUtc { get; set; }

    // Progression — server-owned. Never assigned from a client-reported value.
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int Level { get; set; } = 1;
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int LevelExperience { get; set; }
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt64Serializer))]
    public long Experience { get; set; }
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int ArmyPower { get; set; }
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int Reputation { get; set; }
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int Skill { get; set; }
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int MedalsBalance { get; set; }
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int BeginnersLeague { get; set; } = 1;
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int PlacementMatchesRequired { get; set; }
    public string LeagueId { get; set; } = "";

    // Wallet — server-owned.
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt64Serializer))]
    public long Gold { get; set; }
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt64Serializer))]
    public long WarBucks { get; set; }
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt64Serializer))]
    public long Tickets { get; set; }
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt64Serializer))]
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
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int SquadPoints { get; set; }
    public int SquadRank { get; set; }
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int Status { get; set; }
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int LastAction { get; set; }
    public int SendLogs { get; set; }
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int Position { get; set; }
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int BattlesLostInRow { get; set; }

    /// <summary>
    /// Tracks the recovered rename counter. The first rename is free; later prices double the
    /// catalog's SecondRenameGoldCost. LegacyRenamePolicy checks the Client-width price before
    /// RenamePlayerAsync atomically publishes the name, count and Gold debit against a live session.
    /// </summary>
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int RenameCount { get; set; }

    /// <summary>
    /// Tracks <c>PlayerAnalytics.PlayerAnalyticsData.squadCreationsCount</c>. Feeds
    /// <c>CreateSquad</c>'s price: <c>(squadCreationsCount + 1) * WarBucksCreateSquadPrice</c>
    /// (verified <c>Google2u.Constants</c> value 50000) — escalates with every squad the player has
    /// created, matching <c>PlayerAnalytics.createSquadWarBucksPrice</c> exactly.
    /// </summary>
    [BsonRequired]
    [BsonSerializer(typeof(LegacyInt32Serializer))]
    public int SquadCreationsCount { get; set; }

    /// <summary>
    /// The server-bound battle identity issued by <c>GameStartedTutorial</c> (119) and echoed back
    /// by the client's own <c>TutorialEnded</c> (120) request. Null once no tutorial battle is
    /// outstanding. ApplyTutorialAsync publishes its versioned identity and terminal mirrors together.
    /// </summary>
    [BsonSerializer(typeof(LegacyTutorialIdSerializer))]
    public string? PendingTutorialBattleId { get; set; }

    /// <summary>
    /// Set once the client reports the tutorial finished. Presence of a <c>TutorialData</c> key in
    /// the emitted <c>PlayerData</c> is what tells the client the tutorial is already done, so this
    /// flag alone decides whether a returning player is dropped back into the tutorial.
    /// </summary>
    [BsonRequired]
    [BsonSerializer(typeof(LegacyBooleanSerializer))]
    public bool TutorialCompleted { get; set; }

    /// <summary>Absent on old documents; a present container must carry complete versioned identity.</summary>
    [BsonIgnoreIfNull]
    [BsonSerializer(typeof(LegacyTutorialStateSerializer))]
    public LegacyTutorialState? TutorialState { get; set; }

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
public sealed partial class LegacyPlayerStore
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

    public async Task Initialize(CancellationToken ct)
    {
        await players.Indexes.CreateManyAsync([
        new CreateIndexModel<LegacyPlayerDocument>(Builders<LegacyPlayerDocument>.IndexKeys.Ascending(x => x.SessionHash),
            new CreateIndexOptions { Unique = true, Sparse = true }),
        new CreateIndexModel<LegacyPlayerDocument>(Builders<LegacyPlayerDocument>.IndexKeys.Ascending(x => x.Name))
        ], ct);
        await InitializeCardPoolAsync(ct);
    }

    public static string HashToken(string token) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(token)));

    /// <summary>A 64-hex-character session token. The client stores and replays it verbatim.</summary>
    public static string NewToken() => Convert.ToHexString(RandomNumberGenerator.GetBytes(32));

    /// <summary>
    /// The guest password the server issues and the client replays. It is generated server-side,
    /// never accepted from the client, and returned exactly once in the CreateAccount response.
    /// </summary>
    public static string NewPassword() => Convert.ToHexString(RandomNumberGenerator.GetBytes(16));

    public async Task<LegacyPlayerDocument?> ById(string id, CancellationToken ct, DateTimeOffset? authorityTime = null)
    {
        LegacyPlayerDocument? player = await players.Find(x => x.Id == id).FirstOrDefaultAsync(ct);
        if (player != null)
        {
            LegacyPlayerIdentityAuthority.Validate(player);
            LegacyPlayerEconomyAuthority.Validate(player, authorityTime);
            LegacyAnalyticsState.ValidateContainer(player.Serialized);
            LegacyTutorialAuthority.ValidateForRead(player);
        }

        return player;
    }

    public async Task<List<LegacyPlayerDocument>> ByIds(IEnumerable<string> ids, CancellationToken ct)
    {
        List<LegacyPlayerDocument> selected = await players.Find(
            Builders<LegacyPlayerDocument>.Filter.In(x => x.Id, ids)).ToListAsync(ct);
        foreach (LegacyPlayerDocument player in selected)
        {
            LegacyPlayerIdentityAuthority.Validate(player);
            LegacyPlayerEconomyAuthority.Validate(player);
            LegacyAnalyticsState.ValidateContainer(player.Serialized);
            LegacyTutorialAuthority.ValidateForRead(player);
        }

        return selected;
    }

    /// <summary>
    /// Verifies a replayed guest password. Runs the KDF even when the account is missing so a
    /// wrong id and a wrong password cost the same.
    /// </summary>
    public async Task<LegacyPlayerDocument?> VerifyPassword(string id, string password, CancellationToken ct)
    {
        var player = await ById(id, ct);
        if (player != null)
        {
            LegacySessionAuthority.ValidateStored(player, DateTime.UtcNow);
        }

        if (player != null && (player.PasswordIterations != LegacyPasswordAuthority.Iterations ||
            player.Salt == null || player.Salt.Length != LegacyPasswordAuthority.SaltBytes ||
            player.PasswordHash == null || player.PasswordHash.Length != LegacyPasswordAuthority.HashBytes))
        {
            throw new InvalidDataException("Invalid persisted credential authority.");
        }

        byte[] salt = player?.Salt ?? new byte[LegacyPasswordAuthority.SaltBytes];
        byte[] computed = LegacyPasswordAuthority.Derive(password, salt);
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
        if (player == null || player.Id != playerId)
        {
            return null;
        }

        LegacySessionAuthority.ValidateStored(player, now);
        LegacyPlayerIdentityAuthority.Validate(player);
        LegacyPlayerEconomyAuthority.Validate(player);
        LegacyAnalyticsState.ValidateContainer(player.Serialized);
        LegacyTutorialAuthority.ValidateForRead(player);
        LegacySettingsSnapshot.ValidateContainer(player.Serialized);
        return player;
    }

    /// <summary>Bearer authentication for the protobuf battle bridge. The session token is unique,
    /// hashed at rest, and already identifies exactly one unexpired legacy player.</summary>
    public async Task<LegacyPlayerDocument?> AuthenticateToken(string? token, CancellationToken ct)
    {
        if (token == null || !Regex.IsMatch(token, @"\A[A-F0-9]{64}\z")) return null;
        string hash = HashToken(token);
        DateTime now = DateTime.UtcNow;
        var player = await players.Find(x => x.SessionHash == hash && x.SessionExpiresUtc > now).FirstOrDefaultAsync(ct);
        if (player != null)
        {
            LegacySessionAuthority.ValidateStored(player, now);
            LegacyPlayerIdentityAuthority.Validate(player);
            LegacyPlayerEconomyAuthority.Validate(player);
            LegacyAnalyticsState.ValidateContainer(player.Serialized);
            LegacyTutorialAuthority.ValidateForRead(player);
            LegacySettingsSnapshot.ValidateContainer(player.Serialized);
        }
        if (player != null && (!War.Shared.CanonicalGuid.IsCanonical(player.Id)))
            throw new InvalidDataException("Legacy player identity cannot enter the protobuf battle channel.");
        return player;
    }

}
