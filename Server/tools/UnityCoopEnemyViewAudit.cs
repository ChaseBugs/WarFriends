using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks portable enemy views and adapter publication without creating or simulating enemy actors.</summary>
public static class UnityCoopEnemyViewAudit
{
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string PeerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private static int _checks;

    /// <summary>Runs common-field and callback ordering checks using the current SDK in Unity Mono.</summary>
    public static void Run()
    {
        _checks = 0;
        var owner = new GameObject("CoopEnemyViewAudit");
        owner.SetActive(false);
        try
        {
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId").SetValue(client, PlayerId, null);
            VerifyPublication(client);
            File.WriteAllText(Path.Combine(Application.dataPath, "../coop-enemy-view-audit.json"),
                "{\"schemaVersion\":1,\"checks\":" + _checks + ",\"scope\":\"common enemy view and adapter\"}\n");
            Debug.Log("PASS: " + _checks + " co-op enemy view checks; no enemy actors, combat or rendering.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static void VerifyPublication(SelfHostedBattleClient client)
    {
        IReadOnlyList<CoopEnemyViewState> received = null;
        bool hasObservedOrder = false;
        int notifications = 0;
        client.CoopEnemiesReceived += views => { received = views; notifications++; };
        client.StateReceived += state => hasObservedOrder = received != null && notifications == 1;
        MatchSnapshot snapshot = CreateSnapshot();
        Publish(client, snapshot);
        Require(received != null && received.Count == 1 && received[0].EntityId == 1 && received[0].Health == 100,
            "The adapter must publish the confirmed common enemy body view.");
        Require(hasObservedOrder, "Enemy presentation must precede generic state and outcome subscribers.");
        snapshot.Coop.EnemySpawns[0].CurrentX = 99;
        Require(client.CoopEnemies[0].X == 1f, "Changing the incoming packet must not change published actors.");
        BattleJointRotation copy = received[0].Rotation;
        copy.W = 0;
        Require(received[0].Rotation.W == 1f, "A consumer must not mutate another subscriber's rotation.");
        VerifyInvalidPublication(client, () => notifications);
        MatchSnapshot death = CreateSnapshot();
        death.Coop.EnemySpawns[0].Health = 0;
        death.Coop.EnemySpawns[0].DeathTick = 12;
        Publish(client, death);
        Require(client.CoopEnemies[0].IsDead && client.CoopEnemies[0].DeathTick == 12,
            "A replayable body death must retain its exact host tick for future animation timing.");
        client.LeaveMatch();
        Require(client.CoopEnemies.Count == 0, "Connection close must clear the active enemy view.");
    }

    private static void VerifyInvalidPublication(SelfHostedBattleClient client, Func<int> getNotifications)
    {
        MatchSnapshot before = client.State.Clone();
        MatchSnapshot malformed = CreateSnapshot();
        malformed.ServerTick++;
        malformed.Coop.EnemySpawns[0].CurrentX = float.NaN;
        bool hasRejected = false;
        try
        {
            Publish(client, malformed);
        }
        catch (TargetInvocationException failure)
        {
            if (failure.InnerException == null ||
                failure.InnerException.GetType().FullName != "System.IO.InvalidDataException")
            {
                throw;
            }

            hasRejected = true;
        }

        Require(hasRejected && client.State.Equals(before) && client.CoopEnemies[0].X == 1f && getNotifications() == 1,
            "Rejected enemy rows must not partially replace adapter state or its presentation view.");
    }

    private static MatchSnapshot CreateSnapshot()
    {
        var snapshot = new MatchSnapshot
        {
            MatchId = "enemy-view-audit", ManifestHash = new string('a', 64),
            Phase = BattlePhase.Running, ServerTick = 20,
            Coop = new BattleCoopState
            {
                MissionType = "KillXEnemies", Started = true, DeadlineTick = 100,
                SceneMasterPlayerId = PlayerId, ObjectiveTarget = 10
            }
        };
        foreach (string playerId in new[] { PlayerId, PeerId })
        {
            snapshot.Players.Add(new BattlePlayerState
            {
                PlayerId = playerId, Admitted = true, Ready = true, Health = 100, MaxHealth = 100
            });
            snapshot.Coop.ParticipantIds.Add(playerId);
        }
        snapshot.Coop.EnemySpawns.Add(new BattleCoopEnemySpawn
        {
            EntityId = 1, Behaviour = "Assaulter", SpawnComponentFileId = 100, SpawnTick = 8,
            PoseTick = 8, X = 1, Y = 2, Z = 3, CurrentX = 1, CurrentY = 2, CurrentZ = 3,
            Health = 100, MaxHealth = 100, CurrentRotation = new BattleJointRotation { W = 1 }
        });
        return snapshot;
    }

    private static void Publish(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        typeof(SelfHostedBattleClient).GetMethod("Apply", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(client, new object[] { new MatchReply { Code = "state", Snapshot = snapshot } });
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }

        _checks++;
    }
}
