using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>Observes source cover preparation and its real delayed callback on one side of a corner.</summary>
[DefaultExecutionOrder(0)]
public sealed class UnityGrenadierCornerCallbackProbe : Core_BaseScript
{
    private const int CaptureRate = 30;
    private const int MaximumFrames = 90;
    private const float PriorIdleProgress = 0.5f;
    private const float InitialHideSeconds = 0.7f;
    private const float RoundHideSeconds = 0.5f;
    private const int ExpectedRoundCount = 5;
    private const int HostRoundIntervalTicks = 11;
    private readonly List<object> _rounds = new List<object>();
    private SoldierAnimationController _controller;
    private Animation _animation;
    private Transform _muzzle;
    private string _side;
    private int _preparationFrame;
    private int _callbackFrame = -1;
    private int _callbackTick = -1;
    private int _firstReadyTick = -1;
    private int _currentTick;
    private float _delaySeconds;
    private object _callbackPose;
    private object _firstReadyPose;
    private int _nextRoundTick;

    /// <summary>Reports a completed callback and the next real gameplay Update poll.</summary>
    public bool IsComplete { get { return _rounds.Count == ExpectedRoundCount; } }

    /// <summary>Reports a bounded observation failure for the editor host to stop the process.</summary>
    public string Failure { get; private set; }

    protected override void Start()
    {
        Time.captureFramerate = CaptureRate;
        _side = name.EndsWith("Right", StringComparison.Ordinal) ? "right" : "left";
        _controller = GetComponentInChildren<SoldierAnimationController>(true);
        _animation = GetComponentInChildren<Animation>(true);
        _muzzle = GetComponentsInChildren<Transform>(true)
            .Single(node => node.name == "MachinegunMuzzleFlash" && node.parent.name == "HK416");
        _controller.ForceInScreen();
        _controller.Resume();
        _controller.enabled = true;
        _animation.cullingType = AnimationCullingType.AlwaysAnimate;
        _animation.Stop();
        _animation.Play("pistol_idle");
        _animation["pistol_idle"].normalizedTime = PriorIdleProgress;
        _animation.Sample();
        _preparationFrame = Time.frameCount;
    }

    private void Update()
    {
        _currentTick = Time.frameCount - _preparationFrame;
        if (_currentTick == 0)
        {
            Prepare();
        }
        else if (_callbackFrame >= 0 && _firstReadyTick < 0)
        {
            _firstReadyTick = _currentTick;
            _firstReadyPose = ObserveMuzzle();
            _nextRoundTick = _currentTick;
        }
        else if (_currentTick >= MaximumFrames && !IsComplete)
        {
            Failure = "The source cover callback did not complete inside the bounded observation.";
        }

        if (_firstReadyTick >= 0 && !IsComplete && _currentTick >= _nextRoundTick)
        {
            _rounds.Add(new { tick = _currentTick, pose = ObserveMuzzle() });
            _controller.ShotFromCover(_side == "left", 1f, RoundHideSeconds, false, Weapon.WeaponType.Pistol);
            // The host source catalog emits the next pistol round after eleven fixed ticks; Gun itself is not run here.
            _nextRoundTick = _currentTick + HostRoundIntervalTicks;
        }
    }

    private void Prepare()
    {
        // EnemyController passes the inverse side; the animation controller maps that Boolean back to CoverSide.
        _controller.ShotFromCover(_side == "left", 1f, InitialHideSeconds, false, Weapon.WeaponType.Pistol);
        // EnemyController schedules a 0.7-second pistol callback independently of uncoverLength.
        _delaySeconds = InitialHideSeconds;
        InvokeAfter(RecordCallback, _delaySeconds);
    }

    private void RecordCallback()
    {
        _callbackFrame = Time.frameCount;
        _callbackTick = _currentTick;
        _callbackPose = ObserveMuzzle();
    }

    /// <summary>Exports completed source-local geometry and the actual callback frame binding.</summary>
    public object ExportObservation()
    {
        return new
        {
            side = _side,
            startClip = "player_look_" + _side + "_pistol",
            fireClip = "player_fire_" + _side + "_pistol",
            delaySeconds = _delaySeconds,
            preparationFrame = _preparationFrame,
            callbackFrame = _callbackFrame,
            callbackTick = _callbackTick,
            firstReadyTick = _firstReadyTick,
            callbackPose = _callbackPose,
            firstReadyPose = _firstReadyPose,
            rounds = _rounds
        };
    }

    private object ObserveMuzzle()
    {
        Vector3 position = transform.InverseTransformPoint(_muzzle.position);
        Quaternion rotation = Quaternion.Inverse(transform.rotation) * _muzzle.rotation;
        return new
        {
            position = new[] { position.x, position.y, position.z },
            rotation = new[] { rotation.x, rotation.y, rotation.z, rotation.w },
            states = _animation.Cast<AnimationState>().Where(state => state.enabled)
                .Select(state => new { state.name, state.time, state.normalizedTime, state.weight }).ToArray()
        };
    }
}
