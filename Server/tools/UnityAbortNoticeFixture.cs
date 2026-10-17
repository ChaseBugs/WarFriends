using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Preserves the recovered confirmation widget without unrelated account/menu initialization.</summary>
public static class UnityAbortNoticeFixture
{
    private const string RootName = "RecoveredAbortNoticeUI";

    /// <summary>Moves the original UI root into an empty scene, retaining its serialized modal references.</summary>
    public static void PrepareScene()
    {
        var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
        var roots = scene.GetRootGameObjects();
        Component[] components = roots.SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
        foreach (GameObject root in roots)
        {
            root.SetActive(false);
        }

        GuiManager manager = components.OfType<GuiManager>().Single();
        ConfirmDialog dialog = components.OfType<ConfirmDialog>().Single();
        manager.enabled = false;
        Transform camera = manager.transform.parent;
        foreach (Transform child in camera)
        {
            child.gameObject.SetActive(false);
        }

        manager.gameObject.SetActive(true);
        manager.root.gameObject.name = RootName;
        manager.root.gameObject.SetActive(false);
        manager.root.transform.SetParent(null, false);
        var empty = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
        Type sceneManager = empty.GetType().Assembly.GetType("UnityEngine.SceneManagement.SceneManager", true);
        sceneManager.GetMethod("MoveGameObjectToScene", BindingFlags.Public | BindingFlags.Static)
            .Invoke(null, new object[] { manager.root.gameObject, empty });
        sceneManager.GetMethod("SetActiveScene", BindingFlags.Public | BindingFlags.Static)
            .Invoke(null, new object[] { empty });
        dialog.gameObject.SetActive(false);
    }

    /// <summary>Binds only local source managers and the original English localization table.</summary>
    public static ConfirmDialog StartServices()
    {
        var uiRoot = Resources.FindObjectsOfTypeAll<UIRoot>()
            .Single(root => root.name == RootName && root.gameObject.scene.IsValid());
        GuiManager manager = uiRoot.GetComponentInChildren<GuiManager>(true);
        ConfirmDialog dialog = uiRoot.GetComponentInChildren<ConfirmDialog>(true);
        GameController game = Resources.FindObjectsOfTypeAll<GameController>()
            .Single(value => value.gameObject.scene.IsValid());
        typeof(Singleton<GameController>).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic)
            .SetValue(null, game);
        typeof(Singleton<GuiManager>).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic)
            .SetValue(null, manager);
        var debugOwner = new GameObject("InactiveOriginalDebugProvider");
        debugOwner.SetActive(false);
        var settings = debugOwner.AddComponent<DebugSettings>();
        settings.data = new DebugSettings.DebugSettingsData();
        typeof(DebugSettings).GetField("mInstance", BindingFlags.Static | BindingFlags.NonPublic)
            .SetValue(null, settings);
        BindLocalization(dialog);
        uiRoot.gameObject.SetActive(true);
        dialog.InitEvents();
        return dialog;
    }

    private static void BindLocalization(ConfirmDialog dialog)
    {
        TextAsset english = Resources.Load<TextAsset>("Localizations/en");
        if (english == null)
        {
            throw new InvalidOperationException("The original English localization table is missing.");
        }

        var owner = new GameObject("InactiveOriginalLocalizationProvider");
        owner.SetActive(false);
        var locale = owner.AddComponent<Localization>();
        locale.mainFont = dialog.dialogText.font;
        typeof(Localization).GetField("mDictionary", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(locale, new ByteReader(english).ReadDictionary());
        typeof(Localization).GetField("mLanguage", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(locale, "en");
        typeof(Localization).GetField("mInstance", BindingFlags.Static | BindingFlags.NonPublic)
            .SetValue(null, locale);
    }
}
