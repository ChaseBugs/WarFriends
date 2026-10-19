using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

using UnityEditor;
using UnityEngine;

using Newtonsoft.Json;

/// <summary>Observes activated original joint frames before solving, then records diagnostic native motion.</summary>
public static class UnityHelicopterRopePhysicsCapture
{
    private const string PrefabSource = "Assets/GameObject/Helicopter.prefab";
    private const float PhysicsStep = 0.02f;
    private const int DiagnosticSteps = 10;
    private const float MotionYawDegrees = 3f;
    private const int ExtensionSteps = 18;
    private const float ExtensionVelocity = 0.7f;
    private static readonly Vector3 MotionTranslation = new Vector3(0.04f, 0.01f, -0.02f);
    private static GameObject[] _parents;
    private static QuickRope2[] _ropes;
    private static Quaternion[] _attachmentRestRotations;
    private static int _createdFrame;
    private static bool _previousAutoSimulation;

    /// <summary>
    /// Waits one frame for source-deferred component destruction before reading physical connections.
    /// </summary>
    public static bool Advance()
    {
        try
        {
            if (_parents == null)
            {
                CreateFixtures();
                return false;
            }
            if (Time.frameCount <= _createdFrame)
            {
                return false;
            }
            WriteReference();
            Cleanup();
            return true;
        }
        catch
        {
            Cleanup();
            throw;
        }
    }

    private static void CreateFixtures()
    {
        _previousAutoSimulation = Physics.autoSimulation;
        Physics.autoSimulation = false;
        _parents = new GameObject[3];
        _ropes = new QuickRope2[3];
        _attachmentRestRotations = new Quaternion[3];
        CreateFixture(0, Vector3.zero, Quaternion.identity);
        CreateFixture(1, new Vector3(3, 7, 11), Quaternion.Euler(0, 90, 0));
        CreateFixture(2, new Vector3(-4, 2, -5), Quaternion.Euler(15, 35, 20));
        _createdFrame = Time.frameCount;
    }

    private static void CreateFixture(int index, Vector3 position, Quaternion rotation)
    {
        var parent = new GameObject("ActiveRopePhysics" + index);
        parent.SetActive(false);
        _parents[index] = parent;
        GameObject helicopter = UnityEngine.Object.Instantiate(
            AssetDatabase.LoadAssetAtPath<GameObject>(PrefabSource), parent.transform, false);
        helicopter.transform.position = position;
        helicopter.transform.rotation = rotation;
        QuickRope2 rope = helicopter.GetComponent<Helicopter>().rope;
        _ropes[index] = rope;
        rope.enabled = false;
        StripGameplay(helicopter, rope);
        helicopter.GetComponent<Rigidbody>().isKinematic = true;
        parent.SetActive(true);
        _attachmentRestRotations[index] = Quaternion.Inverse(helicopter.GetComponent<Rigidbody>().rotation) *
            rope.GetComponent<Rigidbody>().rotation;
        // Source OnEnable creates active bodies and automatic anchors. Inactive captures cannot realize these frames.
        rope.enabled = true;
        typeof(QuickRope2).GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(rope, null);
        rope.enabled = false;
    }

    private static void StripGameplay(GameObject root, QuickRope2 rope)
    {
        for (int pass = 0; pass < 5; pass++)
        {
            foreach (MonoBehaviour script in root.GetComponentsInChildren<MonoBehaviour>(true))
            {
                if (script != null && script != rope)
                {
                    UnityEngine.Object.DestroyImmediate(script);
                }
            }
        }
        if (root.GetComponentsInChildren<MonoBehaviour>(true).Any(script => script != null && script != rope))
        {
            throw new InvalidOperationException("Gameplay script remains on the activated rope fixture.");
        }
    }

