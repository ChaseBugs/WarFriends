using System.Security.Cryptography;
using System.Threading.RateLimiting;
using System.Text.Json;
using Google.Protobuf;
using Microsoft.AspNetCore.RateLimiting;
using War.Backend;
using War.Backend.Legacy;
using War.Infrastructure;
using War.Persistence;
using War.Protocol;
using static War.Backend.HttpProtocol;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(k => k.Limits.MaxRequestBodySize = 65536);
string mongoUri = builder.Configuration["Mongo:Uri"] ?? "mongodb://127.0.0.1:27017";
string mongoDatabase = builder.Configuration["Mongo:Database"] ?? "warfriends";
builder.Services.AddSingleton(new AccountStore(mongoUri, mongoDatabase));
builder.Services.AddSingleton(new BattleAllocationStore(mongoUri, mongoDatabase));
builder.Services.AddSingleton(new BattleGrantStore(mongoUri, mongoDatabase));
builder.Services.AddSingleton(new BattleMatchQueueStore(mongoUri, mongoDatabase));
builder.Services.AddSingleton(new BattleResultStore(mongoUri, mongoDatabase));
builder.Services.AddSingleton(new LegacyPlayerStore(mongoUri, mongoDatabase));
builder.Services.AddSingleton<BattlePlayerPresentationSource>();
builder.Services.AddSingleton(new LegacyBufferStore(mongoUri, mongoDatabase));
builder.Services.AddSingleton(new LegacySquadStore(mongoUri, mongoDatabase));
builder.Services.AddSingleton<LegacyBufferProcessor>();
// The recovered Google2u economy catalog (Server/content/recovered-battle-content.json). Optional:
// unset or missing leaves an empty catalog, and priced actions keep refusing rather than guessing.
string? legacyContentPath = builder.Configuration["Legacy:ContentPath"];
var legacyCatalog = legacyContentPath != null && File.Exists(legacyContentPath) ? LegacyCatalog.Load(legacyContentPath) : LegacyCatalog.Empty;
builder.Services.AddSingleton(legacyCatalog);
// Catalog-derived defaults first (evidence: Google2u.Constants StartingGold/StartingWarbucks/
// DogTagCap), then explicit Legacy:Starter config on top, so an operator override always wins.
var starter = LegacyStarterState.FromCatalog(legacyCatalog);
builder.Configuration.GetSection("Legacy:Starter").Bind(starter);
builder.Services.AddSingleton(starter);
builder.Services.AddSingleton(new BattleTickets(builder.Configuration["Battle:SigningKey"] ?? throw new InvalidOperationException("Set Battle__SigningKey to a base64 32-byte random secret in BOTH processes.")));
string serverId = builder.Configuration["Battle:ServerId"] ?? "local-1";
string publicHost = builder.Configuration["Battle:PublicHost"] ?? "127.0.0.1";
int battlePort = int.Parse(builder.Configuration["Battle:Port"] ?? "30000", System.Globalization.CultureInfo.InvariantCulture);
string battleControlKeyText = builder.Configuration["Battle:ControlKey"] ?? throw new InvalidOperationException("Set Battle__ControlKey in Backend and Worker.");
byte[] battleControlKey = Convert.FromBase64String(battleControlKeyText);
if (battleControlKey.Length != 32) throw new InvalidOperationException("Battle:ControlKey must be a base64 256-bit key.");
if (battlePort is < 1 or > 65535 || !System.Text.RegularExpressions.Regex.IsMatch(serverId, @"\A[a-zA-Z0-9-]{1,64}\z") || Uri.CheckHostName(publicHost) == UriHostNameType.Unknown) throw new InvalidOperationException("Invalid battle endpoint configuration.");
int battleControlPort = int.Parse(builder.Configuration["Battle:ControlPort"] ?? (battlePort + 1).ToString(System.Globalization.CultureInfo.InvariantCulture), System.Globalization.CultureInfo.InvariantCulture);
string controlEndpointText = builder.Configuration["Battle:ControlEndpoint"] ?? $"http://127.0.0.1:{battleControlPort}/internal/matches";
string? matchmakingCompatibilityKey = builder.Configuration["Battle:MatchmakingCompatibilityKey"];
if (matchmakingCompatibilityKey != null && !System.Text.RegularExpressions.Regex.IsMatch(matchmakingCompatibilityKey, @"\A[a-zA-Z0-9_.:-]{1,128}\z"))
    throw new InvalidOperationException("Battle:MatchmakingCompatibilityKey is invalid.");
