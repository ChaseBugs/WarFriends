using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Checks normal/Elite inventories against source selectors and startup hand visibility.</summary>
public static class UnityOrdinaryInfantryWeaponsAudit
{
    private const int ExpectedFamilies = 16;
    private const int UpperUpgradeIndex = 39;
    private static int _checks;
    private static int _cases;
    private static int _weapons;

    /// <summary>Constructs every ordinary combat family's inventory at two levels in both source lanes.</summary>
    public static void Run()
    {
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Component[] components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            EnemyController source = components.OfType<ObjectPoolDatabase>().Single().enemy;
            SoldierBehaviour[] families = components.OfType<LevelBehaviourManager>().Single().levelBehaviours
                .Select(entry => entry.behaviour).OfType<SoldierBehaviour>()
                .Where(family => !(family is SoldierBehaviourBuddy) && family.soldierVisuals.Count > 0)
                .GroupBy(family => family.unitDictionaryId).Select(group => group.First()).ToArray();
            Require(families.Length == ExpectedFamilies, "Every ordinary source combat family must be inspected.");
            foreach (SoldierBehaviour family in families)
            {
                foreach (int level in new[] { 0, UpperUpgradeIndex })
                {
                    VerifyLane(source, family, new UpgradeSlots.UnitUpgrades(1f) { slotUpgradeindex = level });
                    VerifyLane(source, family, new UpgradeSlots.UnitUpgrades(1f)
                    {
                        slotUpgradeindex = level, isElite = true
                    });
                }
            }

            VerifyPresenter(components, families);
            VerifyMissingInventory(families[0]);

            Debug.Log("PASS: " + _checks + " ordinary inventory checks; " + _cases +
                " source cases and " + _weapons + " weapon copies.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void VerifyLane(EnemyController source, SoldierBehaviour family, UpgradeSlots.UnitUpgrades upgrades)
    {
        SelfHostedInfantryVisual actor = SelfHostedInfantryVisualFactory.Create(
            source, family.soldierVisuals[0], "OrdinaryWeaponAudit");
        try
        {
            IReadOnlyList<SelfHostedInfantryWeaponAppearance> appearances =
                SelfHostedInfantryWeaponAppearance.ResolveOrdinaryInventory(family, upgrades);
            List<EnemyBasicInventory.InventoryWeapon> inventory =
                family.GetComponent<EnemyBasicInventory>().weapons;
            int[] expected = (int[])typeof(SoldierBehaviour).GetMethod("GetWeaponLevels",
                BindingFlags.Instance | BindingFlags.NonPublic).Invoke(family, new object[] { upgrades });
            Require(appearances.Count == inventory.Count && appearances.Count <= expected.Length,
                "Ordinary inventory must preserve every source entry and its available level.");
            SelfHostedInfantryWeaponSet set = SelfHostedInfantryWeaponSet.CreateOrdinary(family, source, actor, upgrades);
            for (int index = 0; index < inventory.Count; index++)
            {
                SelfHostedInfantryWeaponAppearance appearance = appearances[index];
                Require(appearance.WeaponPrefab == inventory[index].weapon &&
                    appearance.IsLeftHand == inventory[index].leftHand && appearance.ModelNumber == expected[index],
                    "Every normal/Elite weapon must match the original inventory and virtual selector.");
                VerifyWeapon(source, actor, set.Roots[index], appearance);
                Require(set.Roots[index].activeSelf == (index == 0 || family is SoldierBehaviourCommando),
                    "Source Restart selects primary, while Commando also enables its second weapon.");
                _weapons++;
            }

            Require(actor.Root.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
                actor.Root.GetComponentsInChildren<Collider>(true).Length == 0 &&
                actor.Root.GetComponentsInChildren<Rigidbody>(true).Length == 0,
                "Ordinary weapon copies must not activate local gameplay or physics.");
            _cases++;
        }
        catch (Exception failure)
        {
            throw new InvalidOperationException("Ordinary source case failed: " + family.unitDictionaryId +
                "/level=" + upgrades.slotUpgradeindex + "/elite=" + upgrades.isElite, failure);
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(actor.Root);
        }
    }

    private static void VerifyWeapon(EnemyController source, SelfHostedInfantryVisual actor,
        GameObject copy, SelfHostedInfantryWeaponAppearance appearance)
    {
        SoldierParts parts = source.GetComponentInChildren<SoldierParts>(true);
        Transform socket = appearance.IsLeftHand ? parts.gunSnapPointNotScaledLeft : parts.gunSnapPointNotScaled;
        Require(copy.transform.parent == actor.ResolveSource(socket) &&
            copy.transform.localPosition == Vector3.zero && copy.transform.localScale == Vector3.one &&
            Mathf.Abs(Quaternion.Dot(copy.transform.localRotation,
                appearance.WeaponPrefab.transform.localRotation)) > 0.9999f,
            "The source hand, prefab rotation and reset attachment pose must be preserved.");
        if (appearance.Model != null)
        {
            Mesh mesh = appearance.Model.GetComponent<MeshFilter>().sharedMesh;
            Require(copy.GetComponentsInChildren<MeshFilter>(true).Any(filter => filter.sharedMesh == mesh &&
                filter.GetComponent<MeshRenderer>().sharedMaterial ==
                    appearance.Model.GetComponent<Renderer>().sharedMaterial &&
                filter.transform.localPosition == -appearance.Model.pivot.localPosition &&
                filter.transform.localScale == appearance.Scale),
                "The source model mesh, material, pivot and record scale must be preserved.");
        }
        else
        {
            Require(copy.GetComponentsInChildren<MeshFilter>(true).Select(filter => filter.sharedMesh)
                .SequenceEqual(appearance.WeaponPrefab.GetComponentsInChildren<MeshFilter>(true)
                    .Select(filter => filter.sharedMesh)), "Non-leveled weapons retain source static meshes.");
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

    private static void VerifyPresenter(Component[] components, SoldierBehaviour[] families)
    {
        GameObject owner = new GameObject("OrdinaryInventoryPresenterAudit");
        try
        {
            var players = new[]
            {
                new BattlePlayerView { PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", Fraction = 1 },
                new BattlePlayerView { PlayerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", Fraction = 2 }
            };
            foreach (BattlePlayerView player in players)
            {
                foreach (SoldierBehaviour family in families)
                {
                    player.Units.Add(new BattleUnitView
                    {
                        SourceId = family.upgradeSlots.GetSheetName(),
                        UpgradeIndex = player.Fraction == 1 ? 0 : UpperUpgradeIndex,
                        SpecialIndex = -1, EliteIndex = player.Fraction == 1 ? -1 : 0
                    });
                }
            }

            ObjectPoolDatabase pool = components.OfType<ObjectPoolDatabase>().Single();
            var client = owner.AddComponent<SelfHostedBattleClient>();
            var presenter = owner.AddComponent<SelfHostedInfantryPresenter>();
            presenter.Configure(pool.enemy, pool.parachute,
                components.OfType<LevelBehaviourManager>().Single(), client);
            presenter.BindPlayerAppearances(players);
            presenter.BindTeamAppearance(players[0].PlayerId,
                components.OfType<MatCapTextures>().Single().menuMatCapTexture);
            foreach (BattlePlayerView player in players)
            {
                foreach (SoldierBehaviour family in families)
                {
                    VerifyPresentedFamily(presenter, player, family, pool.enemy);
                }
            }
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(owner);
        }
    }

    private static void VerifyPresentedFamily(SelfHostedInfantryPresenter presenter,
        BattlePlayerView player, SoldierBehaviour family, EnemyController source)
    {
        var upgrades = new UpgradeSlots.UnitUpgrades(1f)
        {
            slotUpgradeindex = player.Fraction == 1 ? 0 : UpperUpgradeIndex, isElite = player.Fraction != 1
        };
        var row = new BattleArmyEntityState
        {
            EntityKey = (ulong)player.Fraction, OwnerPlayerId = player.PlayerId, OwnerFraction = player.Fraction,
            UnitId = family.unitDictionaryId, SpawnTick = 60, PositionTick = 60, MaxHealth = 100, Health = 100,
            InfantryClip = GetClip(family.unitDictionaryId), InfantryClipStartTick = 60, InfantryFacingZ = 1
        };
        presenter.Apply(new[] { row });
        GameObject actor = GameObject.Find("SelfHostedInfantry_" + row.EntityKey);
        SoldierParts parts = source.GetComponentInChildren<SoldierParts>(true);
        IReadOnlyList<SelfHostedInfantryWeaponAppearance> appearances =
            SelfHostedInfantryWeaponAppearance.ResolveOrdinaryInventory(family, upgrades);
        for (int index = 0; index < appearances.Count; index++)
        {
            SelfHostedInfantryWeaponAppearance appearance = appearances[index];
            Transform sourceSocket = appearance.IsLeftHand ?
                parts.gunSnapPointNotScaledLeft : parts.gunSnapPointNotScaled;
            string path = AnimationUtility.CalculateTransformPath(sourceSocket, source.transform);
            Transform socket = actor.transform.Find("Rig/" + path);
            Transform root = socket.Cast<Transform>().Single(child => child.name == appearance.WeaponPrefab.name);
            Require(root.gameObject.activeSelf == (index == 0 || family is SoldierBehaviourCommando),
                "Production ordinary actors must retain source startup visibility for each admitted owner.");
            Require(root.GetComponentsInChildren<MonoBehaviour>(true).Length == 0,
                "Production weapons must remain free of source controllers.");
        }

        Material bodyMaterial = actor.GetComponentInChildren<SkinnedMeshRenderer>(true).sharedMaterial;
        presenter.Apply(new BattleArmyEntityState[0]);
        Require(actor == null && bodyMaterial == null, "Ordinary actor removal must release rig and owned materials.");
    }

    private static string GetClip(string unitId)
    {
        switch (unitId)
        {
            case "ID_UNIT-SNIPER": return "sniper_idle";
            case "ID_UNIT-ROCKETSOLDIER": return "bazooka_idle";
            case "ID_UNIT-SHOTGUNNER": return "shotgunner_idle";
            case "ID_UNIT-SWAT": return "shield_idle";
            case "ID_UNIT-MINIGUNNER": return "minigun_idle";
            case "ID_UNIT-ENGINEER": return "engineer_idle";
            case "ID_UNIT-SCIFI": return "grenadelauncher_idle";
            case "ID_UNIT-FLAMETHROWER": return "flamethrower_idle";
            case "ID_UNIT-COMMANDO": return "SMG_idle";
            case "ID_UNIT-GUNSLINGER": return "colt_idle01";
            case "ID_UNIT-MORTAR": return "mortar_idle_standing";
            case "ID_UNIT-WARPER": return "shotgunner_idle";
            default: return "idle_1";
        }
    }

    private static void VerifyMissingInventory(SoldierBehaviour family)
    {
        EnemyBasicInventory inventory = family.GetComponent<EnemyBasicInventory>();
        List<EnemyBasicInventory.InventoryWeapon> original = inventory.weapons;
        try
        {
            inventory.weapons = new List<EnemyBasicInventory.InventoryWeapon>();
            try
            {
                SelfHostedInfantryWeaponAppearance.ResolveOrdinaryInventory(
                    family, new UpgradeSlots.UnitUpgrades(1f));
            }
            catch (InvalidOperationException)
            {
                _checks++;
                return;
            }

            throw new Exception("A missing combat inventory must fail instead of displaying a weapon-less substitute.");
        }
        finally
        {
            inventory.weapons = original;
        }
    }
}