    private static void WriteReference()
    {
        if (Environment.GetEnvironmentVariable("WAR_ROPE_CAPTURE_EXTENSION") == "1")
        {
            WriteExtensionReference();
            return;
        }
        if (Environment.GetEnvironmentVariable("WAR_ROPE_CAPTURE_MOTION") == "1")
        {
            WriteMotionReference();
            return;
        }
        object[] initial = _ropes.Select((rope, index) => Capture(rope, _attachmentRestRotations[index])).ToArray();
        var frames = new List<object>();
        for (int step = 1; step <= DiagnosticSteps; step++)
        {
            Physics.Simulate(PhysicsStep);
            frames.Add(new { step, ropes = _ropes.Select((rope, index) =>
                Capture(rope, _attachmentRestRotations[index])).ToArray() });
        }
        string reference = JsonConvert.SerializeObject(new
        {
            version = 1, client = "1.4.0", unity = Application.unityVersion,
            prefabSource = PrefabSource, prefabSha256 = Hash(PrefabSource),
            ropeSource = "Assets/Plugins/Assembly-CSharp-firstpass/QuickRope2.cs",
            ropeSha256 = Hash("Assets/Plugins/Assembly-CSharp-firstpass/QuickRope2.cs"),
            fixture = "Activated original ropes, stripped gameplay, kinematic aircraft, no extension commands.",
            gravity = Values(Physics.gravity), physicsStep = PhysicsStep,
            solverIterations = Physics.defaultSolverIterations,
            solverVelocityIterations = Physics.defaultSolverVelocityIterations,
            autoSyncTransforms = Physics.autoSyncTransforms,
            initial, frames
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(Environment.GetEnvironmentVariable("WAR_ROPE_PHYSICS_OUTPUT"), reference);
        Debug.Log("PASS: activated rope frames and native diagnostic steps=" + DiagnosticSteps);
    }

    private static void WriteMotionReference()
    {
        object[] initial = _ropes.Select((rope, index) => Capture(rope, _attachmentRestRotations[index])).ToArray();
        bool[][] aircraftChildren = _ropes.Select(rope =>
        {
            Transform aircraft = rope.GetComponent<FixedJoint>().connectedBody.transform;
            return rope.Joints.Select(joint => joint.transform.IsChildOf(aircraft)).ToArray();
        }).ToArray();
        var frames = new List<object>();
        for (int step = 1; step <= DiagnosticSteps; step++)
        {
            foreach (QuickRope2 rope in _ropes)
            {
                Transform aircraft = rope.GetComponent<FixedJoint>().connectedBody.transform;
                aircraft.position += MotionTranslation;
                aircraft.rotation = Quaternion.AngleAxis(MotionYawDegrees, Vector3.up) * aircraft.rotation;
            }
            Physics.SyncTransforms();
            object[] before = _ropes.Select((rope, index) => Capture(rope, _attachmentRestRotations[index])).ToArray();
            Physics.Simulate(PhysicsStep);
            object[] after = _ropes.Select((rope, index) => Capture(rope, _attachmentRestRotations[index])).ToArray();
            frames.Add(new { step, before, after });
        }
        string reference = JsonConvert.SerializeObject(new
        {
            version = 1, client = "1.4.0", unity = Application.unityVersion,
            prefabSource = PrefabSource, prefabSha256 = Hash(PrefabSource),
            ropeSource = "Assets/Plugins/Assembly-CSharp-firstpass/QuickRope2.cs",
            ropeSha256 = Hash("Assets/Plugins/Assembly-CSharp-firstpass/QuickRope2.cs"),
            fixture = "Direct aircraft Transform translation/yaw, SyncTransforms, then one native fixed step.",
            physicsStep = PhysicsStep, aircraftChildren, initial, frames
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(Environment.GetEnvironmentVariable("WAR_ROPE_PHYSICS_OUTPUT"), reference);
        Debug.Log("PASS: recovered moving-aircraft rope frames=" + frames.Count);
    }

    private static void WriteExtensionReference()
    {
        object[] initial = ExtensionStates();
        var frames = new List<object>();
        for (int step = 1; step <= ExtensionSteps; step++)
        {
            object[] before = ExtensionStates();
            foreach (QuickRope2 rope in _ropes)
            {
                rope.ExtendRope(ExtensionVelocity);
            }
            Physics.SyncTransforms();
            object[] command = ExtensionStates();
            Physics.Simulate(PhysicsStep);
            object[] after = ExtensionStates();
            frames.Add(new { step, before, command, after });
        }
        string reference = JsonConvert.SerializeObject(new
        {
            version = 1, client = "1.4.0", unity = Application.unityVersion,
            prefabSource = PrefabSource, prefabSha256 = Hash(PrefabSource),
            ropeSource = "Assets/Plugins/Assembly-CSharp-firstpass/QuickRope2.cs",
            ropeSha256 = Hash("Assets/Plugins/Assembly-CSharp-firstpass/QuickRope2.cs"),
            fixture = "Original ExtendRope command, SyncTransforms, then one native fixed step; stationary aircraft.",
            deltaTime = Time.deltaTime, velocity = ExtensionVelocity, physicsStep = PhysicsStep, initial, frames
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(Environment.GetEnvironmentVariable("WAR_ROPE_PHYSICS_OUTPUT"), reference);
        Debug.Log("PASS: recovered physical rope extension frames=" + frames.Count);
    }

    private static object[] ExtensionStates()
    {
        return _ropes.Select((rope, index) => new
        {
            state = Capture(rope, _attachmentRestRotations[index]),
            settings = rope.Joints.Select(joint =>
            {
                Rigidbody body = joint.GetComponent<Rigidbody>();
                return new { mass = body.mass, drag = body.drag, angularDrag = body.angularDrag,
                    useGravity = body.useGravity, isKinematic = body.isKinematic };
            }).ToArray()
        }).Cast<object>().ToArray();
    }

    private static object Capture(QuickRope2 rope, Quaternion attachmentRestRotation)
    {
        Rigidbody[] bodies = rope.Joints.Select(joint => joint.GetComponent<Rigidbody>()).ToArray();
        FixedJoint attachment = rope.GetComponent<FixedJoint>();
        return new
        {
            requestedSpacing = rope.jointSpacing,
            initialDistance = (float)typeof(QuickRope2)
                .GetField("distBetweenJoints", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(rope),
            attachmentConnectedRestRotation = Values(attachmentRestRotation),
            attachment = JointFrame(attachment),
            joints = bodies.Select(body => new
            {
                position = Values(body.position), rotation = Values(body.rotation),
                velocity = Values(body.velocity), angularVelocity = Values(body.angularVelocity),
                centerOfMass = Values(body.centerOfMass), inertiaTensor = Values(body.inertiaTensor),
                inertiaTensorRotation = Values(body.inertiaTensorRotation),
                maxAngularVelocity = body.maxAngularVelocity,
                sleepThreshold = body.sleepThreshold, solverIterations = body.solverIterations,
                solverVelocityIterations = body.solverVelocityIterations,
                connection = JointFrame(body.GetComponent<ConfigurableJoint>()),
                configurableJointCount = body.GetComponents<ConfigurableJoint>().Length
            }).ToArray()
        };
    }

    private static object JointFrame(Joint joint)
    {
        if (joint == null)
        {
            return null;
        }
        Rigidbody connected = joint.connectedBody;
        return new
        {
            anchor = Values(joint.anchor), connectedAnchor = Values(joint.connectedAnchor),
            autoConfigureConnectedAnchor = joint.autoConfigureConnectedAnchor,
            connectedPosition = Values(connected.position), connectedRotation = Values(connected.rotation)
        };
    }

    private static void Cleanup()
    {
        if (_parents == null)
        {
            return;
        }
        for (int index = 0; index < _parents.Length; index++)
        {
            QuickRope2 rope = _ropes[index];
            if (rope != null)
            {
                foreach (GameObject joint in rope.Joints.ToArray())
                {
                    if (joint != rope.gameObject && joint != rope.ropeEnd)
                    {
                        UnityEngine.Object.DestroyImmediate(joint);
                    }
                }
                rope.Joints.Clear();
            }
            UnityEngine.Object.DestroyImmediate(_parents[index]);
        }
        _parents = null;
        _ropes = null;
        _attachmentRestRotations = null;
        Physics.autoSimulation = _previousAutoSimulation;
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
