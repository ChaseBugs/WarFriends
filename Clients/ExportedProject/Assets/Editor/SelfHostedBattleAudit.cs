using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using UnityEditor;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Executes the portable Client SDK in Unity's actual Mono runtime.
/// Run without -quit; this method exits Unity after its asynchronous test.</summary>
public static class SelfHostedBattleAudit
{
    private static Task audit;
    private static double deadline;
    public static void Run()
    {
        string path = Environment.GetEnvironmentVariable("WAR_BATTLE_GRANTS_FILE");
        if (string.IsNullOrEmpty(path)) throw new InvalidOperationException("Set WAR_BATTLE_GRANTS_FILE.");
        string[] lines = File.ReadAllLines(path);
        if (lines.Length != 2) throw new InvalidOperationException("Expected two protobuf-JSON grants.");
        var a = JsonParser.Default.Parse<MatchConnectionGrant>(lines[0]);
        var b = JsonParser.Default.Parse<MatchConnectionGrant>(lines[1]);
        CheckSnapshotOrdering();
        CheckAnimationAliases();
        deadline = EditorApplication.timeSinceStartup + 40;
        audit = Check(a, b);
        EditorApplication.update += Update;
    }
    private static async Task Check(MatchConnectionGrant a, MatchConnectionGrant b)
    {
        var owner = new GameObject("SelfHostedBattleAudit");
        var first = owner.AddComponent<SelfHostedBattleClient>();
        int mainThread = Thread.CurrentThread.ManagedThreadId;
        int updates = 0;
        first.StateReceived += state =>
        {
            Require(Thread.CurrentThread.ManagedThreadId == mainThread, "adapter main-thread state event");
            updates++;
        };
        try
        {
        using (var ct = new CancellationTokenSource(TimeSpan.FromSeconds(30)))
        using (var second = new MatchConnection(b))
        {
            await first.Connect(a);
            Require(first.IsConnected && first.State.Players.Count == 2, "adapter admission");
            Require((await second.ConnectAsync(ct.Token)).Code == "admitted", "second admission");
            await first.Ready();
            Require(first.State.Players[0].Ready, "adapter ready");
            Require((await second.ReadyAsync(ct.Token)).Code == "ready", "second ready");
            do { await Task.Delay(100, ct.Token); await first.Refresh(); }
            while (first.State.Phase == BattlePhase.Countdown);
            Require(first.State.Phase == BattlePhase.Running, "running");
            await first.Fire(new Vector3(1, 2, 3));
            Require(first.State.Players[0].ShotsFired == 1, "adapter fire");
            var state = await second.ForfeitAsync(ct.Token);
            Require(state.Snapshot.WinnerPlayerId == a.PlayerId && !state.Snapshot.RewardEligible, "unscored terminal");
            await first.Refresh();
            Require(first.State.Phase == BattlePhase.Ended && updates >= 5, "adapter receives terminal snapshot");
        }
        }
        finally { UnityEngine.Object.DestroyImmediate(owner); }
    }
    private static void CheckSnapshotOrdering()
    {
        var owner = new GameObject("SnapshotOrderingAudit");
        try
        {
            var client = owner.AddComponent<SelfHostedBattleClient>();
            var apply = typeof(SelfHostedBattleClient).GetMethod("Apply", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var current = new MatchReply { Snapshot = new MatchSnapshot { ServerTick = 10, StateRevision = 5 } };
            current.Snapshot.Players.Add(new BattlePlayerState { CombatEnabled = true, Health = 40, MaxHealth = 100, DamageRevision = 2 });
            apply.Invoke(client, new object[] { current });
            var stale = current.Clone(); stale.Snapshot.StateRevision = 4; stale.Snapshot.Players[0].Health = 100;
            apply.Invoke(client, new object[] { stale });
            Require(client.State.Players[0].Health == 40, "same-tick stale health cannot rewind");
            current.Snapshot.StateRevision = 6; current.Snapshot.Players[0].Health = 0; current.Snapshot.Players[0].Dead = true;
            apply.Invoke(client, new object[] { current });
            Require(client.State.Players[0].Dead, "same-tick new health snapshot accepted");
            current.Snapshot.Players[0].Health = 99;
            Require(client.State.Players[0].Health == 0, "snapshot ownership detached");
        }
        finally { UnityEngine.Object.DestroyImmediate(owner); }
    }
    private static void CheckAnimationAliases()
    {
        var owner = new GameObject("AnimationAliasAudit");
        var original = new AnimationClip { legacy = true };
        var other = new AnimationClip { legacy = true };
        try
        {
            var animation = owner.AddComponent<Animation>();
            animation.AddClip(original, "idle_1");
            animation.AddClip(original, "run_0");
            SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
            Require(animation.GetClip("idle") != null && animation.GetClip("run") != null, "unambiguous recovered aliases");
            var canonicalIdle = animation.GetClip("idle");
            animation.AddClip(other, "idle_2");
            SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
            Require(animation.GetClip("idle") == canonicalIdle, "canonical alias never replaced");
            animation.RemoveClip("idle");
            SoldierAnimationController.RestoreRecoveredBaseAliases(animation);
            Require(animation.GetClip("idle") == null, "ambiguous aliases never guessed");
        }
        finally { UnityEngine.Object.DestroyImmediate(owner); UnityEngine.Object.DestroyImmediate(original); UnityEngine.Object.DestroyImmediate(other); }
    }
    private static void Require(bool value, string name) { if (!value) throw new InvalidOperationException("Battle SDK audit failed: " + name); }
    private static void Update()
    {
        if (!audit.IsCompleted && EditorApplication.timeSinceStartup < deadline) return;
        EditorApplication.update -= Update;
        if (audit.IsCompleted && !audit.IsFaulted && !audit.IsCanceled)
        {
            Debug.Log("UNITY_BATTLE_SDK_PASSED two participants, ready, fire, forfeit; Unity " + Application.unityVersion);
            EditorApplication.Exit(0);
        }
        else
        {
            Debug.LogError(audit.Exception == null ? "Unity Battle SDK audit timed out/cancelled" : audit.Exception.ToString());
            EditorApplication.Exit(1);
        }
    }
}