if (battleControlPort is < 1 or > 65535 || !Uri.TryCreate(controlEndpointText, UriKind.Absolute, out var battleControlEndpoint) ||
    battleControlEndpoint.Scheme is not ("http" or "https")) throw new InvalidOperationException("Invalid Battle control endpoint.");
builder.Services.AddSingleton(new BattleMatchControlClient(new HttpClient { Timeout = TimeSpan.FromSeconds(5) }, battleControlKey));
builder.Services.AddSingleton(services => new BattleMatchProvisioner(services.GetRequiredService<BattleMatchControlClient>(),
    services.GetRequiredService<BattleGrantStore>(), battleControlEndpoint));
string? battleManifestTemplatePath = builder.Configuration["Battle:MatchManifestTemplatePath"];
if (!string.IsNullOrWhiteSpace(battleManifestTemplatePath))
{
    if (!File.Exists(battleManifestTemplatePath)) throw new InvalidOperationException("Battle manifest template file does not exist.");
    string battleContentManifestPath=builder.Configuration["Battle:CombatContentManifestPath"] ??
        throw new InvalidOperationException("Set Battle__CombatContentManifestPath when matchmaking provisioning is enabled.");
    var battleRifles=BattleRifleManifestCatalog.Load(battleContentManifestPath);
    builder.Services.AddSingleton(battleRifles);
    byte[] templateBytes = File.ReadAllBytes(battleManifestTemplatePath);
    builder.Services.AddSingleton(services => new BattleManifestFactory(templateBytes,
        services.GetRequiredService<BattleAllocationStore>(),services.GetRequiredService<BattlePlayerPresentationSource>(),
        services.GetRequiredService<BattleRifleManifestCatalog>()));
}
// Limits are configurable (RateLimiting:Api/Auth:PermitLimit/WindowSeconds) so an isolated test
// harness sharing one IP across a long, fast, sequential script — e.g. LegacySmoke.ps1, which only
// grows as more legacy actions gain coverage — can raise them without touching the production
// defaults below, which stay exactly as they were when unconfigured.
int apiPermitLimit = builder.Configuration.GetValue("RateLimiting:Api:PermitLimit", 120);
int apiWindowSeconds = builder.Configuration.GetValue("RateLimiting:Api:WindowSeconds", 60);
int authPermitLimit = builder.Configuration.GetValue("RateLimiting:Auth:PermitLimit", 10);
int authWindowSeconds = builder.Configuration.GetValue("RateLimiting:Auth:WindowSeconds", 60);
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = 429;
    options.AddPolicy("api", context => RateLimitPartition.GetFixedWindowLimiter(context.Connection.RemoteIpAddress?.ToString() ?? "unknown", _ => new FixedWindowRateLimiterOptions { PermitLimit = apiPermitLimit, Window = TimeSpan.FromSeconds(apiWindowSeconds), QueueLimit = 0 }));
    options.AddPolicy("auth", context => RateLimitPartition.GetFixedWindowLimiter(context.Connection.RemoteIpAddress?.ToString() ?? "unknown", _ => new FixedWindowRateLimiterOptions { PermitLimit = authPermitLimit, Window = TimeSpan.FromSeconds(authWindowSeconds), QueueLimit = 0 }));
});
// The 1.4.0 client's own request builder decides the scheme (BeanstalkUrlCreator uses https for a
// Production build), so a plain-HTTP legacy deployment is an explicit operator choice, not a
// default. It stays off unless Legacy__AllowInsecureHttp is set.
bool legacyAllowsInsecureHttp = builder.Configuration.GetValue("Legacy:AllowInsecureHttp", false);
var app = builder.Build();
await app.Services.GetRequiredService<AccountStore>().Initialize(app.Lifetime.ApplicationStopping);
await app.Services.GetRequiredService<BattleAllocationStore>().Initialize(app.Lifetime.ApplicationStopping);
await app.Services.GetRequiredService<BattleGrantStore>().Initialize(app.Lifetime.ApplicationStopping);
await app.Services.GetRequiredService<BattleMatchQueueStore>().Initialize(app.Lifetime.ApplicationStopping);
await app.Services.GetRequiredService<BattleResultStore>().Initialize(app.Lifetime.ApplicationStopping);
await app.Services.GetRequiredService<BattleResultStore>().Prune(DateTimeOffset.UtcNow, TimeSpan.FromDays(30), app.Lifetime.ApplicationStopping);
await app.Services.GetRequiredService<LegacyPlayerStore>().Initialize(app.Lifetime.ApplicationStopping);
await app.Services.GetRequiredService<LegacyBufferStore>().Initialize(app.Lifetime.ApplicationStopping);
await app.Services.GetRequiredService<LegacySquadStore>().Initialize(app.Lifetime.ApplicationStopping);
if (legacyAllowsInsecureHttp) app.Logger.LogWarning("Legacy HTTP channel accepts plain HTTP. Credentials and session tokens are exposed; use this only on an isolated offline network.");
app.Use(async (context, next) =>
{
    try
    {
        bool exempt = context.Request.Path.StartsWithSegments("/health")
            || (legacyAllowsInsecureHttp && LegacyEndpoints.IsLegacyPath(context.Request.Path));
        if (!app.Environment.IsDevelopment() && !context.Request.IsHttps && !exempt)
        {
            await Error(400, "https_required", "HTTPS is required.").ExecuteAsync(context); return;
        }
        await next();
    }
    catch (InvalidProtocolBufferException) { await Error(400, "invalid_protobuf", "Invalid protobuf body.").ExecuteAsync(context); }
    catch (BadHttpRequestException e) { await Error(e.StatusCode, "invalid_request", "Request rejected.").ExecuteAsync(context); }
    catch (Exception e) when (e is not OperationCanceledException)
    {
        app.Logger.LogError("Request failed: {ErrorType}", e.GetType().Name);
        await Error(503, "unavailable", "Service unavailable.").ExecuteAsync(context);
    }
});
app.UseRateLimiter();
app.MapGet("/health/live", () => Results.Ok(new { status = "alive" }));
app.MapGet("/health/ready", async (AccountStore store, CancellationToken ct) => { await store.Ping(ct); return Results.Ok(new { status = "ready" }); });
// The recovered 1.4.0 client's own channel. Separate from /v1, which is the new protobuf API.
app.MapLegacy(app.Services.GetRequiredService<LegacyPlayerStore>(), app.Services.GetRequiredService<LegacyBufferProcessor>(), starter, legacyCatalog, app.Services.GetRequiredService<LegacySquadStore>());
var auth = app.MapGroup("/v1/accounts").RequireRateLimiting("auth");
auth.MapPost("/register", async (HttpContext ctx, AccountStore store) =>
{
    var request = await Read(ctx, RegisterRequest.Parser);
    if (!AccountStore.ValidCredentials(request.Username, request.Password) || !AccountStore.ValidLocale(request.Locale)) return Error(400, "invalid_registration", "Use a lowercase 3-24 character username, 12-128 character password, and valid locale.");
    var session = await store.Register(request, ctx.RequestAborted);
    return session == null ? Error(409, "account_exists", "Account already exists.") : Proto(session);
});
auth.MapPost("/login", async (HttpContext ctx, AccountStore store) =>
{
    var session = await store.Login(await Read(ctx, LoginRequest.Parser), ctx.RequestAborted);
    return session == null ? Error(401, "invalid_credentials", "Invalid credentials.") : Proto(session);
});
var api = app.MapGroup("/v1").RequireRateLimiting("api");
api.MapGet("/player", async (HttpContext ctx, AccountStore store) =>
{
    var player = await Player(ctx, store);
    return player == null ? Error(401, "unauthorized", "Authentication required.") : Proto(player);
});
// A connectivity probe is not matchmaking and cannot grant gameplay rewards.
api.MapPost("/network/connect", async (HttpContext ctx, AccountStore store, BattleTickets tickets) =>
{
    var player = await Player(ctx, store);
    if (player == null) return Error(401, "unauthorized", "Authentication required.");
    var request = await Read(ctx, ConnectionRequest.Parser);
    if (request.Protocol != "war.v1") return Error(400, "protocol_version", "Expected war.v1.");
    ulong sessionId;
    do { sessionId = BitConverter.ToUInt64(RandomNumberGenerator.GetBytes(8)); } while (sessionId == 0);
    long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    var claims = new TicketClaims { PlayerId = player.PlayerId, ServerId = serverId, SessionId = sessionId, IssuedUnixSeconds = now, ExpiresUnixSeconds = now + BattleTickets.LifetimeSeconds, Purpose = "connectivity-probe" };
    return Proto(new ConnectionGrant { Host = publicHost, Port = (uint)battlePort, Ticket = tickets.Sign(claims), SessionKey = ByteString.CopyFrom(tickets.SessionKey(sessionId)), SessionId = sessionId, ExpiresUnixSeconds = claims.ExpiresUnixSeconds });
});
api.MapPost("/battle/grant", async (HttpContext ctx, AccountStore accounts, LegacyPlayerStore legacy, BattleGrantStore grants) =>
{
    string? playerId = await BattlePlayerId(ctx, accounts, legacy);
    if (playerId == null) return Error(401, "unauthorized", "Authentication required.");
    var request = await Read(ctx, MatchGrantRequest.Parser);
    MatchConnectionGrant? grant;
    try { grant = await grants.GetForPlayer(request.MatchId, playerId, DateTimeOffset.UtcNow.ToUnixTimeSeconds(), ctx.RequestAborted); }
    catch (InvalidDataException) { return Error(400, "invalid_match_grant", "Match grant is invalid or expired."); }
    return grant == null ? Error(404, "match_grant_missing", "No match grant is assigned to this player.") : Proto(grant);
});
api.MapPost("/battle/queue/join", async (HttpContext ctx, AccountStore accounts, LegacyPlayerStore legacy,
    BattleAllocationStore allocations, BattlePlayerPresentationSource presentations, BattleMatchQueueStore queue,
    IServiceProvider services, BattleMatchProvisioner provisioner) =>
{
    string? playerId = await BattlePlayerId(ctx, accounts, legacy);
    if (playerId == null) return Error(401, "unauthorized", "Authentication required.");
    var request = await Read(ctx, MatchQueueRequest.Parser);
    if (request.CalculateSize() != 0) return Error(400, "invalid_matchmaking_request", "Matchmaking request must be empty.");
    if (matchmakingCompatibilityKey == null) return Error(503, "matchmaking_disabled", "Matchmaking policy is not configured.");
    try
    {
        if (await allocations.Get(playerId, ctx.RequestAborted) == null)
            return Error(409, "battle_allocation_missing", "A trusted battle allocation is required before matchmaking.");
    }
    catch (InvalidDataException) { return Error(409, "battle_allocation_invalid", "The trusted battle allocation is invalid."); }
    try { _ = await presentations.Get(playerId, ctx.RequestAborted); }
    catch (InvalidDataException) { return Error(409, "battle_presentation_invalid", "A complete durable player presentation is required before matchmaking."); }
    BattlePairingResult result;
    try { result = await queue.Join(playerId, matchmakingCompatibilityKey, DateTimeOffset.UtcNow, ctx.RequestAborted); }
    catch (InvalidDataException) { return Error(409, "matchmaking_conflict", "Player has incompatible matchmaking authority."); }
    if (result.Code == "paired" && result.MatchId != null && result.Players != null && services.GetService<BattleManifestFactory>() is { } factory)
    {
        try { await provisioner.Provision(await factory.Create(result.MatchId, result.Players, ctx.RequestAborted), ctx.RequestAborted); }
        catch (Exception e) when (e is InvalidDataException or HttpRequestException)
        { return Error(503, "match_provision_deferred", "Match is paired but provisioning must be retried."); }
    }
    var reply = new MatchQueueReply { Code = result.Code, MatchId = result.MatchId ?? "" };
    if (result.Players != null) reply.PlayerIds.Add(result.Players);
    return Proto(reply);
});
api.MapPost("/battle/queue/cancel", async (HttpContext ctx, AccountStore accounts, LegacyPlayerStore legacy, BattleMatchQueueStore queue) =>
{
    string? playerId = await BattlePlayerId(ctx, accounts, legacy);
    if (playerId == null) return Error(401, "unauthorized", "Authentication required.");
    var request = await Read(ctx, MatchQueueRequest.Parser);
    if (request.CalculateSize() != 0) return Error(400, "invalid_matchmaking_request", "Matchmaking request must be empty.");
    string code = await queue.Cancel(playerId, DateTimeOffset.UtcNow, ctx.RequestAborted);
    return Proto(new MatchQueueReply { Code = code });
});
app.MapPost("/internal/battle/matches/provision", async (HttpContext ctx, BattleMatchProvisioner provisioner) =>
{
    if (ctx.Request.ContentLength is > 65536) return Results.StatusCode(413);
    using var stream = new MemoryStream(); await ctx.Request.Body.CopyToAsync(stream, ctx.RequestAborted);
    byte[] body = stream.ToArray();
    if (body.Length is < 1 or > 65536) return Results.StatusCode(413);
    if (!AuthorizeBattleControl(ctx, body, battleControlKey, "war/match/provision/v1/")) return Results.Unauthorized();
    try
    {
        string code = await provisioner.Provision(body, ctx.RequestAborted);
        return Results.Json(new { code }, statusCode: code == "provisioned" ? 201 : 200);
    }
    catch (InvalidDataException) { return Results.BadRequest(new { code = "invalid-match-provision" }); }
    catch (HttpRequestException) { return Results.StatusCode(503); }
});
app.MapPost("/internal/battle/results/accept", async (HttpContext ctx, BattleResultStore store) =>
{
    if (ctx.Request.ContentLength is > 65536) return Results.StatusCode(404);
    using var stream = new MemoryStream(); await ctx.Request.Body.CopyToAsync(stream, ctx.RequestAborted);
    byte[] body = stream.ToArray();
    if (body.Length > 65536) return Results.StatusCode(413);
    if (!AuthorizeBattleControl(ctx, body, battleControlKey, "war/result/accept/v1/")) return Results.Unauthorized();
    try
    {
        using var json = JsonDocument.Parse(body); var root = json.RootElement;
        if (root.ValueKind != JsonValueKind.Object || root.EnumerateObject().Count() != 4 ||
            !root.TryGetProperty("serverId", out var host) || host.ValueKind != JsonValueKind.String || host.GetString() != serverId ||
            !root.TryGetProperty("matchId", out var match) || match.ValueKind != JsonValueKind.String ||
            !root.TryGetProperty("digest", out var digest) || digest.ValueKind != JsonValueKind.String ||
            !root.TryGetProperty("snapshot", out var snapshot) || snapshot.ValueKind != JsonValueKind.String)
            return Results.BadRequest(new { code = "invalid-result" });
        byte[] payload = Convert.FromBase64String(snapshot.GetString()!);
        string code = await store.Accept(match.GetString()!, digest.GetString()!, payload, ctx.RequestAborted);
        return code == "conflict" ? Results.Conflict(new { code }) : Results.Ok(new { code });
    }
    catch (Exception e) when (e is FormatException or JsonException or InvalidDataException)
    { return Results.BadRequest(new { code = "invalid-result" }); }
});
app.MapPost("/internal/battle/results/score", async (HttpContext ctx, BattleResultStore store) =>
{
    if (ctx.Request.ContentLength is > 2048) return Results.StatusCode(404);
    using var stream = new MemoryStream(); await ctx.Request.Body.CopyToAsync(stream, ctx.RequestAborted);
    byte[] body = stream.ToArray();
    if (!AuthorizeBattleControl(ctx, body, battleControlKey, "war/result/score/v1/")) return Results.Unauthorized();
    try
    {
        using var json = JsonDocument.Parse(body); var root = json.RootElement;
        if (root.ValueKind != JsonValueKind.Object || root.EnumerateObject().Count() != 3 ||
            !root.TryGetProperty("serverId", out var host) || host.ValueKind != JsonValueKind.String || host.GetString() != serverId ||
            !root.TryGetProperty("matchId", out var match) || match.ValueKind != JsonValueKind.String ||
            !root.TryGetProperty("digest", out var digest) || digest.ValueKind != JsonValueKind.String)
            return Results.BadRequest(new { code = "invalid-score" });
        string code = await store.ReconcileScored(match.GetString()!, digest.GetString()!, ctx.RequestAborted);
        return code switch
        {
            "scored" or "already-scored" => Results.Ok(new { code }),
            "missing" => Results.NotFound(new { code }),
            "conflict" => Results.Conflict(new { code }),
            _ => Results.BadRequest(new { code })
        };
    }
    catch (Exception e) when (e is JsonException or InvalidDataException)
    { return Results.BadRequest(new { code = "invalid-score" }); }
});
app.MapPost("/internal/battle/allocations/read", async (HttpContext ctx, BattleAllocationStore store) =>
{
    if (ctx.Request.ContentLength is > 2048) return Results.StatusCode(404);
    using var stream = new MemoryStream(); await ctx.Request.Body.CopyToAsync(stream, ctx.RequestAborted);
    byte[] body = stream.ToArray();
    if (body.Length > 2048) return Results.StatusCode(413);
    if (!AuthorizeBattleControl(ctx, body, battleControlKey, "war/allocation/read/v1/")) return Results.Unauthorized();
    try
    {
        using var json = JsonDocument.Parse(body); var root = json.RootElement;
        if (root.ValueKind != JsonValueKind.Object || root.EnumerateObject().Count() != 2 ||
            !root.TryGetProperty("serverId", out var host) || host.ValueKind != JsonValueKind.String || host.GetString() != serverId ||
            !root.TryGetProperty("playerIds", out var players) || players.ValueKind != JsonValueKind.Array || players.GetArrayLength() != 2)
            return Results.BadRequest(new { code = "invalid-allocation-read" });
        string[] ids = players.EnumerateArray().Select(x => x.ValueKind == JsonValueKind.String ? x.GetString()! : "").ToArray();
        var allocations = await store.GetMany(ids, ctx.RequestAborted);
        return Results.Json(allocations);
    }
    catch (Exception e) when (e is JsonException or InvalidDataException)
    { return Results.BadRequest(new { code = "invalid-allocation-read" }); }
});
app.Run();

