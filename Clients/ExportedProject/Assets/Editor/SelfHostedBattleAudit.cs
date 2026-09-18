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
        deadline = EditorApplication.timeSinceStartup + 40;
        audit = Check(a, b);
        EditorApplication.update += Update;
    }
    private static async Task Check(MatchConnectionGrant a, MatchConnectionGrant b)
    {
        using (var ct = new CancellationTokenSource(TimeSpan.FromSeconds(30)))
        using (var first = new MatchConnection(a))
        using (var second = new MatchConnection(b))
        {
            Require((await first.ConnectAsync(ct.Token)).Code == "admitted", "first admission");
            Require((await second.ConnectAsync(ct.Token)).Code == "admitted", "second admission");
            Require((await first.ReadyAsync(ct.Token)).Code == "ready", "first ready");
            Require((await second.ReadyAsync(ct.Token)).Code == "ready", "second ready");
            MatchReply state;
            do { await Task.Delay(100, ct.Token); state = await first.PollAsync(ct.Token); }
            while (state.Snapshot.Phase == BattlePhase.Countdown);
            Require(state.Snapshot.Phase == BattlePhase.Running, "running");
            Require((await first.FireAsync(1, 2, 3, ct.Token)).Code == "shot-accepted", "fire");
            state = await second.ForfeitAsync(ct.Token);
            Require(state.Snapshot.WinnerPlayerId == a.PlayerId && !state.Snapshot.RewardEligible, "unscored terminal");
        }
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
