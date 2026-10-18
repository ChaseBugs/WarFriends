using System;
using System.IO;
using System.Linq;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Runs the recovered coroutine and pool primitives in a disposable native Unity project.</summary>
[InitializeOnLoad]
public static class UnityPoolReturnClockExport
{
    private const string SessionKey = "WarFriends.PoolReturnClock";

    static UnityPoolReturnClockExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += ObserveCompletion;
        }
    }

    /// <summary>Starts controlled two-stage waits with pause, slow motion and forced pool reuse.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        CreateScenario("MinimumDelay", 2f, false, 0);
        CreateScenario("MaximumDelay", 3f, false, 0);
        CreateScenario("ForcedReuseBeforeHide", 2f, true, 20);
        CreateScenario("ForcedReuseAfterHide", 2f, true, 140);
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void CreateScenario(string name, float delay, bool shouldForceReturn, int forcedReturnTick)
    {
        new GameObject(name).AddComponent<UnityPoolReturnClockProbe>()
            .Configure(delay, shouldForceReturn, forcedReturnTick);
    }

    private static void ObserveCompletion()
    {
        if (!EditorApplication.isPlaying)
        {
            return;
        }
        UnityPoolReturnClockProbe[] probes = UnityEngine.Object.FindObjectsOfType<UnityPoolReturnClockProbe>();
        if (probes.Length != 4 || probes.Any(probe => !probe.IsComplete))
        {
            return;
        }
        string output = Path.Combine(Directory.GetParent(Application.dataPath).FullName,
            "pool-return-clock-reference.json");
        File.WriteAllText(output, (JsonConvert.SerializeObject(new
        {
            unityVersion = Application.unityVersion,
            scope = "Recovered InvokeAfter/PoolableObject/ObjectPool on plain shells; " +
                "no EnemyController death or Photon.",
            scenarios = probes.OrderBy(probe => probe.name).Select(probe => probe.ExportObservation()).ToArray()
        }, Formatting.Indented) + "\n").Replace("\r\n", "\n"));
        SessionState.SetBool(SessionKey, false);
        Debug.Log("UNITY_POOL_RETURN_CLOCK_PASSED");
        EditorApplication.Exit(0);
    }
}
