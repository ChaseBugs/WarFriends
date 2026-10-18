using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>Observes recovered Colt stand preparation and real coroutine callbacks on the source rig.</summary>
[DefaultExecutionOrder(100)]
public class UnityGunslingerStandProbe : Core_BaseScript
{
    private const int CaptureRate = 30;
    private const int ShotCount = 4;
    private const int MaximumTicks = 150;
    private const float SourceCadenceSeconds = 0.18f;
    private const float SourceHideSeconds = 1f;
    private const float ShotAnimationSpeed = 1f;
    private readonly List<object> _frames = new List<object>();
    private readonly List<object> _preparations = new List<object>();
    private readonly List<object> _callbacks = new List<object>();
    private readonly List<object> _shots = new List<object>();
    private SoldierAnimationController _controller;
    private Animation _animation;
    private Transform _muzzle;
    private int _startFrame;
    private int _tick;
    private int _remainingShots = ShotCount;
    private int _callbackFrame = -1;
    private float _nextPreparationTime;
    private bool _isPending;
    private bool _isShooting;

    /// <summary>Whether the complete bounded animation history was observed.</summary>
    public bool IsComplete { get { return _tick >= MaximumTicks && _shots.Count == ShotCount; } }

    /// <summary>Failure observed by the editor host.</summary>
    public string Failure { get; private set; }

    protected override void Start()
    {
        Time.captureFramerate = CaptureRate;
        _controller = GetComponentInChildren<SoldierAnimationController>(true);
        _animation = GetComponentInChildren<Animation>(true);
        _muzzle = GetComponentsInChildren<Transform>(true).Single(node =>
            node.name == "MachinegunMuzzleFlash" && node.parent.name == "HK416");
        _controller.ForceInScreen();
        _controller.Resume();
        _controller.enabled = true;
        _animation.cullingType = AnimationCullingType.AlwaysAnimate;
        _animation.Stop();
        _animation.Play("colt_idle01");
        _animation.Sample();
        _startFrame = Time.frameCount;
        _nextPreparationTime = Time.time;
    }

    protected void Update()
    {
        _tick = Time.frameCount - _startFrame;
        if (_tick > MaximumTicks)
        {
            if (_shots.Count != ShotCount)
            {
                Failure = "The native Colt observation did not fire its four scheduled source attempts.";
            }
            return;
        }

        _frames.Add(new { tick = _tick, phase = "probe-update-entry", pose = ObservePose() });
        if (_isShooting && Time.frameCount > _callbackFrame)
        {
            _shots.Add(new { tick = _tick, time = Time.time, pose = ObservePose() });
            _isShooting = false;
            _isPending = false;
            _nextPreparationTime = Time.time + SourceCadenceSeconds;
        }

        if (!_isPending && _remainingShots > 0 && Time.time > _nextPreparationTime)
        {
            Prepare();
        }
    }

    protected void LateUpdate()
    {
        if (_tick <= MaximumTicks)
        {
            _frames.Add(new { tick = _tick, phase = "probe-late-update", pose = ObservePose() });
        }
    }

    private void Prepare()
    {
        _remainingShots--;
        _isPending = true;
        _controller.ShootStandNew(Weapon.WeaponType.Colt, ShotAnimationSpeed, SourceHideSeconds);
        float delay = _controller.GetStandPhase0Length(Weapon.WeaponType.Colt);
        _preparations.Add(new { tick = _tick, time = Time.time, delaySeconds = delay, pose = ObservePose() });
        InvokeAfter(RecordCallback, delay);
    }

    private void RecordCallback()
    {
        _callbackFrame = Time.frameCount;
        _callbacks.Add(new { tick = _tick, time = Time.time, pose = ObservePose() });
        _isShooting = true;
    }

    private object ObservePose()
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

    /// <summary>Returns actual source-method observations; Gun physics and EnemyController are not executed.</summary>
    public object ExportObservation()
    {
        return new { scenario = name, preparations = _preparations, callbacks = _callbacks,
            shots = _shots, frames = _frames };
    }
}
