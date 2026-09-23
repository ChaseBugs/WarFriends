using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using War.Protocol;

namespace War.Client
{
    public enum SelfHostedRoomPhase { Disconnected, Connecting, Loading, Ready, Running, Closed }

    /// <summary>Photon-free room lifecycle for the recovered Unity client. It
    /// owns only connection phase; gameplay authority remains in MatchConnection.
    /// </summary>
    public sealed class SelfHostedRoomLifecycle : IDisposable
    {
        private readonly MatchConnection connection;
        private bool disposed;
        public SelfHostedRoomPhase Phase { get; private set; } = SelfHostedRoomPhase.Disconnected;
        public event Action<SelfHostedRoomPhase> PhaseChanged;
        public MatchConnection Connection => connection;

        public SelfHostedRoomLifecycle(MatchConnection connection)
            => this.connection = connection ?? throw new ArgumentNullException(nameof(connection));

        public async Task<MatchReply> ConnectAsync(CancellationToken ct)
        {
            EnsureOpen();
            if (Phase != SelfHostedRoomPhase.Disconnected) throw new InvalidOperationException("Room is already connected.");
            SetPhase(SelfHostedRoomPhase.Connecting);
            try { var reply = await connection.ConnectAsync(ct).ConfigureAwait(false); SetPhase(SelfHostedRoomPhase.Loading); return reply; }
            catch { SetPhase(SelfHostedRoomPhase.Disconnected); throw; }
        }

        public async Task<MatchReply> MarkReadyAsync(CancellationToken ct)
        {
            EnsureOpen();
            if (Phase != SelfHostedRoomPhase.Loading) throw new InvalidOperationException("Room is not loading.");
            var reply = await connection.ReadyAsync(ct).ConfigureAwait(false);
            if (reply == null || reply.Code != "ready") throw new InvalidOperationException("Room readiness rejected: " + (reply == null ? "null" : reply.Code));
            SetPhase(SelfHostedRoomPhase.Ready);
            return reply;
        }

        /// <summary>Apply an authoritative snapshot received from the host.
        /// This keeps the room phase driven by server state after reconnects and
        /// polls; callers do not need to infer Running/Closed locally.</summary>
        public void Observe(MatchSnapshot snapshot)
        {
            EnsureOpen();
            if (snapshot == null) throw new ArgumentNullException(nameof(snapshot));
            switch (snapshot.Phase)
            {
                case BattlePhase.Waiting:
                case BattlePhase.Countdown:
                    if (Phase == SelfHostedRoomPhase.Disconnected || Phase == SelfHostedRoomPhase.Connecting)
                        SetPhase(SelfHostedRoomPhase.Loading);
                    if (Phase == SelfHostedRoomPhase.Loading && snapshot.Players.Any(p => p.Ready))
                        SetPhase(SelfHostedRoomPhase.Ready);
                    break;
                case BattlePhase.Running:
                    if (Phase == SelfHostedRoomPhase.Connecting) SetPhase(SelfHostedRoomPhase.Loading);
                    if (Phase == SelfHostedRoomPhase.Loading) SetPhase(SelfHostedRoomPhase.Ready);
                    if (Phase == SelfHostedRoomPhase.Ready) SetPhase(SelfHostedRoomPhase.Running);
                    break;
                case BattlePhase.Ended:
                case BattlePhase.Aborted:
                    if (Phase != SelfHostedRoomPhase.Closed) SetPhase(SelfHostedRoomPhase.Closed);
                    break;
                default:
                    throw new InvalidOperationException("Unknown authoritative battle phase.");
            }
        }

        public void MarkRunning()
        {
            EnsureOpen();
            if (Phase != SelfHostedRoomPhase.Ready) throw new InvalidOperationException("Room is not ready.");
            SetPhase(SelfHostedRoomPhase.Running);
        }

        public void Close()
        {
            if (disposed) return;
            disposed = true;
            SetPhase(SelfHostedRoomPhase.Closed);
            connection.Dispose();
        }
        private void SetPhase(SelfHostedRoomPhase phase)
        {
            if (Phase == phase) return;
            Phase = phase;
            PhaseChanged?.Invoke(phase);
        }
        private void EnsureOpen() { if (disposed || Phase == SelfHostedRoomPhase.Closed) throw new ObjectDisposedException(nameof(SelfHostedRoomLifecycle)); }
        public void Dispose() { Close(); }
    }
}
