using War.Client;
using War.Protocol;

/// <summary>Checks shared co-op presentation without promoting it to a wallet or progression grant.</summary>
internal static class CoopOutcomeProjectionTests
{
    private const string MasterId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string PeerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";

    internal static int Run()
    {
        VerifySuccessAndDeparture();
        VerifyMalformedResults();
        VerifyAbort();
        return 10;
    }

    private static void VerifySuccessAndDeparture()
    {
        MatchSnapshot snapshot = CreateSuccess();
        Require(MatchOutcomeProjection.ForPlayer(snapshot, MasterId) == ClientGameEndReason.MissionSuccess,
            "The source master must display mission success without a PvP winner identity.");
        Require(MatchOutcomeProjection.ForPlayer(snapshot, PeerId) == ClientGameEndReason.MissionSuccess,
            "The source peer must display the shared mission success without owning a star row.");
        snapshot.Players[1].CoopDeparted = true;
        snapshot.Players[1].Ready = false;
        snapshot.Coop.ParticipantIds.Remove(PeerId);
        snapshot.Coop.PeerCompletionPlayerIds.Clear();
        Require(MatchOutcomeProjection.ForPlayer(snapshot, PeerId) == ClientGameEndReason.Forfeit,
            "Shared mission success must not resurrect a peer's already completed personal Forfeit.");
    }

    private static void VerifyMalformedResults()
    {
        MatchSnapshot winner = CreateSuccess();
        winner.WinnerPlayerId = MasterId;
        RequireInvalid(winner);
        MatchSnapshot peerStars = CreateSuccess();
        peerStars.Coop.SuccessScores[0].PlayerId = PeerId;
        RequireInvalid(peerStars);
        MatchSnapshot missingRole = CreateSuccess();
        missingRole.Coop.SceneMasterPlayerId = "";
        RequireInvalid(missingRole);
        MatchSnapshot missingPeer = CreateSuccess();
        missingPeer.Coop.PeerCompletionPlayerIds.Clear();
        RequireInvalid(missingPeer);
        MatchSnapshot earlyFailure = CreateSuccess();
        ClearSuccess(earlyFailure);
        earlyFailure.Coop.Failed = true;
        earlyFailure.TerminalReason = "mission-failed";
        RequireInvalid(earlyFailure);
        MatchSnapshot runningMasterKia = CreateSuccess();
        ClearSuccess(runningMasterKia);
        runningMasterKia.Phase = BattlePhase.Running;
        runningMasterKia.EndTick = 0;
        runningMasterKia.Players[0].Dead = true;
        runningMasterKia.Players[0].Health = 0;
        runningMasterKia.Players[0].CoopDeathTick = runningMasterKia.ServerTick;
        runningMasterKia.Players[0].DamageRevision = 1;
        RequireInvalid(runningMasterKia);
    }

    private static void VerifyAbort()
    {
        MatchSnapshot snapshot = CreateSuccess();
        ClearSuccess(snapshot);
        snapshot.Phase = BattlePhase.Aborted;
        snapshot.TerminalReason = "host-shutdown";
        snapshot.Coop.Failed = true;
        Require(MatchOutcomeProjection.ForPlayer(snapshot, MasterId) == ClientGameEndReason.None &&
            MatchOutcomeProjection.ForPlayer(snapshot, PeerId) == ClientGameEndReason.None,
            "A host abort must remain a cancelled presentation rather than an invented win or loss.");
    }

    private static MatchSnapshot CreateSuccess()
    {
        var snapshot = new MatchSnapshot
        {
            Phase = BattlePhase.Ended,
            TerminalReason = "mission-success",
            ServerTick = 10,
            EndTick = 10,
            Coop = new BattleCoopState
            {
                MissionType = "KillXEnemies",
                Started = true,
                Completed = true,
                DeadlineTick = 100,
                SceneMasterPlayerId = MasterId
            }
        };
        foreach (string playerId in new[] { MasterId, PeerId })
        {
            snapshot.Players.Add(new BattlePlayerState
            {
                PlayerId = playerId, Admitted = true, Ready = true, Health = 100, MaxHealth = 100
            });
            snapshot.Coop.ParticipantIds.Add(playerId);
        }
        snapshot.Coop.SuccessScores.Add(new BattleCoopPlayerScore { PlayerId = MasterId, Score = 100, Stars = 1 });
        snapshot.Coop.PeerCompletionPlayerIds.Add(PeerId);
        return snapshot;
    }

    private static void ClearSuccess(MatchSnapshot snapshot)
    {
        snapshot.TerminalReason = "";
        snapshot.Coop.Completed = false;
        snapshot.Coop.SuccessScores.Clear();
        snapshot.Coop.PeerCompletionPlayerIds.Clear();
    }

    private static void RequireInvalid(MatchSnapshot snapshot)
    {
        try
        {
            MatchOutcomeProjection.ForPlayer(snapshot, MasterId);
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidDataException("Malformed co-op state selected a Client presentation result.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
