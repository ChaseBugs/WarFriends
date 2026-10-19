using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

using UnityEditor;
using UnityEngine;

using Newtonsoft.Json;

/// <summary>Captures local palm-chain transforms and actual Unity Animation.Sample blend results.</summary>
public static class UnityHelicopterPalmBlendExport
{
    private const string Source = "Assets/GameObject/enemy.prefab";
    private const string Idle = "idle_1";
    private const string Slide = "helicopter_jump_pose";
    private const int SampleRate = 30;
    private static readonly Vector3 WorldRootPosition = new Vector3(3, 7, 11);
    private static readonly Quaternion WorldRootRotation = Quaternion.Euler(0, 90, 0);

    /// <summary>Runs only in a disposable Edit Mode project with the recovered source assets.</summary>
    public static void Run()
    {
        GameObject enemy = null;
        try
        {
            if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
            {
                throw new InvalidOperationException("Use a disposable validation project.");
            }
            enemy = UnityEngine.Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(Source));
            enemy.transform.position = Vector3.zero;
            enemy.transform.rotation = Quaternion.identity;
            var animation = enemy.GetComponentInChildren<Animation>(true);
            Transform palm = enemy.GetComponent<EnemyController>().mSoldierAnimationController.leftPalm;
            if (animation == null || palm == null || animation[Idle] == null || animation[Slide] == null)
            {
                throw new InvalidOperationException("Recovered palm blend bindings are missing.");
            }
            WriteReference(enemy, animation, palm);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            EditorApplication.Exit(1);
            return;
        }
        finally
        {
            if (enemy != null)
            {
                UnityEngine.Object.DestroyImmediate(enemy);
            }
        }
        EditorApplication.Exit(0);
    }

    private static void WriteReference(GameObject enemy, Animation animation, Transform palm)
    {
        Transform[] chain = Chain(enemy.transform, palm);
        object[] clips = new[] { CaptureClip(animation, chain, Idle), CaptureClip(animation, chain, Slide) };
        var references = new List<object>();
        int idleLast = Mathf.CeilToInt(animation[Idle].length * SampleRate);
        int slideLast = Mathf.CeilToInt(animation[Slide].length * SampleRate);
        foreach (int idleFrame in new[] { 0, idleLast / 2, idleLast - 1 })
        {
            foreach (int slideFrame in new[] { 0, slideLast })
            {
                foreach (float weight in new[] { 0f, 0.25f, 0.5f, 0.75f, 1f })
                {
                    Blend(animation, idleFrame, slideFrame, weight);
                    Vector3 localPalm = enemy.transform.InverseTransformPoint(palm.position);
                    enemy.transform.position = WorldRootPosition;
                    enemy.transform.rotation = WorldRootRotation;
                    Vector3 worldPalm = palm.position;
                    enemy.transform.position = Vector3.zero;
                    enemy.transform.rotation = Quaternion.identity;
                    references.Add(new { idleFrame, slideFrame, weight,
                        palm = Vector(localPalm), worldPalm = Vector(worldPalm) });
                }
            }
        }
        string reference = JsonConvert.SerializeObject(new
        {
            version = 1, client = "1.4.0", unity = Application.unityVersion,
            source = Source, sourceSha256 = Hash(Source), sampleRate = SampleRate,
            resetClip = DescribeClip(animation["T_pose"]),
            nodes = chain.Select((node, index) => new { parent = index - 1,
                path = AnimationUtility.CalculateTransformPath(node, enemy.transform) }).ToArray(),
            clips, worldRootPosition = Vector(WorldRootPosition), worldRootRotation = Rotation(WorldRootRotation),
            references
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(Environment.GetEnvironmentVariable("WAR_PALM_BLEND_OUTPUT"), reference);
        Debug.Log("PASS: palm blend chain captured; nodes=" + chain.Length + ", references=" + references.Count);
    }

    private static object CaptureClip(Animation animation, Transform[] chain, string name)
    {
        AnimationState state = animation[name];
        var frames = new List<object>();
        int last = Mathf.CeilToInt(state.length * SampleRate);
        for (int frame = 0; frame <= last; frame++)
        {
            Blend(animation, name == Idle ? frame : 0, name == Slide ? frame : 0, name == Slide ? 1f : 0f);
            frames.Add(chain.Select((node, index) => new
            {
                position = Vector(index == 0 ? Vector3.zero : node.localPosition),
                rotation = Rotation(index == 0 ? Quaternion.identity : node.localRotation),
                scale = Vector(index == 0 ? Vector3.one : node.localScale)
            }).ToArray());
        }
        string path = AssetDatabase.GetAssetPath(state.clip);
        return new { name, source = path, sha256 = Hash(path), length = state.length,
            wrap = state.wrapMode.ToString(), frames };
    }

    private static object DescribeClip(AnimationState state)
    {
        string path = AssetDatabase.GetAssetPath(state.clip);
        return new { name = state.name, source = path, sha256 = Hash(path), length = state.length,
            wrap = state.wrapMode.ToString(), layer = state.layer, blendMode = state.blendMode.ToString() };
    }

    private static void Blend(Animation animation, int idleFrame, int slideFrame, float weight)
    {
        animation.Stop();
        AnimationState reset = animation["T_pose"];
        reset.enabled = true;
        reset.weight = 1;
        reset.normalizedTime = 1;
        animation.Sample();
        reset.enabled = false;
        AnimationState idle = animation[Idle];
        AnimationState slide = animation[Slide];
        idle.enabled = true;
        slide.enabled = true;
        idle.time = Mathf.Min(idleFrame / (float)SampleRate, idle.length);
        slide.time = Mathf.Min(slideFrame / (float)SampleRate, slide.length);
        idle.weight = 1f - weight;
        slide.weight = weight;
        animation.Sample();
        idle.enabled = false;
        slide.enabled = false;
    }

    private static Transform[] Chain(Transform root, Transform palm)
    {
        var chain = new List<Transform>();
        for (Transform node = palm; node != null; node = node.parent)
        {
            chain.Add(node);
            if (node == root)
            {
                chain.Reverse();
                return chain.ToArray();
            }
        }
        throw new InvalidOperationException("The original palm is outside the enemy root.");
    }

    private static string Hash(string path)
    {
        using (var sha = SHA256.Create())
        {
            return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path)))
                .Replace("-", "").ToLowerInvariant();
        }
    }

    private static float[] Vector(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }

    private static float[] Rotation(Quaternion value)
    {
        return new[] { value.x, value.y, value.z, value.w };
    }
}
