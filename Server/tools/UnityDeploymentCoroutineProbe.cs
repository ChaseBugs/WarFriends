using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>Observes the original RadicalRoutine wrapper and its end-of-frame wait under pause.</summary>
public sealed class UnityDeploymentCoroutineProbe : Core_BaseScript
{
    private const int CaptureRate = 30;
    private const float SourceWaitSeconds = 0.3f;
    private const float HideDelaySeconds = 2f;
    private const float ReturnDelaySeconds = 1f;
    private const float ObservationLimitSeconds = 10f;
    private readonly List<object> _events = new List<object>();
    private WaitForRealSeconds _wait;
    private float _startRealTime;
    private int _lastUpdateFrame;
    private int _lastLateUpdateFrame;
    private bool _hasResumed;
    private bool _hasHidden;
    private bool _hasReturned;
    private bool _isComplete;

    /// <summary>Gets whether the bounded observation has ended.</summary>
    public bool IsComplete { get { return _isComplete; } }

    private void Start()
    {
        Time.captureFramerate = CaptureRate;
        Time.timeScale = 0f;
        Application.runInBackground = true;
        _startRealTime = Time.realtimeSinceStartup;
        InvokeAfter(OnHide, HideDelaySeconds);
        StartCoroutine(RadicalRoutine.Run(ObserveSourceWait()));
    }

    private IEnumerator ObserveSourceWait()
    {
        _wait = new WaitForRealSeconds(SourceWaitSeconds);
        Record("before-source-wait");
        yield return _wait;
        _hasResumed = true;
        Record("after-source-wait");
        Time.timeScale = 1f;
    }

    private void OnHide()
    {
        _hasHidden = true;
        Record("hide-callback");
        InvokeAfter(OnReturn, ReturnDelaySeconds);
    }

    private void OnReturn()
    {
        _hasReturned = true;
        Record("return-callback");
    }

    private void Update()
    {
        _lastUpdateFrame = Time.frameCount;
        if (!_isComplete && (_hasResumed && _hasReturned ||
            Time.realtimeSinceStartup - _startRealTime >= ObservationLimitSeconds))
        {
            Record("observation-ended");
            _isComplete = true;
        }
    }

    private void LateUpdate()
    {
        _lastLateUpdateFrame = Time.frameCount;
    }

    private void Record(string transition)
    {
        _events.Add(new
        {
            transition, frame = Time.frameCount, gameTime = Time.time,
            realElapsed = Time.realtimeSinceStartup - _startRealTime, timeScale = Time.timeScale,
            realWaitFinished = _wait.finished, hasResumed = _hasResumed,
            hasHidden = _hasHidden, hasReturned = _hasReturned,
            afterCurrentUpdate = _lastUpdateFrame == Time.frameCount,
            afterCurrentLateUpdate = _lastLateUpdateFrame == Time.frameCount
        });
    }

    /// <summary>Separates readiness from a callback that may be unsupported in a batch-mode editor.</summary>
    public object ExportObservation()
    {
        return new
        {
            coroutineResumed = _hasResumed, realWaitFinished = _wait.finished,
            bodyReturned = _hasReturned,
            batchMode = Application.isBatchMode, events = _events.ToArray()
        };
    }
}
