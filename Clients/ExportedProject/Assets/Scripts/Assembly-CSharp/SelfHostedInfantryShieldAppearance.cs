using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Copies the recovered inventory shield without activating its physics or gameplay components.</summary>
public static class SelfHostedInfantryShieldAppearance
{
    /// <summary>Uses the ordinary inventory shield and retains its own source materials.</summary>
    public static GameObject AttachOrdinary(SoldierBehaviour family, EnemyController source,
        SelfHostedInfantryVisual visual)
    {
        return Attach(GetInventory(family).shield, source, visual, null);
    }

    /// <summary>Uses the card inventory shield and shares the copied body material as ChangeShieldMat does.</summary>
    public static GameObject AttachCard(SoldierBehaviour family, EnemyController source,
        SelfHostedInfantryVisual visual)
    {
        if (visual == null || visual.Body == null)
        {
            throw new ArgumentException("A copied body material is required for card shield presentation.");
        }

        return Attach(GetInventory(family).cardShield, source, visual, visual.Body.sharedMaterial);
    }

    private static EnemyBasicInventory GetInventory(SoldierBehaviour family)
    {
        EnemyBasicInventory inventory = family == null ? null : family.GetComponent<EnemyBasicInventory>();
        if (inventory == null)
        {
            throw new ArgumentException("A recovered infantry inventory is required for shield selection.");
        }

        return inventory;
    }

    private static GameObject Attach(GameObject prefab, EnemyController source,
        SelfHostedInfantryVisual visual, Material bodyMaterial)
    {
        if (prefab == null)
        {
            return null;
        }

        FakeRigidBodySwapper swapper = prefab.GetComponent<FakeRigidBodySwapper>();
        SoldierParts parts = source == null ? null : source.GetComponentInChildren<SoldierParts>(true);
        if (swapper == null || parts == null || parts.shieldSnapPointNotScaled == null || visual == null ||
            visual.Root == null || visual.Root == source.gameObject ||
            visual.Root.GetComponentsInChildren<MonoBehaviour>(true).Length != 0)
        {
            throw new ArgumentException("A source shield and script-free copied infantry socket are required.");
        }

        GameObject root = new GameObject(prefab.name);
        root.SetActive(false);
        try
        {
            var copies = new Dictionary<Transform, Transform>();
            SelfHostedVisualHierarchy.CopyRoot(prefab.transform, root.transform, copies);
            foreach (KeyValuePair<Transform, Transform> copy in copies)
            {
                copy.Value.gameObject.layer = copy.Key.gameObject.layer;
            }

            AttachRoot(prefab.transform, root.transform, visual.ResolveSource(parts.shieldSnapPointNotScaled));
            ApplyHeldState(swapper, copies);
            if (bodyMaterial != null)
            {
                ApplyBodyMaterial(swapper, copies, bodyMaterial);
            }

            root.SetActive(true);
            return root;
        }
        catch
        {
            if (Application.isPlaying)
            {
                UnityEngine.Object.Destroy(root);
            }
            else
            {
                UnityEngine.Object.DestroyImmediate(root);
            }

            throw;
        }
    }

    private static void AttachRoot(Transform source, Transform copy, Transform socket)
    {
        // AttachShield keeps the instantiated prefab's world scale while parenting, then resets only position/rotation.
        copy.position = source.position;
        copy.rotation = source.rotation;
        copy.localScale = source.lossyScale;
        copy.SetParent(socket, true);
        copy.localPosition = Vector3.zero;
        copy.localRotation = Quaternion.identity;
    }

    private static void ApplyHeldState(FakeRigidBodySwapper source, Dictionary<Transform, Transform> copies)
    {
        Transform hand = copies[source.NoRigidBodyObject.transform];
        copies[source.RigidBodyObject.transform].gameObject.SetActive(false);
        hand.gameObject.SetActive(true);
        if (source.snapPoint != null)
        {
            Transform snap = copies[source.snapPoint.transform];
            snap.SetParent(hand, false);
            snap.localPosition = Vector3.zero;
            snap.localRotation = Quaternion.identity;
            snap.localScale = Vector3.one;
        }
    }

    private static void ApplyBodyMaterial(FakeRigidBodySwapper source, Dictionary<Transform, Transform> copies,
        Material material)
    {
        foreach (GameObject form in new[] { source.RigidBodyObject, source.NoRigidBodyObject })
        {
            MeshRenderer renderer = copies[form.transform].GetComponent<MeshRenderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial = material;
            }
        }
    }
}
