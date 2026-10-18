using System.Collections;
using System.Collections.Generic;
using System.Threading;

using UnityEngine;

/// <summary>Aligns original body return and a real-time source continuation on one rendered frame.</summary>
public sealed class UnityPoolReturnRaceProbe : MonoBehaviour
{
    private const int CaptureRate = 1;
    private const int AlignmentMilliseconds = 350;
    private const float SpawnWaitSeconds = 0.3f;
    private const float HideDelaySeconds = 2f;
    private const float ReturnDelaySeconds = 1f;
    private const float WatchdogSeconds = 5f;
    private readonly List<object> _events = new List<object>();
    private ObjectPool _pool;
    private PoolableObject _prefab;
    private PoolableObject _body;
    private float _startRealTime;
    private float _returnGameTime;
    private int _returnFrame;
    private int _spawnFrame;
    private int _lastLateUpdateFrame;
    private bool _hasAligned;
    private bool _hasReturned;
    private bool _hasSpawned;
    private bool _hasReusedBody;
    private bool _isComplete;

    /// <summary>Gets whether the bounded native observation has finished.</summary>
    public bool IsComplete { get { return _isComplete; } }

    private void Start()
    {
        Time.captureFramerate = CaptureRate;
        Time.timeScale = 1f;
        Application.runInBackground = true;
        _startRealTime = Time.realtimeSinceStartup;
        CreatePool();
        _body = _pool.Instantiate(_prefab);
        _body.InvokeAfter(OnHide, HideDelaySeconds);
        StartCoroutine(RadicalRoutine.Run(ObserveSpawn()));
    }

    private void CreatePool()
    {
        var template = new GameObject("InactiveRaceTemplate");
        template.SetActive(false);
        _prefab = template.AddComponent<PoolableObject>();
        var poolObject = new GameObject("ReturnRacePool");
        poolObject.SetActive(false);
        _pool = poolObject.AddComponent<ObjectPool>();
        _pool.Entries = new List<ObjectPool.ObjectPoolEntry>
        {
            new ObjectPool.ObjectPoolEntry { Name = "Race", Prefab = _prefab, Count = 1 }
        };
        poolObject.SetActive(true);
    }

    private void Update()
    {
        if (!_hasAligned && _returnGameTime > 0f && Time.time >= _returnGameTime)
        {
            // A bounded real frame hitch makes the existing real-time wait ready before callbacks run.
            // Neither source clock nor either coroutine iterator is replaced or manually advanced.
            Thread.Sleep(AlignmentMilliseconds);
            _hasAligned = true;
            Record("deadline-aligned");
        }
        if (_hasSpawned || Time.realtimeSinceStartup - _startRealTime > WatchdogSeconds)
        {
            _isComplete = true;
        }
    }

    private void LateUpdate()
    {
        _lastLateUpdateFrame = Time.frameCount;
    }

    private void OnHide()
    {
        _returnGameTime = Time.time + ReturnDelaySeconds;
        _body.InvokeAfter(OnReturn, ReturnDelaySeconds);
        Record("hide-callback");
    }

    private void OnReturn()
    {
        _body.DestroyPooled();
        _hasReturned = true;
        _returnFrame = Time.frameCount;
        Record("return-callback");
    }

    private IEnumerator ObserveSpawn()
    {
        yield return new WaitForRealSeconds(SpawnWaitSeconds);
        _spawnFrame = Time.frameCount;
        Record("spawn-continuation");
        if (_hasReturned && _pool.GetNumberOfInstancies(_prefab) == 0)
        {
            PoolableObject successor = _pool.Instantiate(_prefab);
            _hasReusedBody = successor == _body;
        }
        _hasSpawned = true;
        Record("allocation-finished");
    }

    private void Record(string transition)
    {
        _events.Add(new
        {
            transition, frame = Time.frameCount, gameTime = Time.time,
            realElapsed = Time.realtimeSinceStartup - _startRealTime,
            afterCurrentLateUpdate = _lastLateUpdateFrame == Time.frameCount,
            returned = _hasReturned, free = new List<int>(_pool.freePooledObjects[0]).ToArray()
        });
    }

    /// <summary>Reports whether both actual source callbacks competed on one frame and reused the source slot.</summary>
    public object ExportObservation()
    {
        return new
        {
            sameFrame = _hasReturned && _hasSpawned && _returnFrame == _spawnFrame,
            reusedBody = _hasReusedBody, aligned = _hasAligned,
            captureRate = CaptureRate, alignmentMilliseconds = AlignmentMilliseconds,
            batchMode = Application.isBatchMode, events = _events.ToArray()
        };
    }
}
