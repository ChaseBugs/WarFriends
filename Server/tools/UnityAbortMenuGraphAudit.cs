using System;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Inspects the recovered menu graph before enabling it in an isolated abort-recovery audit.</summary>
public static class UnityAbortMenuGraphAudit
{
    /// <summary>Reports original serialized UI roots and activation dependencies without account boot.</summary>
    public static void Run()
    {
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Component[] components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            var manager = components.OfType<GuiManager>().Single();
            Report("GuiManager", manager.transform);
            Report("GuiManager.root", manager.root.transform);
            Report("MainScreen", components.OfType<MainScreen>().Single().transform);
            Report("ConfirmDialog", components.OfType<ConfirmDialog>().Single().transform);
            Report("LoadingDialog", components.OfType<LoadingDialog>().Single().transform);
            Debug.Log("PASS: recovered abort menu graph inspected without Play Mode or account boot.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void Report(string label, Transform node)
    {
        for (Transform current = node; current != null; current = current.parent)
        {
            string types = string.Join(",", current.GetComponents<Component>()
                .Where(component => component != null).Select(component => component.GetType().FullName).ToArray());
            Debug.Log("UI-GRAPH: " + label + " ancestor=" + current.name +
                " activeSelf=" + current.gameObject.activeSelf + " components=" + types);
        }
    }
}
