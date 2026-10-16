using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Checks the recovered score notification and text tween on actual Play Mode frames.</summary>
[InitializeOnLoad]
public static class SelfHostedScoreClockAudit
{
    private const string SessionKey = "WarFriends.ScoreClockAudit";
    private const int ExpectedScore = 56;
    private const double TimeoutSeconds = 30;
    private const float MinimumWaitSeconds = 3;
    private static ScoreManager _scores;
    private static UILabel _total;
    private static UILabel _gain;
    private static float _started;
    private static double _deadline;

    static SelfHostedScoreClockAudit()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            _deadline = EditorApplication.timeSinceStartup + TimeoutSeconds;
            EditorApplication.update += Update;
        }
    }

    /// <summary>Enters an isolated Play Mode scene without booting retired online services.</summary>
    public static void Run()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void Update()
    {
        try
        {
            if (EditorApplication.timeSinceStartup > _deadline)
            {
                throw new TimeoutException("Score notification or NGUI text tween did not complete.");
            }
            if (!EditorApplication.isPlaying || EditorApplication.isPaused)
            {
                return;
            }
            if (_scores == null)
            {
                CreateComponents();
                return;
            }
            if (Time.time - _started < MinimumWaitSeconds)
            {
                return;
            }
            if (_scores.score != ExpectedScore || _total.text != "56" || _gain.text != "+56")
            {
                throw new InvalidOperationException("Play Mode frames did not project the accepted host score.");
            }

            Finish(true);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            Finish(false);
        }
    }

    private static void CreateComponents()
    {
        var controllerRoot = new GameObject("InactiveScoreClockController");
        controllerRoot.SetActive(false);
        GameController controller = controllerRoot.AddComponent<GameController>();
        typeof(Singleton<GameController>).GetField("_instance",
            BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, controller);

        var scoreRoot = new GameObject("ScoreClockManager");
        scoreRoot.SetActive(false);
        _scores = scoreRoot.AddComponent<ScoreManager>();
        // Keep unrelated gameplay Update disabled; its real notification coroutine still runs.
        _scores.enabled = false;
        scoreRoot.SetActive(true);

        var hudRoot = new GameObject("InactiveScoreClockHud");
        hudRoot.SetActive(false);
        HudScreen hud = hudRoot.AddComponent<HudScreen>();
        _total = CreateLabel("ScoreTotal");
        _gain = CreateLabel("ScoreGain");
        hud.scoreLabel = _total;
        hud.scoreAddedLabel = _gain;
        TweenAnimator animator = hudRoot.AddComponent<TweenAnimator>();
        animator.allTweens = new List<TweenAnimator.TweenRecord>();
        typeof(HudScreen).GetField("mAnimator", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(hud, animator);
        MethodInfo callback = typeof(HudScreen).GetMethod("OnScoreChanged",
            BindingFlags.Instance | BindingFlags.NonPublic);
        _scores.ScoreChanged += (Action<int, int>)Delegate.CreateDelegate(typeof(Action<int, int>), hud, callback);
        // Invoke the recovered Start once; Unity owns its coroutine scheduling from this point.
        typeof(ScoreManager).GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(_scores, null);
        var snapshot = new MatchSnapshot { Phase = BattlePhase.Running };
        snapshot.Players.Add(new BattlePlayerState { PlayerId = new string('a', 32), Score = ExpectedScore });
        snapshot.Players.Add(new BattlePlayerState { PlayerId = new string('b', 32) });
        _scores.ApplySelfHostedSnapshot(snapshot, snapshot.Players[0].PlayerId);
        _started = Time.time;
    }

    private static UILabel CreateLabel(string name)
    {
        var labelRoot = new GameObject(name);
        UILabel label = labelRoot.AddComponent<UILabel>();
        label.text = "0";
        return label;
    }

    private static void Finish(bool isSuccess)
    {
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= Update;
        if (isSuccess)
        {
            Debug.Log("PASS: Play Mode score coroutine and NGUI tween advanced without manual stepping.");
        }
        EditorApplication.Exit(isSuccess ? 0 : 1);
    }
}
