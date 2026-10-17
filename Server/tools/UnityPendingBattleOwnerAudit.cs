using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using War.Protocol;

/// <summary>Checks canonical pending-search ownership and the actual legacy controller timeout boundary.</summary>
public static class UnityPendingBattleOwnerAudit
{
    private const int SearchTimeoutSeconds = 90;
    private const float ExpiredDeadlineAgeSeconds = 1f;
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;

    /// <summary>Checks real search ownership without substituting menu, profile or gameplay implementations.</summary>
    public static async Task VerifyAsync(
        SelfHostedBattleClient client,
        string endpoint,
        string token,
        CancellationToken cancellationToken)
    {
        bool wasActive = client.gameObject.activeSelf;
        var foreignRoot = new GameObject("RejectedForeignSearchOwner");
        foreignRoot.SetActive(false);
        var foreign = foreignRoot.AddComponent<SelfHostedBattleClient>();
        try
        {
            client.gameObject.SetActive(false);
            Require(client.IsMatchmaking && client.OwnsBattleOperation && SelfHostedBattleClient.Active == client &&
                PhotonConnectionManager.GetOwnedSelfHostedClient() == client &&
                SelfHostedBattleClient.GetOrCreate() == client,
                "The inactive pending search lost canonical ownership.");
            Require(!PhotonConnectionManager.isInRoom && PhotonConnectionManager.GetPlayerCount() == 0 &&
                PhotonConnectionManager.GetNetworkTime() == 0 && PhotonConnectionManager.GetBattleId() == string.Empty,
                "A pending search exposed the previous battle as an admitted room.");
            RequireDirectAdmissionRejected(foreign);
            await RequireSearchRejectedAsync(foreign, endpoint, token, cancellationToken);
            VerifyControllerTimeouts(client);
            Require(client.IsMatchmaking && SelfHostedBattleClient.Active == client,
                "A stale controller timeout changed the real successor search.");
        }
        finally
        {
            client.gameObject.SetActive(wasActive);
            UnityEngine.Object.DestroyImmediate(foreignRoot);
        }

        Debug.Log("UNITY_PENDING_BATTLE_OWNER_PASSED inactiveOwner=True foreignRejected=True staleTimeoutBlocked=True");
    }

    private static void VerifyControllerTimeouts(SelfHostedBattleClient client)
    {
        var root = new GameObject("ActualExpiredRematchControllers");
        root.SetActive(false);
        PlayerController previousPlayer = PlayerController.currentPlayer;
        float previousDeadline = MatchManager.rematchExpireTime;
        try
        {
            var player = root.AddComponent<PlayerController>();
            player.networkStatus = new PlayerNetworkStatus(player);
            player.networkStatus.matchState = PlayerNetworkStatus.MatchState.Rematch;
            PlayerController.currentPlayer = player;
            MatchManager.rematchExpireTime = Time.realtimeSinceStartup - ExpiredDeadlineAgeSeconds;
            GameControllerOnline[] controllers =
            {
                root.AddComponent<GameControllerDeathMatch>(),
                root.AddComponent<GameControllerCoop>()
            };
            FieldInfo retained = typeof(GameControllerOnline).GetField("_selfHostedRematchClient", PrivateInstance);
            MethodInfo timeout = typeof(GameControllerOnline).GetMethod("UpdateLegacyRematchTimeout", PrivateInstance);
            foreach (GameControllerOnline controller in controllers)
            {
                retained.SetValue(controller, client);
                timeout.Invoke(controller, null);
                retained.SetValue(controller, null);
                timeout.Invoke(controller, null);
                Require(player.networkStatus.matchState == PlayerNetworkStatus.MatchState.Rematch,
                    "The expired legacy timer reset player state while another operation owned the battle.");
            }
        }
        finally
        {
            PlayerController.currentPlayer = previousPlayer;
            MatchManager.rematchExpireTime = previousDeadline;
            UnityEngine.Object.DestroyImmediate(root);
        }
    }

    private static void RequireDirectAdmissionRejected(SelfHostedBattleClient foreign)
    {
        try
        {
            foreign.Connect(new MatchConnectionGrant());
        }
        catch (InvalidOperationException failure)
        {
            RequireOwnerRejection(failure);
            return;
        }

        throw new InvalidOperationException("A foreign direct grant bypassed the canonical queue owner.");
    }

    private static async Task RequireSearchRejectedAsync(
        SelfHostedBattleClient foreign,
        string endpoint,
        string token,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        try
        {
            await foreign.MatchmakeAndConnect(endpoint, token, SearchTimeoutSeconds, true);
        }
        catch (InvalidOperationException failure)
        {
            RequireOwnerRejection(failure);
            Require(!foreign.IsMatchmaking, "The rejected foreign adapter still created a queue operation.");
            return;
        }

        throw new InvalidOperationException("A foreign search bypassed the canonical queue owner.");
    }

    private static void RequireOwnerRejection(InvalidOperationException failure)
    {
        Require(failure.Message == "Retained battle authority must complete before another admission.",
            "The foreign adapter reached grant or Backend dependencies before its ownership guard.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
