using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

public static class SelfHostedInfantryRenderAudit
{
    private static readonly KeyValuePair<string, string>[] Families =
    {
        Pair("ID_UNIT-ASSAULT", "idle_1"),
        Pair("ID_UNIT-SNIPER", "sniper_idle"),
        Pair("ID_UNIT-ROCKETSOLDIER", "bazooka_idle"),
        Pair("ID_UNIT-SHOTGUNNER", "shotgunner_idle"),
        Pair("ID_UNIT-GRENADIER", "idle_1"),
        Pair("ID_UNIT-PARATROOPER", "idle_1"),
        Pair("ID_UNIT-SWAT", "shield_idle"),
        Pair("ID_UNIT-MINIGUNNER", "minigun_idle"),
        Pair("ID_UNIT-ENGINEER", "engineer_idle"),
        Pair("ID_UNIT-MACHINEGUNNER", "idle_1"),
        Pair("ID_UNIT-SCIFI", "grenadelauncher_idle"),
        Pair("ID_UNIT-FLAMETHROWER", "flamethrower_idle"),
        Pair("ID_UNIT-COMMANDO", "SMG_idle"),
        Pair("ID_UNIT-GUNSLINGER", "colt_idle01"),
        Pair("ID_UNIT-MORTAR", "mortar_idle_standing"),
        Pair("ID_UNIT-WARPER", "shotgunner_idle")
    };

