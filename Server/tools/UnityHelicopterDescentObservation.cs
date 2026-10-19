using System;
using System.Collections.Generic;
using System.Reflection;

using UnityEngine;

/// <summary>Invokes recovered descent on inactive owners, isolating pose math from global services.</summary>
public static class UnityHelicopterDescentObservation
{
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;
    private const float StartHeight = 10f;
    private static readonly Dictionary<int, EnemyController> Owners = new Dictionary<int, EnemyController>();

    public static object Capture(Transform rig, Transform palm, int scenario, bool advance)
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
        owner.transform.SetPositionAndRotation(rig.position, rig.rotation);
        var point = (EnemyPointHelicopter)Get(owner, "mHeliPoint");
        var joints = (List<GameObject>)Get(owner, "mJoints");
        object input = new
        {
            root = Values(rig.position), rotation = Values(rig.rotation), palm = Values(palm.position),
            helicopterRight = Values(point.helicopter.mTransform.right),
            joints = joints.ConvertAll(joint => Values(joint.transform.position))
        };
        if (advance)
        {
            typeof(EnemyController).GetMethod("HelicopterUpdate", PrivateInstance).Invoke(owner, null);
            rig.SetPositionAndRotation(owner.transform.position, owner.transform.rotation);
        }
        return new
        {
            input, advanced = advance, startHeight = StartHeight, landingHeight = 0f,
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
