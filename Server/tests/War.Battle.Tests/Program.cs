using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;
using Google.Protobuf;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using War.BattleServer;
using War.Client;
using War.Infrastructure;
using War.Protocol;
using War.Protocol.Transport;

int checks = 0;
void Check(bool ok, string name) { if (!ok) throw new Exception(name); checks++; }
void Reject(Action f, string name)
{
    try { f(); } catch (Exception e) when (e is InvalidDataException or ArgumentException) { checks++; return; }
    throw new Exception(name);
}
string a = new string('a', 32), b = new string('b', 32);
string hash = new string('a', 64);
// Synthetic small weapon for boundary tests, NOT recovered catalog content.
var definition = new MatchManifest("test-match", "test-host", "fixture-map", hash, hash,
    MatchManifest.PrototypeMode, 10, 60, 10,
    [new(a, new("fixture-rifle", 2, 3, 0.1, 0.2)), new(b, new("fixture-rifle", 2, 3, 0.1, 0.2))]);
MatchCommand Ready(ulong id, string digest) => new() { CommandId = id, Ready = new ReadyCommand { ManifestHash = digest } };
MatchCommand Fire(ulong id) => new() { CommandId = id, Fire = new FireCommand { TargetX = 1, TargetY = 2, TargetZ = 3 } };
MatchCommand Poll() => new() { Poll = new PollMatch() };
var match = new MatchEngine(definition);
Check(match.Command(a, Fire(1)).Code == "not-admitted", "no pre-admission command");
Check(!match.Admit(new string('c', 32)), "outsider admission");
Check(match.Admit(a) && match.Admit(b), "roster admission");
Check(match.Command(a, Ready(1, hash)).Code == "manifest-mismatch", "wrong content rejected");
Check(match.Command(a, Ready(2, match.ManifestHash)).Code == "ready", "first ready");
Check(match.Command(a, Fire(3)).Code == "not-running", "no early fire");
Check(match.Command(b, Ready(1, match.ManifestHash)).Snapshot.Phase == BattlePhase.Countdown, "two-player ready gate");
match.Advance(59);
Check(match.Command(a, Fire(4)).Code == "not-running", "source two-second start barrier");
match.Advance(60);
var shot = match.Command(a, Fire(5));
Check(shot.Code == "shot-accepted" && shot.Snapshot.Players[0].ClipAmmo == 1, "one shot debit");
match.Advance(61);
Check(match.Command(a, Fire(5)).Equals(shot), "lost reply exact replay");
var altered = Fire(5); altered.Fire.TargetX = 2;
Check(match.Command(a, altered).Code == "command-conflict", "same id different payload");
Check(match.Command(a, Fire(7)).Code == "command-order", "skip command sequence");
Check(match.Command(a, Fire(6)).Code == "cooldown", "server cadence");
match.Advance(63);
var empty = match.Command(a, Fire(7));
Check(empty.Snapshot.Players[0].ClipAmmo == 0 && empty.Snapshot.Players[0].ReloadEndTick == 69, "empty clip auto-reload");
Check(match.Command(a, Fire(8)).Code == "reloading", "no fire during reload");
match.Advance(68);
Check(match.Snapshot().Players[0].ClipAmmo == 0, "reload incomplete");
match.Advance(69);
Check(match.Snapshot().Players[0].ClipAmmo == 2 && match.Snapshot().Players[0].ReserveAmmo == 1, "source min transfer conserving ammo");
var nan = Fire(9); nan.Fire.TargetY = float.NaN;
Check(match.Command(a, nan).Code == "invalid-target" && match.Snapshot().Players[0].ClipAmmo == 2, "NaN target consumes no ammo");
var terminal = match.Command(b, new MatchCommand { CommandId = 2, Forfeit = new ForfeitCommand() });
Check(terminal.Snapshot.WinnerPlayerId == a && terminal.Snapshot.TerminalReason == "forfeit" && !terminal.Snapshot.RewardEligible, "unscored forfeit");
Check(match.Command(a, Fire(10)).Code == "match-terminal", "no terminal mutation");
Check(match.Command(b, new MatchCommand { CommandId = 2, Forfeit = new ForfeitCommand() }).Equals(terminal), "terminal receipt replay");
Reject(() => match.Advance(68), "backwards clock");
Reject(() => new MatchEngine(definition with { Players = [definition.Players[0], definition.Players[0]] }), "duplicate roster");
Reject(() => new MatchEngine(definition with { DurationSeconds = 0 }), "invalid policy");
Reject(() => new MatchEngine(definition with { Mode = "ranked" }), "no fake ranked combat");
Reject(() => new MatchEngine(definition with { Players = [new(a, definition.Players[0].Weapon with { ReloadSeconds = double.NaN }), definition.Players[1]] }), "invalid weapon config");
var frozen = new MatchEngine(definition);
var original = definition.Players[0];
definition.Players[0] = new(a, new("changed", 999, 999, 1, 1));
Check(frozen.Snapshot().Players[0].ClipAmmo == 2, "detached manifest authority");
definition.Players[0] = original;
var timeout = new MatchEngine(definition);
timeout.Advance(300);
Check(timeout.Snapshot().TerminalReason == "admission-timeout" && !timeout.Admit(a), "half-open admission deadline");
var idle = new MatchEngine(definition);
idle.Admit(a); idle.Admit(b); idle.Command(a, Ready(1, idle.ManifestHash)); idle.Command(b, Ready(1, idle.ManifestHash));
idle.Advance(299); idle.Command(a, Poll()); idle.Advance(300);
Check(idle.Snapshot().WinnerPlayerId == a && idle.Snapshot().TerminalReason == "opponent-disconnected", "idle peer forfeits");
var both = new MatchEngine(definition);
both.Admit(a); both.Admit(b); both.Command(a, Ready(1, both.ManifestHash)); both.Command(b, Ready(1, both.ManifestHash)); both.Advance(300);
Check(both.Snapshot().Phase == BattlePhase.Aborted && both.Snapshot().WinnerPlayerId == "", "both idle abort");

