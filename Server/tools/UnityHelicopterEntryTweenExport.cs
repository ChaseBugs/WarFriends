using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Invokes original Start/Update with controlled prior realtime and actual parent-space rotations.</summary>
[InitializeOnLoad]
public static class UnityHelicopterEntryTweenExport
{
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;
    private const string ScaledKey = "WarFriends.EntryScaledCapture";

    static UnityHelicopterEntryTweenExport()
    {
        if (SessionState.GetBool(ScaledKey, false))
        {
            EditorApplication.update += ObserveScaledStart;
        }
    }

    private static void ObserveScaledStart()
    {
        if (!Application.isPlaying || Time.frameCount < 3 || Time.deltaTime <= 0)
        {
            return;
        }
        EditorApplication.update -= ObserveScaledStart;
        SessionState.SetBool(ScaledKey, false);
        Run();
    }

    public static void Run()
    {
        try
        {
            string output = Environment.GetEnvironmentVariable("WAR_HELICOPTER_ENTRY_OUTPUT");
            if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/") || string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("A disposable project and explicit output are required.");
            }
            if (!Application.isPlaying)
            {
                EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
                if (Environment.GetEnvironmentVariable("WAR_HELICOPTER_ENTRY_SCALED") == "1")
                {
                    SessionState.SetBool(ScaledKey, true);
                    EditorApplication.isPlaying = true;
                    return;
                }
            }
            if (Time.realtimeSinceStartup < 1.5f)
            {
                System.Threading.Thread.Sleep(1500);
            }
            var scenarios = new List<object>();
            for (int index = 0; index < 3; index++)
            {
                scenarios.Add(Capture(index));
            }
            string text = JsonConvert.SerializeObject(new
            {
                version = 1, client = "1.4.0", unity = Application.unityVersion,
                fixture = "Explicit original Start/Update dispatch, controlled prior clock, " +
                    "fresh and reused entry tween.",
                tweenSha256 = Hash("TweenRotation.cs"), updateSha256 = Hash("UITweener.cs"),
                clockSha256 = Hash("IgnoreTimeScale.cs"), scenarios
            }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
            File.WriteAllText(output, text);
            Debug.Log("PASS: original entry tween scenarios=" + scenarios.Count);
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            EditorApplication.Exit(1);
        }
    }

    private static object Capture(int scenario)
    {
        var parent = new GameObject("InactiveEntryParent");
        parent.SetActive(false);
        parent.transform.rotation = Quaternion.Euler(scenario * 5, scenario * 37, 0);
        var soldier = new GameObject("InactiveEntrySoldier");
        soldier.transform.SetParent(parent.transform, false);
        soldier.transform.rotation = Quaternion.identity;
        object first = CaptureCycle(soldier, Quaternion.Euler(0, new[] { 20f, 90f, -120f }[scenario], 0), 0);
        object reused = CaptureCycle(soldier, Quaternion.Euler(0, 45, 0), 1);
        object result = new { parent = Values(parent.transform.rotation), first, reused };
        UnityEngine.Object.DestroyImmediate(parent);
        return result;
    }

    private static object CaptureCycle(GameObject soldier, Quaternion target, int cycle)
    {
        TweenRotation tween = TweenRotation.Begin(soldier, 0.3f, target);
        if (Environment.GetEnvironmentVariable("WAR_HELICOPTER_ENTRY_SCALED") == "1")
        {
            tween.ignoreTimeScale = false;
        }
        Quaternion from = Quaternion.Euler(tween.from);
        Quaternion to = Quaternion.Euler(tween.to);
        var rows = new List<object>();
        int maximumUpdates = tween.ignoreTimeScale ? 20 : 2048;
        for (int index = 0; index < maximumUpdates && tween.enabled; index++)
        {
            float gap = cycle == 0 ? 0.033f : 1.25f;
            float previous = Time.realtimeSinceStartup - gap;
            typeof(IgnoreTimeScale).GetField("mTimeStarted", PrivateInstance).SetValue(tween, true);
            typeof(IgnoreTimeScale).GetField("mTimeStart", PrivateInstance).SetValue(tween, previous);
            string dispatch = cycle == 0 && index == 0 ? "Start" : "Update";
            typeof(UITweener).GetMethod(dispatch, PrivateInstance).Invoke(tween, null);
            rows.Add(new
            {
                previous, realtime = tween.realTime, delta = tween.realTimeDelta, dispatch,
                scaledDelta = Time.deltaTime, ignoreTimeScale = tween.ignoreTimeScale,
                factor = tween.tweenFactor, enabled = tween.enabled,
                localRotation = Values(soldier.transform.localRotation), rotation = Values(soldier.transform.rotation)
            });
        }
        if (tween.enabled)
        {
            throw new InvalidOperationException("Entry tween fixture failed to reach completion.");
        }
        return new { from = Values(from), target = Values(to), rows };
    }

    private static float[] Values(Quaternion value)
    {
        return new[] { value.x, value.y, value.z, value.w };
    }

    private static string Hash(string filename)
    {
        using (var sha = SHA256.Create())
        {
            byte[] bytes = File.ReadAllBytes("Assets/Plugins/Assembly-CSharp-firstpass/" + filename);
            return BitConverter.ToString(sha.ComputeHash(bytes)).Replace("-", "").ToLowerInvariant();
        }
    }
}
