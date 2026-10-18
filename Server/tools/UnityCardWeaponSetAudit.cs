using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Shared;

/// <summary>Checks ordered card weapon construction and explicit visibility against recovered selectors.</summary>
public static class UnityCardWeaponSetAudit
{
    private static int _checks;
    private static int _weapons;

    /// <summary>Exercises all six infantry card inventories without activating production gameplay.</summary>
    public static void Run()
    {
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Component[] components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            EnemyController source = components.OfType<ObjectPoolDatabase>().Single().enemy;
            LevelBehaviourManager manager = components.OfType<LevelBehaviourManager>().Single();
            foreach (string cardId in new[]
                { "BIGROCKET", "ELITEMINIGUN", "ELITEPARA", "ELITESNIPER", "ELITESWAT", "GREATGRENADIER" })
            {
                SoldierBehaviour family = manager.levelBehaviours.Select(entry => entry.behaviour)
                    .OfType<SoldierBehaviour>()
                    .First(item => CardUnitSourceIdentity.Matches(cardId, item.unitDictionaryId));
                VerifyInventory(source, family);
            }

            Debug.Log("PASS: " + _checks + " card weapon set checks; six inventories, " +
                _weapons + " source weapons.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void VerifyInventory(EnemyController source, SoldierBehaviour family)
    {
        SelfHostedInfantryVisual actor = SelfHostedInfantryVisualFactory.Create(
            source, family.cardSoldierVisuals[0], "CardWeaponsAudit");
        GameObject referenceRoot = new GameObject("ReferenceWeaponInventory");
        try
        {
            IReadOnlyList<SelfHostedInfantryWeaponAppearance> appearances =
                SelfHostedInfantryWeaponAppearance.ResolveCardInventory(family);
            int[] expected = (int[])typeof(SoldierBehaviour).GetMethod("GetCardWeaponLevels",
                BindingFlags.Instance | BindingFlags.NonPublic).Invoke(family, null);
            List<EnemyBasicInventory.InventoryWeapon> inventory =
                family.GetComponent<EnemyBasicInventory>().cardWeapons;
            Require(appearances.Count == inventory.Count && appearances.Count == expected.Length,
                "Every source inventory entry must retain its own ordered level.");
            SelfHostedInfantryWeaponSet set = SelfHostedInfantryWeaponSet.CreateCard(family, source, actor, 1u);
            EnemyBasicInventory reference = CreateReference(referenceRoot, inventory);
            for (int index = 0; index < appearances.Count; index++)
            {
                SelfHostedInfantryWeaponAppearance appearance = appearances[index];
                Require(appearance.WeaponPrefab == inventory[index].weapon &&
                    appearance.IsLeftHand == inventory[index].leftHand && appearance.ModelNumber == expected[index],
                    "Weapon identity, hand and model number must agree with the recovered virtual selector.");
                Debug.Log("CARD_WEAPON " + family.unitDictionaryId + " index=" + index +
                    " prefab=" + appearance.WeaponPrefab.name + " left=" + appearance.IsLeftHand +
                    " level=" + appearance.ModelNumber + " resource=" + appearance.ResourcePath);
                VerifyGeometry(source, actor, set.Roots[index], appearance);
                reference.SwitchWeapon(index);
                set.ApplyVisibleMask(1u << index);
                VerifyVisibility(set, reference);
                _weapons++;
            }

            reference.SwitchWeapon(0);
            set.ApplyVisibleMask(1u);
            if (set.Roots.Count > 1)
            {
                reference.EnableSecondaryWeapon(1);
                set.ApplyVisibleMask(3u);
                VerifyVisibility(set, reference);
            }

            bool[] before = set.Roots.Select(root => root.activeSelf).ToArray();
            ExpectRejected(() => set.ApplyVisibleMask(1u << set.Roots.Count));
            Require(set.Roots.Select(root => root.activeSelf).SequenceEqual(before),
                "An invalid mask must not partly change weapon visibility.");
            Require(actor.Root.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
                actor.Root.GetComponentsInChildren<Collider>(true).Length == 0 &&
                actor.Root.GetComponentsInChildren<Rigidbody>(true).Length == 0,
                "Copied weapons must not introduce local gameplay, damage or physics writers.");
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(actor.Root);
            UnityEngine.Object.DestroyImmediate(referenceRoot);
        }
    }

    private static EnemyBasicInventory CreateReference(GameObject root,
        List<EnemyBasicInventory.InventoryWeapon> inventory)
    {
        EnemyBasicInventory reference = root.AddComponent<EnemyBasicInventory>();
        var weapons = new List<Weapon>();
        foreach (EnemyBasicInventory.InventoryWeapon entry in inventory)
        {
            Weapon weapon = UnityEngine.Object.Instantiate(entry.weapon);
            weapon.transform.SetParent(root.transform, false);
            weapons.Add(weapon);
        }

        typeof(EnemyBasicInventory).GetField("mWeaponInstancies", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(reference, weapons);
        typeof(EnemyBasicInventory).GetField("mSoldierParts", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(reference, root.AddComponent<SoldierParts>());
        return reference;
    }

    private static void VerifyGeometry(EnemyController source, SelfHostedInfantryVisual actor,
        GameObject copy, SelfHostedInfantryWeaponAppearance appearance)
    {
        SoldierParts parts = source.GetComponentInChildren<SoldierParts>(true);
        Transform socket = appearance.IsLeftHand ? parts.gunSnapPointNotScaledLeft : parts.gunSnapPointNotScaled;
        Require(copy.transform.parent == actor.ResolveSource(socket) && copy.transform.localPosition == Vector3.zero &&
            Mathf.Abs(Quaternion.Dot(copy.transform.localRotation,
                appearance.WeaponPrefab.transform.localRotation)) > .9999f &&
            copy.transform.localScale == Vector3.one,
            "Every weapon must retain the source hand, prefab rotation and reset attachment scale.");
        if (appearance.Model != null)
        {
            Mesh mesh = appearance.Model.GetComponent<MeshFilter>().sharedMesh;
            MeshFilter filter = copy.GetComponentsInChildren<MeshFilter>(true).Single(item => item.sharedMesh == mesh);
            Require(filter.GetComponent<MeshRenderer>().sharedMaterial ==
                appearance.Model.GetComponent<Renderer>().sharedMaterial &&
                filter.transform.localPosition == -appearance.Model.pivot.localPosition &&
                filter.transform.localScale == appearance.Scale,
                "Model replacement must preserve the source mesh, material, pivot and record scale.");
        }
        else
        {
            Require(copy.GetComponentsInChildren<MeshFilter>(true).Select(filter => filter.sharedMesh)
                .SequenceEqual(appearance.WeaponPrefab.GetComponentsInChildren<MeshFilter>(true)
                    .Select(filter => filter.sharedMesh)), "A non-leveled entry must retain its static source meshes.");
        }
    }

    private static void VerifyVisibility(SelfHostedInfantryWeaponSet actual, EnemyBasicInventory reference)
    {
        Require(actual.Roots.Select(root => root.activeSelf)
            .SequenceEqual(reference.weaponInstancies.Select(weapon => weapon.gameObject.activeSelf)),
            "Explicit masks must agree with source SwitchWeapon and EnableSecondaryWeapon visibility.");
    }

    private static void ExpectRejected(Action action)
    {
        try
        {
            action();
        }
        catch (ArgumentOutOfRangeException)
        {
            _checks++;
            return;
        }

        throw new Exception("An out-of-inventory weapon mask was accepted.");
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
