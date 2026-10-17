using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>Checks managed iterator faults alongside real Unity-hosted source visual loaders.</summary>
public static class UnityResourceExecutionFailureAudit
{
    private const int ObservationFrames = 6;
    private const int TimeoutSeconds = 10;

    /// <summary>Requires execution errors to stop owned source visuals and retain their original causes.</summary>
    public static async Task VerifyAsync(LevelBehaviour host, UpgradeSlots slots)
    {
        foreach (FailureMode mode in Enum.GetValues(typeof(FailureMode)))
        {
            await VerifyCaseAsync(host, slots, mode);
        }
        Debug.Log("PASS: controlled MoveNext/Current faults stop sibling source loading, retain execution and " +
            "cleanup causes, restore unscoped loading and block real root admission.");
    }

    private static async Task VerifyCaseAsync(LevelBehaviour host, UpgradeSlots slots, FailureMode mode)
    {
        var scope = new BattleResourceLoadScope();
        var fault = new ExecutionLoad(mode);
        slots.NullCardVisuals(true, true);
        try
        {
            scope.Start(host, host.PrepareVisualsForCardCoroutine(true, false));
            slots.NullCardVisuals(true, false);
            Exception reported = AdvanceFault(scope, host, fault);
            Require(Contains(reported, fault.ExecutionFailure), "Execution failure lost its original cause.");
            Require(ReferenceEquals(scope.FirstFailure, fault.ExecutionFailure),
                "The owner cannot observe the exact first execution failure after its iterator unwinds.");
            if (mode == FailureMode.MoveAndCleanup)
            {
                Require(Contains(reported, fault.CleanupFailure), "Cleanup masked the original execution failure.");
            }
            host.StartCoroutine(slots.LoadOpponentVisualsCoroutineCards());
            await WaitFramesAsync();
            Require(scope.PendingCount == 0 &&
                slots.cardVisuals.TrueForAll(visual => visual.materialTetxureBlue == null),
                "A sibling source loader continued after execution failed in its battle scope.");
            Require(slots.cardVisuals.TrueForAll(visual => visual.materialTetxureRed != null),
                "Execution failure leaked its cancelled context into an unscoped source loader.");
            AggregateException retained = CaptureCancellation(scope);
            Require(Contains(retained, fault.ExecutionFailure) && fault.DisposeCount == 1,
                "Cancellation forgot the execution error or disposed the failing iterator twice.");
            if (mode == FailureMode.MoveAndCleanup)
            {
                Require(Contains(retained, fault.CleanupFailure), "Retried cleanup lost one of the original causes.");
            }
            UnityResourceScopeFailureAudit.VerifyBlockedRootAdmission(scope, fault.ExecutionFailure);
        }
        finally
        {
            host.StopAllCoroutines();
            slots.StopAllCoroutines();
        }
    }

    private static Exception AdvanceFault(BattleResourceLoadScope scope, MonoBehaviour host, IEnumerator loading)
    {
        // Advance the real wrapper directly so the expected exception is caught, not hidden by a log filter.
        Type pendingType = typeof(BattleResourceLoadScope).GetNestedType("PendingLoad", BindingFlags.NonPublic);
        object pending = Activator.CreateInstance(pendingType, new object[] { host, loading });
        var observed = (IEnumerator)typeof(BattleResourceLoadScope)
            .GetMethod("Observe", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(scope, new[] { pending });
        try
        {
            observed.MoveNext();
        }
        catch (Exception failure)
        {
            return failure;
        }
        throw new InvalidOperationException("The controlled execution iterator did not fail.");
    }

    private static AggregateException CaptureCancellation(BattleResourceLoadScope scope)
    {
        try
        {
            scope.Cancel();
        }
        catch (AggregateException failure)
        {
            return failure;
        }
        throw new InvalidOperationException("The scope forgot its execution failure during cancellation.");
    }

    private static bool Contains(Exception reported, Exception expected)
    {
        var aggregate = reported as AggregateException;
        return ReferenceEquals(reported, expected) ||
            (aggregate != null && aggregate.Flatten().InnerExceptions.Any(error => ReferenceEquals(error, expected)));
    }

    private static async Task WaitFramesAsync()
    {
        int target = Time.frameCount + ObservationFrames;
        DateTime deadline = DateTime.UtcNow.AddSeconds(TimeoutSeconds);
        while (Time.frameCount < target)
        {
            Require(DateTime.UtcNow < deadline, "Execution fault observation timed out.");
            await Task.Yield();
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private enum FailureMode
    {
        MoveNext,
        Current,
        MoveAndCleanup,
    }

    private sealed class ExecutionLoad : IEnumerator, IDisposable
    {
        private readonly FailureMode _mode;

        public ExecutionLoad(FailureMode mode)
        {
            _mode = mode;
            ExecutionFailure = new InvalidOperationException("Injected execution fault: " + mode);
            CleanupFailure = new InvalidOperationException("Injected execution cleanup fault.");
        }

        public Exception ExecutionFailure { get; private set; }

        public Exception CleanupFailure { get; private set; }

        public int DisposeCount { get; private set; }

        public object Current
        {
            get
            {
                if (_mode == FailureMode.Current)
                {
                    throw ExecutionFailure;
                }
                return null;
            }
        }

        public bool MoveNext()
        {
            if (_mode != FailureMode.Current)
            {
                throw ExecutionFailure;
            }
            return true;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
            DisposeCount++;
            if (_mode == FailureMode.MoveAndCleanup)
            {
                throw CleanupFailure;
            }
        }
    }
}
