using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using Google.Protobuf;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;
using War.Protocol;
using War.Shared;

/// <summary>Checks score presentation without starting recovered gameplay or contacting Photon.</summary>
public static class SelfHostedScoreHudAudit
{
    private const int ExpectedScore = 56;
    private const float ExpectedProgress = 5.6f;
    private const float PendingProgress = 150f;
    private static readonly string LocalId = new string('a', 32);
    private static readonly string OtherId = new string('b', 32);
    private static int _checks;

    /// <summary>Runs the component, NGUI text, terminal ordering, and authority checks in batch mode.</summary>
    public static void Run()
    {
        _checks = 0;
        var root = new GameObject("SelfHostedScoreHudAudit");
        root.SetActive(false);
        try
        {
            ScoreManager scores = root.AddComponent<ScoreManager>();
            SelfHostedBattleClient client = root.AddComponent<SelfHostedBattleClient>();
            scores.score = 7;
            Check(scores.score == 7, "Legacy score assignment remains available before host binding.");
            using (var connection = new MatchConnection(CreateGrant()))
            {
                VerifySnapshotOrdering(client, scores, connection);
                VerifyLocalAuthorityDisabled(scores);
                VerifyInvalidSnapshotRejected(scores);
                VerifyHudText(root, scores);
                client.LeaveMatch();
                VerifyLocalAuthorityDisabled(scores);
            }

            Debug.Log("PASS: " + _checks + " self-hosted score HUD audit assertions");
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            EditorApplication.Exit(1);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(root);
        }
    }

