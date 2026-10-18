using System.Collections.Generic;
using System.Reflection;

using UnityEngine;

/// <summary>Observes original reuse callbacks from one viewer without allocating Photon pool objects.</summary>
[DefaultExecutionOrder(-100)]
public sealed class UnityMortarIndicatorReuseProbe : MonoBehaviour
{
    private const int CaptureRate = 30;
    private const int LastTick = 360;
    private static readonly MethodInfo BeginIndicator = typeof(Mortar).GetMethod("StartIndicatorAnimation",
        BindingFlags.NonPublic | BindingFlags.Instance);
    [SerializeField] private Mortar _weapon;
    [SerializeField] private PlayerController _localPlayer;
    [SerializeField] private PlayerController[] _owners;
    private readonly List<object> _frames = new List<object>();
    private readonly List<int> _shrinkFinished = new List<int>();
    private readonly List<int> _blinkFinished = new List<int>();
    private MissileSetup _setup;
    private int _startFrame;
    private int _tick;
    private int _indicatorIdentity;
    private bool _isComplete;

    /// <summary>Gets whether every source frame has been recorded.</summary>
    public bool IsComplete { get { return _isComplete; } }

    /// <summary>Retains source shells across the Play Mode domain reload.</summary>
    public void Configure(Mortar weapon, PlayerController localPlayer, PlayerController[] owners)
    {
        _weapon = weapon;
        _localPlayer = localPlayer;
        _owners = owners;
    }

    private void Start()
    {
        Time.captureFramerate = CaptureRate;
        _startFrame = Time.frameCount;
        _setup = _weapon.GetComponent<MissileSetup>();
        _indicatorIdentity = _weapon.indicator.GetInstanceID();
        ReassignOwner(0);
    }

    private void Update()
    {
        _tick = Time.frameCount - _startFrame;
        if (_tick == 85 || _tick == 220)
        {
            ReassignOwner(1);
        }
        else if (_tick == 170 || _tick == 285)
        {
            ReassignOwner(0);
        }
        if (_tick == 5 || _tick == 90 || _tick == 175 || _tick == 200 || _tick == 225 || _tick == 290)
        {
            PlayerController.currentPlayer = _localPlayer;
            BeginIndicator.Invoke(_weapon, new object[] { _setup, new Vector3(3f, 0.24f, -7f) });
            TweenScale shrink = _weapon.indicator.GetComponent<TweenScale>();
            if (_weapon.fraction != _localPlayer.fraction && shrink != null)
            {
                shrink.onFinished += OnShrinkFinished;
            }
        }
    }

    private void ReassignOwner(int ownerIndex)
    {
        _weapon.owner = _owners[ownerIndex];
        _weapon.OnInstancied();
    }

    private void OnShrinkFinished(UITweener tween)
    {
        _shrinkFinished.Add(_tick);
        _weapon.indicator.GetComponent<TweenColorTk2d>().onFinished += OnBlinkFinished;
    }

    private void OnBlinkFinished(UITweener tween)
    {
        _blinkFinished.Add(_tick);
    }

    private void LateUpdate()
    {
        if (_tick > LastTick)
        {
            return;
        }
        GameObject indicator = _weapon.indicator;
        TweenScale shrink = indicator.GetComponent<TweenScale>();
        TweenColorTk2d blink = indicator.GetComponent<TweenColorTk2d>();
        TweenRotationSpecial rotation = indicator.GetComponent<TweenRotationSpecial>();
        _frames.Add(new
        {
            tick = _tick, deltaTime = Time.deltaTime, active = indicator.activeSelf,
            localFraction = (int)_localPlayer.fraction, ownerFraction = (int)_weapon.fraction,
            sameIndicatorObject = indicator.GetInstanceID() == _indicatorIdentity,
            scale = indicator.transform.localScale.x,
            alpha = indicator.GetComponentInChildren<tk2dSprite>(true).color.a,
            shrinkFactor = shrink == null ? 0f : shrink.tweenFactor,
            blinkFactor = blink == null ? 0f : blink.tweenFactor,
            rotationFactor = rotation == null ? 0f : rotation.tweenFactor,
            shrinkEnabled = shrink != null && shrink.enabled,
            blinkEnabled = blink != null && blink.enabled
        });
        _isComplete = _tick >= LastTick;
    }

    /// <summary>Returns source lifecycle data; pool allocation and networking are deliberately not exercised.</summary>
    public object ExportObservation()
    {
        return new { name, localFraction = (int)_localPlayer.fraction, stopSeconds = _setup.stopTime,
            reassignTicks = new[] { 0, 85, 170, 220, 285 }, fireTicks = new[] { 5, 90, 175, 200, 225, 290 },
            shrinkFinished = _shrinkFinished, blinkFinished = _blinkFinished, frames = _frames };
    }
}
