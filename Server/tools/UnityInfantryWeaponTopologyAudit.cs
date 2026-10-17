using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks the production visual factory against the captured body and rifle topology.</summary>
public static class UnityInfantryWeaponTopologyAudit
{
    private const int ExpectedTransforms = 59;

    /// <summary>Validates source attachment identities without enabling recovered enemy simulation.</summary>
    public static void Run()
    {
        SelfHostedInfantryVisual visual = null;
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            LevelBehaviourManager manager = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<LevelBehaviourManager>(true)).Single();
            SoldierBehaviourAssaulter family = manager.levelBehaviours
                .Select(entry => entry.behaviour).OfType<SoldierBehaviourAssaulter>().First();
            EnemyController source = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/enemy.prefab")
                .GetComponent<EnemyController>();
            Weapon rifle = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/AssaultRifleEnemy.prefab")
                .GetComponent<Weapon>();
            var selected = new EnemyBasicInventory.InventoryWeapon { weapon = rifle, leftHand = false };
            visual = SelfHostedInfantryVisualFactory.Create(source, family.soldierVisuals[0], selected, "TopologyAudit");
            Verify(visual);
            VerifyAttachment(visual, rifle);
            Debug.Log("PASS: production body/rifle topology matches all 58 catalog identities; no gameplay proof.");
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

    private static void VerifyAttachment(SelfHostedInfantryVisual visual, Weapon source)
    {
        Transform weapon = visual.Root.GetComponentsInChildren<Transform>(true)
            .Single(transform => transform.name == source.name);
        if (weapon.localPosition != Vector3.zero || weapon.localScale != Vector3.one ||
            Quaternion.Angle(weapon.localRotation, source.transform.localRotation) > 0.001f ||
            weapon.GetComponentsInChildren<MeshRenderer>(true).Length !=
                source.GetComponentsInChildren<MeshRenderer>(true).Length)
        {
            throw new InvalidOperationException("The copied rifle must retain source attachment and mesh rules.");
        }
    }

    private static void Verify(SelfHostedInfantryVisual visual)
    {
        Transform rig = visual.Root.transform.GetChild(0);
        if (visual.Root.activeSelf || rig.GetComponentsInChildren<Transform>(true).Length != ExpectedTransforms ||
            visual.Root.GetComponentsInChildren<MonoBehaviour>(true).Length != 0 ||
            visual.Root.GetComponentsInChildren<Collider>(true).Length != 0 ||
            visual.Root.GetComponentsInChildren<Rigidbody>(true).Length != 0)
        {
            throw new InvalidOperationException("The visual must remain inactive, complete and free of gameplay components.");
        }

        foreach (ObservedInfantryPoseTransform identity in ObservedInfantryPoseCatalogData.BuiltIn.Snapshot().Skeleton)
        {
            Transform actual = rig;
            string[] segments = identity.Path.Split('/');
            for (int index = 1; index < segments.Length; index++)
            {
                actual = actual.GetChild(int.Parse(segments[index]));
            }

            if (actual.name != identity.Name)
            {
                throw new InvalidOperationException("The production visual topology differs at " + identity.Path);
            }
        }
    }
}
