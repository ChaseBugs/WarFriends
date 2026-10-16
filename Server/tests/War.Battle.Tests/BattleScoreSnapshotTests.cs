using Google.Protobuf;
using War.Client;
using War.Protocol;
using War.BattleServer;

// Scores are authoritative snapshots, including frozen mutation replays.
// Validate their domain without imposing a false monotonic-reply requirement.
internal static class BattleScoreSnapshotTests
{
    private const int ExpectedScore = 56;
    private const float ExpectedProgress = 5.6f;

    internal static int Run()
    {
        var snapshot = new MatchSnapshot();
        snapshot.Players.Add(new BattlePlayerState
        {
            PlayerId = new string('a', 32), Score = ExpectedScore, KillStreakProgress = ExpectedProgress
        });
        snapshot.Players.Add(new BattlePlayerState { PlayerId = new string('b', 32), Score = 0 });
        BattleScoreSnapshotPolicy.Validate(snapshot);
        MatchSnapshot decoded = MatchSnapshot.Parser.ParseFrom(snapshot.ToByteArray());
        if (decoded.Players[0].Score != ExpectedScore || decoded.Players[1].Score != 0 ||
            decoded.Players[0].KillStreakProgress != ExpectedProgress)
        {
            throw new Exception("Protobuf must retain both participants' authoritative scores.");
        }

        snapshot.Players[1].Score = -1;
        RequireRejection(snapshot);

        int checks = 2;
        foreach (float progress in new[] { -1f, float.NaN, float.PositiveInfinity })
        {
            MatchSnapshot invalid = decoded.Clone();
            invalid.Players[0].KillStreakProgress = progress;
            RequireRejection(invalid);
            checks++;
        }

        MatchSnapshot duplicate = decoded.Clone();
        duplicate.Players[1].PlayerId = duplicate.Players[0].PlayerId;
        RequireRejection(duplicate);
        checks++;
        MatchSnapshot truncated = decoded.Clone();
        truncated.Phase = BattlePhase.Ended;
        truncated.Players[0].SkillShotCounts.Add(new BattleSkillShotCount { Flag = 4096, Count = 1 });
        RequireRejection(truncated);
        checks++;

        Console.WriteLine($"PASS: {checks} battle score snapshot assertions");
        return checks;
    }

    internal static int VerifyTerminal(MatchEngine match, string playerId)
    {
        MatchSnapshot snapshot = match.Snapshot();
        BattleScoreSnapshotPolicy.Validate(snapshot);
        BattlePlayerState player = snapshot.Players.Single(row => row.PlayerId == playerId);
        if (player.ConfirmedSkillShotCounts.Count != 0 ||
            player.SkillShotCounts.Single(row => row.Flag == PvpArmyKillSkillShotPolicy.RevengeKill).Count != 1)
        {
            throw new Exception("The public terminal breakdown must preserve revenge without private counters.");
        }

        BattlePlayerState evidence = match.TerminalEvidenceSnapshot().Players.Single(row => row.PlayerId == playerId);
        uint privateCount = evidence.ConfirmedSkillShotCounts[0].Count;
        evidence.SkillShotCounts[0].Count++;
        if (evidence.ConfirmedSkillShotCounts[0].Count != privateCount)
        {
            throw new Exception("Public counter rows must not alias private terminal evidence.");
        }

        return 2;
    }

    private static void RequireRejection(MatchSnapshot snapshot)
    {
        try
        {
            BattleScoreSnapshotPolicy.Validate(snapshot);
        }
        catch (InvalidOperationException)
        {
            return;
        }

        throw new Exception("The SDK accepted a damaged score snapshot.");
    }
}
