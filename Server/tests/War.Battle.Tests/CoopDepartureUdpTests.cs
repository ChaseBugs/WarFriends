using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using Google.Protobuf;
using War.BattleServer;
using War.Client;
using War.Protocol;
using War.Protocol.Transport;

/// <summary>Recovers a lost peer-departure receipt through the actual SDK and authenticated UDP endpoint.</summary>
internal static class CoopDepartureUdpTests
{
    private const ulong MasterSessionId = 2901;
    private const ulong PeerSessionId = 2902;
    private const int FixtureTimeoutSeconds = 30;
    private const int SigningKeyByteCount = 32;
    private const int LeftDirection = -1;
    private const int RightDirection = 1;
    private const int FirstCoverIndex = 0;
    private const int ReleasedPeerCoverIndex = 2;

    internal static async Task Run(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        await using var host = new Host(sources);
        string masterId = sources.Manifest.Players[0].PlayerId;
        string peerId = sources.Manifest.Players[1].PlayerId;
        using var master = new MatchConnection(host.CreateGrant(masterId, MasterSessionId),
            ObservedInfantryPoseCatalogData.BuiltIn.Revision);
        using var peer = new MatchConnection(host.CreateGrant(peerId, PeerSessionId));
        await StartMission(master, peer, host.Token);
        await LoseDepartureReply(peer, host);
        await VerifyRecovery(master, peer, host);
        Console.WriteLine("PASS: co-op SDK lost-departure receipt recovery, closed reconnect and continuing master");
    }

    private static async Task StartMission(MatchConnection master, MatchConnection peer, CancellationToken token)
    {
        MatchReply masterReply = await master.ConnectAsync(token);
        Require(masterReply.Code == "admitted" && masterReply.ObservedPoseCatalogRevision ==
            ObservedInfantryPoseCatalogData.BuiltIn.Revision, "The master must negotiate its exact renderer revision.");
        MatchReply peerReply = await peer.ConnectAsync(token);
        Require(peerReply.Code == "admitted" && peerReply.ObservedPoseCatalogRevision.Length == 0,
            "The clip-only peer must remain compatible without advertising a renderer.");
        Require((await master.ReadyAsync(token)).Code == "ready", "The source master must become ready.");
        Require((await peer.ReadyAsync(token)).Snapshot.Coop.Started,
            "Both SDK clients must start the source mission.");
    }

    private static async Task LoseDepartureReply(MatchConnection peer, Host host)
    {
        try
        {
            await peer.ForfeitAsync(host.Token);
        }
        catch (TimeoutException)
        {
            Require(host.CapturedDeparture != null, "The host must consume departure before every reply is lost.");
            return;
        }

        throw new InvalidDataException("The fixture failed to lose all automatic Forfeit replies.");
    }

    private static async Task VerifyRecovery(MatchConnection master, MatchConnection peer, Host host)
    {
        MatchReply original = host.CapturedDeparture ?? throw new InvalidDataException("Departure was not captured.");
        string masterId = original.Snapshot.Coop.ParticipantIds.Single();
        string peerId = original.Snapshot.Players.Single(player => player.CoopDeparted).PlayerId;
        MatchReply surviving = await master.PollAsync(host.Token);
        Require(surviving.Snapshot.Phase == BattlePhase.Running &&
            surviving.Snapshot.Coop.ParticipantIds.SequenceEqual([masterId]),
            "Losing the peer's response must not end or re-admit its source mission.");
        host.VerifyReconnectEligibility(masterId, peerId);
        host.AllowDepartureReplies();
        MatchReply recovered = await peer.RetryPendingAsync(host.Token);
        Require(recovered.ToByteArray().AsSpan().SequenceEqual(original.ToByteArray()),
            "SDK retry must recover the original immutable response with its original command cursor.");
        await VerifyNewCommandRejected(peer, host, peerId);
        Require((await master.MoveCoopCoverAsync(RightDirection, ReleasedPeerCoverIndex, host.Token)).Code == "moving",
            "The master must continue gameplay and acquire the departed peer's released cover.");
        MatchReply terminal = await master.ForfeitAsync(host.Token);
        Require(terminal.Snapshot.Phase == BattlePhase.Ended && terminal.Snapshot.Coop.ParticipantIds.Count == 0,
            "The remaining master's departure must close the shared mission.");
    }

