using System.Text;

using War.Client;

/// <summary>Checks a real registered Worker identity survives a lost registration acknowledgement.</summary>
internal static class LiveRematchRegistrationLossChecks
{
    internal static async Task RunAsync(Scenario scenario, CancellationToken cancellationToken)
    {
        var proxy = scenario.Settings.RegistrationReplyLoss
            ?? throw new InvalidDataException("Registration reply-loss fixture is missing.");
        proxy.Arm();
        await RequireDeferredAsync(scenario, cancellationToken);
        var dropped = proxy.Dropped;
        Require(dropped.Code == "registered", "The dropped reply must be the first real Worker registration.");
        var consent = await scenario.Backend.ReadRematchConsentAsync(
            scenario.SourceMatchId, scenario.Settings.Tokens[0], cancellationToken);
        Require(consent.Status == "allocated" && consent.NextMatchId == dropped.MatchId,
            "Lost registration reply must retain the original reserved identity.");
        byte[] frozen = await scenario.Stores.Snapshots.GetForParticipantsAsync(
            consent.NextMatchId, consent.AcceptedPlayerIds.ToArray(), cancellationToken)
            ?? throw new InvalidDataException("Lost acknowledgement removed the committed admission payload.");
        Require(RegistrationReplyLossProxy.Hash(frozen) == dropped.RequestHash,
            "The Worker did not register the exact frozen admission bytes.");
        await RequireNoGrantAsync(scenario, dropped.MatchId, cancellationToken);
        var retry = await scenario.Backend.AllocateRematchAsync(
            scenario.SourceMatchId, scenario.Settings.Tokens[0], cancellationToken);
        Require(retry.Code == "paired" && retry.MatchId == dropped.MatchId,
            "Lost-response retry allocated another match.");
        var replays = proxy.Replays;
        Require(replays.Length > 0 && replays.All(replay => replay.Code == "existing-match" &&
            replay.RequestHash == dropped.RequestHash && replay.GrantsHash == dropped.GrantsHash),
            "Worker replay changed its admission payload or issued new capabilities.");
        await VerifyPublishedCapabilitiesAsync(scenario, dropped, cancellationToken);
        Console.WriteLine("PASS: dropped real Worker registration reply, " +
            "same frozen request and exact recovered capabilities");
    }

    private static async Task RequireDeferredAsync(Scenario scenario, CancellationToken cancellationToken)
    {
        try
        {
            await scenario.Backend.AllocateRematchAsync(
                scenario.SourceMatchId, scenario.Settings.Tokens[0], cancellationToken);
        }
        catch (HttpRequestException exception) when (
            exception.Message.Contains("Backend status 503", StringComparison.Ordinal) &&
            exception.Message.Contains("rematch_provision_deferred", StringComparison.Ordinal))
        {
            return;
        }
        throw new InvalidDataException("The Backend must observe the intentionally missing registration response.");
    }

    private static async Task RequireNoGrantAsync(
        Scenario scenario, string matchId, CancellationToken cancellationToken)
    {
        try
        {
            await scenario.Backend.MatchGrantAsync(matchId, scenario.Settings.Tokens[0], cancellationToken);
        }
        catch (HttpRequestException exception) when (
            exception.Message.Contains("Backend status 404", StringComparison.Ordinal))
        {
            return;
        }
        throw new InvalidDataException("A lost registration acknowledgement prematurely published a capability.");
    }

    private static async Task VerifyPublishedCapabilitiesAsync(Scenario scenario,
        RegistrationReplyLossProxy.Evidence registered, CancellationToken cancellationToken)
    {
        foreach (string token in scenario.Settings.Tokens)
        {
            var grant = await scenario.Backend.MatchGrantAsync(registered.MatchId, token, cancellationToken);
            var expected = registered.Capabilities.Single(capability => capability.PlayerId == grant.PlayerId);
            Require(grant.ManifestHash == registered.ManifestHash && grant.SessionId == expected.SessionId &&
                RegistrationReplyLossProxy.Hash(Encoding.UTF8.GetBytes(grant.Ticket)) == expected.TicketHash &&
                RegistrationReplyLossProxy.Hash(grant.SessionKey.ToByteArray()) == expected.KeyHash,
                "Backend recovery must publish exactly the original Worker's player capability.");
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }

    internal sealed record Scenario(BackendClient Backend, LiveSameOpponentRematchChecks.Settings Settings,
        LiveSameOpponentRematchChecks.Stores Stores, string SourceMatchId);
}
