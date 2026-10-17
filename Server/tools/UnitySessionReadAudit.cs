using System;
using System.Reflection;
using Google.Protobuf;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks idle, local-model and retained inactive-owner reads without a Photon fallback.</summary>
public static class UnitySessionReadAudit
{
    private const BindingFlags InstanceFields = BindingFlags.Instance | BindingFlags.NonPublic;
    private const string MatchId = "session-read-fixture";
    private const int SessionKeyBytes = 32;
    private const int GrantLifetimeSeconds = 60;

    /// <summary>Requires canonical owned snapshots and the recovered unsigned local millisecond clock.</summary>
    public static void Verify()
    {
        var room = (LocalOfflineRoom)typeof(PhotonConnectionManager)
            .GetField("mLocalOfflineRoom", BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
        Require(SelfHostedBattleClient.Active == null && !room.IsOffline,
            "The isolated session-read audit must not replace an existing owner or solo room.");
        GameObject ownerRoot = null;
        SelfHostedBattleClient client = null;
        try
        {
            VerifyIdle();
            UnityCachedRpcAudit.VerifyRegistry();
            room.JoinSoloRoom();
            Require(PhotonConnectionManager.isInRoom && PhotonConnectionManager.IsLocalSoloRoom &&
                PhotonConnectionManager.GetPlayerCount() == 1 && PhotonConnectionManager.GetBattleId().Length == 0,
                "Local model reads lost their single-player membership or invented a server battle ID.");
            room.Disconnect();
            ownerRoot = new GameObject("InactiveSessionReadOwner");
            ownerRoot.SetActive(false);
            client = ownerRoot.AddComponent<SelfHostedBattleClient>();
            var grant = new MatchConnectionGrant
            {
                Host = "127.0.0.1", Port = 30000, SessionId = 1, MatchId = MatchId,
                PlayerId = new string('a', 32), ManifestHash = new string('b', 64),
                SessionKey = ByteString.CopyFrom(new byte[SessionKeyBytes]), Ticket = "fixture-ticket",
                ExpiresUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + GrantLifetimeSeconds
            };
            typeof(SelfHostedBattleClient).GetField("connection", InstanceFields)
                .SetValue(client, new MatchConnection(grant));
            typeof(SelfHostedBattleClient).GetProperty("Active").SetValue(null, client, null);
            Require(PhotonConnectionManager.IsSelfHostedActive && PhotonConnectionManager.isInRoom &&
                PhotonConnectionManager.GetNetworkTime() == 0 && PhotonConnectionManager.GetPlayerCount() == 0 &&
                PhotonConnectionManager.GetBattleId().Length == 0,
                "An owned session without a snapshot borrowed unrelated clock or room authority.");
            var snapshot = new MatchSnapshot { MatchId = MatchId, ServerTick = 75 };
            snapshot.Players.Add(new BattlePlayerState { PlayerId = grant.PlayerId });
            snapshot.Players.Add(new BattlePlayerState { PlayerId = new string('c', 32) });
            typeof(SelfHostedBattleClient).GetProperty("State").SetValue(client, snapshot, null);
            Require(PhotonConnectionManager.GetNetworkTime() == 2.5 && PhotonConnectionManager.GetPlayerCount() == 2 &&
                PhotonConnectionManager.GetBattleId() == MatchId && SelfHostedBattleClient.GetOrCreate() == client,
                "An inactive retained owner fell back to Photon or created a replacement adapter.");
            UnityCachedRpcAudit.VerifyOwnedBoundary();
            UnityControllerOwnerAudit.Verify(client);
            UnityStartPresentationAudit.Verify(client);
            PhotonConnectionManager.Disconnect();
            Require(!client.OwnsMatch,
                "Disconnect ignored the inactive canonical self-hosted owner.");
            VerifyIdle();
            Debug.Log("PASS: idle/local-model/owned reads avoid Photon fallback, preserve unsigned local time, " +
                "keep missing snapshots unknown and reuse/disconnect the inactive canonical owner; " +
                "controlled snapshots only.");
        }
        finally
        {
            if (client != null)
            {
                client.LeaveMatch();
            }
            if (ownerRoot != null)
            {
                UnityEngine.Object.DestroyImmediate(ownerRoot);
            }
            room.Disconnect();
        }
    }

    private static void VerifyIdle()
    {
        double before = unchecked((uint)Environment.TickCount) / 1000.0;
        double observed = PhotonConnectionManager.GetNetworkTime();
        double after = unchecked((uint)Environment.TickCount) / 1000.0;
        bool isWithinClockWindow = before <= after ? observed >= before && observed <= after :
            observed >= before || observed <= after;
        Require(isWithinClockWindow && !PhotonConnectionManager.isInRoom &&
            PhotonConnectionManager.GetPlayerCount() == 0 && PhotonConnectionManager.GetBattleId().Length == 0,
            "Idle reads changed the recovered clock epoch or exposed an unrelated room.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
