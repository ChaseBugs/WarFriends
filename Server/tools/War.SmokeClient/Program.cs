using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
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
    byte[] pingBytes = PacketCodec.Encode(ping, key);
    var pong = await Exchange(udp, pingBytes);
    Check(PacketCodec.Authenticate(pong, key) && PacketCodec.ReadUntrusted(pong)?.Pong.ClientTime == 1234, "authenticated ping/pong");
    await udp.SendAsync(pingBytes);
    Check(await IsSilent(udp), "duplicate ping rejected");
    ping.Sequence = 3; byte[] tampered = PacketCodec.Encode(ping, key); tampered[^1] ^= 1;
    await udp.SendAsync(tampered);
    Check(await IsSilent(udp), "invalid MAC rejected");
    ping.Sequence = 4; ping.Disconnect = new Disconnect { Reason = "probe complete" };
    await udp.SendAsync(PacketCodec.Encode(ping, key));
    await Task.Delay(100);
    await udp.SendAsync(bytes);
    Check(await IsSilent(udp), "closed ticket cannot reopen session");
}
Console.WriteLine($"PASS: {checks} live MongoDB/HTTP/protobuf/UDP checks; two independent clients; no Photon.");

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
