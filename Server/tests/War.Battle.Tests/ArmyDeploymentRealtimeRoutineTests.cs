using System.Security.Cryptography;
using System.Text;

using War.BattleServer;

/// <summary>Checks strict source float deadlines, frame hitches and non-mutating spawn preflight.</summary>
internal static class ArmyDeploymentRealtimeRoutineTests
{
    private const float StartedSeconds = 2f;
    private const float HitchSeconds = 10f;
    private const string WaitSourceDigest = "4ce840bfc00c216677a27f6f951227424d4e223c44a17d3525a3ba924a0137eb";
    // Reviewed 104f27751 changes binding-generation guards; Spawn is unchanged from c830ce762.
    private const string ManagerSourceDigest = "2dd7ab8fcd227e6843c11a1ae3d45dd07f0fbcc2daf15ee94f63e1459ddf394f";
    private const string WrapperSourceDigest = "4108b79f7f6b250be727bb154f2045b14f02698db0cba66825aa95f366322499";

    internal static int Run(string directory)
    {
        string repository = Directory.GetParent(directory)!.Parent!.FullName;
        int checks = CheckSource(repository,
            "Assets/Plugins/Assembly-CSharp-firstpass/WaitForRealSeconds.cs", WaitSourceDigest);
        checks += CheckSource(repository,
            "Assets/Scripts/Assembly-CSharp/SpawningManagerDeathMatch.cs", ManagerSourceDigest);
        checks += CheckSource(repository,
            "Assets/Plugins/Assembly-CSharp-firstpass/RadicalRoutine.cs", WrapperSourceDigest);
        return checks + CheckSourceSequence() + CheckPreflight() + CheckRejectedInputs();
    }

    private static int CheckSource(string repository, string relativePath, string expectedDigest)
    {
        string source = File.ReadAllText(Path.Combine(repository, "Clients/ExportedProject", relativePath))
            .Replace("\r\n", "\n").Replace('\r', '\n');
        return Require(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(source))) == expectedDigest,
            "Recovered deployment coroutine source changed without review: " + relativePath);
    }

    private static int CheckSourceSequence()
    {
        var routine = new ArmyDeploymentRealtimeRoutine(4, StartedSeconds);
        int checks = CommitReadyIteration(routine, StartedSeconds);
        checks += Require(routine.RemainingIterations == 3,
            "The source first iteration was delayed before its initial unit.");
        float firstDeadline = routine.DeadlineSeconds;
        checks += Require(routine.Preview(firstDeadline) == ArmyDeploymentRealtimeRoutine.Step.None,
            "A source float wait completed at equality.");
        checks += CommitReadyIteration(routine, MathF.BitIncrement(firstDeadline));
        checks += CommitReadyIteration(routine, HitchSeconds);
        checks += Require(routine.RemainingIterations == 1 && routine.DeadlineSeconds == HitchSeconds + 0.3f,
            "A delayed callback carried its old deadline into the next source wait.");
        checks += Require(routine.Preview(HitchSeconds) == ArmyDeploymentRealtimeRoutine.Step.None &&
            routine.RemainingIterations == 1, "Catch-up observations published a burst at the same real time.");
        checks += RequireUnavailable(() => routine.CommitIteration(HitchSeconds));
        float next = MathF.BitIncrement(routine.DeadlineSeconds);
        checks += CommitReadyIteration(routine, next);
        checks += Require(routine.RemainingIterations == 0 && !routine.HasFinished,
            "The last unit skipped the source's final post-spawn wait.");
        checks += Require(routine.Preview(routine.DeadlineSeconds) == ArmyDeploymentRealtimeRoutine.Step.None,
            "The final source wait completed at equality.");
        checks += RequireUnavailable(() => routine.CommitFinished(routine.DeadlineSeconds));
        float finished = MathF.BitIncrement(routine.DeadlineSeconds);
        checks += Require(routine.Preview(finished) == ArmyDeploymentRealtimeRoutine.Step.Finished,
            "The source completion callback did not follow its final strict deadline.");
        routine.CommitFinished(finished);
        checks += Require(routine.HasFinished && routine.Preview(HitchSeconds + 1f) ==
            ArmyDeploymentRealtimeRoutine.Step.None,
            "A completed source coroutine published completion twice.");
        return checks + RequireUnavailable(() => routine.CommitFinished(HitchSeconds + 1f));
    }

    private static int CheckPreflight()
    {
        var routine = new ArmyDeploymentRealtimeRoutine(2, StartedSeconds);
        float before = routine.DeadlineSeconds;
        int checks = Require(routine.Preview(HitchSeconds) == ArmyDeploymentRealtimeRoutine.Step.SpawnIteration &&
            routine.RemainingIterations == 2 && routine.DeadlineSeconds == before && !routine.HasFinished,
            "A future preflight consumed source units or started a wait.");
        routine.CommitIteration(StartedSeconds);
        checks += Require(routine.DeadlineSeconds == StartedSeconds + 0.3f,
            "A future preview replaced the actual callback time.");
        var delayed = new ArmyDeploymentRealtimeRoutine(1, StartedSeconds);
        delayed.Preview(StartedSeconds);
        float actualCompletion = StartedSeconds + 0.1f;
        delayed.CommitIteration(actualCompletion);
        return checks + Require(delayed.DeadlineSeconds == actualCompletion + 0.3f,
            "The next wait began at preflight rather than actual iteration completion.");
    }

    private static int CheckRejectedInputs()
    {
        int checks = 0;
        foreach (int count in new[] { 0, -1 })
        {
            checks += RequireRejected(() => new ArmyDeploymentRealtimeRoutine(count, StartedSeconds));
        }
        foreach (float seconds in new[] { float.NaN, float.PositiveInfinity, -1f })
        {
            checks += RequireRejected(() => new ArmyDeploymentRealtimeRoutine(1, seconds));
        }
        var routine = new ArmyDeploymentRealtimeRoutine(1, StartedSeconds);
        foreach (float seconds in new[] { float.NaN, float.PositiveInfinity, StartedSeconds - 1f })
        {
            checks += RequireRejected(() => routine.CommitIteration(seconds));
        }
        checks += RequireUnavailable(() => routine.CommitFinished(StartedSeconds));
        return checks + Require(routine.RemainingIterations == 1 && !routine.HasFinished &&
            routine.DeadlineSeconds == StartedSeconds, "Rejected time mutated pending source authority.");
    }

    private static int CommitReadyIteration(ArmyDeploymentRealtimeRoutine routine, float seconds)
    {
        int checks = Require(routine.Preview(seconds) == ArmyDeploymentRealtimeRoutine.Step.SpawnIteration,
            "The source spawn loop did not resume when its float wait was ready.");
        routine.CommitIteration(seconds);
        return checks;
    }

    private static int RequireUnavailable(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidOperationException)
        {
            return 1;
        }
        throw new InvalidOperationException("A pending or completed source iteration was committed again.");
    }

    private static int RequireRejected(Action action)
    {
        try
        {
            action();
        }
        catch (ArgumentOutOfRangeException)
        {
            return 1;
        }
        throw new InvalidOperationException("Invalid source routine input was accepted.");
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        return 1;
    }
}
