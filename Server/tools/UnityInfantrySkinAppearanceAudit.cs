using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Checks source team textures, attachment identities and material ownership on copied infantry.</summary>
public static class UnityInfantrySkinAppearanceAudit
{
    private const string MatCapProperty = "_MatCap";
    private const int UpperUpgradeIndex = 39;
    private const int ExpectedFamilyCount = 16;
    private static int _checks;
    private static int _actors;
    private static EnemyController _source;
    private static Texture2D _matCap;

    /// <summary>Exercises both lanes and perspectives at two levels across every ordinary family.</summary>
    public static void Run()
    {
        try
        {
            var scene = EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
            Component[] components = scene.GetRootGameObjects()
                .SelectMany(root => root.GetComponentsInChildren<Component>(true)).ToArray();
            _source = components.OfType<ObjectPoolDatabase>().Single().enemy;
            _matCap = components.OfType<MatCapTextures>().Single().menuMatCapTexture;
            SoldierBehaviour[] families = components.OfType<LevelBehaviourManager>().Single().levelBehaviours
                .Select(entry => entry.behaviour).OfType<SoldierBehaviour>()
                .Where(family => !(family is SoldierBehaviourBuddy) && family.soldierVisuals.Count > 0)
                .GroupBy(family => family.unitDictionaryId).Select(group => group.First()).ToArray();
            Require(families.Length == ExpectedFamilyCount,
                "The audit requires all sixteen source combat infantry families.");
            foreach (SoldierBehaviour family in families)
            {
                VerifyFamily(family);
            }

            Debug.Log("PASS: " + _checks + " infantry skin checks across " + _actors +
                " source actors; no full gameplay proof.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void VerifyFamily(SoldierBehaviour family)
    {
        foreach (int level in new[] { 0, UpperUpgradeIndex })
        {
            foreach (bool isElite in new[] { false, true })
            {
                var upgrades = new UpgradeSlots.UnitUpgrades(1f) { slotUpgradeindex = level, isElite = isElite };
                List<TechnologyVisualDefinition> definitions = family.upgradeSlots.GetVisuals(upgrades);
                VerifySelection(family.soldierVisuals[0], definitions, Team.Owned);
                VerifySelection(family.soldierVisuals[0], definitions, Team.Opponent);
            }
        }
    }

    private static void VerifySelection(SoldierMeshChanger.SoldierStyle style,
        List<TechnologyVisualDefinition> definitions, Team team)
    {
        SelfHostedInfantryVisual visual = SelfHostedInfantryVisualFactory.Create(_source, style, "SkinAudit");
        var skin = new SelfHostedInfantrySkinAppearance(_matCap);
        Material originalBody = _source.meshChanger.skinnedMeshRenderer.sharedMaterial;
        Texture originalTexture = originalBody.mainTexture;
        Texture originalMatCap = originalBody.GetTexture(MatCapProperty);
        try
        {
            if (team == Team.Owned)
            {
                skin.ApplyOwned(_source, visual, definitions);
            }
            else
            {
                skin.ApplyOpponent(_source, visual, definitions);
            }

            VerifyRenderers(visual, definitions, team);
            Require(originalBody.mainTexture == originalTexture &&
                originalBody.GetTexture(MatCapProperty) == originalMatCap,
                "Team presentation must not mutate the recovered source material.");
            Require(visual.Root.GetComponentsInChildren<MonoBehaviour>(true).Length == 0,
                "Team attachments must remain free of recovered scripts.");
            Material[] owned = visual.Root.GetComponentsInChildren<Renderer>(true)
                .SelectMany(renderer => renderer.sharedMaterials).Where(material =>
                    material != null && material != originalBody && !AssetDatabase.Contains(material))
                .Distinct().ToArray();
            Require(definitions.Count == 0 || definitions[0] == null || owned.Contains(visual.Body.sharedMaterial),
                "The selected body must own a distinct non-asset material instance.");
            skin.Dispose();
            Require(owned.All(material => material == null), "Renderer-owned skin materials must be released.");
            _actors++;
        }
        finally
        {
            skin.Dispose();
            UnityEngine.Object.DestroyImmediate(visual.Root);
        }
    }

    private static void VerifyRenderers(SelfHostedInfantryVisual visual,
        List<TechnologyVisualDefinition> definitions, Team team)
    {
        if (definitions.Count > 0 && definitions[0] != null)
        {
            VerifyMaterial(visual.Body, definitions[0], team, _matCap);
            VerifyAttachments(visual, _source.meshChanger.bodyAttachemnts, definitions[0], team);
        }

        if (definitions.Count > 1 && definitions[1] != null)
        {
            FakeRigidBodySwapper helmet = _source.meshChanger.helmet;
            VerifyMaterial(Map(visual, helmet.NoRigidBodyObject.transform).GetComponent<Renderer>(),
                definitions[1], team, _matCap);
            VerifyMaterial(Map(visual, helmet.RigidBodyObject.transform).GetComponent<Renderer>(),
                definitions[1], team, _matCap);
            VerifyAttachments(visual, _source.meshChanger.helmetAttachments, definitions[1], team);
        }

        Require(!Map(visual, _source.meshChanger.powerband.transform).gameObject.activeSelf,
            "SetSoldierVisual hides the player powerband for ordinary infantry.");
    }

    private static void VerifyMaterial(Renderer renderer, TechnologyVisualDefinition definition,
        Team team, Texture2D matCap)
    {
        string path = team == Team.Owned ? definition.materialTextrePathBlue : definition.materialTextrePathRed;
        Texture expected = string.IsNullOrEmpty(path) ? null : Resources.Load<Texture2D>(path);
        Require(renderer.sharedMaterial.mainTexture == expected &&
            renderer.sharedMaterial.GetTexture(MatCapProperty) == matCap,
            "Copied body and both helmet forms must use the source perspective texture and MatCap.");
    }

    private static void VerifyAttachments(SelfHostedInfantryVisual visual,
        ModelAttachments slots, TechnologyVisualDefinition definition, Team team)
    {
        foreach (UpgradeSlots.VisualSlotMesh selection in definition.visualSlotMeshes)
        {
            MeshRenderer prefab = team == Team.Opponent && selection.partRed != null ?
                selection.partRed : selection.part;
            ModelAttachments.ModelAttachment slot = slots.modelAttachments.FirstOrDefault(item =>
                item.id == selection.visualSlotId);
            if (prefab == null || slot == null)
            {
                continue;
            }

            Transform parent = Map(visual, slot.parent);
            Transform copy = parent.Cast<Transform>().Last(child => child.name == prefab.name);
            Require(copy.localPosition == Vector3.zero && copy.localRotation == Quaternion.identity &&
                copy.localScale == Vector3.one && copy.gameObject.activeSelf &&
                copy.GetComponent<MeshFilter>().sharedMesh == prefab.GetComponent<MeshFilter>().sharedMesh &&
                copy.GetComponent<MeshRenderer>().sharedMaterials.SequenceEqual(prefab.sharedMaterials),
                "Selected source attachments must retain their mesh, materials and reset socket pose.");
        }
    }

    private static Transform Map(SelfHostedInfantryVisual visual, Transform target)
    {
        return visual.ResolveSource(target);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }

        _checks++;
    }

    private enum Team
    {
        Owned,
        Opponent
    }
}
