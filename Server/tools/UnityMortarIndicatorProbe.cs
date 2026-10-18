using System.Collections.Generic;
using System.Reflection;

using UnityEngine;

/// <summary>Records the original warning's actual frame updates, including repeated and short-duration shots.</summary>
[DefaultExecutionOrder(-100)]
public sealed class UnityMortarIndicatorProbe : MonoBehaviour
{
    private const int CaptureRate = 30;
    private const int FirstShotTick = 5;
    private const int RepeatedShotTick = 105;
    private const int LastTick = 240;
    private static readonly MethodInfo BeginIndicator = typeof(Mortar).GetMethod("StartIndicatorAnimation",
        BindingFlags.NonPublic | BindingFlags.Instance);

    [SerializeField] private Mortar _weapon;
    [SerializeField] private PlayerController _localPlayer;
    [SerializeField] private PlayerController _opponent;
    [SerializeField] private float _stopSeconds;
    private readonly List<object> _frames = new List<object>();
    private readonly List<int> _shrinkFinished = new List<int>();
    private readonly List<int> _blinkFinished = new List<int>();
    private int _startFrame;
    private int _tick;
    private bool _isComplete;
    private MissileSetup _setup;

    /// <summary>Gets whether the bounded two-shot observation has ended.</summary>
    public bool IsComplete { get { return _isComplete; } }

    /// <summary>Retains isolated scene references across the Editor's Play Mode domain reload.</summary>
    public void Configure(Mortar weapon, PlayerController localPlayer, PlayerController opponent, float stopSeconds)
    {
        _weapon = weapon;
        _localPlayer = localPlayer;
        _opponent = opponent;
        _stopSeconds = stopSeconds;
    }

    private void Start()
    {
        Time.captureFramerate = CaptureRate;
        _startFrame = Time.frameCount;
        PlayerController.currentPlayer = _localPlayer;
        _weapon.owner = _opponent;
        _setup = _weapon.GetComponent<MissileSetup>();
    }

    private void Update()
    {
        _tick = Time.frameCount - _startFrame;
        if (_tick == FirstShotTick || _tick == RepeatedShotTick)
        {
            BeginIndicator.Invoke(_weapon, new object[]
            {
                _setup, new Vector3(3f, 0.24f, -7f)
            });
            TweenScale shrink = _weapon.indicator.GetComponent<TweenScale>();
            shrink.onFinished += OnShrinkFinished;
        }
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
        var sprite = indicator.GetComponentInChildren<tk2dSprite>(true);
        _frames.Add(new
        {
            tick = _tick, deltaTime = Time.deltaTime, time = Time.time,
            active = indicator.activeSelf, scale = indicator.transform.localScale.x,
            alpha = sprite.color.a,
            rotation = new[] { indicator.transform.localRotation.x, indicator.transform.localRotation.y,
                indicator.transform.localRotation.z, indicator.transform.localRotation.w },
            shrinkFactor = shrink == null ? 0f : shrink.tweenFactor,
            blinkFactor = blink == null ? 0f : blink.tweenFactor,
            rotationFactor = rotation == null ? 0f : rotation.tweenFactor,
            shrinkEnabled = shrink != null && shrink.enabled,
            blinkEnabled = blink != null && blink.enabled
        });
        _isComplete = _tick >= LastTick;
    }

    /// <summary>Returns raw observations without deriving an approximate animation duration.</summary>
    public object ExportObservation()
    {
        return new { name, stopSeconds = _stopSeconds, firstShotTick = FirstShotTick,
            repeatedShotTick = RepeatedShotTick, shrinkFinished = _shrinkFinished,
            blinkFinished = _blinkFinished, frames = _frames };
    }
}
