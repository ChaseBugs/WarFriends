using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Records actual source wrapper callbacks without substituting a manual coroutine pump.</summary>
[InitializeOnLoad]
public static class UnityDeploymentCoroutineExport
{
    private const string SessionKey = "WarFriends.DeploymentCoroutine";

    static UnityDeploymentCoroutineExport()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += ObserveCompletion;
        }
    }

    /// <summary>Starts an original paused source wait in a bounded disposable observation.</summary>
    public static void Run()
    {
        PrepareScene();
        BeginObservation();
    }

    /// <summary>Uses the real Game View render loop instead of batch-mode end-of-frame suppression.</summary>
    public static void RunRendered()
    {
        PrepareScene();
        new GameObject("ObservationCamera").AddComponent<Camera>();
        Type gameViewType = typeof(Editor).Assembly.GetType("UnityEditor.GameView");
        EditorWindow.GetWindow(gameViewType).Focus();
        BeginObservation();
    }

    private static void PrepareScene()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        new GameObject("DeploymentCoroutine").AddComponent<UnityDeploymentCoroutineProbe>();
    }

    private static void BeginObservation()
    {
        SessionState.SetBool(SessionKey, true);
        EditorApplication.isPlaying = true;
    }

    private static void ObserveCompletion()
    {
        if (!EditorApplication.isPlaying)
        {
            return;
        }
        var probe = UnityEngine.Object.FindObjectOfType<UnityDeploymentCoroutineProbe>();
        if (probe == null || !probe.IsComplete)
        {
            return;
        }
        string[] sources =
        {
            "Assets/Plugins/Assembly-CSharp-firstpass/WaitForRealSeconds.cs",
            "Assets/Plugins/Assembly-CSharp-firstpass/CoroutineReturn.cs",
            "Assets/Plugins/Assembly-CSharp-firstpass/RadicalRoutine.cs",
            "Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs",
            "Assets/UnityDeploymentCoroutineProbe.cs", "Assets/Editor/UnityDeploymentCoroutineExport.cs"
        };
        string output = Path.Combine(Directory.GetParent(Application.dataPath).FullName,
            "deployment-coroutine-reference.json");
        File.WriteAllText(output, (JsonConvert.SerializeObject(new
        {
            unityVersion = Application.unityVersion,
            graphicsDevice = SystemInfo.graphicsDeviceType.ToString(),
            scope = "Actual RadicalRoutine/WaitForRealSeconds and InvokeAfter phases; " +
                "no spawning manager, pool or same-frame return race.",
            sources = sources.Select(path => new { source = path, normalizedUtf8LfSha256 = Hash(path) }).ToArray(),
            observation = probe.ExportObservation()
        }, Formatting.Indented) + "\n").Replace("\r\n", "\n"));
        SessionState.SetBool(SessionKey, false);
        Debug.Log("UNITY_DEPLOYMENT_COROUTINE_OBSERVED");
        EditorApplication.Exit(0);
    }

    private static string Hash(string path)
    {
        string normalized = File.ReadAllText(path).Replace("\r\n", "\n").Replace('\r', '\n');
        using (var hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(Encoding.UTF8.GetBytes(normalized)))
                .Replace("-", "").ToLowerInvariant();
        }
    }
}
