using System.Collections.Generic;
using UnityEngine;

/// <summary>Observes the recovered InvokeAfter coroutine without starting the game's online services.</summary>
public sealed class UnityMortarClockProbe : Core_BaseScript
{
    private const int CaptureRate = 30;
    private const int MaximumTicks = 400;
    private readonly List<Observation> _observations = new List<Observation>();
    private int _startFrame;

    public float HideSeconds;
    public float UpSeconds;
    public bool IsComplete { get; private set; }
    public List<Observation> Observations { get { return _observations; } }

    protected override void Start()
    {
        Time.captureFramerate = CaptureRate;
        _startFrame = Time.frameCount;
    }

    private void Update()
    {
        int tick = Time.frameCount - _startFrame;
        foreach (Observation observation in _observations)
        {
            if (observation.callbackTick.HasValue && !observation.pollTick.HasValue)
            {
                observation.pollTick = tick;
            }
            if (!observation.relocationTick.HasValue && Time.time > observation.deadline)
            {
                observation.relocationTick = tick;
            }
        }
        if (tick == 5 || tick == 65 || tick == 305)
        {
            Prepare(tick);
        }
        IsComplete = tick >= MaximumTicks;
    }

    private void Prepare(int tick)
    {
        var observation = new Observation
        {
            preparedTick = tick, preparedTime = Time.time,
            deadline = Time.time + HideSeconds + UpSeconds
        };
        _observations.Add(observation);
        InvokeAfter(delegate { observation.callbackTick = Time.frameCount - _startFrame; }, 0.3f);
        InvokeAfter(delegate { observation.handReturnTick = Time.frameCount - _startFrame; }, HideSeconds);
    }

    /// <summary>Records source coroutine and strict Update transitions without approximating their clocks.</summary>
    public sealed class Observation
    {
        public int preparedTick;
        public float preparedTime;
        public float deadline;
        public int? callbackTick;
        public int? pollTick;
        public int? handReturnTick;
        public int? relocationTick;
    }
}
