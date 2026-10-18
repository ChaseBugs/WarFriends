using System.Collections.Generic;
using UnityEngine;

/// <summary>Observes the original half-second InvokeAfter at cold and later gameplay ticks.</summary>
public sealed class UnityGrenadierWeaponReturnProbe : Core_BaseScript
{
    private const int CaptureRate = 30;
    private const int LastTick = 400;
    private const float ReturnDelaySeconds = 0.5f;
    private static readonly int[] ScheduledTicks = { 1, 324, 340 };
    private readonly List<object> _observations = new List<object>();
    private int _startFrame;
    private int _tick;

    /// <summary>Reports completion of all three bounded source coroutine observations.</summary>
    public bool IsComplete { get { return _tick >= LastTick && _observations.Count == ScheduledTicks.Length; } }

    protected override void Start()
    {
        Time.captureFramerate = CaptureRate;
        _startFrame = Time.frameCount;
    }

    private void Update()
    {
        _tick = Time.frameCount - _startFrame;
        foreach (int scheduledTick in ScheduledTicks)
        {
            if (_tick == scheduledTick)
            {
                Schedule(scheduledTick);
            }
        }
    }

    private void Schedule(int scheduledTick)
    {
        float scheduledTime = Time.time;
        InvokeAfter(delegate
        {
            _observations.Add(new { scheduledTick, scheduledTime, callbackTick = _tick, callbackTime = Time.time });
        }, ReturnDelaySeconds);
    }

    /// <summary>Returns observed callback ticks without asserting weapon rendering or controller execution.</summary>
    public object ExportObservation()
    {
        return _observations.ToArray();
    }
}
