using System;
using System.Collections.Generic;
using UnityEngine;
using War.Shared;

/// <summary>Copies the recovered indicator's visual hierarchy without weapon, Photon or tween components.</summary>
public sealed class SelfHostedMortarWarningVisual : IDisposable
{
    private readonly GameObject _root;
    private readonly tk2dSprite[] _sprites;
    private readonly List<Material> _ownedMaterials = new List<Material>();
    private Color _color = Color.white;

    public Transform Root { get { return _root == null ? null : _root.transform; } }

    public SelfHostedMortarWarningVisual(GameObject source, Transform worldRoot, int slot)
    {
        if (source == null || worldRoot == null)
        {
            throw new ArgumentException("A recovered warning hierarchy and scene root are required.");
        }
        _root = new GameObject("SelfHostedMortarWarningSlot" + slot);
        _root.transform.SetParent(worldRoot, false);
        try
        {
            var copies = new Dictionary<Transform, Transform>();
            SelfHostedVisualHierarchy.CopyRoot(source.transform, _root.transform, copies);
            foreach (var pair in copies)
            {
                pair.Value.gameObject.layer = pair.Key.gameObject.layer;
                pair.Value.gameObject.SetActive(true);
            }
            var sprites = new List<tk2dSprite>();
            foreach (tk2dSprite original in source.GetComponentsInChildren<tk2dSprite>(true))
            {
                if (original.Collection == null)
                {
                    throw new InvalidOperationException("Recovered Mortar indicator sprite collection is absent.");
                }
                tk2dSprite sprite = copies[original.transform].gameObject.AddComponent<tk2dSprite>();
                sprite.SetSprite(original.Collection, original.spriteId);
                sprite.scale = original.scale;
                sprite.color = original.color;
                BindSourceAtlas(sprite);
                sprites.Add(sprite);
            }
            if (sprites.Count == 0)
            {
                throw new InvalidOperationException("Recovered Mortar indicator contains no source sprites.");
            }
            _sprites = sprites.ToArray();
            foreach (var pair in copies)
            {
                if (pair.Value != _root.transform)
                {
                    pair.Value.gameObject.SetActive(pair.Key.gameObject.activeSelf);
                }
            }
            foreach (Collider collider in _root.GetComponentsInChildren<Collider>(true))
            {
                collider.enabled = false;
            }
            Hide();
        }
        catch
        {
            Dispose();
            throw;
        }
    }

    private void BindSourceAtlas(tk2dSprite sprite)
    {
        Renderer renderer = sprite.GetComponent<Renderer>();
        Material sourceMaterial = renderer.sharedMaterial;
        if (sourceMaterial != null && sourceMaterial.mainTexture != null)
        {
            return;
        }

        tk2dSpriteCollectionData collection = sprite.Collection.inst;
        int materialIndex = collection.spriteDefinitions[sprite.spriteId].materialId;
        if (sourceMaterial == null || collection.textures == null || materialIndex < 0 ||
            materialIndex >= collection.textures.Length || collection.textures[materialIndex] == null)
        {
            throw new InvalidOperationException("The recovered warning collection has no matching atlas texture.");
        }

        // The recovered collection retains its atlas even when the material texture binding is empty.
        var material = new Material(sourceMaterial);
        _ownedMaterials.Add(material);
        material.mainTexture = collection.textures[materialIndex];
        renderer.sharedMaterial = material;
    }

    /// <summary>Applies the original local rotation composition and white sprite alpha to a world warning.</summary>
    public void Render(MortarIndicatorClock clock)
    {
        if (_root == null)
        {
            return;
        }
        _root.SetActive(clock.IsVisible);
        _root.transform.localRotation = Quaternion.AngleAxis(
            MortarIndicatorTween.SampleRotationDegrees(clock.RotationFactor), Vector3.up) * Quaternion.Euler(90f, 0f, 0f);
        _root.transform.localScale = Vector3.one * clock.Scale;
        _color.a = clock.Alpha;
        for (int index = 0; index < _sprites.Length; index++)
        {
            _sprites[index].color = _color;
        }
    }

    public void Hide()
    {
        if (_root != null)
        {
            _root.SetActive(false);
        }
    }

    public void Dispose()
    {
        foreach (Material material in _ownedMaterials)
        {
            if (Application.isPlaying)
            {
                UnityEngine.Object.Destroy(material);
            }
            else
            {
                UnityEngine.Object.DestroyImmediate(material);
            }
        }
        _ownedMaterials.Clear();
        if (_root == null)
        {
            return;
        }
        if (Application.isPlaying)
        {
            UnityEngine.Object.Destroy(_root);
        }
        else
        {
            UnityEngine.Object.DestroyImmediate(_root);
        }
    }
}