string signingKey = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
var tokens = new MatchTokens(signingKey);
long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
MatchAdmission Claims(string id, ulong session) => new()
{
    MatchId = definition.MatchId, PlayerId = id, ServerId = definition.ServerId,
    ManifestHash = frozen.ManifestHash, SessionId = session, IssuedUnixSeconds = now, ExpiresUnixSeconds = now + 120
};
var claimsA = Claims(a, 101);
Check(tokens.Validate(tokens.Sign(claimsA), frozen, definition.ServerId, now) != null, "signed match admission");
Check(tokens.Validate(tokens.Sign(claimsA), frozen, definition.ServerId, now + 120) == null, "expired match admission");
Check(tokens.Validate(tokens.Sign(claimsA), frozen, "wrong-host", now) == null, "host binding");
var wrong = claimsA.Clone(); wrong.ManifestHash = new string('b', 64);
Check(tokens.Validate(tokens.Sign(wrong), frozen, definition.ServerId, now) == null, "content binding");
var probe = new BattleTickets(signingKey);
Check(tokens.Validate(probe.Sign(new TicketClaims { PlayerId = a, ServerId = definition.ServerId, SessionId = 101, IssuedUnixSeconds = now, ExpiresUnixSeconds = now + 120, Purpose = "connectivity-probe" }), frozen, definition.ServerId, now) == null, "probe cannot join match");
Check(!tokens.SessionKey(claimsA).SequenceEqual(probe.SessionKey(101)), "domain separated keys");

