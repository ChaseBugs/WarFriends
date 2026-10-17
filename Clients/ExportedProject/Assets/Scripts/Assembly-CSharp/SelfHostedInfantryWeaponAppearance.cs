using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Resolves recovered weapon appearance without starting inventory, sound or Photon services.</summary>
public sealed class SelfHostedInfantryWeaponAppearance
{
    private const int WeaponVisualIndex = 2;
    private const int PrimaryWeaponIndex = 0;

    /// <summary>Gets the recovered inventory weapon used for hierarchy attachment.</summary>
    public Weapon WeaponPrefab { get; private set; }

    /// <summary>Gets whether the recovered inventory entry selects the left attachment.</summary>
    public bool IsLeftHand { get; private set; }

    /// <summary>Gets the exact visual-table model number, rather than the combat upgrade index.</summary>
    public int ModelNumber { get; private set; }

    /// <summary>Gets the source resource path derived by EnemyLeveledWeapon.PrepareAsync.</summary>
    public string ResourcePath { get; private set; }

    /// <summary>Gets the source model whose mesh, material and pivot define the visible weapon.</summary>
    public GameWeaponModel Model { get; private set; }

    /// <summary>Gets the source record scale applied after model replacement.</summary>
    public Vector3 Scale { get; private set; }

    private SelfHostedInfantryWeaponAppearance()
    {
    }

    /// <summary>Resolves the normal or Elite weapon through the recovered upgrade visual selector.</summary>
    public static SelfHostedInfantryWeaponAppearance ResolveOrdinary(
        SoldierBehaviourAssaulter family, UpgradeSlots.UnitUpgrades upgrades)
    {
        ValidateFamily(family);
        if (upgrades.slotUpgradeindex < 0)
        {
            throw new ArgumentOutOfRangeException("upgrades");
        }

        return Resolve(family.GetComponent<EnemyBasicInventory>().weapons, family.upgradeSlots.GetVisuals(upgrades));
    }

    /// <summary>Resolves card appearance from its fixed source lane, independent of card combat scaling.</summary>
    public static SelfHostedInfantryWeaponAppearance ResolveCard(SoldierBehaviourAssaulter family)
    {
        ValidateFamily(family);
        return Resolve(family.GetComponent<EnemyBasicInventory>().cardWeapons, family.upgradeSlots.cardVisuals);
    }

    /// <summary>Applies the recovered model replacement to a script-free copy of this weapon hierarchy.</summary>
    public void ApplyTo(Transform copiedWeapon)
    {
        EnemyLeveledWeapon leveled = WeaponPrefab.GetComponent<EnemyLeveledWeapon>();
        if (copiedWeapon == null || copiedWeapon == WeaponPrefab.transform ||
            copiedWeapon.name != WeaponPrefab.name || leveled.weaponRenderer == null ||
            copiedWeapon.GetComponentsInChildren<MonoBehaviour>(true).Length != 0)
        {
            throw new ArgumentException("A matching copied source weapon hierarchy is required.");
        }

        Transform target = ResolveCopy(WeaponPrefab.transform, leveled.weaponRenderer.transform, copiedWeapon);
        MeshFilter filter = target.GetComponent<MeshFilter>();
        MeshRenderer renderer = target.GetComponent<MeshRenderer>();
        if (filter == null || renderer == null || Model == null || Model.pivot == null)
        {
            throw new InvalidOperationException("The copied weapon model renderer is incomplete.");
        }

        // SetLevel changes these channels after attachment; it does not replace the weapon's gameplay identity.
        filter.sharedMesh = Model.GetComponent<MeshFilter>().sharedMesh;
        renderer.sharedMaterial = Model.GetComponent<Renderer>().sharedMaterial;
        renderer.useLightProbes = true;
        target.localPosition = -Model.pivot.localPosition;
        target.localScale = Scale;
    }

