using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Checks recovered body/helmet assets on inactive rigs without copying gameplay components.</summary>
public static class UnityInfantryVisualFactoryAudit
{
    private const int ExpectedRegistryFamilies = 17;
    private const int ExpectedStyleFamilies = 16;
    private const int ExpectedMissionCardFamilies = 7;
    private static int _checks;
    private static int _styles;

    /// <summary>Builds every source-required ordinary and mission-card infantry style.</summary>
    public static void Run()
    {
        _checks = 0;
        _styles = 0;
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            var components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            ObjectPoolDatabase pool = components.OfType<ObjectPoolDatabase>().Single();
            LevelBehaviourManager manager = components.OfType<LevelBehaviourManager>().Single();
            SoldierBehaviour[] families = manager.levelBehaviours.Select(entry => entry.behaviour)
                .OfType<SoldierBehaviour>().Where(family => !string.IsNullOrEmpty(family.unitDictionaryId) &&
                    family.soldierVisuals != null && family.soldierVisuals.Count > 0)
                .GroupBy(family => family.unitDictionaryId).Select(group => group.First()).ToArray();
            Require(families.Length == ExpectedRegistryFamilies,
                "Expected seventeen source infantry/helper families; got " + families.Length + ": " +
                string.Join(", ", families.Select(family => family.unitDictionaryId).ToArray()));
            // Buddy overrides UpdateVisual and receives player camos through ChangeCamo; its style list is unused.
            Require(families.Count(family => family is SoldierBehaviourBuddy) == 1,
                "The source Buddy helper must retain its separate player-camo appearance path.");
            SoldierBehaviour[] styleFamilies = families.Where(family => !(family is SoldierBehaviourBuddy)).ToArray();
            Require(styleFamilies.Length == ExpectedStyleFamilies,
                "All sixteen style-driven combat families are required.");
            HashSet<Type> cardFamilies = ReadMissionCardFamilies();
            int sourceCardFamilyCount = styleFamilies.Count(family => cardFamilies.Contains(family.GetType()));
            Require(sourceCardFamilyCount == ExpectedMissionCardFamilies,
                "The source mission catalog must bind all seven infantry card appearance families.");
            foreach (SoldierBehaviour family in styleFamilies)
            {
                VerifyStyles(pool.enemy, family.soldierVisuals, family.unitDictionaryId + "/ordinary");
                if (cardFamilies.Contains(family.GetType()))
                {
                    Require(family.cardSoldierVisuals != null && family.cardSoldierVisuals.Count > 0,
                        "A source mission card family must provide its own appearance lane.");
                    VerifyStyles(pool.enemy, family.cardSoldierVisuals, family.unitDictionaryId + "/card");
                }
            }

            Require(_styles == ExpectedStyleFamilies + ExpectedMissionCardFamilies,
                "All twenty-three source-required styles must be built in this client version.");
            VerifyAbsentHelmet(pool.enemy, families[0].soldierVisuals[0]);
            File.WriteAllText(Path.Combine(Application.dataPath, "../infantry-visual-factory-audit.json"),
                "{\"schemaVersion\":1,\"checks\":" + _checks + ",\"families\":" + families.Length +
                ",\"styleFamilies\":" + styleFamilies.Length + ",\"styles\":" + _styles +
                ",\"scope\":\"inactive source infantry geometry\"}\n");
            Debug.Log("PASS: " + _checks + " infantry visual factory checks across " + _styles + " source styles.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static HashSet<Type> ReadMissionCardFamilies()
    {
        string path = Path.Combine(Application.dataPath, "../coop-visual-mission-catalog.json");
        JArray missions = (JArray)JObject.Parse(File.ReadAllText(path))["missions"];
        var families = new HashSet<Type>();
        foreach (JToken mission in missions)
        {
            foreach (JToken spawn in mission["events"])
            {
                if (!(bool)spawn["isCardUnit"])
                {
                    continue;
                }

                Type behaviourType = Mission.behavioursDictionary[(string)spawn["behaviour"]].Value1;
                if (typeof(SoldierBehaviour).IsAssignableFrom(behaviourType))
                {
                    families.Add(behaviourType);
                }
            }
        }

        return families;
    }

    private static void VerifyStyles(EnemyController source, List<SoldierMeshChanger.SoldierStyle> styles, string lane)
    {
        if (styles == null)
        {
            return;
        }

        for (int index = 0; index < styles.Count; index++)
        {
            SoldierMeshChanger.SoldierStyle style = styles[index];
            SkinnedMeshRenderer template = source.meshChanger.skinnedMeshRenderer;
            Mesh originalMesh = template.sharedMesh;
            Material[] originalMaterials = template.sharedMaterials;
            Transform[] originalBones = template.bones;
            SelfHostedInfantryVisual visual;
            try
            {
                visual = SelfHostedInfantryVisualFactory.Create(source, style, "SourceStyleAudit");
            }
            catch (Exception failure)
            {
                throw new InvalidOperationException(
                    "Source style " + lane + "/" + index + " could not be built.", failure);
            }
            try
            {
                Require(!visual.Root.activeSelf, "An unposed source rig must remain inactive.");
                VerifyBody(source, style, visual);
                Require(template.sharedMesh == originalMesh &&
                    template.sharedMaterials.SequenceEqual(originalMaterials) &&
                    template.bones.SequenceEqual(originalBones),
                    "Creating a visual must not mutate the recovered template mesh, materials or bones.");
                Require(visual.Root.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
                    visual.Root.GetComponentsInChildren<Collider>(true).Length == 0 &&
                    visual.Root.GetComponentsInChildren<Rigidbody>(true).Length == 0 &&
                    visual.Root.GetComponentsInChildren<Animation>(true).Length == 0 &&
                    visual.Root.GetComponentsInChildren<Animator>(true).Length == 0,
                    "A visual rig must not contain recovered scripts, physics or autonomous animation.");
                VerifyHelmet(source, style, visual);
                _styles++;
            }
            finally
            {
                UnityEngine.Object.DestroyImmediate(visual.Root);
            }
        }
    }

    private static void VerifyBody(EnemyController source, SoldierMeshChanger.SoldierStyle style,
        SelfHostedInfantryVisual visual)
    {
        SkinnedMeshRenderer template = source.meshChanger.skinnedMeshRenderer;
        Require(visual.Body.sharedMesh == style.modelMeshRenderer.sharedMesh &&
            visual.Body.sharedMaterials.SequenceEqual(template.sharedMaterials),
            "ChangeSkins selects the style mesh while retaining the destination materials.");
        Require(visual.Body.bones.All(bone => bone != null && bone.IsChildOf(visual.Root.transform)) &&
            visual.Body.rootBone.IsChildOf(visual.Root.transform),
            "Every skin bone must belong to the copied rig rather than the source prefab.");

        // The mesh weights index the selected model's bones, not the template renderer's bone order.
        string[] selectedBoneNames = style.modelMeshRenderer.bones.Select(bone => bone.name).ToArray();
        string[] copiedBoneNames = visual.Body.bones.Select(bone => bone.name).ToArray();
        Require(copiedBoneNames.SequenceEqual(selectedBoneNames),
            "Copied skin bone order must preserve the selected source model's weight identities.");
        Require(visual.AnimationRoot.transform.localScale == Vector3.one,
            "SpawningManager resets the actor root scale before normal gameplay.");
    }

    private static void VerifyHelmet(EnemyController source, SoldierMeshChanger.SoldierStyle style,
        SelfHostedInfantryVisual visual)
    {
        FakeRigidBodySwapper helmet = source.meshChanger.helmet;
        if (helmet == null)
        {
            return;
        }

        string attachedPath = AnimationUtility.CalculateTransformPath(helmet.NoRigidBodyObject.transform,
            source.transform);
        string detachedPath = AnimationUtility.CalculateTransformPath(helmet.RigidBodyObject.transform,
            source.transform);
        Transform attached = visual.Root.transform.Find("Rig/" + attachedPath);
        Transform detached = visual.Root.transform.Find("Rig/" + detachedPath);
        Require(attached.GetComponent<MeshFilter>().sharedMesh == style.helmetMesh &&
            detached.GetComponent<MeshFilter>().sharedMesh == style.helmetMesh &&
            attached.gameObject.activeSelf && !detached.gameObject.activeSelf,
            "Both helmet forms must match the selected source mesh and source reset visibility.");
    }

    private static void VerifyAbsentHelmet(EnemyController source, SoldierMeshChanger.SoldierStyle bodyStyle)
    {
        bodyStyle.LoadModel();
        var style = new SoldierMeshChanger.SoldierStyle();
        typeof(SoldierMeshChanger.SoldierStyle).GetProperty("modelMeshRenderer")
            .SetValue(style, bodyStyle.modelMeshRenderer, null);
        SelfHostedInfantryVisual visual = SelfHostedInfantryVisualFactory.Create(source, style, "NoHelmetAudit");
        try
        {
            VerifyHelmet(source, style, visual);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(visual.Root);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }

        _checks++;
    }
}
