using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading.Tasks;
using Google.Protobuf;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using War.Client;
using War.Protocol;

/// <summary>Checks repeated terminal delivery through the actual Unity adapter and installed SDK.</summary>
public static class UnityTerminalRoomReplayAudit
{
    private const string MatchId = "terminal-room-audit";
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const int SessionKeyBytes = 32;
    private const int TicketLifetimeSeconds = 60;

    /// <summary>Uses controlled snapshots and a pending socket; this is not admitted gameplay.</summary>
    public static async void RunAsync()
    {
        try
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            await VerifyPhaseAsync(BattlePhase.Ended);
            await VerifyPhaseAsync(BattlePhase.Aborted);
            Debug.Log("PASS: terminal snapshot replay reaches Unity callbacks after a callback failure; " +
                "both terminal phases, one Closed transition each; controlled component audit only.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
    }

    private static async Task VerifyPhaseAsync(BattlePhase phase)
    {
        var owner = new GameObject("TerminalRoomReplayAudit");
        var client = owner.AddComponent<SelfHostedBattleClient>();
        using (var receiver = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0)))
        {
            Task pending = client.Connect(CreateGrant(receiver));
            try
            {
                int states = 0;
                int closures = 0;
                client.RoomPhaseChanged += roomPhase =>
                {
                    if (roomPhase == SelfHostedRoomPhase.Closed)
                    {
                        closures++;
                    }
                };
                client.StateReceived += state =>
                {
                    states++;
                    if (states == 1)
                    {
                        throw new InvalidOperationException("Expected presentation callback failure.");
                    }

                    state.TerminalReason = "mutated-callback-copy";
                };
                var snapshot = new MatchSnapshot
                {
                    MatchId = MatchId, ManifestHash = new string('a', 64), Phase = phase, StateRevision = 1,
                };
                ExpectCallbackFailure(client, snapshot);
                Apply(client, snapshot);
                Apply(client, snapshot);
                if (states != 3 || closures != 1 || client.State.TerminalReason.Length != 0)
                {
                    throw new InvalidOperationException(
                        "Terminal delivery lost retry or retained a mutated callback copy.");
                }
            }
            finally
            {
                client.LeaveMatch();
                await ExpectCancelledAsync(pending);
                UnityEngine.Object.DestroyImmediate(owner);
            }
        }
    }

    private static MatchConnectionGrant CreateGrant(UdpClient receiver)
    {
        return new MatchConnectionGrant
        {
            Host = "127.0.0.1", Port = (uint)((IPEndPoint)receiver.Client.LocalEndPoint).Port,
            MatchId = MatchId, ManifestHash = new string('a', 64), PlayerId = PlayerId, SessionId = 1,
            SessionKey = ByteString.CopyFrom(new byte[SessionKeyBytes]), Ticket = "pending-terminal-fixture",
            ExpiresUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + TicketLifetimeSeconds,
        };
    }

    private static void Apply(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        var reply = new MatchReply
        {
            Code = "state", Snapshot = snapshot,
            ObservedPoseCatalogRevision = ObservedInfantryPoseCatalogData.BuiltIn.Revision,
        };
        typeof(SelfHostedBattleClient).GetMethod("Apply", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(client, new object[] { reply });
    }

    private static void ExpectCallbackFailure(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        try
        {
            Apply(client, snapshot);
        }
        catch (TargetInvocationException failure) when (failure.InnerException is InvalidOperationException &&
            failure.InnerException.Message == "Expected presentation callback failure.")
        {
            return;
        }

        throw new InvalidOperationException("The injected first presentation failure was not reached.");
    }

    private static async Task ExpectCancelledAsync(Task pending)
    {
        try
        {
            await pending;
        }
        catch (OperationCanceledException)
        {
            return;
        }
        catch (ObjectDisposedException)
        {
            return;
        }

        throw new InvalidOperationException("The controlled pending admission unexpectedly completed.");
    }
}
