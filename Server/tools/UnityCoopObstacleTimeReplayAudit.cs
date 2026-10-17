using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

/// <summary>Diagnoses time representation without modifying source captures or production sampling.</summary>
public static class UnityCoopObstacleTimeReplayAudit
{
    private static readonly string[] Modes = { "recorded-time", "normalized-product", "ulp-down", "ulp-up" };

    /// <summary>Runs independent source-prefab replay with declared time conversion controls.</summary>
    public static void Run()
    {
        try
        {
            string reference = Environment.GetEnvironmentVariable("WAR_OBSTACLE_TIME_REFERENCE");
            string output = Environment.GetEnvironmentVariable("WAR_OBSTACLE_TIME_OUTPUT");
            if (string.IsNullOrEmpty(reference) || string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("Set the obstacle time reference and output paths.");
            }
            JObject capture;
            using (var reader = new StreamReader(new GZipStream(File.OpenRead(reference), CompressionMode.Decompress)))
            {
                capture = JObject.Parse(reader.ReadToEnd());
            }
            WriteReport(capture, reference, output);
            Debug.Log("PASS: obstacle time representation observations written.");
            EditorApplication.Exit(0);
        }
        catch (Exception error)
        {
            Debug.LogException(error);
            EditorApplication.Exit(1);
        }
    }

    private static void WriteReport(JObject capture, string reference, string output)
    {
        MethodInfo compare = typeof(UnityCoopObstacleFreshReplayAudit).GetMethod("CompareFreshFrame",
            BindingFlags.NonPublic | BindingFlags.Static);
        if (compare == null)
        {
            throw new InvalidOperationException("The independently verified fresh replay helper is absent.");
        }
        var results = new List<object>();
        foreach (string mode in Modes)
        {
            var frames = new List<object>();
            foreach (JObject frame in capture["samples"])
            {
                JObject input = ConvertTimes(frame, mode);
                frames.Add(compare.Invoke(null, new object[] { input }));
            }
            results.Add(new { mode, frames });
        }
        File.WriteAllText(output, JsonConvert.SerializeObject(new
        {
            unity = Application.unityVersion,
            referenceSha256 = Hash(reference),
            auditSha256 = Hash("Assets/Editor/UnityCoopObstacleTimeReplayAudit.cs"),
            freshAuditSha256 = Hash("Assets/Editor/UnityCoopObstacleFreshReplayAudit.cs"),
            results
        }, Formatting.Indented));
    }

    private static JObject ConvertTimes(JObject source, string mode)
    {
        JObject frame = (JObject)source.DeepClone();
        foreach (JObject state in frame["rig"]["states"])
        {
            float seconds = (float)state["time"];
            if (mode == "normalized-product")
            {
                seconds = (float)state["normalizedTime"] * (float)state["clipLength"];
            }
            else if (seconds > 0f && (mode == "ulp-down" || mode == "ulp-up"))
            {
                int bits = BitConverter.ToInt32(BitConverter.GetBytes(seconds), 0);
                int direction = mode == "ulp-down" ? -1 : 1;
                seconds = BitConverter.ToSingle(BitConverter.GetBytes(bits + direction), 0);
            }
            state["time"] = seconds;
        }
        return frame;
    }

    private static string Hash(string path)
    {
        using (SHA256 hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }
}
