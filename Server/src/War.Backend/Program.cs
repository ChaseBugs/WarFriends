using System.Security.Cryptography;
using System.Threading.RateLimiting;
using Google.Protobuf;
using Microsoft.AspNetCore.RateLimiting;
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
builder.Services.AddSingleton(new LegacyPlayerStore(mongoUri, mongoDatabase));
builder.Services.AddSingleton(new LegacyBufferStore(mongoUri, mongoDatabase));
builder.Services.AddSingleton<LegacyBufferProcessor>();
var starter = new LegacyStarterState();
builder.Configuration.GetSection("Legacy:Starter").Bind(starter);
builder.Services.AddSingleton(starter);
builder.Services.AddSingleton(new BattleTickets(builder.Configuration["Battle:SigningKey"] ?? throw new InvalidOperationException("Set Battle__SigningKey to a base64 32-byte random secret in BOTH processes.")));
string serverId = builder.Configuration["Battle:ServerId"] ?? "local-1";
string publicHost = builder.Configuration["Battle:PublicHost"] ?? "127.0.0.1";
int battlePort = int.Parse(builder.Configuration["Battle:Port"] ?? "30000", System.Globalization.CultureInfo.InvariantCulture);
if (battlePort is < 1 or > 65535 || !System.Text.RegularExpressions.Regex.IsMatch(serverId, @"\A[a-zA-Z0-9-]{1,64}\z") || Uri.CheckHostName(publicHost) == UriHostNameType.Unknown) throw new InvalidOperationException("Invalid battle endpoint configuration.");
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = 429;
    options.AddPolicy("api", context => RateLimitPartition.GetFixedWindowLimiter(context.Connection.RemoteIpAddress?.ToString() ?? "unknown", _ => new FixedWindowRateLimiterOptions { PermitLimit = 120, Window = TimeSpan.FromMinutes(1), QueueLimit = 0 }));
    options.AddPolicy("auth", context => RateLimitPartition.GetFixedWindowLimiter(context.Connection.RemoteIpAddress?.ToString() ?? "unknown", _ => new FixedWindowRateLimiterOptions { PermitLimit = 10, Window = TimeSpan.FromMinutes(1), QueueLimit = 0 }));
});
// The 1.4.0 client's own request builder decides the scheme (BeanstalkUrlCreator uses https for a
// Production build), so a plain-HTTP legacy deployment is an explicit operator choice, not a
// default. It stays off unless Legacy__AllowInsecureHttp is set.
bool legacyAllowsInsecureHttp = builder.Configuration.GetValue("Legacy:AllowInsecureHttp", false);
var app = builder.Build();
await app.Services.GetRequiredService<AccountStore>().Initialize(app.Lifetime.ApplicationStopping);
await app.Services.GetRequiredService<LegacyPlayerStore>().Initialize(app.Lifetime.ApplicationStopping);
await app.Services.GetRequiredService<LegacyBufferStore>().Initialize(app.Lifetime.ApplicationStopping);
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
app.MapLegacy(app.Services.GetRequiredService<LegacyPlayerStore>(), app.Services.GetRequiredService<LegacyBufferProcessor>(), starter);
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
app.Run();
