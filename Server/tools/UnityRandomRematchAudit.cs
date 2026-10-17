using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Reuses the actual Unity SDK through two real Backend allocations without profile/menu stubs.</summary>
public static class UnityRandomRematchAudit
{
    private const int SearchTimeoutSeconds = 90;
    private const int PollDelayMilliseconds = 100;
    private const int AuditTimeoutSeconds = 150;
    private static Task _audit;
    private static double _deadline;

    /// <summary>Credentials arrive only through the owned process environment.</summary>
    public static void Run()
    {
        string endpoint = Environment.GetEnvironmentVariable("WAR_REMATCH_BACKEND_ENDPOINT");
        string token = Environment.GetEnvironmentVariable("WAR_REMATCH_BACKEND_TOKEN");
        string released = Environment.GetEnvironmentVariable("WAR_REMATCH_RELEASED_FILE");
        if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(token) || string.IsNullOrEmpty(released))
        {
            throw new InvalidOperationException("The owned rematch fixture environment is incomplete.");
        }

        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        _deadline = EditorApplication.timeSinceStartup + AuditTimeoutSeconds;
        _audit = VerifyAsync(endpoint, token, released);
        EditorApplication.update += ObserveCompletion;
    }

    private static async Task VerifyAsync(string endpoint, string token, string released)
    {
        var owner = new GameObject("RealQueueRematchAdapter");
        var client = owner.AddComponent<SelfHostedBattleClient>();
        using (var lifetime = new CancellationTokenSource(TimeSpan.FromSeconds(AuditTimeoutSeconds)))
        {
            try
            {
                string firstMatch = await PlayRoundAsync(client, endpoint, token, lifetime.Token);
                while (!File.Exists(released))
                {
                    await Task.Delay(PollDelayMilliseconds, lifetime.Token);
                }
                Require(File.ReadAllText(released) == firstMatch,
                    "Pair release acknowledgement does not belong to the completed match.");
                string secondMatch = await PlayRoundAsync(client, endpoint, token, lifetime.Token);
                Require(secondMatch != firstMatch, "Random rematch reused its terminal match identity.");
                Debug.Log("UNITY_RANDOM_REMATCH_PASSED freshMatch=True terminalPreserved=True");
            }
            finally
            {
                client.LeaveMatch();
                UnityEngine.Object.DestroyImmediate(owner);
            }
        }
    }

    private static async Task<string> PlayRoundAsync(SelfHostedBattleClient client, string endpoint,
        string token, CancellationToken cancellationToken)
    {
        await client.MatchmakeAndConnect(endpoint, token, SearchTimeoutSeconds, true);
        string matchId = client.State.MatchId;
        await client.Ready();
        while (client.State.Phase != BattlePhase.Running)
        {
            await Task.Delay(PollDelayMilliseconds, cancellationToken);
            await client.Refresh();
        }

        await client.Forfeit();
        Require(client.State.Phase == BattlePhase.Ended, "The Worker did not confirm a terminal result.");
        ByteString frozen = client.State.ToByteString();
        client.ReleaseEndedMatchForNewSearch();
        Require(!client.OwnsMatch && SelfHostedBattleClient.Active == null &&
            client.State.ToByteString().Equals(frozen),
            "Releasing the ended transport changed its result or retained active ownership.");
        return matchId;
    }

    private static void ObserveCompletion()
    {
        if (!_audit.IsCompleted && EditorApplication.timeSinceStartup <= _deadline)
        {
            return;
        }

        EditorApplication.update -= ObserveCompletion;
        if (_audit.IsFaulted || _audit.IsCanceled || !_audit.IsCompleted)
        {
            Debug.LogError(_audit.IsFaulted ? _audit.Exception.ToString() : "Random rematch audit timed out.");
            EditorApplication.Exit(1);
            return;
        }
        EditorApplication.Exit(0);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
