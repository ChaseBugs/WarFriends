using System.Net;
using System.Net.Sockets;
using Google.Protobuf;
using War.BattleServer;
using War.Client;
using War.Protocol;
using War.Protocol.Transport;

/// <summary>Runs signed UDP delivery around explicit host-owned crew transitions, without a Worker clock.</summary>
internal sealed class CoopCrewUdpHost : IAsyncDisposable
{
    private const int MissionIndex = 46;
    private const ulong AircraftSpawnTick = 10UL * MatchManifest.TickRate;
    private const int TimeoutSeconds = 30;
    private const int SigningKeyBytes = 32;

    private readonly object _sync = new();
    private readonly MatchManifest _manifest;
    private readonly CoopMatchRuntime _runtime;
    private readonly MatchEndpoint _endpoint;
    private readonly MatchTokens _tokens;
    private readonly UdpClient _socket = new(new IPEndPoint(IPAddress.Loopback, 0));
    private readonly CancellationTokenSource _lifetime = new(TimeSpan.FromSeconds(TimeoutSeconds));
    private readonly Task _pump;
    private ulong _tick;
    private bool _hasPreparedAircraft;

    internal CoopCrewUdpHost(CoopObstacleVolleyRuntimeTests.Sources sources, string directory)
    {
        MissionMapRule map = sources.Missions.MapForMission(MissionIndex);
        _manifest = MatchManifest.Validate(sources.Manifest with
        {
            MatchId = "coop-secondary-udp",
            MissionIndex = MissionIndex,
            MapId = map.Scene,
            MapRevision = map.SceneSha256,
            DurationSeconds = sources.Missions.Get(MissionIndex).TimeSeconds,
        });
        string signingKey = Convert.ToBase64String(Enumerable.Repeat((byte)1, SigningKeyBytes).ToArray());
        _tokens = new MatchTokens(signingKey);
        _runtime = new CoopMatchRuntime(_manifest, sources.Missions, sources.Spawns, sources.Routes,
            sources.Combat, chooseBehaviour: _ => 0, choosePoint: _ => 0, playerWeaponContent: sources.Content,
            coopAirWaypoints: CoopAirWaypointCatalog.Load(
                Path.Combine(directory, "recovered-coop-air-waypoint-routes.json"), sources.Spawns));
        _endpoint = new MatchEndpoint(_manifest, signingKey, _runtime, 0);
        _pump = ServeAsync();
    }

    internal CancellationToken Token => _lifetime.Token;

    internal bool HasSentTransfer { get; private set; }

    internal MatchConnectionGrant CreateGrant(string playerId, ulong sessionId, ulong generation)
    {
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var admission = new MatchAdmission
        {
            MatchId = _manifest.MatchId, ManifestHash = _manifest.Digest(), ServerId = _manifest.ServerId,
            PlayerId = playerId, SessionId = sessionId, ConnectionGeneration = generation,
            IssuedUnixSeconds = now, ExpiresUnixSeconds = now + MatchTokens.GrantLifetimeSeconds,
        };
        return new MatchConnectionGrant
        {
            Host = "127.0.0.1", Port = (uint)((IPEndPoint)_socket.Client.LocalEndPoint!).Port,
            MatchId = admission.MatchId, ManifestHash = admission.ManifestHash, PlayerId = playerId,
            SessionId = sessionId, Ticket = _tokens.Sign(admission),
            SessionKey = ByteString.CopyFrom(_tokens.SessionKey(admission)),
            ExpiresUnixSeconds = admission.ExpiresUnixSeconds,
        };
    }

    internal BattleCoopEnemySpawn PrepareAircraft()
    {
        lock (_sync)
        {
            _tick = _runtime.Snapshot().StartTick + AircraftSpawnTick;
            _endpoint.Advance(_tick);
            BattleCoopEnemySpawn aircraft = _runtime.Snapshot().Coop.EnemySpawns
                .Single(row => row.Behaviour == "DeployHeli");
            _hasPreparedAircraft = true;
            return aircraft;
        }
    }

    internal void ApplyConfirmedDamage(BattleCoopEnemySpawn aircraft)
    {
        lock (_sync)
        {
            bool crewDamaged = _runtime.ApplyHostEnemyDamage(
                aircraft.CrewActors[0].EntityId, aircraft.CrewActors[0].Health / 2, _tick);
            bool gunnerKilled = _runtime.ApplyHostTransportGunnerDamage(
                aircraft.EntityId, aircraft.GunnerHealth, _tick);
            if (!crewDamaged || !gunnerKilled)
            {
                throw new InvalidDataException("Host crew damage fixture could not apply source transitions.");
            }
        }
    }

    internal void AdvanceToRespawn(ulong aircraftId)
    {
        lock (_sync)
        {
            _tick = _runtime.TransportGunner(aircraftId)?.RespawnTick ??
                throw new InvalidDataException("Source gunner has no respawn state.");
            if (_tick == 0)
            {
                throw new InvalidDataException("Source gunner must be dead before advancing to respawn.");
            }
            _endpoint.Advance(_tick);
        }
    }

    private async Task ServeAsync()
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

                byte[]? reply;
                lock (_sync)
                {
                    // Preserve endpoint rate limits while each real datagram advances the host clock.
                    _endpoint.Advance(++_tick);
                    reply = _endpoint.Handle(packet, datagram.Buffer, datagram.RemoteEndPoint,
                        DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                    HasSentTransfer |= _hasPreparedAircraft && packet.MatchCommand?.Poll != null &&
                        reply != null && PacketCodec.ReadUntrusted(reply)?.MatchReply?.TransferId > 0;
                }
                if (reply != null)
                {
                    await _socket.SendAsync(reply, datagram.RemoteEndPoint, Token);
                }
            }
        }
        catch (OperationCanceledException) when (Token.IsCancellationRequested)
        {
            // Fixture disposal cancels its owned receive instead of leaving a background socket.
        }
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
            _runtime.Dispose();
            _lifetime.Dispose();
        }
    }
}
