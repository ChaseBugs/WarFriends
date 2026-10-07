using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

public static class SelfHostedAssaultHelicopterRenderAudit
{
    public static void Run()
    {
        var previousScenes = EditorSceneManager.GetSceneManagerSetup();
        GameObject owner = null;
        try
        {
            EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/GameObject/assaultHelicopter.prefab");
            var source = prefab == null ? null : prefab.GetComponent<AssaultHelicopter>();
            Require(source != null && source.glass != null && source.glass.Count == 3,
                "recovered Assault Helicopter and three glass parts");

            owner = new GameObject("SelfHostedAssaultHelicopterRenderAudit");
            var presenter = owner.AddComponent<SelfHostedAssaultHelicopterPresenter>();
            presenter.Configure(source);
            var rotation = Quaternion.Euler(9f, 31f, -4f);
            var row = new BattleArmyEntityState
            {
                EntityKey = 4294967297,
                UnitId = "ID_UNIT-ASSAULTHELI",
                X = 2f, Y = 3f, Z = 4f,
                PositionTick = 60,
                AssaultRotation = new BattleJointRotation
                {
                    X = rotation.x, Y = rotation.y, Z = rotation.z, W = rotation.w
                },
                AssaultGlassMaxHealth = 72.33f,
                AssaultGlassHealth = 72.33f
            };
            presenter.Apply(new List<BattleArmyEntityState> { row });
            var visual = GameObject.Find("SelfHostedAssaultHelicopter_4294967297");
            Require(visual != null &&
                Vector3.Distance(visual.transform.position, new Vector3(2f, 3f, 4f)) < .0001f &&
                Quaternion.Angle(visual.transform.rotation, rotation) < .001f,
                "authoritative Assault Helicopter root pose");
            Require(visual.GetComponentsInChildren<MonoBehaviour>(true).Length == 0 &&
                visual.GetComponentsInChildren<Collider>(true).Length == 0 &&
                visual.GetComponentsInChildren<Rigidbody>(true).Length == 0,
                "visual copy contains no gameplay or collision components");

            var nextRotation = Quaternion.Euler(9f, 61f, -4f);
            row.X = 6f;
            row.PositionTick = 66;
            row.AssaultRotation = new BattleJointRotation
            {
                X = nextRotation.x, Y = nextRotation.y,
                Z = nextRotation.z, W = nextRotation.w
            };
            presenter.Apply(new List<BattleArmyEntityState> { row });
            Require(Mathf.Abs(visual.transform.position.x - 2f) < .001f,
                "moving aircraft keeps its prior visual pose until render time");
            presenter.RenderAt(Time.realtimeSinceStartup + .12f, .016f);
            Require(Mathf.Abs(visual.transform.position.x - 4.8f) < .1f &&
                Quaternion.Angle(visual.transform.rotation,
                    Quaternion.Slerp(rotation, nextRotation, .7f)) < 1f,
                "remote aircraft interpolates its host-tick position and root rotation: x="+
                visual.transform.position.x+" angle="+Quaternion.Angle(visual.transform.rotation,
                    Quaternion.Slerp(rotation, nextRotation, .7f)));
            presenter.RenderAt(Time.realtimeSinceStartup + 1.4f, .016f);
            Require(Mathf.Abs(visual.transform.position.x - 6f) < .01f,
                "aircraft visual settles at the latest host pose");

            var filters = new List<MeshFilter>();
            foreach (var sourceGlass in source.glass)
            {
                var matches = visual.GetComponentsInChildren<MeshFilter>(true)
                    .Where(filter => filter.name == sourceGlass.name).ToArray();
                Require(matches.Length == 1 &&
                    matches[0].sharedMesh == sourceGlass.glassMesh,
                    "intact recovered glass mesh: " + sourceGlass.name);
                filters.Add(matches[0]);
            }
            row.AssaultGlassHealth = 0f;
            presenter.Apply(new List<BattleArmyEntityState> { row });
            for (int index = 0; index < filters.Count; index++)
                Require(filters[index].sharedMesh == source.glass[index].brokenGlassMesh,
                    "broken recovered glass mesh: " + source.glass[index].name);
            row.AssaultGlassHealth = row.AssaultGlassMaxHealth;
            presenter.Apply(new List<BattleArmyEntityState> { row });
            for (int index = 0; index < filters.Count; index++)
                Require(filters[index].sharedMesh == source.glass[index].glassMesh,
                    "restored recovered glass mesh: " + source.glass[index].name);
            presenter.Apply(new List<BattleArmyEntityState>());
            Require(GameObject.Find("SelfHostedAssaultHelicopter_4294967297") == null,
                "removed roster entity cleans up its visual");
            Debug.Log("PASS: SelfHostedAssaultHelicopterRenderAudit");
        }
        finally
        {
            if (owner != null) UnityEngine.Object.DestroyImmediate(owner);
            if (previousScenes.Length > 0)
                EditorSceneManager.RestoreSceneManagerSetup(previousScenes);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition) throw new InvalidOperationException(message);
    }
}
