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
    private readonly List<Exception> _cancellationFailures = new List<Exception>();
    private readonly List<Exception> _cleanupFailures = new List<Exception>();
    private bool _isCancelled;

    /// <summary>Retains the first loading failure for owner-bound handling after the iterator unwinds.</summary>
    public Exception FirstFailure { get; private set; }

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

    /// <summary>Includes loaders started by synchronous battle preparation callbacks in this scope.</summary>
    public void RunSetup(Action setup)
    {
        if (setup == null)
        {
            throw new ArgumentNullException("setup");
        }
        if (_isCancelled)
        {
            throw new InvalidOperationException("A cancelled battle scope cannot run setup.");
        }
        BattleResourceLoadScope previousScope = _currentScope;
        _currentScope = this;
        try
        {
            setup();
        }
        catch (Exception failure)
        {
            FirstFailure = FirstFailure ?? failure;
            try
            {
                Cancel();
            }
            catch (Exception cancellationFailure)
            {
                throw new AggregateException("Battle setup and cancellation failed.", failure, cancellationFailure);
            }
            throw;
        }
        finally
        {
            _currentScope = previousScope;
        }
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
            DisposeLoading(loading);
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
        catch (Exception failure)
        {
            RecordFailure(failure);
            try
            {
                Finish(pending);
            }
            catch (Exception cleanupFailure)
            {
                throw new AggregateException("Battle loading start and cleanup failed.", failure, cleanupFailure);
            }
            throw;
        }
    }

    /// <summary>Stops exactly this battle's loaders without cancelling unrelated work on the same hosts.</summary>
    public void Cancel()
    {
        _isCancelled = true;
        PendingLoad[] pendingLoads = _pending.ToArray();
        _pending.Clear();
        foreach (PendingLoad pending in pendingLoads)
        {
            try
            {
                if (pending.Owner != null && pending.Handle != null)
                {
                    pending.Owner.StopCoroutine(pending.Handle);
                }
            }
            catch (Exception failure)
            {
                RecordCleanupFailure(failure);
            }
            // Disposal is still required when Unity could not stop the coroutine handle.
            try
            {
                Finish(pending);
            }
            catch (Exception failure)
            {
                RecordCleanupFailure(failure);
            }
        }
        if (_cancellationFailures.Count != 0)
        {
            throw new AggregateException("Battle resource cancellation failed.", _cancellationFailures.ToArray());
        }
    }

    /// <summary>Allows confirmed abort cleanup past prior execution errors, but never reported stop/disposal errors.</summary>
    public void CancelAfterConfirmedAbort()
    {
        try
        {
            Cancel();
        }
        catch (AggregateException) when (_cleanupFailures.Count == 0)
        {
            // The original execution failure remains in FirstFailure and ordinary Cancel still rejects reuse.
        }
    }

    private IEnumerator Observe(PendingLoad pending)
    {
        Exception executionFailure = null;
        try
        {
            while (!_isCancelled)
            {
                bool hasNext;
                object current;
                try
                {
                    hasNext = Advance(pending, out current);
                }
                catch (Exception failure)
                {
                    // A failed iterator must close sibling loading before Unity resumes another host.
                    executionFailure = failure;
                    RecordFailure(failure);
                    throw;
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
            FinishAfterExecution(pending, executionFailure);
        }
    }

    private void FinishAfterExecution(PendingLoad pending, Exception executionFailure)
    {
        try
        {
            Finish(pending);
        }
        catch (Exception cleanupFailure)
        {
            if (executionFailure != null)
            {
                throw new AggregateException("Battle loading execution and cleanup failed.",
                    executionFailure, cleanupFailure);
            }
            throw;
        }
    }

    private bool Advance(PendingLoad pending, out object current)
    {
        BattleResourceLoadScope previousScope = _currentScope;
        _currentScope = this;
        current = null;
        try
        {
            bool hasNext = pending.Loading.MoveNext();
            if (hasNext)
            {
                current = pending.Loading.Current;
            }
            return hasNext;
        }
        finally
        {
            _currentScope = previousScope;
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
        DisposeLoading(pending.Loading);
    }

    private void DisposeLoading(IEnumerator loading)
    {
        // Cleanup still belongs to its battle; a finally callback must not reopen loading outside a cancelled scope.
        BattleResourceLoadScope previousScope = _currentScope;
        _currentScope = this;
        try
        {
            var disposable = loading as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
        catch (Exception failure)
        {
            RecordCleanupFailure(failure);
            throw;
        }
        finally
        {
            _currentScope = previousScope;
        }
    }

    private void RecordFailure(Exception failure)
    {
        FirstFailure = FirstFailure ?? failure;
        _isCancelled = true;
        if (!_cancellationFailures.Contains(failure))
        {
            _cancellationFailures.Add(failure);
        }
    }

    private void RecordCleanupFailure(Exception failure)
    {
        RecordFailure(failure);
        if (!_cleanupFailures.Contains(failure))
        {
            _cleanupFailures.Add(failure);
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
