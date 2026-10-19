using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>Records actual Unity fixed/render callbacks while the original timing method changes modes.</summary>
public sealed class UnityHelicopterClockRecorder : MonoBehaviour
{
    private const int CaptureRate = 30;
    private const int RenderFrames = 30;
    private const float NormalPhysicsDelta = 0.02f;
    private readonly List<object> _events = new List<object>();
    private GameObject _timingObject;
    private TimeManager _timing;
    private int _renders;
    private float _initialTime;
    private float _initialFixedTime;
    private bool _isRagdoll;
    private bool _hasPauseFixture;

    public static Action Completed { private get; set; }

    private void Awake()
    {
        if (Time.fixedDeltaTime != NormalPhysicsDelta)
        {
            throw new InvalidOperationException("Automatic clock capture requires the active 20ms profile.");
        }
        Time.captureFramerate = CaptureRate;
        Physics.autoSimulation = true;
        _hasPauseFixture = Environment.GetEnvironmentVariable("WAR_ROPE_CLOCK_PAUSE") == "1";
        _initialTime = Time.time;
        _initialFixedTime = Time.fixedTime;
        _timingObject = new GameObject("InactiveClockTimingManager");
        _timingObject.SetActive(false);
        _timing = _timingObject.AddComponent<TimeManager>();
        typeof(TimeManager).GetField("mDefaultFixedDeltaTime", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(_timing, Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        _events.Add(new { kind = "fixed", frame = Time.frameCount, time = Time.time,
            fixedTime = Time.fixedTime, deltaTime = Time.deltaTime, fixedDeltaTime = Time.fixedDeltaTime,
            ragdoll = _isRagdoll });
    }

    private void Update()
    {
        _renders++;
        bool previousMode = _isRagdoll;
        float previousScale = Time.timeScale;
        if (_renders == 6 || _renders == 18)
        {
            _isRagdoll = true;
        }
        else if (_renders == 12 || _renders == 24)
        {
            _isRagdoll = false;
        }
        _timing.SetupPhysicsTiming(_isRagdoll);
        if (_hasPauseFixture && _renders == 4)
        {
            Time.timeScale = 0;
        }
        else if (_hasPauseFixture && _renders == 7)
        {
            Time.timeScale = 1;
        }
        _events.Add(new { kind = "render", frame = Time.frameCount, time = Time.time,
            fixedTime = Time.fixedTime, deltaTime = Time.deltaTime, fixedDeltaTime = Time.fixedDeltaTime,
            previousRagdoll = previousMode, ragdoll = _isRagdoll,
            previousTimeScale = previousScale, timeScale = Time.timeScale });
        if (_renders == RenderFrames)
        {
            enabled = false;
            WriteReference();
            if (Completed != null)
            {
                Completed();
            }
        }
    }

    private void WriteReference()
    {
        const string TimeSource = "Assets/Scripts/Assembly-CSharp/TimeManager.cs";
        string digest;
        using (var sha = SHA256.Create())
        {
            digest = BitConverter.ToString(sha.ComputeHash(File.ReadAllBytes(TimeSource)))
                .Replace("-", "").ToLowerInvariant();
        }
        string reference = JsonConvert.SerializeObject(new
        {
            version = 1, unity = Application.unityVersion, client = "1.4.0", timeSource = TimeSource,
            timeSha256 = digest, captureRate = CaptureRate, autoSimulation = Physics.autoSimulation,
            hasPauseFixture = _hasPauseFixture,
            initialTime = _initialTime, initialFixedTime = _initialFixedTime, events = _events
        }, Formatting.Indented).Replace("\r\n", "\n") + "\n";
        File.WriteAllText(Environment.GetEnvironmentVariable("WAR_ROPE_CLOCK_OUTPUT"), reference);
        Debug.Log("PASS: automatic source clock renders=" + _renders + ", events=" + _events.Count);
    }

    private void OnDestroy()
    {
        Completed = null;
        Time.timeScale = 1;
        if (_timingObject != null)
        {
            DestroyImmediate(_timingObject);
        }
    }
}
