using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Owns ordered script-free weapon copies and applies an explicitly supplied visibility mask.</summary>
public sealed class SelfHostedInfantryWeaponSet
{
    private const int MaskWidth = 32;
    private readonly List<GameObject> _roots;
    private readonly uint _allowedMask;
    private readonly List<Dictionary<Transform, Transform>> _sourceTransforms;

    /// <summary>Gets the source-ordered weapon roots without exposing a mutable inventory list.</summary>
    public IReadOnlyList<GameObject> Roots { get; private set; }

    private SelfHostedInfantryWeaponSet(List<GameObject> roots,
        List<Dictionary<Transform, Transform>> sourceTransforms)
    {
        _roots = roots;
        _sourceTransforms = sourceTransforms;
        _allowedMask = roots.Count == MaskWidth ? uint.MaxValue : (1u << roots.Count) - 1u;
        Roots = roots.AsReadOnly();
    }

    /// <summary>Builds every source card weapon with an explicitly supplied initial visibility mask.</summary>
    public static SelfHostedInfantryWeaponSet CreateCard(SoldierBehaviour family, EnemyController source,
        SelfHostedInfantryVisual visual, uint visibleMask)
    {
        IReadOnlyList<SelfHostedInfantryWeaponAppearance> appearances =
            SelfHostedInfantryWeaponAppearance.ResolveCardInventory(family);
        return Create(source, visual, appearances, visibleMask);
    }

    /// <summary>Builds an already resolved ordinary inventory with its source startup visibility.</summary>
    public static SelfHostedInfantryWeaponSet CreateOrdinary(SoldierBehaviour family, EnemyController source,
        SelfHostedInfantryVisual visual, UpgradeSlots.UnitUpgrades upgrades)
    {
        IReadOnlyList<SelfHostedInfantryWeaponAppearance> appearances =
            SelfHostedInfantryWeaponAppearance.ResolveOrdinaryInventory(family, upgrades);
        uint initialMask = 1u;
        if (family is SoldierBehaviourCommando)
        {
            // Commando.Restart enables its left weapon after selecting the right weapon.
            initialMask = 3u;
        }

        return Create(source, visual, appearances, initialMask);
    }

    private static SelfHostedInfantryWeaponSet Create(EnemyController source, SelfHostedInfantryVisual visual,
        IReadOnlyList<SelfHostedInfantryWeaponAppearance> appearances, uint visibleMask)
    {
        if (source == null || visual == null || visual.Root == null || visual.Root == source.gameObject ||
            appearances.Count > MaskWidth || visual.Root.GetComponentsInChildren<MonoBehaviour>(true).Length != 0)
        {
            throw new ArgumentException("An ordered source inventory and script-free infantry rig are required.");
        }

        var roots = new List<GameObject>();
        var sourceTransforms = new List<Dictionary<Transform, Transform>>();
        try
        {
            SoldierParts parts = source.GetComponentInChildren<SoldierParts>(true);
            foreach (SelfHostedInfantryWeaponAppearance appearance in appearances)
            {
                var root = new GameObject(appearance.WeaponPrefab.name);
                root.SetActive(false);
                roots.Add(root);
                sourceTransforms.Add(CopyWeapon(parts, visual, appearance, root));
            }

            var result = new SelfHostedInfantryWeaponSet(roots, sourceTransforms);
            result.ApplyVisibleMask(visibleMask);
            return result;
        }
        catch
        {
            foreach (GameObject root in roots)
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

            throw;
        }
    }

    /// <summary>Changes copied visibility without firing or enabling a source weapon controller.</summary>
    public void ApplyVisibleMask(uint visibleMask)
    {
        if ((visibleMask & ~_allowedMask) != 0)
        {
            throw new ArgumentOutOfRangeException("visibleMask");
        }

        foreach (GameObject root in _roots)
        {
            if (root == null)
            {
                throw new InvalidOperationException("The copied infantry weapon set has been destroyed.");
            }
        }

        for (int index = 0; index < _roots.Count; index++)
        {
            _roots[index].SetActive((visibleMask & (1u << index)) != 0);
        }
    }

    /// <summary>Resolves original identities even after held-state restoration reparents the copied snap point.</summary>
    public Transform ResolveSource(int weaponIndex, Transform source)
    {
        Transform copy;
        if (weaponIndex < 0 || weaponIndex >= _sourceTransforms.Count || source == null ||
            !_sourceTransforms[weaponIndex].TryGetValue(source, out copy) || copy == null)
        {
            throw new InvalidOperationException("The source transform is absent from this copied weapon.");
        }
        return copy;
    }

    private static Dictionary<Transform, Transform> CopyWeapon(SoldierParts parts, SelfHostedInfantryVisual visual,
        SelfHostedInfantryWeaponAppearance appearance, GameObject root)
    {
        if (parts == null)
        {
            throw new InvalidOperationException("The recovered weapon sockets are absent.");
        }

        Transform socket = appearance.IsLeftHand ? parts.gunSnapPointNotScaledLeft : parts.gunSnapPointNotScaled;
        root.transform.SetParent(visual.ResolveSource(socket), false);
        var copies = new Dictionary<Transform, Transform>();
        SelfHostedVisualHierarchy.CopyRoot(appearance.WeaponPrefab.transform, root.transform, copies);
        foreach (KeyValuePair<Transform, Transform> copy in copies)
        {
            copy.Value.gameObject.layer = copy.Key.gameObject.layer;
        }

        root.transform.localPosition = Vector3.zero;
        root.transform.localRotation = appearance.WeaponPrefab.transform.localRotation;
        root.transform.localScale = Vector3.one;
        RestoreHeldState(appearance.WeaponPrefab, copies);
        appearance.ApplyTo(root.transform, copies);
        return copies;
    }

    private static void RestoreHeldState(Weapon prefab, Dictionary<Transform, Transform> copies)
    {
        FakeRigidBodySwapper[] swappers = prefab.GetComponentsInChildren<FakeRigidBodySwapper>(true);
        if (swappers.Length == 0)
        {
            throw new InvalidOperationException("The source weapon swapper is absent.");
        }

        // AttachWeapons resets the first swapper for each inventory entry before selecting active weapons.
        FakeRigidBodySwapper source = swappers[0];
        Transform hand = copies[source.NoRigidBodyObject.transform];
        Transform rigid = copies[source.RigidBodyObject.transform];
        hand.gameObject.SetActive(true);
        rigid.gameObject.SetActive(false);
        rigid.localScale = Vector3.one;
        if (source.snapPoint != null)
        {
            Transform snap = copies[source.snapPoint.transform];
            snap.SetParent(hand, false);
            snap.localPosition = Vector3.zero;
            snap.localRotation = Quaternion.identity;
            snap.localScale = Vector3.one;
        }
    }
}
