using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Checks that stopping the source loader does not lose its outstanding native scene operation.</summary>
[InitializeOnLoad]
public static class UnitySceneLoadDrainAudit
{
    private const string SessionKey = "WarFriends.SceneLoadDrainAudit";
    private const string SceneKey = SessionKey + ".Scene";
    private const string MarkerName = "AbortedNativeLoadMarker";
    private const int TimeoutSeconds = 30;

    static UnitySceneLoadDrainAudit()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += BeginWhenPlaying;
        }
    }

    /// <summary>Creates a disposable build scene and enters Play Mode for a real source scene load.</summary>
    public static void RunAsync()
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        new GameObject(MarkerName);
        string path = "Assets/__SceneLoadDrainAudit_" + Guid.NewGuid().ToString("N") + ".unity";
        if (!EditorSceneManager.SaveScene(scene, path))
        {
            throw new InvalidOperationException("The disposable scene could not be saved.");
        }

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        var scenes = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);
        scenes.Add(new EditorBuildSettingsScene(path, true));
        EditorBuildSettings.scenes = scenes.ToArray();
        SessionState.SetString(SceneKey, path);
        SessionState.SetBool(SessionKey, true);
        EditorApplication.update -= BeginWhenPlaying;
        EditorApplication.update += BeginWhenPlaying;
        EditorApplication.isPlaying = true;
    }

    private static void BeginWhenPlaying()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
        {
            return;
        }

        EditorApplication.update -= BeginWhenPlaying;
        RunChecksAsync();
    }

    private static async void RunChecksAsync()
    {
        try
        {
            string path = SessionState.GetString(SceneKey, string.Empty);
            MapManager map = CreateInactiveSourceManagers(path);
            Require(map.loadProgress == 0f, "Progress before issuing a load must be zero.");
            IEnumerator loading = map.Load("drain-fixture");
            Require(loading.MoveNext(), "The source loader did not issue an asynchronous operation.");
            var operation = loading.Current as AsyncOperation;
            Require(operation != null && !operation.isDone, "Expected an actual pending Unity scene load.");
            Require(map.loadProgress == operation.progress, "The source progress property lost the issued operation.");
            var disposable = loading as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }

            IEnumerator recovery = map.WaitForSceneLoadRoutine();
            Require(recovery.MoveNext() && ReferenceEquals(recovery.Current, operation),
                "Recovery must wait for the native operation after its original enumerator stops.");
            DateTime deadline = DateTime.UtcNow.AddSeconds(TimeoutSeconds);
            while (!operation.isDone)
            {
                Require(DateTime.UtcNow < deadline, "The disposable native scene did not finish loading.");
                await Task.Yield();
            }

            Require(!recovery.MoveNext() && map.loadProgress == 1f &&
                GameObject.Find(MarkerName) != null,
                "Recovery must finish only after the real scene has loaded, without losing final progress.");
            Require(!map.WaitForSceneLoadRoutine().MoveNext(), "A completed load must not block recovery again.");
            await VerifyDiscardAsync(map);
            SessionState.SetBool(SessionKey, false);
            Debug.Log("PASS: actual source scene load retains progress after its enumerator stops; " +
                "abort drain waits for native completion and discards registered/unregistered maps without Init; " +
                "Play Mode, no menu or combat proof.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            SessionState.SetBool(SessionKey, false);
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static MapManager CreateInactiveSourceManagers(string path)
    {
        var owner = new GameObject("InactiveSceneLoadManagers");
        owner.SetActive(false);
        UnityEngine.Object.DontDestroyOnLoad(owner);
        var game = owner.AddComponent<GameController>();
        var controller = owner.AddComponent<GameControllerDeathMatch>();
        typeof(GameController).GetField("mMainController", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(game, controller);
        var map = owner.AddComponent<MapManager>();
        typeof(Singleton<GameController>).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic)
            .SetValue(null, game);
        typeof(Singleton<MapManager>).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic)
            .SetValue(null, map);
        map.mapEntries = new List<MapManager.MapEntry>
        {
            new MapManager.MapEntry { name = "drain-fixture", levelPVPName = Path.GetFileNameWithoutExtension(path) },
        };
        return map;
    }

    private static async Task VerifyDiscardAsync(MapManager map)
    {
        for (int index = 0; index < 2; index++)
        {
            var root = new GameObject("DiscardedAbortMap");
            root.SetActive(false);
            var definition = root.AddComponent<MapDefinition>();
            definition.floorTransform = root.transform;
            definition.playersPositions = null;
            root.SetActive(true);
            map.currentMapDef = index == 0 ? definition : null;
            map.DiscardAbortedScene();
            DateTime deadline = DateTime.UtcNow.AddSeconds(TimeoutSeconds);
            while (root != null)
            {
                Require(DateTime.UtcNow < deadline, "The discarded map survived deferred destruction.");
                await Task.Yield();
            }

            Require(root == null && map.currentMapDef == null && GameObject.Find(MarkerName) != null,
                "Abort discard must remove registered and late maps without initializing or deleting unrelated objects.");
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
