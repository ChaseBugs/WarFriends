using System;
using System.IO;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Runs a rendered source pool/coroutine competition without Photon or real army spawning.</summary>
[InitializeOnLoad]
public static class UnityPoolReturnRaceExport
{
    private const string SessionKey = "WarFriends.PoolReturnRace";

    static UnityPoolReturnRaceExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += ObserveCompletion;
        }
    }

    /// <summary>Creates one occupied source slot and renders both source callback paths.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        new GameObject("ObservationCamera").AddComponent<Camera>();
        new GameObject("PoolReturnRace").AddComponent<UnityPoolReturnRaceProbe>();
        EditorWindow.GetWindow(typeof(Editor).Assembly.GetType("UnityEditor.GameView")).Focus();
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void ObserveCompletion()
    {
        if (!EditorApplication.isPlaying)
        {
            return;
        }
        var probe = UnityEngine.Object.FindObjectOfType<UnityPoolReturnRaceProbe>();
        if (probe == null || !probe.IsComplete)
        {
            return;
        }
        string output = Path.Combine(Directory.GetParent(Application.dataPath).FullName,
            "pool-return-race-reference.json");
        File.WriteAllText(output, (JsonConvert.SerializeObject(new
        {
            unityVersion = Application.unityVersion, graphicsDevice = SystemInfo.graphicsDeviceType.ToString(),
            scope = "Original ObjectPool/PoolableObject, InvokeAfter and RadicalRoutine; " +
                "controlled frame hitch, plain shells, no army manager or Photon.",
            observation = probe.ExportObservation()
        }, Formatting.Indented) + "\n").Replace("\r\n", "\n"));
        SessionState.SetBool(SessionKey, false);
        Debug.Log("UNITY_POOL_RETURN_RACE_OBSERVED");
        EditorApplication.Exit(0);
    }
}
