using Google.Protobuf;
using War.BattleServer;
using War.Protocol;

/// <summary>Distinguishes co-op loading cancellation from an actual mission's terminal forfeit.</summary>
internal static class CoopPrestartCancellationTests
{
    private const ulong CancellationTick = 3;

    internal static void Run(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        VerifyWaitingCancellation(sources);
        VerifyReadyPeerCancellation(sources);
        VerifyStartedForfeit(sources);
        Console.WriteLine("PASS: co-op prestart cancellation, immutable replay and started-only forfeit evidence");
    }

    private static void VerifyWaitingCancellation(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = CreateRuntime(sources);
        string playerId = sources.Manifest.Players[0].PlayerId;
        runtime.Admit(playerId);
        runtime.Advance(CancellationTick);
        MatchReply reply = runtime.Command(playerId, CreateForfeitCommand(1));
        MatchSnapshot terminal = runtime.TerminalEvidenceSnapshot();
        Require(reply.Code == "forfeit" && terminal.Phase == BattlePhase.Aborted &&
            terminal.TerminalReason == "cancelled-before-start" && !terminal.Coop.Started &&
            terminal.WinnerPlayerId.Length == 0 && !terminal.RewardEligible,
            "Leaving while waiting for the other ally must cancel without a played or reward-bearing outcome.");
        Validate(sources, terminal);
        VerifyFrozenReplay(runtime, playerId, CreateForfeitCommand(1), reply);
        MatchSnapshot forgedForfeit = terminal.Clone();
        forgedForfeit.Phase = BattlePhase.Ended;
        forgedForfeit.TerminalReason = "forfeit";
        RequireInvalid(() => Validate(sources, forgedForfeit));
    }

    private static void VerifyReadyPeerCancellation(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = CreateRuntime(sources);
        foreach (ParticipantManifest player in sources.Manifest.Players)
        {
            runtime.Admit(player.PlayerId);
        }

        string playerId = sources.Manifest.Players[0].PlayerId;
        SendReadyCommand(runtime, playerId);
        runtime.Advance(CancellationTick);
        MatchReply reply = runtime.Command(playerId, CreateForfeitCommand(2));
        MatchSnapshot terminal = runtime.TerminalEvidenceSnapshot();
        Require(reply.Code == "forfeit" && terminal.Phase == BattlePhase.Aborted &&
            terminal.TerminalReason == "cancelled-before-start" && !terminal.Coop.Started &&
            terminal.StartTick == 0 && terminal.Coop.DeadlineTick == 0 && terminal.Coop.EnemySpawns.Count == 0,
            "One ready ally must not turn loading cancellation into mission play.");
        Validate(sources, terminal);
        VerifyFrozenReplay(runtime, playerId, CreateForfeitCommand(2), reply);
    }

    private static void VerifyStartedForfeit(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        CoopMatchRuntime runtime = CreateRuntime(sources);
        foreach (ParticipantManifest player in sources.Manifest.Players)
        {
            runtime.Admit(player.PlayerId);
            SendReadyCommand(runtime, player.PlayerId);
        }

        Require(runtime.Snapshot().Coop.Started, "Both ready allies must actually start the mission.");
        string playerId = sources.Manifest.Players[1].PlayerId;
        MatchCommand departure = CreateForfeitCommand(2);
        MatchReply departed = runtime.Command(playerId, departure);
        MatchSnapshot running = departed.Snapshot;
        BattlePlayerState inactive = running.Players.Single(player => player.PlayerId == playerId);
        Require(departed.Code == "forfeit" && running.Phase == BattlePhase.Running &&
            running.Coop.ParticipantIds.Count == 1 && inactive.CoopDeparted &&
            !inactive.Ready && !inactive.Dead && inactive.Health == inactive.MaxHealth &&
            !runtime.Resume(playerId),
            "One departing peer must deactivate without killing the survivor's running mission.");
        Require(runtime.Command(playerId, departure.Clone()).ToByteArray().AsSpan()
            .SequenceEqual(departed.ToByteArray()), "Departure retries must return the original response.");
        Require(runtime.Command(playerId, CreateForfeitCommand(3)).Code == "coop-peer-departed",
            "A departed peer must not submit a new gameplay mutation.");
        string survivorId = sources.Manifest.Players[0].PlayerId;
        runtime.Command(survivorId, CreateForfeitCommand(2));
        MatchSnapshot terminal = runtime.TerminalEvidenceSnapshot();
        Require(terminal.Phase == BattlePhase.Ended && terminal.TerminalReason == "forfeit" &&
            terminal.Coop.Started && terminal.Coop.ParticipantIds.Count == 0 &&
            terminal.WinnerPlayerId.Length == 0 && !terminal.RewardEligible,
            "The final active departure must end the mission without a winner or reward.");
        Validate(sources, terminal);
        MatchSnapshot forged = terminal.Clone();
        forged.Players[0].CoopDeparted = false;
        RequireInvalid(() => Validate(sources, forged));
    }

    private static void VerifyFrozenReplay(CoopMatchRuntime runtime, string playerId,
        MatchCommand command, MatchReply originalReply)
    {
        byte[] before = runtime.TerminalEvidenceSnapshot().ToByteArray();
        MatchReply replay = runtime.Command(playerId, command.Clone());
        Require(replay.ToByteArray().AsSpan().SequenceEqual(originalReply.ToByteArray()),
            "An exact cancellation retry must return the original immutable reply.");
        runtime.Advance(runtime.Snapshot().ServerTick + MatchManifest.TickRate);
        Require(runtime.TerminalEvidenceSnapshot().ToByteArray().AsSpan().SequenceEqual(before),
            "Cancelled missions must freeze the host tick and terminal evidence.");
    }

    private static CoopMatchRuntime CreateRuntime(CoopObstacleVolleyRuntimeTests.Sources sources)
    {
        return new CoopMatchRuntime(sources.Manifest, sources.Missions, sources.Spawns,
            sources.Routes, sources.Combat, playerWeaponContent: sources.Content);
    }

    private static void SendReadyCommand(CoopMatchRuntime runtime, string playerId)
    {
        MatchReply reply = runtime.Command(playerId, new MatchCommand
        {
            CommandId = 1,
            Ready = new ReadyCommand { ManifestHash = runtime.ManifestHash }
        });
        Require(reply.Code == "ready", "The fixture's ready command must be accepted.");
    }

    private static MatchCommand CreateForfeitCommand(ulong commandId)
    {
        return new MatchCommand { CommandId = commandId, Forfeit = new ForfeitCommand() };
    }

    private static void Validate(CoopObstacleVolleyRuntimeTests.Sources sources, MatchSnapshot snapshot)
    {
        CoopTerminalScoreValidator.ValidateNonSuccess(snapshot, sources.Manifest, sources.Missions,
            sources.Combat, spawnPoints: sources.Spawns);
    }

    private static void RequireInvalid(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidDataException("A prestart mission was accepted as a terminal forfeit.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
