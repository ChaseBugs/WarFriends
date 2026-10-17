using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Builds a recovered infantry appearance without activating local AI, collision or Photon components.
/// </summary>
public static class SelfHostedInfantryVisualFactory
{
    /// <summary>
    /// Creates an inactive rig for an explicitly selected source style; it chooses no random appearance.
    /// </summary>
    public static SelfHostedInfantryVisual Create(EnemyController source,
        SoldierMeshChanger.SoldierStyle style, string rootName)
    {
        ValidateSource(source, style, rootName);
        var root = new GameObject(rootName);
        root.SetActive(false);
        try
        {
            var rig = new GameObject("Rig");
            rig.transform.SetParent(root.transform, false);
            var copies = new Dictionary<Transform, Transform>();
            SelfHostedVisualHierarchy.CopyRoot(source.transform, rig.transform, copies);
            SkinnedMeshRenderer body = CopyBody(source.meshChanger.skinnedMeshRenderer, style, copies);
            CopyHelmets(source.meshChanger.helmet, style, copies);
            Animation animation = source.GetComponentInChildren<Animation>(true);
            if (animation == null || !copies.ContainsKey(animation.transform))
            {
                throw new InvalidOperationException("Recovered infantry animation hierarchy is absent.");
            }

            return new SelfHostedInfantryVisual(root, copies[animation.transform].gameObject, body);
        }
        catch
        {
            // A rejected style must not leave a partly constructed actor for a later snapshot to reuse.
            if (Application.isPlaying)
            {
                UnityEngine.Object.Destroy(root);
            }
            else
            {
                UnityEngine.Object.DestroyImmediate(root);
            }

            throw;
        }
    }

    private static void ValidateSource(EnemyController source, SoldierMeshChanger.SoldierStyle style, string rootName)
    {
        if (source == null || source.meshChanger == null || style == null || string.IsNullOrEmpty(rootName))
        {
            throw new ArgumentException("A recovered enemy rig, selected style and visual name are required.");
        }

        style.LoadModel();
        SkinnedMeshRenderer skeleton = source.meshChanger.skinnedMeshRenderer;
        if (style.modelMeshRenderer == null || style.modelMeshRenderer.sharedMesh == null ||
            skeleton == null || skeleton.bones == null || skeleton.rootBone == null)
        {
            throw new InvalidOperationException("Recovered infantry mesh or skeleton is absent.");
        }
    }

    private static SkinnedMeshRenderer CopyBody(SkinnedMeshRenderer source,
        SoldierMeshChanger.SoldierStyle style, Dictionary<Transform, Transform> copies)
    {
        SkinnedMeshRenderer body = copies[source.transform].gameObject.AddComponent<SkinnedMeshRenderer>();
        body.sharedMesh = style.modelMeshRenderer.sharedMesh;
        body.sharedMaterials = style.modelMeshRenderer.sharedMaterials;
        var bones = new Transform[source.bones.Length];
        for (int index = 0; index < bones.Length; index++)
        {
            bones[index] = copies[source.bones[index]];
        }

        body.bones = bones;
        body.rootBone = copies[source.rootBone];
        body.localBounds = source.localBounds;
        body.updateWhenOffscreen = source.updateWhenOffscreen;
        return body;
    }

    private static void CopyHelmets(FakeRigidBodySwapper source, SoldierMeshChanger.SoldierStyle style,
        Dictionary<Transform, Transform> copies)
    {
        if (source == null)
        {
            return;
        }
        if (source.NoRigidBodyObject == null || source.RigidBodyObject == null)
        {
            throw new InvalidOperationException("Recovered infantry helmet hierarchy is absent.");
        }

        CopyHelmet(source.NoRigidBodyObject.transform, style, copies);
        CopyHelmet(source.RigidBodyObject.transform, style, copies);
        // FakeRigidBodySwapper.SetMesh resets to the attached form even when the selected mesh is null.
        copies[source.NoRigidBodyObject.transform].gameObject.SetActive(true);
        copies[source.RigidBodyObject.transform].gameObject.SetActive(false);
        copies[source.RigidBodyObject.transform].localScale = Vector3.one;
    }

    private static void CopyHelmet(Transform source, SoldierMeshChanger.SoldierStyle style,
        Dictionary<Transform, Transform> copies)
    {
        MeshFilter filter = copies[source].GetComponent<MeshFilter>();
        if (filter == null)
        {
            throw new InvalidOperationException("Recovered infantry helmet mesh is absent.");
        }

        filter.sharedMesh = style.helmetMesh;
        MeshRenderer renderer = copies[source].GetComponent<MeshRenderer>();
        if (renderer != null && style.helmetMaterials != null && style.helmetMaterials.Count > 0)
        {
            renderer.sharedMaterials = style.helmetMaterials.ToArray();
        }
    }
}
