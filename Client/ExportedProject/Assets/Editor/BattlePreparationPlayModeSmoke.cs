using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
internal static class BattlePreparationPlayModeSmoke
{
    private const string ActiveKey = "WarFriends.BattlePreparationSmoke.Active";
    private const string StartKey = "WarFriends.BattlePreparationSmoke.Start";
    private const string ActivatedKey = "WarFriends.BattlePreparationSmoke.Activated";
    private const string ActivatedAtKey = "WarFriends.BattlePreparationSmoke.ActivatedAt";
    private const string ErrorsKey = "WarFriends.BattlePreparationSmoke.Errors";
    private const string RequestFile = "battle-preparation-smoke.request";

    static BattlePreparationPlayModeSmoke()
    {
        string request = ClientPath(RequestFile);
        if (File.Exists(request))
        {
            File.Delete(request);
            EditorApplication.delayCall += Begin;
        }
        if (SessionState.GetBool(ActiveKey, false))
        {
            Subscribe();
        }
    }

    private static void Begin()
    {
        SessionState.SetBool(ActiveKey, true);
        SessionState.SetString(StartKey, DateTime.UtcNow.Ticks.ToString());
        SessionState.SetBool(ActivatedKey, false);
        SessionState.SetString(ActivatedAtKey, string.Empty);
        SessionState.SetString(ErrorsKey, string.Empty);
        EditorSceneManager.OpenScene("Assets/Scenes/SplashScene.unity", OpenSceneMode.Single);
        Subscribe();
        EditorApplication.isPlaying = true;
    }

    private static void Subscribe()
    {
        EditorApplication.update -= Update;
        EditorApplication.update += Update;
        Application.logMessageReceived -= OnLog;
        Application.logMessageReceived += OnLog;
    }

    private static void Update()
    {
        if (!SessionState.GetBool(ActiveKey, false))
        {
            Unsubscribe();
            return;
        }

        double elapsed = Elapsed();
        if (EditorApplication.isPlaying)
        {
            if (!SessionState.GetBool(ActivatedKey, false))
            {
                GameObject main = FindSceneObject("GUIScreen Main");
                GameObject prepare = FindSceneObject("GUIScreen Prepare for Battle");
                if (elapsed >= 8.0 && main != null && main.activeInHierarchy && prepare != null)
                {
                    prepare.SetActive(true);
                    SessionState.SetBool(ActivatedKey, true);
                    SessionState.SetString(ActivatedAtKey, DateTime.UtcNow.Ticks.ToString());
                    Debug.Log("Battle preparation smoke: screen activated.");
                }
            }
            else
            {
                double activeSeconds = ActivatedElapsed();
                if (activeSeconds >= 3.0 && activeSeconds < 3.3)
                {
                    ScreenCapture.CaptureScreenshot(ClientPath("battle-preparation-after.png"));
                }
                if (activeSeconds >= 7.0)
                {
                    EditorApplication.isPlaying = false;
                }
            }

            if (elapsed >= 85.0)
            {
                EditorApplication.isPlaying = false;
            }
            return;
        }

        WriteReport();
        SessionState.SetBool(ActiveKey, false);
        Unsubscribe();
    }

    private static void OnLog(string condition, string stackTrace, LogType type)
    {
        if (!SessionState.GetBool(ActiveKey, false) ||
            (type != LogType.Error && type != LogType.Exception && type != LogType.Assert))
        {
            return;
        }
        string current = SessionState.GetString(ErrorsKey, string.Empty);
        if (current.Length < 12000)
        {
            current += "[" + type + "] " + condition.Replace('\r', ' ').Replace('\n', ' ') + Environment.NewLine;
            current += stackTrace.Replace('\r', ' ').Replace('\n', ' ') + Environment.NewLine;
            SessionState.SetString(ErrorsKey, current);
        }
    }

    private static GameObject FindSceneObject(string name)
    {
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject candidate in objects)
        {
            if (candidate.name == name && candidate.scene.IsValid())
            {
                return candidate;
            }
        }
        return null;
    }

    private static double Elapsed()
    {
        long ticks;
        return long.TryParse(SessionState.GetString(StartKey, "0"), out ticks)
            ? TimeSpan.FromTicks(DateTime.UtcNow.Ticks - ticks).TotalSeconds
            : 0.0;
    }

    private static double ActivatedElapsed()
    {
        long ticks;
        return long.TryParse(SessionState.GetString(ActivatedAtKey, "0"), out ticks)
            ? TimeSpan.FromTicks(DateTime.UtcNow.Ticks - ticks).TotalSeconds
            : 0.0;
    }

    private static void WriteReport()
    {
        StringBuilder report = new StringBuilder();
        report.AppendLine("screen_activated=" + SessionState.GetBool(ActivatedKey, false));
        report.AppendLine("elapsed_seconds=" + Elapsed().ToString("F1"));
        report.AppendLine("errors:");
        report.Append(SessionState.GetString(ErrorsKey, string.Empty));
        File.WriteAllText(ClientPath("battle-preparation-smoke.txt"), report.ToString());
        Debug.Log("Battle preparation smoke report written.");
    }

    private static string ClientPath(string fileName)
    {
        DirectoryInfo exportedProject = Directory.GetParent(Application.dataPath);
        return Path.Combine(exportedProject.Parent.FullName, fileName);
    }

    private static void Unsubscribe()
    {
        EditorApplication.update -= Update;
        Application.logMessageReceived -= OnLog;
    }
}
