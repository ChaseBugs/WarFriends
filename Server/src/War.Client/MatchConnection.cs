using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using War.Protocol;
using War.Protocol.Transport;

namespace War.Client
{
    /// <summary>Portable Unity-compatible match transport. One in-flight mutation;
    /// its identity survives a timeout until RetryPendingAsync resolves it.</summary>
    public sealed class MatchConnection : IDisposable
    {
        private readonly Socket socket;
        private readonly MatchConnectionGrant grant;
        private readonly byte[] key;
        private readonly SemaphoreSlim gate = new SemaphoreSlim(1, 1);
        private readonly ReplayWindow replay = new ReplayWindow();
        private ulong sequence;
        private ulong commandId;
        private MatchCommand pending;
        private bool admitted;
        private volatile bool disposed;

        public MatchConnection(MatchConnectionGrant connection)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            grant = connection.Clone();
            IPAddress address;
            if (!IPAddress.TryParse(grant.Host, out address) || grant.Port == 0 || grant.Port > 65535 ||
                grant.SessionId == 0 || grant.SessionKey.Length != 32 || grant.Ticket.Length < 10 || grant.Ticket.Length > 1024 ||
                grant.MatchId.Length < 1 || grant.MatchId.Length > 64 || !Guid.TryParseExact(grant.PlayerId, "N", out _) ||
                !System.Text.RegularExpressions.Regex.IsMatch(grant.ManifestHash, @"\A[0-9a-f]{64}\z") ||
                grant.ExpiresUnixSeconds <= DateTimeOffset.UtcNow.ToUnixTimeSeconds())
                throw new ArgumentException("Invalid match grant. An IP endpoint and unexpired participant capability are required.");
            key = grant.SessionKey.ToByteArray();
            socket = new Socket(address.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            socket.Connect(new IPEndPoint(address, (int)grant.Port));
        }

        public Task<MatchReply> ConnectAsync(CancellationToken ct) => Run(null, true, false, ct);
        public Task<MatchReply> ReadyAsync(CancellationToken ct) => Run(new MatchCommand { Ready = new ReadyCommand { ManifestHash = grant.ManifestHash } }, false, false, ct);
        public Task<MatchReply> FireAsync(float x, float y, float z, CancellationToken ct) => Run(new MatchCommand { Fire = new FireCommand { TargetX = x, TargetY = y, TargetZ = z } }, false, false, ct);
        public Task<MatchReply> ReloadAsync(CancellationToken ct) => Run(new MatchCommand { Reload = new ReloadCommand() }, false, false, ct);
        public Task<MatchReply> ForfeitAsync(CancellationToken ct) => Run(new MatchCommand { Forfeit = new ForfeitCommand() }, false, false, ct);
        public Task<MatchReply> PollAsync(CancellationToken ct) => Run(new MatchCommand { Poll = new PollMatch() }, false, false, ct);
        public Task<MatchReply> MoveCoverAsync(int direction, CancellationToken ct) => Run(new MatchCommand { MoveCover = new MoveCoverCommand { Direction = direction } }, false, false, ct);
        public Task<MatchReply> RetryPendingAsync(CancellationToken ct) => Run(null, false, true, ct);

        private async Task<MatchReply> Run(MatchCommand command, bool hello, bool retry, CancellationToken ct)
        {
            await gate.WaitAsync(ct).ConfigureAwait(false);
            try
            {
                if (disposed) throw new ObjectDisposedException(nameof(MatchConnection));
                if (hello && admitted) throw new InvalidOperationException("This session is already admitted. Reconnect with a fresh grant and connection.");
                if (!hello && !admitted) throw new InvalidOperationException("Connect before sending match commands.");
                bool poll = command != null && command.IntentCase == MatchCommand.IntentOneofCase.Poll;
                if (retry)
                {
                    if (pending == null) throw new InvalidOperationException("No unresolved command.");
                    command = pending.Clone();
                }
                else if (!hello && !poll)
                {
                    if (pending != null) throw new InvalidOperationException("Retry the unresolved command before another mutation.");
                    command.CommandId = checked(commandId + 1);
                    pending = command.Clone();
                }
                // Poll/Receive is run off Unity's main thread. No orphaned async
                // receive tasks can consume a later request's reply after timeout.
                MatchReply reply = await Task.Run(() => Exchange(command, hello, ct), ct).ConfigureAwait(false);
                if (hello)
                {
                    if (reply.Code != "admitted") throw new InvalidOperationException("Admission rejected: " + reply.Code);
                    admitted = true;
                    foreach (var player in reply.Snapshot.Players)
                        if (player.PlayerId == grant.PlayerId) commandId = player.LastCommandId;
                }
                else if (!poll)
                {
                    if (reply.Code == "command-conflict" || reply.Code == "command-order" || reply.Code == "invalid-command" || reply.Code == "not-admitted")
                        throw new InvalidOperationException("Match command stream rejected: " + reply.Code);
                    commandId = command.CommandId;
                    pending = null;
                }
                return reply;
            }
            finally { gate.Release(); }
        }

        private MatchReply Exchange(MatchCommand command, bool hello, CancellationToken ct)
        {
            var watch = Stopwatch.StartNew();
            long nextSend = 0;
            ulong firstSequence = checked(sequence + 1);
            byte[] buffer = new byte[PacketCodec.MaximumDatagramBytes + 1];
            while (watch.ElapsedMilliseconds < 3000)
            {
                ct.ThrowIfCancellationRequested();
                if (disposed) throw new ObjectDisposedException(nameof(MatchConnection));
                if (watch.ElapsedMilliseconds >= nextSend)
                {
                    var packet = new Packet { Version = 1, SessionId = grant.SessionId, Sequence = checked(++sequence) };
                    if (hello) packet.MatchHello = new MatchHello { Ticket = grant.Ticket, MatchId = grant.MatchId };
                    else packet.MatchCommand = command;
                    socket.Send(PacketCodec.Encode(packet, key));
                    nextSend = watch.ElapsedMilliseconds + 150;
                }
                if (!socket.Poll(10000, SelectMode.SelectRead)) continue;
                int size;
                try { size = socket.Receive(buffer); }
                catch (SocketException e) when (e.SocketErrorCode == SocketError.MessageSize || e.SocketErrorCode == SocketError.ConnectionReset) { continue; }
                if (size > PacketCodec.MaximumDatagramBytes) continue;
                byte[] bytes = new byte[size]; Array.Copy(buffer, bytes, size);
                if (!PacketCodec.Authenticate(bytes, key)) continue;
                Packet response = PacketCodec.ReadUntrusted(bytes);
                if (response == null || response.SessionId != grant.SessionId || response.Ack < firstSequence || response.Ack > sequence ||
                    response.MatchReply == null || response.MatchReply.CommandId != (hello ? 0 : command.CommandId) || !replay.Accept(response.Sequence)) continue;
                var snapshot = response.MatchReply.Snapshot;
                if (snapshot == null || snapshot.MatchId != grant.MatchId || snapshot.ManifestHash != grant.ManifestHash || snapshot.Players.Count != 2)
                    throw new InvalidOperationException("Battle host returned an incompatible snapshot.");
                return response.MatchReply.Clone();
            }
            throw new TimeoutException("Battle host did not acknowledge the request. Retry pending mutations with their existing identity.");
        }

        public void Dispose() { disposed = true; socket.Dispose(); }
    }
}
