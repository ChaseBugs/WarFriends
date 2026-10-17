using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using Google.Protobuf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks real MainScene mission HUD bindings without running gameplay or saving the scene.</summary>
public static class UnityCoopHudSceneAudit
{
    private const string MasterId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string PeerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private const ulong ElapsedTicks = 600;
    private const int HostTickRate = 30;
    private const int AuditPort = 9;
    private const int GrantLifetimeSeconds = 60;
    private static int _checks;
    private static readonly List<Dictionary<string, object>> Observations = new List<Dictionary<string, object>>();

    /// <summary>Updates the recovered NGUI labels and bars through the production mission HUD method.</summary>
    public static void Run()
    {
        _checks = 0;
        Observations.Clear();
        GameObject owner = null;
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Component[] components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            MissionsManager manager = components.OfType<MissionsManager>().Single();
            GameController game = components.OfType<GameController>().Single();
            TimeAndProgressHudGuiElement hud = components.OfType<TimeAndProgressHudGuiElement>().Single();
            Require(hud.progressLabel != null && hud.progressSprite != null && hud.timeLabel != null &&
                hud.progressPart != null && hud.timePart != null, "The scene must retain all mission HUD references.");
            owner = new GameObject("CoopHudSceneAudit");
            owner.SetActive(false);
            PrepareScene(owner, manager, game);
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            using (var connection = new MatchConnection(CreateGrant()))
            {
                SetClient(client, connection);
                VerifyMissionRows(owner, new HudBindings(manager, hud, client));
                client.LeaveMatch();
            }

            WriteReport();
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            if (owner != null)
            {
                UnityEngine.Object.DestroyImmediate(owner);
            }
        }
    }

    internal static void PrepareScene(GameObject owner, MissionsManager manager, GameController game)
    {
        typeof(MissionsManager).GetField("mInstance", BindingFlags.Static | BindingFlags.NonPublic)
            .SetValue(null, manager);
        Require(game.gameControllerCoop != null && Singleton<GameController>.instance == game,
            "The actual scene must resolve its co-op controller and game singleton.");
        typeof(GameController).GetField("mMainController", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(game, game.gameControllerCoop);
        Localization localization = owner.AddComponent<Localization>();
        TextAsset english = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Resources/localizations/en.txt");
        Require(english != null, "The recovered English localization asset must exist.");
        typeof(Localization).GetField("mDictionary", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(localization, new ByteReader(english).ReadDictionary());
        typeof(Localization).GetField("mInstance", BindingFlags.Static | BindingFlags.NonPublic)
            .SetValue(null, localization);
    }

    private static void VerifyMissionRows(GameObject owner, HudBindings bindings)
    {
        string catalogPath = Path.Combine(Application.dataPath, "../coop-hud-mission-catalog.json");
        JArray rows = (JArray)JObject.Parse(File.ReadAllText(catalogPath))["missions"];
        VerifyMission(owner.AddComponent<KillMission>(), rows, bindings);
        VerifyMission(owner.AddComponent<SurviveMission>(), rows, bindings);
        VerifyMission(owner.AddComponent<ScoreMission>(), rows, bindings);
        VerifyMission(owner.AddComponent<BotMission>(), rows, bindings);
    }

    private static void VerifyMission(Mission mission, JArray rows, HudBindings bindings)
    {
        string type = GetMissionType(mission);
        JToken row = rows.First(candidate => (string)candidate["missionType"] == type);
        int target = row["objective"].Type == JTokenType.Null ? 0 : (int)row["objective"];
        int duration = (int)row["timeSeconds"];
        mission.index = (int)row["index"];
        typeof(Mission).GetField("mMissionDefinition", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(mission, new MissionDefinition { maxTimeForMission = duration });
        if (mission is KillMission)
        {
            ((KillMission)mission).killFor1Star = target;
        }
        if (mission is ScoreMission)
        {
            ((ScoreMission)mission).scoreToSucces = target;
        }

        bindings.Manager.missions = new List<Mission> { mission };
        bindings.Manager.indexMissionToStart = 0;
        Publish(bindings.Client, CreateSnapshot(mission.index, type, target, duration));
        bindings.Client.BindMissionManager(bindings.Manager);
        InvokeHud(bindings.Hud, "Hide");
        InvokeHud(bindings.Hud, "Show");
        InvokeHud(bindings.Hud, "Update");
        VerifyDisplayedValues(bindings.Hud, type);
    }

    private static string GetMissionType(Mission mission)
    {
        if (mission is KillMission)
        {
            return "KillXEnemies";
        }
        if (mission is SurviveMission)
        {
            return "SurviveXSeconds";
        }
        if (mission is ScoreMission)
        {
            return "Score";
        }

        return "KillOpponent";
    }

    private static void VerifyDisplayedValues(TimeAndProgressHudGuiElement hud, string type)
    {
        string expectedTime = type == "SurviveXSeconds" ? "00:40" : "01:40";
        if (type == "KillOpponent")
        {
            expectedTime = "02:40";
        }

        Require(hud.timePart.activeSelf && hud.timeLabel.text == expectedTime,
            type + " must display the host remaining time in the actual scene label.");
        Observations.Add(new Dictionary<string, object>
        {
            { "missionType", type },
            { "timeText", hud.timeLabel.text },
            { "objectiveText", hud.progressLabel.text },
            { "progressVisible", hud.progressPart.activeSelf },
            { "fillAmount", hud.progressSprite.fillAmount }
        });
        if (type == "KillOpponent")
        {
            Require(!hud.progressPart.activeSelf, "The source Boss HUD must hide the mission progress part.");
            return;
        }

        string expectedText = type == "KillXEnemies" ? "KILL 4 / 10" : "SCORE 15 / 280";
        float expectedProgress = type == "KillXEnemies" ? 0.4f : 15f / 280f;
        if (type == "SurviveXSeconds")
        {
            expectedText = "SURVIVE FOR 60s";
            expectedProgress = 1f / 3f;
        }

        Require(hud.progressPart.activeSelf && hud.progressLabel.text == expectedText,
            type + " must format the actual recovered English objective label.");
        Require(Math.Abs(hud.progressSprite.fillAmount - expectedProgress) < 0.0001f,
            type + " must update the serialized NGUI progress sprite from host state.");
    }

    internal static MatchSnapshot CreateSnapshot(int index, string type, int target, int duration)
    {
        var snapshot = new MatchSnapshot
        {
            MatchId = "hud-scene-audit", ManifestHash = new string('a', 64),
            Phase = BattlePhase.Running, ServerTick = ElapsedTicks,
            Coop = new BattleCoopState
            {
                MissionIndex = index, MissionType = type, ObjectiveTarget = target, EnemyKills = 4,
                Started = true, SceneMasterPlayerId = MasterId, DeadlineTick = (ulong)duration * HostTickRate
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
        if (type == "Score")
        {
            snapshot.Coop.ObjectiveScore = 15;
            snapshot.Coop.ParticipantScores.Add(new BattleCoopParticipantScore { PlayerId = MasterId, Score = 10 });
            snapshot.Coop.ParticipantScores.Add(new BattleCoopParticipantScore { PlayerId = PeerId, Score = 5 });
        }

        return snapshot;
    }

    internal static MatchConnectionGrant CreateGrant()
    {
        byte[] key = new byte[32];
        using (RandomNumberGenerator random = RandomNumberGenerator.Create())
        {
            random.GetBytes(key);
        }

        return new MatchConnectionGrant
        {
            Host = "127.0.0.1", Port = AuditPort, PlayerId = MasterId, SessionId = 1,
            MatchId = "hud-scene-audit", ManifestHash = new string('a', 64), Ticket = "audit-only-capability",
            SessionKey = ByteString.CopyFrom(key),
            ExpiresUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + GrantLifetimeSeconds
        };
    }

    internal static void SetClient(SelfHostedBattleClient client, MatchConnection connection)
    {
        typeof(SelfHostedBattleClient).GetField("connection", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(client, connection);
        typeof(SelfHostedBattleClient).GetProperty("Active").SetValue(null, client, null);
        typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId").SetValue(client, MasterId, null);
    }

    internal static void Publish(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        typeof(SelfHostedBattleClient).GetMethod("Apply", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(client, new object[] { new MatchReply { Code = "state", Snapshot = snapshot } });
    }

    internal static void InvokeHud(TimeAndProgressHudGuiElement hud, string method)
    {
        typeof(TimeAndProgressHudGuiElement).GetMethod(method, BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(hud, null);
    }

    private static void WriteReport()
    {
        File.WriteAllText(Path.Combine(Application.dataPath, "../coop-hud-scene-audit.json"),
            JsonConvert.SerializeObject(new
            {
                schemaVersion = 2, checks = _checks, scope = "MainScene NGUI component output",
                observations = Observations
            }) + "\n");
        Debug.Log("PASS: " + _checks + " MainScene co-op HUD checks; no rendered frames or gameplay.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }

        _checks++;
    }

    private sealed class HudBindings
    {
        internal MissionsManager Manager { get; private set; }

        internal TimeAndProgressHudGuiElement Hud { get; private set; }

        internal SelfHostedBattleClient Client { get; private set; }

        internal HudBindings(MissionsManager manager, TimeAndProgressHudGuiElement hud, SelfHostedBattleClient client)
        {
            Manager = manager;
            Hud = hud;
            Client = client;
        }
    }

}
