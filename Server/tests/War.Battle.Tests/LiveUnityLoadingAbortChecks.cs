using System.Diagnostics;
using War.Client;
using War.Persistence;
using War.Protocol;

/// <summary>Combines an engine-dispatched Unity loading fault with real authenticated HTTP, UDP and MongoDB.</summary>
internal static class LiveUnityLoadingAbortChecks
{
    private const int SearchTimeoutSeconds = 120;
    private const string SuccessMarker = "UNITY_LIVE_LOADING_ABORT_PASSED";

    internal static async Task RunAsync(Settings settings, Stores stores, CancellationToken cancellationToken)
    {
        using var peer = new SelfHostedMatchmakingAttempt(
            new BackendClient(settings.BackendEndpoint, true), settings.AccessTokens[1]);
        Task<MatchConnectionGrant> search = peer.FindAsync(SearchTimeoutSeconds);
        string logPath = Path.Combine(settings.RunDirectory, "UnityLoadingAbort.log");
        using Process editor = StartEditor(settings, logPath);
        try
        {
            MatchConnectionGrant grant = await search.WaitAsync(cancellationToken);
            using var connection = new MatchConnection(grant);
            var admission = await connection.ConnectAsync(cancellationToken);
            Require(admission.Code == "admitted", "The real SDK peer could not enter the Unity match.");
            await editor.WaitForExitAsync(cancellationToken);
            Require(editor.ExitCode == 0 && File.ReadAllText(logPath).Contains(SuccessMarker, StringComparison.Ordinal),
                "Real Unity loading abort failed; inspect " + logPath);
            var terminal = await connection.PollAsync(cancellationToken);
            Require(terminal.Snapshot.Phase == BattlePhase.Aborted &&
                terminal.Snapshot.TerminalReason == "cancelled-before-start" && !terminal.Snapshot.RewardEligible,
                "The still-open SDK peer did not receive the actual unscored Unity cancellation.");
            await VerifyStoredAsync(grant, stores, cancellationToken);
            await peer.CompleteAsync();
            Console.WriteLine("PASS: actual Unity iterator failure, scoped Backend cancellation, Worker abort, " +
                "controller recovery entry and Mongo pair release; " + logPath);
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

    private static Process StartEditor(Settings settings, string logPath)
    {
        var start = new ProcessStartInfo(settings.UnityExecutable)
        {
            UseShellExecute = false, CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden
        };
        foreach (string argument in new[] { "-batchmode", "-nographics", "-noUpm", "-projectPath",
            settings.ProjectPath, "-executeMethod", "UnityAbortRecoveryRoutingAudit.RunAsync", "-logFile", logPath })
        {
            start.ArgumentList.Add(argument);
        }
        start.Environment["WAR_LOADING_BACKEND_ENDPOINT"] = settings.BackendEndpoint.AbsoluteUri;
        start.Environment["WAR_LOADING_BACKEND_TOKEN"] = settings.AccessTokens[0];
        return Process.Start(start) ?? throw new Exception("The owned Unity process did not start.");
    }

    private static async Task VerifyStoredAsync(
        MatchConnectionGrant grant, Stores stores, CancellationToken cancellationToken)
    {
        var stored = await stores.Results.Get(grant.MatchId, cancellationToken);
        Require(stored != null, "Unity cancellation was not accepted into MongoDB.");
        var terminal = War.BattleServer.TerminalOutbox.ValidatePayload(stored!.Snapshot, grant.MatchId, stored.Digest);
        Require(terminal.Phase == BattlePhase.Aborted && terminal.ManifestHash == grant.ManifestHash &&
            terminal.WinnerPlayerId.Length == 0 && !terminal.RewardEligible,
            "Accepted Unity cancellation differs from the admitted manifest or invents an outcome.");
        foreach (string playerId in grant.PlayerViews.Select(view => view.PlayerId))
        {
            Require(await stores.Queue.Existing(playerId, cancellationToken) == null,
                "Accepted Unity cancellation did not release both participants.");
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
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
