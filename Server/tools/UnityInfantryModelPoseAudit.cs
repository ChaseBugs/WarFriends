using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks model replacement followed by observed-pose reconstruction on production factory actors.</summary>
public static class UnityInfantryModelPoseAudit
{
    private const int ObservationsPerPhase = 13;
    private static Action<Transform, JObject, uint> _compare;
    private static Func<Transform, string, Transform> _resolve;
    private static int _checks;

    /// <summary>Exercises every supported source selection against all 221 captured pose observations.</summary>
    public static void Run()
    {
        try
        {
            BindSourceComparators();
            JObject reference = (JObject)typeof(UnityObservedInfantryRendererAudit)
                .GetMethod("ReadReference", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null);
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            SoldierBehaviourAssaulter family = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<LevelBehaviourManager>(true)).Single()
                .levelBehaviours.Select(entry => entry.behaviour).OfType<SoldierBehaviourAssaulter>().First();
            EnemyController source = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/enemy.prefab")
                .GetComponent<EnemyController>();
            var slots = (UpgradeSlotsAssaulter)family.upgradeSlots;
            _checks = 0;
            foreach (SelfHostedInfantryWeaponAppearance appearance in EnumerateAppearances(family, slots))
            {
                VerifyAppearance(source, family.soldierVisuals[0], appearance, (JArray)reference["samples"]);
            }

            Debug.Log("PASS: " + _checks + " model/pose applications preserve source body poses and weapon models; " +
                "one body style, no gameplay proof.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static IEnumerable<SelfHostedInfantryWeaponAppearance> EnumerateAppearances(
        SoldierBehaviourAssaulter family, UpgradeSlotsAssaulter slots)
    {
        int maximum = slots.visualsWeapon.Max(visual => visual.level) + 1;
        for (int level = 0; level <= maximum; level++)
        {
            yield return SelfHostedInfantryWeaponAppearance.ResolveOrdinary(
                family, new UpgradeSlots.UnitUpgrades { slotUpgradeindex = level });
        }

        maximum = slots.eliteVisualsWeapon.Max(visual => visual.level) + 1;
        for (int level = 0; level <= maximum; level++)
        {
            yield return SelfHostedInfantryWeaponAppearance.ResolveOrdinary(
                family, new UpgradeSlots.UnitUpgrades { slotUpgradeindex = level, isElite = true });
        }

        yield return SelfHostedInfantryWeaponAppearance.ResolveCard(family);
    }

    private static void VerifyAppearance(
        EnemyController source, SoldierMeshChanger.SoldierStyle style,
        SelfHostedInfantryWeaponAppearance appearance, JArray samples)
    {
        SelfHostedInfantryVisual visual = SelfHostedInfantryVisualFactory.CreateWithAppearance(
            source, style, appearance, "ModelPoseAudit");
        try
        {
            Transform model = visual.WeaponRoot.GetComponentsInChildren<MeshFilter>(true)
                .Single(filter => filter.sharedMesh == appearance.Model.GetComponent<MeshFilter>().sharedMesh)
                .transform;
            var renderer = new SelfHostedObservedInfantryPoseRenderer(
                visual, source.GetComponentInChildren<Animation>(true));
            var targets = new Dictionary<string, Transform>();
            foreach (JObject expected in samples[0]["rig"]["transforms"])
            {
                string path = (string)expected["path"];
                targets.Add(path, _resolve(visual.Root.transform.GetChild(0), path));
            }

            var binding = new ModelBinding(appearance, model, targets);
            foreach (JObject sample in samples)
            {
                VerifySample(renderer, binding, sample);
                _checks++;
            }
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(visual.Root);
        }
    }

    private static void VerifySample(
        SelfHostedObservedInfantryPoseRenderer renderer, ModelBinding binding, JObject sample)
    {
        SelfHostedInfantryWeaponAppearance appearance = binding.Appearance;
        Transform model = binding.Model;
        uint id = (uint)((int)sample["priorReturnTicks"] * ObservationsPerPhase +
            (int)sample["observationTick"] + 1);
        renderer.Sample(new BattleInfantryObservedPoseReference
        {
            CatalogRevision = ObservedInfantryPoseCatalogData.BuiltIn.Revision, SampleId = id
        });
        foreach (JObject expected in sample["rig"]["transforms"])
        {
            string path = (string)expected["path"];
            Transform target = binding.Targets[path];
            if (path != "root" && target != model)
            {
                _compare(target, expected, id);
            }
            else if (target == model)
            {
                CompareModelRotation(model, expected);
            }
        }

        if (model.localPosition != -appearance.Model.pivot.localPosition || model.localScale != appearance.Scale ||
            model.GetComponent<MeshFilter>().sharedMesh != appearance.Model.GetComponent<MeshFilter>().sharedMesh ||
            model.GetComponent<MeshRenderer>().sharedMaterial !=
                appearance.Model.GetComponent<Renderer>().sharedMaterial)
        {
            throw new InvalidOperationException(
                "Pose reconstruction changed the selected weapon model at sample " + id);
        }
    }

    private static void CompareModelRotation(Transform model, JObject expected)
    {
        const float RotationTolerance = 0.000001f;
        JToken rotation = expected["rotation"];
        var sourceRotation = new Quaternion(
            (float)rotation[0], (float)rotation[1], (float)rotation[2], (float)rotation[3]);
        if (1f - Mathf.Abs(Quaternion.Dot(model.localRotation.normalized, sourceRotation.normalized)) >
            RotationTolerance)
        {
            throw new InvalidOperationException("Model replacement changed the source weapon rotation.");
        }
    }

    private static void BindSourceComparators()
    {
        const BindingFlags Flags = BindingFlags.Static | BindingFlags.NonPublic;
        Type audit = typeof(UnityObservedInfantryRendererAudit);
        _compare = (Action<Transform, JObject, uint>)Delegate.CreateDelegate(
            typeof(Action<Transform, JObject, uint>), audit.GetMethod("Compare", Flags));
        _resolve = (Func<Transform, string, Transform>)Delegate.CreateDelegate(
            typeof(Func<Transform, string, Transform>), audit.GetMethod("Resolve", Flags));
    }

    private sealed class ModelBinding
    {
        internal SelfHostedInfantryWeaponAppearance Appearance { get; private set; }

        internal Transform Model { get; private set; }

        internal Dictionary<string, Transform> Targets { get; private set; }

        internal ModelBinding(SelfHostedInfantryWeaponAppearance appearance, Transform model,
            Dictionary<string, Transform> targets)
        {
            Appearance = appearance;
            Model = model;
            Targets = targets;
        }
    }
}
