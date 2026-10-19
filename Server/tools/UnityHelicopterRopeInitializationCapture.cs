using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

using UnityEditor;
using UnityEngine;

using Newtonsoft.Json;

/// <summary>Captures generated source-prefab joint geometry and connection setup before the first solve.</summary>
public static class UnityHelicopterRopeInitializationCapture
{
    private const string PrefabSource = "Assets/GameObject/Helicopter.prefab";
    private const string RopeSource = "Assets/Plugins/Assembly-CSharp-firstpass/QuickRope2.cs";
    private const int ExtensionSteps = 8;
    private const float ExtensionVelocity = 0.7f;

    /// <summary>Measures the native near-collinear branch boundary without advancing a scene.</summary>
    public static void RunOrientationBoundary()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable validation project.");
        }
        int lower = BitConverter.ToInt32(BitConverter.GetBytes(0.0000001f), 0);
        int upper = BitConverter.ToInt32(BitConverter.GetBytes(0.001f), 0);
        while (upper - lower > 1)
        {
            int middle = lower + (upper - lower) / 2;
            float lateral = BitConverter.ToSingle(BitConverter.GetBytes(middle), 0);
            Quaternion rotation = Quaternion.LookRotation(new Vector3(lateral, 1, 0));
            if (Mathf.Abs(rotation.z) < 0.25f)
            {
                lower = middle;
            }
            else
            {
                upper = middle;
            }
        }
        float lastFallback = BitConverter.ToSingle(BitConverter.GetBytes(lower), 0);
        float firstMatrix = BitConverter.ToSingle(BitConverter.GetBytes(upper), 0);
        string reference = JsonConvert.SerializeObject(new { unity = Application.unityVersion,
            lastFallback, firstMatrix, lastFallbackBits = lower, firstMatrixBits = upper }, Formatting.Indented)
            .Replace("\r\n", "\n") + "\n";
        File.WriteAllText(Environment.GetEnvironmentVariable("WAR_ROPE_INITIALIZATION_OUTPUT"), reference);
        Debug.Log("PASS: native rope orientation boundary=" + firstMatrix.ToString("R"));
        EditorApplication.Exit(0);
    }

    /// <summary>Called by the disposable Play Mode lifecycle in UnityHelicopterRopeExtensionExport.</summary>
    public static void Run()
    {
        object[] cases =
        {
            Capture("identity", Vector3.zero, Quaternion.identity),
            Capture("translated-yaw", new Vector3(3, 7, 11), Quaternion.Euler(0, 90, 0)),
            Capture("translated-tilt", new Vector3(-4, 2, -5), Quaternion.Euler(15, 35, 20)),
            Capture("vertical-control", Vector3.zero, Quaternion.identity, Vector3.down),
            Capture("upward-control", Vector3.zero, Quaternion.identity, Vector3.up),
            Capture("near-vertical-small", Vector3.zero, Quaternion.identity, new Vector3(0.000001f, -1, 0)),
            Capture("near-vertical-intermediate", Vector3.zero, Quaternion.identity, new Vector3(0.000002f, -1, 0)),
            Capture("near-vertical-medium", Vector3.zero, Quaternion.identity, new Vector3(0.0001f, -1, 0)),
            Capture("near-vertical-large", Vector3.zero, Quaternion.identity, new Vector3(0.01f, -1, 0))
        };
        string reference = JsonConvert.SerializeObject(new
        {
            version = 1, client = "1.4.0", unity = Application.unityVersion,
            prefabSource = PrefabSource, prefabSha256 = Hash(PrefabSource),
            ropeSource = RopeSource, ropeSha256 = Hash(RopeSource),
            fixture = "Inactive original prefab; ApplyRopeSettings and Start before physics; " +
                "vertical endpoint control.",
            extensionDeltaTime = Time.deltaTime,
            cases
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(Environment.GetEnvironmentVariable("WAR_ROPE_INITIALIZATION_OUTPUT"), reference);
        Debug.Log("PASS: original Helicopter rope initialization cases=" + cases.Length);
    }

    private static object Capture(string name, Vector3 position, Quaternion rotation, Vector3? direction = null)
    {
        var inactiveParent = new GameObject("InactiveRopeInitialization");
        inactiveParent.SetActive(false);
        GameObject helicopter = UnityEngine.Object.Instantiate(
            AssetDatabase.LoadAssetAtPath<GameObject>(PrefabSource), inactiveParent.transform, false);
        helicopter.transform.position = position;
        helicopter.transform.rotation = rotation;
        QuickRope2 rope = helicopter.GetComponent<Helicopter>().rope;
        try
        {
            var serialized = new SerializedObject(rope);
            if (serialized.FindProperty("controlPoints").arraySize != 0 || rope.JointPrefab != null)
            {
                throw new InvalidOperationException(
                    "The source rope is no longer the unadorned zero-control-point rig.");
            }
            Vector3 anchor = rope.transform.position;
            Vector3 end = rope.ropeEnd.transform.position;
            if (direction.HasValue)
            {
                float length = Vector3.Distance(anchor, end);
                helicopter.transform.position -= anchor;
                rope.ropeEnd.transform.position = direction.Value * length;
                anchor = rope.transform.position;
                end = rope.ropeEnd.transform.position;
            }
            rope.ApplyRopeSettings();
            typeof(QuickRope2).GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(rope, null);
            float initialDistance = (float)typeof(QuickRope2)
                .GetField("distBetweenJoints", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(rope);
            Rigidbody[] bodies = rope.Joints.Select(joint => joint.GetComponent<Rigidbody>()).ToArray();
            object[] joints = rope.Joints.Select(joint => CaptureJoint(joint, bodies)).ToArray();
            object[] extensions = CaptureExtensions(rope);
            return new
            {
                name, anchor = Values(anchor), end = Values(end), requestedSpacing = rope.jointSpacing,
                initialDistance, joints, extensions
            };
        }
        finally
        {
            foreach (GameObject joint in rope.Joints.ToArray())
            {
                if (joint != rope.gameObject && joint != rope.ropeEnd)
                {
                    UnityEngine.Object.DestroyImmediate(joint);
                }
            }
            rope.Joints.Clear();
            UnityEngine.Object.DestroyImmediate(inactiveParent);
        }
    }

    private static object[] CaptureExtensions(QuickRope2 rope)
    {
        var steps = new object[ExtensionSteps];
        for (int step = 0; step < steps.Length; step++)
        {
            rope.ExtendRope(ExtensionVelocity);
            steps[step] = new
            {
                positions = rope.Joints.Select(joint => Values(joint.transform.position)).ToArray()
            };
        }
        return steps;
    }

    private static object CaptureJoint(GameObject joint, Rigidbody[] bodies)
    {
        Rigidbody body = joint.GetComponent<Rigidbody>();
        ConfigurableJoint connection = joint.GetComponent<ConfigurableJoint>();
        return new
        {
            position = Values(joint.transform.position), rotation = Values(joint.transform.rotation),
            mass = body.mass, drag = body.drag, angularDrag = body.angularDrag, useGravity = body.useGravity,
            isKinematic = body.isKinematic, constraints = body.constraints.ToString(),
            connection = connection == null ? null : new
            {
                connectedIndex = Array.IndexOf(bodies, connection.connectedBody),
                autoConfigureConnectedAnchor = connection.autoConfigureConnectedAnchor,
                anchor = Values(connection.anchor), connectedAnchor = Values(connection.connectedAnchor),
                xMotion = connection.xMotion.ToString(), yMotion = connection.yMotion.ToString(),
                zMotion = connection.zMotion.ToString(), angularX = connection.angularXMotion.ToString(),
                angularY = connection.angularYMotion.ToString(), angularZ = connection.angularZMotion.ToString(),
                lowX = connection.lowAngularXLimit.limit, highX = connection.highAngularXLimit.limit,
                limitY = connection.angularYLimit.limit, limitZ = connection.angularZLimit.limit
            }
        };
    }

    private static string Hash(string path)
    {
        using (var sha = SHA256.Create())
        {
            return BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(path)))
                .Replace("-", "").ToLowerInvariant();
        }
    }

    private static float[] Values(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }

    private static float[] Values(Quaternion value)
    {
        return new[] { value.x, value.y, value.z, value.w };
    }
}
