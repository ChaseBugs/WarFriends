using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class HybridSceneAudit
{
    public static void Run()
    {
        StringBuilder report = new StringBuilder();
        report.AppendLine("scene,loaded,root_objects,game_objects,components,missing_scripts,exception");
        StringBuilder missingDetails = new StringBuilder();
        missingDetails.AppendLine("scene,game_object,missing_scripts");

        int failedScenes = 0;
        int missingScripts = 0;

        foreach (EditorBuildSettingsScene buildScene in EditorBuildSettings.scenes)
        {
            if (!buildScene.enabled)
            {
                continue;
            }

            bool loaded = false;
            int rootCount = 0;
            int gameObjectCount = 0;
            int componentCount = 0;
            int sceneMissingScripts = 0;
            string exception = string.Empty;

            try
            {
                Scene scene = EditorSceneManager.OpenScene(buildScene.path, OpenSceneMode.Single);
                loaded = scene.IsValid() && scene.isLoaded;
                GameObject[] roots = scene.GetRootGameObjects();
                rootCount = roots.Length;

                foreach (GameObject root in roots)
                {
                    Transform[] transforms = root.GetComponentsInChildren<Transform>(true);
                    gameObjectCount += transforms.Length;

                    foreach (Transform transform in transforms)
                    {
                        Component[] components = transform.gameObject.GetComponents<Component>();
                        componentCount += components.Length;
                        int objectMissingScripts = 0;
                        foreach (Component component in components)
                        {
                            if (component == null)
                            {
                                sceneMissingScripts++;
                                objectMissingScripts++;
                            }
                        }

                        if (objectMissingScripts > 0)
                        {
                            missingDetails.AppendLine(string.Join(",", new[]
                            {
                                Csv(buildScene.path),
                                Csv(HierarchyPath(transform)),
                                objectMissingScripts.ToString()
                            }));
                        }
                    }
                }
            }
            catch (Exception error)
            {
                failedScenes++;
                exception = error.GetType().Name + ": " + error.Message;
                Debug.LogError("Hybrid scene audit failed for " + buildScene.path + ": " + error);
            }

            missingScripts += sceneMissingScripts;
            report.AppendLine(string.Join(",", new[]
            {
                Csv(buildScene.path),
                loaded ? "true" : "false",
                rootCount.ToString(),
                gameObjectCount.ToString(),
                componentCount.ToString(),
                sceneMissingScripts.ToString(),
                Csv(exception)
            }));
        }

        string reportPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "hybrid-scene-audit.csv"));
        File.WriteAllText(reportPath, report.ToString());
        string missingDetailsPath = Path.GetFullPath(Path.Combine(Application.dataPath, "..", "..", "hybrid-missing-script-details.csv"));
        File.WriteAllText(missingDetailsPath, missingDetails.ToString());
        Debug.Log("Hybrid scene audit report: " + reportPath);
        Debug.Log("Hybrid scene audit totals: failedScenes=" + failedScenes + ", missingScripts=" + missingScripts);
        EditorApplication.Exit(failedScenes == 0 && missingScripts == 0 ? 0 : 1);
    }

    private static string Csv(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return string.Empty;
        }

        return "\"" + value.Replace("\"", "\"\"") + "\"";
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
}
