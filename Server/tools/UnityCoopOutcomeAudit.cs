using System;
using System.IO;
using System.Reflection;
using Google.Protobuf;
using UnityEditor;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks portable co-op result projection in Unity Mono without rendering or changing game assets.</summary>
public static class UnityCoopOutcomeAudit
{
    private const string MasterId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string PeerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";

    /// <summary>Runs portable projection and Unity event bridge checks without rendering result UI.</summary>
    public static void Run()
    {
        try
        {
            Require((byte)ClientGameEndReason.Kia == 8 && (byte)ClientGameEndReason.MissionFailed == 9 &&
                (byte)ClientGameEndReason.MissionSuccess == 10, "Presentation codes must match the recovered enum.");
            VerifySuccessAndSpectating();
            VerifyMasterFailure();
            VerifyForfeit();
            VerifyDepartedPeer();
            VerifyMalformedResults();
            VerifyBridgeLifecycle();
            File.WriteAllText(Path.Combine(Application.dataPath, "../coop-outcome-unity-audit.json"),
                "{\"schemaVersion\":3,\"checks\":23,\"scope\":\"edit-mode SDK projection and event bridge\"}\n");
            Debug.Log("PASS: 23 co-op projection and event bridge checks; no rendered result UI or rewards applied.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void VerifyBridgeLifecycle()
    {
        var owner = new GameObject("CoopOutcomeBridgeAudit");
        try
        {
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId").SetValue(client, MasterId, null);
            VerifySubscribedDelivery(owner, client);
            VerifyImmediateReplay(owner, client);
            VerifyLocalKiaAndSharedFinish(owner, client);
            VerifyRemoteKia(owner, client);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static void VerifySubscribedDelivery(GameObject owner, SelfHostedBattleClient client)
    {
        MatchSnapshot running = CreateBridgeSnapshot();
        SetUnsuccessful(running, "");
        running.Coop.Failed = false;
        running.Phase = BattlePhase.Running;
        running.EndTick = 0;
        Publish(client, running);
        int callbacks = 0;
        SelfHostedCoopOutcomeBridge bridge = owner.AddComponent<SelfHostedCoopOutcomeBridge>();
        bridge.Configure(client, reason =>
        {
            Require(reason == ClientGameEndReason.MissionSuccess, "The bridge must preserve the shared result.");
            callbacks++;
        });
        Require(callbacks == 0, "Binding a running mission must not finish it.");
        InvokeLifecycle(bridge, "OnDisable");
        Publish(client, CreateBridgeSnapshot());
        Require(callbacks == 0, "Disabled result bridges must unsubscribe.");
        InvokeLifecycle(bridge, "OnEnable");
        Require(callbacks == 1, "Re-enable must replay the terminal state missed while disabled.");
        Publish(client, CreateBridgeSnapshot());
        Require(callbacks == 1, "Repeated terminal polls must not finish twice.");
        InvokeLifecycle(bridge, "OnDisable");
        UnityEngine.Object.DestroyImmediate(bridge);
    }

    private static void VerifyImmediateReplay(GameObject owner, SelfHostedBattleClient client)
    {
        int callbacks = 0;
        SelfHostedCoopOutcomeBridge bridge = owner.AddComponent<SelfHostedCoopOutcomeBridge>();
        bridge.Configure(client, reason => callbacks++);
        Require(callbacks == 1, "Configure must replay an already received terminal result.");
        InvokeLifecycle(bridge, "OnDisable");
        InvokeLifecycle(bridge, "OnEnable");
        Require(callbacks == 1, "Re-enable must retain successful delivery history.");
        InvokeLifecycle(bridge, "OnDisable");
        UnityEngine.Object.DestroyImmediate(bridge);
    }

    private static void VerifyLocalKiaAndSharedFinish(GameObject owner, SelfHostedBattleClient client)
    {
        typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId").SetValue(client, PeerId, null);
        Publish(client, CreateRunningBridgeSnapshot(false));
        int localKia = 0;
        int peerKia = 0;
        int finishes = 0;
        SelfHostedCoopOutcomeBridge bridge = owner.AddComponent<SelfHostedCoopOutcomeBridge>();
        bridge.Configure(client, reason => finishes++, () =>
        {
            localKia++;
            bridge.ApplySnapshot(CreateRunningBridgeSnapshot(true));
        }, () => peerKia++);
        Require(localKia == 0 && peerKia == 0, "A living roster must not show KIA.");
        InvokeLifecycle(bridge, "OnDisable");
        Publish(client, CreateRunningBridgeSnapshot(true));
        Require(localKia == 0, "Disabled KIA presentation must not receive death.");
        InvokeLifecycle(bridge, "OnEnable");
        Require(localKia == 1 && peerKia == 0 && finishes == 0,
            "A missed peer KIA must replay once without reentrant presentation or shared finish.");
        Publish(client, CreateRunningBridgeSnapshot(true));
        Require(localKia == 1, "Repeated KIA polls must not restart the spectator coroutine.");
        MatchSnapshot success = CreateBridgeSnapshot();
        SetPeerKia(success);
        Publish(client, success);
        Publish(client, CreateRunningBridgeSnapshot(true));
        Require(finishes == 1 && localKia == 1, "Shared finish must supersede spectator presentation once.");
        InvokeLifecycle(bridge, "OnDisable");
        UnityEngine.Object.DestroyImmediate(bridge);
    }

    private static void VerifyRemoteKia(GameObject owner, SelfHostedBattleClient client)
    {
        typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId").SetValue(client, MasterId, null);
        Publish(client, CreateRunningBridgeSnapshot(false));
        int localKia = 0;
        int peerKia = 0;
        SelfHostedCoopOutcomeBridge bridge = owner.AddComponent<SelfHostedCoopOutcomeBridge>();
        bridge.Configure(client, reason => { }, () => localKia++, () => peerKia++);
        VerifyMalformedKia(bridge);
        MatchSnapshot foreign = CreateRunningBridgeSnapshot(true);
        foreign.MatchId = "another-match";
        bridge.ApplySnapshot(foreign);
        Require(localKia == 0 && peerKia == 0, "Another match must not trigger peer KIA.");
        Publish(client, CreateRunningBridgeSnapshot(true));
        Publish(client, CreateRunningBridgeSnapshot(true));
        Require(localKia == 0 && peerKia == 1, "The master must receive only one partner-died notification.");
        InvokeLifecycle(bridge, "OnDisable");
        UnityEngine.Object.DestroyImmediate(bridge);
    }

    private static void VerifyMalformedKia(SelfHostedCoopOutcomeBridge bridge)
    {
        MatchSnapshot malformed = CreateRunningBridgeSnapshot(true);
        malformed.Players[1].ClearCoopDeathTick();
        try
        {
            bridge.ApplySnapshot(malformed);
        }
        catch (Exception failure)
        {
            if (failure.GetType().FullName == "System.IO.InvalidDataException")
            {
                return;
            }

            throw;
        }

        throw new Exception("A missing source death tick must not select KIA presentation.");
    }

    private static MatchSnapshot CreateRunningBridgeSnapshot(bool hasPeerKia)
    {
        MatchSnapshot snapshot = CreateBridgeSnapshot();
        SetUnsuccessful(snapshot, "");
        snapshot.Coop.Failed = false;
        snapshot.Phase = BattlePhase.Running;
        snapshot.EndTick = 0;
        if (hasPeerKia)
        {
            SetPeerKia(snapshot);
        }

        return snapshot;
    }

    private static MatchSnapshot CreateBridgeSnapshot()
    {
        MatchSnapshot snapshot = CreateSuccess();
        snapshot.MatchId = "outcome-bridge-match";
        snapshot.ManifestHash = "outcome-bridge-manifest";
        return snapshot;
    }

    private static void Publish(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        typeof(SelfHostedBattleClient).GetMethod("Apply", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(client, new object[] { new MatchReply { Code = "state", Snapshot = snapshot } });
    }

    private static void InvokeLifecycle(SelfHostedCoopOutcomeBridge bridge, string method)
    {
        typeof(SelfHostedCoopOutcomeBridge).GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(bridge, null);
    }

    private static void VerifySuccessAndSpectating()
    {
        MatchSnapshot success = CreateSuccess();
        Require(MatchOutcomeProjection.ForPlayer(success, MasterId) == ClientGameEndReason.MissionSuccess &&
            MatchOutcomeProjection.ForPlayer(success, PeerId) == ClientGameEndReason.MissionSuccess,
            "Both connected players must receive the shared source success reason.");
        MatchSnapshot spectating = CreateSuccess();
        SetPeerKia(spectating);
        SetUnsuccessful(spectating, "");
        spectating.Coop.Failed = false;
        spectating.Phase = BattlePhase.Running;
        spectating.EndTick = 0;
        Require(MatchOutcomeProjection.ForPlayer(spectating, PeerId) == ClientGameEndReason.None,
            "A running peer's private KIA screen must not become a shared terminal result.");
        SetPeerKia(success);
        Require(MatchOutcomeProjection.ForPlayer(success, PeerId) == ClientGameEndReason.MissionSuccess,
            "The shared finish RPC supersedes the connected peer's prior KIA presentation.");
    }

    private static void SetPeerKia(MatchSnapshot snapshot)
    {
        snapshot.Players[1].Dead = true;
        snapshot.Players[1].Health = 0;
        snapshot.Players[1].DamageRevision = 1;
        snapshot.Players[1].CoopDeathTick = 0;
    }

    private static void VerifyMasterFailure()
    {
        MatchSnapshot failure = CreateMasterFailure();
        failure = MatchSnapshot.Parser.ParseFrom(failure.ToByteArray());
        Require(failure.Players[0].HasCoopDeathTick && failure.Players[0].CoopDeathTick == 0 &&
            MatchOutcomeProjection.ForPlayer(failure, MasterId) == ClientGameEndReason.MissionFailed &&
            MatchOutcomeProjection.ForPlayer(failure, PeerId) == ClientGameEndReason.MissionFailed,
            "A real tick-zero master KIA must project shared failure after native protobuf round trip.");
    }

    private static MatchSnapshot CreateMasterFailure()
    {
        MatchSnapshot failure = CreateSuccess();
        SetUnsuccessful(failure, "mission-failed");
        failure.ServerTick = 0;
        failure.EndTick = 0;
        failure.Players[0].Health = 0;
        failure.Players[0].Dead = true;
        failure.Players[0].DamageRevision = 1;
        failure.Players[0].CoopDeathTick = 0;
        return failure;
    }

    private static void VerifyForfeit()
    {
        MatchSnapshot forfeit = CreateSuccess();
        SetUnsuccessful(forfeit, "forfeit");
        forfeit.Players[0].CoopDeparted = true;
        forfeit.Players[0].Ready = false;
        forfeit.Coop.ParticipantIds.Remove(MasterId);
        Require(MatchOutcomeProjection.ForPlayer(forfeit, MasterId) == ClientGameEndReason.Forfeit &&
            MatchOutcomeProjection.ForPlayer(forfeit, PeerId) == ClientGameEndReason.Forfeit,
            "Source master departure must not grant its peer a PvP WinByForfeit.");
    }

    private static void VerifyDepartedPeer()
    {
        MatchSnapshot success = CreateSuccess();
        success.Players[1].CoopDeparted = true;
        success.Players[1].Ready = false;
        success.Coop.ParticipantIds.Remove(PeerId);
        success.Coop.PeerCompletionPlayerIds.Clear();
        Require(MatchOutcomeProjection.ForPlayer(success, PeerId) == ClientGameEndReason.Forfeit &&
            MatchOutcomeProjection.ForPlayer(success, MasterId) == ClientGameEndReason.MissionSuccess,
            "The surviving master's later success cannot resurrect a departed peer.");
    }

    private static void VerifyMalformedResults()
    {
        MatchSnapshot winner = CreateSuccess();
        winner.WinnerPlayerId = MasterId;
        RequireInvalid(winner);
        MatchSnapshot missingDeath = CreateMasterFailure();
        missingDeath.Players[0].ClearCoopDeathTick();
        RequireInvalid(missingDeath);
    }

    private static MatchSnapshot CreateSuccess()
    {
        var snapshot = new MatchSnapshot
        {
            Phase = BattlePhase.Ended, TerminalReason = "mission-success", ServerTick = 10, EndTick = 10,
            Coop = new BattleCoopState
            {
                MissionType = "KillXEnemies", Started = true, Completed = true,
                DeadlineTick = 100, SceneMasterPlayerId = MasterId
            }
        };
        foreach (string playerId in new[] { MasterId, PeerId })
        {
            snapshot.Players.Add(new BattlePlayerState
            {
                PlayerId = playerId, Admitted = true, Ready = true, Health = 100, MaxHealth = 100
            });
            snapshot.Coop.ParticipantIds.Add(playerId);
        }
        snapshot.Coop.SuccessScores.Add(new BattleCoopPlayerScore { PlayerId = MasterId, Score = 100, Stars = 1 });
        snapshot.Coop.PeerCompletionPlayerIds.Add(PeerId);
        return snapshot;
    }

    private static void SetUnsuccessful(MatchSnapshot snapshot, string reason)
    {
        snapshot.TerminalReason = reason;
        snapshot.Coop.Completed = false;
        snapshot.Coop.Failed = true;
        snapshot.Coop.SuccessScores.Clear();
        snapshot.Coop.PeerCompletionPlayerIds.Clear();
    }

    private static void RequireInvalid(MatchSnapshot snapshot)
    {
        try
        {
            MatchOutcomeProjection.ForPlayer(snapshot, MasterId);
        }
        catch (Exception failure)
        {
            // The recovered AWS assembly duplicates InvalidDataException's source name; inspect SDK runtime identity.
            if (failure.GetType().FullName == "System.IO.InvalidDataException")
            {
                return;
            }
            throw;
        }
        throw new Exception("Malformed co-op data selected a native Client result.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
