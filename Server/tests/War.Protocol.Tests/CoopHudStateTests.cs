using War.Protocol;

/// <summary>Checks the exact Unity source view against host clock and objective snapshots.</summary>
internal static class CoopHudStateTests
{
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

    internal static int Run()
    {
        MatchSnapshot snapshot = CreateRunning();
        SelfHostedCoopHudState kill = SelfHostedCoopHudState.FromSnapshot(snapshot, PlayerId);
        Require(kill.RemainingSeconds == 2f && kill.DurationSeconds == 3f,
            "The mission timer must use host ticks rather than local wall time.");
        Require(kill.ObjectiveProgress == 4 && kill.Progress == 0.4f,
            "Kill progress must read the confirmed enemy counter.");
        snapshot.Coop.MissionType = "SurviveXSeconds";
        snapshot.Coop.ObjectiveTarget = 0;
        Require(SelfHostedCoopHudState.FromSnapshot(snapshot, PlayerId).Progress == 1f / 3f,
            "Survival progress must use elapsed host time.");
        snapshot.Coop.MissionType = "KillOpponent";
        Require(SelfHostedCoopHudState.FromSnapshot(snapshot, PlayerId).Progress == 0f,
            "Boss missions must retain the source base zero progress.");
        VerifyInvalidCounters();
        snapshot.Coop.MissionType = "Score";
        snapshot.Coop.ObjectiveTarget = 100;
        snapshot.Coop.ObjectiveScore = 15;
        snapshot.Coop.ParticipantScores.Add(new BattleCoopParticipantScore { PlayerId = PlayerId, Score = 10 });
        snapshot.Coop.ParticipantScores.Add(new BattleCoopParticipantScore
        {
            PlayerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", Score = 5
        });
        SelfHostedCoopHudState score = SelfHostedCoopHudState.FromSnapshot(snapshot, PlayerId);
        Require(score.ObjectiveProgress == 15 && score.Progress == 0.15f,
            "Score progress must use conserved shared contributions rather than success stars.");
        return 10;
    }

    private static void VerifyInvalidCounters()
    {
        MatchSnapshot negative = CreateRunning();
        negative.Coop.EnemyKills = -1;
        RequireInvalid(negative);
        MatchSnapshot zeroTarget = CreateRunning();
        zeroTarget.Coop.ObjectiveTarget = 0;
        RequireInvalid(zeroTarget);
        MatchSnapshot missingIndex = CreateRunning();
        missingIndex.Coop.MissionIndex = -1;
        RequireInvalid(missingIndex);
        MatchSnapshot missingMatch = CreateRunning();
        missingMatch.MatchId = "";
        RequireInvalid(missingMatch);
        MatchSnapshot missingManifest = CreateRunning();
        missingManifest.ManifestHash = "";
        RequireInvalid(missingManifest);
    }

    private static MatchSnapshot CreateRunning()
    {
        MatchSnapshot snapshot = CoopOutcomeProjectionTests.CreateSuccess();
        snapshot.MatchId = "source-mission-hud";
        snapshot.ManifestHash = new string('a', 64);
        snapshot.Phase = BattlePhase.Running;
        snapshot.ServerTick = 30;
        snapshot.EndTick = 0;
        snapshot.TerminalReason = "";
        snapshot.Coop.DeadlineTick = 90;
        snapshot.Coop.Completed = false;
        snapshot.Coop.SuccessScores.Clear();
        snapshot.Coop.PeerCompletionPlayerIds.Clear();
        snapshot.Coop.ObjectiveTarget = 10;
        snapshot.Coop.EnemyKills = 4;
        return snapshot;
    }

    private static void RequireInvalid(MatchSnapshot snapshot)
    {
        try
        {
            SelfHostedCoopHudState.FromSnapshot(snapshot, PlayerId);
        }
        catch (InvalidOperationException)
        {
            return;
        }

        throw new InvalidOperationException("Invalid mission counters selected a HUD view.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
