using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Google.Protobuf;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using War.BattleServer;

var builder=WebApplication.CreateBuilder(args);
int udpPort=int.Parse(builder.Configuration["Battle:Port"]??"30000",CultureInfo.InvariantCulture);
int controlPort=int.Parse(builder.Configuration["Battle:ControlPort"]??
    (udpPort+1).ToString(CultureInfo.InvariantCulture),CultureInfo.InvariantCulture);
int maxMatches=int.Parse(builder.Configuration["Battle:MaxMatches"]??"32",CultureInfo.InvariantCulture);
int tickRate=int.Parse(builder.Configuration["Battle:TickRate"]??"30",CultureInfo.InvariantCulture);
int mtuBytes=int.Parse(builder.Configuration["Battle:MtuBytes"]??"1200",CultureInfo.InvariantCulture);
if(udpPort is <1 or >65534 || controlPort is <1 or >65535 || controlPort==udpPort)
    throw new InvalidOperationException("Invalid battle or control port.");
var runtimeConfig=BattleRuntimeConfigValidator.ValidateAndFreeze(new BattleRuntimeConfig(udpPort,maxMatches,tickRate,mtuBytes));
if(tickRate!=30)throw new InvalidOperationException("Battle TickRate must match the fixed simulation rate of 30.");
byte[] signingKey=Convert.FromBase64String(builder.Configuration["Battle:SigningKey"]??
    throw new InvalidOperationException("Set Battle__SigningKey."));
if(signingKey.Length!=32)throw new InvalidOperationException("Battle signing key must be 32 bytes.");
TransportSecurityPolicy.ValidateSigningKey(signingKey);
byte[] controlKey=Convert.FromBase64String(builder.Configuration["Battle:ControlKey"]??
    throw new InvalidOperationException("Set Battle__ControlKey separately from Battle__SigningKey."));
try {controlKey=BattleControlKeyPolicy.ValidateAndCopy(controlKey,signingKey);}
catch(InvalidDataException e){throw new InvalidOperationException(e.Message,e);}
builder.WebHost.ConfigureKestrel(options=>
{
    options.ListenLocalhost(controlPort);
    options.Limits.MaxRequestBodySize=65536;
});
builder.Services.AddSingleton<NetworkWorker>();
builder.Services.AddSingleton(runtimeConfig);
builder.Services.AddHostedService(services=>services.GetRequiredService<NetworkWorker>());
var app=builder.Build();
app.MapGet("/health/live",()=>Results.Ok(new {status="alive"}));
app.MapGet("/health/ready",(NetworkWorker worker)=>worker.IsReady
    ?Results.Ok(new {status="ready"}):Results.StatusCode(503));
