using System;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Routes a confirmed shared mission result to the recovered scene finish callback.</summary>
public sealed class SelfHostedCoopOutcomeBridge : MonoBehaviour
{
    private SelfHostedBattleClient _client;
    private string _localPlayerId;
    private CoopOutcomeDelivery _delivery;

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
    public void Configure(SelfHostedBattleClient client, Action<ClientGameEndReason> onFinished)
    {
        if (_client != null || client == null || client.State == null)
        {
            throw new InvalidOperationException("One admitted co-op scene is required for result delivery.");
        }

        var delivery = new CoopOutcomeDelivery(client.State.MatchId, client.State.ManifestHash,
            client.LocalPlayerId, onFinished);
        _client = client;
        _localPlayerId = client.LocalPlayerId;
        _delivery = delivery;
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
