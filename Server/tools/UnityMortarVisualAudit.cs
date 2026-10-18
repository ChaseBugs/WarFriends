using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Checks the compiled presentation-only Mortar model in a disposable Unity project.</summary>
public static class UnityMortarVisualAudit
{
    /// <summary>Verifies source mesh copying without starting gameplay or contacting online services.</summary>
    public static void Run()
    {
        if (!Application.dataPath.Replace('\\', '/').Contains("/Server/.local/"))
        {
            throw new InvalidOperationException("Use a disposable project under Server/.local.");
        }
        UnityOfflineLauncherAudit.Run();
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/GameObject/MortarEnemy.prefab");
        Weapon weapon = prefab == null ? null : prefab.GetComponent<Weapon>();
        if (weapon == null || !(weapon.bulletPrefab is Missile))
        {
            throw new InvalidOperationException("Recovered Mortar weapon or Missile prefab is absent.");
        }
        var holder = new GameObject("MortarVisualAudit");
        GameObject root = null;
        try
        {
            var presenter = holder.AddComponent<SelfHostedProjectilePresenter>();
            const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;
            typeof(SelfHostedProjectilePresenter).GetField("_mortarWeapon", PrivateInstance)
                .SetValue(presenter, weapon);
            object visual = typeof(SelfHostedProjectilePresenter).GetMethod("CreateMortarVisual", PrivateInstance)
                .Invoke(presenter, new object[] { 1UL });
            root = (GameObject)visual.GetType().GetField("Root").GetValue(visual);
            int meshes = root.GetComponentsInChildren<MeshFilter>(true).Length;
            if (meshes == 0 || root.transform.childCount != 1 ||
                Vector3.Distance(root.transform.forward, Vector3.down) > 0.00001f ||
                Vector3.Distance(root.transform.GetChild(0).localScale, new Vector3(0.5f, 0.5f, 0.7f)) > 0.00001f)
            {
                throw new InvalidOperationException("Mortar model lost its meshes, overhead direction or Small scale.");
            }
            foreach (Component component in root.GetComponentsInChildren<Component>(true))
            {
                if (!(component is Transform) && !(component is MeshFilter) && !(component is MeshRenderer))
                {
                    throw new InvalidOperationException("Mortar visual copied a gameplay or collision component.");
                }
            }
            string output = Path.Combine(
                Directory.GetParent(Application.dataPath).FullName, "mortar-visual-audit.json");
            File.WriteAllText(output, (JsonConvert.SerializeObject(new
            {
                scope = "Compiled recovered mesh copy and Small scale; no normal gameplay or particle/trail proof.",
                unityVersion = Application.unityVersion,
                copiedMeshes = meshes,
                gameplayOrCollisionComponents = 0
            }, Formatting.Indented) + "\n").Replace("\r\n", "\n"));
            Debug.Log("UNITY_MORTAR_VISUAL_AUDIT_PASSED meshes=" + meshes);
        }
        finally
        {
            if (root != null) UnityEngine.Object.DestroyImmediate(root);
            UnityEngine.Object.DestroyImmediate(holder);
        }
    }
}
