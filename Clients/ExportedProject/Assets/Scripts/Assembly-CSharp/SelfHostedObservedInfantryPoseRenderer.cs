using System;
using System.Collections.Generic;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Reconstructs reviewed local poses without advancing animation or changing host placement.</summary>
public sealed class SelfHostedObservedInfantryPoseRenderer
{
    private readonly ObservedInfantryPoseCatalogData _catalog;
    private readonly SelfHostedInfantryAnimationSampler _sampler;
    private readonly Transform[] _transforms;
    private readonly Vector3[] _positions;
    private readonly Quaternion[] _rotations;
    private readonly Vector3[] _scales;
    private readonly Transform _rig;
    private readonly Transform[] _parents;
    private readonly int[] _siblingIndexes;
    private readonly int[] _childCounts;
    private readonly string[] _names;
    private readonly int _rigChildCount;

    /// <summary>Binds an exact source topology before installing a disabled source animation mixer.</summary>
    public SelfHostedObservedInfantryPoseRenderer(SelfHostedInfantryVisual visual, Animation source)
    {
        if (visual == null || visual.Root == null || source == null)
        {
            throw new ArgumentException("A complete source visual and animation definition are required.");
        }

        _catalog = ObservedInfantryPoseCatalogData.BuiltIn;
        _rig = visual.Root.transform.GetChild(0);
        _transforms = Bind(_rig, _catalog.Snapshot());
        _positions = new Vector3[_transforms.Length];
        _rotations = new Quaternion[_transforms.Length];
        _scales = new Vector3[_transforms.Length];
        _parents = new Transform[_transforms.Length];
        _siblingIndexes = new int[_transforms.Length];
        _childCounts = new int[_transforms.Length];
        _names = new string[_transforms.Length];
        _rigChildCount = _rig.childCount;
        for (int index = 0; index < _transforms.Length; index++)
        {
            _positions[index] = _transforms[index].localPosition;
            _rotations[index] = _transforms[index].localRotation;
            _scales[index] = _transforms[index].localScale;
            _parents[index] = _transforms[index].parent;
            _siblingIndexes[index] = _transforms[index].GetSiblingIndex();
            _childCounts[index] = _transforms[index].childCount;
            _names[index] = _transforms[index].name;
        }

        ValidateClips(source, _catalog.Snapshot());
        _sampler = new SelfHostedInfantryAnimationSampler(visual.AnimationRoot, source);
    }

    /// <summary>Resolves trusted local content before applying its complete clip and correction sequence.</summary>
    public void Sample(BattleInfantryObservedPoseReference reference)
    {
        ObservedInfantryPoseSample sample = _catalog.GetSample(reference);
        var states = new List<SelfHostedInfantryAnimationState>();
        foreach (BattleInfantryAnimationClip clip in sample.Clips)
        {
            states.Add(new SelfHostedInfantryAnimationState(
                clip.ClipName, clip.TimeSeconds, clip.Weight, ToUnityWrap(clip.Wrap)));
        }

        ValidateBinding();
        RestoreSourcePose();
        _sampler.Sample(states);
        foreach (ObservedInfantryPoseOverride correction in sample.Overrides)
        {
            Transform target = _transforms[(int)correction.TransformIndex - 1];
            target.localPosition = ToVector(correction.Position);
            target.localScale = ToVector(correction.Scale);
        }
    }

    private static Transform[] Bind(Transform rig, ObservedInfantryPoseCatalog catalog)
    {
        if (rig.GetComponentsInChildren<Transform>(true).Length != catalog.Skeleton.Count + 1)
        {
            throw new InvalidOperationException("The observed pose requires its complete source body and weapon.");
        }

        var result = new Transform[catalog.Skeleton.Count];
        foreach (ObservedInfantryPoseTransform identity in catalog.Skeleton)
        {
            Transform target = Resolve(rig, identity.Path);
            if (target.name != identity.Name)
            {
                throw new InvalidOperationException("Observed pose topology differs at " + identity.Path);
            }

            result[(int)identity.Index - 1] = target;
        }

        return result;
    }

    private void ValidateBinding()
    {
        // A detached or replaced weapon must fail before any bone or mixer state changes.
        if (_rig == null || _rig.childCount != _rigChildCount)
        {
            throw new InvalidOperationException("The observed pose root topology changed.");
        }

        for (int index = 0; index < _transforms.Length; index++)
        {
            Transform current = _transforms[index];
            if (current == null || current.parent != _parents[index] || current.name != _names[index] ||
                current.GetSiblingIndex() != _siblingIndexes[index] || current.childCount != _childCounts[index])
            {
                throw new InvalidOperationException("The observed pose binding changed after construction.");
            }
        }
    }

    private static void ValidateClips(Animation source, ObservedInfantryPoseCatalog catalog)
    {
        foreach (ObservedInfantryPoseSample sample in catalog.Samples)
        {
            foreach (BattleInfantryAnimationClip state in sample.Clips)
            {
                AnimationClip clip = source.GetClip(state.ClipName);
                if (clip == null || clip.name != state.ClipName)
                {
                    throw new InvalidOperationException("An observed pose source clip binding is missing.");
                }
            }
        }
    }

    private void RestoreSourcePose()
    {
        // Partial-weight legacy samples depend on their initial pose; previous corrections are not a new basis.
        for (int index = 0; index < _transforms.Length; index++)
        {
            _transforms[index].localPosition = _positions[index];
            _transforms[index].localRotation = _rotations[index];
            _transforms[index].localScale = _scales[index];
        }
    }

    private static Transform Resolve(Transform root, string path)
    {
        Transform current = root;
        string[] segments = path.Split('/');
        for (int index = 1; index < segments.Length; index++)
        {
            int childIndex = int.Parse(segments[index]);
            if (childIndex >= current.childCount)
            {
                throw new InvalidOperationException("An observed pose source transform is missing.");
            }

            current = current.GetChild(childIndex);
        }

        return current;
    }

    private static Vector3 ToVector(ObservedInfantryPoseVector value)
    {
        return new Vector3(value.X, value.Y, value.Z);
    }

    private static WrapMode ToUnityWrap(BattleInfantryAnimationWrap wrap)
    {
        switch (wrap)
        {
            case BattleInfantryAnimationWrap.Clamp:
                return WrapMode.Clamp;
            case BattleInfantryAnimationWrap.ClampForever:
                return WrapMode.ClampForever;
            case BattleInfantryAnimationWrap.Loop:
                return WrapMode.Loop;
            default:
                throw new InvalidOperationException("The observed pose contains an unsupported source wrap mode.");
        }
    }
}
