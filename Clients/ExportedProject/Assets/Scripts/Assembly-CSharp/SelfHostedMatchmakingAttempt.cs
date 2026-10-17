using System;
using System.Threading;
using System.Threading.Tasks;
using War.Client;
using War.Protocol;

/// <summary>Owns one queue search and keeps its HTTP client alive until remote cancellation completes.</summary>
internal sealed class SelfHostedMatchmakingAttempt : IDisposable
{
    private const int MaximumLoadingCancellationAttempts = 3;
    private const int LoadingCancellationRetryDelayMilliseconds = 500;
    private readonly BackendClient _backend;
    private readonly string _accessToken;
    private readonly CancellationTokenSource _lifetime = new CancellationTokenSource();
    private readonly TaskCompletionSource<bool> _searchFinished =
        new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
    private Task<string> _attemptToken;
    private Task _cancellation = Task.CompletedTask;
    private Task _loadingCancellation;
    private bool _hasCancellation;
    private bool _hasSearch;
    private bool _hasGrant;
    private bool _isDisposed;

    internal SelfHostedMatchmakingAttempt(BackendClient backend, string accessToken)
    {
        _backend = backend ?? throw new ArgumentNullException(nameof(backend));
        _accessToken = accessToken;
    }

    internal bool IsCancellationRequested { get { return _lifetime.IsCancellationRequested; } }

    internal bool IsRetainedForLoading { get; private set; }

    internal async Task<MatchConnectionGrant> FindAsync(int timeoutSeconds)
    {
        if (_hasSearch)
        {
            throw new InvalidOperationException("A matchmaking attempt can start only one search.");
        }

        _hasSearch = true;
        try
        {
            _lifetime.Token.ThrowIfCancellationRequested();
            _attemptToken = AcquireAttemptTokenAsync();
            string attemptToken = await _attemptToken;
            _lifetime.Token.ThrowIfCancellationRequested();
            MatchConnectionGrant grant = await _backend.FindMatchAsync(
                _accessToken, attemptToken, TimeSpan.FromSeconds(timeoutSeconds), _lifetime.Token);
            _hasGrant = true;
            return grant;
        }
        finally
        {
            _searchFinished.TrySetResult(true);
        }
    }

    internal void RetainForLoading()
    {
        if (_isDisposed || !_hasGrant || IsCancellationRequested)
        {
            throw new InvalidOperationException("Only a successful current search can retain loading cancellation.");
        }

        IsRetainedForLoading = true;
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

    internal Task CancelLoadingWithRetryAsync(Func<bool> isCurrentOwner)
    {
        if (_loadingCancellation == null || _loadingCancellation.IsFaulted || _loadingCancellation.IsCanceled)
        {
            _loadingCancellation = CancelLoadingCoreAsync(isCurrentOwner);
        }

        return _loadingCancellation;
    }

    private async Task CancelLoadingCoreAsync(Func<bool> isCurrentOwner)
    {
        for (int i = 0; i < MaximumLoadingCancellationAttempts; i++)
        {
            if (_isDisposed || !IsRetainedForLoading || isCurrentOwner == null || !isCurrentOwner())
            {
                throw new OperationCanceledException("Loading cancellation no longer owns this match.");
            }

            try
            {
                await CancelAsync();
                return;
            }
            catch (Exception failure) when (BackendClient.IsTransientFailure(failure) &&
                i < MaximumLoadingCancellationAttempts - 1)
            {
                // Reuse the exact attempt credential; a temporary outage never authorizes another scope.
                await Task.Delay(LoadingCancellationRetryDelayMilliseconds);
            }
        }
    }

    private async Task<string> AcquireAttemptTokenAsync()
    {
        // Issuance cannot enqueue a player. Keep its bounded HTTP request alive so cleanup knows its scope.
        var grant = await _backend.CreateMatchQueueAttemptAsync(_accessToken, CancellationToken.None);
        if (string.IsNullOrWhiteSpace(grant.Token) || grant.ExpiresUnixSeconds <= 0)
        {
            throw new InvalidOperationException("The Backend returned an invalid queue attempt credential.");
        }

        return grant.Token;
    }

    private async Task CancelQueueAsync()
    {
        Task<string> pendingToken = _attemptToken;
        if (pendingToken == null)
        {
            // No credential request means this attempt could not submit a join.
            return;
        }

        string attemptToken;
        try
        {
            attemptToken = await pendingToken;
        }
        catch (Exception)
        {
            // A failed credential request cannot have reached FindMatchAsync or created a queue ticket.
            return;
        }

        MatchQueueReply reply = await _backend.CancelMatchQueueAsync(
            _accessToken, attemptToken, CancellationToken.None);
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

        if (!IsRetainedForLoading || _hasCancellation)
        {
            Dispose();
        }
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
