using War.BattleServer;
using War.Client;
using War.Persistence;
using War.Protocol;

/// <summary>Uses the actual Unity attempt owner against real Backend, Worker and MongoDB processes.</summary>
internal sealed class LiveLoadingCancellationChecks
{
    private const int SearchTimeoutSeconds = 10;
    private const int MaximumPolls = 100;
    private const int PollDelayMilliseconds = 100;
    private readonly Uri _backendEndpoint;
    private readonly string[] _accessTokens;
    private readonly BattleMatchQueueStore _queue;
    private readonly BattleResultStore _results;

    internal LiveLoadingCancellationChecks(
        Uri backendEndpoint, string[] accessTokens, BattleMatchQueueStore queue, BattleResultStore results)
    {
        _backendEndpoint = backendEndpoint;
        _accessTokens = accessTokens;
        _queue = queue;
        _results = results;
    }

    internal async Task RunAsync(CancellationToken cancellationToken)
    {
        await VerifyLoadingCancellationAsync(cancellationToken);
        await VerifyRunningRefusalAsync(cancellationToken);
        Console.WriteLine("PASS: actual Unity attempt retains admitted cancellation through real HTTP/UDP, " +
            "accepted Mongo terminal proof and Running-first refusal");
    }

    private async Task VerifyLoadingCancellationAsync(CancellationToken cancellationToken)
    {
        using var pair = await OpenAsync(cancellationToken);
        await pair.First.ReadyAsync(cancellationToken);
        await pair.Owner.CancelAsync();
        var replies = await Task.WhenAll(
            pair.First.PollAsync(cancellationToken), pair.Second.PollAsync(cancellationToken));
        foreach (var reply in replies)
        {
            Require(reply.Snapshot.Phase == BattlePhase.Aborted &&
                reply.Snapshot.TerminalReason == "cancelled-before-start" &&
                !reply.Snapshot.RewardEligible && reply.Snapshot.WinnerPlayerId.Length == 0,
                "Both still-open transports must receive the real unscored cancellation proof.");
        }

        await VerifyAcceptedAsync(pair, BattlePhase.Aborted, cancellationToken);
        await pair.Owner.CompleteAsync();
    }

    private async Task VerifyRunningRefusalAsync(CancellationToken cancellationToken)
    {
        using var pair = await OpenAsync(cancellationToken);
        await pair.First.ReadyAsync(cancellationToken);
        await pair.Second.ReadyAsync(cancellationToken);
        await WaitForRunningAsync(pair, cancellationToken);
        bool refused = false;
        try
        {
            await pair.Owner.CancelAsync();
        }
        catch (InvalidOperationException)
        {
            refused = true;
        }

        Require(refused && await _results.Get(pair.Grant.MatchId, cancellationToken) == null &&
            (await _queue.Existing(pair.Grant.PlayerId, cancellationToken))?.MatchId == pair.Grant.MatchId,
            "Running-first refusal must preserve the active pair without terminal evidence.");
        var reply = await pair.First.PollAsync(cancellationToken);
        Require(reply.Snapshot.Phase == BattlePhase.Running,
            "Refused loading cancellation must leave its UDP transport usable.");
        await pair.First.ForfeitAsync(cancellationToken);
        await VerifyAcceptedAsync(pair, BattlePhase.Ended, cancellationToken);
    }

    private async Task<Pair> OpenAsync(CancellationToken cancellationToken)
    {
        var owner = new SelfHostedMatchmakingAttempt(
            new BackendClient(_backendEndpoint, true), _accessTokens[0]);
        using var peer = new SelfHostedMatchmakingAttempt(
            new BackendClient(_backendEndpoint, true), _accessTokens[1]);
        try
        {
            var grants = await Task.WhenAll(
                owner.FindAsync(SearchTimeoutSeconds), peer.FindAsync(SearchTimeoutSeconds));
            Require(grants[0].MatchId == grants[1].MatchId, "Attempt owners found different matches.");
            var pair = new Pair(owner, grants[0], grants[1]);
            try
            {
                var admissions = await Task.WhenAll(
                    pair.First.ConnectAsync(cancellationToken), pair.Second.ConnectAsync(cancellationToken));
                Require(admissions.All(reply => reply.Code == "admitted"), "UDP admission failed.");
                owner.RetainForLoading();
                await owner.CompleteAsync();
                await peer.CompleteAsync();
                return pair;
            }
            catch
            {
                pair.Dispose();
                throw;
            }
        }
        catch
        {
            owner.Dispose();
            throw;
        }
    }

    private static async Task WaitForRunningAsync(Pair pair, CancellationToken cancellationToken)
    {
        for (int i = 0; i < MaximumPolls; i++)
        {
            var reply = await pair.First.PollAsync(cancellationToken);
            if (reply.Snapshot.Phase == BattlePhase.Running)
            {
                return;
            }

            await Task.Delay(PollDelayMilliseconds, cancellationToken);
        }

        throw new Exception("The admitted battle did not reach Running.");
    }

    private async Task VerifyAcceptedAsync(Pair pair, BattlePhase phase, CancellationToken cancellationToken)
    {
        for (int i = 0; i < MaximumPolls; i++)
        {
            var stored = await _results.Get(pair.Grant.MatchId, cancellationToken);
            if (stored != null)
            {
                var terminal = TerminalOutbox.ValidatePayload(stored.Snapshot, pair.Grant.MatchId, stored.Digest);
                Require(terminal.Phase == phase && terminal.ManifestHash == pair.Grant.ManifestHash,
                    "Accepted terminal differs from this admitted match.");
                if (await _queue.Existing(pair.Grant.PlayerId, cancellationToken) == null &&
                    await _queue.Existing(pair.PeerPlayerId, cancellationToken) == null)
                {
                    return;
                }
            }

            await Task.Delay(PollDelayMilliseconds, cancellationToken);
        }

        throw new Exception("Terminal acceptance did not release both admitted participants.");
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
        internal Pair(SelfHostedMatchmakingAttempt owner, MatchConnectionGrant first, MatchConnectionGrant second)
        {
            Owner = owner;
            Grant = first;
            PeerPlayerId = second.PlayerId;
            First = new MatchConnection(first);
            Second = new MatchConnection(second);
        }

        internal SelfHostedMatchmakingAttempt Owner { get; }
        internal MatchConnectionGrant Grant { get; }
        internal string PeerPlayerId { get; }
        internal MatchConnection First { get; }
        internal MatchConnection Second { get; }

        /// <summary>Releases only the HTTP attempt and UDP peers owned by this fixture.</summary>
        public void Dispose()
        {
            First.Dispose();
            Second.Dispose();
            Owner.Dispose();
        }
    }
}
