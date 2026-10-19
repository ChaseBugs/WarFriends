using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

/// <summary>Distinguishes imported binding pose from previous sampled pose under sub-unit clip weights.</summary>
public static class UnityPalmRemainderExport
{
    private const string Source = "Assets/GameObject/enemy.prefab";
    private const string Idle = "idle_1";
    private const string Slide = "helicopter_jump_pose";
    private const int SampleRate = 30;

    public static void Run()
    {
        GameObject enemy = null;
        try
        {
            string output = Environment.GetEnvironmentVariable("WAR_PALM_REMAINDER_OUTPUT");
            if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/") || string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("A disposable project and explicit output are required.");
            }
            enemy = UnityEngine.Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(Source));
            enemy.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
            Transform palm = enemy.GetComponent<EnemyController>().mSoldierAnimationController.leftPalm;
            var chain = new List<Transform>();
            for (Transform node = palm; node != null; node = node.parent)
            {
                chain.Add(node);
            }
            chain.Reverse();
            Write(output, enemy.GetComponentInChildren<Animation>(true), chain.ToArray());
            UnityEngine.Object.DestroyImmediate(enemy);
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            if (enemy != null)
            {
                UnityEngine.Object.DestroyImmediate(enemy);
            }
            EditorApplication.Exit(1);
        }
    }

    private static void Write(string output, Animation animation, Transform[] chain)
    {
        object[] bindingPose = Pose(chain);
        var references = new List<object>();
        Vector2[] weights = { Vector2.zero, new Vector2(1f / 9f, 0), new Vector2(0.25f, 0.25f),
            new Vector2(0.5f, 0), new Vector2(0.25f, 0.5f), new Vector2(0.5f, 0.25f) };
        var selections = from seed in new[] { "T_pose", Slide }
            from idleFrame in new[] { 0, 15, 29 }
            from slideFrame in new[] { 0, 1 }
            from pair in weights
            select new Selection(seed, idleFrame, slideFrame, pair);
        foreach (Selection selection in selections)
        {
            references.Add(Capture(animation, chain, selection));
        }
        string text = JsonConvert.SerializeObject(new
        {
            version = 1, client = "1.4.0", unity = Application.unityVersion, sourceSha256 = Hash(Source),
            fixture = "Imported binding pose plus two previous sampled poses; enabled layers with sub-unit weights.",
            bindingPose,
            paths = chain.Select(node => AnimationUtility.CalculateTransformPath(node, chain[0])).ToArray(),
            references
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(output, text);
        Debug.Log("PASS: sub-unit palm remainder references=" + references.Count);
    }

    private static object Capture(Animation animation, Transform[] chain, Selection selection)
    {
        animation.Stop();
        AnimationState seed = animation[selection.Seed];
        seed.enabled = true;
        seed.weight = 1;
        seed.time = seed.length;
        animation.Sample();
        seed.enabled = false;
        object[] before = Pose(chain);
        AnimationState idle = animation[Idle];
        AnimationState slide = animation[Slide];
        idle.enabled = true;
        slide.enabled = true;
        idle.time = Mathf.Min(selection.IdleFrame / (float)SampleRate, idle.length);
        slide.time = Mathf.Min(selection.SlideFrame / (float)SampleRate, slide.length);
        idle.weight = selection.Weights.x;
        slide.weight = selection.Weights.y;
        animation.Sample();
        object[] after = Pose(chain);
        Transform root = chain[0];
        Transform palm = chain[chain.Length - 1];
        Vector3 local = root.InverseTransformPoint(palm.position);
        root.SetPositionAndRotation(new Vector3(3, 7, 11), Quaternion.Euler(0, 90, 0));
        Vector3 world = palm.position;
        root.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
        idle.enabled = false;
        slide.enabled = false;
        return new
        {
            seed = selection.Seed, idleFrame = selection.IdleFrame, slideFrame = selection.SlideFrame,
            idleWeight = selection.Weights.x, slideWeight = selection.Weights.y,
            before, after, palm = Values(local), worldPalm = Values(world)
        };
    }

    private static object[] Pose(Transform[] chain)
    {
        return chain.Select(node => (object)new
        {
            position = Values(node.localPosition), scale = Values(node.localScale),
            rotation = new[] { node.localRotation.x, node.localRotation.y, node.localRotation.z, node.localRotation.w }
        }).ToArray();
    }

    private static float[] Values(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }

    private static string Hash(string path)
    {
        using (var sha = SHA256.Create())
        {
            return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }

    private sealed class Selection
    {
        internal string Seed { get; private set; }
        internal int IdleFrame { get; private set; }
        internal int SlideFrame { get; private set; }
        internal Vector2 Weights { get; private set; }

        internal Selection(string seed, int idleFrame, int slideFrame, Vector2 weights)
        {
            Seed = seed;
            IdleFrame = idleFrame;
            SlideFrame = slideFrame;
            Weights = weights;
        }
    }
}
