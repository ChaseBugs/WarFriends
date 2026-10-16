using System;
using System.IO;
using Google.Protobuf;
using UnityEditor;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks portable co-op result projection in Unity Mono without rendering or changing game assets.</summary>
public static class UnityCoopOutcomeAudit
{
    private const string MasterId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string PeerId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";

    /// <summary>Runs nine Editor-mode checks against the freshly built portable SDK.</summary>
    public static void Run()
    {
        try
        {
            Require((byte)ClientGameEndReason.Kia == 8 && (byte)ClientGameEndReason.MissionFailed == 9 &&
                (byte)ClientGameEndReason.MissionSuccess == 10, "Presentation codes must match the recovered enum.");
            VerifySuccessAndSpectating();
            VerifyMasterFailure();
            VerifyForfeit();
            VerifyDepartedPeer();
            VerifyMalformedResults();
            File.WriteAllText(Path.Combine(Application.dataPath, "../coop-outcome-unity-audit.json"),
                "{\"schemaVersion\":1,\"checks\":9,\"scope\":\"edit-mode portable SDK projection\"}\n");
            Debug.Log("PASS: nine source co-op result projections in Unity Mono; no game-over UI or rewards applied.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void VerifySuccessAndSpectating()
    {
        MatchSnapshot success = CreateSuccess();
        Require(MatchOutcomeProjection.ForPlayer(success, MasterId) == ClientGameEndReason.MissionSuccess &&
            MatchOutcomeProjection.ForPlayer(success, PeerId) == ClientGameEndReason.MissionSuccess,
            "Both connected players must receive the shared source success reason.");
        MatchSnapshot spectating = CreateSuccess();
        SetPeerKia(spectating);
        SetUnsuccessful(spectating, "");
        spectating.Coop.Failed = false;
        spectating.Phase = BattlePhase.Running;
        spectating.EndTick = 0;
        Require(MatchOutcomeProjection.ForPlayer(spectating, PeerId) == ClientGameEndReason.None,
            "A running peer's private KIA screen must not become a shared terminal result.");
        SetPeerKia(success);
        Require(MatchOutcomeProjection.ForPlayer(success, PeerId) == ClientGameEndReason.MissionSuccess,
            "The shared finish RPC supersedes the connected peer's prior KIA presentation.");
    }

    private static void SetPeerKia(MatchSnapshot snapshot)
    {
        snapshot.Players[1].Dead = true;
        snapshot.Players[1].Health = 0;
        snapshot.Players[1].DamageRevision = 1;
        snapshot.Players[1].CoopDeathTick = 0;
    }

    private static void VerifyMasterFailure()
    {
        MatchSnapshot failure = CreateMasterFailure();
        failure = MatchSnapshot.Parser.ParseFrom(failure.ToByteArray());
        Require(failure.Players[0].HasCoopDeathTick && failure.Players[0].CoopDeathTick == 0 &&
            MatchOutcomeProjection.ForPlayer(failure, MasterId) == ClientGameEndReason.MissionFailed &&
            MatchOutcomeProjection.ForPlayer(failure, PeerId) == ClientGameEndReason.MissionFailed,
            "A real tick-zero master KIA must project shared failure after native protobuf round trip.");
    }

    private static MatchSnapshot CreateMasterFailure()
    {
        MatchSnapshot failure = CreateSuccess();
        SetUnsuccessful(failure, "mission-failed");
        failure.ServerTick = 0;
        failure.EndTick = 0;
        failure.Players[0].Health = 0;
        failure.Players[0].Dead = true;
        failure.Players[0].DamageRevision = 1;
        failure.Players[0].CoopDeathTick = 0;
        return failure;
    }

    private static void VerifyForfeit()
    {
        MatchSnapshot forfeit = CreateSuccess();
        SetUnsuccessful(forfeit, "forfeit");
        forfeit.Players[0].CoopDeparted = true;
        forfeit.Players[0].Ready = false;
        forfeit.Coop.ParticipantIds.Remove(MasterId);
        Require(MatchOutcomeProjection.ForPlayer(forfeit, MasterId) == ClientGameEndReason.Forfeit &&
            MatchOutcomeProjection.ForPlayer(forfeit, PeerId) == ClientGameEndReason.Forfeit,
            "Source master departure must not grant its peer a PvP WinByForfeit.");
    }

    private static void VerifyDepartedPeer()
    {
        MatchSnapshot success = CreateSuccess();
        success.Players[1].CoopDeparted = true;
        success.Players[1].Ready = false;
        success.Coop.ParticipantIds.Remove(PeerId);
        success.Coop.PeerCompletionPlayerIds.Clear();
        Require(MatchOutcomeProjection.ForPlayer(success, PeerId) == ClientGameEndReason.Forfeit &&
            MatchOutcomeProjection.ForPlayer(success, MasterId) == ClientGameEndReason.MissionSuccess,
            "The surviving master's later success cannot resurrect a departed peer.");
    }

    private static void VerifyMalformedResults()
    {
        MatchSnapshot winner = CreateSuccess();
        winner.WinnerPlayerId = MasterId;
        RequireInvalid(winner);
        MatchSnapshot missingDeath = CreateMasterFailure();
        missingDeath.Players[0].ClearCoopDeathTick();
        RequireInvalid(missingDeath);
    }

    private static MatchSnapshot CreateSuccess()
    {
        var snapshot = new MatchSnapshot
        {
            Phase = BattlePhase.Ended, TerminalReason = "mission-success", ServerTick = 10, EndTick = 10,
            Coop = new BattleCoopState
            {
                MissionType = "KillXEnemies", Started = true, Completed = true,
                DeadlineTick = 100, SceneMasterPlayerId = MasterId
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

    private static void SetUnsuccessful(MatchSnapshot snapshot, string reason)
    {
        snapshot.TerminalReason = reason;
        snapshot.Coop.Completed = false;
        snapshot.Coop.Failed = true;
        snapshot.Coop.SuccessScores.Clear();
        snapshot.Coop.PeerCompletionPlayerIds.Clear();
    }

    private static void RequireInvalid(MatchSnapshot snapshot)
    {
        try
        {
            MatchOutcomeProjection.ForPlayer(snapshot, MasterId);
        }
        catch (Exception failure)
        {
            // The recovered AWS assembly duplicates InvalidDataException's source name; inspect SDK runtime identity.
            if (failure.GetType().FullName == "System.IO.InvalidDataException")
            {
                return;
            }
            throw;
        }
        throw new Exception("Malformed co-op data selected a native Client result.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
