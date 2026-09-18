using System;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class ObbRecoveryAudit
{
    public static void Run()
    {
        int missing = 0;
        foreach (string path in Directory.GetFiles("Assets/Scenes", "*.unity"))
        {
            var scene = EditorSceneManager.OpenScene(path);
            int count = 0;
            foreach (GameObject root in scene.GetRootGameObjects())
                foreach (Transform transform in root.GetComponentsInChildren<Transform>(true))
                    foreach (Component component in transform.GetComponents<Component>())
                        if (component == null) { missing++; count++; Debug.LogWarning("OBB_MISSING_SCRIPT " + path + " " + transform.name); }
            Debug.Log("OBB_SCENE_AUDIT " + path + " missing=" + count);
        }
        EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
        GuiManager gui = UnityEngine.Object.FindObjectOfType<GuiManager>();
        Require(gui != null && gui.root != null && gui.guiCamera != null, "GuiManager references");
        GameController controller = UnityEngine.Object.FindObjectOfType<GameController>();
        Require(controller != null && controller.mainPlayerController != null && controller.gameControllerCampaign != null, "GameController references");
        foreach (WeaponPreviewCamera preview in Resources.FindObjectsOfTypeAll<WeaponPreviewCamera>())
            if (preview.gameObject.scene.IsValid()) Require(preview.target != null && preview.weaponParent != null, "WeaponPreviewCamera references");
        Require(GuiElementSingle<ConfirmDialog>.instance != null, "ConfirmDialog lookup");
        int sprites = 0;
        int brokenSprites = 0;
        foreach (UISprite sprite in gui.root.GetComponentsInChildren<UISprite>(true))
        {
            sprites++;
            if (sprite.atlas != null && !string.IsNullOrEmpty(sprite.spriteName) && sprite.atlas.GetSprite(sprite.spriteName) == null)
            {
                brokenSprites++;
                Debug.LogWarning("OBB_MISSING_SPRITE " + sprite.name + " " + sprite.spriteName);
            }
        }
        Debug.Log("OBB_REFERENCE_AUDIT_PASSED sprites=" + sprites + " brokenSprites=" + brokenSprites + " missingScripts=" + missing);
        // Some shipped templates contain stale names replaced when populated.
        // Keep these visible in the report; do not fabricate atlas entries.
        Require(missing == 0, "Scene script attachments");
    }

    private static void Require(bool value, string label)
    {
        if (!value) throw new Exception("OBB reference check failed: " + label);
        Debug.Log("OBB_FIELD_PASSED " + label);
    }
}
