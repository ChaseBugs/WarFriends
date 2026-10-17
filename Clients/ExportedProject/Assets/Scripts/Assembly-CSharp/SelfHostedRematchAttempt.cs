using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using War.Client;
using War.Protocol;

/// <summary>Owns one completed source match's consent, fresh grant and confirmed remote cancellation.</summary>
internal sealed class SelfHostedRematchAttempt : IDisposable
{
    private const int PollDelayMilliseconds = 250;
    private readonly object _gate = new object();
    private readonly BackendClient _backend;
    private readonly string _accessToken;
    private readonly string _sourceMatchId;
    private readonly string _playerId;
    private readonly string[] _players;
    private readonly CancellationTokenSource _lifetime = new CancellationTokenSource();
    private Task<MatchConnectionGrant> _finding;
    private Task _cancellation = Task.CompletedTask;
    private bool _isCancellationRequested;
    private bool _hasCancellation;
    private bool _isCancellationConfirmed;
    private bool _isDisposed;

    internal SelfHostedRematchAttempt(BackendClient backend, string accessToken,
        MatchSnapshot completedSource, string playerId)
    {
        SelfHostedRematchAuthority.RequireSource(completedSource, playerId);
        _backend = backend ?? throw new ArgumentNullException(nameof(backend));
        if (string.IsNullOrEmpty(accessToken))
        {
            throw new ArgumentException("Rematch requires the original authenticated session.", nameof(accessToken));
        }
        _accessToken = accessToken;
        _sourceMatchId = completedSource.MatchId;
        _playerId = playerId;
        _players = completedSource.Players.Select(player => player.PlayerId).ToArray();
    }

    internal bool IsCancellationRequested
    {
        get
        {
            lock (_gate)
            {
                return _isCancellationRequested;
            }
        }
    }

    internal bool IsCancellationConfirmed
    {
        get
        {
            lock (_gate)
            {
                return _isCancellationConfirmed;
            }
        }
    }

    internal Task<MatchConnectionGrant> FindAsync(CancellationToken cancellationToken)
    {
        Task<MatchConnectionGrant> finding;
        lock (_gate)
        {
            RequireUsable();
            if (_isCancellationRequested)
            {
                throw new OperationCanceledException("This source rematch is being cancelled.");
            }
            if (_finding == null || _finding.IsFaulted || _finding.IsCanceled)
            {
                _finding = FindCoreAsync(cancellationToken);
            }
            finding = _finding;
        }
        return CopyGrantAsync(finding, cancellationToken);
    }

    private async Task<MatchConnectionGrant> CopyGrantAsync(
        Task<MatchConnectionGrant> finding, CancellationToken cancellationToken)
    {
        MatchConnectionGrant grant = await finding;
        RequireDiscoveryOwner(cancellationToken);
        return grant.Clone();
    }

    internal Task CancelAsync()
    {
        Task cancellation;
        lock (_gate)
        {
            RequireUsable();
            _isCancellationRequested = true;
            if (_isCancellationConfirmed)
            {
                return Task.CompletedTask;
            }
            if (!_hasCancellation || _cancellation.IsFaulted || _cancellation.IsCanceled)
            {
                _hasCancellation = true;
                _cancellation = CancelCoreAsync();
            }
            cancellation = _cancellation;
        }
        // Stop local discovery only after publishing cleanup; a local abort is not a remote receipt.
        _lifetime.Cancel();
        return cancellation;
    }

    private async Task<MatchConnectionGrant> FindCoreAsync(CancellationToken cancellationToken)
    {
        using (var linked = CancellationTokenSource.CreateLinkedTokenSource(_lifetime.Token, cancellationToken))
        {
            CancellationToken token = linked.Token;
            MatchRematchConsent consent = await _backend.AcceptRematchAsync(_sourceMatchId, _accessToken, token);
            while (true)
            {
                RequireDiscoveryOwner(token);
                SelfHostedRematchAuthority.RequireConsent(consent, _sourceMatchId, _players);
                try
                {
                    if (consent.Status == "ready" || consent.Status == "allocated")
                    {
                        MatchConnectionGrant grant = await FindGrantAsync(token);
                        RequireDiscoveryOwner(token);
                        return grant;
                    }
                    if (consent.Status != "waiting")
                    {
                        throw new InvalidOperationException("The source rematch is no longer waiting for consent.");
                    }
                }
                catch (Exception failure) when (BackendClient.IsTransientFailure(failure) &&
                    !token.IsCancellationRequested)
                {
                    // A lost registration reply retries the same consumed source, never a random queue join.
                }
                await Task.Delay(PollDelayMilliseconds, token);
                consent = await _backend.ReadRematchConsentAsync(_sourceMatchId, _accessToken, token);
            }
        }
    }

    private async Task<MatchConnectionGrant> FindGrantAsync(CancellationToken token)
    {
        MatchQueueReply allocation = await _backend.AllocateRematchAsync(_sourceMatchId, _accessToken, token);
        SelfHostedRematchAuthority.RequireAllocation(allocation, _sourceMatchId, _players);
        MatchConnectionGrant grant = await _backend.MatchGrantAsync(allocation.MatchId, _accessToken, token);
        SelfHostedRematchAuthority.RequireGrant(grant, allocation, _playerId);
        return grant.Clone();
    }

    private async Task CancelCoreAsync()
    {
        // Cleanup survives discovery cancellation and remains retryable after an unavailable Backend.
        MatchRematchConsent consent = await _backend.CancelRematchAsync(
            _sourceMatchId, _accessToken, CancellationToken.None);
        SelfHostedRematchAuthority.RequireConsent(consent, _sourceMatchId, _players);
        if (consent.Status == "allocated")
        {
            MatchQueueReply cancelled = await _backend.CancelAllocatedRematchAsync(
                _sourceMatchId, _accessToken, CancellationToken.None);
            if (cancelled.MatchId != consent.NextMatchId || cancelled.PlayerIds.Count != 0 ||
                (cancelled.Code != "cancelled" && cancelled.Code != "completed"))
            {
                throw new InvalidOperationException(
                    "The Backend did not confirm this allocated rematch's cancellation.");
            }
        }
        else if (consent.Status != "cancelled" && consent.Status != "expired")
        {
            throw new InvalidOperationException("The Backend did not confirm source consent cancellation.");
        }
        lock (_gate)
        {
            _isCancellationConfirmed = true;
        }
    }

    private void RequireDiscoveryOwner(CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        lock (_gate)
        {
            RequireUsable();
            if (_isCancellationRequested)
            {
                throw new OperationCanceledException("Cancelled rematch discovery cannot deliver another grant.");
            }
        }
    }

    private void RequireUsable()
    {
        if (_isDisposed)
        {
            throw new ObjectDisposedException(nameof(SelfHostedRematchAttempt));
        }
    }

    /// <summary>Releases local resources only; disposal never confirms remote cancellation.</summary>
    public void Dispose()
    {
        lock (_gate)
        {
            if (_isDisposed)
            {
                return;
            }
            _isDisposed = true;
        }
        _lifetime.Cancel();
        _backend.Dispose();
        _lifetime.Dispose();
    }
}