// Adversarial datagrams exercise the same endpoint as NetworkWorker without
// depending on receive timeout timings for negative assertions.
var admission = new MatchEndpoint(definition, signingKey);
var sender = new IPEndPoint(IPAddress.Loopback, 40101);
var stranger = new IPEndPoint(IPAddress.Loopback, 40102);
Packet Hello(MatchAdmission c, ulong sequence) => new()
{
    Version = 1, SessionId = c.SessionId, Sequence = sequence,
    MatchHello = new MatchHello { Ticket = tokens.Sign(c) }
};
var hello = Hello(claimsA, 1);
byte[] helloBytes = PacketCodec.Encode(hello, tokens.SessionKey(claimsA));
var badMac = helloBytes.ToArray(); badMac[^1] ^= 1;
Check(admission.Handle(hello, badMac, sender, now) == null && !admission.Owns(101), "bad MAC cannot reserve participant");
Check(admission.Handle(hello, helloBytes, sender, now) != null, "endpoint admitted");
Check(admission.Handle(hello, helloBytes, stranger, now) == null, "no endpoint hijack");
var duplicateIdentity = Claims(a, 103);
var duplicateHello = Hello(duplicateIdentity, 1);
Check(admission.Handle(duplicateHello, PacketCodec.Encode(duplicateHello, tokens.SessionKey(duplicateIdentity)), sender, now) == null, "one session per participant");
var wrongSession = hello.Clone(); wrongSession.SessionId = 199;
Check(admission.Handle(wrongSession, PacketCodec.Encode(wrongSession, tokens.SessionKey(claimsA)), sender, now) == null, "ticket session mismatch");
var commandPacket = new Packet { Version = 1, SessionId = 101, Sequence = 2, MatchCommand = Ready(1, frozen.ManifestHash) };
var commandBytes = PacketCodec.Encode(commandPacket, tokens.SessionKey(claimsA));
Check(admission.Handle(commandPacket, commandBytes, sender, now) != null, "endpoint command");
Check(admission.Handle(commandPacket, commandBytes, sender, now) == null, "packet replay discarded");
admission.Advance(1);
for (ulong sequence = 3; sequence < 7; sequence++)
{
    var pollPacket = new Packet { Version = 1, SessionId = 101, Sequence = sequence, MatchCommand = Poll() };
    Check(admission.Handle(pollPacket, PacketCodec.Encode(pollPacket, tokens.SessionKey(claimsA)), sender, now) != null, "bounded packet allowance");
}
var flood = new Packet { Version = 1, SessionId = 101, Sequence = 7, MatchCommand = Poll() };
Check(admission.Handle(flood, PacketCodec.Encode(flood, tokens.SessionKey(claimsA)), sender, now) == null, "per-player tick budget");

var history = new MatchEngine(definition);
// A replacement capability must revoke the old endpoint without resetting commands.
var resumed = Claims(a, 104); resumed.ConnectionGeneration = 1;
var resumedHello = Hello(resumed, 1);
Check(admission.Handle(resumedHello, PacketCodec.Encode(resumedHello, tokens.SessionKey(resumed)), stranger, now) != null, "fresh generation reconnect");
Check(!admission.Owns(101) && admission.Owns(104), "reconnect revokes old session");
Check(admission.Handle(hello, helloBytes, sender, now) == null, "old capability cannot reclaim identity");
var resumedReady = new Packet { Version = 1, SessionId = 104, Sequence = 2, MatchCommand = Ready(1, frozen.ManifestHash) };
var resumedBytes = admission.Handle(resumedReady, PacketCodec.Encode(resumedReady, tokens.SessionKey(resumed)), stranger, now);
Check(resumedBytes != null && PacketCodec.Authenticate(resumedBytes, tokens.SessionKey(resumed)) && PacketCodec.ReadUntrusted(resumedBytes)?.MatchReply.Code == "ready", "reconnect preserves exact command receipt");
var otherDefinition = definition with { MatchId = "second-match" };
var router = new MatchRouter([definition, otherDefinition], definition.ServerId, signingKey);
Check(router.Handle(hello, helloBytes, sender, now) == null, "multi-match requires routing identity");
var routedHello = hello.Clone(); routedHello.MatchHello.MatchId = definition.MatchId;
Check(router.Handle(routedHello, PacketCodec.Encode(routedHello, tokens.SessionKey(claimsA)), sender, now) != null, "first routed match admitted");
var otherClaims = Claims(b, 105); otherClaims.MatchId = otherDefinition.MatchId; otherClaims.ManifestHash = new MatchEngine(otherDefinition).ManifestHash;
var otherHello = Hello(otherClaims, 1); otherHello.MatchHello.MatchId = otherDefinition.MatchId;
Check(router.Handle(otherHello, PacketCodec.Encode(otherHello, tokens.SessionKey(otherClaims)), stranger, now) != null, "second match isolated admission");
var misrouted = routedHello.Clone(); misrouted.MatchHello.MatchId = otherDefinition.MatchId;
Check(router.Handle(misrouted, PacketCodec.Encode(misrouted, tokens.SessionKey(claimsA)), sender, now) == null, "session cannot cross matches");
Reject(() => new MatchRouter([definition, definition], definition.ServerId, signingKey), "duplicate match allocation");
Reject(() => new MatchRouter(Enumerable.Range(0, 33).Select(i => definition with { MatchId = "m" + i }), definition.ServerId, signingKey), "bounded match allocation");
history.Admit(a);
for (ulong id = 1; id <= 70; id++) history.Command(a, new MatchCommand { CommandId = id, Reload = new ReloadCommand() });
Check(history.Command(a, new MatchCommand { CommandId = 1, Reload = new ReloadCommand() }).Code == "command-order", "evicted command cannot execute again");
var timer = new MatchEngine(definition with { DurationSeconds = 5, IdleSeconds = 120 });
timer.Admit(a); timer.Admit(b); timer.Command(a, Ready(1, timer.ManifestHash)); timer.Command(b, Ready(1, timer.ManifestHash));
timer.Advance(210);
Check(timer.Snapshot().TerminalReason == "duration-limit" && !timer.Snapshot().RewardEligible, "duration expires without fake outcome");
var limited = new MatchEngine(definition);
limited.Admit(a); limited.Admit(b); limited.Command(a, Ready(1, limited.ManifestHash)); limited.Command(b, Ready(1, limited.ManifestHash));
limited.Advance(60); limited.Command(a, Fire(2)); limited.Advance(63); limited.Command(a, Fire(3)); limited.Advance(69);
limited.Command(a, Fire(4)); limited.Advance(72); limited.Command(a, Fire(5)); limited.Advance(78);
Check(limited.Snapshot().Players[0].ClipAmmo == 1 && limited.Snapshot().Players[0].ReserveAmmo == 0, "partial final reload");
limited.Command(a, Fire(6)); limited.Advance(81);
Check(limited.Command(a, Fire(7)).Code == "no-ammo", "finite ammunition exhausted");
Check(limited.Command(a, new MatchCommand { CommandId = 8, Reload = new ReloadCommand() }).Code == "reload-unavailable", "empty reserve cannot refill");

