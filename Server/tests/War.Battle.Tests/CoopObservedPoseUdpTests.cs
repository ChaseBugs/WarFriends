using System.Net;
using System.Net.Sockets;
using Google.Protobuf;
using War.BattleServer;
using War.Client;
using War.Protocol;
using War.Protocol.Transport;

/// <summary>Exercises negotiated and clip-only pose delivery over real SDK UDP sockets.</summary>
internal static class CoopObservedPoseUdpTests
{
    private const ulong ModernSessionId = 3101;
    private const ulong LegacySessionId = 3102;
    private const int TimeoutSeconds = 30;
    private const ulong MaximumTick = 1600;
    private const ulong CompletedReturnTicks = 16;
    private const ulong PartialReturnTicks = 3;
    private const ulong SettledTurnTicks = 6;

    internal static async Task Run(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        await RunCase(sources, PartialReturnTicks);
        await RunCase(sources, CompletedReturnTicks);
    }

    private static async Task RunCase(CoopObstacleVolleyRuntimeTests.Sources sources, ulong returnTicks)
    {
        await using var host = new Host(sources);
        string revision = ObservedInfantryPoseCatalogData.BuiltIn.Revision;
        using var modern = new MatchConnection(
            host.CreateGrant(sources.Manifest.Players[0].PlayerId, ModernSessionId), revision);
        using var legacy = new MatchConnection(host.CreateGrant(sources.Manifest.Players[1].PlayerId, LegacySessionId));
        using var modernRoom = new SelfHostedRoomLifecycle(modern);
        using var legacyRoom = new SelfHostedRoomLifecycle(legacy);
        await VerifyReadinessOrderAsync(modernRoom, legacyRoom, host.Token);
        ulong enemyId = host.PrepareObservedWindow(returnTicks);
        Task<MatchReply> modernPoll = modern.PollAsync(host.Token);
        Task<MatchReply> legacyPoll = legacy.PollAsync(host.Token);
        await Task.WhenAll(modernPoll, legacyPoll);
        MatchReply observed = await modernPoll;
        MatchReply compatible = await legacyPoll;
        IReadOnlyList<CoopEnemyViewState> observedViews = CoopEnemyViewProjection.FromSnapshot(
            observed.Snapshot, sources.Manifest.Players[0].PlayerId, revision);
        InfantryAnimationFrameView frame = observedViews.Single(enemy => enemy.EntityId == enemyId).InfantryAnimation;
        Require(frame?.ObservedPose != null, "The negotiated socket must receive the host-selected source pose.");
        Require(host.HasLegacyPollReference && CoopEnemyViewProjection.FromSnapshot(compatible.Snapshot,
            sources.Manifest.Players[1].PlayerId).Single(enemy => enemy.EntityId == enemyId).InfantryAnimation == null,
            "The clip-only socket must hide an actual observed frame, not merely poll after the pose expired.");
        Require(host.HasSentObservedTransfer && host.CurrentTick > observed.Snapshot.ServerTick,
            "The SDK must recover a frozen observed reply after UDP chunk requests advance the simulation.");
        string? output = Environment.GetEnvironmentVariable("WAR_OBSERVED_UDP_FRAME_OUTPUT");
        if (!string.IsNullOrEmpty(output))
        {
            File.WriteAllBytes(output, observed.ToByteArray());
        }

        Console.WriteLine($"PASS: return phase {returnTicks} SDK UDP negotiation, clip-only isolation " +
            "and frozen observed-pose chunk delivery");
    }

