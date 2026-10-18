using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Exports actual native Mortar coroutine timing from a private empty scene.</summary>
[InitializeOnLoad]
public static class UnityMortarClockExport
{
    private const string SessionKey = "WarFriends.MortarClockExport";

    static UnityMortarClockExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += ObserveCompletion;
        }
    }

    /// <summary>Starts the recovered coroutine probe without activating gameplay or provider components.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        var holder = new GameObject("MortarClockProbe");
        var probe = holder.AddComponent<UnityMortarClockProbe>();
        probe.HideSeconds = AssetDatabase.LoadAssetAtPath<AnimationClip>(
            "Assets/AnimationClip/mortar_hide.anim").length;
        probe.UpSeconds = AssetDatabase.LoadAssetAtPath<AnimationClip>("Assets/AnimationClip/mortar_up.anim").length;
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void ObserveCompletion()
    {
        if (!EditorApplication.isPlaying)
        {
            return;
        }
        UnityMortarClockProbe probe = UnityEngine.Object.FindObjectOfType<UnityMortarClockProbe>();
        if (probe == null || !probe.IsComplete)
        {
            return;
        }
        bool valid = probe.Observations.Count == 3 && probe.Observations.All(row =>
            row.callbackTick.HasValue && row.pollTick.HasValue && row.handReturnTick.HasValue &&
            row.relocationTick.HasValue);
        string output = Path.Combine(Directory.GetParent(Application.dataPath).FullName, "mortar-clock-reference.json");
        File.WriteAllText(output, (JsonConvert.SerializeObject(new
        {
            unityVersion = Application.unityVersion,
            scope = "Actual Core_BaseScript.InvokeAfter and strict deadline; " +
                "no gameplay, animation or physics update-order proof.",
            captureRate = Time.captureFramerate,
            hideSeconds = probe.HideSeconds,
            upSeconds = probe.UpSeconds,
            observations = probe.Observations
        }, Formatting.Indented) + "\n").Replace("\r\n", "\n"));
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= ObserveCompletion;
        Debug.Log("UNITY_MORTAR_CLOCK_EXPORT_COMPLETE valid=" + valid);
        EditorApplication.Exit(valid ? 0 : 1);
    }
}
