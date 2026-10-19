using System.Collections.Generic;
using System.Reflection;

using UnityEngine;

/// <summary>Records each actual virtual Update after the original implementation has executed.</summary>
public sealed class CrewEntryLifecycleProbe : TweenRotation
{
    private List<object> _rows = new List<object>();
    private Quaternion _from;
    private Quaternion _target;
    private float _beginRealtime;
    private float _enabledAt;

    protected override void OnEnable()
    {
        base.OnEnable();
        _enabledAt = (float)typeof(IgnoreTimeScale).GetField("mTimeStart",
            BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this);
    }

    /// <summary>Invokes source Begin on this component without replacing its retained clock.</summary>
    public void BeginCycle(Quaternion target)
    {
        _rows = new List<object>();
        TweenRotation.Begin(gameObject, 0.3f, target);
        _from = Quaternion.Euler(from);
        _target = Quaternion.Euler(to);
        _beginRealtime = Time.realtimeSinceStartup;
    }

    protected override void Update()
    {
        base.Update();
        _rows.Add(new
        {
            frame = Time.frameCount, realtime = realTime,
            delta = realTimeDelta, scaledDelta = Time.deltaTime,
            factor = tweenFactor, enabled, localRotation = Values(transform.localRotation),
            rotation = Values(transform.rotation)
        });
    }

    /// <summary>Returns endpoints, actual OnEnable origin and the completed cycle's automatic observations.</summary>
    public object Capture()
    {
        return new
        {
            from = Values(_from), target = Values(_target), beginRealtime = _beginRealtime,
            ignoreTimeScale, enabledAt = _enabledAt, rows = _rows.ToArray()
        };
    }

    /// <summary>Preserves source quaternion components without converting through Euler angles.</summary>
    public static float[] Values(Quaternion value)
    {
        return new[] { value.x, value.y, value.z, value.w };
    }
}
