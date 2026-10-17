using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks automatic source HUD updates on real Unity frames in an isolated Play Mode scene.</summary>
[InitializeOnLoad]
public static class UnityCoopHudPlayAudit
{
    private const string SessionKey = "WarFriends.CoopHudPlayAudit";
    private const int MaximumStartupSeconds = 60;
    private const int FramesBeforeObservation = 2;
    private const int MinimumFrozenFrames = 10;
    private const float FrozenObservationSeconds = 1f;
    private static TimeAndProgressHudGuiElement _hud;
    private static SelfHostedBattleClient _client;
    private static MatchConnection _connection;
    private static int _phase;
    private static int _phaseStartFrame;
    private static int _checks;
    private static float _phaseStartSeconds;
    private static double _deadline;

    static UnityCoopHudPlayAudit()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            _deadline = EditorApplication.timeSinceStartup + MaximumStartupSeconds;
            EditorApplication.update += ObserveFrames;
        }
    }

    /// <summary>Copies the recovered HUD into a disposable empty scene before entering Play Mode.</summary>
    public static void Run()
    {
        var sourceScene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
        TimeAndProgressHudGuiElement sourceHud = sourceScene.GetRootGameObjects()
            .SelectMany(root => root.GetComponentsInChildren<TimeAndProgressHudGuiElement>(true)).Single();
        sourceHud.gameObject.SetActive(false);
        GameObject clone = UnityEngine.Object.Instantiate(sourceHud.gameObject);
        clone.name = "RecoveredCoopHudPlayAudit";
        foreach (MonoBehaviour behaviour in clone.GetComponentsInChildren<MonoBehaviour>(true))
        {
            behaviour.enabled = false;
        }

        var emptyScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
        MoveToNativeScene(clone, emptyScene);
        EditorSceneManager.CloseScene(sourceScene, true);
        SessionState.SetBool(SessionKey, true);
        _deadline = EditorApplication.timeSinceStartup + MaximumStartupSeconds;
        EditorApplication.update -= ObserveFrames;
        EditorApplication.update += ObserveFrames;
        EditorApplication.isPlaying = true;
    }

    private static void MoveToNativeScene(GameObject clone, object scene)
    {
        // The recovered firstpass also declares SceneManager; use the type owning the Editor-returned scene.
        Type managerType = scene.GetType().Assembly.GetType("UnityEngine.SceneManagement.SceneManager", true);
        managerType.GetMethod("MoveGameObjectToScene", BindingFlags.Public | BindingFlags.Static)
            .Invoke(null, new[] { (object)clone, scene });
        managerType.GetMethod("SetActiveScene", BindingFlags.Public | BindingFlags.Static)
            .Invoke(null, new[] { scene });
    }

    private static void ObserveFrames()
    {
        if (EditorApplication.timeSinceStartup > _deadline)
        {
            Finish(new TimeoutException("The source co-op HUD Play Mode audit timed out."));
            return;
        }
        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
        {
            return;
        }

        try
        {
            if (_hud == null)
            {
                PrepareRuntime();
                return;
            }
            if (Time.frameCount < _phaseStartFrame + FramesBeforeObservation)
            {
                return;
            }

            CheckCurrentPhase();
        }
        catch (Exception failure)
        {
            Finish(failure);
        }
    }

    private static void PrepareRuntime()
    {
        _hud = Resources.FindObjectsOfTypeAll<TimeAndProgressHudGuiElement>()
            .Single(candidate => candidate.gameObject.scene.IsValid());
        var owner = new GameObject("CoopHudPlayDependencies");
        owner.SetActive(false);
        MissionsManager manager = owner.AddComponent<MissionsManager>();
        GameController game = owner.AddComponent<GameController>();
        game.gameControllerCoop = owner.AddComponent<GameControllerCoop>();
        typeof(Singleton<GameController>).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic)
            .SetValue(null, game);
        UnityCoopHudSceneAudit.PrepareScene(owner, manager, game);
        KillMission mission = owner.AddComponent<KillMission>();
        mission.killFor1Star = 10;
        typeof(Mission).GetField("mMissionDefinition", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(mission, new MissionDefinition { maxTimeForMission = 120 });
        manager.missions = new List<Mission> { mission };
        manager.indexMissionToStart = 0;
        PrepareClient(owner, manager);
        EnableHudUpdates();
        _phaseStartFrame = Time.frameCount;
    }

    private static void PrepareClient(GameObject owner, MissionsManager manager)
    {
        _client = owner.AddComponent<SelfHostedBattleClient>();
        _connection = new MatchConnection(UnityCoopHudSceneAudit.CreateGrant());
        UnityCoopHudSceneAudit.SetClient(_client, _connection);
        UnityCoopHudSceneAudit.Publish(_client,
            UnityCoopHudSceneAudit.CreateSnapshot(0, "KillXEnemies", 10, 120));
        _client.BindMissionManager(manager);
    }

    private static void EnableHudUpdates()
    {
        Require(_hud.progressLabel != null && _hud.progressSprite != null && _hud.timeLabel != null,
            "The cloned source HUD must retain its serialized NGUI references.");
        // This audit isolates Update scheduling; normal scene-wide InitControls/layout is a separate gate.
        typeof(GuiElement).GetField("mFirstEnable", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(_hud, false);
        _hud.progressLabel.text = "awaiting-host-frame";
        _hud.timeLabel.text = "awaiting-host-frame";
        _hud.enabled = true;
        _hud.gameObject.SetActive(true);
        UnityCoopHudSceneAudit.InvokeHud(_hud, "Hide");
        UnityCoopHudSceneAudit.InvokeHud(_hud, "Show");
        Require(_hud.isActiveAndEnabled, "Unity must schedule the actual source HUD behaviour.");
    }

    private static void CheckCurrentPhase()
    {
        if (_phase == 0)
        {
            VerifyOutput("KILL 4 / 10", "01:40", 0.4f);
            MatchSnapshot next = UnityCoopHudSceneAudit.CreateSnapshot(0, "KillXEnemies", 10, 120);
            next.ServerTick = 900;
            next.Coop.EnemyKills = 6;
            UnityCoopHudSceneAudit.Publish(_client, next);
            _phase = 1;
            _phaseStartFrame = Time.frameCount;
            return;
        }
        if (_phase == 1)
        {
            VerifyOutput("KILL 6 / 10", "01:30", 0.6f);
            _phase = 2;
            _phaseStartFrame = Time.frameCount;
            _phaseStartSeconds = Time.realtimeSinceStartup;
            return;
        }
        if (Time.frameCount < _phaseStartFrame + MinimumFrozenFrames ||
            Time.realtimeSinceStartup < _phaseStartSeconds + FrozenObservationSeconds)
        {
            return;
        }

        VerifyOutput("KILL 6 / 10", "01:30", 0.6f);
        Finish(null);
    }

    private static void VerifyOutput(string objective, string time, float progress)
    {
        Require(_hud.progressLabel.text == objective && _hud.timeLabel.text == time,
            "Automatic source Update must display the current host objective and time.");
        Require(Math.Abs(_hud.progressSprite.fillAmount - progress) < 0.0001f,
            "Automatic source Update must publish host progress to the recovered sprite.");
    }

    private static void Finish(Exception failure)
    {
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= ObserveFrames;
        if (_client != null)
        {
            _client.LeaveMatch();
        }
        if (failure != null)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
            return;
        }

        File.WriteAllText(Path.Combine(Application.dataPath, "../coop-hud-play-audit.json"),
            JsonConvert.SerializeObject(new
            {
                schemaVersion = 2, checks = _checks, frames = Time.frameCount,
                frozenSeconds = Time.realtimeSinceStartup - _phaseStartSeconds,
                objectiveText = _hud.progressLabel.text, timeText = _hud.timeLabel.text,
                scope = "isolated source HUD Update scheduling"
            }) + "\n");
        Debug.Log("PASS: " + _checks + " source co-op HUD Play Mode checks; automatic frames, no rendered output.");
        EditorApplication.Exit(0);
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
