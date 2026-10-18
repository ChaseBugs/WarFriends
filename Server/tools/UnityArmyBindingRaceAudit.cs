using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Google.Protobuf;
using UnityEditor;
using UnityEngine;
using War.Client;
using War.Protocol;
using War.Protocol.Transport;

/// <summary>Exercises real UDP reply ordering while the same Unity army manager is rebound.</summary>
public static class UnityArmyBindingRaceAudit
{
    private const BindingFlags PrivateInstance = BindingFlags.Instance | BindingFlags.NonPublic;
    private const int DeadlineMilliseconds = 5_000;
    private const int MaximumQueuedRequests = 32;
    private static readonly byte[] SessionKey = new byte[32];
    private static readonly string ManifestHash = new string('a', 64);
    private static ulong _responseSequence;

    public static async void RunAsync()
    {
        GameObject owner = new GameObject("ArmyBindingRaceAudit");
        owner.SetActive(false);
        using (var server = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0)))
        using (var lifetime = new CancellationTokenSource())
        {
            MatchConnection transport = null;
            try
            {
                var grant = CreateGrant((uint)((IPEndPoint)server.Client.LocalEndPoint).Port);
                transport = new MatchConnection(grant);
                SetField(transport, "admitted", true);
                SelfHostedBattleClient client = owner.AddComponent<SelfHostedBattleClient>();
                SpawningManagerDeathMatch army = owner.AddComponent<SpawningManagerDeathMatch>();
                SetField(client, "connection", transport);
                SetField(client, "lifetime", lifetime);
                typeof(SelfHostedBattleClient).GetProperty("IsConnected").SetValue(client, true, null);
                await VerifyBindingAndRefreshAsync(server, client, army);
                await VerifyRetiredDeploymentAsync(server, client, army);
                await VerifyManagerContinuationAsync(server, client, army);
                client.UnbindArmyManager(army);
                Require(GetField(army, "mSelfHosted") == null, "The completed race leaked a subscription.");
                File.WriteAllText(Path.Combine(Application.dataPath, "../army-binding-race-unity-audit.json"),
                    "{\"checks\":8,\"scope\":\"authenticated UDP binding, refresh and deployment rebinding\"}\n");
                Debug.Log("PASS: 8 real UDP army ownership checks; admission was fixture-provisioned.");
                EditorApplication.Exit(0);
            }
            catch (Exception failure)
            {
                Debug.LogException(failure);
                EditorApplication.Exit(1);
            }
            finally
            {
                UnityEngine.Object.DestroyImmediate(owner);
                if (transport != null) transport.Dispose();
            }
        }
    }

    private static async Task VerifyBindingAndRefreshAsync(UdpClient server, SelfHostedBattleClient client,
        SpawningManagerDeathMatch army)
    {
        int published = 0;
        client.ArmyOffersReceived += _ => published++;

        Task retired = client.BindArmyManager(army);
        UdpReceiveResult first = await ReceiveAsync(server);
        Packet firstRequest = ReadRequest(first);
        client.UnbindArmyManager(army);
        Task successor = client.BindArmyManager(army);
        await ReplyAsync(server, first, firstRequest, 1);
        bool rejected = false;
        try
        {
            await WithinDeadline(retired);
        }
        catch (OperationCanceledException)
        {
            rejected = true;
        }
        Require(rejected && published == 0, "Retired reply reached the rebound manager.");
        Require(ReferenceEquals(GetField(client, "armyManager"), army),
            "Retired bind cleanup detached the successor owner.");
        await ReplyToSuccessorAsync(server, successor);
        await WithinDeadline(successor);
        Require(published == 1 && ReferenceEquals(GetField(client, "armyManager"), army),
            "The successor reply failed to publish exactly once to its owner.");
        Task refresh = client.RefreshArmy();
        UdpReceiveResult refreshPacket = await ReceiveAsync(server);
        Packet refreshRequest = ReadRequest(refreshPacket);
        client.UnbindArmyManager(army);
        Task rebound = client.BindArmyManager(army);
        await ReplyAsync(server, refreshPacket, refreshRequest, 3);
        bool refreshRejected = false;
        try
        {
            await WithinDeadline(refresh);
        }
        catch (OperationCanceledException)
        {
            refreshRejected = true;
        }
        Require(refreshRejected && published == 1, "Retired army refresh reached a successor binding.");
        await ReplyToSuccessorAsync(server, rebound);
        await WithinDeadline(rebound);
        Require(published == 2, "Rebound army did not retain independent publication ownership.");
    }

    private static async Task VerifyRetiredDeploymentAsync(UdpClient server, SelfHostedBattleClient client,
        SpawningManagerDeathMatch army)
    {
        Task deployment = client.DeployArmyResult(0);
        UdpReceiveResult received = await ReceiveAsync(server);
        Packet request = PacketCodec.ReadUntrusted(received.Buffer);
        Require(PacketCodec.Authenticate(received.Buffer, SessionKey) && request.MatchCommand != null,
            "Expected an authenticated deployment command.");
        client.UnbindArmyManager(army);
        Task successor = client.BindArmyManager(army);
        await ReplyDeploymentAsync(server, received, request);
        bool rejected = false;
        try
        {
            await WithinDeadline(deployment);
        }
        catch (OperationCanceledException)
        {
            rejected = true;
        }
        Require(rejected && client.State == null, "A retired deployment applied its snapshot to a successor.");
        await ReplyToSuccessorAsync(server, successor);
        await WithinDeadline(successor);
    }

    private static async Task VerifyManagerContinuationAsync(UdpClient server, SelfHostedBattleClient client,
        SpawningManagerDeathMatch army)
    {
        var definition = new SpawningManagerDeathMatch.ArmyUnitDefinition();
        var deployment = (Task)typeof(SpawningManagerDeathMatch)
            .GetMethod("SendSelfHostedUnitAsync", PrivateInstance).Invoke(army, new object[] { definition, false });
        UdpReceiveResult received = await ReceiveAsync(server);
        Packet request = PacketCodec.ReadUntrusted(received.Buffer);
        Require(PacketCodec.Authenticate(received.Buffer, SessionKey) && request.MatchCommand != null,
            "Expected the manager's authenticated deployment command.");
        client.UnbindArmyManager(army);
        Task successor = client.BindArmyManager(army);
        SetField(army, "mSelfHostedDeployPending", true);
        SetField(army, "mSelfHostedForceRefresh", false);
        SetField(army, "mCoolDown", 123f);
        await ReplyDeploymentAsync(server, received, request);
        await WithinDeadline(deployment);
        Require((bool)GetField(army, "mSelfHostedDeployPending") &&
            !(bool)GetField(army, "mSelfHostedForceRefresh") &&
            (float)GetField(army, "mCoolDown") == 123f && GetField(army, "mCurrentDefinition") == null,
            "Retired manager continuation changed the successor's pending, refresh or cooldown state.");
        await ReplyToSuccessorAsync(server, successor);
        await WithinDeadline(successor);
    }

    private static async Task ReplyDeploymentAsync(UdpClient server, UdpReceiveResult received, Packet request)
    {
        var snapshot = new MatchSnapshot
        {
            MatchId = "army-binding-race", ManifestHash = ManifestHash, Phase = BattlePhase.Running,
            StateRevision = request.MatchCommand.CommandId
        };
        snapshot.Players.Add(new BattlePlayerState
        {
            PlayerId = new string('a', 32), LastCommandId = request.MatchCommand.CommandId
        });
        snapshot.Players.Add(new BattlePlayerState { PlayerId = new string('b', 32) });
        var response = new Packet
        {
            Version = 1, SessionId = request.SessionId, Sequence = ++_responseSequence, Ack = request.Sequence,
            MatchReply = new MatchReply
            {
                CommandId = request.MatchCommand.CommandId, Code = "army-deploying", Snapshot = snapshot
            }
        };
        byte[] bytes = PacketCodec.Encode(response, SessionKey);
        await server.SendAsync(bytes, bytes.Length, received.RemoteEndPoint);
    }

    private static MatchConnectionGrant CreateGrant(uint port)
    {
        return new MatchConnectionGrant
        {
            Host = "127.0.0.1", Port = port, SessionId = 1,
            SessionKey = ByteString.CopyFrom(SessionKey), Ticket = "fixture-ticket",
            MatchId = "army-binding-race", PlayerId = new string('a', 32), ManifestHash = ManifestHash,
            ExpiresUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 300
        };
    }

    private static async Task ReplyToSuccessorAsync(UdpClient server, Task successor)
    {
        for (int index = 0; index < MaximumQueuedRequests; index++)
        {
            Task<UdpReceiveResult> incoming = server.ReceiveAsync();
            Task completed = await Task.WhenAny(successor, incoming, Task.Delay(DeadlineMilliseconds));
            if (completed == successor)
            {
                return;
            }
            if (completed != incoming)
            {
                throw new TimeoutException("The successor request was not observed.");
            }
            UdpReceiveResult received = await incoming;
            Packet request = ReadRequest(received);
            // Retired retries can already be queued when the semaphore admits the successor.
            // Acknowledge every captured poll; the SDK rejects acknowledgements outside its own range.
            await ReplyAsync(server, received, request, (ulong)index + 2);
        }
        throw new InvalidOperationException("The successor request was not observed within the bounded queue.");
    }

    private static Packet ReadRequest(UdpReceiveResult received)
    {
        Require(PacketCodec.Authenticate(received.Buffer, SessionKey), "The SDK poll was not authenticated.");
        Packet request = PacketCodec.ReadUntrusted(received.Buffer);
        Require(request != null && request.MatchArmyPoll != null, "Expected an army poll datagram.");
        return request;
    }

    private static async Task ReplyAsync(UdpClient server, UdpReceiveResult received, Packet request, ulong sequence)
    {
        var reply = new Packet
        {
            Version = 1, SessionId = request.SessionId, Sequence = ++_responseSequence, Ack = request.Sequence,
            MatchArmyBatch = new MatchArmyBatch
            {
                MatchId = "army-binding-race", ManifestHash = ManifestHash, Code = "army-unavailable", Energy = 8
            }
        };
        byte[] bytes = PacketCodec.Encode(reply, SessionKey);
        await server.SendAsync(bytes, bytes.Length, received.RemoteEndPoint);
    }

    private static async Task<UdpReceiveResult> ReceiveAsync(UdpClient server)
    {
        Task<UdpReceiveResult> received = server.ReceiveAsync();
        await WithinDeadline(received);
        return await received;
    }

    private static async Task WithinDeadline(Task pending)
    {
        if (await Task.WhenAny(pending, Task.Delay(DeadlineMilliseconds)) != pending)
        {
            throw new TimeoutException("The UDP binding audit exceeded its bounded wait.");
        }
        await pending;
    }

    private static object GetField(object owner, string name)
    {
        return owner.GetType().GetField(name, PrivateInstance).GetValue(owner);
    }

    private static void SetField(object owner, string name, object value)
    {
        owner.GetType().GetField(name, PrivateInstance).SetValue(owner, value);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
