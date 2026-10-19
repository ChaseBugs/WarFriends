using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Observes which local bones and clip states the original Reset actually restores.</summary>
public static class UnitySoldierPoseResetExport
{
    public static void Run()
    {
        GameObject enemy = null;
        try
        {
            string output = Environment.GetEnvironmentVariable("WAR_SOLDIER_POSE_RESET_OUTPUT");
            if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/") || string.IsNullOrEmpty(output))
            {
                throw new InvalidOperationException("A disposable project and explicit output are required.");
            }
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            enemy = UnityEngine.Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/GameObject/enemy.prefab"));
            enemy.SetActive(false);
            SoldierAnimationController controller = enemy.GetComponent<EnemyController>().mSoldierAnimationController;
            typeof(SoldierAnimationController).GetMethod("Awake",
                BindingFlags.Instance | BindingFlags.NonPublic).Invoke(controller, null);
            Write(output, controller);
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

    private static void Write(string output, SoldierAnimationController controller)
    {
        Transform[] nodes = Chain(controller.leftPalm, controller.transform);
        object[] rest = Pose(nodes);
        Animation animation = controller.GetComponent<Animation>();
        animation.Stop();
        AnimationState slide = animation["helicopter_jump_pose"];
        slide.enabled = true;
        slide.weight = 1;
        slide.time = slide.length;
        animation.Sample();
        object[] sampled = Pose(nodes);
        // Retained scale and a non-root stale transform distinguish a partial reset from a full bind-pose reset.
        controller.rootBone.localScale *= 1.1f;
        nodes.First(node => node != controller.rootBone && node != controller.rootBoneInner).localPosition +=
            new Vector3(0.02f, 0.03f, 0.04f);
        object[] before = Pose(nodes);
        object[] statesBefore = States(animation);
        controller.Reset();
        string text = JsonConvert.SerializeObject(new
        {
            version = 1, client = "1.4.0", unity = Application.unityVersion,
            sourceSha256 = Hash("Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs"),
            prefabSha256 = Hash("Assets/GameObject/enemy.prefab"),
            fixture = "Original Reset on an inactive sampled rig with controlled stale position/scale; " +
                "no actor lifecycle.",
            rootIndex = Array.IndexOf(nodes, controller.rootBone),
            innerIndex = Array.IndexOf(nodes, controller.rootBoneInner),
            paths = nodes.Select(node => AnimationUtility.CalculateTransformPath(node, controller.transform)).ToArray(),
            rest, sampled, before, after = Pose(nodes), statesBefore, statesAfter = States(animation)
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(output, text);
        Debug.Log("PASS: original soldier pose reset nodes=" + nodes.Length);
    }

    private static Transform[] Chain(Transform palm, Transform root)
    {
        var nodes = new List<Transform>();
        for (Transform node = palm; node != root; node = node.parent)
        {
            if (node == null)
            {
                throw new InvalidOperationException("Palm is outside the recovered rig.");
            }
            nodes.Add(node);
        }
        nodes.Reverse();
        return nodes.ToArray();
    }

    private static object[] Pose(Transform[] nodes)
    {
        return nodes.Select(node => (object)new
        {
            position = Values(node.localPosition), rotation = Values(node.localRotation),
            scale = Values(node.localScale)
        }).ToArray();
    }

    private static object[] States(Animation animation)
    {
        return animation.Cast<AnimationState>().Where(state => state.name == "helicopter_jump_pose")
            .Select(state => (object)new { state.name, state.time, state.weight, state.enabled }).ToArray();
    }

    private static float[] Values(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }

    private static float[] Values(Quaternion value)
    {
        return new[] { value.x, value.y, value.z, value.w };
    }

    private static string Hash(string path)
    {
        using (var sha = SHA256.Create())
        {
            return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path))).Replace("-", "").ToLowerInvariant();
        }
    }
}
