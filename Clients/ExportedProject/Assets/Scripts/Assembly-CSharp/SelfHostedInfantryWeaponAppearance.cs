using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Resolves recovered weapon appearance without starting inventory, sound or Photon services.</summary>
public sealed class SelfHostedInfantryWeaponAppearance
{
    private const int WeaponVisualIndex = 2;
    private const int PrimaryWeaponIndex = 0;

    /// <summary>Gets the recovered family identity that owns this appearance selection.</summary>
    public string UnitId { get; private set; }

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

        return ResolveForFamily(family, family.GetComponent<EnemyBasicInventory>().weapons,
            family.upgradeSlots.GetVisuals(upgrades));
    }

    /// <summary>Resolves the ordinary Gunslinger weapon through its recovered visual upgrade lane.</summary>
    public static SelfHostedInfantryWeaponAppearance ResolveOrdinary(
        SoldierBehaviourGunslinger family, UpgradeSlots.UnitUpgrades upgrades)
    {
        ValidateFamily(family);
        if (family.unitDictionaryId != "ID_UNIT-GUNSLINGER" || upgrades.slotUpgradeindex < 0)
        {
            throw new ArgumentException("A recovered Gunslinger family and nonnegative visual level are required.");
        }

        return ResolveForFamily(family, family.GetComponent<EnemyBasicInventory>().weapons,
            family.upgradeSlots.GetVisuals(upgrades));
    }

    /// <summary>Resolves the source-constant Gunslinger model without inventing an untransmitted upgrade level.</summary>
    public static SelfHostedInfantryWeaponAppearance ResolveGunslinger(SoldierBehaviourGunslinger family)
    {
        ValidateFamily(family);
        UpgradeSlotsGunslicer slots = family.upgradeSlots as UpgradeSlotsGunslicer;
        if (slots == null || slots.visualsWeapon == null || slots.eliteVisualsWeapon == null ||
            slots.visualsWeapon.Count != 1 || slots.eliteVisualsWeapon.Count != 1)
        {
            throw new InvalidOperationException("Gunslinger presentation requires the recovered constant weapon lanes.");
        }

        TechnologyVisualDefinition normal = slots.visualsWeapon[0];
        TechnologyVisualDefinition elite = slots.eliteVisualsWeapon[0];
        if (normal == null || elite == null || normal.level != 0 || elite.level != 0 ||
            normal.weaponNumber != elite.weaponNumber)
        {
            throw new InvalidOperationException("Variable Gunslinger weapon visuals require explicit upgrade authority.");
        }

        return ResolveOrdinary(family, new UpgradeSlots.UnitUpgrades { slotUpgradeindex = 0 });
    }

    /// <summary>Resolves card appearance from its fixed source lane, independent of card combat scaling.</summary>
    public static SelfHostedInfantryWeaponAppearance ResolveCard(SoldierBehaviourAssaulter family)
    {
        ValidateFamily(family);
        return ResolveForFamily(family, family.GetComponent<EnemyBasicInventory>().cardWeapons,
            family.upgradeSlots.cardVisuals);
    }

    /// <summary>Resolves every card inventory entry in source order, including non-leveled weapon geometry.</summary>
    public static IReadOnlyList<SelfHostedInfantryWeaponAppearance> ResolveCardInventory(SoldierBehaviour family)
    {
        ValidateFamily(family);
        List<EnemyBasicInventory.InventoryWeapon> inventory = family.GetComponent<EnemyBasicInventory>().cardWeapons;
        List<TechnologyVisualDefinition> visuals = family.upgradeSlots.cardVisuals;
        if (inventory == null || inventory.Count == 0 || visuals == null ||
            visuals.Count <= WeaponVisualIndex || visuals[WeaponVisualIndex] == null)
        {
            throw new InvalidOperationException("A complete recovered card inventory and weapon lane are required.");
        }

        int number = visuals[WeaponVisualIndex].weaponNumber;
        int[] levels = GetCardLevels(family, number);
        if (inventory.Count != levels.Length)
        {
            throw new InvalidOperationException("Card inventory order must match the recovered weapon-level selector.");
        }

        var result = new List<SelfHostedInfantryWeaponAppearance>();
        for (int index = 0; index < inventory.Count; index++)
        {
            result.Add(ResolveEntry(family, inventory[index], levels[index]));
        }

        return result.AsReadOnly();
    }

    private static SelfHostedInfantryWeaponAppearance ResolveEntry(SoldierBehaviour family,
        EnemyBasicInventory.InventoryWeapon entry, int level)
    {
        if (entry == null || entry.weapon == null)
        {
            throw new InvalidOperationException("The recovered inventory weapon identity is absent.");
        }

        EnemyLeveledWeapon leveled = entry.weapon.GetComponent<EnemyLeveledWeapon>();
        SelfHostedInfantryWeaponAppearance appearance;
        if (leveled == null)
        {
            // SetWeaponsUpgrade skips entries without a root EnemyLeveledWeapon component.
            appearance = new SelfHostedInfantryWeaponAppearance
            {
                WeaponPrefab = entry.weapon, IsLeftHand = entry.leftHand, ModelNumber = level,
                ResourcePath = string.Empty, Scale = Vector3.one
            };
        }
        else
        {
            EnemyLeveledWeapon.WeaponModelRecord record = leveled.weaponRecords == null ? null :
                leveled.weaponRecords.Find(item => item != null && item.level == level);
            if (record == null)
            {
                throw new InvalidOperationException("The card weapon model number has no recovered record.");
            }

            appearance = Load(entry, record);
        }

        appearance.UnitId = family.unitDictionaryId;
        return appearance;
    }

    private static int[] GetCardLevels(SoldierBehaviour family, int number)
    {
        if (family is SoldierBehaviourGrennader)
        {
            return new[] { 0, number };
        }

        if (family is SoldierBehaviourCommando)
        {
            return new[] { number, number };
        }

        return new[] { number };
    }

    /// <summary>Applies the recovered model replacement to a script-free copy of this weapon hierarchy.</summary>
    public void ApplyTo(Transform copiedWeapon)
    {
        EnemyLeveledWeapon leveled = ValidateCopy(copiedWeapon);
        if (leveled == null)
        {
            return;
        }

        Transform target = SelfHostedVisualHierarchy.ResolveCopy(WeaponPrefab.transform,
            leveled.weaponRenderer.transform, copiedWeapon);
        ApplyModel(target);
    }

    /// <summary>Applies SetLevel after swapper reset using identities captured before hierarchy changes.</summary>
    public void ApplyTo(Transform copiedWeapon, Dictionary<Transform, Transform> copies)
    {
        EnemyLeveledWeapon leveled = ValidateCopy(copiedWeapon);
        if (leveled == null)
        {
            return;
        }

        Transform target;
        if (copies == null || !copies.TryGetValue(leveled.weaponRenderer.transform, out target) ||
            target == null || !target.IsChildOf(copiedWeapon))
        {
            throw new ArgumentException("The copied model renderer identity is absent.");
        }

        ApplyModel(target);
    }

    private EnemyLeveledWeapon ValidateCopy(Transform copiedWeapon)
    {
        EnemyLeveledWeapon leveled = WeaponPrefab.GetComponent<EnemyLeveledWeapon>();
        if (copiedWeapon == null || copiedWeapon == WeaponPrefab.transform ||
            copiedWeapon.name != WeaponPrefab.name ||
            copiedWeapon.GetComponentsInChildren<MonoBehaviour>(true).Length != 0)
        {
            throw new ArgumentException("A matching copied source weapon hierarchy is required.");
        }

        if (leveled == null && Model == null)
        {
            return null;
        }

        if (leveled == null || leveled.weaponRenderer == null || Model == null || Model.pivot == null)
        {
            throw new InvalidOperationException("The selected source weapon replacement is incomplete.");
        }

        return leveled;
    }

    private void ApplyModel(Transform target)
    {
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

    private static void ValidateFamily(SoldierBehaviour family)
    {
        if (family == null || family.upgradeSlots == null || family.GetComponent<EnemyBasicInventory>() == null)
        {
            throw new ArgumentException("A recovered infantry family, inventory and upgrade visuals are required.");
        }
    }

    private static SelfHostedInfantryWeaponAppearance ResolveForFamily(SoldierBehaviour family,
        List<EnemyBasicInventory.InventoryWeapon> inventory, List<TechnologyVisualDefinition> visuals)
    {
        SelfHostedInfantryWeaponAppearance appearance = Resolve(inventory, visuals);
        appearance.UnitId = family.unitDictionaryId;
        return appearance;
    }

    private static SelfHostedInfantryWeaponAppearance Resolve(
        List<EnemyBasicInventory.InventoryWeapon> inventory, List<TechnologyVisualDefinition> visuals)
    {
        if (inventory == null || inventory.Count != 1 || inventory[PrimaryWeaponIndex] == null ||
            inventory[PrimaryWeaponIndex].weapon == null || visuals == null ||
            visuals.Count <= WeaponVisualIndex || visuals[WeaponVisualIndex] == null)
        {
            throw new InvalidOperationException("The supported infantry appearance requires one source weapon.");
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
