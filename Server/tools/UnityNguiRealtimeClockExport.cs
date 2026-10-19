using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Invokes the original clock using controlled prior timestamps and carried source residuals.</summary>
public static class UnityNguiRealtimeClockExport
{
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;
    private const string Source = "Assets/Plugins/Assembly-CSharp-firstpass/IgnoreTimeScale.cs";
    private static readonly float[] Gaps = { 0f, 0.0004f, 0.0005f, 0.0006f, 0.016f, 0.033f, 0.35f, 1f, 1.25f };

    public static void Run()
    {
        try
        {
            string output = Environment.GetEnvironmentVariable("WAR_NGUI_REALTIME_OUTPUT");
            if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/") || string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("A disposable project and explicit output are required.");
            }
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            var owner = new GameObject("InactiveClockOwner");
            owner.SetActive(false);
            IgnoreTimeScale clock = owner.AddComponent<IgnoreTimeScale>();
            List<object> rows = Capture(clock);
            UnityEngine.Object.DestroyImmediate(owner);
            string text = JsonConvert.SerializeObject(new
            {
                version = 1, client = "1.4.0", unity = Application.unityVersion, source = Source,
                sourceSha256 = Hash(Source),
                fixture = "Controlled prior timestamps; actual UpdateRealTimeDelta invocation, residual retained.", rows
            }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
            File.WriteAllText(output, text);
            Debug.Log("PASS: original NGUI realtime observations=" + rows.Count);
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            EditorApplication.Exit(1);
        }
    }

    private static List<object> Capture(IgnoreTimeScale clock)
    {
        // Fresh batch Editors can have less uptime than the long-frame case requires.
        if (Time.realtimeSinceStartup < 1.5f)
        {
            System.Threading.Thread.Sleep(1500);
        }
        MethodInfo update = typeof(IgnoreTimeScale).GetMethod("UpdateRealTimeDelta", PrivateInstance);
        var rows = new List<object>();
        for (int cycle = 0; cycle < 3; cycle++)
        {
            foreach (float gap in Gaps)
            {
                float previous = Mathf.Max(0f, Time.realtimeSinceStartup - gap);
                float beforeResidual = (float)Get(clock, "mActual");
                Set(clock, "mTimeStarted", true);
                Set(clock, "mTimeStart", previous);
                float delta = (float)update.Invoke(clock, null);
                rows.Add(new
                {
                    requestedGap = gap, previous, beforeResidual, realtime = clock.realTime,
                    delta, residual = (float)Get(clock, "mActual")
                });
            }
        }
        return rows;
    }

    private static object Get(IgnoreTimeScale clock, string field)
    {
        return typeof(IgnoreTimeScale).GetField(field, PrivateInstance).GetValue(clock);
    }

    private static void Set(IgnoreTimeScale clock, string field, object value)
    {
        typeof(IgnoreTimeScale).GetField(field, PrivateInstance).SetValue(clock, value);
    }

    private static string Hash(string path)
    {
        using (var sha = SHA256.Create())
        {
            return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }
}
