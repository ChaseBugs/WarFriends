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

    internal SelfHostedInfantryVisual(GameObject root, GameObject animationRoot, SkinnedMeshRenderer body)
    {
        Root = root;
        AnimationRoot = animationRoot;
        Body = body;
    }
}
