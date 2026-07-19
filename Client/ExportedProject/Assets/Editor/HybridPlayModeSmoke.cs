using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class HybridPlayModeSmoke
{
    private const string ActiveKey = "WarFriends.HybridSmoke.Active";
    private const string StartTicksKey = "WarFriends.HybridSmoke.StartTicks";
    private const string ErrorCountKey = "WarFriends.HybridSmoke.ErrorCount";
    private const string ErrorSamplesKey = "WarFriends.HybridSmoke.ErrorSamples";
    private const string LastSceneKey = "WarFriends.HybridSmoke.LastScene";
    private const string SceneHistoryKey = "WarFriends.HybridSmoke.SceneHistory";
    private const double DurationSeconds = 45.0;

    static HybridPlayModeSmoke()
    {
        if (SessionState.GetBool(ActiveKey, false))
        {
            Subscribe();
        }
    }

    public static void Start()
    {
        SessionState.SetBool(ActiveKey, true);
        SessionState.SetString(StartTicksKey, DateTime.UtcNow.Ticks.ToString());
        SessionState.SetInt(ErrorCountKey, 0);
        SessionState.SetString(ErrorSamplesKey, string.Empty);
        SessionState.SetString(LastSceneKey, string.Empty);
        SessionState.SetString(SceneHistoryKey, string.Empty);

        EditorSceneManager.OpenScene("Assets/Scenes/SplashScene.unity", OpenSceneMode.Single);
        Subscribe();
        RecordScenes();
        Debug.Log("Hybrid Play Mode smoke test started for " + DurationSeconds + " seconds.");
        EditorApplication.isPlaying = true;
    }

    private static void Subscribe()
    {
        EditorApplication.update -= Update;
        EditorApplication.update += Update;
        Application.logMessageReceived -= OnLog;
        Application.logMessageReceived += OnLog;
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private static void Update()
    {
        if (!SessionState.GetBool(ActiveKey, false))
        {
            Unsubscribe();
            return;
        }

        RecordScenes();
        long startTicks;
        if (!long.TryParse(SessionState.GetString(StartTicksKey, "0"), out startTicks))
        {
            startTicks = DateTime.UtcNow.Ticks;
        }

        double elapsed = TimeSpan.FromTicks(DateTime.UtcNow.Ticks - startTicks).TotalSeconds;
        if (elapsed < DurationSeconds)
        {
            return;
        }

        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
            return;
        }

        Finish(elapsed);
    }

    private static void RecordScenes()
    {
        int sceneCount = SceneManager.sceneCount;
        if (sceneCount == 0)
        {
            RecordSceneName("<none>");
            return;
        }

        for (int index = 0; index < sceneCount; index++)
        {
            Scene scene = SceneManager.GetSceneAt(index);
            RecordSceneName(scene.IsValid() ? scene.name : "<none>");
        }
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        RecordSceneName(scene.IsValid() ? scene.name : "<none>");
    }

    private static void RecordSceneName(string currentScene)
    {
        string history = SessionState.GetString(SceneHistoryKey, string.Empty);
        string paddedHistory = " -> " + history + " -> ";
        if (paddedHistory.Contains(" -> " + currentScene + " -> "))
        {
            return;
        }

        SessionState.SetString(LastSceneKey, currentScene);
        if (history.Length > 0)
        {
            history += " -> ";
        }
        SessionState.SetString(SceneHistoryKey, history + currentScene);
    }

    private static void OnLog(string condition, string stackTrace, LogType type)
    {
        if (!SessionState.GetBool(ActiveKey, false) ||
            (type != LogType.Error && type != LogType.Exception && type != LogType.Assert))
        {
            return;
        }

        int count = SessionState.GetInt(ErrorCountKey, 0) + 1;
        SessionState.SetInt(ErrorCountKey, count);
        if (count <= 20)
        {
            string samples = SessionState.GetString(ErrorSamplesKey, string.Empty);
            samples += "[" + type + "] " + OneLine(condition) + Environment.NewLine;
            if (!string.IsNullOrEmpty(stackTrace))
            {
                samples += OneLine(stackTrace) + Environment.NewLine;
            }
            SessionState.SetString(ErrorSamplesKey, samples);
        }
    }

    private static void Finish(double elapsed)
    {
        int errorCount = SessionState.GetInt(ErrorCountKey, 0);
        StringBuilder report = new StringBuilder();
        report.AppendLine("duration_seconds=" + elapsed.ToString("F1"));
        report.AppendLine("scene_history=" + SessionState.GetString(SceneHistoryKey, string.Empty));
        report.AppendLine("managed_error_count=" + errorCount);
        report.AppendLine("error_samples:");
        report.Append(SessionState.GetString(ErrorSamplesKey, string.Empty));

        string reportPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "hybrid-playmode-smoke.txt"));
        File.WriteAllText(reportPath, report.ToString());
        Debug.Log("Hybrid Play Mode smoke test finished: errors=" + errorCount + ", report=" + reportPath);

        SessionState.SetBool(ActiveKey, false);
        Unsubscribe();
        EditorApplication.Exit(errorCount == 0 ? 0 : 1);
    }

    private static void Unsubscribe()
    {
        EditorApplication.update -= Update;
        Application.logMessageReceived -= OnLog;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private static string OneLine(string value)
    {
        return value.Replace('\r', ' ').Replace('\n', ' ');
    }
}
