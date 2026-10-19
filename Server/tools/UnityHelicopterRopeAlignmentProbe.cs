using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

/// <summary>Captures the actual recovered GetRopePosition method without entering Play Mode.</summary>
public static class UnityHelicopterRopeAlignmentProbe
{
    private static readonly List<GameObject> OwnedObjects = new List<GameObject>();

    public static void Run()
    {
        try
        {
            if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
            {
                throw new InvalidOperationException("Use a disposable validation project.");
            }
            EnemyController controller = CreateController();
            var cases = new List<object>();
            foreach (float yaw in new[] { 0f, 45f, 137f })
            {
                foreach (float height in new[] { 12f, 10f, 7f, 5f, 2f, 0f, -1f })
                {
                    cases.Add(Capture(controller, yaw, height, true));
                }
                cases.Add(Capture(controller, yaw, 7f, false));
            }
            string source = Path.Combine(Application.dataPath, "Scripts/Assembly-CSharp/EnemyController.cs");
            string digest;
            using (var sha = SHA256.Create())
            {
                digest = BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(source)))
                    .Replace("-", "").ToLowerInvariant();
            }
            string output = Environment.GetEnvironmentVariable("WAR_ROPE_ALIGNMENT_OUTPUT");
            string reference = JsonConvert.SerializeObject(new
            {
                version = 1, unity = Application.unityVersion, sourceSha256 = digest, cases
            }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
            File.WriteAllText(output, reference);
            Debug.Log("PASS: actual recovered rope alignment captured for " + cases.Count + " cases");
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            EditorApplication.Exit(1);
            return;
        }
        finally
        {
            foreach (GameObject owned in OwnedObjects)
            {
                UnityEngine.Object.DestroyImmediate(owned);
            }
        }
        EditorApplication.Exit(0);
    }

    private static object Capture(EnemyController controller, float yaw, float height, bool hasJoints)
    {
        controller.transform.position = new Vector3(3, 4, 5);
        controller.transform.rotation = Quaternion.Euler(0, yaw, 0);
        Vector3 basePosition = new Vector3(3, height - 1, 5);
        controller.mSoldierAnimationController.leftPalm.position = new Vector3(4, 5, 5.5f);
        var positions = new[] { new Vector3(1, 10, 2), new Vector3(2, 5, 4), new Vector3(3, 0, 6) };
        List<GameObject> joints = hasJoints ? new List<GameObject>() : null;
        if (joints != null)
        {
            foreach (Vector3 position in positions)
            {
                GameObject joint = Create("Joint");
                joint.transform.position = position;
                joints.Add(joint);
            }
        }
        const BindingFlags Members = BindingFlags.Instance | BindingFlags.NonPublic;
        typeof(EnemyController).GetField("mJoints", Members).SetValue(controller, joints);
        var result = (Vector3)typeof(EnemyController).GetMethod("GetRopePosition", Members)
            .Invoke(controller, new object[] { basePosition });
        Quaternion rotation = controller.transform.rotation;
        return new
        {
            basePosition = Vector(basePosition), rootPosition = Vector(controller.transform.position),
            leftPalmPosition = Vector(controller.mSoldierAnimationController.leftPalm.position),
            rootRotation = new[] { rotation.x, rotation.y, rotation.z, rotation.w },
            joints = hasJoints ? Array.ConvertAll(positions, Vector) : null, expected = Vector(result)
        };
    }

    private static GameObject Create(string name)
    {
        var created = new GameObject(name);
        OwnedObjects.Add(created);
        return created;
    }

    private static EnemyController CreateController()
    {
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/enemy.prefab");
        GameObject root = UnityEngine.Object.Instantiate(prefab);
        OwnedObjects.Add(root);
        EnemyController controller = root.GetComponent<EnemyController>();
        if (controller == null || controller.mSoldierAnimationController == null)
        {
            throw new InvalidOperationException("The recovered enemy prefab lacks its original controller bindings.");
        }
        controller.mSoldierAnimationController.leftPalm = Create("Palm").transform;
        return controller;
    }

    private static float[] Vector(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }
}
