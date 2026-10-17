using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Checks source-backed normal, Elite and card weapon selection on recovered scene data.</summary>
public static class UnityInfantryWeaponSelectionAudit
{
    /// <summary>Compares model numbers with the recovered behavior's own protected selectors.</summary>
    public static void Run()
    {
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            SoldierBehaviourAssaulter family = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<LevelBehaviourManager>(true)).Single()
                .levelBehaviours.Select(entry => entry.behaviour).OfType<SoldierBehaviourAssaulter>().First();
            var slots = (UpgradeSlotsAssaulter)family.upgradeSlots;
            int checks = VerifyLane(family, slots.visualsWeapon, false);
            checks += VerifyLane(family, slots.eliteVisualsWeapon, true);
            SelfHostedInfantryWeaponAppearance card = SelfHostedInfantryWeaponAppearance.ResolveCard(family);
            int expectedCard = ((int[])typeof(SoldierBehaviour).GetMethod("GetCardWeaponLevels",
                BindingFlags.Instance | BindingFlags.NonPublic).Invoke(family, null))[0];
            if (card.ModelNumber != expectedCard)
            {
                throw new InvalidOperationException("Card appearance differs from the recovered selector.");
            }

            VerifyModelCopy(card);
            VerifySourceProtection(card);
            Debug.Log("PASS: " + (checks + 1) + " recovered weapon model/resource selections; card " +
                card.ResourcePath + "; no gameplay proof.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void VerifySourceProtection(SelfHostedInfantryWeaponAppearance appearance)
    {
        try
        {
            appearance.ApplyTo(appearance.WeaponPrefab.transform);
        }
        catch (ArgumentException)
        {
            return;
        }

        throw new InvalidOperationException("Appearance application must never mutate its source prefab.");
    }

    private static int VerifyLane(
        SoldierBehaviourAssaulter family, System.Collections.Generic.List<TechnologyVisualDefinition> visuals,
        bool isElite)
    {
        int checks = 0;
        int maximum = visuals.Max(visual => visual.level) + 1;
        MethodInfo selector = typeof(SoldierBehaviour).GetMethod("GetWeaponLevels",
            BindingFlags.Instance | BindingFlags.NonPublic);
        for (int level = 0; level <= maximum; level++)
        {
            var upgrades = new UpgradeSlots.UnitUpgrades { slotUpgradeindex = level, isElite = isElite };
            int expected = ((int[])selector.Invoke(family, new object[] { upgrades }))[0];
            SelfHostedInfantryWeaponAppearance actual =
                SelfHostedInfantryWeaponAppearance.ResolveOrdinary(family, upgrades);
            if (actual.ModelNumber != expected || actual.Model == null)
            {
                throw new InvalidOperationException("Weapon selection differs at upgrade index " + level + ".");
            }

            VerifyModelCopy(actual);
            checks++;
        }

        return checks;
    }

    private static void VerifyModelCopy(SelfHostedInfantryWeaponAppearance appearance)
    {
        var root = new GameObject(appearance.WeaponPrefab.name);
        root.SetActive(false);
        try
        {
            SelfHostedVisualHierarchy.CopyRoot(appearance.WeaponPrefab.transform, root.transform,
                new System.Collections.Generic.Dictionary<Transform, Transform>());
            appearance.ApplyTo(root.transform);
            Mesh expected = appearance.Model.GetComponent<MeshFilter>().sharedMesh;
            MeshFilter actual = root.GetComponentsInChildren<MeshFilter>(true)
                .Single(filter => filter.sharedMesh == expected);
            if (actual.transform.localPosition != -appearance.Model.pivot.localPosition ||
                actual.transform.localScale != appearance.Scale ||
                actual.GetComponent<MeshRenderer>().sharedMaterial !=
                    appearance.Model.GetComponent<Renderer>().sharedMaterial ||
                root.GetComponentsInChildren<MonoBehaviour>(true).Length != 0)
            {
                throw new InvalidOperationException("The copied source weapon model differs from SetLevel rules.");
            }
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(root);
        }
    }
}