    private static async Task VerifyReadinessOrderAsync(
        SelfHostedRoomLifecycle modernRoom, SelfHostedRoomLifecycle legacyRoom, CancellationToken token)
    {
        modernRoom.Observe((await modernRoom.ConnectAsync(token)).Snapshot);
        legacyRoom.Observe((await legacyRoom.ConnectAsync(token)).Snapshot);
        modernRoom.Observe((await modernRoom.MarkReadyAsync(token)).Snapshot);
        MatchReply peerReady = await legacyRoom.Connection.PollAsync(token);
        legacyRoom.Observe(peerReady.Snapshot);
        Require(legacyRoom.Phase == SelfHostedRoomPhase.Loading,
            "The other player's Ready must not consume the local scene-loading transition.");
        legacyRoom.Observe((await legacyRoom.MarkReadyAsync(token)).Snapshot);
        Require(legacyRoom.Phase == SelfHostedRoomPhase.Running,
            "The local Ready must still reach the host and start the cooperative mission.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private sealed class Host : IAsyncDisposable
    {
        private readonly object _sync = new();
        private readonly CoopMatchRuntime _runtime;
        private readonly MatchEndpoint _endpoint;
        private readonly MatchTokens _tokens;
        private readonly string _serverId;
        private readonly UdpClient _socket = new(new IPEndPoint(IPAddress.Loopback, 0));
        private readonly CancellationTokenSource _lifetime = new(TimeSpan.FromSeconds(TimeoutSeconds));
        private readonly Task _pump;
        private ulong _tick;
        private ulong _enemyId;
        private bool _shouldPairPolls;
        private UdpReceiveResult? _heldPoll;

        internal Host(CoopObstacleVolleyRuntimeTests.Sources sources)
        {
            const int KeyBytes = 32;
            string signingKey = Convert.ToBase64String(Enumerable.Repeat((byte)1, KeyBytes).ToArray());
            _tokens = new MatchTokens(signingKey);
            _serverId = sources.Manifest.ServerId;
            _runtime = CoopObstacleVolleyRuntimeTests.CreateUnstartedRuntime(sources);
            _endpoint = new MatchEndpoint(sources.Manifest, signingKey, _runtime, 0);
            _pump = Serve();
        }

        internal CancellationToken Token => _lifetime.Token;
        internal bool HasLegacyPollReference { get; private set; }

        internal bool HasSentObservedTransfer { get; private set; }

        internal ulong CurrentTick
        {
            get
            {
                lock (_sync)
                {
                    return _tick;
                }
            }
        }

        internal MatchConnectionGrant CreateGrant(string playerId, ulong sessionId)
        {
            long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var admission = new MatchAdmission
            {
                MatchId = _runtime.MatchId, ManifestHash = _runtime.ManifestHash, ServerId = _serverId,
                PlayerId = playerId, SessionId = sessionId, IssuedUnixSeconds = now,
                ExpiresUnixSeconds = now + MatchTokens.GrantLifetimeSeconds
            };
            return new MatchConnectionGrant
            {
                Host = "127.0.0.1", Port = (uint)((IPEndPoint)_socket.Client.LocalEndPoint!).Port,
                MatchId = admission.MatchId, ManifestHash = admission.ManifestHash, PlayerId = playerId,
                SessionId = sessionId, Ticket = _tokens.Sign(admission),
                SessionKey = ByteString.CopyFrom(_tokens.SessionKey(admission)),
                ExpiresUnixSeconds = admission.ExpiresUnixSeconds
            };
        }

        internal ulong PrepareObservedWindow(ulong returnTicks)
        {
            lock (_sync)
            {
                while (_runtime.Snapshot().Coop.EnemySpawns.Count == 0)
                {
                    Advance(_tick + 1);
                }

                _enemyId = _runtime.Snapshot().Coop.EnemySpawns[0].EntityId;
                while (_runtime.InfantryShotWindup(_enemyId)?.CompletedTick == null ||
                    _runtime.ObstacleCrawlReturnTick(_enemyId) == null)
                {
                    Advance(_tick + 1);
                }

                ulong capture = _runtime.ObstacleCrawlReturnTick(_enemyId)!.Value + returnTicks;
                CoopObstaclePreparationRuntimeTests.ForceEarlyReadiness(_runtime, _enemyId, capture);
                Advance(capture + SettledTurnTicks);
                Require(HasReference(), "The verified return window must exist before network polling.");
                _shouldPairPolls = true;
                return _enemyId;
            }
        }

        private void Advance(ulong tick)
        {
            Require(tick <= MaximumTick && !_runtime.Terminal, "The bounded source fixture did not reach its pose.");
            _tick = tick;
            _endpoint.Advance(tick);
        }

        private bool HasReference()
        {
            return _runtime.Snapshot().Coop.EnemySpawns.Single(enemy => enemy.EntityId == _enemyId)
                .InfantryAnimation?.ObservedPose != null;
        }

        private async Task Serve()
        {
            try
            {
                while (!Token.IsCancellationRequested)
                {
                    UdpReceiveResult received = await _socket.ReceiveAsync(Token);
                    List<(byte[] Bytes, IPEndPoint Peer)> replies = [];
                    lock (_sync)
                    {
                        foreach (UdpReceiveResult datagram in SelectBatch(received))
                        {
                            byte[]? reply = Handle(datagram);
                            if (reply != null)
                            {
                                replies.Add((reply, datagram.RemoteEndPoint));
                            }
                        }
                    }

                    foreach (var reply in replies)
                    {
                        await _socket.SendAsync(reply.Bytes, reply.Peer, Token);
                    }
                }
            }
            catch (OperationCanceledException) when (Token.IsCancellationRequested)
            {
                // Bounded fixture disposal deliberately cancels its pending UDP receive.
            }
        }

        private UdpReceiveResult[] SelectBatch(UdpReceiveResult received)
        {
            Packet? packet = PacketCodec.ReadUntrusted(received.Buffer);
            if (_shouldPairPolls && packet?.MatchCommand?.Poll != null)
            {
                // Hold both poll requests before either response, keeping their narrow source window comparable.
                if (_heldPoll == null)
                {
                    _heldPoll = received;
                    return [];
                }

                UdpReceiveResult first = _heldPoll.Value;
                _heldPoll = null;
                _shouldPairPolls = false;
                return [first, received];
            }

            return [received];
        }

        private byte[]? Handle(UdpReceiveResult datagram)
        {
            Packet? packet = PacketCodec.ReadUntrusted(datagram.Buffer);
            if (packet == null)
            {
                return null;
            }

            Advance(_tick + 1);
            if (packet.SessionId == LegacySessionId && packet.MatchCommand?.Poll != null && _enemyId != 0)
            {
                HasLegacyPollReference = HasReference();
            }

            byte[]? bytes = _endpoint.Handle(packet, datagram.Buffer, datagram.RemoteEndPoint,
                DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            if (packet.SessionId == ModernSessionId && packet.MatchCommand?.Poll != null && bytes != null)
            {
                HasSentObservedTransfer |= PacketCodec.ReadUntrusted(bytes)?.MatchReply?.TransferId > 0;
            }

            return bytes;
        }

        public async ValueTask DisposeAsync()
        {
            _lifetime.Cancel();
            try
            {
                await _pump;
            }
            finally
            {
                _socket.Dispose();
                _lifetime.Dispose();
            }
        }
    }
}
