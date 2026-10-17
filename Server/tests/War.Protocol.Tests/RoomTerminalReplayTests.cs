using Google.Protobuf;
using War.Client;
using War.Protocol;

/// <summary>Checks phase delivery when immutable terminal snapshots are received repeatedly.</summary>
internal static class RoomTerminalReplayTests
{
    internal static int Run()
    {
        int checks = 0;
        foreach (var phase in new[] { BattlePhase.Ended, BattlePhase.Aborted })
        {
            using var room = CreateRoom();
            int callbacks = 0;
            room.PhaseChanged += _ => callbacks++;
            var terminal = new MatchSnapshot { Phase = phase, MatchId = "terminal-replay", StateRevision = 1 };
            var original = terminal.Clone();
            room.Observe(terminal);
            Require(room.Phase == SelfHostedRoomPhase.Closed && callbacks == 1, "Terminal must close the room once.");
            room.Observe(original.Clone());
            Require(callbacks == 1, "An exact terminal replay must not repeat the room phase callback.");
            terminal.TerminalReason = "mutated-caller-copy";
            room.Observe(original.Clone());
            Require(callbacks == 1, "The caller must not be able to mutate remembered terminal evidence.");
            Reject(() => room.Observe(terminal), "A changed terminal replay must be rejected.");
            Reject(() => room.Observe(new MatchSnapshot { Phase = BattlePhase.Running }),
                "A closed terminal room must never return to Running.");
            room.Dispose();
            Reject(() => room.Observe(original), "A disposed room must reject even an exact terminal replay.");
            checks += 6;
        }

        Console.WriteLine("PASS: " + checks + " terminal room replay and closure checks");
        return checks;
    }

    private static SelfHostedRoomLifecycle CreateRoom()
    {
        const int FixturePort = 30000;
        const int SessionKeyBytes = 32;
        const int TicketLifetimeSeconds = 60;
        var grant = new MatchConnectionGrant
        {
            Host = "127.0.0.1", Port = FixturePort, SessionId = 1,
            MatchId = "terminal-replay", PlayerId = new string('a', 32), ManifestHash = new string('b', 64),
            SessionKey = ByteString.CopyFrom(new byte[SessionKeyBytes]), Ticket = "fixture-ticket",
            ExpiresUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + TicketLifetimeSeconds,
        };
        return new SelfHostedRoomLifecycle(new MatchConnection(grant));
    }

    private static void Reject(Action action, string message)
    {
        try
        {
            action();
        }
        catch (InvalidOperationException)
        {
            return;
        }

        throw new Exception(message);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
