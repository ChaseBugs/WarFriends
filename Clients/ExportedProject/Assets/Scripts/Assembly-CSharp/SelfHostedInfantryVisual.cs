using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Owns an inactive script-free infantry rig until its caller supplies a confirmed pose.</summary>
public sealed class SelfHostedInfantryVisual
{
    private Dictionary<Transform, Transform> _sourceTransforms;

    /// <summary>Gets the visual root whose lifetime is owned by the caller.</summary>
    public GameObject Root { get; private set; }

    /// <summary>Gets the copied source animation hierarchy for explicit clip sampling.</summary>
    public GameObject AnimationRoot { get; private set; }

    /// <summary>Gets the body renderer with the selected source mesh and remapped bones.</summary>
    public SkinnedMeshRenderer Body { get; private set; }

    /// <summary>Gets the optional copied weapon attachment without any recovered weapon components.</summary>
    public Transform WeaponRoot { get; private set; }

    internal SelfHostedInfantryVisual(
        GameObject root, GameObject animationRoot, SkinnedMeshRenderer body, Transform weaponRoot)
    {
        Root = root;
        AnimationRoot = animationRoot;
        Body = body;
        WeaponRoot = weaponRoot;
    }

    /// <summary>Resolves the original copied identity even after weapons and upgrades add hierarchy children.</summary>
    public Transform ResolveSource(Transform source)
    {
        Transform copy;
        if (source == null || _sourceTransforms == null || !_sourceTransforms.TryGetValue(source, out copy))
        {
            throw new InvalidOperationException("The source transform is absent from this copied infantry rig.");
        }

        return copy;
    }

    internal void BindSourceTransforms(Dictionary<Transform, Transform> sourceTransforms)
    {
        if (_sourceTransforms != null || sourceTransforms == null)
        {
            throw new InvalidOperationException("Bind the original transform identities once during construction.");
        }

        _sourceTransforms = sourceTransforms;
    }
}
