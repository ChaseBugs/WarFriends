using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

/// <summary>Samples each captured obstacle frame on a newly copied prefab hierarchy with no prior animation.</summary>
public static class UnityCoopObstacleFreshReplayAudit
{
    /// <summary>Writes independent replay errors without changing the captured source or relaxing tolerances.</summary>
    public static void Run()
    {
        try
        {
            string reference = Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_RIG_REFERENCE");
            string output = Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_FRESH_OUTPUT");
            if (string.IsNullOrEmpty(reference) || string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("Set the obstacle rig reference and fresh replay output paths.");
            }
            JObject capture;
            using (var reader = new StreamReader(new GZipStream(File.OpenRead(reference), CompressionMode.Decompress)))
            {
                capture = JObject.Parse(reader.ReadToEnd());
            }
            var frames = new List<object>();
            foreach (JObject frame in capture["samples"])
            {
                frames.Add(CompareFreshFrame(frame));
            }
            File.WriteAllText(output, JsonConvert.SerializeObject(new
            {
                unity = Application.unityVersion,
                referenceSha256 = Hash(reference),
                prefabSha256 = Hash("Assets/GameObject/enemy.prefab"),
                samplerSha256 = Hash("Assets/Scripts/Assembly-CSharp/SelfHostedInfantryAnimationSampler.cs"),
                auditSha256 = Hash("Assets/Editor/UnityCoopObstacleFreshReplayAudit.cs"),
                initialization = "source-prefab; independent actor per frame; no preparation or prior sample",
                frames
            }, Formatting.Indented));
            Debug.Log("PASS: fresh obstacle replay observations written: " + frames.Count);
            EditorApplication.Exit(0);
        }
        catch (Exception error)
        {
            Debug.LogException(error);
            EditorApplication.Exit(1);
        }
    }

    private static object CompareFreshFrame(JObject frame)
    {
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/enemy.prefab");
        Animation source = prefab.GetComponentInChildren<Animation>(true);
        var root = new GameObject("InactiveFreshObstacleReplay");
        root.SetActive(false);
        try
        {
            var copies = new Dictionary<Transform, Transform>();
            SelfHostedVisualHierarchy.CopyRoot(prefab.transform, root.transform, copies);
            AttachWeapon(prefab, copies);
            var sampler = new SelfHostedInfantryAnimationSampler(copies[source.transform].gameObject, source);
            var states = new List<SelfHostedInfantryAnimationState>();
            foreach (JObject state in frame["rig"]["states"])
            {
                states.Add(new SelfHostedInfantryAnimationState((string)state["clipName"], (float)state["time"],
                    (float)state["weight"], (WrapMode)Enum.Parse(typeof(WrapMode), (string)state["wrapMode"])));
            }
            sampler.Sample(states);
            return Measure(frame, root.transform);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(root);
        }
    }

    private static void AttachWeapon(GameObject prefab, Dictionary<Transform, Transform> copies)
    {
        SoldierParts parts = prefab.GetComponentInChildren<SoldierParts>(true);
        GameObject weapon = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/AssaultRifleEnemy.prefab");
        var root = new GameObject(weapon.name);
        root.transform.SetParent(copies[parts.gunSnapPointNotScaled], false);
        root.transform.localRotation = weapon.transform.localRotation;
        SelfHostedVisualHierarchy.CopyRoot(weapon.transform, root.transform, new Dictionary<Transform, Transform>());
        root.transform.localScale = Vector3.one;
    }

    private static object Measure(JObject frame, Transform root)
    {
        float maximumPositionError = 0f;
        float maximumRotationError = 0f;
        float maximumScaleError = 0f;
        foreach (JObject expected in frame["rig"]["transforms"])
        {
            string path = (string)expected["path"];
            Transform actual = Resolve(root, path);
            if (path != "root" && actual.name != (string)expected["name"])
            {
                throw new InvalidOperationException("The fresh replay hierarchy identity differs at " + path);
            }
            Vector3 position = Vector(expected["position"]);
            Quaternion rotation = Rotation(expected["rotation"]);
            if (path == "root")
            {
                // Root placement is host-owned; it is not an animated bone or an inherited preparation pose.
                actual.localPosition = position;
                actual.localRotation = rotation;
            }
            maximumPositionError = Mathf.Max(maximumPositionError, Vector3.Distance(actual.localPosition, position));
            maximumRotationError = Mathf.Max(maximumRotationError,
                1f - Mathf.Abs(Quaternion.Dot(actual.localRotation.normalized, rotation.normalized)));
            maximumScaleError = Mathf.Max(maximumScaleError, ScaleError(Vector(expected["scale"]), actual.localScale));
        }
        int transforms = root.GetComponentsInChildren<Transform>(true).Length;
        if (transforms != ((JArray)frame["rig"]["transforms"]).Count)
        {
            throw new InvalidOperationException("The fresh replay hierarchy is incomplete.");
        }
        return new
        {
            tick = (int)frame["tick"], transforms, maximumPositionError, maximumRotationError, maximumScaleError
        };
    }

    private static Transform Resolve(Transform root, string path)
    {
        string[] segments = path.Split('/');
        Transform current = root;
        for (int index = 1; index < segments.Length; index++)
        {
            current = current.GetChild(int.Parse(segments[index]));
        }
        return current;
    }

    private static Vector3 Vector(JToken value)
    {
        return new Vector3((float)value[0], (float)value[1], (float)value[2]);
    }

    private static Quaternion Rotation(JToken value)
    {
        return new Quaternion((float)value[0], (float)value[1], (float)value[2], (float)value[3]);
    }

    private static float ScaleError(Vector3 expected, Vector3 actual)
    {
        const float minimumScale = 0.000000000001f;
        float error = 0f;
        for (int axis = 0; axis < 3; axis++)
        {
            error = Mathf.Max(error, Mathf.Abs(expected[axis] - actual[axis]) /
                Mathf.Max(Mathf.Abs(expected[axis]), minimumScale));
        }
        return error;
    }
    private static string Hash(string path)
    {
        using (SHA256 hash = SHA256.Create())
        {
            return BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }

}
