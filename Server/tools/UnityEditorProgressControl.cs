using System;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Tests rendered Editor frame progression without WarFriends code or assets.</summary>
[InitializeOnLoad]
public static class UnityEditorProgressControl
{
    private const string SessionKey = "WarFriends.EditorProgressControl";
    private const int ObservationSeconds = 12;
    private static DateTime _nextSampleUtc;

    static UnityEditorProgressControl()
    {
        if (SessionState.GetBool(SessionKey, false))
        {
            EditorApplication.update += Observe;
        }
    }

    /// <summary>Runs only in the isolated empty control project.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').EndsWith("/Server/.local/editor-progress-control/Assets"))
        {
            throw new InvalidOperationException("Use the empty disposable control project.");
        }

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        PlayerSettings.runInBackground = true;
        Application.runInBackground = true;
        EditorWindow.GetWindow(typeof(EditorWindow).Assembly.GetType("UnityEditor.GameView", true)).Show();
        SessionState.SetBool(SessionKey, true);
        SessionState.SetFloat(SessionKey + ".Started", (float)EditorApplication.timeSinceStartup);
        EditorApplication.update -= Observe;
        EditorApplication.update += Observe;
        EditorApplication.isPlaying = true;
    }

    private static void Observe()
    {
        if (EditorApplication.isPlaying)
        {
            Application.runInBackground = true;
        }
        DateTime now = DateTime.UtcNow;
        if (now < _nextSampleUtc)
        {
            return;
        }

        _nextSampleUtc = now.AddSeconds(1);
        File.AppendAllText(Path.Combine(Application.dataPath, "../progress.log"),
            now.ToString("O") + " frame=" + Time.frameCount + " playing=" + EditorApplication.isPlaying +
            " background=" + Application.runInBackground + "\n");
        if (EditorApplication.timeSinceStartup - SessionState.GetFloat(SessionKey + ".Started", 0) >= ObservationSeconds)
        {
            SessionState.SetBool(SessionKey, false);
            EditorApplication.update -= Observe;
            EditorApplication.Exit(0);
        }
    }
}
