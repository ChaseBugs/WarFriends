using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Compares automatic replacement cleanup with source PoolableObject timers on real Unity frames.</summary>
[InitializeOnLoad]
public static class UnityBazookaTailPlayAudit
{
    private const string SessionKey = "WarFriends.BazookaTailPlayAudit";
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const float LocalDelay = 1.3f;
    private const float RemoteDelay = 0.2f;
    private const float PauseSeconds = 0.4f;
    private const int MaximumSeconds = 60;
    private static SelfHostedProjectilePresenter _presenter;
    private static GameObject _localReplacement;
    private static GameObject _remoteReplacement;
    private static GameObject _localSource;
    private static GameObject _remoteSource;
    private static int _localFrame;
    private static int _remoteFrame;
    private static int _localSourceFrame;
    private static int _remoteSourceFrame;
    private static float _localAge;
    private static float _remoteAge;
    private static float _localSourceAge;
    private static float _remoteSourceAge;
    private static float _scaledStart;
    private static float _pauseStart;
    private static float _pausedRealSeconds;
    private static double _deadline;
    private static bool _isPaused;
    private static int _checks;

    static UnityBazookaTailPlayAudit()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            _deadline = EditorApplication.timeSinceStartup + MaximumSeconds;
            EditorApplication.update += Observe;
        }
    }

    /// <summary>Enters an empty scene; original boot services and missile combat scripts are never started.</summary>
    public static void Run()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        SessionState.SetBool(SessionKey, true);
        _deadline = EditorApplication.timeSinceStartup + MaximumSeconds;
        EditorApplication.update -= Observe;
        EditorApplication.update += Observe;
        EditorApplication.isPlaying = true;
    }

    private static void Observe()
    {
        if (EditorApplication.timeSinceStartup > _deadline)
        {
            Finish(new TimeoutException("The automatic source/replacement tail comparison timed out."));
            return;
        }

        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
        {
            return;
        }

        try
        {
            if (_presenter == null)
            {
                PrepareRuntime();
            }
            else if (_isPaused)
            {
                ObservePause();
            }
            else
            {
                ObserveCleanup();
            }
        }
        catch (Exception failure)
        {
            Finish(failure);
        }
    }

    private static void PrepareRuntime()
    {
        _presenter = new GameObject("TailPlayPresenter").AddComponent<SelfHostedProjectilePresenter>();
        var lifetime = (SelfHostedBazookaLifetime)typeof(SelfHostedProjectilePresenter)
            .GetField("bazookaLifetime", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(_presenter);
        GameObject prefab = Resources.Load<GameObject>("SelfHostedPlayerMissileVisual");
        _localReplacement = UnityEngine.Object.Instantiate(prefab);
        _remoteReplacement = UnityEngine.Object.Instantiate(prefab);
        lifetime.Register(1, _localReplacement, "Google2u.Bazooka_RPG7", true);
        lifetime.Register(2, _remoteReplacement, "Google2u.Bazooka_RPG7", false);
        _localSource = new GameObject("OriginalLocalPoolTimer");
        _remoteSource = new GameObject("OriginalRemotePoolTimer");
        PoolableObject localTimer = _localSource.AddComponent<PoolableObject>();
        PoolableObject remoteTimer = _remoteSource.AddComponent<PoolableObject>();
        _scaledStart = Time.time;
        lifetime.Impact(Impact(1), _scaledStart);
        lifetime.Impact(Impact(2), _scaledStart);
        localTimer.DestroyPooled(LocalDelay);
        remoteTimer.DestroyPooled(RemoteDelay);
        Time.timeScale = 0f;
        _isPaused = true;
        _pauseStart = Time.realtimeSinceStartup;
    }

    private static void ObservePause()
    {
        if (Time.realtimeSinceStartup - _pauseStart < PauseSeconds)
        {
            return;
        }

        Require(_localReplacement != null && _remoteReplacement != null &&
            _localSource != null && _remoteSource != null, "Both source and replacement timers freeze during pause.");
        Require(Time.time == _scaledStart, "The production clock is scaled Unity time.");
        _pausedRealSeconds = Time.realtimeSinceStartup - _pauseStart;
        Time.timeScale = 1f;
        _isPaused = false;
    }

    private static void ObserveCleanup()
    {
        RecordDeath(_localReplacement, ref _localFrame, ref _localAge);
        RecordDeath(_remoteReplacement, ref _remoteFrame, ref _remoteAge);
        RecordDeath(_localSource, ref _localSourceFrame, ref _localSourceAge);
        RecordDeath(_remoteSource, ref _remoteSourceFrame, ref _remoteSourceAge);
        if (_localFrame == 0 || _remoteFrame == 0 || _localSourceFrame == 0 || _remoteSourceFrame == 0)
        {
            return;
        }

        Require(_localAge >= LocalDelay && _remoteAge >= RemoteDelay, "Neither replacement tail expires early.");
        Require(_localSourceAge >= LocalDelay && _remoteSourceAge >= RemoteDelay,
            "The independent source timers reach their serialized delays.");
        Require(Math.Abs(_localFrame - _localSourceFrame) <= 1,
            "The owner tail follows the original coroutine within one scheduling frame.");
        Require(Math.Abs(_remoteFrame - _remoteSourceFrame) <= 1,
            "The peer tail follows the original coroutine within one scheduling frame.");
        Finish(null);
    }

    private static void RecordDeath(GameObject root, ref int frame, ref float age)
    {
        if (root == null && frame == 0)
        {
            frame = Time.frameCount;
            age = Time.time - _scaledStart;
        }
    }

    private static MatchEvent Impact(ulong id)
    {
        return new MatchEvent
        {
            Kind = MatchEventKind.Impact, Reason = "bazooka", ActorId = PlayerId,
            ProjectileId = id, WeaponSourceId = "Google2u.Bazooka_RPG7"
        };
    }

    private static void Finish(Exception failure)
    {
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= Observe;
        Time.timeScale = 1f;
        if (failure != null)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
            return;
        }

        File.WriteAllText(Path.Combine(Application.dataPath, "../bazooka-tail-play-audit.json"),
            JsonConvert.SerializeObject(new
            {
                checks = _checks, pausedRealSeconds = _pausedRealSeconds,
                localAge = _localAge, remoteAge = _remoteAge,
                localSourceAge = _localSourceAge, remoteSourceAge = _remoteSourceAge,
                localFrame = _localFrame, localSourceFrame = _localSourceFrame,
                remoteFrame = _remoteFrame, remoteSourceFrame = _remoteSourceFrame,
                scope = "automatic production Update versus source WaitForSeconds in an isolated scene"
            }) + "\n");
        Debug.Log("PASS: " + _checks + " automatic bazooka tail/source timer checks with pause; no rendered match.");
        EditorApplication.Exit(0);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        _checks++;
    }
}
