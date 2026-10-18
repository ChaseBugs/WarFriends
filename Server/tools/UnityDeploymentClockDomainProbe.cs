using System.Collections.Generic;

using UnityEngine;

/// <summary>Compares the recovered real-time deployment wait with scaled body-owned waits.</summary>
public sealed class UnityDeploymentClockDomainProbe : Core_BaseScript
{
    private const int CaptureRate = 30;
    private const float SpawnWaitSeconds = 0.3f;
    private const float HideDelaySeconds = 2f;
    private const float ReturnDelaySeconds = 1f;
    private const float ResumeAfterRealSeconds = 0.45f;
    private const float WatchdogRealSeconds = 10f;
    private readonly List<object> _events = new List<object>();
    private WaitForRealSeconds _spawnWait;
    private float _startRealTime;
    private float _startGameTime;
    private bool _hasResumed;
    private bool _hasHidden;
    private bool _hasReturned;
    private bool _isComplete;
    private string _failureReason;

    /// <summary>Gets whether the observation has completed or reached its bounded watchdog.</summary>
    public bool IsComplete { get { return _isComplete; } }

    /// <summary>Gets whether real-time readiness preceded both scaled callbacks during pause.</summary>
    public bool HasPassed { get { return _isComplete && string.IsNullOrEmpty(_failureReason); } }

    private void Start()
    {
        Time.captureFramerate = CaptureRate;
        Time.timeScale = 0f;
        _startRealTime = Time.realtimeSinceStartup;
        _startGameTime = Time.time;
        _spawnWait = new WaitForRealSeconds(SpawnWaitSeconds);
        InvokeAfter(OnHide, HideDelaySeconds);
        Record("scheduled-paused");
    }

    private void Update()
    {
        float realElapsed = Time.realtimeSinceStartup - _startRealTime;
        if (!_hasResumed && realElapsed >= ResumeAfterRealSeconds)
        {
            if (!_spawnWait.finished || _hasHidden || _hasReturned || Time.time != _startGameTime)
            {
                Fail("Real-time deployment readiness and paused body waits did not separate.");
                return;
            }
            Record("real-wait-ready-while-paused");
            _hasResumed = true;
            Time.timeScale = 1f;
        }
        if (!_isComplete && realElapsed > WatchdogRealSeconds)
        {
            Fail("The bounded scaled-wait observation did not complete.");
        }
    }

    private void OnHide()
    {
        if (!_hasResumed)
        {
            Fail("The scaled hide callback ran while timeScale was zero.");
            return;
        }
        _hasHidden = true;
        Record("hide-callback");
        InvokeAfter(OnReturn, ReturnDelaySeconds);
    }

    private void OnReturn()
    {
        _hasReturned = true;
        Record("return-callback");
        _isComplete = true;
    }

    private void Fail(string reason)
    {
        _failureReason = reason;
        _isComplete = true;
    }

    private void Record(string transition)
    {
        _events.Add(new
        {
            transition, frame = Time.frameCount, gameElapsed = Time.time - _startGameTime,
            realElapsed = Time.realtimeSinceStartup - _startRealTime, deltaTime = Time.deltaTime,
            timeScale = Time.timeScale, realWaitFinished = _spawnWait.finished,
            hasHidden = _hasHidden, hasReturned = _hasReturned
        });
    }

    /// <summary>Exports clock readiness only; this is not a spawn coroutine scheduling-order proof.</summary>
    public object ExportObservation()
    {
        return new { hasPassed = HasPassed, failureReason = _failureReason, events = _events.ToArray() };
    }
}