    private static Transform ResolveCopy(Transform sourceRoot, Transform sourceTarget, Transform copiedRoot)
    {
        var indexes = new Stack<int>();
        Transform current = sourceTarget;
        while (current != sourceRoot)
        {
            if (current == null)
            {
                throw new InvalidOperationException("The model renderer is outside its source weapon.");
            }

            indexes.Push(current.GetSiblingIndex());
            current = current.parent;
        }

        Transform source = sourceRoot;
        Transform copy = copiedRoot;
        while (indexes.Count > 0)
        {
            int index = indexes.Pop();
            if (copy.childCount != source.childCount || index >= copy.childCount)
            {
                throw new InvalidOperationException("The copied weapon renderer path is incomplete.");
            }

            source = source.GetChild(index);
            copy = copy.GetChild(index);
            if (source.name != copy.name)
            {
                throw new InvalidOperationException("The copied weapon renderer identity differs from its source.");
            }
        }

        return copy;
    }

    private static void ValidateFamily(SoldierBehaviourAssaulter family)
    {
        if (family == null || family.upgradeSlots == null || family.GetComponent<EnemyBasicInventory>() == null)
        {
            throw new ArgumentException("A recovered Assaulter family, inventory and upgrade visuals are required.");
        }
    }

    private static SelfHostedInfantryWeaponAppearance Resolve(
        List<EnemyBasicInventory.InventoryWeapon> inventory, List<TechnologyVisualDefinition> visuals)
    {
        if (inventory == null || inventory.Count != 1 || inventory[PrimaryWeaponIndex] == null ||
            inventory[PrimaryWeaponIndex].weapon == null || visuals == null ||
            visuals.Count <= WeaponVisualIndex || visuals[WeaponVisualIndex] == null)
        {
            throw new InvalidOperationException("The supported Assaulter appearance requires one source weapon.");
        }

        EnemyBasicInventory.InventoryWeapon selected = inventory[PrimaryWeaponIndex];
        int modelNumber = visuals[WeaponVisualIndex].weaponNumber;
        EnemyLeveledWeapon leveled = selected.weapon.GetComponent<EnemyLeveledWeapon>();
        if (leveled == null || leveled.weaponRecords == null)
        {
            throw new InvalidOperationException("The source weapon model records are missing.");
        }

        foreach (EnemyLeveledWeapon.WeaponModelRecord record in leveled.weaponRecords)
        {
            if (record != null && record.level == modelNumber)
            {
                return Load(selected, record);
            }
        }

        throw new InvalidOperationException("The selected weapon model number has no recovered source record.");
    }

    private static SelfHostedInfantryWeaponAppearance Load(
        EnemyBasicInventory.InventoryWeapon selected, EnemyLeveledWeapon.WeaponModelRecord record)
    {
        string[] segments = record.weaponModelPath == null ? new string[0] : record.weaponModelPath.Split('/');
        if (segments.Length < 2 || string.IsNullOrEmpty(segments[1]) || string.IsNullOrEmpty(record.assetBundleName))
        {
            throw new InvalidOperationException("The source weapon resource identity is incomplete.");
        }

        // Preserve PrepareAsync's exact path rule; the last path segment is not necessarily its asset name.
        string resourcePath = "Weapons/" + record.assetBundleName + "/" + segments[1];
        GameObject prefab = Resources.Load<GameObject>(resourcePath);
        GameWeaponModel model = prefab == null ? null : prefab.GetComponent<GameWeaponModel>();
        if (model == null || model.pivot == null || model.GetComponent<MeshFilter>() == null ||
            model.GetComponent<MeshFilter>().sharedMesh == null || model.GetComponent<Renderer>() == null ||
            model.GetComponent<Renderer>().sharedMaterial == null)
        {
            throw new InvalidOperationException("The selected recovered weapon model is unavailable: " + resourcePath);
        }

        return new SelfHostedInfantryWeaponAppearance
        {
            WeaponPrefab = selected.weapon,
            IsLeftHand = selected.leftHand,
            ModelNumber = record.level,
            ResourcePath = resourcePath,
            Model = model,
            Scale = record.scale
        };
    }
}
