using System.Collections.Generic;
using System.Linq;

using UnityEngine;

/// <summary>Observes recovered Mortar animation and swapper methods around the strict construction deadline.</summary>
[DefaultExecutionOrder(100)]
public class UnityMortarPreparationProbe : Core_BaseScript
{
    private const int CaptureRate = 30;
    private const int MaximumTicks = 440;
    private const float BuildSeconds = 2f;
    private readonly List<object> _frames = new List<object>();
    private SoldierAnimationController _controller;
    private Animation _animation;
    private FakeRigidBodySwapper _swapper;
    private int _startFrame;
    private int _tick;
    private int _preparedTick = -1;
    private float _constructionDeadline;
    private bool _isBuilding;

    public Transform WorldRoot;
    public bool IsComplete { get { return _tick >= MaximumTicks; } }

    protected override void Start()
    {
        Time.captureFramerate = CaptureRate;
        _controller = GetComponentInChildren<SoldierAnimationController>(true);
        _animation = GetComponentInChildren<Animation>(true);
        _swapper = GetComponentInChildren<FakeRigidBodySwapper>(true);
        _controller.ForceInScreen();
        _controller.Resume();
        _controller.enabled = true;
        _animation.cullingType = AnimationCullingType.AlwaysAnimate;
        _animation.Stop();
        _animation.Play("mortar_run");
        _animation.Sample();
        _swapper.Swap(false);
        _startFrame = Time.frameCount;
    }

    protected void Update()
    {
        _tick = Time.frameCount - _startFrame;
        if (_tick > MaximumTicks)
        {
            return;
        }
        Observe("update-entry");
        if (_tick == 5 || _tick == 305)
        {
            _controller.BuildMortar();
            _constructionDeadline = Time.time + BuildSeconds;
            _isBuilding = true;
            Observe("build-called");
        }
        if (_isBuilding && Time.time > _constructionDeadline)
        {
            Prepare();
        }
        if (_preparedTick >= 0 && _tick == _preparedTick + 2)
        {
            transform.rotation *= Quaternion.Euler(0f, 17f, 0f);
            Observe("synthetic-root-turn");
        }
    }

    private void Prepare()
    {
        _isBuilding = false;
        _preparedTick = _tick;
        Observe("before-fire");
        _controller.FiredMortar();
        Observe("after-animation-call");
        _swapper.SetParent(WorldRoot);
        Observe("after-world-detach");
        InvokeAfter(delegate
        {
            _swapper.Swap(false);
            Observe("hand-return-callback");
        }, _controller.mortarShotTime);
    }

    protected void LateUpdate()
    {
        if (_tick <= MaximumTicks)
        {
            Observe("late-update");
        }
    }

    private void Observe(string phase)
    {
        Transform snap = _swapper.snapPoint.transform;
        _frames.Add(new
        {
            tick = _tick,
            phase,
            time = Time.time,
            rootPosition = Vector(transform.position),
            rootRotation = Rotation(transform.rotation),
            snapPosition = Vector(snap.position),
            snapRotation = Rotation(snap.rotation),
            snapScale = Vector(snap.lossyScale),
            localPosition = Vector(transform.InverseTransformPoint(snap.position)),
            localRotation = Rotation(Quaternion.Inverse(transform.rotation) * snap.rotation),
            detached = snap.parent == WorldRoot,
            clips = _animation.Cast<AnimationState>().Where(state => state.enabled).Select(state => new
            {
                state.name, state.time, state.weight, state.speed
            }).ToArray()
        });
    }

    /// <summary>Returns observed engine state without asserting full native gameplay order.</summary>
    public object ExportObservation()
    {
        return new { scenario = name, frames = _frames };
    }

    private static float[] Vector(Vector3 value)
    {
        return new[] { value.x, value.y, value.z };
    }

    private static float[] Rotation(Quaternion value)
    {
        return new[] { value.x, value.y, value.z, value.w };
    }
}