    private static async Task VerifyNewCommandRejected(MatchConnection peer, Host host, string peerId)
    {
        try
        {
            await peer.MoveCoopCoverAsync(LeftDirection, FirstCoverIndex, host.Token);
        }
        catch (InvalidOperationException)
        {
            host.VerifyDepartedCursor(peerId);
            return;
        }

        throw new InvalidDataException("The departed SDK peer resumed gameplay.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }

    private sealed class Host : IAsyncDisposable
    {
        private readonly CoopMatchRuntime _runtime;
        private readonly MatchEndpoint _endpoint;
        private readonly MatchManifest _manifest;
        private readonly MatchTokens _tokens;
        private readonly UdpClient _socket = new(new IPEndPoint(IPAddress.Loopback, 0));
        private readonly CancellationTokenSource _lifetime = new(TimeSpan.FromSeconds(FixtureTimeoutSeconds));
        private readonly Stopwatch _clock = Stopwatch.StartNew();
        private readonly Task _pump;
        private volatile bool _dropDepartureReplies = true;

        internal Host(CoopObstacleVolleyRuntimeTests.Sources sources)
        {
            _manifest = sources.Manifest;
            string signingKey = Convert.ToBase64String(new byte[SigningKeyByteCount]);
            _tokens = new MatchTokens(signingKey);
            _runtime = new CoopMatchRuntime(_manifest, sources.Missions, sources.Spawns,
                sources.Routes, sources.Combat, chooseBehaviour: _ => 0, playerWeaponContent: sources.Content);
            _endpoint = new MatchEndpoint(_manifest, signingKey, _runtime, 0);
            _pump = Serve();
        }

        internal CancellationToken Token => _lifetime.Token;

        internal MatchReply? CapturedDeparture { get; private set; }

        internal MatchConnectionGrant CreateGrant(string playerId, ulong sessionId)
        {
            long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var admission = new MatchAdmission
            {
                MatchId = _manifest.MatchId,
                ServerId = _manifest.ServerId,
                PlayerId = playerId,
                ManifestHash = _runtime.ManifestHash,
                SessionId = sessionId,
                IssuedUnixSeconds = now,
                ExpiresUnixSeconds = now + MatchTokens.GrantLifetimeSeconds
            };
            return new MatchConnectionGrant
            {
                Host = "127.0.0.1",
                Port = (uint)((IPEndPoint)_socket.Client.LocalEndPoint!).Port,
                PlayerId = playerId,
                SessionId = sessionId,
                MatchId = admission.MatchId,
                ManifestHash = admission.ManifestHash,
                Ticket = _tokens.Sign(admission),
                SessionKey = ByteString.CopyFrom(_tokens.SessionKey(admission)),
                ExpiresUnixSeconds = admission.ExpiresUnixSeconds
            };
        }

        internal void AllowDepartureReplies()
        {
            _dropDepartureReplies = false;
        }

        internal void VerifyReconnectEligibility(string masterId, string peerId)
        {
            byte[] before = _runtime.Snapshot().ToByteArray();
            Require(!_endpoint.CanReconnect(peerId) && _endpoint.CanReconnect(masterId),
                "Reconnect authorization must reject the departed peer and retain the master.");
            Require(_runtime.Snapshot().ToByteArray().AsSpan().SequenceEqual(before),
                "Checking reconnect eligibility must not mutate presence, revision or mission state.");
        }

        internal void VerifyDepartedCursor(string peerId)
        {
            MatchReply original = CapturedDeparture ?? throw new InvalidDataException("Departure was not captured.");
            ulong originalCursor = original.Snapshot.Players.Single(player => player.PlayerId == peerId).LastCommandId;
            BattlePlayerState peer = _runtime.Snapshot().Players.Single(player => player.PlayerId == peerId);
            Require(peer.CoopDeparted && peer.LastCommandId == originalCursor,
                "The rejected post-departure command must leave the consumed command cursor unchanged.");
        }

        private async Task Serve()
        {
            try
            {
                while (!Token.IsCancellationRequested)
                {
                    UdpReceiveResult datagram = await _socket.ReceiveAsync(Token);
                    Packet? packet = PacketCodec.ReadUntrusted(datagram.Buffer);
                    if (packet == null)
                    {
                        continue;
                    }

                    _endpoint.Advance((ulong)(_clock.Elapsed.TotalSeconds * MatchManifest.TickRate));
                    byte[]? reply = _endpoint.Handle(packet, datagram.Buffer, datagram.RemoteEndPoint,
                        DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                    MatchCommand? command = packet.MatchCommand;
                    bool departure = packet.SessionId == PeerSessionId && command?.Forfeit != null;
                    if (departure && reply != null && command != null)
                    {
                        CapturedDeparture ??= _runtime.Reply(command.CommandId, "forfeit");
                    }
                    if (reply != null && !(departure && _dropDepartureReplies))
                    {
                        await _socket.SendAsync(reply, datagram.RemoteEndPoint, Token);
                    }
                }
            }
            catch (OperationCanceledException) when (Token.IsCancellationRequested)
            {
                // Disposing this bounded fixture deliberately cancels its pending UDP receive.
            }
        }

        public async ValueTask DisposeAsync()
        {
            _lifetime.Cancel();
            await _pump;
            _socket.Dispose();
            _lifetime.Dispose();
        }
    }
}
