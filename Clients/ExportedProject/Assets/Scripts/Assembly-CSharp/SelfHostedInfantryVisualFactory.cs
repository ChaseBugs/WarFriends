using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Builds a recovered infantry appearance without activating local AI, collision or Photon components.
/// </summary>
public static class SelfHostedInfantryVisualFactory
{
    /// <summary>Applies recovered model replacement before a pose renderer captures its initial basis.</summary>
    public static SelfHostedInfantryVisual CreateWithAppearance(
        EnemyController source,
        SoldierMeshChanger.SoldierStyle style,
        SelfHostedInfantryWeaponAppearance appearance,
        string rootName)
    {
        if (appearance == null)
        {
            throw new ArgumentNullException("appearance");
        }

        var selected = new EnemyBasicInventory.InventoryWeapon
        {
            weapon = appearance.WeaponPrefab,
            leftHand = appearance.IsLeftHand
        };
        SelfHostedInfantryVisual visual = Create(source, style, selected, rootName);
        try
        {
            appearance.ApplyTo(visual.WeaponRoot);
            return visual;
        }
        catch
        {
            DestroyRoot(visual.Root);
            throw;
        }
    }

    /// <summary>
    /// Creates an inactive rig for an explicitly selected source style; it chooses no random appearance.
    /// </summary>
    public static SelfHostedInfantryVisual Create(EnemyController source,
        SoldierMeshChanger.SoldierStyle style, string rootName)
    {
        return Create(source, style, null, rootName);
    }

    /// <summary>Copies an explicitly selected inventory weapon without starting its gameplay components.</summary>
    public static SelfHostedInfantryVisual Create(
        EnemyController source,
        SoldierMeshChanger.SoldierStyle style,
        EnemyBasicInventory.InventoryWeapon selectedWeapon,
        string rootName)
    {
        ValidateSource(source, style, rootName);
        var root = new GameObject(rootName);
        root.SetActive(false);
        try
        {
            var rig = new GameObject("Rig");
            rig.transform.SetParent(root.transform, false);
            var copies = new Dictionary<Transform, Transform>();
            SelfHostedVisualHierarchy.CopyRoot(source.transform, rig.transform, copies);
            // SpawningManager.Spawn and SpawnAIObjectRPC reset the pooled source root scale.
            rig.transform.localScale = Vector3.one;
            Transform weaponRoot = null;
            if (selectedWeapon != null)
            {
                weaponRoot = CopyWeapon(source, selectedWeapon, copies);
            }
            SkinnedMeshRenderer body = CopyBody(source.meshChanger.skinnedMeshRenderer, style, copies);
            CopyHelmets(source.meshChanger.helmet, style, copies);
            Animation animation = source.GetComponentInChildren<Animation>(true);
            if (animation == null || !copies.ContainsKey(animation.transform))
            {
                throw new InvalidOperationException("Recovered infantry animation hierarchy is absent.");
            }

            return new SelfHostedInfantryVisual(root, copies[animation.transform].gameObject, body, weaponRoot);
        }
        catch
        {
            // A rejected style must not leave a partly constructed actor for a later snapshot to reuse.
            DestroyRoot(root);

            throw;
        }
    }

    private static Transform CopyWeapon(
        EnemyController source,
        EnemyBasicInventory.InventoryWeapon selectedWeapon,
        Dictionary<Transform, Transform> copies)
    {
        SoldierParts parts = source.GetComponentInChildren<SoldierParts>(true);
        if (parts == null || selectedWeapon.weapon == null)
        {
            throw new InvalidOperationException("A selected source weapon and infantry attachment are required.");
        }

        Transform attachment = selectedWeapon.leftHand ? parts.gunSnapPointNotScaledLeft : parts.gunSnapPointNotScaled;
        Transform destination;
        if (attachment == null || !copies.TryGetValue(attachment, out destination))
        {
            throw new InvalidOperationException("The selected weapon attachment is outside the copied source rig.");
        }

        Transform weapon = selectedWeapon.weapon.transform;
        var weaponRoot = new GameObject(weapon.name);
        weaponRoot.transform.SetParent(destination, false);
        SelfHostedVisualHierarchy.CopyRoot(weapon, weaponRoot.transform, new Dictionary<Transform, Transform>());
        // SoldierParts.AttachWeapons keeps prefab rotation but resets attachment translation and scale.
        weaponRoot.transform.localPosition = Vector3.zero;
        weaponRoot.transform.localRotation = weapon.localRotation;
        weaponRoot.transform.localScale = Vector3.one;
        return weaponRoot.transform;
    }

