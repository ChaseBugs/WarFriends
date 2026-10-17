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

/// <summary>Tests source-observed position/scale overrides on independent production sampler hierarchies.</summary>
public static class UnityCoopObstaclePoseOverrideAudit
{
    private const int PositionAndScaleFloatCount = 6;

    /// <summary>Measures compact observed-pose preservation without enabling a wire format or gameplay route.</summary>
    public static void Run()
    {
        try
        {
            string reference = Environment.GetEnvironmentVariable("WAR_OBSTACLE_OVERRIDE_REFERENCE");
            string output = Environment.GetEnvironmentVariable("WAR_OBSTACLE_OVERRIDE_OUTPUT");
            if (string.IsNullOrEmpty(reference) || string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("Set the obstacle override reference and output paths.");
            }
            JObject controls;
            using (var reader = new StreamReader(new GZipStream(File.OpenRead(reference), CompressionMode.Decompress)))
            {
                controls = JObject.Parse(reader.ReadToEnd());
            }
            WriteReport(controls, reference, output);
            Debug.Log("PASS: independent observed-pose override measurements written.");
            EditorApplication.Exit(0);
        }
        catch (Exception error)
        {
            Debug.LogException(error);
            EditorApplication.Exit(1);
        }
    }

    private static void WriteReport(JObject controls, string reference, string output)
    {
        if ((string)controls["clean"]["prefabSha256"] != Hash("Assets/GameObject/enemy.prefab"))
        {
            throw new InvalidOperationException("The original source prefab is required.");
        }
        var cases = new List<object>();
        foreach (string control in new[] { "manualAt1", "manualAt2" })
        {
            JArray samples = (JArray)controls[control]["samples"];
            foreach (JObject scenario in samples[samples.Count - 1]["scenarios"])
            {
                cases.Add(MeasureCase(scenario, control));
            }
        }
        File.WriteAllText(output, JsonConvert.SerializeObject(new
        {
            unity = Application.unityVersion,
            referenceSha256 = Hash(reference),
            auditSha256 = Hash("Assets/Editor/UnityCoopObstaclePoseOverrideAudit.cs"),
            samplerSha256 = Hash("Assets/Scripts/Assembly-CSharp/SelfHostedInfantryAnimationSampler.cs"),
            cases
        }, Formatting.Indented));
    }

    private static object MeasureCase(JObject scenario, string control)
    {
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/enemy.prefab");
        Animation definition = prefab.GetComponentInChildren<Animation>(true);
        var root = new GameObject("InactiveObservedPoseOverride");
        root.SetActive(false);
        try
        {
            var copies = new Dictionary<Transform, Transform>();
            SelfHostedVisualHierarchy.CopyRoot(prefab.transform, root.transform, copies);
            InvokeHelper("AttachWeapon", prefab, copies);
            var sampler = new SelfHostedInfantryAnimationSampler(copies[definition.transform].gameObject, definition);
            Sample(sampler, scenario);
            var frame = new JObject { ["tick"] = 0, ["rig"] = scenario["rig"].DeepClone() };
            object before = InvokeHelper("Measure", frame, root.transform);
            List<JObject> overrides = SelectOverrides(scenario);
            Apply(root.transform, overrides);
            object after = InvokeHelper("Measure", frame, root.transform);
            Apply(root.transform, overrides);
            object replay = InvokeHelper("Measure", frame, root.transform);
            return new
            {
                control, returnFraction = (float)scenario["returnFraction"], overrideCount = overrides.Count,
                floatPayloadBytes = overrides.Count * PositionAndScaleFloatCount * sizeof(float), before, after, replay
            };
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(root);
        }
    }

    private static void Sample(SelfHostedInfantryAnimationSampler sampler, JObject scenario)
    {
        var states = new List<SelfHostedInfantryAnimationState>();
        foreach (JObject state in scenario["rig"]["states"])
        {
            states.Add(new SelfHostedInfantryAnimationState((string)state["clipName"], (float)state["time"],
                (float)state["weight"], (WrapMode)Enum.Parse(typeof(WrapMode), (string)state["wrapMode"])));
        }
        sampler.Sample(states);
    }

    private static List<JObject> SelectOverrides(JObject scenario)
    {
        JArray expected = (JArray)scenario["rig"]["transforms"];
        JArray manuallySampled = (JArray)scenario["manualRig"]["transforms"];
        var overrides = new List<JObject>();
        for (int index = 0; index < expected.Count; index++)
        {
            JObject original = (JObject)expected[index];
            JToken manual = manuallySampled[index];
            if ((string)original["path"] != "root" &&
                (!JToken.DeepEquals(original["position"], manual["position"]) ||
                 !JToken.DeepEquals(original["scale"], manual["scale"])))
            {
                overrides.Add(original);
            }
        }
        return overrides;
    }

    private static void Apply(Transform root, List<JObject> overrides)
    {
        foreach (JObject observed in overrides)
        {
            Transform target = (Transform)InvokeHelper("Resolve", root, (string)observed["path"]);
            if (target.name != (string)observed["name"])
            {
                throw new InvalidOperationException("An observed override resolved to another source transform.");
            }
            target.localPosition = Vector(observed["position"]);
            target.localScale = Vector(observed["scale"]);
        }
    }

    private static Vector3 Vector(JToken value)
    {
        return new Vector3((float)value[0], (float)value[1], (float)value[2]);
    }

    private static object InvokeHelper(string name, params object[] arguments)
    {
        MethodInfo method = typeof(UnityCoopObstacleFreshReplayAudit).GetMethod(name,
            BindingFlags.Static | BindingFlags.NonPublic);
        if (method == null)
        {
            throw new InvalidOperationException("The verified fresh replay helper is absent: " + name);
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
