using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using War.Protocol;

public abstract partial class GameControllerOnline
{
    private const float RematchConsentTimeoutSeconds = 30f;
    private CancellationTokenSource _selfHostedRematchRequest;
    private SelfHostedBattleClient _selfHostedRematchClient;
    private bool _isRematchQuitPending;

    private void BeginSelfHostedRematch(SelfHostedBattleClient client)
    {
        RequireSelfHostedRematchSource(client);
        PrepareSelfHostedRematchLobby();
        var request = new CancellationTokenSource();
        _selfHostedRematchRequest = request;
        _selfHostedRematchClient = client;
        ConnectSelfHostedRematchAsync(client, request);
    }

    protected void RequireSelfHostedRematchSource()
    {
        SelfHostedBattleClient client = PhotonConnectionManager.GetOwnedSelfHostedClient();
        if (client != null)
        {
            RequireSelfHostedRematchSource(client);
        }
    }

    private void RequireSelfHostedRematchSource(SelfHostedBattleClient client)
    {
        if (_selfHostedRematchRequest != null || client.HasPendingRematch ||
            !client.OwnsMatch || client.State == null || client.State.Phase != BattlePhase.Ended)
        {
            throw new InvalidOperationException("Rematch requires an ended owner without another pending request.");
        }

        RequireAbortRecoveryComplete();
        SelfHostedRematchAuthority.RequireSource(client.State, client.LocalPlayerId);
        GameLoginManager login = Singleton<GameLoginManager>.instance;
        if (login == null || string.IsNullOrEmpty(login.accessToken))
        {
            throw new InvalidOperationException("The recovered Backend session is not available.");
        }
    }

    private async void ConnectSelfHostedRematchAsync(
        SelfHostedBattleClient client,
        CancellationTokenSource request)
    {
        Task admission = null;
        try
        {
            // Start the authenticated request before the recovered optimistic local Dog Tag update.
            admission = client.RematchWithRecoveredSessionAsync(request.Token);
            SpendDogtagLocaly();
            await admission;
            request.Token.ThrowIfCancellationRequested();
            if (_selfHostedRematchRequest != request || SelfHostedBattleClient.Active != client)
            {
                return;
            }

            Singleton<PhotonConnectionManager>.instance.CompleteSelfHostedJoin();
            if (!mBothPlayersConnected)
            {
                AllPlayersConnected();
            }
        }
        catch (OperationCanceledException)
        {
            // Quit or disable owns cleanup; a late admission cannot publish a replacement lobby.
            if (_selfHostedRematchRequest == request && !request.IsCancellationRequested)
            {
                client.LeaveMatch();
            }
        }
        catch (Exception failure)
        {
            // An unconfirmed remote operation remains owned by the adapter until scoped cleanup succeeds.
            if (_selfHostedRematchRequest == request)
            {
                client.LeaveMatch();
                Debug.LogError("Self-hosted rematch did not complete: " + failure);
            }
        }
        finally
        {
            if (admission != null)
            {
                await ObserveRematchCompletionAsync(admission);
            }

            if (_selfHostedRematchRequest == request)
            {
                _selfHostedRematchRequest = null;
            }

            request.Dispose();
        }
    }

    private static async Task ObserveRematchCompletionAsync(Task admission)
    {
        try
        {
            await admission;
        }
        catch (Exception)
        {
            // The owning catch handles failure; also observe admission if the local Dog Tag callback threw first.
        }
    }

    private bool HasSelfHostedBattleOperation
    {
        get
        {
            if (_selfHostedRematchRequest != null)
            {
                return true;
            }

            if (_selfHostedRematchClient != null && _selfHostedRematchClient.OwnsBattleOperation)
            {
                return true;
            }

            return PhotonConnectionManager.GetOwnedSelfHostedClient() != null;
        }
    }

    private void PrepareSelfHostedRematchLobby()
    {
        mShowWaitingForPlayer = false;
        MatchManager.matchState = MatchState.WaitingForOpponent;
        int mapId = mMapId;
        Reset();
        mMapIdSet = true;
        mMapId = mapId;
        isInMatch = true;
        PlayerController.currentPlayer.networkStatus.SetState(
            PlayerNetworkStatus.MatchState.Rematch,
            ++mStateUpdateCounter);
        MatchManager.rematchExpireTime = Time.realtimeSinceStartup + RematchConsentTimeoutSeconds;
    }

    private void UpdateLegacyRematchTimeout()
    {
        PlayerController player = PlayerController.currentPlayer;
        if (HasSelfHostedBattleOperation || player == null || player.networkStatus == null ||
            player.networkStatus.matchState != PlayerNetworkStatus.MatchState.Rematch ||
            mBothPlayersConnected || !(Time.realtimeSinceStartup > MatchManager.rematchExpireTime))
        {
            return;
        }

        Quit();
        LoadingDialog.Hide();
        MatchManager.matchState = MatchState.GameCancelled;
        bool isCoop = mMainController.isCoop || mMainController.isCoopBot;
        WarningDialog.ShowError(
            Localization.Localize(isCoop ? "ID_COOPCANCELED" : "ID_BATTLECANCELED"),
            Localization.Localize(isCoop ? "ID_FRIENDREFUSEDREMATCHCOOP" : "ID_OPPONENTREFUSEDTHEREMATCH"),
            0f,
            delegate
            {
                Singleton<GuiManager>.instance.ShowMainScreen();
                LoadingDialog.Hide();
            },
            string.Empty);
        PlayerController.currentPlayer.networkStatus.Reset();
        GuiElementSingle<WarningDialog>.instance.HideDialog();
    }

    private void CancelSelfHostedRematchRequest()
    {
        CancellationTokenSource request = _selfHostedRematchRequest;
        SelfHostedBattleClient client = _selfHostedRematchClient;
        _selfHostedRematchRequest = null;
        _selfHostedRematchClient = null;
        if (request != null)
        {
            request.Cancel();
        }

        if (client != null && client.HasPendingRematch)
        {
            client.LeaveMatch();
        }
    }

    private async void QuitSelfHostedRematchAsync(SelfHostedBattleClient client)
    {
        if (_isRematchQuitPending)
        {
            return;
        }

        _isRematchQuitPending = true;
        try
        {
            bool released = await client.CancelRematchAndReleaseAsync();
            if (this == null || !released || _selfHostedRematchClient != client)
            {
                return;
            }

            // A local reset is not evidence that the reserved remote pair was released.
            CancelSelfHostedRematchRequest();
            CompleteLocalQuit();
        }
        catch (Exception failure)
        {
            Debug.LogError("Self-hosted rematch cancellation was not confirmed: " + failure);
        }
        finally
        {
            _isRematchQuitPending = false;
        }
    }
}
