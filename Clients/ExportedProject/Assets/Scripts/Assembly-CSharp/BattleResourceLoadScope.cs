using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Tracks only battle-owned managed loaders across their actual coroutine hosts.</summary>
public sealed class BattleResourceLoadScope
{
    // Unity resumes hosts independently; ownership exists only while one managed loading step executes.
    [ThreadStatic]
    private static BattleResourceLoadScope _currentScope;
    private readonly List<PendingLoad> _pending = new List<PendingLoad>();
    private bool _isCancelled;

    /// <summary>Gets the number of tracked loaders still pending in this battle scope.</summary>
    public int PendingCount
    {
        get
        {
            return _pending.Count;
        }
    }

    /// <summary>Preserves ordinary preview loading unless the caller is executing a tracked battle loader.</summary>
    public static Coroutine StartNested(MonoBehaviour owner, IEnumerator loading)
    {
        if (_currentScope == null)
        {
            return owner.StartCoroutine(loading);
        }
        return _currentScope.Start(owner, loading);
    }

    /// <summary>Starts a loader and carries its battle ownership through each managed continuation.</summary>
    public Coroutine Start(MonoBehaviour owner, IEnumerator loading)
    {
        if (owner == null || loading == null)
        {
            throw new ArgumentException("A live coroutine host and loading iterator are required.");
        }
        if (_isCancelled)
        {
            var disposable = loading as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
            return null;
        }
        var pending = new PendingLoad(owner, loading);
        _pending.Add(pending);
        try
        {
            pending.Handle = owner.StartCoroutine(Observe(pending));
            if (pending.Handle == null && !pending.IsFinished)
            {
                throw new InvalidOperationException("The coroutine host could not start a battle resource loader.");
            }
            return pending.Handle;
        }
        catch
        {
            Finish(pending);
            throw;
        }
    }

    /// <summary>Stops exactly this battle's loaders without cancelling unrelated work on the same hosts.</summary>
    public void Cancel()
    {
        _isCancelled = true;
        PendingLoad[] pendingLoads = _pending.ToArray();
        _pending.Clear();
        var failures = new List<Exception>();
        foreach (PendingLoad pending in pendingLoads)
        {
            try
            {
                if (pending.Owner != null && pending.Handle != null)
                {
                    pending.Owner.StopCoroutine(pending.Handle);
                }
                Finish(pending);
            }
            catch (Exception failure)
            {
                failures.Add(failure);
            }
        }
        if (failures.Count != 0)
        {
            throw new AggregateException("Battle resource cancellation failed.", failures);
        }
    }

    private IEnumerator Observe(PendingLoad pending)
    {
        try
        {
            while (!_isCancelled)
            {
                BattleResourceLoadScope previousScope = _currentScope;
                bool hasNext;
                object current;
                _currentScope = this;
                try
                {
                    hasNext = pending.Loading.MoveNext();
                    current = hasNext ? pending.Loading.Current : null;
                }
                finally
                {
                    _currentScope = previousScope;
                }
                if (!hasNext)
                {
                    yield break;
                }
                yield return current;
            }
        }
        finally
        {
            Finish(pending);
        }
    }

    private void Finish(PendingLoad pending)
    {
        if (pending.IsFinished)
        {
            return;
        }
        pending.IsFinished = true;
        _pending.Remove(pending);
        var disposable = pending.Loading as IDisposable;
        if (disposable != null)
        {
            disposable.Dispose();
        }
    }

    private sealed class PendingLoad
    {
        public PendingLoad(MonoBehaviour owner, IEnumerator loading)
        {
            Owner = owner;
            Loading = loading;
        }

        public MonoBehaviour Owner { get; private set; }

        public IEnumerator Loading { get; private set; }

        public Coroutine Handle { get; set; }

        public bool IsFinished { get; set; }
    }
}
