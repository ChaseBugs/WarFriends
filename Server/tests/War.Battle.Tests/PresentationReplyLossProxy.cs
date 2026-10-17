using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using War.Protocol;
using War.Protocol.Transport;

/// <summary>Drops real Worker replies without rewriting authenticated packet bytes.</summary>
internal sealed class PresentationReplyLossProxy : IAsyncDisposable
{
    private const ulong LocalSessionId = 801;
    private const ulong LastFixtureSessionId = 804;
    private readonly UdpClient _clients = new(new IPEndPoint(IPAddress.Loopback, 0));
    private readonly UdpClient _worker = new(new IPEndPoint(IPAddress.Loopback, 0));
    private readonly ConcurrentDictionary<ulong, IPEndPoint> _routes = new();
    private readonly CancellationTokenSource _lifetime = new();
    private readonly IPEndPoint _workerEndpoint;
    private readonly Task _requests;
    private readonly Task _replies;
    private bool _hasReadyRequest;
    private bool _shouldReleaseReadyReplies;
    private int _droppedReadyReplies;
    private int _droppedPresentationReplies;

    internal PresentationReplyLossProxy(int workerPort)
    {
        _workerEndpoint = new IPEndPoint(IPAddress.Loopback, workerPort);
        _requests = ObserveShutdownAsync(ForwardRequestsAsync);
        _replies = ObserveShutdownAsync(ForwardRepliesAsync);
    }

    internal int Port => ((IPEndPoint)_clients.Client.LocalEndPoint!).Port;

    internal void VerifyInjectedLoss()
    {
        if (Volatile.Read(ref _droppedReadyReplies) < 2 ||
            Volatile.Read(ref _droppedPresentationReplies) != 1 ||
            !Volatile.Read(ref _shouldReleaseReadyReplies))
        {
            throw new InvalidDataException("The fixture did not exercise ready timeout and presentation reply loss.");
        }
    }

    private async Task ForwardRequestsAsync()
    {
        while (!_lifetime.IsCancellationRequested)
        {
            UdpReceiveResult datagram = await _clients.ReceiveAsync(_lifetime.Token);
            Packet? packet = PacketCodec.ReadUntrusted(datagram.Buffer);
            if (packet == null || packet.SessionId < LocalSessionId || packet.SessionId > LastFixtureSessionId)
            {
                continue;
            }

            _routes[packet.SessionId] = datagram.RemoteEndPoint;
            ObserveRequest(packet);
            await _worker.SendAsync(datagram.Buffer, _workerEndpoint, _lifetime.Token);
        }
    }

    private void ObserveRequest(Packet packet)
    {
        if (packet.SessionId != LocalSessionId || packet.MatchCommand == null)
        {
            return;
        }
        if (packet.MatchCommand.IntentCase == MatchCommand.IntentOneofCase.Ready)
        {
            Volatile.Write(ref _hasReadyRequest, true);
        }
        if (packet.MatchCommand.IntentCase == MatchCommand.IntentOneofCase.Poll &&
            Volatile.Read(ref _hasReadyRequest))
        {
            // The Editor polls only after its awaited Ready call has timed out.
            Volatile.Write(ref _shouldReleaseReadyReplies, true);
        }
    }

    private async Task ForwardRepliesAsync()
    {
        while (!_lifetime.IsCancellationRequested)
        {
            UdpReceiveResult datagram = await _worker.ReceiveAsync(_lifetime.Token);
            Packet? packet = PacketCodec.ReadUntrusted(datagram.Buffer);
            if (!datagram.RemoteEndPoint.Equals(_workerEndpoint) || packet == null ||
                !_routes.TryGetValue(packet.SessionId, out IPEndPoint? client))
            {
                continue;
            }
            if (!ShouldDrop(packet))
            {
                await _clients.SendAsync(datagram.Buffer, client, _lifetime.Token);
            }
        }
    }

    private bool ShouldDrop(Packet packet)
    {
        if (packet.SessionId != LocalSessionId || packet.MatchReply == null)
        {
            return false;
        }
        if (packet.MatchReply.Code == "ready" && !Volatile.Read(ref _shouldReleaseReadyReplies))
        {
            Interlocked.Increment(ref _droppedReadyReplies);
            return true;
        }
        return packet.MatchReply.Code == "presentation-ready" &&
            Interlocked.CompareExchange(ref _droppedPresentationReplies, 1, 0) == 0;
    }

    private async Task ObserveShutdownAsync(Func<Task> pump)
    {
        try
        {
            await pump();
        }
        catch (OperationCanceledException) when (_lifetime.IsCancellationRequested)
        {
            // Owned fixture shutdown deliberately cancels pending socket receives.
        }
    }

    public async ValueTask DisposeAsync()
    {
        _lifetime.Cancel();
        await Task.WhenAll(_requests, _replies);
        _clients.Dispose();
        _worker.Dispose();
        _lifetime.Dispose();
    }
}
