using War.BattleServer;
using War.Client;
using War.Persistence;
using War.Protocol;

/// <summary>Exercises actual HTTP cancellation against UDP ready/start traffic in the same Worker match.</summary>
internal sealed class LiveQueueCancellationRaceChecks
{
    private const int MaximumPolls = 100;
    private const int PollDelayMilliseconds = 100;
    private readonly ScopedQueueLiveChecks.Scenario _scenario;
    private readonly BattleMatchQueueStore _queue;
    private readonly BattleResultStore _results;

    internal LiveQueueCancellationRaceChecks(
        ScopedQueueLiveChecks.Scenario scenario, BattleMatchQueueStore queue, BattleResultStore results)
    {
        _scenario = scenario;
        _queue = queue;
        _results = results;
    }

    internal async Task RunAsync()
    {
        await VerifyCancelBeforeReadyAsync();
        await VerifyOverlappingRequestsAsync();
        await VerifyRunningFirstAsync();
        Console.WriteLine("PASS: real HTTP/UDP late-ready, overlapping ready/cancel and Running-first cancellation");
    }

    private async Task VerifyCancelBeforeReadyAsync()
    {
        using (var pair = await OpenAsync())
        {
            await pair.First.ReadyAsync(_scenario.CancellationToken);
            var cancelled = await CancelAsync(pair);
            Require(cancelled.Code == "cancelled", "Cancellation before the other ready must succeed.");
            var lateReady = await pair.Second.ReadyAsync(_scenario.CancellationToken);
            Require(lateReady.Snapshot.Phase == BattlePhase.Aborted, "Late UDP ready must observe the aborted match.");
            await VerifyResultAsync(pair, BattlePhase.Aborted);
        }
    }

    private async Task VerifyOverlappingRequestsAsync()
    {
        using (var pair = await OpenAsync())
        {
            await pair.First.ReadyAsync(_scenario.CancellationToken);
            var ready = pair.Second.ReadyAsync(_scenario.CancellationToken);
            var cancellation = CancelAsync(pair);
            await Task.WhenAll(ready, cancellation);
            if (cancellation.Result.Code == "cancelled")
            {
                await VerifyResultAsync(pair, BattlePhase.Aborted);
            }
            else
            {
                Require(cancellation.Result.Code == "already-paired",
                    "Race returned unsupported cancellation authority.");
                await FinishRunningAsync(pair);
            }
        }
    }

    private async Task VerifyRunningFirstAsync()
    {
        using (var pair = await OpenAsync())
        {
            await pair.First.ReadyAsync(_scenario.CancellationToken);
            await pair.Second.ReadyAsync(_scenario.CancellationToken);
            await WaitForRunningAsync(pair);
            Require((await CancelAsync(pair)).Code == "already-paired", "HTTP cancellation must not abort Running.");
            Require(await _results.Get(pair.MatchId, _scenario.CancellationToken) == null &&
                (await _queue.Existing(pair.FirstPlayer, _scenario.CancellationToken))?.MatchId == pair.MatchId,
                "A rejected cancellation must not store terminal evidence or release the running pair.");
            await FinishRunningAsync(pair);
        }
    }

    private async Task<Pair> OpenAsync()
    {
        var token = _scenario.CancellationToken;
        var first = await _scenario.Left.CreateMatchQueueAttemptAsync(_scenario.AccessTokens[0], token);
        var second = await _scenario.Right.CreateMatchQueueAttemptAsync(_scenario.AccessTokens[1], token);
        await _scenario.Left.JoinMatchQueueAsync(_scenario.AccessTokens[0], first.Token, token);
        await _scenario.Right.JoinMatchQueueAsync(_scenario.AccessTokens[1], second.Token, token);
        var grants = await Task.WhenAll(
            _scenario.Left.FindMatchAsync(_scenario.AccessTokens[0], first.Token, TimeSpan.FromSeconds(5), token),
            _scenario.Right.FindMatchAsync(_scenario.AccessTokens[1], second.Token, TimeSpan.FromSeconds(5), token));
        var pair = new Pair(grants[0], grants[1], first.Token);
        try
        {
            var admissions = await Task.WhenAll(pair.First.ConnectAsync(token), pair.Second.ConnectAsync(token));
            Require(admissions.All(reply => reply.Code == "admitted"), "Race participants could not enter UDP match.");
            return pair;
        }
        catch
        {
            pair.Dispose();
            throw;
        }
    }

    private Task<MatchQueueReply> CancelAsync(Pair pair)
    {
        return _scenario.Left.CancelMatchQueueAsync(
            _scenario.AccessTokens[0], pair.AttemptToken, _scenario.CancellationToken);
    }

    private async Task WaitForRunningAsync(Pair pair)
    {
        for (int poll = 0; poll < MaximumPolls; poll++)
        {
            var reply = await pair.First.PollAsync(_scenario.CancellationToken);
            if (reply.Snapshot.Phase == BattlePhase.Running)
            {
                return;
            }

            await Task.Delay(PollDelayMilliseconds, _scenario.CancellationToken);
        }

        throw new Exception("The authoritative countdown did not reach Running.");
    }

    private async Task FinishRunningAsync(Pair pair)
    {
        await WaitForRunningAsync(pair);
        await pair.First.ForfeitAsync(_scenario.CancellationToken);
        await VerifyResultAsync(pair, BattlePhase.Ended);
    }

    private async Task VerifyResultAsync(Pair pair, BattlePhase expectedPhase)
    {
        for (int poll = 0; poll < MaximumPolls; poll++)
        {
            var stored = await _results.Get(pair.MatchId, _scenario.CancellationToken);
            if (stored != null && await _queue.Existing(pair.FirstPlayer, _scenario.CancellationToken) == null)
            {
                var terminal = TerminalOutbox.ValidatePayload(stored.Snapshot, pair.MatchId, stored.Digest);
                Require(terminal.Phase == expectedPhase && terminal.ManifestHash == pair.ManifestHash,
                    "Stored terminal authority differs from the observed race outcome.");
                Require(expectedPhase == BattlePhase.Aborted
                    ? terminal.TerminalReason == "cancelled-before-start" && terminal.WinnerPlayerId.Length == 0
                    : terminal.TerminalReason == "forfeit" && terminal.WinnerPlayerId == pair.SecondPlayer,
                    "Cancellation and running forfeit must preserve their distinct authoritative outcomes.");
                Require(await _queue.Existing(pair.SecondPlayer, _scenario.CancellationToken) == null,
                    "Terminal acceptance did not release both roster members.");
                return;
            }

            await Task.Delay(PollDelayMilliseconds, _scenario.CancellationToken);
        }

        throw new Exception("HTTP/UDP race did not publish accepted terminal evidence and release its pair.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }

    private sealed class Pair : IDisposable
    {
        internal Pair(MatchConnectionGrant first, MatchConnectionGrant second, string attemptToken)
        {
            First = new MatchConnection(first);
            Second = new MatchConnection(second);
            FirstPlayer = first.PlayerId;
            SecondPlayer = second.PlayerId;
            MatchId = first.MatchId;
            ManifestHash = first.ManifestHash;
            AttemptToken = attemptToken;
        }

        internal MatchConnection First { get; }
        internal MatchConnection Second { get; }
        internal string FirstPlayer { get; }
        internal string SecondPlayer { get; }
        internal string MatchId { get; }
        internal string ManifestHash { get; }
        internal string AttemptToken { get; }

        /// <summary>Releases only the two UDP clients owned by this fixture.</summary>
        public void Dispose()
        {
            First.Dispose();
            Second.Dispose();
        }
    }
}
