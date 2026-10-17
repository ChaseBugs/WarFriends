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

/// <summary>Checks discrete crawl poses on fresh samplers with source-observed overrides.</summary>
public static class UnityCoopObstacleFixedStepReplayAudit
{
    /// <summary>Writes independent pose bases and reconstruction measurements without enabling transport.</summary>
    public static void Run()
    {
        try
        {
            string reference = Environment.GetEnvironmentVariable("WAR_OBSTACLE_MATRIX_REFERENCE");
            string output = Environment.GetEnvironmentVariable("WAR_OBSTACLE_MATRIX_OUTPUT");
            if (string.IsNullOrEmpty(reference) || string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("Set the obstacle matrix reference and output paths.");
            }
            JObject capture;
            using (var reader = new StreamReader(new GZipStream(File.OpenRead(reference), CompressionMode.Decompress)))
            {
                capture = JObject.Parse(reader.ReadToEnd());
            }
            WriteReport(capture, reference, output);
            Debug.Log("PASS: fixed-step independent pose reconstruction measurements written.");
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
        if ((string)capture["prefabSha256"] != Hash("Assets/GameObject/enemy.prefab"))
        {
            throw new InvalidOperationException("The original source prefab is required.");
        }
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/enemy.prefab");
        AnimationState crawl = prefab.GetComponentInChildren<Animation>(true)["stand_up_crawl"];
        float ticksPerCrawl = (int)capture["captureRate"] * crawl.length;
        var cases = new List<object>();
        foreach (JObject source in capture["samples"])
        {
            JObject basis = CreateBasis(source);
            var scenario = new JObject
            {
                ["returnFraction"] = (int)source["priorReturnTicks"] / ticksPerCrawl,
                ["rig"] = source["rig"].DeepClone(),
                ["manualRig"] = basis
            };
            object reconstruction = Invoke(typeof(UnityCoopObstaclePoseOverrideAudit), "MeasureCase", scenario,
                "prior-return-ticks/" + source["priorReturnTicks"] + "/sample/" + source["observationTick"]);
            cases.Add(new
            {
                priorReturnTicks = (int)source["priorReturnTicks"],
                observationTick = (int)source["observationTick"], basis, reconstruction
            });
        }
        File.WriteAllText(output, JsonConvert.SerializeObject(new
        {
            unity = Application.unityVersion,
            referenceSha256 = Hash(reference),
            auditSha256 = Hash("Assets/Editor/UnityCoopObstacleFixedStepReplayAudit.cs"),
            freshAuditSha256 = Hash("Assets/Editor/UnityCoopObstacleFreshReplayAudit.cs"),
            overrideAuditSha256 = Hash("Assets/Editor/UnityCoopObstaclePoseOverrideAudit.cs"),
            samplerSha256 = Hash("Assets/Scripts/Assembly-CSharp/SelfHostedInfantryAnimationSampler.cs"),
            cases
        }, Formatting.Indented));
    }

    private static JObject CreateBasis(JObject source)
    {
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/enemy.prefab");
        Animation definition = prefab.GetComponentInChildren<Animation>(true);
        var root = new GameObject("InactiveFixedStepBasis");
        root.SetActive(false);
        try
        {
            var copies = new Dictionary<Transform, Transform>();
            SelfHostedVisualHierarchy.CopyRoot(prefab.transform, root.transform, copies);
            Invoke(typeof(UnityCoopObstacleFreshReplayAudit), "AttachWeapon", prefab, copies);
            var sampler = new SelfHostedInfantryAnimationSampler(copies[definition.transform].gameObject, definition);
            Invoke(typeof(UnityCoopObstaclePoseOverrideAudit), "Sample", sampler, source);
            Animation animation = copies[definition.transform].GetComponent<Animation>();
            // Match the source artifact's JSON float representation before selecting changed channels.
            string observed = JsonConvert.SerializeObject(UnityCoopRigFrameCapture.Capture(root.transform, animation));
            return JObject.Parse(observed);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(root);
        }
    }

    private static object Invoke(Type owner, string name, params object[] arguments)
    {
        MethodInfo method = owner.GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static);
        if (method == null)
        {
            throw new InvalidOperationException("A pinned verification helper is absent: " + name);
        }
        return method.Invoke(null, arguments);
    }

    private static string Hash(string path)
    {
        using (SHA256 hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }
}
