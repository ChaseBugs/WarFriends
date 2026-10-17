using Google.Protobuf;
using War.BattleServer;
using War.Protocol;
using War.Shared;

/// <summary>Enumerates the single-reader orderings of ready commands, countdown expiry and cancellation.</summary>
internal static class PrestartCancellationOrderingTests
{
    private const int CountdownSeconds = 2;
    private const int ExpectedOrderCount = 24;
    private const int ExpectedRunningWins = 2;
    private const ulong FirstReadyCommandId = 1;
    private const ulong LateReadyCommandId = 2;
    private const ulong CountdownTicks = CountdownSeconds * MatchManifest.TickRate;
    private static readonly string FirstPlayer = new('a', 32);
    private static readonly string SecondPlayer = new('b', 32);

    internal static int Run()
    {
        int cases = 0;
        int runningWins = 0;
        foreach (var order in Orders([Operation.ReadyFirst, Operation.ReadySecond, Operation.Advance, Operation.Cancel]))
        {
            if (!VerifyOrder(order))
            {
                runningWins++;
            }

            cases++;
        }

        Require(cases == ExpectedOrderCount && runningWins == ExpectedRunningWins,
            "Coverage must exercise both cancellation wins and both ready-order permutations that start battle first.");
        var cancelled = new MatchEngine(CreateManifest());
        Require(cancelled.CancelBeforeStart() && !cancelled.Admit(FirstPlayer) && !cancelled.Admit(SecondPlayer),
            "Cancellation before admission must reject both late participants.");
        Console.WriteLine("PASS: " + (cases + 1) + " prestart admission/ready/tick/cancellation orderings");
        return cases + 1;
    }

    private static bool VerifyOrder(Operation[] order)
    {
        var match = new MatchEngine(CreateManifest());
        Require(match.Admit(FirstPlayer) && match.Admit(SecondPlayer), "Ordering fixture admission failed.");
        byte[]? cancellationEvidence = null;
        foreach (var operation in order)
        {
            switch (operation)
            {
                case Operation.ReadyFirst:
                    Ready(match, FirstPlayer);
                    break;
                case Operation.ReadySecond:
                    Ready(match, SecondPlayer);
                    break;
                case Operation.Advance:
                    match.Advance(CountdownTicks);
                    break;
                case Operation.Cancel:
                    if (match.CancelBeforeStart())
                    {
                        cancellationEvidence = match.TerminalEvidenceSnapshot().ToByteArray();
                    }
                    break;
            }
        }

        VerifyOutcome(match, cancellationEvidence);
        return cancellationEvidence != null;
    }

    private static void VerifyOutcome(MatchEngine match, byte[]? cancellationEvidence)
    {
        match.Advance(CountdownTicks * 2);
        Ready(match, FirstPlayer, LateReadyCommandId);
        Ready(match, SecondPlayer, LateReadyCommandId);
        if (cancellationEvidence == null)
        {
            Require(match.Snapshot().Phase == BattlePhase.Running && !match.CancelBeforeStart(),
                "A rejected cancellation must preserve the already running battle.");
            return;
        }

        string digest = TerminalResultDigest.Compute(cancellationEvidence);
        var terminal = TerminalOutbox.ValidatePayload(cancellationEvidence, match.MatchId, digest);
        Require(terminal.Phase == BattlePhase.Aborted && terminal.TerminalReason == "cancelled-before-start" &&
            terminal.WinnerPlayerId.Length == 0 && !terminal.RewardEligible,
            "A successful prestart cancellation must never manufacture a winner or reward.");
        Require(match.TerminalEvidenceSnapshot().ToByteArray().SequenceEqual(cancellationEvidence) &&
            !match.CancelBeforeStart(),
            "Late ready commands, ticks and repeated cancellation must preserve exact terminal bytes.");
    }

    private static void Ready(MatchEngine match, string playerId, ulong commandId = FirstReadyCommandId)
    {
        match.Command(playerId, new MatchCommand
        {
            CommandId = commandId, Ready = new ReadyCommand { ManifestHash = match.ManifestHash }
        });
    }

    private static MatchManifest CreateManifest()
    {
        string revision = new('a', 64);
        // Synthetic transport fixture values are not recovered weapon balancing authority.
        var weapon = new WeaponManifest("ordering-fixture-rifle", 2, 3, 0.1, 0.2);
        return new MatchManifest("ordering-fixture", "ordering-host", "fixture-map", revision, revision,
            MatchManifest.PrototypeMode, 10, 60, 10,
            [new ParticipantManifest(FirstPlayer, weapon), new ParticipantManifest(SecondPlayer, weapon)]);
    }

    private static IEnumerable<Operation[]> Orders(Operation[] remaining)
    {
        if (remaining.Length == 0)
        {
            yield return [];
            yield break;
        }

        for (int index = 0; index < remaining.Length; index++)
        {
            var tail = remaining.Where(operation => operation != remaining[index]).ToArray();
            foreach (var suffix in Orders(tail))
            {
                yield return new[] { remaining[index] }.Concat(suffix).ToArray();
            }
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private enum Operation
    {
        ReadyFirst,
        ReadySecond,
        Advance,
        Cancel
    }
}
