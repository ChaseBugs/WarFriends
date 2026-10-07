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
        string reconnectPath = Environment.GetEnvironmentVariable("WAR_BATTLE_RECONNECT_FILE");
        string backendUrl = Environment.GetEnvironmentVariable("WAR_BATTLE_AUTO_BACKEND");
        string dropPollPath = Environment.GetEnvironmentVariable("WAR_BATTLE_DROP_POLL_FILE");
        string dropForfeitPath = Environment.GetEnvironmentVariable("WAR_BATTLE_DROP_FORFEIT_FILE");
        if (string.IsNullOrEmpty(path)) throw new InvalidOperationException("Set WAR_BATTLE_GRANTS_FILE.");
        if (string.IsNullOrEmpty(reconnectPath)) throw new InvalidOperationException("Set WAR_BATTLE_RECONNECT_FILE.");
        if (string.IsNullOrEmpty(backendUrl) || string.IsNullOrEmpty(dropPollPath) ||
            string.IsNullOrEmpty(dropForfeitPath))
            throw new InvalidOperationException("Set automatic reconnect audit endpoints.");
        string[] lines = File.ReadAllLines(path);
        if (lines.Length != 2) throw new InvalidOperationException("Expected two protobuf-JSON grants.");
        var a = JsonParser.Default.Parse<MatchConnectionGrant>(lines[0]);
        var b = JsonParser.Default.Parse<MatchConnectionGrant>(lines[1]);
        CheckSnapshotOrdering();
        CheckReconnectClock();
        CheckEventSnapshotBoundary();
        CheckAnimationAliases();
        deadline = EditorApplication.timeSinceStartup + 50;
        audit = Check(a, b, reconnectPath, backendUrl, dropPollPath, dropForfeitPath);
        EditorApplication.update += Update;
    }
    private static async Task Check(MatchConnectionGrant a, MatchConnectionGrant b,
        string reconnectPath, string backendUrl, string dropPollPath, string dropForfeitPath)
    {
        var owner = new GameObject("SelfHostedBattleAudit");
        var first = owner.AddComponent<SelfHostedBattleClient>();
        // Create the login component explicitly: Singleton<T> calls DontDestroyOnLoad,
        // which Unity permits only in Play Mode, not this batch-mode Editor audit.
        var login = owner.AddComponent<GameLoginManager>();
        typeof(GameLoginManager).GetField("loginAccessToken",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            .SetValue(login, "audit-token");
        typeof(SelfHostedBattleClient).GetField("backendEndpoint",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
            .SetValue(first, backendUrl);
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
            while (!File.Exists(reconnectPath)) await Task.Delay(100, ct.Token);
            int beforeReconnect = updates;
            ulong processedBeforeReconnect = first.ProcessedEventId;
            File.WriteAllText(dropPollPath, "drop");
            var update = typeof(SelfHostedBattleClient).GetMethod("Update",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            bool sawRecovery = false;
            for (int attempt = 0; attempt < 200; attempt++)
            {
                update.Invoke(first, null);
                await Task.Delay(100, ct.Token);
                if (first.IsReconnecting) sawRecovery = true;
                if (sawRecovery && first.IsConnected && !first.IsReconnecting) break;
            }
            Require(sawRecovery, "lost UDP polls trigger automatic reconnect");
            Require(first.IsConnected && first.State.Phase == BattlePhase.Running &&
                first.ProcessedEventId == processedBeforeReconnect && updates > beforeReconnect,
                "same Unity adapter resumes its running snapshot and event cursor");
            await first.Reload();
            Require(first.State.Players[0].LastCommandId == 3,
                "Unity command sequence continues after fresh Worker admission");
            File.WriteAllText(dropForfeitPath, "drop");
            Task forfeit = first.ForfeitWithRecovery();
            while (!forfeit.IsCompleted)
            {
                update.Invoke(first, null); // Normal frames must not replace this pending session.
                await Task.Delay(100, ct.Token);
            }
            await forfeit;
            Require(first.State.Phase == BattlePhase.Ended &&
                first.State.WinnerPlayerId == b.PlayerId && !first.State.RewardEligible &&
                first.State.Players[0].LastCommandId == 4,
                "lost Forfeit reply replays one command and confirms the Worker terminal snapshot");
            var state = await second.PollAsync(ct.Token);
            Require(state.Snapshot.Phase == BattlePhase.Ended && updates >= 5,
                "both participants observe the authoritative forfeit");
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
    private static void CheckReconnectClock()
    {
        var snapshot = new MatchSnapshot { PauseHostTick = 300 };
        snapshot.Players.Add(new BattlePlayerState { PlayerId = "local" });
        snapshot.Players.Add(new BattlePlayerState { PlayerId = "other", Reconnecting = true,
            ReconnectDeadlineHostTick = 600 });
        float seconds;
        Require(SelfHostedBattleClient.TryGetOpponentReconnectSeconds(snapshot, "local", out seconds) &&
            seconds == 10f, "opponent grace uses host tick, not paused simulation tick");
        snapshot.PauseHostTick = 600;
        Require(SelfHostedBattleClient.TryGetOpponentReconnectSeconds(snapshot, "local", out seconds) &&
            seconds == 0f, "expired host deadline cannot become a local victory");
        snapshot.Players[1].Reconnecting = false;
        Require(!SelfHostedBattleClient.TryGetOpponentReconnectSeconds(snapshot, "local", out seconds),
            "resumed opponent hides the reconnect countdown");
    }
    private static void CheckEventSnapshotBoundary()
    {
        var snapshot = new MatchSnapshot { LatestEventId = 12 };
        Require(SelfHostedBattleClient.ValidateSnapshotEventBoundary(snapshot, 7, 14) == 12,
            "expired event cursor resumes after an authoritative snapshot");
        bool rejected = false;
        try { SelfHostedBattleClient.ValidateSnapshotEventBoundary(snapshot, 13, 14); }
        catch (InvalidOperationException) { rejected = true; }
        Require(rejected, "snapshot cannot rewind an already presented event");
        rejected = false;
        try { SelfHostedBattleClient.ValidateSnapshotEventBoundary(snapshot, 7, 11); }
        catch (InvalidOperationException) { rejected = true; }
        Require(rejected, "snapshot cannot claim events beyond the host response");
    }
    private static void Require(bool value, string name) { if (!value) throw new InvalidOperationException("Battle SDK audit failed: " + name); }
    private static void Update()
    {
        if (!audit.IsCompleted && EditorApplication.timeSinceStartup < deadline) return;
        EditorApplication.update -= Update;
        if (audit.IsCompleted && !audit.IsFaulted && !audit.IsCanceled)
        {
            Debug.Log("UNITY_BATTLE_SDK_PASSED two participants, ready, fire, automatic reconnect, forfeit; Unity " + Application.unityVersion);
            EditorApplication.Exit(0);
        }
        else
        {
            Debug.LogError(audit.Exception == null ? "Unity Battle SDK audit timed out/cancelled" : audit.Exception.ToString());
            EditorApplication.Exit(1);
        }
    }
}
