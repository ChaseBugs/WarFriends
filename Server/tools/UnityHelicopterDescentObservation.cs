using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

using Newtonsoft.Json.Linq;

using UnityEngine;

/// <summary>Invokes recovered descent on inactive owners, isolating pose math from global services.</summary>
public static class UnityHelicopterDescentObservation
{
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;
    private const float StartHeight = 10f;
    private static readonly Dictionary<int, EnemyController> Owners = new Dictionary<int, EnemyController>();
    private static JArray _nativeFrames;

    public static string NativeInputDigest { get; private set; }

    public static object Capture(Transform rig, Transform palm, int scenario, int frameIndex)
    {
        if (Environment.GetEnvironmentVariable("WAR_HELICOPTER_FADE_DESCENT") != "1")
        {
            return null;
        }
        EnemyController owner;
        if (!Owners.TryGetValue(scenario, out owner))
        {
            owner = Create(rig, palm, scenario);
            Owners.Add(scenario, owner);
        }
        ApplyNativeFrame(owner, frameIndex);
        owner.transform.SetPositionAndRotation(rig.position, rig.rotation);
        var point = (EnemyPointHelicopter)Get(owner, "mHeliPoint");
        var joints = (List<GameObject>)Get(owner, "mJoints");
        object input = new
        {
            root = Values(rig.position), rotation = Values(rig.rotation), palm = Values(palm.position),
            helicopterRight = Values(point.helicopter.mTransform.right),
            joints = joints.ConvertAll(joint => Values(joint.transform.position))
        };
        if (frameIndex > 0)
        {
            typeof(EnemyController).GetMethod("HelicopterUpdate", PrivateInstance).Invoke(owner, null);
            rig.SetPositionAndRotation(owner.transform.position, owner.transform.rotation);
        }
        return new
        {
            input, advanced = frameIndex > 0, startHeight = StartHeight, landingHeight = 0f,
            position = Values(owner.transform.position), rotation = Values(owner.transform.rotation),
            progress = (float)Get(owner, "mProgress")
        };
    }

    public static void Clear()
    {
        foreach (EnemyController owner in Owners.Values)
        {
            var point = (EnemyPointHelicopter)Get(owner, "mHeliPoint");
            var joints = (List<GameObject>)Get(owner, "mJoints");
            UnityEngine.Object.DestroyImmediate(point.helicopter.gameObject);
            foreach (GameObject joint in joints)
            {
                UnityEngine.Object.DestroyImmediate(joint);
            }
            UnityEngine.Object.DestroyImmediate(owner.gameObject);
        }
        Owners.Clear();
        _nativeFrames = null;
        NativeInputDigest = null;
    }

    private static void ApplyNativeFrame(EnemyController owner, int frameIndex)
    {
        string input = Environment.GetEnvironmentVariable("WAR_HELICOPTER_DESCENT_NATIVE_INPUT");
        if (string.IsNullOrEmpty(input))
        {
            return;
        }
        if (_nativeFrames == null)
        {
            _nativeFrames = ReadNativeFrames(input);
        }
        JToken frame = _nativeFrames[frameIndex];
        JArray positions = (JArray)frame["joints"];
        var joints = (List<GameObject>)Get(owner, "mJoints");
        while (joints.Count < positions.Count)
        {
            joints.Add(new GameObject("NativeObservedJoint" + joints.Count));
        }
        while (joints.Count > positions.Count)
        {
            UnityEngine.Object.DestroyImmediate(joints[joints.Count - 1]);
            joints.RemoveAt(joints.Count - 1);
        }
        for (int index = 0; index < joints.Count; index++)
        {
            joints[index].transform.position = Vector(positions[index]);
        }
        var point = (EnemyPointHelicopter)Get(owner, "mHeliPoint");
        point.helicopter.mTransform.rotation = Quaternion.FromToRotation(
            Vector3.right, Vector(frame["helicopterRight"]));
    }

    private static JArray ReadNativeFrames(string input)
    {
        byte[] bytes = File.ReadAllBytes(input);
        using (var sha = SHA256.Create())
        {
            NativeInputDigest = BitConverter.ToString(sha.ComputeHash(bytes)).Replace("-", "").ToLowerInvariant();
        }
        return (JArray)JObject.Parse(System.Text.Encoding.UTF8.GetString(bytes))["frames"];
    }

    private static Vector3 Vector(JToken value)
    {
        return new Vector3((float)value[0], (float)value[1], (float)value[2]);
    }

    private static EnemyController Create(Transform rig, Transform palm, int scenario)
    {
        // Inactive owners never run Awake/Start or contact the recovered singleton/provider graph.
        var root = new GameObject("InactiveDescentOwner" + scenario);
        root.SetActive(false);
        EnemyController owner = root.AddComponent<EnemyController>();
        owner.mTransform = root.transform;
        owner.mSoldierAnimationController = root.AddComponent<SoldierAnimationController>();
        owner.mSoldierAnimationController.leftPalm = palm;
        EnemyPointHelicopter point = root.AddComponent<EnemyPointHelicopter>();
        var aircraft = new GameObject("InactiveDescentAircraft" + scenario);
        aircraft.SetActive(false);
        point.helicopter = aircraft.AddComponent<Helicopter>();
        point.helicopter.mTransform = aircraft.transform;
        aircraft.transform.rotation = Quaternion.Euler(0, 60 + scenario * 20, 5);
        var joints = new List<GameObject>();
        for (int index = 0; index < 4; index++)
        {
            var joint = new GameObject("ObservedJoint" + index);
            joint.transform.position = new Vector3(2 + index * 0.2f, 14 - index * 6, 3);
            joints.Add(joint);
        }
        Set(owner, "mJoints", joints);
        Set(owner, "mHeliPoint", point);
        Set(owner, "mHeliStartYPos", StartHeight);
        Set(owner, "mHeliEndYPos", 0f);
        FieldInfo phase = typeof(EnemyController).GetField("mHeliPhase", PrivateInstance);
        phase.SetValue(owner, Enum.Parse(phase.FieldType, "Spawning"));
        rig.SetPositionAndRotation(new Vector3(0, StartHeight, 0), Quaternion.Euler(0, 30, 0));
        return owner;
    }

    private static object Get(EnemyController owner, string field)
    {
        return typeof(EnemyController).GetField(field, PrivateInstance).GetValue(owner);
    }

    private static void Set(EnemyController owner, string field, object value)
    {
        typeof(EnemyController).GetField(field, PrivateInstance).SetValue(owner, value);
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
