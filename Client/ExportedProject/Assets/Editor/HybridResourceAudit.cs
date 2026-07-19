using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class HybridResourceAudit
{
    public static void ReimportSerializedAssets()
    {
        string[] extensions = { ".unity", ".prefab", ".asset" };
        int imported = 0;
        AssetDatabase.StartAssetEditing();
        try
        {
            foreach (string path in Directory.EnumerateFiles(Application.dataPath, "*", SearchOption.AllDirectories))
            {
                bool supported = false;
                foreach (string extension in extensions)
                {
                    if (path.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
                    {
                        supported = true;
                        break;
                    }
                }

                if (!supported)
                {
                    continue;
                }

                string assetPath = "Assets" + path.Substring(Application.dataPath.Length).Replace('\\', '/');
                AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
                imported++;
            }
        }
        finally
        {
            AssetDatabase.StopAssetEditing();
        }

        Debug.Log("Reimported " + imported + " serialized assets with active serialization aliases.");
        EditorApplication.Exit(0);
    }

    public static void ReimportGameCollection()
    {
        AssetDatabase.ImportAsset(
            "Assets/GameObject/gameCollection.prefab",
            ImportAssetOptions.ForceSynchronousImport | ImportAssetOptions.ForceUpdate);
        Debug.Log("Reimported Assets/GameObject/gameCollection.prefab with active runtime assemblies.");
        EditorApplication.Exit(0);
    }

    public static void Run()
    {
        Scene scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity", OpenSceneMode.Single);
        StringBuilder report = new StringBuilder();
        report.AppendLine("game_object,sprite_assembly,collection_assembly,sprite_id,definition_count,serialized_definition_count,collection,problem");
        int problems = 0;

        foreach (GameObject root in scene.GetRootGameObjects())
        {
            foreach (Transform transform in root.GetComponentsInChildren<Transform>(true))
            {
                foreach (Component component in transform.GetComponents<Component>())
                {
                    if (component == null || component.GetType().Name != "tk2dSprite")
                    {
                        continue;
                    }

                    Type spriteType = component.GetType();
                    Type baseType = spriteType.BaseType;
                    FieldInfo collectionField = baseType.GetField("collection", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    FieldInfo spriteIdField = baseType.GetField("_spriteId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    UnityEngine.Object collection = collectionField == null ? null : collectionField.GetValue(component) as UnityEngine.Object;
                    int spriteId = spriteIdField == null ? -1 : (int)spriteIdField.GetValue(component);
                    int definitionCount = -1;
                    int serializedDefinitionCount = -1;
                    string problem = string.Empty;

                    if (collection == null)
                    {
                        problem = "missing collection";
                    }
                    else
                    {
                        FieldInfo definitionsField = collection.GetType().GetField("spriteDefinitions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        Array definitions = definitionsField == null ? null : definitionsField.GetValue(collection) as Array;
                        definitionCount = definitions == null ? -1 : definitions.Length;
                        SerializedObject serializedCollection = new SerializedObject(collection);
                        SerializedProperty serializedDefinitions = serializedCollection.FindProperty("spriteDefinitions");
                        serializedDefinitionCount = serializedDefinitions == null ? -1 : serializedDefinitions.arraySize;
                        if (definitions == null || definitions.Length == 0)
                        {
                            problem = "empty definitions";
                        }
                        else if (spriteId < 0 || spriteId >= definitions.Length)
                        {
                            problem = "sprite id out of range";
                        }
                    }

                    if (problem.Length == 0)
                    {
                        continue;
                    }

                    problems++;
                    report.AppendLine(string.Join(",", new[]
                    {
                        Csv(HierarchyPath(transform)),
                        Csv(spriteType.Assembly.GetName().Name),
                        Csv(collection == null ? string.Empty : collection.GetType().Assembly.GetName().Name),
                        spriteId.ToString(),
                        definitionCount.ToString(),
                        serializedDefinitionCount.ToString(),
                        Csv(collection == null ? string.Empty : AssetDatabase.GetAssetPath(collection)),
                        Csv(problem)
                    }));
                }
            }
        }

        string reportPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "hybrid-resource-audit.csv"));
        File.WriteAllText(reportPath, report.ToString());
        Debug.Log("Hybrid resource audit: problems=" + problems + ", report=" + reportPath);
        EditorApplication.Exit(problems == 0 ? 0 : 1);
    }

    private static string HierarchyPath(Transform transform)
    {
        string path = transform.name;
        while (transform.parent != null)
        {
            transform = transform.parent;
            path = transform.name + "/" + path;
        }
        return path;
    }

    private static string Csv(string value)
    {
        return "\"" + value.Replace("\"", "\"\"") + "\"";
    }
}
