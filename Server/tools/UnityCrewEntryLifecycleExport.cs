using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Records automatic source tween updates in an empty disposable Play Mode scene.</summary>
[InitializeOnLoad]
public static class UnityCrewEntryLifecycleExport
{
    private const string ActiveKey = "WarFriends.CrewEntryLifecycle";
    private static readonly List<CrewEntryLifecycleProbe> Probes = new List<CrewEntryLifecycleProbe>();
    private static readonly List<object> First = new List<object>();
    private static int _cycle;

    static UnityCrewEntryLifecycleExport()
    {
        if (SessionState.GetBool(ActiveKey, false))
        {
            EditorApplication.update += Observe;
        }
    }

    /// <summary>Starts the isolated automatic tween observation without loading gameplay scenes.</summary>
    public static void Run()
    {
        string output = Environment.GetEnvironmentVariable("WAR_CREW_ENTRY_LIFECYCLE_OUTPUT");
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
            if (Probes.Count == 0)
            {
                Create();
                return;
            }
            if (Probes.Any(probe => probe.enabled))
            {
                return;
            }
            if (_cycle == 0)
            {
                foreach (CrewEntryLifecycleProbe probe in Probes)
                {
                    First.Add(probe.Capture());
                    probe.BeginCycle(Quaternion.Euler(0, 45, 0));
                }
                _cycle = 1;
                return;
            }
            Write();
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

    private static void Create()
    {
        Time.captureFramerate = 30;
        for (int index = 0; index < 6; index++)
        {
            var parent = new GameObject("CrewEntryParent");
            parent.transform.rotation = Quaternion.Euler((index % 3) * 5, (index % 3) * 37, 0);
            var soldier = new GameObject("CrewEntryTweenOnly");
            soldier.transform.SetParent(parent.transform, false);
            soldier.transform.rotation = Quaternion.identity;
            CrewEntryLifecycleProbe probe = soldier.AddComponent<CrewEntryLifecycleProbe>();
            probe.ignoreTimeScale = index < 3;
            probe.BeginCycle(Quaternion.Euler(0, new[] { 20f, 90f, -120f }[index % 3], 0));
            Probes.Add(probe);
        }
    }

    private static void Write()
    {
        object[] scenarios = Probes.Select((probe, index) => new
        {
            parent = CrewEntryLifecycleProbe.Values(probe.transform.parent.rotation),
            first = First[index], reused = probe.Capture()
        }).ToArray();
        string text = JsonConvert.SerializeObject(new
        {
            version = 1, client = "1.4.0", unity = Application.unityVersion,
            fixture = "Automatic Unity Start/Update on source TweenRotation subclass; no actor or pool lifecycle.",
            tweenSha256 = Hash("TweenRotation.cs"), updateSha256 = Hash("UITweener.cs"),
            clockSha256 = Hash("IgnoreTimeScale.cs"),
            scenarios
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(Environment.GetEnvironmentVariable("WAR_CREW_ENTRY_LIFECYCLE_OUTPUT"), text);
        Debug.Log("PASS: automatic crew entry lifecycle scenarios=" + scenarios.Length);
    }

    private static string Hash(string filename)
    {
        using (var hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(
                "Assets/Plugins/Assembly-CSharp-firstpass/" + filename))).Replace("-", "").ToLowerInvariant();
        }
    }
}
