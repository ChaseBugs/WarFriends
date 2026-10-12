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
            presenter.Configure(pool.enemy, manager, client);

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
            presenter.Apply(new List<BattleArmyEntityState>());
            Require(GameObject.Find("SelfHostedInfantry_" + Families.Length) == null,
                "removed infantry visual");
            Debug.Log("UNITY_INFANTRY_RENDER_PASSED families=" + Families.Length +
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