    /// <summary>Checks recovered MainScene score bindings through its production HUD event setup.</summary>
    public static void RunScene()
    {
        _checks = 0;
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            ScoreManager scores = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<ScoreManager>(true)).Single();
            HudScreen hud = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<HudScreen>(true)).Single();
            Check(Singleton<ScoreManager>.instance == scores,
                "The scene singleton resolves the recovered score component.");
            Check(hud.scoreLabel != null && hud.scoreAddedLabel != null && hud.pauseButton != null,
                "The recovered HUD retains its serialized score and control references.");
            hud.InitEvents();
            scores.ApplySelfHostedSnapshot(CreateSnapshot(BattlePhase.Ended, 2), LocalId);
            IEnumerator clock = (IEnumerator)Invoke(scores, "CheckForScoreChange");
            clock.MoveNext();
            Component counter = hud.scoreLabel.GetComponent("TweenTextCounter");
            Invoke(counter, "Awake");
            ((UITweener)counter).Sample(1f, true);
            Check(hud.scoreLabel.text == "56" && hud.scoreAddedLabel.text == "+56",
                "The scene's production event subscription updates its actual NGUI labels.");
            Check(hud.GetComponent<TweenAnimator>().allTweens.Count > 0,
                "The production HUD initializes its recovered score animations.");
            VerifyResultSummary(scene, scores);
            Debug.Log("PASS: " + _checks + " MainScene score HUD assertions");
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            EditorApplication.Exit(1);
        }
    }

    private static void VerifyResultSummary(UnityEngine.SceneManagement.Scene scene, ScoreManager scores)
    {
        RibbonsContent content = scene.GetRootGameObjects()
            .SelectMany(root => root.GetComponentsInChildren<RibbonsContent>(true))
            .First(item => item.skillshotGuiRecordPrefab != null);
        SkillshotGuiRecord summary = UnityEngine.Object.Instantiate(content.skillshotGuiRecordPrefab);
        try
        {
            summary.MultiplayerSkillshotSpecial(scores.score, scores.opponentScore);
            Check(summary.isSpecial && summary.plScore == ExpectedScore && summary.opScore == 0,
                "The recovered result summary retains the host's final participant totals.");
            Check(summary.playerScore.text == "56" && summary.opponentScore.text == "0",
                "The recovered result prefab displays both final score labels.");
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(summary.gameObject);
        }
    }

    private static void VerifySnapshotOrdering(SelfHostedBattleClient client,
        ScoreManager scores, MatchConnection connection)
    {
        typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId").SetValue(client, LocalId, null);
        SetField(client, "connection", connection);
        client.BindScoreManager(scores);
        MatchSnapshot running = CreateSnapshot(BattlePhase.Running, 1);
        Invoke(client, "Apply", new MatchReply { Snapshot = running });
        Check(scores.score == 0, "The accepted host snapshot replaces the prior score.");

        var lifecycle = new SelfHostedRoomLifecycle(connection);
        SetField(client, "roomLifecycle", lifecycle);
        bool isFinalScoreVisible = false;
        lifecycle.PhaseChanged += delegate (SelfHostedRoomPhase phase)
        {
            if (phase == SelfHostedRoomPhase.Closed)
            {
                isFinalScoreVisible = scores.score == ExpectedScore &&
                    scores.skillShotCounts[SkillShot.SkillShotType.RevengeKill] == 1;
            }
        };
        MatchSnapshot terminal = CreateSnapshot(BattlePhase.Ended, 2);
        Invoke(client, "Apply", new MatchReply { Snapshot = terminal });
        Check(isFinalScoreVisible, "Final score and counts precede the room's terminal callback.");
        Check(Mathf.Abs(scores.killStreakProgress - ExpectedProgress) < .001f && scores.opponentScore == 0,
            "The HUD model uses the host's streak progress and opponent score.");
        Invoke(client, "Apply", new MatchReply { Snapshot = running });
        Check(scores.score == ExpectedScore, "An older replay cannot rewind the score view.");
    }

    private static void VerifyLocalAuthorityDisabled(ScoreManager scores)
    {
        MatchSnapshot pending = CreateSnapshot(BattlePhase.Ended, 3);
        pending.Players[0].KillStreakProgress = PendingProgress;
        scores.ApplySelfHostedSnapshot(pending, LocalId);
        scores.score = 999;
        scores.AddSkillshot(null, null);
        Invoke(scores, "AdvanceLocalStreak");
        Invoke(scores, "LateUpdate");
        Invoke(scores, "InstanceOnGameEnded", default(GameController.GameEndReason));
        Invoke(scores, "RecieveOponentScore", 999);
        Invoke(scores, "RecieveSkillShotsCount", (int)SkillShot.SkillShotType.RevengeKill, 999);
        Invoke(scores, "OnPhotonSerializeView", null, default(PhotonMessageInfo));
        Check(scores.score == ExpectedScore && scores.opponentScore == 0 &&
            scores.killStreakProgress == PendingProgress && !scores.isNewKillStreak &&
            scores.skillShotCountsOponent[SkillShot.SkillShotType.RevengeKill] == 0,
            "Local calculation and old Photon callbacks cannot overwrite accepted host state.");
    }

    private static void VerifyInvalidSnapshotRejected(ScoreManager scores)
    {
        MatchSnapshot invalid = CreateSnapshot(BattlePhase.Ended, 3);
        invalid.Players[0].Score = 999;
        invalid.Players[0].KillStreakProgress = float.NaN;
        bool isRejected = false;
        try
        {
            scores.ApplySelfHostedSnapshot(invalid, LocalId);
        }
        catch (InvalidOperationException)
        {
            isRejected = true;
        }

        Check(isRejected && scores.score == ExpectedScore,
            "Invalid progress cannot partially replace the accepted score.");
    }

    private static void VerifyHudText(GameObject root, ScoreManager scores)
    {
        HudScreen hud = root.AddComponent<HudScreen>();
        hud.scoreLabel = CreateLabel(root, "Score");
        hud.scoreAddedLabel = CreateLabel(root, "AddedScore");
        TweenAnimator animator = root.AddComponent<TweenAnimator>();
        animator.allTweens = new List<TweenAnimator.TweenRecord>();
        SetField(hud, "mAnimator", animator);
        MethodInfo callback = typeof(HudScreen).GetMethod("OnScoreChanged",
            BindingFlags.NonPublic | BindingFlags.Instance);
        Action<int, int> listener = (Action<int, int>)Delegate.CreateDelegate(typeof(Action<int, int>), hud, callback);
        scores.ScoreChanged += listener;
        IEnumerator clock = (IEnumerator)Invoke(scores, "CheckForScoreChange");
        clock.MoveNext();
        Component counter = hud.scoreLabel.GetComponent("TweenTextCounter");
        Invoke(counter, "Awake");
        ((UITweener)counter).Sample(1f, true);
        Check(hud.scoreLabel.text == "56" && hud.scoreAddedLabel.text == "+56",
            "The recovered ScoreChanged handler drives the actual NGUI label and gain text.");
        scores.ScoreChanged -= listener;
    }

    private static UILabel CreateLabel(GameObject root, string name)
    {
        var child = new GameObject(name);
        child.transform.SetParent(root.transform, false);
        UILabel label = child.AddComponent<UILabel>();
        label.text = "0";
        return label;
    }

    private static MatchSnapshot CreateSnapshot(BattlePhase phase, ulong revision)
    {
        var snapshot = new MatchSnapshot
        {
            MatchId = "score-hud-audit",
            ManifestHash = new string('a', 64),
            Phase = phase,
            ServerTick = revision,
            StateRevision = revision
        };
        var local = new BattlePlayerState { PlayerId = LocalId };
        var other = new BattlePlayerState { PlayerId = OtherId };
        if (phase == BattlePhase.Ended)
        {
            local.Score = ExpectedScore;
            local.KillStreakProgress = ExpectedProgress;
            Dictionary<int, int> counts = CreateEmptyCounts();
            counts[(int)SkillShot.SkillShotType.Kill] = 1;
            counts[(int)SkillShot.SkillShotType.OneHitKill] = 1;
            counts[(int)SkillShot.SkillShotType.VehicleDestroyed] = 1;
            counts[(int)SkillShot.SkillShotType.RevengeKill] = 1;
            local.SkillShotCounts.AddRange(SkillShotCounterPolicy.FromConfirmedCounts(counts));
            other.SkillShotCounts.AddRange(SkillShotCounterPolicy.FromConfirmedCounts(CreateEmptyCounts()));
        }

        snapshot.Players.Add(local);
        snapshot.Players.Add(other);
        return snapshot;
    }

    private static Dictionary<int, int> CreateEmptyCounts()
    {
        var counts = new Dictionary<int, int>();
        foreach (SkillShot.SkillShotType flag in Enum.GetValues(typeof(SkillShot.SkillShotType)))
        {
            if (flag != SkillShot.SkillShotType.None)
            {
                counts.Add((int)flag, 0);
            }
        }

        return counts;
    }

    private static MatchConnectionGrant CreateGrant()
    {
        byte[] key = new byte[32];
        using (RandomNumberGenerator random = RandomNumberGenerator.Create())
        {
            random.GetBytes(key);
        }
        return new MatchConnectionGrant
        {
            Host = "127.0.0.1", Port = 9, PlayerId = LocalId, SessionId = 1,
            MatchId = "score-hud-audit", ManifestHash = new string('a', 64),
            Ticket = "audit-only-capability", SessionKey = ByteString.CopyFrom(key),
            ExpiresUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60
        };
    }

    private static void SetField(object target, string name, object value)
    {
        target.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic).SetValue(target, value);
    }

    private static object Invoke(object target, string name, params object[] arguments)
    {
        return target.GetType().GetMethod(name,
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Invoke(target, arguments);
    }

    private static void Check(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        _checks++;
    }
}
