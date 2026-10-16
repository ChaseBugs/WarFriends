using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using War.Protocol;

/// <summary>Checks co-op snapshot delivery in Unity Mono without opening a room or changing assets.</summary>
public static class UnityCoopPeerBridgeAudit
{
    private const string LocalId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string RemoteId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";

    public static void Run()
    {
        GameObject owner = null;
        try
        {
            owner = new GameObject("CoopPeerBridgeAudit");
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId").SetValue(client, LocalId, null);
            VerifyDelivery(owner, client);
            VerifyFailedPresentationRetry(owner, client);
            string report = Path.Combine(Application.dataPath, "../coop-peer-bridge-audit.json");
            File.WriteAllText(report, "{\"schemaVersion\":1,\"checks\":6,\"unityVersion\":\"" +
                Application.unityVersion + "\",\"scope\":\"edit-mode event bridge\"}\n");
            Debug.Log("PASS: co-op peer bridge subscription, replay, re-enable and callback retry in Unity Mono.");
            UnityEngine.Object.DestroyImmediate(owner);
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            if (owner != null)
            {
                UnityEngine.Object.DestroyImmediate(owner);
            }

            EditorApplication.Exit(1);
        }
    }

    private static void VerifyDelivery(GameObject owner, SelfHostedBattleClient client)
    {
        int notifications = 0;
        SelfHostedCoopPeerBridge bridge = owner.AddComponent<SelfHostedCoopPeerBridge>();
        bridge.Configure(client, RemoteId, () => notifications++);
        Publish(client, CreateSnapshot(false, 1));
        Require(notifications == 0, "A running two-player mission must not show departure.");
        InvokeLifecycle(bridge, "OnDisable");
        Publish(client, CreateSnapshot(true, 2));
        Require(notifications == 0, "Disabling the bridge must unsubscribe it before departure.");
        InvokeLifecycle(bridge, "OnEnable");
        Publish(client, CreateSnapshot(true, 3));
        Require(notifications == 1, "Re-enabling the bridge must deliver the confirmed departure.");
        Publish(client, CreateSnapshot(true, 4));
        InvokeLifecycle(bridge, "OnDisable");
        InvokeLifecycle(bridge, "OnEnable");
        Publish(client, CreateSnapshot(true, 5));
        Require(notifications == 1, "Repeated polls and re-enable must not repeat source presentation.");
        InvokeLifecycle(bridge, "OnDisable");
        UnityEngine.Object.DestroyImmediate(bridge);
    }

    private static void VerifyFailedPresentationRetry(GameObject owner, SelfHostedBattleClient client)
    {
        int attempts = 0;
        SelfHostedCoopPeerBridge bridge = owner.AddComponent<SelfHostedCoopPeerBridge>();
        // Configure against a complete roster so its immediate state replay does not invoke the callback yet.
        Publish(client, CreateSnapshot(false, 6));
        bridge.Configure(client, RemoteId, () =>
        {
            attempts++;
            if (attempts == 1)
            {
                throw new InvalidOperationException("Expected first presentation failure.");
            }
        });
        try
        {
            bridge.ApplySnapshot(CreateSnapshot(true, 7));
            throw new Exception("The fixture did not expose its presentation failure.");
        }
        catch (InvalidOperationException)
        {
            Require(attempts == 1, "A failed presentation must execute exactly one attempt.");
        }

        bridge.ApplySnapshot(CreateSnapshot(true, 8));
        bridge.ApplySnapshot(CreateSnapshot(true, 9));
        Require(attempts == 2, "A failed callback must be retryable and a successful callback must remain idempotent.");
        InvokeLifecycle(bridge, "OnDisable");
        UnityEngine.Object.DestroyImmediate(bridge);
    }

    private static MatchSnapshot CreateSnapshot(bool departed, ulong revision)
    {
        var snapshot = new MatchSnapshot
        {
            Phase = BattlePhase.Running,
            StateRevision = revision,
            Coop = new BattleCoopState { Started = true }
        };
        snapshot.Players.Add(new BattlePlayerState { PlayerId = LocalId, Admitted = true, Ready = true });
        snapshot.Players.Add(new BattlePlayerState { PlayerId = RemoteId, Admitted = true, Ready = !departed });
        snapshot.Coop.ParticipantIds.Add(LocalId);
        if (!departed)
        {
            snapshot.Coop.ParticipantIds.Add(RemoteId);
        }

        return snapshot;
    }

    private static void Publish(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        typeof(SelfHostedBattleClient).GetMethod("Apply", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(client, new object[] { new MatchReply { Code = "state", Snapshot = snapshot } });
    }

    private static void InvokeLifecycle(SelfHostedCoopPeerBridge bridge, string method)
    {
        typeof(SelfHostedCoopPeerBridge).GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(bridge, null);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
