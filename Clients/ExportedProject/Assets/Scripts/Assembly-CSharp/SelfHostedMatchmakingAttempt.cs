using System;
using System.Threading;
using System.Threading.Tasks;
using War.Client;
using War.Protocol;

/// <summary>Owns one queue search and keeps its HTTP client alive until remote cancellation completes.</summary>
internal sealed class SelfHostedMatchmakingAttempt : IDisposable
{
    private readonly BackendClient _backend;
    private readonly string _accessToken;
    private readonly CancellationTokenSource _lifetime = new CancellationTokenSource();
    private readonly TaskCompletionSource<bool> _searchFinished =
        new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
    private Task _cancellation = Task.CompletedTask;
    private bool _hasCancellation;
    private bool _isDisposed;

    internal SelfHostedMatchmakingAttempt(BackendClient backend, string accessToken)
    {
        _backend = backend ?? throw new ArgumentNullException(nameof(backend));
        _accessToken = accessToken;
    }

    internal bool IsCancellationRequested { get { return _lifetime.IsCancellationRequested; } }

    internal async Task<MatchConnectionGrant> FindAsync(int timeoutSeconds)
    {
        try
        {
            return await _backend.FindMatchAsync(
                _accessToken, TimeSpan.FromSeconds(timeoutSeconds), _lifetime.Token);
        }
        finally
        {
            _searchFinished.TrySetResult(true);
        }
    }

    internal Task CancelAsync()
    {
        if (_isDisposed)
        {
            throw new ObjectDisposedException(nameof(SelfHostedMatchmakingAttempt));
        }

        if (!_hasCancellation || _cancellation.IsFaulted || _cancellation.IsCanceled)
        {
            // Publish the HTTP task before signaling FindAsync: its cleanup must wait for this request.
            _cancellation = CancelQueueAsync();
            _hasCancellation = true;
        }

        _lifetime.Cancel();
        return _cancellation;
    }

    private async Task CancelQueueAsync()
    {
        MatchQueueReply reply = await _backend.CancelMatchQueueAsync(_accessToken, CancellationToken.None);
        if ((reply.Code != "cancelled" && reply.Code != "not-queued") ||
            reply.MatchId.Length != 0 || reply.PlayerIds.Count != 0)
        {
            // Already-paired authority still needs its Worker/allocator cancellation; it is not a cleanup receipt.
            throw new InvalidOperationException("The Backend did not confirm matchmaking cancellation.");
        }
    }

    internal async Task CompleteAsync()
    {
        await _searchFinished.Task;
        if (_hasCancellation)
        {
            // Failed remote cleanup retains this attempt so the next cancel can retry before another join.
            await _cancellation;
        }

        Dispose();
    }

    /// <summary>Releases only this attempt; shutdown may also abort an outstanding HTTP cleanup.</summary>
    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        _isDisposed = true;
        _lifetime.Cancel();
        _backend.Dispose();
        _lifetime.Dispose();
    }
}
