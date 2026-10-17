using System.Diagnostics;

using War.BattleServer;
using War.Client;
using War.Persistence;
using War.Protocol;

/// <summary>Pairs an actual Mono adapter with an SDK peer across a source-bound rematch handoff.</summary>
internal static class LiveUnitySameOpponentRematchChecks
{
    private const int SearchTimeoutSeconds = 120;
    private const int PollDelayMilliseconds = 100;
    private const string SuccessMarker = "UNITY_SAME_OPPONENT_REMATCH_PASSED";

    internal static async Task RunAsync(Settings settings, Stores stores, CancellationToken cancellationToken)
    {
        string released = Path.Combine(settings.RunDirectory, "UnitySameOpponentReleased.txt");
        string logPath = Path.Combine(settings.RunDirectory, "UnitySameOpponentRematch.log");
        using Process editor = StartEditor(settings, logPath, released);
        try
        {
            MatchConnectionGrant source = await PlaySourcePeerAsync(settings, cancellationToken);
            var proof = new LiveUnityRandomRematchChecks.Stores(stores.Queue, stores.Results);
            string digest = await LiveUnityRandomRematchChecks.WaitForAcceptedAsync(source, proof, cancellationToken);
            var accepted = await stores.Results.Get(source.MatchId, cancellationToken)
                ?? throw new InvalidDataException("The original accepted Unity result is missing.");
            MatchSnapshot snapshot = TerminalOutbox.ValidatePayload(
                accepted.Snapshot,
                accepted.MatchId,
                accepted.Digest);
            await File.WriteAllTextAsync(released, source.MatchId, cancellationToken);
            using var rematch = new SelfHostedRematchAttempt(new BackendClient(settings.BackendEndpoint, true),
                settings.AccessTokens[1], snapshot, source.PlayerId);
            MatchConnectionGrant next = await rematch.FindAsync(cancellationToken);
            await PlayAdmittedPeerAsync(next, cancellationToken);
            await LiveUnityRandomRematchChecks.WaitForAcceptedAsync(next, proof, cancellationToken);
            Require(next.MatchId != source.MatchId && next.SessionId != source.SessionId &&
                (await stores.Results.Get(source.MatchId, cancellationToken))?.Digest == digest,
                "Unity handoff reused its original identity or changed the accepted source result.");
            await editor.WaitForExitAsync(cancellationToken);
            Require(editor.ExitCode == 0 && File.ReadAllText(logPath).Contains(SuccessMarker, StringComparison.Ordinal),
                "Actual Mono rematch handoff failed; inspect " + logPath);
            Console.WriteLine(
                "PASS: actual Mono rematch handoff, failed-close retry, canonical owner and real UDP; " + logPath);
        }
        finally
        {
            if (!editor.HasExited)
            {
                editor.Kill(true);
                await editor.WaitForExitAsync(CancellationToken.None);
            }
        }
    }

    private static async Task<MatchConnectionGrant> PlaySourcePeerAsync(
        Settings settings, CancellationToken cancellationToken)
    {
        using var search = new SelfHostedMatchmakingAttempt(
            new BackendClient(settings.BackendEndpoint, true), settings.AccessTokens[1]);
        var grant = await search.FindAsync(SearchTimeoutSeconds).WaitAsync(cancellationToken);
        await PlayAdmittedPeerAsync(grant, cancellationToken);
        await search.CompleteAsync();
        return grant;
    }

    private static async Task PlayAdmittedPeerAsync(MatchConnectionGrant grant, CancellationToken cancellationToken)
    {
        using var peer = new MatchConnection(grant);
        Require((await peer.ConnectAsync(cancellationToken)).Code == "admitted", "SDK peer admission failed.");
        await peer.ReadyAsync(cancellationToken);
        MatchReply reply;
        do
        {
            await Task.Delay(PollDelayMilliseconds, cancellationToken);
            reply = await peer.PollAsync(cancellationToken);
        } while (reply.Snapshot.Phase != BattlePhase.Ended);
        Require(reply.Snapshot.WinnerPlayerId == grant.PlayerId && !reply.Snapshot.RewardEligible,
            "Mono rematch did not confirm the expected unscored terminal result.");
    }

    private static Process StartEditor(Settings settings, string logPath, string released)
    {
        var start = new ProcessStartInfo(settings.UnityExecutable)
        {
            UseShellExecute = false, CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden,
        };
        foreach (string argument in new[] { "-batchmode", "-nographics", "-noUpm", "-projectPath", settings.ProjectPath,
            "-executeMethod", "UnitySameOpponentRematchAudit.Run", "-logFile", logPath })
        {
            start.ArgumentList.Add(argument);
        }
        start.Environment["WAR_REMATCH_BACKEND_ENDPOINT"] = settings.BackendEndpoint.AbsoluteUri;
        start.Environment["WAR_REMATCH_BACKEND_TOKEN"] = settings.AccessTokens[0];
        start.Environment["WAR_REMATCH_RELEASED_FILE"] = released;
        return Process.Start(start) ?? throw new InvalidDataException("The owned Mono handoff Editor did not start.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }

    internal sealed class Settings
    {
        internal required Uri BackendEndpoint { get; init; }
        internal required string[] AccessTokens { get; init; }
        internal required string UnityExecutable { get; init; }
        internal required string ProjectPath { get; init; }
        internal required string RunDirectory { get; init; }
    }

    internal sealed record Stores(BattleMatchQueueStore Queue, BattleResultStore Results);
}
