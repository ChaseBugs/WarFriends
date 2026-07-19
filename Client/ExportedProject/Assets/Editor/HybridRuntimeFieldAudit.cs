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

public static class HybridRuntimeFieldAudit
{
    private static readonly HashSet<string> TargetTypes = new HashSet<string>(StringComparer.Ordinal)
    {
        "LevelBehaviourManager", "ObjectPool", "NetworkObjectPool", "SettingsManager",
        "GameController", "CardManagerDeathmatchOffline", "OfferManager", "CamosManager",
        "PushNotificationManager", "PlayerTexturePool", "ScoreManager", "ReminderManager",
        "AssignmentsManager", "MatchManager", "GameVariables", "AssetBundleManager",
        "WeaponInventory", "PlayerWeapon", "PlayerController", "LevelManager",
        "EventTrackingManager", "FuseSDK", "ObjectHolderOnSceneChange"
    };

    public static void Run()
    {
        var report = new StringBuilder();
        string scenePath = "Assets/Scenes/MainScene.unity";
        Scene scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
        report.AppendLine("scene=" + scenePath);

        MonoBehaviour[] behaviours = scene.GetRootGameObjects()
            .SelectMany(root => root.GetComponentsInChildren<MonoBehaviour>(true))
            .Where(component => component != null && TargetTypes.Contains(component.GetType().Name))
            .OrderBy(component => component.GetType().Name, StringComparer.Ordinal)
            .ThenBy(component => GetPath(component.transform), StringComparer.Ordinal)
            .ToArray();

        foreach (MonoBehaviour component in behaviours)
        {
            Type type = component.GetType();
            report.AppendLine();
            report.AppendLine("component=" + type.FullName + " path=" + GetPath(component.transform));
            foreach (FieldInfo field in GetSerializableFields(type))
            {
                object value;
                try
                {
                    value = field.GetValue(component);
                }
                catch (Exception exception)
                {
                    report.AppendLine("  " + field.Name + " <read-error:" + exception.GetType().Name + ">");
                    continue;
                }

                report.AppendLine("  " + field.Name + " " + Summarize(value));
            }
        }

        string outputPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "hybrid-runtime-field-audit.txt"));
        File.WriteAllText(outputPath, report.ToString());
        Debug.Log("HybridRuntimeFieldAudit wrote " + outputPath + " for " + behaviours.Length + " components.");
        EditorApplication.Exit(0);
    }

    public static void AuditSplashComponents()
    {
        Scene scene = EditorSceneManager.OpenScene("Assets/Scenes/SplashScene.unity", OpenSceneMode.Single);
        var report = new StringBuilder();
        foreach (MonoBehaviour component in scene.GetRootGameObjects()
            .SelectMany(root => root.GetComponentsInChildren<MonoBehaviour>(true))
            .Where(item => item != null)
            .OrderBy(item => GetPath(item.transform), StringComparer.Ordinal)
            .ThenBy(item => item.GetType().FullName, StringComparer.Ordinal))
        {
            Type type = component.GetType();
            var bases = new List<string>();
            for (Type current = type.BaseType; current != null && current != typeof(object); current = current.BaseType)
            {
                bases.Add(current.FullName);
            }

            report.AppendLine(GetPath(component.transform) + " | active=" + component.gameObject.activeInHierarchy +
                " | " + type.FullName + " | bases=" + string.Join(" -> ", bases.ToArray()));
        }

        string outputPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "hybrid-splash-components.txt"));
        File.WriteAllText(outputPath, report.ToString());
        Debug.Log("HybridRuntimeFieldAudit wrote " + outputPath);
        EditorApplication.Exit(0);
    }

    private static IEnumerable<FieldInfo> GetSerializableFields(Type type)
    {
        for (Type current = type; current != null && current != typeof(MonoBehaviour); current = current.BaseType)
        {
            foreach (FieldInfo field in current.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
            {
                if (field.IsStatic || field.IsNotSerialized)
                {
                    continue;
                }

                if (field.IsPublic || field.GetCustomAttributes(typeof(SerializeField), true).Length != 0)
                {
                    yield return field;
                }
            }
        }
    }

    private static string Summarize(object value)
    {
        if (value == null)
        {
            return "=<null>";
        }

        if (value is UnityEngine.Object unityObject)
        {
            return unityObject == null ? "=<destroyed-or-missing>" : "=" + unityObject.GetType().Name + ":" + unityObject.name;
        }

        if (value is IList list)
        {
            int nulls = 0;
            var samples = new List<string>();
            var missingMembers = new List<string>();
            for (int index = 0; index < list.Count; index++)
            {
                object item = list[index];
                bool isNull = item == null || (item is UnityEngine.Object itemObject && itemObject == null);
                if (isNull)
                {
                    nulls++;
                    if (samples.Count < 8)
                    {
                        samples.Add(index.ToString());
                    }
                }
                else if (item != null && missingMembers.Count < 12)
                {
                    foreach (FieldInfo itemField in item.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public))
                    {
                        if (!typeof(UnityEngine.Object).IsAssignableFrom(itemField.FieldType))
                        {
                            continue;
                        }

                        var memberValue = itemField.GetValue(item) as UnityEngine.Object;
                        if (memberValue == null)
                        {
                            missingMembers.Add(index + "." + itemField.Name);
                        }
                    }
                }
            }

            return "=list(count=" + list.Count + ", nulls=" + nulls +
                (samples.Count == 0 ? string.Empty : ", null_indices=" + string.Join(";", samples)) +
                (missingMembers.Count == 0 ? string.Empty : ", null_object_members=" + string.Join(";", missingMembers)) + ")";
        }

        return "=" + value;
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
}
