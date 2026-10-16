using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>Measures the recovered InvokeAfter callback and its next gameplay Update poll.</summary>
public sealed class UnityCoopDelayedShotProbe : Core_BaseScript
{
    private const float SourceCallbackPaddingSeconds = 0.05f;
    private string _outputPath;
    private int _currentTick;
    private int _preparationFrame;
    private int _callbackFrame = -1;
    private int _callbackTick = -1;
    private int _firstReadyTick = -1;
    private float _preparationTime;
    private float _callbackTime;
    private float _callbackDelay;
    private Transform _muzzle;
    private Animation _animation;
    private object _callbackPose;
    private object _firstReadyPose;

    /// <summary>Starts the source delay after preparation and observes readiness on later Update polls.</summary>
    public void ObserveGameplay(int tick)
    {
        _currentTick = tick;
        if (tick == 0)
        {
            BeginDelay();
        }
        else if (_callbackFrame >= 0 && _firstReadyTick < 0)
        {
            _firstReadyTick = tick;
            _firstReadyPose = ObserveMuzzle();
            Persist();
        }
    }

    private void BeginDelay()
    {
        _outputPath = Environment.GetEnvironmentVariable("WAR_COOP_OBSTACLE_DELAY_OUTPUT");
        SoldierAnimationController controller = GetComponentInChildren<SoldierAnimationController>(true);
        _muzzle = GetComponentsInChildren<Transform>(true)
            .Single(node => node.name == "MachinegunMuzzleFlash" && node.parent.name == "HK416");
        _animation = GetComponentInChildren<Animation>(true);
        _callbackDelay = controller.GetStandUpFromCrawlLength(Weapon.WeaponType.Riffle) +
            SourceCallbackPaddingSeconds;
        _preparationFrame = Time.frameCount;
        _preparationTime = Time.time;
        InvokeAfter(RecordCallback, _callbackDelay);
    }

    private void RecordCallback()
    {
        _callbackFrame = Time.frameCount;
        _callbackTick = _currentTick;
        _callbackTime = Time.time;
        _callbackPose = ObserveMuzzle();
        Persist();
    }

    private void Persist()
    {
        File.WriteAllText(_outputPath, JsonConvert.SerializeObject(new
        {
            version = 2,
            unity = Application.unityVersion,
            captureRate = Time.captureFramerate,
            timeScale = Time.timeScale,
            callbackDelay = _callbackDelay,
            preparationFrame = _preparationFrame,
            preparationTime = _preparationTime,
            callbackFrame = _callbackFrame,
            callbackTick = _callbackTick,
            callbackTime = _callbackTime,
            firstReadyTick = _firstReadyTick,
            callbackPose = _callbackPose,
            firstReadyPose = _firstReadyPose,
            source = "Core_BaseScript.InvokeAfter -> WaitAndCall -> WaitForSeconds"
        }, Formatting.Indented));
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
