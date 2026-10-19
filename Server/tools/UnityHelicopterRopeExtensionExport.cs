using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

using Newtonsoft.Json;

/// <summary>Calls recovered QuickRope2 directly before any physical solve can alter its command result.</summary>
[InitializeOnLoad]
public static class UnityHelicopterRopeExtensionExport
{
    private const string Active = "WarFriends.RopeExtensionProbe";
    private const string OutputVariable = "WAR_ROPE_EXTENSION_OUTPUT";
    private const string RopeSource = "Assets/Plugins/Assembly-CSharp-firstpass/QuickRope2.cs";
    private const string HelicopterSource = "Assets/Scripts/Assembly-CSharp/Helicopter.cs";
    private const string PrefabSource = "Assets/GameObject/Helicopter.prefab";
    private const float SourceVelocity = 0.7f;
    private const int CaptureRate = 30;
    private static int _startingFrame = -1;

    static UnityHelicopterRopeExtensionExport()
    {
        if (SessionState.GetBool(Active, false))
        {
            EditorApplication.update += Observe;
        }
        if (SessionState.GetBool(Active + ".Finished", false))
        {
            EditorApplication.update += ExitWhenStopped;
        }
    }

    /// <summary>Runs an animation-free, inactive-joint command fixture in a disposable project.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/") ||
            string.IsNullOrEmpty(Environment.GetEnvironmentVariable(OutputVariable)))
        {
            throw new InvalidOperationException("Use a disposable project and explicit output path.");
        }
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        SessionState.SetBool(Active, true);
        EditorApplication.isPlaying = true;
    }

    private static void Observe()
    {
        if (!EditorApplication.isPlaying || EditorApplication.isPaused)
        {
            return;
        }
        if (_startingFrame < 0)
        {
            Time.captureFramerate = CaptureRate;
            _startingFrame = Time.frameCount;
            return;
        }
        if (Time.frameCount <= _startingFrame)
        {
            return;
        }
        try
        {
            WriteReference();
            Finish(0);
        }
        catch (Exception exception)
        {
            Debug.LogException(exception);
            Finish(1);
        }
    }

    private static void WriteReference()
    {
        QuickRope2 source = AssetDatabase.LoadAssetAtPath<GameObject>(PrefabSource)
            .GetComponentInChildren<QuickRope2>(true);
        float spacing = source.jointSpacing;
        object[] cases = new[]
        {
            Capture("ordinary", new Vector3(0, -spacing, 0), new Vector3(0, -spacing * 2, 0), spacing),
            Capture("below-threshold", new Vector3(0, -0.49f, 0), new Vector3(0, -0.7f, 0), spacing),
            Capture("exact-threshold", new Vector3(0, -(spacing * 1.5f - Time.deltaTime * SourceVelocity), 0),
                new Vector3(0, -0.7f, 0), spacing),
            Capture("cross-threshold", new Vector3(0, -0.51f, 0), new Vector3(0, -0.7f, 0), spacing),
            Capture("far-stretched", new Vector3(0, -0.9f, 0), new Vector3(0, -1.2f, 0), spacing),
            Capture("tilted", new Vector3(0.1f, -0.5f, 0.05f), new Vector3(0.3f, -0.8f, 0.1f), spacing),
            Capture("coincident-end-direction", new Vector3(0, -spacing, 0), Vector3.zero, spacing),
            Capture("tiny-end-direction", new Vector3(0, -spacing, 0), new Vector3(0, -0.000001f, 0), spacing)
        };
        string reference = JsonConvert.SerializeObject(new
        {
            version = 1, client = "1.4.0", unity = Application.unityVersion,
            ropeSource = RopeSource, ropeSha256 = Hash(RopeSource),
            helicopterSource = HelicopterSource, helicopterSha256 = Hash(HelicopterSource),
            prefabSource = PrefabSource, prefabSha256 = Hash(PrefabSource),
            fixture = "Inactive synthetic joints; original ExtendRope call; no intervening physics solve.",
            jointSpacing = spacing, velocity = SourceVelocity, deltaTime = Time.deltaTime, cases
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(Environment.GetEnvironmentVariable(OutputVariable), reference);
        Debug.Log("PASS: recovered rope extension commands=" + cases.Length);
    }

    private static object Capture(string name, Vector3 first, Vector3 second, float spacing)
    {
        var root = new GameObject("InactiveRopeCommandProbe");
        root.SetActive(false);
        QuickRope2 rope = root.AddComponent<QuickRope2>();
        rope.enabled = false;
        rope.showJoints = true;
        rope.Joints = new List<GameObject>();
        try
        {
            foreach (Vector3 position in new[] { Vector3.zero, first, second })
            {
                var joint = new GameObject("Joint" + rope.Joints.Count);
                joint.transform.SetParent(root.transform, false);
                joint.transform.position = position;
                joint.AddComponent<Rigidbody>();
                rope.Joints.Add(joint);
            }
            rope.Joints[0].AddComponent<ConfigurableJoint>();
            typeof(QuickRope2).GetField("distBetweenJoints", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(rope, spacing);
            GameObject originalFirst = rope.Joints[1];
            rope.ExtendRope(SourceVelocity);
            return new
            {
                name, anchor = Values(Vector3.zero), first = Values(first), second = Values(second),
                movedFirst = Values(originalFirst.transform.position),
                jointCount = rope.Joints.Count,
                inserted = rope.Joints.Count == 4 ? Values(rope.Joints[1].transform.position) : null,
                firstIsDynamic = !rope.Joints[1].GetComponent<Rigidbody>().isKinematic,
                anchorReconnected = rope.Joints[0].GetComponent<ConfigurableJoint>().connectedBody ==
                    rope.Joints[1].GetComponent<Rigidbody>()
            };
        }
        finally
        {
            foreach (GameObject joint in rope.Joints.ToArray())
            {
                UnityEngine.Object.DestroyImmediate(joint);
            }
            rope.Joints.Clear();
            UnityEngine.Object.DestroyImmediate(root);
        }
    }

    private static void Finish(int exitCode)
    {
        SessionState.SetBool(Active, false);
        EditorApplication.update -= Observe;
        SessionState.SetBool(Active + ".Finished", true);
        SessionState.SetInt(Active + ".ExitCode", exitCode);
        EditorApplication.update += ExitWhenStopped;
        EditorApplication.isPlaying = false;
    }

    private static void ExitWhenStopped()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
            return;
        }
        SessionState.SetBool(Active + ".Finished", false);
        EditorApplication.update -= ExitWhenStopped;
        EditorApplication.Exit(SessionState.GetInt(Active + ".ExitCode", 1));
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
}
