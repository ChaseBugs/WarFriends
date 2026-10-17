using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Compares the production renderer with automatic source observations on one reused factory actor.</summary>
public static class UnityObservedInfantryRendererAudit
{
    private const float PositionTolerance = 0.00001f;
    private const float RotationTolerance = 0.000001f;
    private const float ScaleTolerance = 0.00001f;
    private const int ObservationsPerPhase = 13;
    private const string ReferenceDigest = "f1f062324d04c7a3e816984ad6edc4fa26f44a568fb3351b3418b575b181ce47";

    /// <summary>Checks forward, reverse and replay order without enabling combat or host publication.</summary>
    public static void Run()
    {
        SelfHostedInfantryVisual visual = null;
        try
        {
            JObject reference = ReadReference();
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            SoldierBehaviourAssaulter family = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<LevelBehaviourManager>(true)).Single()
                .levelBehaviours.Select(entry => entry.behaviour).OfType<SoldierBehaviourAssaulter>().First();
            EnemyController source = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/enemy.prefab")
                .GetComponent<EnemyController>();
            Weapon rifle = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/AssaultRifleEnemy.prefab")
                .GetComponent<Weapon>();
            var selected = new EnemyBasicInventory.InventoryWeapon { weapon = rifle };
            visual = SelfHostedInfantryVisualFactory.Create(source, family.soldierVisuals[0], selected, "PoseAudit");
            var renderer = new SelfHostedObservedInfantryPoseRenderer(
                visual, source.GetComponentInChildren<Animation>(true));
            JArray samples = (JArray)reference["samples"];
            foreach (JObject sample in samples)
            {
                VerifySample(renderer, visual, sample);
            }

            foreach (JObject sample in samples.Reverse())
            {
                VerifySample(renderer, visual, sample);
                VerifySample(renderer, visual, sample);
            }

            VerifyRejections(renderer, visual);
            Debug.Log("PASS: 663 production observed-pose samples match source local transforms; no gameplay proof.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            if (visual != null)
            {
                UnityEngine.Object.DestroyImmediate(visual.Root);
            }
        }
    }

    private static JObject ReadReference()
    {
        string path = Environment.GetEnvironmentVariable("WAR_OBSTACLE_RENDERER_REFERENCE");
        using (SHA256 hash = SHA256.Create())
        {
            string digest = BitConverter.ToString(hash.ComputeHash(File.ReadAllBytes(path)))
                .Replace("-", "").ToLowerInvariant();
            if (digest != ReferenceDigest)
            {
                throw new InvalidOperationException("The automatic source observation bytes changed.");
            }
        }

        using (var reader = new StreamReader(new GZipStream(File.OpenRead(path), CompressionMode.Decompress)))
        {
            return JObject.Parse(reader.ReadToEnd());
        }
    }

    private static void VerifyRejections(
        SelfHostedObservedInfantryPoseRenderer renderer, SelfHostedInfantryVisual visual)
    {
        Transform rig = visual.Root.transform.GetChild(0);
        Animation animation = visual.AnimationRoot.GetComponent<Animation>();
        string before = JObject.FromObject(UnityCoopRigFrameCapture.Capture(rig, animation)).ToString();
        Reject(() => renderer.Sample(new BattleInfantryObservedPoseReference()));
        string after = JObject.FromObject(UnityCoopRigFrameCapture.Capture(rig, animation)).ToString();
        if (before != after)
        {
            throw new InvalidOperationException("A rejected catalog reference changed the displayed pose.");
        }

        Transform changed = rig.GetChild(0);
        string originalName = changed.name;
        changed.name = "RejectedTopology";
        before = JObject.FromObject(UnityCoopRigFrameCapture.Capture(rig, animation)).ToString();
        Reject(() => renderer.Sample(new BattleInfantryObservedPoseReference
        {
            CatalogRevision = ObservedInfantryPoseCatalogData.BuiltIn.Revision,
            SampleId = 1
        }));
        after = JObject.FromObject(UnityCoopRigFrameCapture.Capture(rig, animation)).ToString();
        changed.name = originalName;
        if (before != after)
        {
            throw new InvalidOperationException("A rejected topology changed mixer or transform state.");
        }
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (Exception failure)
        {
            // The retained AWS binary also defines InvalidDataException in this recovered Editor project.
            if (failure.GetType().FullName == "System.IO.InvalidDataException" ||
                failure is InvalidOperationException)
            {
                return;
            }

            throw;
        }

        throw new InvalidOperationException("An invalid renderer input was accepted.");
    }

    private static void VerifySample(
        SelfHostedObservedInfantryPoseRenderer renderer, SelfHostedInfantryVisual visual, JObject sample)
    {
        uint id = (uint)((int)sample["priorReturnTicks"] * ObservationsPerPhase +
            (int)sample["observationTick"] + 1);
        renderer.Sample(new BattleInfantryObservedPoseReference
        {
            CatalogRevision = ObservedInfantryPoseCatalogData.BuiltIn.Revision,
            SampleId = id
        });
        Transform rig = visual.Root.transform.GetChild(0);
        foreach (JObject expected in sample["rig"]["transforms"])
        {
            string path = (string)expected["path"];
            if (path == "root")
            {
                continue;
            }

            Transform target = Resolve(rig, path);
            Compare(target, expected, id);
        }
    }

    private static void Compare(Transform actual, JObject expected, uint sampleId)
    {
        JToken rotation = expected["rotation"];
        var expectedRotation = new Quaternion(
            (float)rotation[0], (float)rotation[1], (float)rotation[2], (float)rotation[3]);
        Vector3 scale = Vector(expected["scale"]);
        if (actual.name != (string)expected["name"] ||
            Vector3.Distance(actual.localPosition, Vector(expected["position"])) > PositionTolerance ||
            1f - Mathf.Abs(Quaternion.Dot(actual.localRotation.normalized, expectedRotation.normalized)) >
                RotationTolerance)
        {
            throw new InvalidOperationException("Observed renderer pose differs at sample " + sampleId +
                ", path " + expected["path"] + ", position " + actual.localPosition + ".");
        }

        for (int axis = 0; axis < 3; axis++)
        {
            if (Mathf.Abs(actual.localScale[axis] - scale[axis]) > Mathf.Abs(scale[axis]) * ScaleTolerance)
            {
                throw new InvalidOperationException("Observed renderer scale differs at sample " + sampleId +
                    ", path " + expected["path"] + ".");
            }
        }
    }

    private static Transform Resolve(Transform root, string path)
    {
        Transform current = root;
        string[] segments = path.Split('/');
        for (int index = 1; index < segments.Length; index++)
        {
            current = current.GetChild(int.Parse(segments[index]));
        }

        return current;
    }

    private static Vector3 Vector(JToken value)
    {
        return new Vector3((float)value[0], (float)value[1], (float)value[2]);
    }
}
