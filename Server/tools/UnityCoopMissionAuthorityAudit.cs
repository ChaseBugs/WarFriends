using System;
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
                Mission resetProbe = owner.AddComponent<Mission>();
                resetProbe.PlayMission(true);
                Require(resetProbe.HasSelfHostedCoopAuthority, "A base mission must bind host authority before reset.");
                client.LeaveMatch();
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
