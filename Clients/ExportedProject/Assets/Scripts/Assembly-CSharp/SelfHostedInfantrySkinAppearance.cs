using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Applies recovered team textures and attachments while owning only copied render materials.</summary>
public sealed class SelfHostedInfantrySkinAppearance : IDisposable
{
    private const string MatCapProperty = "_MatCap";
    private readonly Texture2D _matCap;
    private readonly List<Material> _materials = new List<Material>();
    private bool _isApplied;

    /// <summary>Retains the map-selected MatCap supplied by the recovered scene flow.</summary>
    public SelfHostedInfantrySkinAppearance(Texture2D matCap)
    {
        _matCap = matCap;
    }

    /// <summary>Uses the recovered blue textures and ordinary attachment prefabs for the local owner.</summary>
    public void ApplyOwned(EnemyController source, SelfHostedInfantryVisual visual,
        List<TechnologyVisualDefinition> definitions)
    {
        Apply(source, visual, definitions, Team.Owned);
    }

    /// <summary>Uses the recovered red textures and optional red attachment prefabs for the opponent.</summary>
    public void ApplyOpponent(EnemyController source, SelfHostedInfantryVisual visual,
        List<TechnologyVisualDefinition> definitions)
    {
        Apply(source, visual, definitions, Team.Opponent);
    }

    /// <summary>Releases cloned materials without destroying source materials, textures or the caller's rig.</summary>
    public void Dispose()
    {
        foreach (Material material in _materials)
        {
            if (material == null)
            {
                continue;
            }

            DestroyObject(material);
        }

        _materials.Clear();
    }

    private void Apply(EnemyController source, SelfHostedInfantryVisual visual,
        List<TechnologyVisualDefinition> definitions, Team team)
    {
        if (_isApplied || source == null || source.meshChanger == null || visual == null ||
            visual.Root == null || visual.Root == source.gameObject || visual.Body == null ||
            visual.Body == source.meshChanger.skinnedMeshRenderer ||
            !visual.Body.transform.IsChildOf(visual.Root.transform) ||
            visual.Root.GetComponentsInChildren<MonoBehaviour>(true).Length != 0 || definitions == null)
        {
            throw new ArgumentException("Apply one recovered skin selection to one copied infantry rig.");
        }

        _isApplied = true;
        SoldierMeshChanger meshChanger = source.meshChanger;
        Map(visual, meshChanger.powerband.transform).gameObject.SetActive(false);
        if (definitions.Count > 0 && definitions[0] != null)
        {
            ApplyMaterial(visual.Body, ResolveTexture(definitions[0], team));
            ApplyAttachments(visual, meshChanger.bodyAttachemnts, SelectAttachments(definitions[0], team));
        }

        if (definitions.Count > 1 && definitions[1] != null)
        {
            Texture2D texture = ResolveTexture(definitions[1], team);
            FakeRigidBodySwapper helmet = meshChanger.helmet;
            ApplyMaterial(Map(visual, helmet.NoRigidBodyObject.transform).GetComponent<MeshRenderer>(), texture);
            ApplyMaterial(Map(visual, helmet.RigidBodyObject.transform).GetComponent<MeshRenderer>(), texture);
            ApplyAttachments(visual, meshChanger.helmetAttachments, SelectAttachments(definitions[1], team));
        }
    }

    private void ApplyMaterial(Renderer renderer, Texture2D texture)
    {
        Material[] materials = renderer.sharedMaterials;
        if (materials.Length == 0 || materials[0] == null)
        {
            throw new InvalidOperationException("The recovered destination material is absent.");
        }

        // Source .material/.materials create renderer-owned instances; never mutate shared asset materials.
        Material material = new Material(materials[0]);
        _materials.Add(material);
        material.mainTexture = texture;
        material.SetTexture(MatCapProperty, _matCap);
        materials[0] = material;
        renderer.sharedMaterials = materials;
    }

    private static Texture2D ResolveTexture(TechnologyVisualDefinition definition, Team team)
    {
        Texture2D texture = team == Team.Owned ? definition.materialTetxureBlue : definition.materialTetxureRed;
        string path = team == Team.Owned ? definition.materialTextrePathBlue : definition.materialTextrePathRed;
        if (texture == null && !string.IsNullOrEmpty(path))
        {
            // TechnologyVisualDefinition.LoadMineAsync/LoadOpponentAsync use these exact Resources paths.
            texture = Resources.Load<Texture2D>(path);
            if (texture == null)
            {
                throw new InvalidOperationException("Recovered infantry texture is absent: " + path);
            }
        }

        return texture;
    }

    private static void ApplyAttachments(SelfHostedInfantryVisual visual,
        ModelAttachments slots, IEnumerable<KeyValuePair<int, MeshRenderer>> selections)
    {
        var occupied = new Dictionary<int, GameObject>();
        foreach (KeyValuePair<int, MeshRenderer> selection in selections)
        {
            foreach (ModelAttachments.ModelAttachment slot in slots.modelAttachments)
            {
                if (slot.id != selection.Key)
                {
                    continue;
                }

                GameObject previous;
                if (occupied.TryGetValue(slot.id, out previous))
                {
                    previous.SetActive(false);
                    DestroyObject(previous);
                }

                occupied[slot.id] = CopyAttachment(selection.Value, Map(visual, slot.parent),
                    slots.gameObject.layer);
                break;
            }
        }
    }

    private static IEnumerable<KeyValuePair<int, MeshRenderer>> SelectAttachments(
        TechnologyVisualDefinition definition, Team team)
    {
        foreach (UpgradeSlots.VisualSlotMesh selection in definition.visualSlotMeshes)
        {
            MeshRenderer prefab = team == Team.Opponent && selection.partRed != null ?
                selection.partRed : selection.part;
            if (prefab != null)
            {
                yield return new KeyValuePair<int, MeshRenderer>(selection.visualSlotId, prefab);
            }
        }
    }

    private static GameObject CopyAttachment(MeshRenderer prefab, Transform parent, int layer)
    {
        var root = new GameObject(prefab.gameObject.name);
        root.transform.SetParent(parent, false);
        var copies = new Dictionary<Transform, Transform>();
        SelfHostedVisualHierarchy.CopyRoot(prefab.transform, root.transform, copies);
        foreach (KeyValuePair<Transform, Transform> copy in copies)
        {
            copy.Value.gameObject.layer = copy.Key.gameObject.layer;
        }
        root.transform.localPosition = Vector3.zero;
        root.transform.localRotation = Quaternion.identity;
        root.transform.localScale = Vector3.one;
        root.layer = layer;
        root.GetComponent<MeshRenderer>().useLightProbes = true;
        root.SetActive(true);
        return root;
    }

    private static Transform Map(SelfHostedInfantryVisual visual, Transform target)
    {
        return visual.ResolveSource(target);
    }

    private static void DestroyObject(UnityEngine.Object target)
    {
        if (Application.isPlaying)
        {
            UnityEngine.Object.Destroy(target);
        }
        else
        {
            UnityEngine.Object.DestroyImmediate(target);
        }
    }

    private enum Team
    {
        Owned,
        Opponent
    }
}
