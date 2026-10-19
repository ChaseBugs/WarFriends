using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Runs the automatic clock recorder only in a disposable project with an explicit output.</summary>
[InitializeOnLoad]
public static class UnityHelicopterClockExport
{
    private const string Active = "WarFriends.AutomaticRopeClock";
    private const double MaximumCaptureSeconds = 30;
    private static bool _hasStarted;
    private static double _startedAt;

    static UnityHelicopterClockExport()
    {
        if (SessionState.GetBool(Active, false))
        {
            EditorApplication.update += Observe;
        }
        if (SessionState.GetBool(Active + ".Finished", false))
        {
            EditorApplication.update += ExitWhenStopped;
        }
    }

    /// <summary>Starts the actual Unity automatic physics/render loop capture.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/") ||
            string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WAR_ROPE_CLOCK_OUTPUT")))
        {
            throw new InvalidOperationException("Use a disposable project and an explicit clock output path.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        SessionState.SetBool(Active, true);
        EditorApplication.isPlaying = true;
    }

    private static void Observe()
    {
        if (!EditorApplication.isPlaying)
        {
            return;
        }
        if (_hasStarted)
        {
            if (EditorApplication.timeSinceStartup - _startedAt > MaximumCaptureSeconds)
            {
                Debug.LogError("Automatic clock recorder did not complete its thirty render callbacks.");
                Stop(1);
            }
            return;
        }
        _hasStarted = true;
        _startedAt = EditorApplication.timeSinceStartup;
        UnityHelicopterClockRecorder.Completed = Finish;
        if (new GameObject("AutomaticRopeClockRecorder").AddComponent<UnityHelicopterClockRecorder>() == null)
        {
            Debug.LogError("The clock recorder must be installed outside the Editor folder.");
            Stop(1);
        }
    }

    /// <summary>Stops Play Mode after the recorder completes its final update.</summary>
    public static void Finish()
    {
        Stop(0);
    }

    private static void Stop(int exitCode)
    {
        SessionState.SetBool(Active, false);
        SessionState.SetBool(Active + ".Finished", true);
        SessionState.SetInt(Active + ".ExitCode", exitCode);
        EditorApplication.update -= Observe;
        EditorApplication.update += ExitWhenStopped;
        EditorApplication.isPlaying = false;
    }

    private static void ExitWhenStopped()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
            return;
        }
        SessionState.SetBool(Active + ".Finished", false);
        EditorApplication.Exit(SessionState.GetInt(Active + ".ExitCode", 1));
    }
}
