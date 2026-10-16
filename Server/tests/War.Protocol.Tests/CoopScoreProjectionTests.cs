using War.Client;
using War.Protocol;

/// <summary>Checks conserved Score-mission presentation before the Unity manager publishes either contribution.</summary>
internal static class CoopScoreProjectionTests
{
    private const string MasterId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string PeerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";

    internal static int Run()
    {
        MatchSnapshot snapshot = CreateScoreSnapshot();
        CoopScoreProjection master = CoopScoreProjection.ForPlayer(snapshot, MasterId);
        Require(master.LocalScore == 10 && master.PeerScore == 5 && master.TotalScore == 15,
            "The master's HUD must preserve both source contributions.");
        CoopScoreProjection peer = CoopScoreProjection.ForPlayer(snapshot, PeerId);
        Require(peer.LocalScore == 5 && peer.PeerScore == 10 && peer.TotalScore == 15,
            "The peer's HUD must reverse local ownership without changing the shared total.");
        VerifyInvalidContributions();
        VerifyDepartureAndPrestart();
        return 11;
    }

    private static void VerifyInvalidContributions()
    {
        MatchSnapshot negative = CreateScoreSnapshot();
        negative.Coop.ParticipantScores[0].Score = -1;
        RequireInvalid(negative);
        MatchSnapshot missing = CreateScoreSnapshot();
        missing.Coop.ParticipantScores.RemoveAt(1);
        RequireInvalid(missing);
        MatchSnapshot duplicate = CreateScoreSnapshot();
        duplicate.Coop.ParticipantScores[1].PlayerId = MasterId;
        RequireInvalid(duplicate);
        MatchSnapshot reordered = CreateScoreSnapshot();
        BattleCoopParticipantScore first = reordered.Coop.ParticipantScores[0];
        reordered.Coop.ParticipantScores[0] = reordered.Coop.ParticipantScores[1];
        reordered.Coop.ParticipantScores[1] = first;
        RequireInvalid(reordered);
        MatchSnapshot mismatch = CreateScoreSnapshot();
        mismatch.Coop.ObjectiveScore++;
        RequireInvalid(mismatch);
        MatchSnapshot overflow = CreateScoreSnapshot();
        overflow.Coop.ParticipantScores[0].Score = int.MaxValue;
        RequireInvalid(overflow);
        MatchSnapshot wrongMission = CreateScoreSnapshot();
        wrongMission.Coop.MissionType = "KillXEnemies";
        RequireInvalid(wrongMission);
    }

    private static void VerifyDepartureAndPrestart()
    {
        MatchSnapshot departed = CreateScoreSnapshot();
        departed.Players[1].CoopDeparted = true;
        departed.Players[1].Ready = false;
        departed.Coop.ParticipantIds.Remove(PeerId);
        departed.Coop.PeerCompletionPlayerIds.Clear();
        CoopScoreProjection view = CoopScoreProjection.ForPlayer(departed, MasterId);
        Require(view.LocalScore == 10 && view.PeerScore == 5 && view.TotalScore == 15,
            "An admitted peer's earned contribution must survive departure without granting peer completion.");

        MatchSnapshot prestart = CreateScoreSnapshot();
        prestart.Phase = BattlePhase.Waiting;
        prestart.EndTick = 0;
        prestart.TerminalReason = "";
        prestart.Coop.Started = false;
        prestart.Coop.Completed = false;
        prestart.Coop.SuccessScores.Clear();
        prestart.Coop.PeerCompletionPlayerIds.Clear();
        RequireInvalid(prestart);
    }

    private static MatchSnapshot CreateScoreSnapshot()
    {
        MatchSnapshot snapshot = CoopOutcomeProjectionTests.CreateSuccess();
        snapshot.Coop.MissionType = "Score";
        snapshot.Coop.ObjectiveScore = 15;
        snapshot.Coop.ParticipantScores.Add(new BattleCoopParticipantScore { PlayerId = MasterId, Score = 10 });
        snapshot.Coop.ParticipantScores.Add(new BattleCoopParticipantScore { PlayerId = PeerId, Score = 5 });
        return snapshot;
    }

    private static void RequireInvalid(MatchSnapshot snapshot)
    {
        try
        {
            CoopScoreProjection.ForPlayer(snapshot, MasterId);
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidDataException("Malformed co-op score selected a HUD projection.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
