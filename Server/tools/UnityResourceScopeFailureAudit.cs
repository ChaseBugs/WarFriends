using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>Injects managed iterator cleanup faults into real Unity-hosted battle loading scopes.</summary>
public static class UnityResourceScopeFailureAudit
{
    /// <summary>The exact injected cleanup error recognized by the native fault controls.</summary>
    public const string CleanupFailureMessage = "Injected battle resource cleanup failure.";
    private const string SetupFailureMessage = "Injected battle setup failure.";
    private const int ObservationFrames = 6;
    private const int TimeoutSeconds = 10;

    /// <summary>Returns a pending test iterator whose cleanup reports an explicit injected failure.</summary>
    public static IEnumerator CreateFailingLoad()
    {
        return new CleanupLoad(() => { throw new InvalidOperationException(CleanupFailureMessage); });
    }

    /// <summary>
    /// Requires cleanup ownership, retained errors and fail-closed root admission under injected faults.
    /// </summary>
    public static async Task VerifyAsync(LevelBehaviour host, UpgradeSlots slots)
    {
        var failures = new List<Exception>();
        try
        {
            await VerifyCleanupOwnershipAsync(host, slots);
        }
        catch (Exception failure)
        {
            failures.Add(failure);
        }
        try
        {
            VerifyRetainedFailure(host);
            VerifySetupFailure(host);
        }
        catch (Exception failure)
        {
            failures.Add(failure);
        }
        if (failures.Count != 0)
        {
            throw new AggregateException("Resource scope failure gates failed.", failures);
        }
        Debug.Log("PASS: injected cleanup faults retain battle ownership, visit remaining loaders, preserve " +
            "failure evidence across retry and block real root admission; setup failures retain both causes.");
    }

    private static async Task VerifyCleanupOwnershipAsync(LevelBehaviour host, UpgradeSlots slots)
    {
        var scope = new BattleResourceLoadScope();
        slots.NullCardVisuals(true, false);
        var cleanup = new CleanupLoad(() => BattleResourceLoadScope.StartNested(host,
            host.PrepareVisualsForCardCoroutine(true, false)));
        try
        {
            scope.Start(host, cleanup);
            scope.Cancel();
            await WaitFramesAsync();
            Require(cleanup.DisposeCount == 1 && scope.PendingCount == 0 &&
                slots.cardVisuals.TrueForAll(visual => visual.materialTetxureBlue == null),
                "A cleanup continuation escaped its cancelled scope and repopulated source visuals.");
        }
        finally
        {
            host.StopAllCoroutines();
            slots.StopAllCoroutines();
            slots.NullCardVisuals(true, false);
        }
    }

    private static void VerifyRetainedFailure(LevelBehaviour host)
    {
        var scope = new BattleResourceLoadScope();
        var failing = new CleanupLoad(() => { throw new InvalidOperationException(CleanupFailureMessage); });
        var remaining = new CleanupLoad(() => { });
        scope.Start(host, failing);
        scope.Start(host, remaining);
        AggregateException original = CancelFailure(scope);
        Require(failing.DisposeCount == 1 && remaining.DisposeCount == 1 && scope.PendingCount == 0,
            "Cleanup failure skipped another pending loader or disposed a loader twice.");
        AggregateException repeated = CancelFailure(scope);
        Require(HasCleanupFailure(original) && HasCleanupFailure(repeated) && failing.DisposeCount == 1,
            "A repeated cancellation forgot its prior cleanup failure.");
        VerifyBlockedRootAdmission(scope);
    }

    private static void VerifySetupFailure(LevelBehaviour host)
    {
        var scope = new BattleResourceLoadScope();
        AggregateException reported = null;
        try
        {
            scope.RunSetup(() =>
            {
                BattleResourceLoadScope.StartNested(host, CreateFailingLoad());
                throw new InvalidOperationException(SetupFailureMessage);
            });
        }
        catch (AggregateException failure)
        {
            reported = failure;
        }
        Require(reported != null && HasCleanupFailure(reported) &&
            reported.Flatten().InnerExceptions.Any(error => error.Message == SetupFailureMessage),
            "Setup failure lost its original cause or its cleanup cause.");
        Require(HasCleanupFailure(CancelFailure(scope)), "Rejected setup forgot its cleanup failure on retry.");
    }

    private static void VerifyBlockedRootAdmission(BattleResourceLoadScope scope)
    {
        GameController game = Singleton<GameController>.instance;
        var scopeField = GameField("_battleResourceLoads");
        var controllerField = GameField("mMainController");
        var createdField = GameField("mGameCreated");
        object previousScope = scopeField.GetValue(game);
        object previousController = controllerField.GetValue(game);
        object previousCreated = createdField.GetValue(game);
        var root = new GameObject("InactiveCleanupAdmissionProbe");
        root.SetActive(false);
        var controller = root.AddComponent<AbortMissionSetupControllerProbe>();
        bool setupReached = false;
        controller.LoadingStartedAction = () =>
        {
            setupReached = true;
            throw new InvalidOperationException("Root setup must not run after failed cleanup.");
        };
        scopeField.SetValue(game, scope);
        controllerField.SetValue(game, controller);
        try
        {
            AggregateException reported = null;
            try
            {
                game.StartGame();
            }
            catch (AggregateException failure)
            {
                reported = failure;
            }
            Require(!setupReached && reported != null && HasCleanupFailure(reported) &&
                ReferenceEquals(scopeField.GetValue(game), scope),
                "Real root admission replaced or bypassed a scope with failed cleanup.");
        }
        finally
        {
            scopeField.SetValue(game, previousScope);
            controllerField.SetValue(game, previousController);
            createdField.SetValue(game, previousCreated);
        }
    }

    private static AggregateException CancelFailure(BattleResourceLoadScope scope)
    {
        try
        {
            scope.Cancel();
        }
        catch (AggregateException failure)
        {
            return failure;
        }
        throw new InvalidOperationException("Cancellation silently forgot failed resource cleanup.");
    }

    private static bool HasCleanupFailure(AggregateException failure)
    {
        return failure.Flatten().InnerExceptions.Any(error => error.Message == CleanupFailureMessage);
    }

    private static FieldInfo GameField(string name)
    {
        return typeof(GameController).GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
    }

    private static async Task WaitFramesAsync()
    {
        int target = Time.frameCount + ObservationFrames;
        DateTime deadline = DateTime.UtcNow.AddSeconds(TimeoutSeconds);
        while (Time.frameCount < target)
        {
            Require(DateTime.UtcNow < deadline, "Cleanup continuation observation timed out.");
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

    private sealed class CleanupLoad : IEnumerator, IDisposable
    {
        private readonly Action _cleanup;

        public CleanupLoad(Action cleanup)
        {
            _cleanup = cleanup;
        }

        public int DisposeCount { get; private set; }

        public object Current
        {
            get
            {
                return null;
            }
        }

        public bool MoveNext()
        {
            return true;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
            DisposeCount++;
            _cleanup();
        }
    }
}
