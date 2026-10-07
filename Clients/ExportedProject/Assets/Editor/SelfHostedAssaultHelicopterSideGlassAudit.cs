using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

// The two side panels are visible, but their recovered MeshColliders have no
// mesh. Keep this distinction explicit before assigning host collision authority.
public static class SelfHostedAssaultHelicopterSideGlassAudit
{
    public static void Run()
    {
        var previousScenes = EditorSceneManager.GetSceneManagerSetup();
        GameObject instance = null;
        try
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(
                "Assets/GameObject/assaultHelicopter.prefab");
            if (prefab == null) throw new InvalidOperationException("Assault Helicopter prefab is absent.");

            CheckGlass(prefab, "prefab");
            instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
            CheckGlass(instance, "Editor instance");
            Debug.Log("PASS: SelfHostedAssaultHelicopterSideGlassAudit");
        }
        finally
        {
            if (instance != null) UnityEngine.Object.DestroyImmediate(instance);
            if (previousScenes.Length > 0)
                EditorSceneManager.RestoreSceneManagerSetup(previousScenes);
        }
    }

    private static void CheckGlass(GameObject root, string context)
    {
        var panels = root.GetComponentsInChildren<Glass>(true);
        if (panels.Length != 3)
            throw new InvalidOperationException(context + " must contain three recovered glass panels.");

        foreach (string name in new[]
        {
            "assaultheli_glass_left_side", "assaultheli_glass_right_side"
        })
        {
            var panel = panels.Single(glass => glass.name == name);
            var filter = panel.GetComponent<MeshFilter>();
            var collider = panel.GetComponent<MeshCollider>();
            if (filter == null || filter.sharedMesh == null || collider == null ||
                collider.sharedMesh != null)
                throw new InvalidOperationException(context + " side glass geometry changed: " + name);
        }

        var front = panels.Single(glass => glass.name == "assaultheli_glass_front");
        if (front.GetComponent<MeshCollider>() == null ||
            front.GetComponent<MeshCollider>().sharedMesh == null)
            throw new InvalidOperationException(context + " front glass collider is absent.");
    }
}
