using System;
using System.Threading;
using System.Threading.Tasks;
using War.Client;
using War.Protocol;

public sealed partial class SelfHostedBattleClient
{
    private SelfHostedRematchAttempt _rematchAttempt;
    private Task _rematchConnecting;
    private MatchConnectionGrant _preparedRematchGrant;
    private string _rematchSourceId;
    private string _rematchSourcePlayerId;
    private bool _isRematchSourceReleased;
    private bool _hasRematchAdmissionStarted;

    /// <summary>Includes retained queue and rematch authority while no UDP connection is assigned.</summary>
    public bool OwnsBattleOperation
    {
        get
        {
            return OwnsMatch || matchmaking != null || _rematchAttempt != null;
        }
    }

    /// <summary>Retains a rematch until cancellation is confirmed or the admitted match starts.</summary>
    public bool HasPendingRematch
    {
        get
        {
            return _rematchAttempt != null;
        }
    }

    /// <summary>Uses the existing login session and configured offline Backend for a fresh rematch.</summary>
    public Task RematchWithRecoveredSessionAsync(CancellationToken cancellationToken)
    {
        GameLoginManager login = Singleton<GameLoginManager>.instance;
        if (login == null || string.IsNullOrEmpty(login.accessToken))
        {
            throw new InvalidOperationException("The recovered Backend session is not available.");
        }

        return RematchAndConnectAsync(backendEndpoint, login.accessToken, allowLocalHttp, cancellationToken);
    }

    /// <summary>Finds and admits a same-opponent grant while keeping the original result until handoff.</summary>
    public Task RematchAndConnectAsync(
        string endpoint,
        string accessToken,
        bool allowLoopbackHttp,
        CancellationToken cancellationToken)
    {
        RequireAbortRecoveryReleased();
        RequireNoPendingRematch();
        RequireEndedRematchSource();
        var backend = new BackendClient(new Uri(endpoint), allowLoopbackHttp);
        try
        {
            _rematchAttempt = new SelfHostedRematchAttempt(backend, accessToken, State, LocalPlayerId);
        }
        catch
        {
            backend.Dispose();
            throw;
        }
        _rematchSourceId = State.MatchId;
        _rematchSourcePlayerId = LocalPlayerId;
        _isRematchSourceReleased = false;
        _hasRematchAdmissionStarted = false;
        _rematchConnecting = RunRematchHandoffAsync(_rematchAttempt, cancellationToken);
        return _rematchConnecting;
    }

    /// <summary>Retries only a retained pre-admission operation, including a failed local close callback.</summary>
    public Task RetryRematchHandoffAsync(CancellationToken cancellationToken)
    {
        if (_rematchAttempt == null || _hasRematchAdmissionStarted)
        {
            throw new InvalidOperationException("No pre-admission handoff can be retried; retain scoped cleanup.");
        }
        if (_rematchConnecting == null || _rematchConnecting.IsCompleted)
        {
            _rematchConnecting = RunRematchHandoffAsync(_rematchAttempt, cancellationToken);
        }
        return _rematchConnecting;
    }

    /// <summary>Confirms remote cleanup without closing the transport before its caller handles the receipt.</summary>
    public Task CancelRematchAsync()
    {
        if (_rematchAttempt == null)
        {
            throw new InvalidOperationException("There is no retained source rematch to cancel.");
        }
        if (OwnsPreparedRematch() && State != null &&
            (State.Phase == BattlePhase.Running || State.Phase == BattlePhase.Ended))
        {
            throw new InvalidOperationException("A started rematch cannot use prestart cancellation.");
        }
        return _rematchAttempt.CancelAsync();
    }

    internal async Task<bool> CancelRematchAndReleaseAsync()
    {
        SelfHostedRematchAttempt attempt = _rematchAttempt;
        await CancelRematchAsync();
        if (destroyed || !attempt.IsCancellationConfirmed || Active != null && Active != this)
        {
            return false;
        }

        if (_rematchAttempt == attempt)
        {
            Close();
        }

        // MatchClosed can synchronously start a successor; recheck ownership after every callback.
        // Disconnect may also have observed the same receipt before this continuation resumed.
        return _rematchAttempt == null && connection == null && matchmaking == null && Active == null;
    }

    private async Task RunRematchHandoffAsync(SelfHostedRematchAttempt attempt, CancellationToken cancellationToken)
    {
        RequireCurrentRematch(attempt);
        MatchConnectionGrant grant = await attempt.FindAsync(cancellationToken);
        RequireCurrentRematch(attempt);
        MatchConnection.ValidateGrantEnvelope(grant);
        _preparedRematchGrant = grant.Clone();
        if (!_isRematchSourceReleased)
        {
            RequireEndedRematchSource();
            if (State.MatchId != _rematchSourceId || LocalPlayerId != _rematchSourcePlayerId)
            {
                throw new InvalidOperationException("The original rematch transport was replaced.");
            }
            try
            {
                Close();
            }
            finally
            {
                // A MatchClosed callback can throw after transport disposal; keep the grant and operation.
                _isRematchSourceReleased = connection == null;
            }
        }
        RequireCurrentRematch(attempt);
        if (connection != null)
        {
            throw new InvalidOperationException("A replacement transport already owns this adapter.");
        }
        _hasRematchAdmissionStarted = true;
        await ConnectCoreAsync(grant, 0);
        RequireCurrentRematch(attempt);
        ReleaseRematchAfterStart();
    }

    private void RequireCurrentRematch(SelfHostedRematchAttempt attempt)
    {
        if (destroyed || Active != this || _rematchAttempt != attempt || attempt.IsCancellationRequested)
        {
            throw new OperationCanceledException("The source rematch no longer owns this handoff.");
        }
    }

    private void RequireEndedRematchSource()
    {
        if (destroyed || Active != this || !OwnsMatch || State == null || State.Phase != BattlePhase.Ended)
        {
            throw new InvalidOperationException("Rematch handoff requires the current confirmed ended transport.");
        }
    }

    private void RequireNoPendingRematch()
    {
        if (_rematchAttempt != null || Active != null && Active != this && Active.OwnsBattleOperation)
        {
            throw new InvalidOperationException("Retained battle authority must complete before another admission.");
        }
    }

    private bool OwnsPreparedRematch()
    {
        return connection != null && _preparedRematchGrant != null && matchId == _preparedRematchGrant.MatchId;
    }

    private void ReleaseRematchAfterStart()
    {
        if (OwnsPreparedRematch() && IsConnected && State != null &&
            (State.Phase == BattlePhase.Running || State.Phase == BattlePhase.Ended))
        {
            ReleaseRematchOperation();
        }
    }

    private void ReleaseRematchOperation()
    {
        SelfHostedRematchAttempt previous = _rematchAttempt;
        _rematchAttempt = null;
        _rematchConnecting = null;
        _preparedRematchGrant = null;
        _rematchSourceId = null;
        _rematchSourcePlayerId = null;
        _isRematchSourceReleased = false;
        _hasRematchAdmissionStarted = false;
        if (previous != null)
        {
            previous.Dispose();
        }
    }

    private async void ObserveRematchLeaveAsync(SelfHostedRematchAttempt attempt)
    {
        try
        {
            await CancelRematchAsync();
            if (!destroyed && !_isAbortRecoverySuspended && _rematchAttempt == attempt &&
                attempt.IsCancellationConfirmed)
            {
                Close();
            }
        }
        catch (Exception failure)
        {
            // Failed cleanup keeps the canonical owner; a new queue operation remains blocked.
            if (!destroyed && _rematchAttempt == attempt && ConnectionError != null)
            {
                ConnectionError(failure.Message);
            }
        }
    }
}
