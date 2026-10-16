using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>Records native collider queries before the editor-driven volley callback.</summary>
[DefaultExecutionOrder(0)]
public sealed class UnityCoopObstacleQueryProbe : MonoBehaviour
{
    /// <summary>Supplies the editor-owned clock without a runtime reference to an editor assembly.</summary>
    public static Func<int> ReadGameplayTick { private get; set; }

    /// <summary>Invokes source OnShot behavior after capturing the current firing transforms.</summary>
    public static Action<int> EmitGameplayRound { private get; set; }

    private const string OutputVariable = "WAR_COOP_OBSTACLE_QUERY_OUTPUT";
    private const int MaximumSamples = 240;
    private const float RayOffset = 2f;
    private const float RayDistance = 4f;
    private readonly List<object> _samples = new List<object>();
    private Collider[] _colliders;
    private string _outputPath;
    private Transform _muzzle;
    private Animation _animation;

    private void Awake()
    {
        _outputPath = Environment.GetEnvironmentVariable(OutputVariable);
        _colliders = GetComponentsInChildren<Collider>(true);
        _muzzle = GetComponentsInChildren<Transform>(true)
            .Single(node => node.name == "MachinegunMuzzleFlash" && node.parent.name == "HK416");
        _animation = GetComponentInChildren<Animation>(true);
    }

    private void Update()
    {
        int tick = ReadGameplayTick == null ? -1 : ReadGameplayTick();
        if (ReadGameplayTick != null && tick < 0)
        {
            return;
        }

        if (_samples.Count >= MaximumSamples)
        {
            throw new InvalidOperationException("The collider query probe exceeded its sample bound.");
        }

        List<object> queries = CaptureQueries();
        _samples.Add(new
        {
            tick,
            unityFrame = Time.frameCount,
            scaledTime = Time.time,
            muzzle = Values(transform.InverseTransformPoint(_muzzle.position)),
            states = _animation.Cast<AnimationState>().Where(state => state.enabled)
                .Select(state => new { state.name, state.time, state.normalizedTime, state.weight }).ToArray(),
            queries
        });
        if (EmitGameplayRound != null)
        {
            EmitGameplayRound(tick);
        }

        Persist();
    }

    private List<object> CaptureQueries()
    {
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

        return queries;
    }

    private void Persist()
    {
        // Persist each bounded sample because the existing exporter owns process termination.
        File.WriteAllText(_outputPath, JsonConvert.SerializeObject(new
        {
            version = EmitGameplayRound == null ? 1 : 2,
            unity = Application.unityVersion,
            samplePhase = EmitGameplayRound == null
                ? "MonoBehaviour.Update order 0; rounds remain editor-driven"
                : "MonoBehaviour.Update order 0; capture before source ShootFromCrawl",
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
