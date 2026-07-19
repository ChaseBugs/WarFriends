using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class HybridCompatibilitySanitizer
{
    public static void Run()
    {
        var report = new StringBuilder();
        report.AppendLine("asset,component_path,component_type,list_field,removed_index,removed_name,missing_member");
        int removed = 0;
        string[] scenePaths = AssetDatabase.FindAssets("t:Scene")
            .Select(AssetDatabase.GUIDToAssetPath)
            .OrderBy(path => path, StringComparer.Ordinal)
            .ToArray();

        foreach (string scenePath in scenePaths)
        {
            Scene scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
            bool changed = false;
            foreach (MonoBehaviour component in scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<MonoBehaviour>(true))
                .Where(item => item != null))
            {
                Type type = component.GetType();
                if (type.Name == "LevelBehaviourManager")
                {
                    changed |= RemoveMissingEntries(scenePath, component, "DHKKHDABING", "behaviour", report, ref removed);
                }

                if (IsObjectPool(type))
                {
                    changed |= RemoveMissingEntries(scenePath, component, "LNHBALFMHOM", "Prefab", report, ref removed);
                }

                if (type.Name == "LevelManager")
                {
                    changed |= RemoveNullEntries(scenePath, component, "behaviours", report, ref removed);
                    changed |= RemoveNullEntries(scenePath, component, "additionalBehaviours", report, ref removed);
                }
            }

            if (changed)
            {
                EditorSceneManager.MarkSceneDirty(scene);
                EditorSceneManager.SaveScene(scene);
            }
        }

        string outputPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "hybrid-compatibility-sanitizer.csv"));
        File.WriteAllText(outputPath, report.ToString());
        AssetDatabase.SaveAssets();
        Debug.Log("HybridCompatibilitySanitizer removed " + removed + " incompatible entries; report=" + outputPath);
        EditorApplication.Exit(0);
    }

    private static bool IsObjectPool(Type type)
    {
        for (Type current = type; current != null; current = current.BaseType)
        {
            if (current.Name == "ObjectPool")
            {
                return true;
            }
        }

        return false;
    }

    private static bool RemoveMissingEntries(
        string assetPath,
        MonoBehaviour component,
        string listFieldName,
        string objectFieldName,
        StringBuilder report,
        ref int removed)
    {
        FieldInfo listField = FindField(component.GetType(), listFieldName);
        var list = listField == null ? null : listField.GetValue(component) as IList;
        if (list == null)
        {
            return false;
        }

        bool changed = false;
        for (int index = list.Count - 1; index >= 0; index--)
        {
            object entry = list[index];
            FieldInfo objectField = entry == null ? null : FindField(entry.GetType(), objectFieldName);
            var referencedObject = objectField == null ? null : objectField.GetValue(entry) as UnityEngine.Object;
            if (entry != null && objectField != null && referencedObject != null)
            {
                continue;
            }

            string entryName = GetEntryName(entry);
            report.AppendLine(string.Join(",", new[]
            {
                Csv(assetPath), Csv(GetPath(component.transform)), Csv(component.GetType().FullName),
                Csv(listFieldName), index.ToString(), Csv(entryName), Csv(objectFieldName)
            }));
            list.RemoveAt(index);
            changed = true;
            removed++;
        }

        return changed;
    }

    private static bool RemoveNullEntries(
        string assetPath,
        MonoBehaviour component,
        string listFieldName,
        StringBuilder report,
        ref int removed)
    {
        FieldInfo listField = FindField(component.GetType(), listFieldName);
        var list = listField == null ? null : listField.GetValue(component) as IList;
        if (list == null)
        {
            return false;
        }

        bool changed = false;
        for (int index = list.Count - 1; index >= 0; index--)
        {
            object entry = list[index];
            bool isMissing = entry == null || (entry is UnityEngine.Object unityObject && unityObject == null);
            if (!isMissing)
            {
                continue;
            }

            report.AppendLine(string.Join(",", new[]
            {
                Csv(assetPath), Csv(GetPath(component.transform)), Csv(component.GetType().FullName),
                Csv(listFieldName), index.ToString(), Csv("<missing-reference>"), Csv("<entry>")
            }));
            list.RemoveAt(index);
            changed = true;
            removed++;
        }

        return changed;
    }

    private static FieldInfo FindField(Type type, string name)
    {
        for (Type current = type; current != null; current = current.BaseType)
        {
            FieldInfo field = current.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            if (field != null)
            {
                return field;
            }
        }

        return null;
    }

    private static string GetEntryName(object entry)
    {
        if (entry == null)
        {
            return "<null-entry>";
        }

        foreach (string name in new[] { "Name", "name" })
        {
            FieldInfo field = FindField(entry.GetType(), name);
            if (field != null && field.GetValue(entry) is string value)
            {
                return value;
            }
        }

        return entry.GetType().Name;
    }

    private static string GetPath(Transform transform)
    {
        var names = new Stack<string>();
        for (Transform current = transform; current != null; current = current.parent)
        {
            names.Push(current.name);
        }

        return string.Join("/", names.ToArray());
    }

    private static string Csv(string value)
    {
        return "\"" + (value ?? string.Empty).Replace("\"", "\"\"") + "\"";
    }
}
