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
    private const string ScreenshotTakenKey = "WarFriends.HybridSmoke.ScreenshotTaken";
    private const string MainSceneSecondsKey = "WarFriends.HybridSmoke.MainSceneSeconds";
    private const string PlayerDataSecondsKey = "WarFriends.HybridSmoke.PlayerDataSeconds";
    private const string AfterPlayerDataSecondsKey = "WarFriends.HybridSmoke.AfterPlayerDataSeconds";
    private const string MainVisibleSecondsKey = "WarFriends.HybridSmoke.MainVisibleSeconds";
    // A one-shot request lets automation start Play Mode only after Unity has imported this source.
    private const string RequestFileName = "hybrid-playmode-smoke.request";
    private const double DurationSeconds = 65.0;

    static HybridPlayModeSmoke()
    {
        EditorApplication.update -= StopBrokenPlayModeBeforeReload;
        EditorApplication.update += StopBrokenPlayModeBeforeReload;
        string requestPath = GetClientPath(RequestFileName);
        if (File.Exists(requestPath))
        {
            File.Delete(requestPath);
            EditorApplication.delayCall += StartWhenReady;
        }

        if (SessionState.GetBool(ActiveKey, false))
        {
            Subscribe();
        }
    }

    private static void StopBrokenPlayModeBeforeReload()
    {
        if (EditorApplication.isPlaying && EditorApplication.isCompiling && !SessionState.GetBool(ActiveKey, false))
        {
            Debug.LogWarning("Stopping Play Mode because scripts are compiling; recovered runtime state cannot survive an assembly reload.");
            EditorApplication.isPlaying = false;
        }
    }

    private static void StartWhenReady()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
            EditorApplication.delayCall += StartWhenReady;
            return;
        }

        Start();
    }

    public static void Start()
    {
        Application.runInBackground = true;
        SessionState.SetBool(ActiveKey, true);
        SessionState.SetString(StartTicksKey, DateTime.UtcNow.Ticks.ToString());
        SessionState.SetInt(ErrorCountKey, 0);
        SessionState.SetString(ErrorSamplesKey, string.Empty);
        SessionState.SetString(LastSceneKey, string.Empty);
        SessionState.SetString(SceneHistoryKey, string.Empty);
        SessionState.SetBool(ScreenshotTakenKey, false);
        SessionState.SetString(MainSceneSecondsKey, string.Empty);
        SessionState.SetString(PlayerDataSecondsKey, string.Empty);
        SessionState.SetString(AfterPlayerDataSecondsKey, string.Empty);
        SessionState.SetString(MainVisibleSecondsKey, string.Empty);

        EditorSceneManager.OpenScene("Assets/Scenes/SplashScene.unity", OpenSceneMode.Single);
        Subscribe();
        RecordScenes();
        GameObject mainScreen = GameObject.Find("GUIScreen Main");
        if (mainScreen != null && mainScreen.activeInHierarchy)
        {
            RecordFirstTiming(MainVisibleSecondsKey);
        }
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
        GameObject mainScreen = GameObject.Find("GUIScreen Main");
        if (mainScreen != null && mainScreen.activeInHierarchy)
        {
            RecordFirstTiming(MainVisibleSecondsKey);
        }
        long startTicks;
        if (!long.TryParse(SessionState.GetString(StartTicksKey, "0"), out startTicks))
        {
            startTicks = DateTime.UtcNow.Ticks;
        }

        double elapsed = TimeSpan.FromTicks(DateTime.UtcNow.Ticks - startTicks).TotalSeconds;
        if (EditorApplication.isPlaying && elapsed >= 55.0 && !SessionState.GetBool(ScreenshotTakenKey, false))
        {
            SessionState.SetBool(ScreenshotTakenKey, true);
            TryWriteReport(CaptureGameView, "game-view capture");
            TryWriteReport(WriteTutorialLayoutReport, "tutorial layout");
            TryWriteReport(WriteCameraReport, "camera");
            TryWriteReport(WriteVisibleUiReport, "visible UI");
        }
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
        if (scene.IsValid() && scene.name == "MainScene")
        {
            RecordFirstTiming(MainSceneSecondsKey);
        }
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
        if (condition == "BeanstalkServerManager: PlayerDataLoaded")
        {
            RecordFirstTiming(PlayerDataSecondsKey);
        }
        else if (condition == "BeanstalkServerManager: AfterPlayerDataLoaded")
        {
            RecordFirstTiming(AfterPlayerDataSecondsKey);
        }
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
        report.AppendLine("main_scene_seconds=" + SessionState.GetString(MainSceneSecondsKey, "not_reached"));
        report.AppendLine("player_data_seconds=" + SessionState.GetString(PlayerDataSecondsKey, "not_reached"));
        report.AppendLine("after_player_data_seconds=" + SessionState.GetString(AfterPlayerDataSecondsKey, "not_reached"));
        report.AppendLine("main_visible_seconds=" + SessionState.GetString(MainVisibleSecondsKey, "not_reached"));
        report.AppendLine("error_samples:");
        report.Append(SessionState.GetString(ErrorSamplesKey, string.Empty));

        string reportPath = GetClientPath("hybrid-playmode-smoke.txt");
        File.WriteAllText(reportPath, report.ToString());
        Debug.Log("Hybrid Play Mode smoke test finished: errors=" + errorCount + ", report=" + reportPath);

        SessionState.SetBool(ActiveKey, false);
        Unsubscribe();
        if (Application.isBatchMode)
        {
            EditorApplication.Exit(errorCount == 0 ? 0 : 1);
        }
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

    private static void RecordFirstTiming(string key)
    {
        if (!SessionState.GetBool(ActiveKey, false) || !string.IsNullOrEmpty(SessionState.GetString(key, string.Empty)))
        {
            return;
        }
        long startTicks;
        if (long.TryParse(SessionState.GetString(StartTicksKey, "0"), out startTicks))
        {
            double elapsed = TimeSpan.FromTicks(DateTime.UtcNow.Ticks - startTicks).TotalSeconds;
            SessionState.SetString(key, elapsed.ToString("F2"));
        }
    }

    private static void CaptureGameView()
    {
        Camera[] cameras = Camera.allCameras;
        Array.Sort(cameras, delegate(Camera left, Camera right)
        {
            if (ReferenceEquals(left, right)) return 0;
            if (ReferenceEquals(left, null)) return 1;
            if (ReferenceEquals(right, null)) return -1;
            return left.depth.CompareTo(right.depth);
        });
        if (cameras.Length == 0)
        {
            return;
        }

        const int width = 1600;
        const int height = 900;
        RenderTexture renderTexture = RenderTexture.GetTemporary(width, height, 24, RenderTextureFormat.ARGB32);
        RenderTexture previousActive = RenderTexture.active;
        try
        {
            RenderTexture.active = renderTexture;
            GL.Clear(true, true, Color.black);

            foreach (Camera camera in cameras)
            {
                if (camera == null || !camera.isActiveAndEnabled || camera.targetDisplay != 0 || camera.targetTexture != null)
                {
                    continue;
                }
                RenderTexture previousTarget = camera.targetTexture;
                try
                {
                    camera.targetTexture = renderTexture;
                    camera.Render();
                }
                finally
                {
                    camera.targetTexture = previousTarget;
                }
            }

            RenderTexture.active = renderTexture;
            Texture2D screenshot = new Texture2D(width, height, TextureFormat.RGB24, false);
            screenshot.ReadPixels(new Rect(0f, 0f, width, height), 0, 0);
            screenshot.Apply();
            File.WriteAllBytes(GetClientPath("main-ui-after.png"), screenshot.EncodeToPNG());
            UnityEngine.Object.DestroyImmediate(screenshot);
        }
        finally
        {
            RenderTexture.active = previousActive;
            RenderTexture.ReleaseTemporary(renderTexture);
        }
    }

    private static void WriteCameraReport()
    {
        Camera[] cameras = Resources.FindObjectsOfTypeAll<Camera>();
        Array.Sort(cameras, delegate(Camera left, Camera right)
        {
            if (ReferenceEquals(left, right)) return 0;
            if (ReferenceEquals(left, null)) return 1;
            if (ReferenceEquals(right, null)) return -1;
            return left.depth.CompareTo(right.depth);
        });

        StringBuilder report = new StringBuilder();
        foreach (Camera camera in cameras)
        {
            if (camera == null || !camera.gameObject.scene.IsValid())
            {
                continue;
            }
            report.Append(GetHierarchyPath(camera.transform));
            report.Append(" | active=").Append(camera.isActiveAndEnabled);
            report.Append(" | depth=").Append(camera.depth);
            report.Append(" | clear=").Append(camera.clearFlags);
            report.Append(" | mask=0x").Append(camera.cullingMask.ToString("X8"));
            report.Append(" | display=").Append(camera.targetDisplay);
            report.Append(" | target=").Append(camera.targetTexture != null ? camera.targetTexture.name : "<display>");
            report.Append(" | rect=").Append(camera.rect);
            report.AppendLine();
        }
        File.WriteAllText(GetClientPath("main-ui-cameras.txt"), report.ToString());
    }

    private static void WriteVisibleUiReport()
    {
        StringBuilder report = new StringBuilder();
        Component[] components = Resources.FindObjectsOfTypeAll<Component>();
        foreach (Component component in components)
        {
            if (component == null || !component.gameObject.activeInHierarchy || component.GetType().Assembly.GetName().Name != "WarFriends.Gameplay.FirstPass")
            {
                continue;
            }
            Type type = component.GetType();
            if (type.Name != "UISprite" && type.Name != "UITexture")
            {
                continue;
            }
            int width = Mathf.RoundToInt(Mathf.Abs(component.transform.localScale.x));
            int height = Mathf.RoundToInt(Mathf.Abs(component.transform.localScale.y));
            if (width < 140 && height < 70)
            {
                continue;
            }
            report.Append(GetHierarchyPath(component.transform));
            if (type.Name == "UISprite")
            {
                object atlas = type.GetProperty("atlas").GetValue(component, null);
                report.Append(" | sprite=").Append(type.GetProperty("spriteName").GetValue(component, null));
                report.Append(" | atlas=").Append(atlas != null ? ((UnityEngine.Object)atlas).name : "<none>");
            }
            else
            {
                object texture = type.GetProperty("mainTexture").GetValue(component, null);
                report.Append(" | texture=").Append(texture != null ? ((UnityEngine.Object)texture).name : "<none>");
            }
            report.Append(" | size=").Append(width).Append('x').Append(height);
            report.Append(" | depth=").Append(type.GetProperty("depth").GetValue(component, null));
            report.AppendLine();
        }
        File.WriteAllText(GetClientPath("main-ui-visible-widgets.txt"), report.ToString());
    }

    private static void WriteTutorialLayoutReport()
    {
        string[] names =
        {
            "Next Button Panel",
            "Next Button",
            "Left Button Anchor",
            "Tutorial Text Position",
            "Go To Battle"
        };
        Transform[] transforms = Resources.FindObjectsOfTypeAll<Transform>();
        Array.Sort(transforms, delegate(Transform left, Transform right)
        {
            if (ReferenceEquals(left, right)) return 0;
            if (ReferenceEquals(left, null)) return 1;
            if (ReferenceEquals(right, null)) return -1;
            return string.CompareOrdinal(GetHierarchyPath(left), GetHierarchyPath(right));
        });

        StringBuilder report = new StringBuilder();
        foreach (Transform current in transforms)
        {
            if (current == null || !current.gameObject.scene.IsValid() || Array.IndexOf(names, current.name) < 0)
            {
                continue;
            }

            report.AppendLine(GetHierarchyPath(current));
            report.Append("  active=").Append(current.gameObject.activeInHierarchy);
            report.Append(" localPosition=").Append(current.localPosition);
            report.Append(" position=").Append(current.position);
            report.Append(" localScale=").Append(current.localScale);
            report.Append(" lossyScale=").Append(current.lossyScale);
            report.AppendLine();

            foreach (Component component in current.GetComponents<Component>())
            {
                if (component == null)
                {
                    continue;
                }
                Type type = component.GetType();
                report.Append("  ").Append(type.FullName);
                AppendProperty(report, component, type, "width");
                AppendProperty(report, component, type, "height");
                AppendProperty(report, component, type, "pivot");
                AppendProperty(report, component, type, "depth");
                AppendProperty(report, component, type, "text");
                AppendProperty(report, component, type, "spriteName");
                AppendProperty(report, component, type, "worldCorners");
                report.AppendLine();
            }
        }
        File.WriteAllText(GetClientPath("main-ui-tutorial-layout.txt"), report.ToString());
    }

    private static void AppendProperty(StringBuilder report, Component component, Type type, string propertyName)
    {
        System.Reflection.PropertyInfo property = type.GetProperty(propertyName);
        if (property == null || property.GetIndexParameters().Length != 0)
        {
            return;
        }
        try
        {
            object value = property.GetValue(component, null);
            Array values = value as Array;
            report.Append(' ').Append(propertyName).Append('=');
            if (values == null)
            {
                report.Append(value ?? "<null>");
                return;
            }
            report.Append('[');
            for (int index = 0; index < values.Length; index++)
            {
                if (index > 0) report.Append(',');
                report.Append(values.GetValue(index));
            }
            report.Append(']');
        }
        catch (Exception exception)
        {
            report.Append(' ').Append(propertyName).Append("=<").Append(exception.GetType().Name).Append('>');
        }
    }

    private static void TryWriteReport(Action action, string description)
    {
        try
        {
            action();
        }
        catch (Exception exception)
        {
            Debug.LogError("Hybrid Play Mode smoke " + description + " failed: " + exception);
        }
    }

    private static string GetHierarchyPath(Transform current)
    {
        string path = current.name;
        while (current.parent != null)
        {
            current = current.parent;
            path = current.name + "/" + path;
        }
        return path;
    }

    private static string GetClientPath(string fileName)
    {
        return Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", fileName));
    }
}
