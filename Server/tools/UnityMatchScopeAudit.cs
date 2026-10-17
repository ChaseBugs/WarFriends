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
using War.Protocol.Transport;

/// <summary>Checks component reuse and cancellation ownership across distinct match connections.</summary>
public static class UnityMatchScopeAudit
{
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string OldMatchId = "old-scope";
    private const string NewMatchId = "new-scope";
    private const string ReplacementMatchId = "replacement-scope";
    private const ulong OldTick = 120;

    /// <summary>Uses pending SDK sockets and controlled snapshots to isolate lifecycle ownership.</summary>
    public static async void RunAsync()
    {
        GameObject owner = null;
        try
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            owner = new GameObject("MatchScopeAudit");
            SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
            using (var receiver = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0)))
            {
                SetLocalPlayer(client);
                Apply(client, Snapshot(OldMatchId, OldTick), string.Empty);
                Task first = client.Connect(CreateGrant(receiver, NewMatchId));
                Require(client.State == null && client.CoopEnemies.Count == 0,
                    "A new grant must reset the previous match's snapshot and enemy projection.");
                client.LeaveMatch();
                Task replacement = client.Connect(CreateGrant(receiver, ReplacementMatchId));
                await ExpectCanceledAsync(first);
                Require(SelfHostedBattleClient.Active == client && client.LocalPlayerId == PlayerId,
                    "An older canceled admission must not close its replacement connection.");
                Apply(client, Snapshot(OldMatchId, OldTick), string.Empty);
                Require(client.State == null, "A late foreign-match callback must not publish into the new scope.");
                string revision = ObservedInfantryPoseCatalogData.BuiltIn.Revision;
                Apply(client, Snapshot(ReplacementMatchId, 20), revision);
                Require(client.State != null && client.State.ServerTick == 20,
                    "The replacement match must accept its own lower tick after the previous match.");
                MatchSnapshot foreignContent = Snapshot(ReplacementMatchId, 30);
                foreignContent.ManifestHash = new string('b', 64);
                Apply(client, foreignContent, revision);
                Apply(client, Snapshot(ReplacementMatchId, 19), revision);
                Require(client.State.ServerTick == 20,
                    "A foreign manifest or stale same-match reply must not replace the current snapshot.");
                client.LeaveMatch();
                await ExpectCanceledAsync(replacement);
                await VerifyCallbackReplacementAsync(client, receiver);
            }

            Debug.Log("PASS: new-match snapshot reset, foreign callback rejection and canceled admission ownership; " +
                "component lifecycle only, no admitted gameplay.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            if (owner != null)
            {
                UnityEngine.Object.DestroyImmediate(owner);
            }
        }
    }

    private static async Task VerifyCallbackReplacementAsync(SelfHostedBattleClient client, UdpClient pendingReceiver)
    {
        using (var admittedReceiver = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0)))
        {
            Task replacement = null;
            Action<MatchSnapshot> replace = snapshot =>
            {
                client.LeaveMatch();
                replacement = client.Connect(CreateGrant(pendingReceiver, NewMatchId));
            };
            client.StateReceived += replace;
            MatchConnectionGrant grant = CreateGrant(admittedReceiver, ReplacementMatchId);
            Task admission = client.Connect(grant);
            UdpReceiveResult received = await admittedReceiver.ReceiveAsync();
            Packet request = PacketCodec.ReadUntrusted(received.Buffer);
            var reply = new Packet
            {
                Version = 1, SessionId = grant.SessionId, Sequence = 1, Ack = request.Sequence,
                MatchReply = new MatchReply
                {
                    Code = "admitted", Snapshot = Snapshot(ReplacementMatchId, 20),
                    ObservedPoseCatalogRevision = ObservedInfantryPoseCatalogData.BuiltIn.Revision
                }
            };
            byte[] bytes = PacketCodec.Encode(reply, grant.SessionKey.ToByteArray());
            await admittedReceiver.SendAsync(bytes, bytes.Length, received.RemoteEndPoint);
            await ExpectCanceledAsync(admission);
            client.StateReceived -= replace;
            Require(replacement != null && SelfHostedBattleClient.Active == client && !client.IsConnected,
                "Replacing from a snapshot callback must not mark the replacement admitted or close it.");
            client.LeaveMatch();
            await ExpectCanceledAsync(replacement);
        }
    }

    private static MatchConnectionGrant CreateGrant(UdpClient receiver, string matchId)
    {
        const int KeyBytes = 32;
        const ulong SessionId = 4001;
        const int LifetimeSeconds = 60;
        return new MatchConnectionGrant
        {
            Host = "127.0.0.1", Port = (uint)((IPEndPoint)receiver.Client.LocalEndPoint).Port,
            MatchId = matchId, ManifestHash = new string('a', 64), PlayerId = PlayerId,
            SessionId = SessionId, SessionKey = ByteString.CopyFrom(new byte[KeyBytes]),
            Ticket = "pending-scope-fixture",
            ExpiresUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + LifetimeSeconds
        };
    }

    private static MatchSnapshot Snapshot(string matchId, ulong tick)
    {
        MatchSnapshot snapshot = (MatchSnapshot)typeof(UnityCoopWalkingVisualAudit)
            .GetMethod("CreateSnapshot", BindingFlags.Static | BindingFlags.NonPublic).Invoke(null, null);
        snapshot.MatchId = matchId;
        snapshot.ServerTick = tick;
        snapshot.Coop.DeadlineTick = 1000;
        BattleCoopEnemySpawn enemy = snapshot.Coop.EnemySpawns[0];
        enemy.PoseTick = tick;
        enemy.InfantryVisualClip = "";
        enemy.InfantryVisualStartTick = 0;
        enemy.InfantryVisualSampleTick = 0;
        enemy.InfantryAnimation.SampleTick = tick;
        return snapshot;
    }

    private static void Apply(SelfHostedBattleClient client, MatchSnapshot snapshot, string revision)
    {
        typeof(SelfHostedBattleClient).GetMethod("Apply", BindingFlags.Instance | BindingFlags.NonPublic)
            .Invoke(client, new object[]
            {
                new MatchReply { Code = "state", Snapshot = snapshot, ObservedPoseCatalogRevision = revision }
            });
    }

    private static void SetLocalPlayer(SelfHostedBattleClient client)
    {
        typeof(SelfHostedBattleClient).GetProperty("LocalPlayerId").SetValue(client, PlayerId, null);
    }

    private static async Task ExpectCanceledAsync(Task pending)
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
        catch (SocketException failure) when (failure.SocketErrorCode == SocketError.OperationAborted ||
            failure.SocketErrorCode == SocketError.Interrupted || failure.SocketErrorCode == SocketError.NotSocket)
        {
            return;
        }

        throw new InvalidOperationException("A closed pending admission unexpectedly completed.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
