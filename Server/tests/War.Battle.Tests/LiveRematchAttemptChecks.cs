using Google.Protobuf;
using War.BattleServer;
using War.Client;
using War.Protocol;

/// <summary>Runs the actual linked Unity rematch owner against native Backend, Worker and MongoDB authority.</summary>
internal static class LiveRematchAttemptChecks
{
    private const int SearchTimeoutSeconds = 25;
    private const int ConsentPollMilliseconds = 100;

    internal static async Task RunAsync(LiveSameOpponentRematchChecks.Settings settings,
        LiveSameOpponentRematchChecks.Stores stores, CancellationToken cancellationToken)
    {
        var scenario = new Scenario(settings, stores);
        await VerifyWaitingCancellationAsync(scenario, cancellationToken);
        await VerifyAllocatedCancellationAsync(scenario, cancellationToken);
        await VerifyAdmissionAsync(scenario, cancellationToken);
        Console.WriteLine("PASS: actual Unity source rematch owner waits, " +
            "cancels consent/allocation and delivers playable grants");
    }

    private static async Task<Source> OpenCompletedSourceAsync(Scenario scenario, CancellationToken cancellationToken)
    {
        using var backend = new BackendClient(scenario.Settings.Endpoint, true);
        var grants = await Task.WhenAll(scenario.Settings.Tokens.Select(token =>
            backend.FindMatchAsync(token, TimeSpan.FromSeconds(SearchTimeoutSeconds), cancellationToken)));
        await LiveSameOpponentRematchChecks.FinishRoundAsync(grants, cancellationToken);
        string digest = await LiveSameOpponentRematchChecks.WaitForAcceptedAsync(
            scenario.Stores, grants[0], cancellationToken);
        var result = await scenario.Stores.Results.Get(grants[0].MatchId, cancellationToken)
            ?? throw new InvalidDataException("The completed source result is missing.");
        return new Source(grants,
            TerminalOutbox.ValidatePayload(result.Snapshot, result.MatchId, result.Digest), digest);
    }

    private static async Task VerifyWaitingCancellationAsync(Scenario scenario, CancellationToken cancellationToken)
    {
        Source source = await OpenCompletedSourceAsync(scenario, cancellationToken);
        using var owner = CreateOwner(scenario, source, 0);
        using var observer = new BackendClient(scenario.Settings.Endpoint, true);
        Task<MatchConnectionGrant> finding = owner.FindAsync(cancellationToken);
        while (true)
        {
            if (finding.IsFaulted)
            {
                await finding;
            }
            var consent = await observer.ReadRematchConsentAsync(
                source.Snapshot.MatchId, scenario.Settings.Tokens[0], cancellationToken);
            if (consent.Status == "waiting")
            {
                break;
            }
            await Task.Delay(ConsentPollMilliseconds, cancellationToken);
        }
        Require(!finding.IsCompleted, "One participant must not receive a fresh grant before peer consent.");
        await owner.CancelAsync();
        try
        {
            await finding;
            throw new InvalidDataException("Cancelled rematch discovery delivered a grant.");
        }
        catch (OperationCanceledException)
        {
            // Local discovery cancellation is expected only alongside the separate remote receipt below.
        }
        Require(owner.IsCancellationRequested && owner.IsCancellationConfirmed &&
            await scenario.Stores.Queue.Existing(source.Grants[0].PlayerId, cancellationToken) == null,
            "Consent cancellation must confirm remote cleanup without creating a queue entry.");
    }

    private static async Task VerifyAllocatedCancellationAsync(Scenario scenario, CancellationToken cancellationToken)
    {
        Source source = await OpenCompletedSourceAsync(scenario, cancellationToken);
        ByteString original = source.Snapshot.ToByteString();
        using var first = CreateOwner(scenario, source, 0);
        using var second = CreateOwner(scenario, source, 1);
        var grants = await Task.WhenAll(first.FindAsync(cancellationToken), second.FindAsync(cancellationToken));
        await first.CancelAsync();
        await second.CancelAsync();
        await LiveSameOpponentRematchChecks.WaitForAcceptedAsync(scenario.Stores, grants[0], cancellationToken);
        var result = await scenario.Stores.Results.Get(grants[0].MatchId, cancellationToken)
            ?? throw new InvalidDataException("Allocated cancellation lost its terminal result.");
        Require(first.IsCancellationConfirmed && second.IsCancellationConfirmed &&
            TerminalOutbox.ValidatePayload(
                result.Snapshot, result.MatchId, result.Digest).Phase == BattlePhase.Aborted &&
            source.Snapshot.ToByteString().Equals(original),
            "Rematch cancellation changed its source or lacked proof.");
    }

    private static async Task VerifyAdmissionAsync(Scenario scenario, CancellationToken cancellationToken)
    {
        Source source = await OpenCompletedSourceAsync(scenario, cancellationToken);
        using var first = CreateOwner(scenario, source, 0);
        using var second = CreateOwner(scenario, source, 1);
        var grants = await Task.WhenAll(first.FindAsync(cancellationToken), second.FindAsync(cancellationToken));
        Require(grants[0].MatchId == grants[1].MatchId && grants[0].MatchId != source.Snapshot.MatchId &&
            grants[0].PlayerId == source.Grants[0].PlayerId && grants[1].PlayerId == source.Grants[1].PlayerId,
            "Source rematch owner delivered an unrelated grant.");
        var copy = await first.FindAsync(cancellationToken);
        Require(copy.Equals(grants[0]) && !ReferenceEquals(copy, grants[0]),
            "Repeated reads must return isolated grants.");
        copy.PlayerViews[0].DisplayName = "LocalCopyOnly";
        Require((await first.FindAsync(cancellationToken)).Equals(grants[0]),
            "A caller mutated the retained admission capability through a shared DTO.");
        await LiveSameOpponentRematchChecks.FinishRoundAsync(grants, cancellationToken);
        await LiveSameOpponentRematchChecks.WaitForAcceptedAsync(scenario.Stores, grants[0], cancellationToken);
        var retained = await scenario.Stores.Results.Get(source.Snapshot.MatchId, cancellationToken);
        Require(retained?.Digest == source.Digest,
            "New rematch play changed the original accepted result.");
    }

    private static SelfHostedRematchAttempt CreateOwner(Scenario scenario, Source source, int participant)
    {
        return new SelfHostedRematchAttempt(new BackendClient(scenario.Settings.Endpoint, true),
            scenario.Settings.Tokens[participant], source.Snapshot, source.Grants[participant].PlayerId);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }

    private sealed record Scenario(LiveSameOpponentRematchChecks.Settings Settings,
        LiveSameOpponentRematchChecks.Stores Stores);

    private sealed record Source(MatchConnectionGrant[] Grants, MatchSnapshot Snapshot, string Digest);
}
