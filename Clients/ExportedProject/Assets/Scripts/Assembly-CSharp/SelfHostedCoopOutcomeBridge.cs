using System;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Routes a confirmed shared mission result to the recovered scene finish callback.</summary>
public sealed class SelfHostedCoopOutcomeBridge : MonoBehaviour
{
    private SelfHostedBattleClient _client;
    private string _localPlayerId;
    private string _matchId;
    private string _manifestHash;
    private CoopOutcomeDelivery _delivery;
    private Action _onLocalKia;
    private Action _onPeerKia;
    private bool _hasPresentedKia;
    private bool _isPresentingKia;
    private bool _hasSharedOutcome;

    private void OnEnable()
    {
        SubscribeAndReplay();
    }

    private void OnDisable()
    {
        if (_client != null)
        {
            _client.StateReceived -= ApplySnapshot;
        }
    }

    /// <summary>Binds the admitted scene after its mission and UI startup have completed.</summary>
    public void Configure(SelfHostedBattleClient client, Action<ClientGameEndReason> onFinished,
        Action onLocalKia = null, Action onPeerKia = null)
    {
        if (_client != null || client == null || client.State == null)
        {
            throw new InvalidOperationException("One admitted co-op scene is required for result delivery.");
        }

        if (onFinished == null)
        {
            throw new ArgumentNullException(nameof(onFinished));
        }

        var delivery = new CoopOutcomeDelivery(client.State.MatchId, client.State.ManifestHash,
            client.LocalPlayerId, reason =>
            {
                _hasSharedOutcome = true;
                onFinished(reason);
            });
        _client = client;
        _localPlayerId = client.LocalPlayerId;
        _matchId = client.State.MatchId;
        _manifestHash = client.State.ManifestHash;
        _delivery = delivery;
        _onLocalKia = onLocalKia;
        _onPeerKia = onPeerKia;
        if (isActiveAndEnabled)
        {
            SubscribeAndReplay();
        }
    }

    /// <summary>Delivers only this scene's validated result on the adapter's Unity main thread.</summary>
    public void ApplySnapshot(MatchSnapshot snapshot)
    {
        if (_delivery == null || _client == null || _client.LocalPlayerId != _localPlayerId || snapshot == null)
        {
            return;
        }

        _delivery.ApplySnapshot(snapshot);
        PresentConfirmedKia(snapshot);
    }

    private void PresentConfirmedKia(MatchSnapshot snapshot)
    {
        if (_hasSharedOutcome || _hasPresentedKia || _isPresentingKia || snapshot.Phase != BattlePhase.Running ||
            snapshot.MatchId != _matchId || snapshot.ManifestHash != _manifestHash || snapshot.Coop == null ||
            string.IsNullOrEmpty(snapshot.Coop.MissionType))
        {
            return;
        }

        // ApplySnapshot has already validated this running source roster, including the living master.
        foreach (BattlePlayerState player in snapshot.Players)
        {
            if (player.PlayerId != snapshot.Coop.SceneMasterPlayerId && player.Dead && !player.CoopDeparted)
            {
                Action callback = player.PlayerId == _localPlayerId ? _onLocalKia : _onPeerKia;
                DeliverKia(callback);
                return;
            }
        }
    }

    private void DeliverKia(Action callback)
    {
        if (callback == null)
        {
            return;
        }

        _isPresentingKia = true;
        try
        {
            callback();
            _hasPresentedKia = true;
        }
        finally
        {
            _isPresentingKia = false;
        }
    }

    private void SubscribeAndReplay()
    {
        if (_client == null)
        {
            return;
        }

        _client.StateReceived -= ApplySnapshot;
        _client.StateReceived += ApplySnapshot;
        ApplySnapshot(_client.State);
    }
}
