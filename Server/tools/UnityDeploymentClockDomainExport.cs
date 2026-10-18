using System;
using System.IO;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Observes original wait clock domains without starting the network or a battle scene.</summary>
[InitializeOnLoad]
public static class UnityDeploymentClockDomainExport
{
    private const string SessionKey = "WarFriends.DeploymentClockDomains";

    static UnityDeploymentClockDomainExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += ObserveCompletion;
        }
    }

    /// <summary>Creates a bounded pause/resume observation in the disposable project only.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        new GameObject("DeploymentClockDomains").AddComponent<UnityDeploymentClockDomainProbe>();
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void ObserveCompletion()
    {
        if (!EditorApplication.isPlaying)
        {
            return;
        }
        var probe = UnityEngine.Object.FindObjectOfType<UnityDeploymentClockDomainProbe>();
        if (probe == null || !probe.IsComplete)
        {
            return;
        }
        string output = Path.Combine(Directory.GetParent(Application.dataPath).FullName,
            "deployment-clock-domain-reference.json");
        File.WriteAllText(output, (JsonConvert.SerializeObject(new
        {
            unityVersion = Application.unityVersion,
            scope = "Original WaitForRealSeconds.finished polled in Update plus InvokeAfter callbacks; " +
                "no RadicalRoutine, spawn coroutine, pool or scheduling-order proof.",
            observation = probe.ExportObservation()
        }, Formatting.Indented) + "\n").Replace("\r\n", "\n"));
        SessionState.SetBool(SessionKey, false);
        Debug.Log(probe.HasPassed ? "UNITY_DEPLOYMENT_CLOCK_DOMAINS_PASSED" : "UNITY_DEPLOYMENT_CLOCK_DOMAINS_FAILED");
        EditorApplication.Exit(probe.HasPassed ? 0 : 1);
    }
}
