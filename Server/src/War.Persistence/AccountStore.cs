using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using War.Protocol;

namespace War.Persistence;

public sealed class AccountDocument
{
    [BsonId] public string Id { get; set; } = "";
    public string Username { get; set; } = "";
    public string Locale { get; set; } = "";
    public byte[] Salt { get; set; } = [];
    public byte[] PasswordHash { get; set; } = [];
    public int PasswordIterations { get; set; } = 600_000;
    public string SessionHash { get; set; } = "";
    public DateTime SessionExpiresUtc { get; set; }
    public DateTime CreatedUtc { get; set; }
    public long Revision { get; set; } = 1;
}

public sealed class AccountStore
{
    private readonly IMongoDatabase database;
    private readonly IMongoCollection<AccountDocument> accounts;
    public AccountStore(string uri, string databaseName)
    {
        if (!Regex.IsMatch(databaseName, @"\A[A-Za-z0-9_]{1,64}\z")) throw new ArgumentException("Invalid Mongo database name.");
        var settings = MongoClientSettings.FromConnectionString(uri);
        settings.ServerSelectionTimeout = TimeSpan.FromSeconds(5);
        database = new MongoClient(settings).GetDatabase(databaseName);
        accounts = database.GetCollection<AccountDocument>("accounts");
    }
    public async Task Initialize(CancellationToken ct)
    {
        await Ping(ct);
        await accounts.Indexes.CreateManyAsync([
            new CreateIndexModel<AccountDocument>(Builders<AccountDocument>.IndexKeys.Ascending(x => x.Username), new CreateIndexOptions { Unique = true }),
            new CreateIndexModel<AccountDocument>(Builders<AccountDocument>.IndexKeys.Ascending(x => x.SessionHash), new CreateIndexOptions { Unique = true })
        ], ct);
    }
    public Task<BsonDocument> Ping(CancellationToken ct) => database.RunCommandAsync<BsonDocument>(new BsonDocument("ping", 1), cancellationToken: ct);
    public static bool ValidCredentials(string name, string password) => Regex.IsMatch(name, @"\A[a-z0-9_]{3,24}\z") && password.Length is >= 12 and <= 128;
    public static bool ValidLocale(string locale) => Regex.IsMatch(locale, @"\A[a-z]{2,3}(?:[-_][A-Za-z]{2,4})?\z");
    public static string HashToken(string token) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(token)));
    private static string NewToken() => Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
    public async Task<AccountSession?> Register(RegisterRequest request, CancellationToken ct)
    {
        if (!ValidCredentials(request.Username, request.Password) || !ValidLocale(request.Locale)) throw new ArgumentException("Invalid registration fields.");
        string token = NewToken();
        DateTime now = DateTime.UtcNow;
        var account = new AccountDocument
        {
            Id = Guid.NewGuid().ToString("N"),
            Username = request.Username,
            Locale = request.Locale,
            Salt = RandomNumberGenerator.GetBytes(16),
            SessionHash = HashToken(token),
            SessionExpiresUtc = now.AddHours(24),
            CreatedUtc = now
        };
        account.PasswordHash = Rfc2898DeriveBytes.Pbkdf2(request.Password, account.Salt, account.PasswordIterations, HashAlgorithmName.SHA256, 32);
        try { await accounts.InsertOneAsync(account, cancellationToken: ct); }
        catch (MongoWriteException e) when (e.WriteError.Category == ServerErrorCategory.DuplicateKey) { return null; }
        return Session(account, token);
    }
    public async Task<AccountSession?> Login(LoginRequest request, CancellationToken ct)
    {
        if (!ValidCredentials(request.Username, request.Password)) return null;
        var account = await accounts.Find(x => x.Username == request.Username).FirstOrDefaultAsync(ct);
        if (account != null && (account.PasswordIterations != 600_000 || account.Salt.Length != 16 || account.PasswordHash.Length != 32)) throw new InvalidDataException("Invalid credential authority.");
        byte[] computed = Rfc2898DeriveBytes.Pbkdf2(request.Password, account?.Salt ?? new byte[16], 600_000, HashAlgorithmName.SHA256, 32);
        if (account == null || !CryptographicOperations.FixedTimeEquals(computed, account.PasswordHash)) return null;
        string token = NewToken();
        DateTime expiry = DateTime.UtcNow.AddHours(24);
        var result = await accounts.UpdateOneAsync(x => x.Id == account.Id && x.SessionHash == account.SessionHash,
            Builders<AccountDocument>.Update.Set(x => x.SessionHash, HashToken(token)).Set(x => x.SessionExpiresUtc, expiry), cancellationToken: ct);
        if (result.ModifiedCount != 1) return null;
        account.SessionExpiresUtc = expiry;
        return Session(account, token);
    }
    public async Task<PlayerProfile?> Authenticate(string token, CancellationToken ct)
    {
        if (!Regex.IsMatch(token, @"\A[A-F0-9]{64}\z")) return null;
        string hash = HashToken(token);
        DateTime now = DateTime.UtcNow;
        var account = await accounts.Find(x => x.SessionHash == hash && x.SessionExpiresUtc > now).FirstOrDefaultAsync(ct);
        return account == null ? null : Profile(account);
    }
    private static PlayerProfile Profile(AccountDocument a)
    {
        if (!Guid.TryParseExact(a.Id, "N", out _) || !ValidLocale(a.Locale) || !Regex.IsMatch(a.Username, @"\A[a-z0-9_]{3,24}\z") || a.Revision < 1)
            throw new InvalidDataException("Invalid persisted account profile.");
        return new PlayerProfile { PlayerId = a.Id, DisplayName = a.Username, Locale = a.Locale, Revision = a.Revision };
    }
    private static AccountSession Session(AccountDocument a, string token) => new() { AccessToken = token, ExpiresUnixSeconds = new DateTimeOffset(a.SessionExpiresUtc).ToUnixTimeSeconds(), Player = Profile(a) };
}