static async Task<string?> BattlePlayerId(HttpContext context, AccountStore accounts, LegacyPlayerStore legacy)
{
    string header=context.Request.Headers.Authorization.ToString();
    string token=header.StartsWith("Bearer ",StringComparison.Ordinal)?header[7..]:"";
    var modern=await accounts.Authenticate(token,context.RequestAborted);
    if(modern!=null)return modern.PlayerId;
    var recovered=await legacy.AuthenticateToken(token,context.RequestAborted);
    return recovered?.Id;
}

static bool AuthorizeBattleControl(HttpContext context, byte[] body, byte[] key, string domain)
{
    string timestampText = context.Request.Headers["X-War-Control-Time"].ToString();
    string macText = context.Request.Headers["X-War-Control-Mac"].ToString();
    if (!long.TryParse(timestampText, System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture, out long timestamp) ||
        timestamp < 0 || timestamp > 253402300799 || Math.Abs(DateTimeOffset.UtcNow.ToUnixTimeSeconds() - timestamp) > 30 || macText.Length != 64) return false;
    byte[] supplied; try { supplied = Convert.FromHexString(macText); } catch (FormatException) { return false; }
    byte[] prefix = System.Text.Encoding.UTF8.GetBytes(domain + timestampText + "\n");
    byte[] payload = new byte[prefix.Length + body.Length]; prefix.CopyTo(payload, 0); body.CopyTo(payload, prefix.Length);
    return System.Security.Cryptography.CryptographicOperations.FixedTimeEquals(System.Security.Cryptography.HMACSHA256.HashData(key, payload), supplied);
}
