using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Google.Protobuf;
using War.Client;
using War.Protocol;

/// <summary>Invokes the real DeathMatch Update while only the self-hosted clock may own overtime.</summary>
public static class UnityPvpClockAudit
{
    private const ulong StartTick = 30;
    private const ulong CurrentTick = 90;
    private const ulong EndTick = 330;
    private const ulong PrestartDelayTicks = 60;
    private const float ExpectedSeconds = 8f;
    private const int RepeatedFrames = 40;
    private const string PlayerId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const BindingFlags InstanceFields = BindingFlags.Instance | BindingFlags.NonPublic;

    /// <summary>Uses real source controllers and an owned SDK connection, without boot or rendered gameplay.</summary>
    public static void Run()
    {
        GameObject adapterRoot = null;
        GameObject sources = null;
        try
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            sources = new GameObject("InactivePvpClockSources");
            sources.SetActive(false);
            GameController game = sources.AddComponent<GameController>();
            MatchManager manager = sources.AddComponent<MatchManager>();
            TimeManager time = sources.AddComponent<TimeManager>();
            PhotonConnectionManager photon = sources.AddComponent<PhotonConnectionManager>();
            GameControllerDeathMatch controller = sources.AddComponent<GameControllerDeathMatch>();
            BindSingleton(game);
            BindSingleton(manager);
            BindSingleton(photon);
            typeof(TimeManager).GetField("mInstance", BindingFlags.Static | BindingFlags.NonPublic)
                .SetValue(null, time);
            typeof(GameController).GetField("mGameIsRunning", InstanceFields).SetValue(game, true);
            adapterRoot = new GameObject("PvpClockAdapter");
            SelfHostedBattleClient client = adapterRoot.AddComponent<SelfHostedBattleClient>();
            using (var receiver = new UdpClient(new IPEndPoint(IPAddress.Loopback, 0)))
            using (var connection = new MatchConnection(CreateGrant(receiver)))
            {
                typeof(SelfHostedBattleClient).GetField("connection", InstanceFields).SetValue(client, connection);
                typeof(SelfHostedBattleClient).GetProperty("Active").SetValue(null, client, null);
                VerifyClock(controller, manager, client, game);
            }

            Debug.Log("PASS: real DeathMatch Update uses host time, holds a paused tick, " +
                "projects overtime once, resets it, and rejects malformed clocks without mutation; " +
                "no Photon RPC, local shield simulation or rendered gameplay.");
            EditorApplication.Exit(0);
        }
        catch (Exception failure)
        {
            Debug.LogException(failure);
            EditorApplication.Exit(1);
        }
        finally
        {
            if (adapterRoot != null)
            {
                UnityEngine.Object.DestroyImmediate(adapterRoot);
            }

            if (sources != null)
            {
                UnityEngine.Object.DestroyImmediate(sources);
            }
        }
    }

    private static void VerifyClock(
        GameControllerDeathMatch controller,
        MatchManager manager,
        SelfHostedBattleClient client,
        GameController game)
    {
        int overtimeNotifications = 0;
        manager.OverTimeStarted += () => overtimeNotifications++;
        MatchSnapshot snapshot = Running();
        SetSnapshot(client, snapshot);
        controller.time = 0f;
        InvokeUpdate(controller);
        Require(controller.time == ExpectedSeconds && !manager.isOverTime && overtimeNotifications == 0,
            "An expired local timer must not start overtime or replace the host countdown.");
        snapshot.PauseHostTick = 1000;
        for (int frame = 0; frame < RepeatedFrames; frame++)
        {
            InvokeUpdate(controller);
            Require(controller.time == ExpectedSeconds, "A held simulation tick must retain the same HUD time.");
        }

        snapshot.ServerTick = EndTick;
        snapshot.EndTick = 0;
        snapshot.Overtime = true;
        typeof(GameController).GetField("mGameIsRunning", InstanceFields).SetValue(game, false);
        InvokeUpdate(controller);
        Require(controller.time == 0f && !manager.isOverTime && overtimeNotifications == 0,
            "Loading must not publish overtime before the recovered GameStarted presentation.");
        typeof(GameController).GetField("mGameIsRunning", InstanceFields).SetValue(game, true);
        InvokeUpdate(controller);
        InvokeUpdate(controller);
        Require(controller.time == 0f && manager.isOverTime && overtimeNotifications == 1,
            "The host overtime flag must raise the recovered event once without its legacy RPC.");
        var canceled = new MatchSnapshot
        {
            Phase = BattlePhase.Aborted,
            ServerTick = CurrentTick,
            EndTick = CurrentTick,
            StartTick = CurrentTick + PrestartDelayTicks
        };
        SetSnapshot(client, canceled);
        InvokeUpdate(controller);
        Require(controller.time == 0f && !manager.isOverTime && overtimeNotifications == 1,
            "A prestart cancellation keeps its future scheduled start without projecting overtime.");
        SetSnapshot(client, Running());
        InvokeUpdate(controller);
        Require(!manager.isOverTime && overtimeNotifications == 1,
            "A new regular host clock must clear presentation overtime without another notification.");
        VerifyInvalidClock(controller, manager, client);
    }

    private static void VerifyInvalidClock(
        GameControllerDeathMatch controller, MatchManager manager, SelfHostedBattleClient client)
    {
        MatchSnapshot invalid = Running();
        invalid.EndTick = 0;
        SetSnapshot(client, invalid);
        bool hasRejected = false;
        try
        {
            InvokeUpdate(controller);
        }
        catch (TargetInvocationException failure)
        {
            hasRejected = failure.InnerException != null &&
                failure.InnerException.GetType().FullName == "System.IO.InvalidDataException";
        }

        Require(hasRejected && controller.time == ExpectedSeconds && !manager.isOverTime,
            "An inconsistent clock must fail before changing time or overtime presentation.");
    }

    private static MatchSnapshot Running()
    {
        return new MatchSnapshot
        {
            MatchId = "pvp-clock-audit",
            Phase = BattlePhase.Running,
            ServerTick = CurrentTick,
            StartTick = StartTick,
            EndTick = EndTick
        };
    }

    private static MatchConnectionGrant CreateGrant(UdpClient receiver)
    {
        const int KeyBytes = 32;
        const int LifetimeSeconds = 60;
        return new MatchConnectionGrant
        {
            Host = "127.0.0.1",
            Port = (uint)((IPEndPoint)receiver.Client.LocalEndPoint).Port,
            MatchId = "pvp-clock-audit",
            ManifestHash = new string('a', KeyBytes * 2),
            PlayerId = PlayerId,
            SessionId = 4001,
            SessionKey = ByteString.CopyFrom(new byte[KeyBytes]),
            Ticket = "unadmitted-clock-fixture",
            ExpiresUnixSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + LifetimeSeconds
        };
    }

    private static void InvokeUpdate(GameControllerDeathMatch controller)
    {
        typeof(GameControllerDeathMatch).GetMethod("Update", InstanceFields).Invoke(controller, null);
    }

    private static void SetSnapshot(SelfHostedBattleClient client, MatchSnapshot snapshot)
    {
        typeof(SelfHostedBattleClient).GetProperty("State").SetValue(client, snapshot, null);
    }

    private static void BindSingleton<T>(T source) where T : Core_BaseScript
    {
        typeof(Singleton<T>).GetField("_instance", BindingFlags.Static | BindingFlags.NonPublic)
            .SetValue(null, source);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
