using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Globalization;
using Google.Protobuf;
using War.Infrastructure;
using War.Protocol;
using War.Protocol.Transport;
using War.Client;

using var http = new HttpClient { BaseAddress = new Uri(args.Length > 0 ? args[0] : "http://127.0.0.1:8080"), Timeout = TimeSpan.FromSeconds(10) };
int checks = 0;
void Check(bool ok, string name) { if (!ok) throw new Exception(name); checks++; }
async Task<HttpResponseMessage> Post(string path, IMessage body, string? token = null)
{
    using var request = new HttpRequestMessage(HttpMethod.Post, path);
    request.Content = new ByteArrayContent(body.ToByteArray());
    request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-protobuf");
    if (token != null) request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    return await http.SendAsync(request);
}
var grants = new List<ConnectionGrant>();
var accounts = new List<AccountSession>();
for (int i = 0; i < 2; i++)
{
    string username = "probe_" + Guid.NewGuid().ToString("N")[..12];
    string password = Guid.NewGuid().ToString("N") + "_test";
    var registration = new RegisterRequest { Username = username, Password = password, Locale = "en" };
    using var response = await Post("/v1/accounts/register", registration);
    Check(response.IsSuccessStatusCode, "registration");
    var original = AccountSession.Parser.ParseFrom(await response.Content.ReadAsByteArrayAsync());
    using var duplicate = await Post("/v1/accounts/register", registration);
    Check(duplicate.StatusCode == HttpStatusCode.Conflict, "duplicate username");
    using var rejected = await Post("/v1/accounts/login", new LoginRequest { Username = username, Password = "incorrect_password" });
    Check(rejected.StatusCode == HttpStatusCode.Unauthorized, "incorrect password");
    using var login = await Post("/v1/accounts/login", new LoginRequest { Username = username, Password = password });
    Check(login.IsSuccessStatusCode, "login");
    var session = AccountSession.Parser.ParseFrom(await login.Content.ReadAsByteArrayAsync());
    accounts.Add(session);
    Check(session.Player.PlayerId == original.Player.PlayerId, "persistent account identity");
    using var stale = new HttpRequestMessage(HttpMethod.Get, "/v1/player");
    stale.Headers.Authorization = new AuthenticationHeaderValue("Bearer", original.AccessToken);
    using var staleResponse = await http.SendAsync(stale);
    Check(staleResponse.StatusCode == HttpStatusCode.Unauthorized, "old session invalidated");
    using var get = new HttpRequestMessage(HttpMethod.Get, "/v1/player");
    get.Headers.Authorization = new AuthenticationHeaderValue("Bearer", session.AccessToken);
    using var profileResponse = await http.SendAsync(get);
    Check(profileResponse.IsSuccessStatusCode, "authenticated profile");
    var profile = PlayerProfile.Parser.ParseFrom(await profileResponse.Content.ReadAsByteArrayAsync());
    Check(profile.DisplayName == username && profile.Locale == "en", "profile persistence");
    using (var sdk = new BackendClient(http.BaseAddress!, allowLocalHttp: true))
    {
        Check((await sdk.PlayerAsync(session.AccessToken, CancellationToken.None)).PlayerId == profile.PlayerId, "portable SDK profile");
        var sdkGrant = await sdk.ConnectAsync(session.AccessToken, CancellationToken.None);
        using (var connection = new BattleConnection(sdkGrant))
        {
            Check((await connection.HelloAsync(CancellationToken.None)).TickRate == 30, "portable SDK hello");
            Check((await connection.PingAsync(99, CancellationToken.None)).ClientTime == 99, "portable SDK ping");
        }
    }
    using var grantResponse = await Post("/v1/network/connect", new ConnectionRequest { Protocol = "war.v1" }, session.AccessToken);
    Check(grantResponse.IsSuccessStatusCode, "connection ticket");
    grants.Add(ConnectionGrant.Parser.ParseFrom(await grantResponse.Content.ReadAsByteArrayAsync()));
}
using (var unauthorized = await http.GetAsync("/v1/player")) Check(unauthorized.StatusCode == HttpStatusCode.Unauthorized, "anonymous profile denied");
using (var invalid = await http.PostAsync("/v1/accounts/register", new StringContent("{}"))) Check((int)invalid.StatusCode == 415, "content type boundary");
using (var invalid = await Post("/v1/accounts/register", new RegisterRequest { Username="padded\n", Password="long_enough_password", Locale="en" })) Check((int)invalid.StatusCode==400,"noncanonical account name rejected");
Check(grants[0].SessionId != grants[1].SessionId, "distinct sessions");
foreach (var grant in grants)
{
    using var udp = new UdpClient();
    udp.Connect(grant.Host, (int)grant.Port);
    byte[] key = grant.SessionKey.ToByteArray();
    var hello = new Packet { Version = 1, SessionId = grant.SessionId, Sequence = 1, Hello = new ClientHello { Ticket = grant.Ticket } };
    var paddedHello=hello.Clone();
    paddedHello.Hello.MergeFrom(new byte[]{16,1});
    await udp.SendAsync(PacketCodec.Encode(paddedHello,key));
    Check(await IsSilent(udp),"unknown hello field cannot reserve a probe session");
    byte[] bytes = PacketCodec.Encode(hello, key);
    var welcome = await Exchange(udp, bytes);
    Check(PacketCodec.Authenticate(welcome, key), "server packet authentication");
    Check(PacketCodec.ReadUntrusted(welcome)?.Welcome.TickRate == 30, "UDP handshake");
    var retry = await Exchange(udp, bytes);
    Check(PacketCodec.ReadUntrusted(retry)?.Welcome != null, "idempotent hello retry");
    using (var otherEndpoint = new UdpClient())
    {
        otherEndpoint.Connect(grant.Host, (int)grant.Port);
        await otherEndpoint.SendAsync(bytes);
        Check(await IsSilent(otherEndpoint), "ticket endpoint binding");
    }
    var ping = new Packet { Version = 1, SessionId = grant.SessionId, Sequence = 2, Ping = new Ping { ClientTime = 1234 } };
    var paddedPing=ping.Clone();
    paddedPing.Ping.MergeFrom(new byte[]{16,1});
    await udp.SendAsync(PacketCodec.Encode(paddedPing,key));
    Check(await IsSilent(udp),"unknown ping field cannot consume probe sequence");
    byte[] pingBytes = PacketCodec.Encode(ping, key);
    var pong = await Exchange(udp, pingBytes);
    Check(PacketCodec.Authenticate(pong, key) && PacketCodec.ReadUntrusted(pong)?.Pong.ClientTime == 1234, "authenticated ping/pong");
    await udp.SendAsync(pingBytes);
    Check(await IsSilent(udp), "duplicate ping rejected");
    ping.Sequence = 3; byte[] tampered = PacketCodec.Encode(ping, key); tampered[^1] ^= 1;
    await udp.SendAsync(tampered);
    Check(await IsSilent(udp), "invalid MAC rejected");
    var paddedDisconnect=new Packet {Version=1,SessionId=grant.SessionId,Sequence=4,
        Disconnect=new Disconnect {Reason="probe complete"}};
    paddedDisconnect.Disconnect.MergeFrom(new byte[]{16,1});
    await udp.SendAsync(PacketCodec.Encode(paddedDisconnect,key));
    Check(await IsSilent(udp),"unknown disconnect field cannot close probe session");
    ping.Sequence=4;
    Check(PacketCodec.ReadUntrusted(await Exchange(udp,PacketCodec.Encode(ping,key)))?.Pong.ClientTime==1234,
        "valid sequence remains usable after malformed disconnect");
    ping.Sequence = 5; ping.Disconnect = new Disconnect { Reason = "probe complete" };
    await udp.SendAsync(PacketCodec.Encode(ping, key));
    await Task.Delay(100);
    await udp.SendAsync(bytes);
    Check(await IsSilent(udp), "closed ticket cannot reopen session");
}
string? signingText=Environment.GetEnvironmentVariable("Battle__SigningKey");
string? controlPortText=Environment.GetEnvironmentVariable("Battle__ControlPort");
string? udpPortText=Environment.GetEnvironmentVariable("Battle__Port");
if(signingText!=null && controlPortText!=null && udpPortText!=null)
{
    byte[] signingKey=Convert.FromBase64String(signingText);
    int controlPort=int.Parse(controlPortText,CultureInfo.InvariantCulture);
    int udpPort=int.Parse(udpPortText,CultureInfo.InvariantCulture);
    string matchId="smoke-allocated-"+Guid.NewGuid().ToString("N")[..8];
    var manifest=new
    {
        MatchId=matchId,ServerId="local-1",MapId="fixture-map",
        MapRevision=new string('a',64),CatalogRevision=new string('b',64),
        Mode="unscored-weapon-prototype",AdmissionSeconds=10,DurationSeconds=60,IdleSeconds=10,
        Players=accounts.Select(account=>new
        {
            PlayerId=account.Player.PlayerId,
            Weapon=new {SourceId="fixture-rifle",ClipSize=2,ReserveAmmo=3,
                CadenceSeconds=0.1,ReloadSeconds=0.2}
        }).ToArray()
    };
    byte[] body=JsonSerializer.SerializeToUtf8Bytes(manifest);
    long now=DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    string timestamp=now.ToString(CultureInfo.InvariantCulture);
    using var control=new HttpClient {BaseAddress=new Uri($"http://127.0.0.1:{controlPort}")};
    using var request=new HttpRequestMessage(HttpMethod.Post,"/internal/matches");
    request.Content=new ByteArrayContent(body);
    request.Content.Headers.ContentType=new MediaTypeHeaderValue("application/json");
    request.Headers.Add("X-War-Control-Time",timestamp);
    request.Headers.Add("X-War-Control-Mac",Convert.ToHexString(Mac(signingKey,
        "war/match/control/v1/",Encoding.UTF8.GetBytes(timestamp+"\n").Concat(body).ToArray())));
    using var allocated=await control.SendAsync(request);
    Check(allocated.StatusCode==HttpStatusCode.Created,"live worker accepted account-bound runtime match");
    using var receipt=JsonDocument.Parse(await allocated.Content.ReadAsByteArrayAsync());
    string manifestHash=receipt.RootElement.GetProperty("manifestHash").GetString()??"";
    Check(receipt.RootElement.GetProperty("matchId").GetString()==matchId && manifestHash.Length==64,
        "runtime allocation returned its host-computed manifest binding");
    var grantRows=receipt.RootElement.GetProperty("grants").EnumerateArray().ToArray();
    Check(grantRows.Length==2,"runtime allocation returns exactly two player grants");
    var matchGrants=new List<MatchConnectionGrant>();
    for(int i=0;i<grantRows.Length;i++)
    {
        var row=grantRows[i];
        var grant=new MatchConnectionGrant {Host=row.GetProperty("host").GetString()??"",
            Port=row.GetProperty("port").GetUInt32(),Ticket=row.GetProperty("ticket").GetString()??"",
            SessionKey=ByteString.CopyFrom(Convert.FromBase64String(row.GetProperty("sessionKey").GetString()??"")),
            SessionId=row.GetProperty("sessionId").GetUInt64(),MatchId=row.GetProperty("matchId").GetString()??"",
            PlayerId=row.GetProperty("playerId").GetString()??"",ManifestHash=row.GetProperty("manifestHash").GetString()??"",
            ExpiresUnixSeconds=row.GetProperty("expiresUnixSeconds").GetInt64()};
        Check(grant.Host=="127.0.0.1" && grant.Port==udpPort && grant.SessionId!=0 &&
              grant.SessionKey.Length==32 && grant.Ticket.Length>0 && grant.MatchId==matchId &&
              grant.PlayerId==accounts[i].Player.PlayerId && grant.ManifestHash==manifestHash &&
              grant.ExpiresUnixSeconds>now,"host-issued grant binds endpoint, player, match, and key");
        matchGrants.Add(grant);
    }
    Check(matchGrants[0].SessionId!=matchGrants[1].SessionId,"host-issued sessions are distinct");
    using var first=new MatchConnection(matchGrants[0]);
    using var second=new MatchConnection(matchGrants[1]);
    Check((await first.ConnectAsync(CancellationToken.None)).Code=="admitted" &&
          (await second.ConnectAsync(CancellationToken.None)).Code=="admitted",
          "both real UDP peers admitted to late-registered match");
    string firstReconnectId=Guid.NewGuid().ToString("N");
    byte[] reconnectBody=JsonSerializer.SerializeToUtf8Bytes(new
        {matchId,playerId=accounts[0].Player.PlayerId,requestId=firstReconnectId});
    using var reconnectRequest=new HttpRequestMessage(HttpMethod.Post,"/internal/matches/reconnect");
    reconnectRequest.Content=new ByteArrayContent(reconnectBody);
    reconnectRequest.Content.Headers.ContentType=new MediaTypeHeaderValue("application/json");
    reconnectRequest.Headers.Add("X-War-Control-Time",timestamp);
    reconnectRequest.Headers.Add("X-War-Control-Mac",Convert.ToHexString(Mac(signingKey,
        "war/match/control/v1/",Encoding.UTF8.GetBytes(timestamp+"\n").Concat(reconnectBody).ToArray())));
    using var reconnectResponse=await control.SendAsync(reconnectRequest);
    Check(reconnectResponse.StatusCode==HttpStatusCode.OK,"authenticated reconnect grant issued");
    using var reconnectReceipt=JsonDocument.Parse(await reconnectResponse.Content.ReadAsByteArrayAsync());
    var reconnectRow=reconnectReceipt.RootElement.GetProperty("grant");
    var reconnectGrant=new MatchConnectionGrant {Host=reconnectRow.GetProperty("host").GetString()??"",
        Port=reconnectRow.GetProperty("port").GetUInt32(),Ticket=reconnectRow.GetProperty("ticket").GetString()??"",
        SessionKey=ByteString.CopyFrom(Convert.FromBase64String(reconnectRow.GetProperty("sessionKey").GetString()??"")),
        SessionId=reconnectRow.GetProperty("sessionId").GetUInt64(),MatchId=reconnectRow.GetProperty("matchId").GetString()??"",
        PlayerId=reconnectRow.GetProperty("playerId").GetString()??"",ManifestHash=reconnectRow.GetProperty("manifestHash").GetString()??"",
        ExpiresUnixSeconds=reconnectRow.GetProperty("expiresUnixSeconds").GetInt64()};
    using var retryRequest=new HttpRequestMessage(HttpMethod.Post,"/internal/matches/reconnect");
    retryRequest.Content=new ByteArrayContent(reconnectBody);
    retryRequest.Content.Headers.ContentType=new MediaTypeHeaderValue("application/json");
    retryRequest.Headers.Add("X-War-Control-Time",timestamp);
    retryRequest.Headers.Add("X-War-Control-Mac",Convert.ToHexString(Mac(signingKey,
        "war/match/control/v1/",Encoding.UTF8.GetBytes(timestamp+"\n").Concat(reconnectBody).ToArray())));
    using var retryResponse=await control.SendAsync(retryRequest);
    using var retryReceipt=JsonDocument.Parse(await retryResponse.Content.ReadAsByteArrayAsync());
    Check(retryResponse.StatusCode==HttpStatusCode.OK &&
          retryReceipt.RootElement.GetProperty("code").GetString()=="reconnect-existing" &&
          retryReceipt.RootElement.GetProperty("grant").GetProperty("ticket").GetString()==reconnectGrant.Ticket,
          "lost reconnect response retries without minting another generation");
    Check(reconnectGrant.SessionId!=matchGrants[0].SessionId && reconnectGrant.PlayerId==accounts[0].Player.PlayerId,
        "reconnect rotates the player session identity");
    using var reconnected=new MatchConnection(reconnectGrant);
    Check((await reconnected.ConnectAsync(CancellationToken.None)).Code=="admitted",
        "higher-generation grant resumes the live match");
    bool oldRevoked=false;
    try {await first.PollAsync(CancellationToken.None);}
    catch(TimeoutException){oldRevoked=true;}
    Check(oldRevoked,"reconnect revokes the previous player key and endpoint");
    Check((await reconnected.ReadyAsync(CancellationToken.None)).Code=="ready" &&
          (await second.ReadyAsync(CancellationToken.None)).Snapshot.Phase==BattlePhase.Countdown,
          "late-registered match retains two-player ready barrier");
    MatchReply state;
    do {await Task.Delay(100);state=await reconnected.PollAsync(CancellationToken.None);}
    while(state.Snapshot.Phase==BattlePhase.Countdown);
    Check(state.Snapshot.Phase==BattlePhase.Running,"late-registered match reaches running phase");
    var idleWatch=System.Diagnostics.Stopwatch.StartNew();
    MatchReply paused;
    do
    {
        await Task.Delay(250);
        paused=await reconnected.PollAsync(CancellationToken.None);
    }
    while(!paused.Snapshot.Players[1].Reconnecting && idleWatch.Elapsed<TimeSpan.FromSeconds(15));
    Check(paused.Snapshot.Players[1].Reconnecting && paused.Snapshot.Players[1].ReconnectAttempts==1 &&
          paused.Snapshot.PauseHostTick>0 && paused.Snapshot.Phase==BattlePhase.Running,
          "live idle peer enters source first reconnect grace without ending match");
    await Task.Delay(200);
    var stillPaused=await reconnected.PollAsync(CancellationToken.None);
    Check(stillPaused.Snapshot.ServerTick==paused.Snapshot.ServerTick &&
          stillPaused.Snapshot.PauseHostTick>paused.Snapshot.PauseHostTick,
          "live simulation tick freezes while reconnect wall clock advances");
    byte[] secondReconnectBody=JsonSerializer.SerializeToUtf8Bytes(new
        {matchId,playerId=accounts[1].Player.PlayerId,requestId=Guid.NewGuid().ToString("N")});
    string secondStamp=DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);
    using var secondReconnectRequest=new HttpRequestMessage(HttpMethod.Post,"/internal/matches/reconnect");
    secondReconnectRequest.Content=new ByteArrayContent(secondReconnectBody);
    secondReconnectRequest.Content.Headers.ContentType=new MediaTypeHeaderValue("application/json");
    secondReconnectRequest.Headers.Add("X-War-Control-Time",secondStamp);
    secondReconnectRequest.Headers.Add("X-War-Control-Mac",Convert.ToHexString(Mac(signingKey,
        "war/match/control/v1/",Encoding.UTF8.GetBytes(secondStamp+"\n").Concat(secondReconnectBody).ToArray())));
    using var secondReconnectResponse=await control.SendAsync(secondReconnectRequest);
    Check(secondReconnectResponse.StatusCode==HttpStatusCode.OK,"live idle player receives trusted reconnect grant");
    using var secondReconnectReceipt=JsonDocument.Parse(await secondReconnectResponse.Content.ReadAsByteArrayAsync());
    var secondRow=secondReconnectReceipt.RootElement.GetProperty("grant");
    var secondGrant=new MatchConnectionGrant {Host=secondRow.GetProperty("host").GetString()??"",
        Port=secondRow.GetProperty("port").GetUInt32(),Ticket=secondRow.GetProperty("ticket").GetString()??"",
        SessionKey=ByteString.CopyFrom(Convert.FromBase64String(secondRow.GetProperty("sessionKey").GetString()??"")),
        SessionId=secondRow.GetProperty("sessionId").GetUInt64(),MatchId=secondRow.GetProperty("matchId").GetString()??"",
        PlayerId=secondRow.GetProperty("playerId").GetString()??"",ManifestHash=secondRow.GetProperty("manifestHash").GetString()??"",
        ExpiresUnixSeconds=secondRow.GetProperty("expiresUnixSeconds").GetInt64()};
    using var resumedSecond=new MatchConnection(secondGrant);
    var resumedState=await resumedSecond.ConnectAsync(CancellationToken.None);
    Check(resumedState.Snapshot.Players[1].Reconnecting==false &&
          resumedState.Snapshot.Players[1].ReconnectAttempts==1 &&
          resumedState.Snapshot.Phase==BattlePhase.Running,
          "live higher-generation peer resumes paused running match");
    bool staleSecondRevoked=false;
    try {await second.PollAsync(CancellationToken.None);}
    catch(TimeoutException){staleSecondRevoked=true;}
    Check(staleSecondRevoked,"paused reconnect revokes the old second-player session");
    var terminal=await resumedSecond.ForfeitAsync(CancellationToken.None);
    Check(terminal.Snapshot.WinnerPlayerId==accounts[0].Player.PlayerId,
        "late-registered live match resolves host-authenticated terminal result");
    string resultStamp=DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(CultureInfo.InvariantCulture);
    byte[] pollBody="{}"u8.ToArray();
    using var pollRequest=new HttpRequestMessage(HttpMethod.Post,"/internal/results/poll");
    pollRequest.Content=new ByteArrayContent(pollBody);
    pollRequest.Content.Headers.ContentType=new MediaTypeHeaderValue("application/json");
    pollRequest.Headers.Add("X-War-Control-Time",resultStamp);
    pollRequest.Headers.Add("X-War-Control-Mac",Convert.ToHexString(Mac(signingKey,
        "war/result/poll/v1/",Encoding.UTF8.GetBytes(resultStamp+"\n").Concat(pollBody).ToArray())));
    using var resultResponse=await control.SendAsync(pollRequest);
    Check(resultResponse.IsSuccessStatusCode,"battle host exposes authenticated terminal evidence");
    using var resultPage=JsonDocument.Parse(await resultResponse.Content.ReadAsByteArrayAsync());
    var resultRow=resultPage.RootElement.GetProperty("results").EnumerateArray()
        .Single(row=>row.GetProperty("matchId").GetString()==matchId);
    var durable=MatchSnapshot.Parser.ParseFrom(Convert.FromBase64String(resultRow.GetProperty("snapshot").GetString()??""));
    Check(durable.ToByteArray().AsSpan().SequenceEqual(terminal.Snapshot.ToByteArray()) &&
          !durable.RewardEligible && resultRow.GetProperty("digest").GetString()?.Length==64,
          "durable terminal snapshot exactly matches the acknowledged UDP result");
}
Console.WriteLine($"PASS: {checks} live MongoDB/HTTP/protobuf/UDP checks; two independent clients; no Photon.");

static byte[] Mac(byte[] key,string domain,byte[] payload)
    =>HMACSHA256.HashData(key,Encoding.UTF8.GetBytes(domain).Concat(payload).ToArray());

static async Task<byte[]> Exchange(UdpClient udp, byte[] bytes)
{
    await udp.SendAsync(bytes);
    using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(3));
    return (await udp.ReceiveAsync(timeout.Token)).Buffer;
}
static async Task<bool> IsSilent(UdpClient udp)
{
    using var timeout = new CancellationTokenSource(TimeSpan.FromMilliseconds(250));
    try { await udp.ReceiveAsync(timeout.Token); return false; }
    catch (OperationCanceledException) { return true; }
}
