using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Copies only transforms and static mesh renderers, never recovered gameplay components.</summary>
public static class SelfHostedVisualHierarchy
{
    /// <summary>Preserves the root scale and descendant local poses while leaving root placement to the host.</summary>
    public static void CopyRoot(Transform source, Transform destination, Dictionary<Transform, Transform> copies)
    {
        if (source == null || destination == null || copies == null)
        {
            throw new ArgumentException("A source hierarchy, destination and transform map are required.");
        }

        copies.Add(source, destination);
        destination.localScale = source.localScale;
        CopyRenderer(source, destination);
        for (int index = 0; index < source.childCount; index++)
        {
            Transform sourceChild = source.GetChild(index);
            var child = new GameObject(sourceChild.name);
            child.transform.SetParent(destination, false);
            child.transform.localPosition = sourceChild.localPosition;
            child.transform.localRotation = sourceChild.localRotation;
            child.SetActive(sourceChild.gameObject.activeSelf);
            CopyRoot(sourceChild, child.transform, copies);
        }
    }

    /// <summary>Resolves a copied transform by its complete source sibling/name path.</summary>
    public static Transform ResolveCopy(Transform sourceRoot, Transform sourceTarget, Transform copiedRoot)
    {
        if (sourceRoot == null || sourceTarget == null || copiedRoot == null)
        {
            throw new ArgumentException("A source root, source target and copied root are required.");
        }

        var indexes = new Stack<int>();
        Transform current = sourceTarget;
        while (current != sourceRoot)
        {
            if (current == null)
            {
                throw new InvalidOperationException("The model renderer is outside its source weapon.");
            }

            indexes.Push(current.GetSiblingIndex());
            current = current.parent;
        }

        Transform source = sourceRoot;
        Transform copy = copiedRoot;
        while (indexes.Count > 0)
        {
            int index = indexes.Pop();
            if (copy.childCount != source.childCount || index >= copy.childCount)
            {
                throw new InvalidOperationException("The copied weapon renderer path is incomplete.");
            }

            source = source.GetChild(index);
            copy = copy.GetChild(index);
            if (source.name != copy.name)
            {
                throw new InvalidOperationException("The copied weapon renderer identity differs from its source.");
            }
        }

        return copy;
    }

    private static void CopyRenderer(Transform source, Transform destination)
    {
        MeshFilter sourceFilter = source.GetComponent<MeshFilter>();
        MeshRenderer sourceRenderer = source.GetComponent<MeshRenderer>();
        if (sourceFilter == null || sourceRenderer == null)
        {
            return;
        }

        destination.gameObject.AddComponent<MeshFilter>().sharedMesh = sourceFilter.sharedMesh;
        MeshRenderer renderer = destination.gameObject.AddComponent<MeshRenderer>();
        renderer.sharedMaterials = sourceRenderer.sharedMaterials;
        renderer.enabled = sourceRenderer.enabled;
    }
}