    public static void Run()
    {
        var previous = EditorSceneManager.GetSceneManagerSetup();
        GameObject owner = null;
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            var roots = scene.GetRootGameObjects();
            var pool = roots.SelectMany(root =>
                root.GetComponentsInChildren<ObjectPoolDatabase>(true)).Single();
            var manager = roots.SelectMany(root =>
                root.GetComponentsInChildren<LevelBehaviourManager>(true)).Single();
            Require(pool.enemy != null, "recovered enemy prefab");

            owner = new GameObject("SelfHostedInfantryRenderAudit");
            var client = owner.AddComponent<SelfHostedBattleClient>();
            var presenter = owner.AddComponent<SelfHostedInfantryPresenter>();
            presenter.Configure(pool.enemy, pool.parachute, manager, client);

            for (int index = 0; index < Families.Length; index++)
            {
                ulong entityKey = (ulong)(index + 1);
                var family = Families[index];
                var row = new BattleArmyEntityState
                {
                    EntityKey = entityKey,
                    UnitId = family.Key,
                    X = 2, Y = 0, Z = 3,
                    SpawnTick = 60, PositionTick = 60,
                    MaxHealth = 100, Health = 100,
                    InfantryClip = family.Value,
                    InfantryClipStartTick = 60,
                    InfantryFacingZ = 1
                };
                presenter.Apply(new List<BattleArmyEntityState> { row });
                var visual = GameObject.Find("SelfHostedInfantry_" + entityKey);
                Require(visual != null, "created infantry " + family.Key);
                var skin = visual.GetComponentInChildren<SkinnedMeshRenderer>(true);
                Require(skin != null && skin.sharedMesh != null &&
                    skin.bones.Length > 0 && skin.bones.All(bone => bone != null),
                    "source skin and bones " + family.Key);
                Require(visual.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
                    visual.GetComponentsInChildren<Collider>(true).Length == 0 &&
                    visual.GetComponentsInChildren<Rigidbody>(true).Length == 0,
                    "script-free infantry " + family.Key);
                row.X = 6;
                row.PositionTick = 66;
                presenter.Apply(new List<BattleArmyEntityState> { row });
                presenter.RenderAt(Time.realtimeSinceStartup + 1.4f, .016f);
                Require(Mathf.Abs(visual.transform.position.x - 6f) < .01f,
                    "authoritative infantry motion " + family.Key);
            }
            var cardRow = new BattleArmyEntityState
            {
                EntityKey = 100,
                UnitId = "ID_UNIT-MINIGUNNER",
                SourceCardId = "ELITEMINIGUN",
                X = 1, SpawnTick = 60, PositionTick = 60,
                MaxHealth = 100, Health = 100,
                InfantryClip = "minigun_run",
                InfantryClipStartTick = 60,
                InfantryFacingZ = 1
            };
            presenter.Apply(new List<BattleArmyEntityState> { cardRow });
            var cardVisual = GameObject.Find("SelfHostedInfantry_100");
            var cardStyle = manager.levelBehaviours.Select(entry =>
                    entry.behaviour as SoldierBehaviour)
                .First(soldier => soldier != null &&
                    soldier.unitDictionaryId == "ID_UNIT-MINIGUNNER")
                .cardSoldierVisuals.Single();
            cardStyle.LoadModel();
            Require(cardVisual != null &&
                cardVisual.GetComponentInChildren<SkinnedMeshRenderer>(true)
                    .sharedMesh == cardStyle.modelMeshRenderer.sharedMesh,
                "card Minigunner uses its recovered elite mesh");
            var swatCardRow = new BattleArmyEntityState
            {
                EntityKey = 101,
                UnitId = "ID_UNIT-SWAT",
                SourceCardId = "ELITESWAT",
                X = 2, SpawnTick = 60, PositionTick = 60,
                MaxHealth = 100, Health = 100,
                InfantryClip = "shield_run",
                InfantryClipStartTick = 60,
                InfantryFacingZ = 1
            };
            presenter.Apply(new List<BattleArmyEntityState> { cardRow, swatCardRow });
            var swatCardVisual = GameObject.Find("SelfHostedInfantry_101");
            var swatCardStyle = manager.levelBehaviours.Select(entry =>
                    entry.behaviour as SoldierBehaviour)
                .First(soldier => soldier != null &&
                    soldier.unitDictionaryId == "ID_UNIT-SWAT")
                .cardSoldierVisuals.Single();
            swatCardStyle.LoadModel();
            Require(swatCardVisual != null &&
                swatCardVisual.GetComponentInChildren<SkinnedMeshRenderer>(true)
                    .sharedMesh == swatCardStyle.modelMeshRenderer.sharedMesh,
                "card SWAT uses its recovered elite mesh");
            var sniperCardRow = new BattleArmyEntityState
            {
                EntityKey = 102,
                UnitId = "ID_UNIT-SNIPER",
                SourceCardId = "ELITESNIPER",
                X = 3, SpawnTick = 60, PositionTick = 60,
                MaxHealth = 100, Health = 100,
                InfantryClip = "player_look_right_sniper",
                InfantryClipStartTick = 60,
                InfantryFacingZ = 1
            };
            presenter.Apply(new List<BattleArmyEntityState>
                { cardRow, swatCardRow, sniperCardRow });
            var sniperCardVisual = GameObject.Find("SelfHostedInfantry_102");
            var sniperCardStyle = manager.levelBehaviours.Select(entry =>
                    entry.behaviour as SoldierBehaviour)
                .First(soldier => soldier != null &&
                    soldier.unitDictionaryId == "ID_UNIT-SNIPER")
                .cardSoldierVisuals.Single();
            sniperCardStyle.LoadModel();
            Require(sniperCardVisual != null &&
                sniperCardVisual.GetComponentInChildren<SkinnedMeshRenderer>(true)
                    .sharedMesh == sniperCardStyle.modelMeshRenderer.sharedMesh,
                "card Sniper uses its recovered elite mesh and cover clip");
            var parachuteRow = new BattleArmyEntityState
            {
                EntityKey = 103,
                UnitId = "ID_UNIT-PARATROOPER",
                SourceCardId = "ELITEPARA",
                X = 4, Y = 12, SpawnTick = 60, PositionTick = 60,
                MaxHealth = 100, Health = 100,
                InfantryClip = "idle_1",
                InfantryClipStartTick = 60,
                InfantryFacingZ = 1,
                ParachuteActive = true,
                ParachuteRotation = new BattleJointRotation
                    { Y = .7071068f, W = .7071068f }
            };
            presenter.Apply(new List<BattleArmyEntityState>
                { cardRow, swatCardRow, sniperCardRow, parachuteRow });
            var parachuteVisual = GameObject.Find("SelfHostedInfantry_103");
            var canopy = parachuteVisual == null ? null :
                parachuteVisual.transform.Find("ParachuteCanopy");
            var sourceCanopy = pool.parachute.parashuteRenderer;
            var paratrooperStyle = manager.levelBehaviours.Select(entry =>
                    entry.behaviour as SoldierBehaviour)
                .First(soldier => soldier != null &&
                    soldier.unitDictionaryId == "ID_UNIT-PARATROOPER")
                .cardSoldierVisuals.Single();
            paratrooperStyle.LoadModel();
            Require(canopy != null &&
                canopy.GetComponentInChildren<MeshFilter>(true).sharedMesh ==
                    sourceCanopy.GetComponent<MeshFilter>().sharedMesh &&
                parachuteVisual.GetComponentInChildren<SkinnedMeshRenderer>(true)
                    .sharedMesh == paratrooperStyle.modelMeshRenderer.sharedMesh &&
                Mathf.Abs(canopy.rotation.y - .7071068f) < .0001f &&
                canopy.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
                canopy.GetComponentsInChildren<Collider>(true).Length == 0 &&
                canopy.GetComponentsInChildren<Rigidbody>(true).Length == 0,
                "airborne card Paratrooper uses the source canopy without gameplay components");
            parachuteRow.ParachuteActive = false;
            parachuteRow.ParachuteLandingTick = 61;
            parachuteRow.ParachuteLandingX = 4;
            parachuteRow.ParachuteLandingY = 2;
            parachuteRow.ParachuteLandingZ = 3;
            parachuteRow.InfantryClip = "run_0";
            parachuteRow.InfantryClipStartTick = 61;
            parachuteRow.PositionTick = 61;
            presenter.Apply(new List<BattleArmyEntityState>
                { cardRow, swatCardRow, sniperCardRow, parachuteRow });
            Require(canopy != null && canopy.parent == null &&
                Vector3.Distance(canopy.position, new Vector3(4, 2, 3)) < .001f &&
                canopy.GetComponentInChildren<MeshRenderer>(true)
                    .sharedMaterial.shader.name ==
                    "Legacy Shaders/Transparent/DiffuseNew" &&
                parachuteVisual != null &&
                parachuteVisual.transform.Find("ParachuteCanopy") == null,
                "landed canopy stays at its host impact position while soldier walks");
            presenter.RenderAt(Time.realtimeSinceStartup + 3.1f, .016f);
            Require(canopy == null && parachuteVisual != null,
                "landed canopy expires after the source three-second lifetime");
            parachuteRow.ParachuteLandingTick = 0;
            parachuteRow.ParachuteLandingX = 0;
            parachuteRow.ParachuteLandingY = 0;
            parachuteRow.ParachuteLandingZ = 0;
            parachuteRow.ParachuteRotation = null;
            presenter.Apply(new List<BattleArmyEntityState>());
            Require(GameObject.Find("SelfHostedInfantry_100") == null,
                "removed infantry visual");
            Require(GameObject.Find("SelfHostedInfantry_101") == null,
                "removed SWAT card visual");
            Require(GameObject.Find("SelfHostedInfantry_102") == null,
                "removed Sniper card visual");
            Require(GameObject.Find("SelfHostedInfantry_103") == null,
                "removed Paratrooper card visual");
            Debug.Log("UNITY_INFANTRY_RENDER_PASSED families=" + Families.Length +
                " cardMinigunner=True cardSwat=True cardSniper=True cardParatrooper=True" +
                " skin=True scriptFree=True hostMotion=True removal=True");
            EditorApplication.Exit(0);
        }
        catch (Exception exception)
        {
            Debug.LogError(exception);
            EditorApplication.Exit(1);
        }
        finally
        {
            if (owner != null) UnityEngine.Object.DestroyImmediate(owner);
            EditorSceneManager.RestoreSceneManagerSetup(previous);
        }
    }

    private static KeyValuePair<string, string> Pair(string unitId, string clip)
    {
        return new KeyValuePair<string, string>(unitId, clip);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }
}