// Actual NetworkWorker socket/tick integration; no Backend or Mongo process.
using var portProbe = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
int port = ((IPEndPoint)portProbe.Client.LocalEndPoint!).Port;
portProbe.Close();
string manifestFile = Path.Combine(Path.GetTempPath(), "war-battle-" + Guid.NewGuid().ToString("N") + ".json");
await File.WriteAllTextAsync(manifestFile, JsonSerializer.Serialize(definition));
using var logs = LoggerFactory.Create(builder => builder.SetMinimumLevel(LogLevel.Warning));
var config = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
{
    ["Battle:SigningKey"] = signingKey, ["Battle:ServerId"] = definition.ServerId,
    ["Battle:Port"] = port.ToString(), ["Battle:BindAddress"] = "127.0.0.1", ["Battle:MatchManifestPath"] = manifestFile
}).Build();
using var worker = new NetworkWorker(config, logs.CreateLogger<NetworkWorker>());
try
{
    await worker.StartAsync(CancellationToken.None);
    using var peerA = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
    using var peerB = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
    var endpoint = new IPEndPoint(IPAddress.Loopback, port);
    var seq = new Dictionary<ulong, ulong>();
    async Task<MatchReply> Exchange(UdpClient peer, MatchAdmission claims, MatchCommand? command)
    {
        var packet = new Packet { Version = 1, SessionId = claims.SessionId, Sequence = seq.GetValueOrDefault(claims.SessionId) + 1 };
        seq[claims.SessionId] = packet.Sequence;
        if (command == null) packet.MatchHello = new MatchHello { Ticket = tokens.Sign(claims) };
        else packet.MatchCommand = command;
        var key = tokens.SessionKey(claims);
        var bytes = PacketCodec.Encode(packet, key);
        await peer.SendAsync(bytes, endpoint);
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        var received = await peer.ReceiveAsync(deadline.Token);
        var reply = PacketCodec.ReadUntrusted(received.Buffer);
        Check(received.RemoteEndPoint.Equals(endpoint) && PacketCodec.Authenticate(received.Buffer, key) && reply?.SessionId == claims.SessionId && reply.Ack == packet.Sequence && reply.MatchReply != null, "authenticated UDP reply");
        return reply!.MatchReply!;
    }
    var claimsB = Claims(b, 102);
    Check((await Exchange(peerA, claimsA, null)).Code == "admitted", "UDP admit A");
    Check((await Exchange(peerB, claimsB, null)).Code == "admitted", "UDP admit B");
    Check((await Exchange(peerA, claimsA, Ready(1, frozen.ManifestHash))).Code == "ready", "UDP ready A");
    Check((await Exchange(peerB, claimsB, Ready(1, frozen.ManifestHash))).Snapshot.Phase == BattlePhase.Countdown, "UDP start barrier");
    var limit = DateTime.UtcNow.AddSeconds(4);
    MatchReply state;
    do
    {
        await Task.Delay(100);
        state = await Exchange(peerA, claimsA, Poll());
    } while (state.Snapshot.Phase != BattlePhase.Running && DateTime.UtcNow < limit);
    Check(state.Snapshot.Phase == BattlePhase.Running, "live fixed-tick running");
    var liveShot = await Exchange(peerA, claimsA, Fire(2));
    Check(liveShot.Code == "shot-accepted", "UDP fire command");
    Check((await Exchange(peerA, claimsA, Fire(2))).Equals(liveShot), "UDP reliable command retry");
    var final = await Exchange(peerB, claimsB, new MatchCommand { CommandId = 2, Forfeit = new ForfeitCommand() });
    Check(final.Snapshot.Phase == BattlePhase.Ended && final.Snapshot.WinnerPlayerId == a && !final.Snapshot.RewardEligible, "UDP terminal state");
}
finally
{
    await worker.StopAsync(CancellationToken.None);
    File.Delete(manifestFile);
}
// Portable production SDK through a lossy UDP proxy. The server applies the shot
// before its response is deliberately dropped; SDK retry must not fire twice.
await File.WriteAllTextAsync(manifestFile, JsonSerializer.Serialize(definition));
using var sdkWorker = new NetworkWorker(config, logs.CreateLogger<NetworkWorker>());
using var proxy = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0));
using var proxyStop = new CancellationTokenSource();
var sdkServer = new IPEndPoint(IPAddress.Loopback, port);
int proxyPort = ((IPEndPoint)proxy.Client.LocalEndPoint!).Port;
bool dropped = false;
Task relay = Task.Run(async () =>
{
    IPEndPoint? client = null;
    try
    {
        while (!proxyStop.IsCancellationRequested)
        {
            var datagram = await proxy.ReceiveAsync(proxyStop.Token);
            if (datagram.RemoteEndPoint.Equals(sdkServer))
            {
                var packet = PacketCodec.ReadUntrusted(datagram.Buffer);
                if (!dropped && packet?.MatchReply?.Code == "shot-accepted") { dropped = true; continue; }
                if (client != null) await proxy.SendAsync(datagram.Buffer, client, proxyStop.Token);
            }
            else { client = datagram.RemoteEndPoint; await proxy.SendAsync(datagram.Buffer, sdkServer, proxyStop.Token); }
        }
    }
    catch (OperationCanceledException) when (proxyStop.IsCancellationRequested) { }
});
MatchConnectionGrant Grant(MatchAdmission c, int endpointPort) => new()
{
    Host = "127.0.0.1", Port = (uint)endpointPort, Ticket = tokens.Sign(c), SessionKey = ByteString.CopyFrom(tokens.SessionKey(c)),
    SessionId = c.SessionId, MatchId = c.MatchId, PlayerId = c.PlayerId, ManifestHash = c.ManifestHash, ExpiresUnixSeconds = c.ExpiresUnixSeconds
};
try
{
    await sdkWorker.StartAsync(CancellationToken.None);
    using var sdkA = new MatchConnection(Grant(claimsA, proxyPort));
    using var sdkB = new MatchConnection(Grant(Claims(b, 102), port));
    Check((await sdkA.ConnectAsync(CancellationToken.None)).Code == "admitted", "portable SDK admission A");
    Check((await sdkB.ConnectAsync(CancellationToken.None)).Code == "admitted", "portable SDK admission B");
    await sdkA.ReadyAsync(CancellationToken.None); await sdkB.ReadyAsync(CancellationToken.None);
    var deadline = DateTime.UtcNow.AddSeconds(4);
    while ((await sdkA.PollAsync(CancellationToken.None)).Snapshot.Phase != BattlePhase.Running && DateTime.UtcNow < deadline) await Task.Delay(100);
    var sdkShot = await sdkA.FireAsync(1, 2, 3, CancellationToken.None);
    Check(dropped && sdkShot.Code == "shot-accepted" && sdkShot.Snapshot.Players[0].ShotsFired == 1, "SDK recovered dropped shot response exactly once");
    Check((await sdkA.PollAsync(CancellationToken.None)).Snapshot.Players[0].ShotsFired == 1, "no hidden double shot after retry");
    Check((await sdkB.ForfeitAsync(CancellationToken.None)).Snapshot.WinnerPlayerId == a, "SDK terminal projection");
}
finally
{
    proxyStop.Cancel(); await relay;
    await sdkWorker.StopAsync(CancellationToken.None);
    File.Delete(manifestFile);
}
var contentRoot = new DirectoryInfo(AppContext.BaseDirectory);
while (contentRoot != null && !File.Exists(Path.Combine(contentRoot.FullName, "content/recovered-battle-content.json"))) contentRoot = contentRoot.Parent;
if (contentRoot == null) throw new Exception("Recovered battle content artifact not found.");
string contentFile = Path.Combine(contentRoot.FullName, "content/recovered-battle-content.json");
var maps = RecoveredBattleMap.Load(contentFile);
Check(maps.Count == 5 && maps.Sum(m => m.PathCount) == 60, "complete recovered map/path identity set");
var aztec = maps.Single(m => m.Source.EndsWith("Aztec_Multiplayer.unity", StringComparison.Ordinal));
var mappedDefinition = definition with
{
    MapId = "Aztec_Multiplayer", MapRevision = aztec.SourceHash,
    Players = [new(a, original.Weapon, 2, 5, 1), new(b, original.Weapon, 1, 1, 1)]
};
var mapped = new MatchEngine(mappedDefinition, aztec);
mapped.Admit(a); mapped.Admit(b); mapped.Command(a, Ready(1, mapped.ManifestHash)); mapped.Command(b, Ready(1, mapped.ManifestHash)); mapped.Advance(60);
Check(mapped.Snapshot().Players[0].CoverIndex == 5, "manifest binds actual source start cover");
var move = mapped.Command(a, new MatchCommand { CommandId = 2, MoveCover = new MoveCoverCommand { Direction = 1 } });
Check(move.Code == "moving" && move.Snapshot.Players[0].Moving, "source adjacent cover command");
Check(mapped.Command(a, Fire(3)).Code == "moving", "no shot while moving");
mapped.Advance(60);
Check(mapped.Snapshot().Players[0].PositionX == aztec.Covers[5].Position.X, "deferred movement has no unsigned clock underflow");
mapped.Advance(move.Snapshot.Players[0].MoveEndTick);
Check(mapped.Snapshot().Players[0].CoverIndex == 6 && !mapped.Snapshot().Players[0].Moving, "server finishes recovered path");
Check(mapped.Command(a, new MatchCommand { CommandId = 4, MoveCover = new MoveCoverCommand { Direction = 2 } }).Code == "cover-unavailable", "invalid cover direction");
Reject(() => new MatchEngine(mappedDefinition with { MapRevision = hash }, aztec), "map revision binding");
Reject(() => new MatchEngine(mappedDefinition with { Players = [new(a, original.Weapon, 1, 5, 1), mappedDefinition.Players[1]] }, aztec), "cannot use opponent cover");
Check(mapped.Command(a, Fire(5)).Code == "shot-accepted", "mapped geometry fire query");
Check(PacketCodec.Encode(new Packet { Version = 1, SessionId = 101, Sequence = 1, MatchReply = mapped.Reply(5, "shot-accepted") }, tokens.SessionKey(claimsA)).Length <= 1200, "mapped snapshot remains inside MTU");
using (var content = JsonDocument.Parse(await File.ReadAllTextAsync(contentFile)))
{
    Vector3 ReadVector(JsonElement value) => new(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
    foreach (var map in maps)
    {
        foreach (var node in map.Covers)
        {
            foreach (int direction in new[] { -1, 1 })
            {
                int adjacent = map.Adjacent(node.SourceIndex, direction, node.Fraction);
                if (adjacent >= 0)
                {
                    var route = map.Path(node.SourceIndex, adjacent);
                    Check(route.Length >= 2 && map.Covers[adjacent].Fraction == node.Fraction, "source cover adjacency/path");
                    route[0] = new Vector3(999,999,999);
                    Check(map.Path(node.SourceIndex, adjacent)[0] != route[0], "navigation cannot mutate authority");
                }
            }
        }
        var sourceMap = content.RootElement.GetProperty("maps").EnumerateArray().Single(m => m.GetProperty("source").GetString() == map.Source);
        foreach (var ray in sourceMap.GetProperty("validationRays").EnumerateArray())
        {
            var hit = map.Raycast(ReadVector(ray.GetProperty("origin")), ReadVector(ray.GetProperty("direction")), ray.GetProperty("distance").GetSingle());
            bool expectedHit = ray.GetProperty("hit").GetBoolean();
            Check((hit != null) == expectedHit && (!expectedHit || Math.Abs(hit!.Distance - ray.GetProperty("hitDistance").GetSingle()) < 0.002f), "Unity physics parity: " + map.Source + " expected " + ray.GetProperty("hitDistance") + " actual " + hit?.Distance);
        }
    }
}
Console.WriteLine($"PASS: {checks} battle engine, admission, portable SDK, map geometry and real two-peer UDP assertions");

if (args.Length == 3 && args[0] == "--unity")
{
    var unityDefinition = definition with { AdmissionSeconds = 120 };
    await File.WriteAllTextAsync(manifestFile, JsonSerializer.Serialize(unityDefinition));
    string grantsFile = Path.Combine(Path.GetTempPath(), "war-grants-" + Guid.NewGuid().ToString("N") + ".jsonl");
    string unityLog = Path.GetFullPath("Server/.local/unity-battle-sdk.log");
    Directory.CreateDirectory(Path.GetDirectoryName(unityLog)!);
    MatchConnectionGrant UnityGrant(string id, ulong session)
    {
        var claims = Claims(id, session);
        claims.ManifestHash = new MatchEngine(unityDefinition).ManifestHash;
        claims.IssuedUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        claims.ExpiresUnixSeconds = claims.IssuedUnixSeconds + 120;
        return Grant(claims, port);
    }
    await File.WriteAllLinesAsync(grantsFile, [JsonFormatter.Default.Format(UnityGrant(a, 201)), JsonFormatter.Default.Format(UnityGrant(b, 202))]);
    using var unityWorker = new NetworkWorker(config, logs.CreateLogger<NetworkWorker>());
    System.Diagnostics.Process? editor = null;
    try
    {
        await unityWorker.StartAsync(CancellationToken.None);
        var start = new System.Diagnostics.ProcessStartInfo(args[1])
        {
            UseShellExecute = false, CreateNoWindow = true, WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden
        };
        foreach (var argument in new[] { "-batchmode", "-nographics", "-projectPath", args[2], "-executeMethod", "SelfHostedBattleAudit.Run", "-logFile", unityLog }) start.ArgumentList.Add(argument);
        start.Environment["WAR_BATTLE_GRANTS_FILE"] = grantsFile;
        editor = System.Diagnostics.Process.Start(start) ?? throw new Exception("Unity did not start.");
        using var unityTimeout = new CancellationTokenSource(TimeSpan.FromSeconds(110));
        await editor.WaitForExitAsync(unityTimeout.Token);
        Check(editor.ExitCode == 0 && (await File.ReadAllTextAsync(unityLog)).Contains("UNITY_BATTLE_SDK_PASSED"), "actual Unity Mono SDK audit");
        Console.WriteLine("PASS: actual Unity Mono battle SDK; log " + unityLog);
    }
    finally
    {
        if (editor != null) { if (!editor.HasExited) editor.Kill(true); editor.Dispose(); }
        await unityWorker.StopAsync(CancellationToken.None);
        File.Delete(grantsFile); File.Delete(manifestFile);
    }
}
