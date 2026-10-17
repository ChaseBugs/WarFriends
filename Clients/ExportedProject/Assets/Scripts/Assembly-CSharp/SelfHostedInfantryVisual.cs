using UnityEngine;

/// <summary>Owns an inactive script-free infantry rig until its caller supplies a confirmed pose.</summary>
public sealed class SelfHostedInfantryVisual
{
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
}
