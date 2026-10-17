using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using Google.Protobuf;
using UnityEditor;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks recovered mission lifecycle authority without creating gameplay, rewards or a Photon room.</summary>
public static class UnityCoopMissionAuthorityAudit
{
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const int AuditPort = 9;
    private const int GrantLifetimeSeconds = 60;
    private static int _checks;

    /// <summary>Runs real mission components against an owned portable connection in a disposable Editor project.</summary>
    public static void Run()
    {
        _checks = 0;
        var owner = new GameObject("CoopMissionAuthorityAudit");
        owner.SetActive(false);
        SelfHostedBattleClient previousClient = SelfHostedBattleClient.Active;
        try
        {
            Mission[] missions = CreateMissions(owner);
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            using (var connection = new MatchConnection(CreateGrant()))
            {
                SetConnection(client, connection);
                VerifyHostLifecycles(client, missions);
                VerifyBossDeath((BotMission)missions[3]);
                MissionsManager hudManager = VerifyHudBinding(owner, client, (KillMission)missions[0]);
                Mission resetProbe = owner.AddComponent<Mission>();
                resetProbe.PlayMission(true);
                Require(resetProbe.HasSelfHostedCoopAuthority, "A base mission must bind host authority before reset.");
                client.LeaveMatch();
                Require(hudManager.time == 1f, "Closing the connection must retain its last confirmed HUD view.");
                VerifyDisconnectedAuthority(missions);
                resetProbe.PlayMission(false);
                Require(!resetProbe.HasSelfHostedCoopAuthority,
                    "Explicitly starting another mode must release the previous host authority latch.");
            }

            Require(!owner.AddComponent<Mission>().HasSelfHostedCoopAuthority,
                "A new unbound mission must retain its legacy authority selection.");
            File.WriteAllText(Path.Combine(Application.dataPath, "../coop-mission-authority-audit.json"),
                "{\"schemaVersion\":1,\"checks\":" + _checks + ",\"scope\":\"edit-mode mission lifecycle guards\"}\n");
            Debug.Log("PASS: " + _checks + " co-op mission lifecycle authority checks; no gameplay or rewards.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            typeof(SelfHostedBattleClient).GetProperty("Active").SetValue(null, previousClient, null);
            UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static Mission[] CreateMissions(GameObject owner)
    {
        var missions = new Mission[]
        {
            owner.AddComponent<KillMission>(),
            owner.AddComponent<SurviveMission>(),
            owner.AddComponent<ScoreMission>(),
            owner.AddComponent<BotMission>()
        };
        foreach (Mission mission in missions)
        {
            Require(!mission.HasSelfHostedCoopAuthority, "An unbound source mission must not become host-owned.");
        }

        return missions;
    }

    private static void VerifyHostLifecycles(SelfHostedBattleClient client, Mission[] missions)
    {
        string[] missionTypes = { "KillXEnemies", "SurviveXSeconds", "Score", "KillOpponent" };
        for (int index = 0; index < missions.Length; index++)
        {
            typeof(SelfHostedBattleClient).GetProperty("State").SetValue(client,
                new MatchSnapshot { Coop = new BattleCoopState { MissionType = missionTypes[index] } }, null);
            Mission mission = missions[index];
            mission.PlayMission(true);
            mission.OnGameStarted();
            mission.OnAfterGameStarted();
            mission.MissionSuccessCoopClient();
            mission.UpdateCurrentMission();
            mission.EndMission();
            InvokeBase(mission, "MissionSuccess");
            InvokeBase(mission, "MissionFail");
            bool isPlaying = (bool)typeof(Mission).GetField("mIsMissionPlaying",
                BindingFlags.Instance | BindingFlags.NonPublic).GetValue(mission);
            Require(mission.HasSelfHostedCoopAuthority && !isPlaying,
                "Host-owned " + missionTypes[index] + " must not run local setup, completion or progression.");
        }
    }

    private static MissionsManager VerifyHudBinding(GameObject owner, SelfHostedBattleClient client,
        KillMission mission)
    {
        mission.index = 0;
        mission.killFor1Star = 10;
        typeof(Mission).GetField("mMissionDefinition", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(mission, new MissionDefinition { maxTimeForMission = 3 });
        MissionsManager manager = owner.AddComponent<MissionsManager>();
        manager.missions = new List<Mission> { mission };
        manager.indexMissionToStart = 0;
        MatchSnapshot snapshot = CreateHudSnapshot();
        Publish(client, snapshot);
        typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId").SetValue(client, PlayerId, null);
        client.BindMissionManager(manager);
        Require(manager.time == 2f && manager.missionProgress == 0.4f,
            "The source manager must read host clock and kills without a PhotonView.");
        VerifyHudRejection(manager, snapshot);
        bool hasObserved = false;
        client.StateReceived += state => hasObserved = manager.time == 1f && manager.missionProgress == 0.5f;
        snapshot.ServerTick = 60;
        snapshot.Coop.EnemyKills = 5;
        Publish(client, snapshot);
        Require(hasObserved, "Host HUD publication must precede the snapshot callbacks.");
        client.BindMissionManager(manager);
        Require(manager.time == 1f, "Binding a scene again must replay its current host state.");
        VerifyHudIdentityIsolation(client, manager, mission, snapshot);
        return manager;
    }

    private static void VerifyHudIdentityIsolation(SelfHostedBattleClient client, MissionsManager manager,
        KillMission mission, MatchSnapshot snapshot)
    {
        PropertyInfo stateProperty = typeof(SelfHostedBattleClient).GetProperty("State");
        MatchSnapshot nextMatch = snapshot.Clone();
        nextMatch.MatchId = "another-match-same-mission";
        stateProperty.SetValue(client, nextMatch, null);
        Require(manager.time == 3f && manager.missionProgress == 0f,
            "The same mission in a new match must not reuse the previous clock or progress.");
        MatchSnapshot nextManifest = snapshot.Clone();
        nextManifest.ManifestHash = new string('b', 64);
        stateProperty.SetValue(client, nextManifest, null);
        Require(manager.time == 3f && manager.missionProgress == 0f,
            "Another manifest must not inherit cached HUD state even if the match ID repeats.");
        stateProperty.SetValue(client, null, null);
        Require(manager.time == 3f && manager.missionProgress == 0f,
            "An owned connection awaiting its first state must not expose an old mission view.");
        stateProperty.SetValue(client, snapshot, null);
        mission.index = 1;
        Require(manager.time == 3f && manager.missionProgress == 0f,
            "Selecting another source mission must not reuse the previous objective view.");
        mission.index = 0;
    }

    private static void VerifyHudRejection(MissionsManager manager, MatchSnapshot snapshot)
    {
        MatchSnapshot malformed = snapshot.Clone();
        malformed.Coop.MissionIndex = 1;
        bool hasRejected = false;
        try
        {
            manager.ApplySelfHostedHud(malformed, PlayerId);
        }
        catch (InvalidOperationException)
        {
            hasRejected = true;
        }

        Require(hasRejected && manager.time == 2f && manager.missionProgress == 0.4f,
            "A foreign mission view must reject before changing source HUD state.");
    }

    private static MatchSnapshot CreateHudSnapshot()
    {
        const string PeerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
        var snapshot = new MatchSnapshot
        {
            MatchId = "mission-authority-audit", ManifestHash = new string('a', 64),
            Phase = BattlePhase.Running, ServerTick = 30,
            Coop = new BattleCoopState
            {
                MissionType = "KillXEnemies", Started = true, DeadlineTick = 90,
                SceneMasterPlayerId = PlayerId, ObjectiveTarget = 10, EnemyKills = 4
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

        return snapshot;
    }

    private static void Publish(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        typeof(SelfHostedBattleClient).GetMethod("Apply", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(client, new object[] { new MatchReply { Code = "state", Snapshot = snapshot } });
    }

    private static void VerifyBossDeath(BotMission mission)
    {
        typeof(BotMission).GetMethod("OnBotKilled", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(mission, new object[] { null, null });
        Require(!mission.botWasKilled, "Local boss death must not publish a shared kill or access hit attribution.");
    }

    private static void VerifyDisconnectedAuthority(Mission[] missions)
    {
        foreach (Mission mission in missions)
        {
            mission.EndMission();
            mission.UpdateCurrentMission();
            InvokeBase(mission, "MissionSuccess");
            Require(mission.HasSelfHostedCoopAuthority,
                "Disconnect must not reopen local outcome or star authority for an already host-owned mission.");
        }
    }

    private static MatchConnectionGrant CreateGrant()
    {
        byte[] sessionKey = new byte[32];
        using (RandomNumberGenerator random = RandomNumberGenerator.Create())
        {
            random.GetBytes(sessionKey);
        }

        return new MatchConnectionGrant
        {
            Host = "127.0.0.1", Port = AuditPort, PlayerId = PlayerId, SessionId = 1,
            MatchId = "mission-authority-audit", ManifestHash = new string('a', 64),
            Ticket = "audit-only-capability", SessionKey = ByteString.CopyFrom(sessionKey),
            ExpiresUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + GrantLifetimeSeconds
        };
    }

    private static void SetConnection(SelfHostedBattleClient client, MatchConnection connection)
    {
        typeof(SelfHostedBattleClient).GetField("connection", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(client, connection);
        typeof(SelfHostedBattleClient).GetProperty("Active").SetValue(null, client, null);
    }

    private static void InvokeBase(Mission mission, string method)
    {
        typeof(Mission).GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic).Invoke(mission, null);
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
