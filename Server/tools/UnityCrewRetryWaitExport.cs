using System;
using System.IO;
using System.Security.Cryptography;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Captures automatic source InvokeAfter/WaitForSeconds callbacks in a disposable empty scene.</summary>
[InitializeOnLoad]
public static class UnityCrewRetryWaitExport
{
    private const string ActiveKey = "WarFriends.CrewRetryWait";
    private static CrewRetryWaitProbe _probe;

    static UnityCrewRetryWaitExport()
    {
        if (SessionState.GetBool(ActiveKey, false))
        {
            EditorApplication.update += Observe;
        }
    }

    /// <summary>Starts the isolated coroutine capture without activating recovered gameplay.</summary>
    public static void Run()
    {
        string output = Environment.GetEnvironmentVariable("WAR_CREW_RETRY_OUTPUT");
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/") ||
            string.IsNullOrEmpty(output) || !Path.IsPathRooted(output))
        {
            throw new InvalidOperationException("A disposable project and absolute output are required.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        SessionState.SetBool(ActiveKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void Observe()
    {
        if (!Application.isPlaying || Time.frameCount < 3)
        {
            return;
        }
        try
        {
            if (_probe == null)
            {
                Time.captureFramerate = 30;
                Time.timeScale = 1;
                _probe = new GameObject("SourceRetryWaitOnly").AddComponent<CrewRetryWaitProbe>();
                return;
            }
            if (!_probe.IsComplete)
            {
                return;
            }
            string text = JsonConvert.SerializeObject(new
            {
                version = 1, client = "1.4.0", unity = Application.unityVersion,
                fixture = "Original InvokeAfter five-scaled-second waits, automatic coroutine dispatch and pause.",
                sourceSha256 = Hash("Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs"),
                capture = _probe.Capture()
            }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
            File.WriteAllText(Environment.GetEnvironmentVariable("WAR_CREW_RETRY_OUTPUT"), text);
            SessionState.SetBool(ActiveKey, false);
            EditorApplication.update -= Observe;
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            SessionState.SetBool(ActiveKey, false);
            EditorApplication.Exit(1);
        }
    }

    private static string Hash(string path)
    {
        using (var hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path)))
                .Replace("-", "").ToLowerInvariant();
        }
    }
}
