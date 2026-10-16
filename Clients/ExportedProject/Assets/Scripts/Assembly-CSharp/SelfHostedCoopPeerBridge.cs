using System;
using UnityEngine;
using War.Protocol;

/// <summary>Delivers one confirmed remote departure to the recovered co-op presentation callback.</summary>
public sealed class SelfHostedCoopPeerBridge : MonoBehaviour
{
    private SelfHostedBattleClient _client;
    private string _localPlayerId;
    private string _remotePlayerId;
    private Action _onPeerDeparture;
    private bool _hasPresentedDeparture;

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        if (_client != null)
        {
            _client.StateReceived -= ApplySnapshot;
        }
    }

    /// <summary>Binds one scene's peer after its recovered mission and UI have finished starting.</summary>
    public void Configure(SelfHostedBattleClient client, string remotePlayerId, Action onPeerDeparture)
    {
        if (_client != null || client == null || string.IsNullOrEmpty(client.LocalPlayerId) ||
            string.IsNullOrEmpty(remotePlayerId) || remotePlayerId == client.LocalPlayerId || onPeerDeparture == null)
        {
            throw new InvalidOperationException("One self-hosted co-op peer and presentation callback are required.");
        }

        _client = client;
        _localPlayerId = client.LocalPlayerId;
        _remotePlayerId = remotePlayerId;
        _onPeerDeparture = onPeerDeparture;
        if (isActiveAndEnabled)
        {
            Subscribe();
            ApplySnapshot(client.State);
        }
    }

    /// <summary>Ignores unrelated, incomplete and replayed states without changing mission results.</summary>
    public void ApplySnapshot(MatchSnapshot snapshot)
    {
        if (_hasPresentedDeparture || _client == null || _client.LocalPlayerId != _localPlayerId ||
            !SelfHostedCoopDepartureState.IsRemoteDeparture(snapshot, _localPlayerId, _remotePlayerId))
        {
            return;
        }

        _onPeerDeparture();
        _hasPresentedDeparture = true;
    }

    private void Subscribe()
    {
        if (_client != null)
        {
            _client.StateReceived -= ApplySnapshot;
            _client.StateReceived += ApplySnapshot;
        }
    }
}
