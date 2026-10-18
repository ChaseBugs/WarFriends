using System.Collections.Generic;

using UnityEngine;

/// <summary>Observes recovered wait cancellation and real pool return without starting combat.</summary>
public sealed class UnityPoolReturnClockProbe : MonoBehaviour
{
    private const int CaptureRate = 30;
    private const int FinalTick = 300;
    [SerializeField] private float _delay;
    [SerializeField] private bool _shouldForceReturn;
    [SerializeField] private int _forcedReturnTick;
    private readonly List<object> _events = new List<object>();
    private ObjectPool _pool;
    private PoolableObject _prefab;
    private PoolableObject _body;
    private int _startFrame;
    private int _tick;
    private int _originalIdentity;
    private bool _isComplete;

    /// <summary>Gets whether all scheduled observations have finished.</summary>
    public bool IsComplete { get { return _isComplete; } }

    /// <summary>Records setup across the editor's Play Mode domain reload.</summary>
    public void Configure(float delay, bool shouldForceReturn, int forcedReturnTick)
    {
        _delay = delay;
        _shouldForceReturn = shouldForceReturn;
        _forcedReturnTick = forcedReturnTick;
    }

    private void Start()
    {
        Time.captureFramerate = CaptureRate;
        Time.timeScale = 1f;
        _startFrame = Time.frameCount;
        var template = new GameObject("InactivePoolReturnTemplate");
        template.SetActive(false);
        _prefab = template.AddComponent<PoolableObject>();
        var poolObject = new GameObject("RecoveredReturnPool");
        poolObject.SetActive(false);
        _pool = poolObject.AddComponent<ObjectPool>();
        _pool.Entries = new List<ObjectPool.ObjectPoolEntry>
        {
            new ObjectPool.ObjectPoolEntry { Name = "ReturnClock", Prefab = _prefab, Count = 1 }
        };
        poolObject.SetActive(true);
        _body = _pool.Instantiate(_prefab);
        _originalIdentity = _body.GetInstanceID();
        Record("scheduled");
        // EnemyController uses this same recovered helper for both consecutive waits.
        _body.InvokeAfter(OnHide, _delay);
    }

    private void Update()
    {
        _tick = Time.frameCount - _startFrame;
        if (_tick >= 30 && _tick < 60)
        {
            Time.timeScale = 0f;
        }
        else if (_tick >= 60 && _tick < 120)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        if (_shouldForceReturn && _tick == _forcedReturnTick)
        {
            _body.DestroyPooled();
            Record("forced-return");
            _body = _pool.Instantiate(_prefab);
            Record("successor-allocated");
        }
    }

    private void OnHide()
    {
        Record("hide-callback");
        _body.InvokeAfter(OnReturn, 1f);
    }

    private void OnReturn()
    {
        _body.DestroyPooled();
        Record("delayed-return");
    }

    private void LateUpdate()
    {
        if (!_isComplete && _tick >= FinalTick)
        {
            Record("finished");
            _isComplete = true;
        }
    }

    private void Record(string transition)
    {
        _events.Add(new
        {
            transition, tick = _tick, time = Time.time, deltaTime = Time.deltaTime,
            timeScale = Time.timeScale, active = _body.gameObject.activeSelf,
            instantiated = _body.isInstantiated, sameObject = _body.GetInstanceID() == _originalIdentity,
            free = new List<int>(_pool.freePooledObjects[0]).ToArray()
        });
    }

    /// <summary>Exports real helper callbacks and pool ownership transitions for this scenario.</summary>
    public object ExportObservation()
    {
        return new
        {
            delay = _delay, forcedReturn = _shouldForceReturn,
            forcedReturnTick = _forcedReturnTick, events = _events.ToArray()
        };
    }
}
