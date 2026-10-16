using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>Records native collider queries before the editor-driven volley callback.</summary>
[DefaultExecutionOrder(0)]
public sealed class UnityCoopObstacleQueryProbe : MonoBehaviour
{
    private const string OutputVariable = "WAR_COOP_OBSTACLE_QUERY_OUTPUT";
    private const int MaximumSamples = 240;
    private const float RayOffset = 2f;
    private const float RayDistance = 4f;
    private readonly List<object> _samples = new List<object>();
    private Collider[] _colliders;
    private string _outputPath;

    private void Awake()
    {
        _outputPath = Environment.GetEnvironmentVariable(OutputVariable);
        _colliders = GetComponentsInChildren<Collider>(true);
    }

    private void Update()
    {
        if (_samples.Count >= MaximumSamples)
        {
            throw new InvalidOperationException("The collider query probe exceeded its sample bound.");
        }

        var queries = new List<object>();
        foreach (Collider collider in _colliders)
        {
            BoxCollider box = collider as BoxCollider;
            SphereCollider sphere = collider as SphereCollider;
            if (box == null && sphere == null)
            {
                continue;
            }

            Vector3 localCenter = box != null ? box.center : sphere.center;
            Vector3 center = collider.transform.TransformPoint(localCenter);
            Vector3 origin = center - Vector3.forward * RayOffset;
            RaycastHit hit;
            bool hasHit = collider.Raycast(new Ray(origin, Vector3.forward), out hit, RayDistance);
            queries.Add(new
            {
                path = RelativePath(collider.transform),
                kind = box != null ? "box" : "sphere",
                center = Values(center),
                rootLocalCenter = Values(transform.InverseTransformPoint(center)),
                rotation = Values(collider.transform.rotation),
                scale = Values(collider.transform.lossyScale),
                size = Values(box != null ? box.size : Vector3.zero),
                radius = sphere != null ? sphere.radius : 0f,
                enabled = collider.enabled,
                active = collider.gameObject.activeInHierarchy,
                origin = Values(origin),
                hasHit,
                distance = hasHit ? hit.distance : 0f,
                point = Values(hasHit ? hit.point : Vector3.zero)
            });
        }

        _samples.Add(new { unityFrame = Time.frameCount, scaledTime = Time.time, queries });
        // Persist each bounded sample because the existing exporter owns process termination.
        File.WriteAllText(_outputPath, JsonConvert.SerializeObject(new
        {
            version = 1,
            unity = Application.unityVersion,
            samplePhase = "MonoBehaviour.Update order 0; rounds remain editor-driven",
            autoSyncTransforms = Physics.autoSyncTransforms,
            queriesHitTriggers = Physics.queriesHitTriggers,
            rayDirection = Values(Vector3.forward),
            rayDistance = RayDistance,
            samples = _samples
        }, Formatting.Indented));
    }

    private string RelativePath(Transform node)
    {
        return node == transform ? string.Empty : RelativePath(node.parent) + "/" + node.name;
    }

    private static float[] Values(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }

    private static float[] Values(Quaternion value)
    {
        return new[] { value.x, value.y, value.z, value.w };
    }
}
