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
