using System;
using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Google.Protobuf;
using War.Protocol;

/// <summary>Runs real Worker traffic through automatic Play Mode polling and original source effects.</summary>
[InitializeOnLoad]
public static class UnityLiveBazookaPlayAudit
{
    private const string SessionKey = "WarFriends.LiveBazookaPlayAudit";
    private const string GrantsVariable = "WAR_BAZOOKA_LIVE_GRANTS_FILE";
    private const int TimeoutSeconds = 70;
    private static Task _audit;
    private static double _deadline;
    private static string _unityFailure;

    static UnityLiveBazookaPlayAudit()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            _deadline = EditorApplication.timeSinceStartup + TimeoutSeconds;
            EditorApplication.update += Observe;
        }
    }

    /// <summary>Preserves source binding data before Play Mode reloads the managed domain.</summary>
    public static void Run()
    {
        UnityLiveBazookaPlayScene.Prepare();
        SessionState.SetBool(SessionKey, true);
        _deadline = EditorApplication.timeSinceStartup + TimeoutSeconds;
        EditorApplication.update -= Observe;
        EditorApplication.update += Observe;
        EditorApplication.isPlaying = true;
    }

    private static void Observe()
    {
        if (EditorApplication.timeSinceStartup > _deadline)
        {
            Finish(new TimeoutException("Live Play Mode bazooka audit timed out at " + UnityLiveBazookaAudit.Stage));
            return;
        }

        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
        {
            return;
        }

        try
        {
            if (_audit == null)
            {
                Application.logMessageReceived += ObserveUnityLog;
                _audit = StartBattleAsync();
            }

            if (_unityFailure != null)
            {
                throw new InvalidOperationException("Unexpected Unity runtime error: " + _unityFailure);
            }

            if (!_audit.IsCompleted)
            {
                return;
            }

            _audit.GetAwaiter().GetResult();
            Finish(null);
        }
        catch (Exception failure)
        {
            Finish(failure);
        }
    }

    private static Task StartBattleAsync()
    {
        string grantsFile = Environment.GetEnvironmentVariable(GrantsVariable);
        if (string.IsNullOrEmpty(grantsFile))
        {
            throw new InvalidOperationException("The trusted fixture must supply a temporary grant file.");
        }

        string[] grants = File.ReadAllLines(grantsFile);
        if (grants.Length != 2)
        {
            throw new InvalidOperationException("Expected two independently admitted UDP participants.");
        }

        GameObject sources = UnityLiveBazookaPlayScene.BindSources();
        UnityBazookaEffectFixture effects = UnityBazookaEffectFixture.StartServices();
        return UnityLiveBazookaAudit.RunPreparedAsync(
            JsonParser.Default.Parse<MatchConnectionGrant>(grants[0]),
            JsonParser.Default.Parse<MatchConnectionGrant>(grants[1]),
            sources,
            effects);
    }

    private static void ObserveUnityLog(string message, string stack, LogType type)
    {
        if (type == LogType.Error || type == LogType.Exception || type == LogType.Assert)
        {
            _unityFailure = message + "\n" + stack;
        }
    }

    private static void Finish(Exception failure)
    {
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= Observe;
        Application.logMessageReceived -= ObserveUnityLog;
        if (failure != null)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
            return;
        }

        Debug.Log("UNITY_LIVE_BAZOOKA_PLAY_PASSED: actual UDP, automatic adapter Update, " +
            "five source explosions, interrupted callback retry and automatic particle emission; " +
            "inactive recovered rigs, no touch input, rendered pixels or audible output proof.");
        EditorApplication.Exit(0);
    }
}
