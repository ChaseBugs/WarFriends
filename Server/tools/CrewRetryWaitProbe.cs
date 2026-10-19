using System.Collections.Generic;

using UnityEngine;

/// <summary>Observes the original InvokeAfter coroutine across scaled pause and two consecutive waits.</summary>
public sealed class CrewRetryWaitProbe : Core_BaseScript
{
    private const float RetrySeconds = 5f;
    private readonly List<object> _frames = new List<object>();
    private readonly List<object> _callbacks = new List<object>();
    private int _startFrame;
    private object _start;

    /// <summary>Reports when both source coroutine callbacks have completed.</summary>
    public bool IsComplete
    {
        get
        {
            return _callbacks.Count == 2;
        }
    }

    private void Start()
    {
        _startFrame = Time.frameCount;
        _start = new { frame = Time.frameCount, time = Time.time };
        InvokeAfter(OnRetry, RetrySeconds);
    }

    private void Update()
    {
        int elapsed = Time.frameCount - _startFrame;
        if (elapsed < 10)
        {
            Time.timeScale = 1;
        }
        else if (elapsed < 20)
        {
            Time.timeScale = 0;
        }
        else if (elapsed < 50)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1.5f;
        }
    }

    private void OnRetry()
    {
        _callbacks.Add(new { frame = Time.frameCount, time = Time.time });
        if (_callbacks.Count < 2)
        {
            InvokeAfter(OnRetry, RetrySeconds);
        }
    }

    private void LateUpdate()
    {
        _frames.Add(new
        {
            frame = Time.frameCount, time = Time.time, delta = Time.deltaTime,
            scale = Time.timeScale, callbacks = _callbacks.Count
        });
    }

    /// <summary>Returns the original start, late-frame observations and callback timestamps.</summary>
    public object Capture()
    {
        return new { start = _start, frames = _frames.ToArray(), callbacks = _callbacks.ToArray() };
    }
}
