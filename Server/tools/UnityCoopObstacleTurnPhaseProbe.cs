using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.AI;

/// <summary>Records roots before ordinary tween Update and after it on the native moving agent.</summary>
[DefaultExecutionOrder(-10)]
public sealed class UnityCoopObstacleTurnPhaseProbe : MonoBehaviour
{
    private const int MaximumFrames = 120;
    private readonly List<object> _samples = new List<object>();
    private NavMeshAgent _agent;
    private TweenRotation _tween;
    private int _initialFrame;
    private int _tick;
    private string _outputPath;
    private float[] _beforeRotation;
    private float[] _velocity;
    private bool _enabledBeforeUpdate;

    /// <summary>Starts a bounded observation after the exporter creates the source tween.</summary>
    public void Initialize(NavMeshAgent agent)
    {
        _agent = agent;
        _tween = agent.GetComponent<TweenRotation>();
        _initialFrame = Time.frameCount;
        _outputPath = Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_TURN_PHASE_OUTPUT");
    }

    private void Update()
    {
        if (_agent == null)
        {
            return;
        }

        _tick = Time.frameCount - _initialFrame;
        _beforeRotation = Values(transform.rotation);
        _velocity = Values(_agent.velocity);
        _enabledBeforeUpdate = _tween.enabled;
    }

    private void LateUpdate()
    {
        if (_agent == null || _beforeRotation == null)
        {
            return;
        }
        if (_samples.Count >= MaximumFrames)
        {
            throw new InvalidOperationException("The root phase probe exceeded its frame bound.");
        }

        _samples.Add(new
        {
            tick = _tick,
            unityFrame = Time.frameCount,
            deltaSeconds = Time.deltaTime,
            smoothDeltaSeconds = Time.smoothDeltaTime,
            unscaledDeltaSeconds = Time.unscaledDeltaTime,
            beforeRotation = _beforeRotation,
            afterRotation = Values(transform.rotation),
            velocity = _velocity,
            tweenEnabledBefore = _enabledBeforeUpdate,
            tweenEnabledAfter = _tween.enabled
        });
        File.WriteAllText(_outputPath, JsonConvert.SerializeObject(new
        {
            version = 1,
            unity = Application.unityVersion,
            phase = "Update order -10 after Start; LateUpdate after ordinary TweenRotation.Update",
            samples = _samples
        }, Formatting.Indented));
    }

    private static float[] Values(Quaternion value)
    {
        return new[] { value.x, value.y, value.z, value.w };
    }

    private static float[] Values(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }
}
