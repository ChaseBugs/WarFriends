using System;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Runs a coroutine-only observation in a disposable recovered project.</summary>
[InitializeOnLoad]
public static class UnityGunslingerHolsterExport
{
    private const string SessionKey = "WarFriends.GunslingerHolsterExport";
    private const string OutputVariable = "WAR_GUNSLINGER_HOLSTER_OUTPUT";

    static UnityGunslingerHolsterExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += ObserveCompletion;
        }
    }

    /// <summary>Starts the source coroutine observation in an empty disposable scene.</summary>
    public static void Run()
    {
        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable(OutputVariable)))
        {
            throw new InvalidOperationException("Set " + OutputVariable + ".");
        }

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        new GameObject("GunslingerHolsterProbe").AddComponent<UnityGunslingerHolsterProbe>();
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void ObserveCompletion()
    {
        UnityGunslingerHolsterProbe probe = UnityEngine.Object.FindObjectOfType<UnityGunslingerHolsterProbe>();
        if (!EditorApplication.isPlaying || probe == null || !probe.IsComplete)
        {
            return;
        }

        File.WriteAllText(Environment.GetEnvironmentVariable(OutputVariable), JsonConvert.SerializeObject(new
        {
            version = 1,
            unity = Application.unityVersion,
            captureRate = Time.captureFramerate,
            timeScale = Time.timeScale,
            coroutineSha256 = Hash("Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs"),
            probeSha256 = Hash("Assets/UnityGunslingerHolsterProbe.cs"),
            exporterSha256 = Hash("Assets/Editor/UnityGunslingerHolsterExport.cs"),
            observations = probe.ExportObservation()
        }, Formatting.Indented));
        Debug.Log("GUNSLINGER_HOLSTER_EXPORT_PASSED");
        SessionState.SetBool(SessionKey, false);
        EditorApplication.update -= ObserveCompletion;
        EditorApplication.Exit(0);
    }

    private static string Hash(string path)
    {
        using (SHA256 hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }
}
