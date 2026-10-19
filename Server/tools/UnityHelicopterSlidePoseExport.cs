using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

using UnityEditor;
using UnityEngine;

using Newtonsoft.Json;

/// <summary>Exports the recovered slide clip's palm binding and constant-curve evidence in Edit Mode.</summary>
public static class UnityHelicopterSlidePoseExport
{
    private const string PrefabPath = "Assets/GameObject/enemy.prefab";
    private const string ClipName = "helicopter_jump_pose";

    /// <summary>Exports the source palm and a direct recovered-method alignment from a disposable project.</summary>
    public static void Run()
    {
        GameObject enemy = null;
        try
        {
            if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
            {
                throw new InvalidOperationException("Use a disposable validation project.");
            }
            enemy = UnityEngine.Object.Instantiate(AssetDatabase.LoadAssetAtPath<GameObject>(PrefabPath));
            var animation = enemy.GetComponentInChildren<Animation>(true);
            var palm = enemy.GetComponent<EnemyController>().mSoldierAnimationController.leftPalm;
            if (animation == null || palm == null || animation[ClipName] == null)
            {
                throw new InvalidOperationException("The recovered slide animation or palm binding is missing.");
            }
            enemy.transform.position = Vector3.zero;
            enemy.transform.rotation = Quaternion.identity;
            AnimationState state = animation[ClipName];
            Vector3 start = Sample(enemy.transform, animation, palm, 0);
            Vector3 end = Sample(enemy.transform, animation, palm, state.length);
            bool constant = WriteReference(enemy, state, start, end);
            Debug.Log("PASS: recovered slide palm captured; constantCurves=" + constant);
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

    private static Vector3 Sample(Transform root, Animation animation, Transform palm, float seconds)
    {
        animation.Stop();
        AnimationState reset = animation["T_pose"];
        reset.enabled = true;
        reset.weight = 1;
        reset.normalizedTime = 1;
        animation.Sample();
        reset.enabled = false;
        AnimationState slide = animation[ClipName];
        slide.enabled = true;
        slide.weight = 1;
        slide.time = seconds;
        animation.Sample();
        slide.enabled = false;
        return root.InverseTransformPoint(palm.position);
    }

    private static bool IsConstant(AnimationCurve curve)
    {
        return curve != null && curve.keys.Length > 0 && curve.keys.All(key =>
            key.value == curve.keys[0].value && key.inTangent == 0 && key.outTangent == 0);
    }

    private static bool WriteReference(GameObject enemy, AnimationState state, Vector3 start, Vector3 end)
    {
        Transform palm = enemy.GetComponent<EnemyController>().mSoldierAnimationController.leftPalm;
        string clipPath = AssetDatabase.GetAssetPath(state.clip);
        EditorCurveBinding[] bindings = AnimationUtility.GetCurveBindings(state.clip);
        bool constant = bindings.Length > 0 && bindings.All(binding => IsConstant(
            AnimationUtility.GetEditorCurve(state.clip, binding)));
        string guid;
        long fileId;
        if (!AssetDatabase.TryGetGUIDAndLocalFileIdentifier(state.clip, out guid, out fileId))
        {
            throw new InvalidOperationException("The slide clip lacks its source identity.");
        }
        string reference = JsonConvert.SerializeObject(new
        {
            version = 1, client = "1.4.0", unity = Application.unityVersion, source = PrefabPath,
            sourceInputSha256 = Environment.GetEnvironmentVariable("WAR_SLIDE_PREFAB_INPUT_SHA"),
            sourceLoadedSha256 = Hash(PrefabPath), rootScale = Vector(enemy.transform.localScale),
            palmPath = AnimationUtility.CalculateTransformPath(palm, enemy.transform),
            clip = new { name = ClipName, source = clipPath, guid, fileId, sha256 = Hash(clipPath),
                length = state.length, wrap = state.wrapMode.ToString(), curveCount = bindings.Length,
                constantCurves = constant },
            startPalm = Vector(start), endPalm = Vector(end), alignedReference = CaptureAlignment(enemy)
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(Environment.GetEnvironmentVariable("WAR_SLIDE_POSE_OUTPUT"), reference);
        return constant;
    }

    private static object CaptureAlignment(GameObject enemy)
    {
        var joints = new List<GameObject>();
        try
        {
            enemy.transform.position = new Vector3(3, 10, 5);
            enemy.transform.rotation = Quaternion.Euler(0, 90, 0);
            Vector3 basePosition = new Vector3(3, 5, 5);
            var positions = new[] { new Vector3(2, 12, 3), new Vector3(2, 0, 3) };
            foreach (Vector3 position in positions)
            {
                var joint = new GameObject("SlidePalmControlJoint");
                joint.transform.position = position;
                joints.Add(joint);
            }
            const BindingFlags Members = BindingFlags.Instance | BindingFlags.NonPublic;
            EnemyController controller = enemy.GetComponent<EnemyController>();
            typeof(EnemyController).GetField("mJoints", Members).SetValue(controller, joints);
            Vector3 result = (Vector3)typeof(EnemyController).GetMethod("GetRopePosition", Members)
                .Invoke(controller, new object[] { basePosition });
            Quaternion rotation = enemy.transform.rotation;
            return new { rootPosition = Vector(enemy.transform.position),
                rootRotation = new[] { rotation.x, rotation.y, rotation.z, rotation.w },
                joints = Array.ConvertAll(positions, Vector), expected = Vector(result) };
        }
        finally
        {
            foreach (GameObject joint in joints)
            {
                UnityEngine.Object.DestroyImmediate(joint);
            }
        }
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
}
