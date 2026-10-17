using War.Client;
using War.Protocol;

/// <summary>Checks source HUD projection without granting local overtime or terminal authority.</summary>
internal static class PvpMatchClockTests
{
    private const ulong StartTick = 30;
    private const ulong EndTick = 330;
    private const ulong PrestartDelayTicks = 60;
    private const ulong CurrentTick = 90;
    private const float ExpectedSeconds = 8f;

    internal static int Run()
    {
        int checks = VerifyPhases();
        checks += VerifyInvalidClocks();
        Console.WriteLine("PASS: " + checks + " authoritative PvP clock projections");
        return checks;
    }

    private static int VerifyPhases()
    {
        var waiting = new MatchSnapshot { Phase = BattlePhase.Waiting, ServerTick = CurrentTick };
        Require(PvpMatchClock.FromSnapshot(waiting).RemainingSeconds == 0f, "Waiting has no scheduled clock.");
        MatchSnapshot countdown = Running();
        countdown.Phase = BattlePhase.Countdown;
        countdown.ServerTick = StartTick - 1;
        Require(PvpMatchClock.FromSnapshot(countdown).RemainingSeconds == 10f,
            "Loading does not add the prestart delay to match duration.");
        MatchSnapshot running = Running();
        PvpMatchClock view = PvpMatchClock.FromSnapshot(running);
        Require(view.RemainingSeconds == ExpectedSeconds && !view.IsOvertime, "The clock uses host ticks.");
        running.PauseHostTick = 1000;
        Require(PvpMatchClock.FromSnapshot(running).RemainingSeconds == ExpectedSeconds,
            "Advancing disconnect grace does not advance simulation time.");
        running.ServerTick = EndTick;
        Require(PvpMatchClock.FromSnapshot(running).RemainingSeconds == 0f &&
            !PvpMatchClock.FromSnapshot(running).IsOvertime, "Zero display time does not infer overtime.");
        running.EndTick = 0;
        running.Overtime = true;
        Require(PvpMatchClock.FromSnapshot(running).IsOvertime, "Only host state confirms overtime.");
        foreach (BattlePhase phase in new[] { BattlePhase.Ended, BattlePhase.Aborted })
        {
            running.Phase = phase;
            running.EndTick = running.ServerTick;
            Require(PvpMatchClock.FromSnapshot(running).RemainingSeconds == 0f &&
                PvpMatchClock.FromSnapshot(running).IsOvertime, "A terminal clock retains source overtime metadata.");
        }

        var canceled = new MatchSnapshot
        {
            Phase = BattlePhase.Aborted,
            ServerTick = CurrentTick,
            EndTick = CurrentTick,
            StartTick = CurrentTick + PrestartDelayTicks
        };
        Require(PvpMatchClock.FromSnapshot(canceled).RemainingSeconds == 0f &&
            !PvpMatchClock.FromSnapshot(canceled).IsOvertime, "A prestart cancellation retains its future start tick.");

        return 9;
    }

    private static int VerifyInvalidClocks()
    {
        var invalid = new List<MatchSnapshot>();
        MatchSnapshot changed = Running();
        changed.EndTick = 0;
        invalid.Add(changed);
        changed = Running();
        changed.Overtime = true;
        invalid.Add(changed);
        changed = Running();
        changed.StartTick = CurrentTick + 1;
        invalid.Add(changed);
        changed = Running();
        changed.EndTick = CurrentTick - 1;
        invalid.Add(changed);
        changed = Running();
        changed.EndTick = ulong.MaxValue;
        invalid.Add(changed);
        changed = Running();
        changed.Phase = BattlePhase.Countdown;
        invalid.Add(changed);
        changed = Running();
        changed.Phase = BattlePhase.Waiting;
        invalid.Add(changed);
        changed = Running();
        changed.Phase = BattlePhase.Ended;
        invalid.Add(changed);
        changed = Running();
        changed.Phase = BattlePhase.Unspecified;
        invalid.Add(changed);
        changed = Running();
        changed.Coop = new BattleCoopState();
        invalid.Add(changed);
        changed = Running();
        changed.Arena = new BattleArenaState();
        invalid.Add(changed);
        changed = Running();
        changed.Phase = BattlePhase.Aborted;
        changed.EndTick = CurrentTick;
        changed.StartTick = CurrentTick + PrestartDelayTicks + 1;
        invalid.Add(changed);
        changed = Running();
        changed.Phase = BattlePhase.Aborted;
        changed.EndTick = CurrentTick;
        changed.StartTick = CurrentTick + 1;
        changed.Overtime = true;
        invalid.Add(changed);
        foreach (MatchSnapshot snapshot in invalid)
        {
            ExpectInvalid(snapshot);
        }

        return invalid.Count;
    }

    private static MatchSnapshot Running()
    {
        return new MatchSnapshot
        {
            Phase = BattlePhase.Running,
            StartTick = StartTick,
            EndTick = EndTick,
            ServerTick = CurrentTick
        };
    }

    private static void ExpectInvalid(MatchSnapshot snapshot)
    {
        try
        {
            PvpMatchClock.FromSnapshot(snapshot);
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new Exception("Malformed clock became presentation authority.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
