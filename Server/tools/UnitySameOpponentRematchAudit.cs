using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Protocol;

/// <summary>Exercises real Mono rematch handoff, including a failed original close callback.</summary>
public static class UnitySameOpponentRematchAudit
{
    private const int SearchTimeoutSeconds = 90;
    private const int PollDelayMilliseconds = 100;
    private const int AuditTimeoutSeconds = 150;
    private static Task _audit;
    private static double _deadline;

    /// <summary>Uses credentials supplied only to the owned Editor process.</summary>
    public static void Run()
    {
        EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
        string endpoint = Environment.GetEnvironmentVariable("WAR_REMATCH_BACKEND_ENDPOINT");
        string token = Environment.GetEnvironmentVariable("WAR_REMATCH_BACKEND_TOKEN");
        string released = Environment.GetEnvironmentVariable("WAR_REMATCH_RELEASED_FILE");
        if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(token) || string.IsNullOrEmpty(released))
        {
            throw new InvalidOperationException("The owned rematch fixture environment is incomplete.");
        }
        _deadline = EditorApplication.timeSinceStartup + AuditTimeoutSeconds;
        _audit = VerifyAsync(endpoint, token, released);
        EditorApplication.update += ObserveCompletion;
    }

    private static async Task VerifyAsync(string endpoint, string token, string released)
    {
        var root = new GameObject("RealSameOpponentRematchAdapter");
        var client = root.AddComponent<SelfHostedBattleClient>();
        using (var lifetime = new CancellationTokenSource(TimeSpan.FromSeconds(AuditTimeoutSeconds)))
        {
            try
            {
                await client.MatchmakeAndConnect(endpoint, token, SearchTimeoutSeconds, true);
                await PlayToTerminalAsync(client, lifetime.Token);
                MatchSnapshot source = client.State.Clone();
                while (!File.Exists(released))
                {
                    await Task.Delay(PollDelayMilliseconds, lifetime.Token);
                }
                Require(File.ReadAllText(released) == source.MatchId, "Source release acknowledgement differs.");
                await VerifyHandoffAsync(client, source, new ConnectionSettings(endpoint, token), lifetime.Token);
                await PlayToTerminalAsync(client, lifetime.Token);
                Require(client.State.MatchId != source.MatchId && source.Phase == BattlePhase.Ended,
                    "Rematch reopened its original terminal identity.");
                Debug.Log("UNITY_SAME_OPPONENT_REMATCH_PASSED " +
                    "callbackRecovery=True canonicalOwner=True freshMatch=True");
            }
            finally
            {
                client.LeaveMatch();
                UnityEngine.Object.DestroyImmediate(root);
            }
        }
    }

    private static async Task VerifyHandoffAsync(SelfHostedBattleClient client, MatchSnapshot source,
        ConnectionSettings settings, CancellationToken cancellationToken)
    {
        ByteString frozen = source.ToByteString();
        int closed = 0;
        Action failClose = () =>
        {
            closed++;
            throw new InvalidOperationException("Controlled rematch close failure.");
        };
        client.MatchClosed += failClose;
        try
        {
            try
            {
                await client.RematchAndConnectAsync(settings.Endpoint, settings.Token, true, cancellationToken);
                throw new Exception("The controlled close callback did not run.");
            }
            catch (InvalidOperationException failure)
            {
                Require(failure.Message == "Controlled rematch close failure.", "Unexpected handoff failure.");
            }
        }
        finally
        {
            client.MatchClosed -= failClose;
        }
        Require(closed == 1 && client.HasPendingRematch && !client.OwnsMatch && client.OwnsBattleOperation &&
            SelfHostedBattleClient.Active == client && PhotonConnectionManager.GetOwnedSelfHostedClient() == client &&
            SelfHostedBattleClient.GetOrCreate() == client && client.State.ToByteString().Equals(frozen),
            "A failed close callback lost canonical rematch ownership or changed the original result.");
        VerifyReplacementBlocked(client);
        await client.RetryRematchHandoffAsync(cancellationToken);
        Require(client.OwnsMatch && client.IsConnected && client.State.MatchId != source.MatchId &&
            client.HasPendingRematch && source.ToByteString().Equals(frozen),
            "Retained handoff failed to admit the original reserved rematch.");
    }

    private static void VerifyReplacementBlocked(SelfHostedBattleClient current)
    {
        var root = new GameObject("ForbiddenReplacementAdapter");
        var replacement = root.AddComponent<SelfHostedBattleClient>();
        try
        {
            try
            {
                replacement.Connect(new MatchConnectionGrant());
                throw new Exception("A foreign direct admission replaced pending rematch authority.");
            }
            catch (InvalidOperationException)
            {
                Require(SelfHostedBattleClient.Active == current, "Rejected admission changed canonical ownership.");
            }
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(root);
        }
    }

    private static async Task PlayToTerminalAsync(SelfHostedBattleClient client, CancellationToken cancellationToken)
    {
        await client.Ready();
        while (client.State.Phase != BattlePhase.Running)
        {
            await Task.Delay(PollDelayMilliseconds, cancellationToken);
            await client.Refresh();
        }
        Require(!client.HasPendingRematch, "Running transport did not release the completed rematch operation.");
        VerifyControllerRejectsRunningRematch(client);
        await client.Forfeit();
        Require(client.State.Phase == BattlePhase.Ended, "The Worker did not confirm a terminal result.");
    }

    private static void VerifyControllerRejectsRunningRematch(SelfHostedBattleClient client)
    {
        var root = new GameObject("ActualRematchControllerGuard");
        root.SetActive(false);
        GameControllerOnline[] controllers =
        {
            root.AddComponent<GameControllerDeathMatch>(),
            root.AddComponent<GameControllerCoop>()
        };
        ByteString before = client.State.ToByteString();
        try
        {
            foreach (GameControllerOnline controller in controllers)
            {
                try
                {
                    controller.Rematch();
                    throw new Exception("The controller accepted a Running match as a rematch source.");
                }
                catch (InvalidOperationException failure)
                {
                    Require(failure.Message ==
                        "Rematch requires an ended owner without another pending request.",
                        "The actual controller reached profile or scene dependencies before its source guard.");
                }
            }
            Require(SelfHostedBattleClient.Active == client && client.State.ToByteString().Equals(before),
                "Controller rejection changed the Running match owner or snapshot.");
        }
        finally
        {
            UnityEngine.Object.DestroyImmediate(root);
        }
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
            Debug.LogError(_audit.IsFaulted ? _audit.Exception.ToString() : "Same-opponent audit timed out.");
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

    private sealed class ConnectionSettings
    {
        internal string Endpoint { get; private set; }
        internal string Token { get; private set; }

        internal ConnectionSettings(string endpoint, string token)
        {
            Endpoint = endpoint;
            Token = token;
        }
    }
}
