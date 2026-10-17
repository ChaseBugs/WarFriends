using System.Diagnostics;
using War.BattleServer;
using War.Client;
using War.Persistence;
using War.Protocol;

/// <summary>Checks two fresh Unity queue allocations against real HTTP, UDP and MongoDB authority.</summary>
internal static class LiveUnityRandomRematchChecks
{
    private const int SearchTimeoutSeconds = 120;
    private const int MaximumPolls = 300;
    private const int PollDelayMilliseconds = 100;
    private const string SuccessMarker = "UNITY_RANDOM_REMATCH_PASSED";

    internal static async Task RunAsync(Settings settings, Stores stores, CancellationToken cancellationToken)
    {
        string released = Path.Combine(settings.RunDirectory, "UnityRematchReleased.txt");
        string logPath = Path.Combine(settings.RunDirectory, "UnityRandomRematch.log");
        using Process editor = StartEditor(settings, logPath, released);
        try
        {
            MatchConnectionGrant first = await PlayPeerRoundAsync(settings, cancellationToken);
            string originalDigest = await WaitForAcceptedAsync(first, stores, cancellationToken);
            await File.WriteAllTextAsync(released, first.MatchId, cancellationToken);
            MatchConnectionGrant second = await PlayPeerRoundAsync(settings, cancellationToken);
            Require(first.MatchId != second.MatchId && first.SessionId != second.SessionId &&
                first.Ticket != second.Ticket && !first.SessionKey.Equals(second.SessionKey),
                "The second allocation did not issue a distinct match and capability.");
            await WaitForAcceptedAsync(second, stores, cancellationToken);
            Require((await stores.Results.Get(first.MatchId, cancellationToken))?.Digest == originalDigest,
                "The second allocation rewrote the original accepted result.");
            await editor.WaitForExitAsync(cancellationToken);
            Require(editor.ExitCode == 0 && File.ReadAllText(logPath).Contains(SuccessMarker, StringComparison.Ordinal),
                "Actual Unity random rematch failed; inspect " + logPath);
            Console.WriteLine("PASS: same Unity adapter, two authenticated queue grants, Worker terminal results " +
                "and Mongo pair release without terminal rewrite; " + logPath);
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

    private static async Task<MatchConnectionGrant> PlayPeerRoundAsync(Settings settings,
        CancellationToken cancellationToken)
    {
        using var attempt = new SelfHostedMatchmakingAttempt(
            new BackendClient(settings.BackendEndpoint, true), settings.AccessTokens[1]);
        MatchConnectionGrant grant = await attempt.FindAsync(SearchTimeoutSeconds).WaitAsync(cancellationToken);
        using var peer = new MatchConnection(grant);
        Require((await peer.ConnectAsync(cancellationToken)).Code == "admitted", "SDK peer admission failed.");
        await peer.ReadyAsync(cancellationToken);
        MatchReply state;
        do
        {
            await Task.Delay(PollDelayMilliseconds, cancellationToken);
            state = await peer.PollAsync(cancellationToken);
        } while (state.Snapshot.Phase != BattlePhase.Ended);
        Require(state.Snapshot.WinnerPlayerId == grant.PlayerId && !state.Snapshot.RewardEligible,
            "Unity forfeit did not produce the expected unscored peer outcome.");
        await attempt.CompleteAsync();
        return grant;
    }

    internal static async Task<string> WaitForAcceptedAsync(MatchConnectionGrant grant, Stores stores,
        CancellationToken cancellationToken)
    {
        for (int poll = 0; poll < MaximumPolls; poll++)
        {
            var stored = await stores.Results.Get(grant.MatchId, cancellationToken);
            if (stored != null)
            {
                MatchSnapshot terminal = TerminalOutbox.ValidatePayload(stored.Snapshot, grant.MatchId, stored.Digest);
                Require(terminal.Phase == BattlePhase.Ended && terminal.ManifestHash == grant.ManifestHash &&
                    terminal.WinnerPlayerId == grant.PlayerId && !terminal.RewardEligible,
                    "Accepted rematch result differs from its admitted authority.");
                bool isReleased = true;
                foreach (BattlePlayerView player in grant.PlayerViews)
                {
                    isReleased &= await stores.Queue.Existing(player.PlayerId, cancellationToken) == null;
                }
                if (isReleased)
                {
                    return stored.Digest;
                }
            }
            await Task.Delay(PollDelayMilliseconds, cancellationToken);
        }
        throw new InvalidDataException("Accepted rematch result did not release its durable player pair.");
    }

    private static Process StartEditor(Settings settings, string logPath, string released)
    {
        var start = new ProcessStartInfo(settings.UnityExecutable)
        {
            UseShellExecute = false, CreateNoWindow = true, WindowStyle = ProcessWindowStyle.Hidden
        };
        foreach (string argument in new[] { "-batchmode", "-nographics", "-noUpm", "-projectPath",
            settings.ProjectPath, "-executeMethod", "UnityRandomRematchAudit.Run", "-logFile", logPath })
        {
            start.ArgumentList.Add(argument);
        }
        start.Environment["WAR_REMATCH_BACKEND_ENDPOINT"] = settings.BackendEndpoint.AbsoluteUri;
        start.Environment["WAR_REMATCH_BACKEND_TOKEN"] = settings.AccessTokens[0];
        start.Environment["WAR_REMATCH_RELEASED_FILE"] = released;
        return Process.Start(start) ?? throw new InvalidDataException("The owned rematch Editor did not start.");
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
