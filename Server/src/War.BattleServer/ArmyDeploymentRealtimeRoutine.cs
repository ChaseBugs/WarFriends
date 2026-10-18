namespace War.BattleServer;

/// <summary>Preserves the source coroutine's immediate first iteration and separate real-time waits.</summary>
internal sealed class ArmyDeploymentRealtimeRoutine
{
    private const float SourceWaitSeconds = 0.3f;
    private readonly int _unitCount;
    private int _completedIterations;
    private float _lastCommittedSeconds;
    private float _deadlineSeconds;
    private bool _hasFinished;

    internal int RemainingIterations => _unitCount - _completedIterations;

    internal float DeadlineSeconds => _deadlineSeconds;

    internal bool HasFinished => _hasFinished;

    internal ArmyDeploymentRealtimeRoutine(int unitCount, float startedSeconds)
    {
        if (unitCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(unitCount));
        }
        BattleRealtime.Validate(startedSeconds, 0d);
        _unitCount = unitCount;
        _lastCommittedSeconds = startedSeconds;
        _deadlineSeconds = startedSeconds;
    }

    internal Step Preview(float realTimeSeconds)
    {
        BattleRealtime.Validate(realTimeSeconds, _lastCommittedSeconds);
        if (_hasFinished)
        {
            return Step.None;
        }
        if (_completedIterations == 0)
        {
            return Step.SpawnIteration;
        }
        // WaitForRealSeconds compares floats with strict >, including after the final unit.
        if (realTimeSeconds <= _deadlineSeconds)
        {
            return Step.None;
        }
        return _completedIterations < _unitCount ? Step.SpawnIteration : Step.Finished;
    }

    internal void CommitIteration(float completedRealTimeSeconds)
    {
        if (Preview(completedRealTimeSeconds) != Step.SpawnIteration)
        {
            throw new InvalidOperationException("The source spawn iteration is not ready to commit.");
        }
        _lastCommittedSeconds = completedRealTimeSeconds;
        _completedIterations++;
        // Caller records actual iteration completion, not preflight time or wave acceptance.
        // An iteration is not proof of a spawned entity, energy debit or reward authority.
        _deadlineSeconds = completedRealTimeSeconds + SourceWaitSeconds;
    }

    internal void CommitFinished(float realTimeSeconds)
    {
        if (Preview(realTimeSeconds) != Step.Finished)
        {
            throw new InvalidOperationException("The source final wait has not completed.");
        }
        _lastCommittedSeconds = realTimeSeconds;
        _hasFinished = true;
    }

    internal enum Step
    {
        None,
        SpawnIteration,
        Finished
    }
}
