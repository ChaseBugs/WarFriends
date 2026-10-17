using System;
using System.Reflection;
using Google.Protobuf;
using UnityEditor;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks the installed SDK and Unity rematch owner without network or scene fixture substitutions.</summary>
public static class UnityRematchOwnershipAudit
{
    /// <summary>Checks runtime resolution, source rejection and disposal without remote confirmation.</summary>
    public static void Run()
    {
        try
        {
            Verify();
            Debug.Log("UNITY_REMATCH_OWNERSHIP_PASSED construction=True terminalPreserved=True");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogError(failure);
            EditorApplication.Exit(1);
        }
    }

    private static void Verify()
    {
        const BindingFlags Internal = BindingFlags.Instance | BindingFlags.NonPublic;
        string playerId = new string('a', 32);
        var source = new MatchSnapshot { MatchId = "m" + new string('a', 32), Phase = BattlePhase.Ended };
        source.Players.Add(new BattlePlayerState { PlayerId = playerId });
        source.Players.Add(new BattlePlayerState { PlayerId = new string('b', 32) });
        ByteString original = source.ToByteString();
        Type ownerType = typeof(SelfHostedBattleClient).Assembly.GetType("SelfHostedRematchAttempt", true);
        using (var backend = new BackendClient(new Uri("http://127.0.0.1:8080/"), true))
        {
            var owner = (IDisposable)Activator.CreateInstance(ownerType, Internal, null,
                new object[] { backend, "construction-fixture", source, playerId }, null);
            owner.Dispose();
            bool confirmed = (bool)ownerType.GetProperty("IsCancellationConfirmed", Internal).GetValue(owner, null);
            Require(!confirmed && source.ToByteString().Equals(original),
                "Local disposal must preserve terminal bytes and cannot confirm remote cancellation.");
        }
        source.Phase = BattlePhase.Running;
        using (var backend = new BackendClient(new Uri("http://127.0.0.1:8080/"), true))
        {
            try
            {
                Activator.CreateInstance(ownerType, Internal, null,
                    new object[] { backend, "construction-fixture", source, playerId }, null);
                throw new InvalidOperationException("Running match was accepted as a rematch source.");
            }
            catch (TargetInvocationException failure)
            {
                Require(failure.InnerException is InvalidOperationException, "Unexpected source construction failure.");
            }
        }
        try
        {
            MatchConnection.ValidateGrantEnvelope(new MatchConnectionGrant());
            throw new InvalidOperationException("Invalid installed SDK grant envelope was accepted.");
        }
        catch (ArgumentException)
        {
            // The socket-free shared validator must reject before any transport construction.
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
