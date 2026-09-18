using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using War.Protocol;
using War.Protocol.Transport;

namespace War.Client
{
    // Serial request/response probe. Not a gameplay snapshot or reliable-event transport yet.
    public sealed class BattleConnection : IDisposable
    {
        private readonly UdpClient udp = new UdpClient();
        private readonly ConnectionGrant grant;
        private readonly byte[] key;
        private readonly SemaphoreSlim gate = new SemaphoreSlim(1, 1);
        private readonly ReplayWindow received = new ReplayWindow();
        private ulong sequence;
        public BattleConnection(ConnectionGrant connection)
        {
            grant = connection.Clone(); key = grant.SessionKey.ToByteArray();
            if (key.Length != 32 || grant.SessionId == 0 || grant.Port == 0 || grant.Port > 65535 || grant.ExpiresUnixSeconds <= DateTimeOffset.UtcNow.ToUnixTimeSeconds())
                throw new ArgumentException("Invalid connection grant.");
            udp.Connect(grant.Host, (int)grant.Port);
        }
        public async Task<ServerHello> HelloAsync(CancellationToken ct)
        {
            var reply = await Exchange(new Packet { Hello = new ClientHello { Ticket = grant.Ticket } }, ct).ConfigureAwait(false);
            if (reply.Welcome == null) throw new InvalidOperationException("Expected server hello.");
            return reply.Welcome;
        }
        public async Task<Pong> PingAsync(ulong clientTime, CancellationToken ct)
        {
            var reply = await Exchange(new Packet { Ping = new Ping { ClientTime = clientTime } }, ct).ConfigureAwait(false);
            if (reply.Pong == null || reply.Pong.ClientTime != clientTime) throw new InvalidOperationException("Expected matching pong.");
            return reply.Pong;
        }
        private async Task<Packet> Exchange(Packet packet, CancellationToken ct)
        {
            await gate.WaitAsync(ct).ConfigureAwait(false);
            try
            {
                packet.Version = 1; packet.SessionId = grant.SessionId; packet.Sequence = checked(++sequence);
                byte[] bytes = PacketCodec.Encode(packet, key);
                using (var timeout = CancellationTokenSource.CreateLinkedTokenSource(ct))
                {
                    timeout.CancelAfter(TimeSpan.FromSeconds(3));
                    // Cancellation closes the socket, preventing orphaned receive operations.
                    using (timeout.Token.Register(() => udp.Close()))
                    {
                        await udp.SendAsync(bytes, bytes.Length).ConfigureAwait(false);
                        while (true)
                        {
                            byte[] replyBytes = (await udp.ReceiveAsync().ConfigureAwait(false)).Buffer;
                            if (!PacketCodec.Authenticate(replyBytes, key)) continue;
                            Packet reply = PacketCodec.ReadUntrusted(replyBytes);
                            if (reply != null && reply.SessionId == grant.SessionId && reply.Ack == packet.Sequence && received.Accept(reply.Sequence)) return reply;
                        }
                    }
                }
            }
            finally { gate.Release(); }
        }
        public void Dispose() { udp.Close(); }
    }
}