app.MapGet("/health/metrics",(NetworkWorker worker)=>Results.Ok(worker.Metrics));
app.MapPost("/internal/matches",async (HttpContext context,NetworkWorker worker)=>
{
    if(context.Request.ContentLength is >65536)
        return Results.StatusCode(413);
    using var stream=new MemoryStream();
    await context.Request.Body.CopyToAsync(stream,context.RequestAborted);
    byte[] body=stream.ToArray();
    if(body.Length>65536)return Results.StatusCode(413);
    if(!Authorized(context,body,controlKey,"war/match/control/v1/"))
        return Results.Unauthorized();
    MatchManifest manifest;
    try { manifest=MatchManifest.Parse(body); }
    catch(InvalidDataException){return Results.BadRequest(new {code="invalid-manifest"});}
    var result=await worker.RegisterMatch(manifest,context.RequestAborted);
    object[] grants=result.Grants?.Select(grant=>(object)new {host=grant.Host,port=grant.Port,
        ticket=grant.Ticket,sessionKey=Convert.ToBase64String(grant.SessionKey.ToByteArray()),
        sessionId=grant.SessionId,matchId=grant.MatchId,playerId=grant.PlayerId,
        manifestHash=grant.ManifestHash,expiresUnixSeconds=grant.ExpiresUnixSeconds}).ToArray()??[];
    return result.Code switch
    {
        "registered" or "existing-match"=>Results.Json(new {code=result.Code,matchId=manifest.MatchId,
            manifestHash=result.ManifestHash,grants},statusCode:result.Code=="registered"?201:200),
        "duplicate-match" or "admission-expired" or "terminal-match-id" or "match-terminal"=>Results.Conflict(new {code=result.Code}),
        "match-capacity" or "control-capacity" or "control-unavailable"=>Results.Json(new {code=result.Code},statusCode:503),
        _=>Results.BadRequest(new {code=result.Code})
    };
});
app.MapPost("/internal/matches/reconnect",async (HttpContext context,NetworkWorker worker)=>
{
    if(context.Request.ContentLength is >1024)return Results.StatusCode(413);
    using var stream=new MemoryStream();
    await context.Request.Body.CopyToAsync(stream,context.RequestAborted);
    byte[] body=stream.ToArray();
    if(body.Length>1024)return Results.StatusCode(413);
    if(!Authorized(context,body,controlKey,"war/match/control/v1/"))return Results.Unauthorized();
    string matchId,playerId,requestId;
    try
    {
        using var doc=JsonDocument.Parse(body);
        var root=doc.RootElement;
        if(root.ValueKind!=JsonValueKind.Object || root.EnumerateObject().Count()!=3 ||
           !root.TryGetProperty("matchId",out var match) || match.ValueKind!=JsonValueKind.String ||
           !root.TryGetProperty("playerId",out var player) || player.ValueKind!=JsonValueKind.String ||
           !root.TryGetProperty("requestId",out var request) || request.ValueKind!=JsonValueKind.String)
            return Results.BadRequest(new {code="invalid-reconnect"});
        matchId=match.GetString()!;playerId=player.GetString()!;requestId=request.GetString()!;
        if(matchId.Length is <1 or >64 || playerId.Length!=32 ||
           !Guid.TryParseExact(requestId,"N",out _) || requestId!=requestId.ToLowerInvariant())
            return Results.BadRequest(new {code="invalid-reconnect"});
    }
    catch(JsonException){return Results.BadRequest(new {code="invalid-reconnect"});}
    var result=await worker.RegisterReconnect(matchId,playerId,requestId,context.RequestAborted);
    if(result.Code is "control-capacity" or "control-unavailable")return Results.Json(new {code=result.Code},statusCode:503);
    if(result.Code is not ("reconnect-issued" or "reconnect-existing"))return Results.Conflict(new {code=result.Code});
    var grant=result.Grants!.Single();
    return Results.Ok(new {code=result.Code,grant=new {host=grant.Host,port=grant.Port,
        ticket=grant.Ticket,sessionKey=Convert.ToBase64String(grant.SessionKey.ToByteArray()),
        sessionId=grant.SessionId,matchId=grant.MatchId,playerId=grant.PlayerId,
        manifestHash=grant.ManifestHash,expiresUnixSeconds=grant.ExpiresUnixSeconds}});
});
app.MapPost("/internal/matches/cancel",async (HttpContext context,NetworkWorker worker)=>
{
    if(context.Request.ContentLength is >256)return Results.StatusCode(413);
    using var stream=new MemoryStream();
    await context.Request.Body.CopyToAsync(stream,context.RequestAborted);
    byte[] body=stream.ToArray();
    if(body.Length>256)return Results.StatusCode(413);
    if(!Authorized(context,body,controlKey,"war/match/control/v1/"))return Results.Unauthorized();
    string matchId;
    try
    {
        using var doc=JsonDocument.Parse(body);
        var root=doc.RootElement;
        if(root.ValueKind!=JsonValueKind.Object || root.EnumerateObject().Count()!=1 ||
           !root.TryGetProperty("matchId",out var match) || match.ValueKind!=JsonValueKind.String)
            return Results.BadRequest(new {code="invalid-cancel"});
        matchId=match.GetString()!;
        if(matchId.Length is <1 or >64 || !matchId.All(c=>char.IsAsciiLetterOrDigit(c) || c is '_' or '-'))
            return Results.BadRequest(new {code="invalid-cancel"});
    }
    catch(JsonException){return Results.BadRequest(new {code="invalid-cancel"});}
    var result=await worker.CancelMatchBeforeStart(matchId,context.RequestAborted);
    return result.Code switch
    {
        "cancelled-before-start" or "already-cancelled"=>Results.Ok(new {code=result.Code,matchId,manifestHash=result.ManifestHash}),
        "control-capacity" or "control-unavailable"=>Results.Json(new {code=result.Code},statusCode:503),
        _=>Results.Conflict(new {code=result.Code})
    };
});
app.MapPost("/internal/results/poll",async (HttpContext context,NetworkWorker worker)=>
{
    if(context.Request.ContentLength is >16)return Results.StatusCode(413);
    using var stream=new MemoryStream();
    await context.Request.Body.CopyToAsync(stream,context.RequestAborted);
    byte[] body=stream.ToArray();
    if(body.Length>16)return Results.StatusCode(413);
    if(!Authorized(context,body,controlKey,"war/result/poll/v1/"))return Results.Unauthorized();
    if(!body.AsSpan().SequenceEqual("{}"u8))return Results.BadRequest(new {code="invalid-result-poll"});
    var rows=worker.Outbox.PendingPage().Select(e=>new {matchId=e.Snapshot.MatchId,
        digest=e.Digest,snapshot=Convert.ToBase64String(e.Snapshot.ToByteArray())}).ToArray();
    return Results.Ok(new {results=rows});
});
app.MapPost("/internal/results/ack",async (HttpContext context,NetworkWorker worker)=>
{
    if(context.Request.ContentLength is >256)return Results.StatusCode(413);
    using var stream=new MemoryStream();
    await context.Request.Body.CopyToAsync(stream,context.RequestAborted);
    byte[] body=stream.ToArray();
    if(body.Length>256)return Results.StatusCode(413);
    if(!Authorized(context,body,controlKey,"war/result/ack/v1/"))return Results.Unauthorized();
    string matchId,digest;
    try
    {
        using var doc=JsonDocument.Parse(body);
        var root=doc.RootElement;
        if(root.ValueKind!=JsonValueKind.Object || root.EnumerateObject().Count()!=2 ||
           !root.TryGetProperty("matchId",out var match) || match.ValueKind!=JsonValueKind.String ||
           !root.TryGetProperty("digest",out var hash) || hash.ValueKind!=JsonValueKind.String)
            return Results.BadRequest(new {code="invalid-result-ack"});
        matchId=match.GetString()!;digest=hash.GetString()!;
    }
    catch(JsonException){return Results.BadRequest(new {code="invalid-result-ack"});}
    string code;
    try {code=worker.Outbox.Acknowledge(matchId,digest);}
    catch(ArgumentException){return Results.BadRequest(new {code="invalid-result-ack"});}
    return code switch
    {
        "acknowledged" or "already-acknowledged"=>Results.Ok(new {code}),
        "missing"=>Results.NotFound(new {code}),
        _=>Results.Conflict(new {code})
    };
});
await app.RunAsync();

static bool Authorized(HttpContext context,byte[] body,byte[] key,string domain)
{
    string timestampText=context.Request.Headers["X-War-Control-Time"].ToString();
    string macText=context.Request.Headers["X-War-Control-Mac"].ToString();
    if(!long.TryParse(timestampText,NumberStyles.None,CultureInfo.InvariantCulture,out long timestamp) ||
       timestamp is <0 or >253402300799 ||
       Math.Abs(DateTimeOffset.UtcNow.ToUnixTimeSeconds()-timestamp)>30 || macText.Length!=64)
        return false;
    byte[] supplied;
    try {supplied=Convert.FromHexString(macText);}
    catch(FormatException){return false;}
    byte[] prefix=Encoding.UTF8.GetBytes(domain+timestampText+"\n");
    byte[] payload=new byte[prefix.Length+body.Length];
    prefix.CopyTo(payload,0);body.CopyTo(payload,prefix.Length);
    return CryptographicOperations.FixedTimeEquals(HMACSHA256.HashData(key,payload),supplied);
}