    private static void DestroyRoot(GameObject root)
    {
        if (Application.isPlaying)
        {
            UnityEngine.Object.Destroy(root);
        }
        else
        {
            UnityEngine.Object.DestroyImmediate(root);
        }
    }

    private static void ValidateSource(EnemyController source, SoldierMeshChanger.SoldierStyle style, string rootName)
    {
        if (source == null || source.meshChanger == null || style == null || string.IsNullOrEmpty(rootName))
        {
            throw new ArgumentException("A recovered enemy rig, selected style and visual name are required.");
        }

        style.LoadModel();
        SkinnedMeshRenderer skeleton = source.meshChanger.skinnedMeshRenderer;
        if (style.modelMeshRenderer == null || style.modelMeshRenderer.sharedMesh == null ||
            skeleton == null || skeleton.bones == null || skeleton.rootBone == null)
        {
            throw new InvalidOperationException("Recovered infantry mesh or skeleton is absent.");
        }
    }

    private static SkinnedMeshRenderer CopyBody(SkinnedMeshRenderer source,
        SoldierMeshChanger.SoldierStyle style, Dictionary<Transform, Transform> copies)
    {
        SkinnedMeshRenderer body = copies[source.transform].gameObject.AddComponent<SkinnedMeshRenderer>();
        // ChangeSkins retains the destination material and resolves the selected model's
        // bone order by name. Model-prefab materials and template bone order are not substitutes.
        body.sharedMaterials = source.sharedMaterials;
        SkinnedMeshTools.ChangeSkins(style.modelMeshRenderer, body);
        body.rootBone = copies[source.rootBone];
        body.localBounds = source.localBounds;
        body.updateWhenOffscreen = source.updateWhenOffscreen;
        return body;
    }

    private static void CopyHelmets(FakeRigidBodySwapper source, SoldierMeshChanger.SoldierStyle style,
        Dictionary<Transform, Transform> copies)
    {
        if (source == null)
        {
            return;
        }
        if (source.NoRigidBodyObject == null || source.RigidBodyObject == null)
        {
            throw new InvalidOperationException("Recovered infantry helmet hierarchy is absent.");
        }

        CopyHelmet(source.NoRigidBodyObject.transform, style, copies);
        CopyHelmet(source.RigidBodyObject.transform, style, copies);
        // FakeRigidBodySwapper.SetMesh resets to the attached form even when the selected mesh is null.
        copies[source.NoRigidBodyObject.transform].gameObject.SetActive(true);
        copies[source.RigidBodyObject.transform].gameObject.SetActive(false);
        copies[source.RigidBodyObject.transform].localScale = Vector3.one;
    }

    private static void CopyHelmet(Transform source, SoldierMeshChanger.SoldierStyle style,
        Dictionary<Transform, Transform> copies)
    {
        MeshFilter filter = copies[source].GetComponent<MeshFilter>();
        if (filter == null)
        {
            throw new InvalidOperationException("Recovered infantry helmet mesh is absent.");
        }

        filter.sharedMesh = style.helmetMesh;
        MeshRenderer renderer = copies[source].GetComponent<MeshRenderer>();
        if (renderer != null && style.helmetMaterials != null && style.helmetMaterials.Count > 0)
        {
            renderer.sharedMaterials = style.helmetMaterials.ToArray();
        }
    }
}
