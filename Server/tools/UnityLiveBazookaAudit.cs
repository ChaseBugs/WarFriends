using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Google.Protobuf;
using War.Client;
using War.Protocol;

/// <summary>Combines the production UDP adapter and normal battle bridge with two recovered scene rigs.</summary>
public static class UnityLiveBazookaAudit
{
    private const int TimeoutSeconds = 70;
    private const int PollMilliseconds = 40;
    private const int ExpectedImpacts = 5;
    private const int RpgSlot = 2;
    private static readonly Vector3 Target = new Vector3(0, 2, 0);
    private static Task _audit;
    private static double _deadline;
    private static string _stage = "scene-load";
    private static SelfHostedBattleClient _client;
    private static UnityLiveBazookaEffectObservation _effects;

    /// <summary>Requires two temporary host-issued grants from the .NET fixture.</summary>
    public static void Run()
    {
        string path = Environment.GetEnvironmentVariable("WAR_BAZOOKA_LIVE_GRANTS_FILE");
        if (string.IsNullOrEmpty(path))
        {
            throw new InvalidOperationException("Set WAR_BAZOOKA_LIVE_GRANTS_FILE to the host fixture's grant file.");
        }

        string[] lines = File.ReadAllLines(path);
        if (lines.Length != 2)
        {
            throw new InvalidOperationException("Expected two independently signed bazooka grants.");
        }

        var local = JsonParser.Default.Parse<MatchConnectionGrant>(lines[0]);
        var peer = JsonParser.Default.Parse<MatchConnectionGrant>(lines[1]);
        _deadline = EditorApplication.timeSinceStartup + TimeoutSeconds;
        _audit = CheckAsync(local, peer, null, null);
        EditorApplication.update += Observe;
    }

    /// <summary>Runs the same live battle scenario after an isolated Play Mode scene is ready.</summary>
    public static Task RunPreparedAsync(
        MatchConnectionGrant local,
        MatchConnectionGrant peer,
        GameObject sources,
        UnityBazookaEffectFixture effects)
    {
        if (!Application.isPlaying || sources == null || effects == null)
        {
            throw new InvalidOperationException("Prepare source services and enter Play Mode first.");
        }

        return CheckAsync(local, peer, sources, effects);
    }

    /// <summary>Reports the last completed setup step for native timeout diagnostics.</summary>
    public static string Stage { get { return _stage; } }

    private static async Task CheckAsync(
        MatchConnectionGrant local,
        MatchConnectionGrant peer,
        GameObject sources,
        UnityBazookaEffectFixture effects)
    {
        GameObject owner = null;
        GameObject left = null;
        GameObject right = null;
        try
        {
            UnityLiveBazookaRigs.Select(sources, out left, out right);
            PlayerController leftPlayer = left.GetComponent<PlayerController>();
            PlayerController rightPlayer = right.GetComponent<PlayerController>();
            UnityLiveBazookaRigs.BindInventory(leftPlayer, local);
            UnityLiveBazookaRigs.BindInventory(rightPlayer, peer);
            owner = new GameObject("LiveBazookaAdapter");
            SelfHostedBattleClient adapter = owner.AddComponent<SelfHostedBattleClient>();
            _client = adapter;
            using (var token = new CancellationTokenSource(TimeSpan.FromSeconds(TimeoutSeconds)))
            using (var other = new MatchConnection(peer))
            {
                SetStage("local-admission");
                await adapter.Connect(local);
                SetStage("peer-admission");
                await other.ConnectAsync(token.Token);
                SetStage("bridge-activation");
                if (effects != null)
                {
                    _effects = new UnityLiveBazookaEffectObservation(effects, adapter);
                }

                adapter.ActivateDeathMatchScene(leftPlayer, rightPlayer);
                if (_effects != null)
                {
                    _effects.BindCompletedHandler();
                }

                var observation = new UnityLiveBazookaObservation(local.PlayerId, peer.PlayerId);
                adapter.StateReceived += observation.ObserveSnapshot;
                adapter.CombatEventReceived += observation.ObserveEvent;
                await RunBattleAsync(adapter, other, observation, token.Token);
                Debug.Log("UNITY_LIVE_BAZOOKA_PASSED: five moving host missiles, M202 real/fake, " +
                    "RPG slot independence, production bridge tails and identical two-peer impacts; " +
                    (Application.isPlaying ?
                        "automatic Play Mode polling and source effects." : "Editor components only."));
            }
        }
        finally
        {
            DestroyOwned(owner);
            DestroyOwned(left);
            DestroyOwned(right);
        }
    }

    private static async Task RunBattleAsync(
        SelfHostedBattleClient adapter,
        MatchConnection other,
        UnityLiveBazookaObservation observation,
        CancellationToken token)
    {
        SetStage("peer-ready-first");
        await other.ReadyAsync(token);
        await WaitForAsync(() => adapter.State.Players.Single(row => row.PlayerId == other.LocalPlayerId).Ready,
            adapter, token);
        await adapter.Ready();
        SetStage("wait-running");
        await WaitForAsync(() => adapter.State.Phase == BattlePhase.Running, adapter, token);
        await adapter.BazookaHold(true, Target);
        SetStage("wait-four-m202-flights");
        await WaitForAsync(() => observation.HasM202Volley, adapter, token);
        await adapter.SwitchWeapon(RpgSlot);
        SetStage("verify-slot-switch");
        UnityLiveBazookaRigs.VerifySlotSelection(adapter, RpgSlot);
        observation.VerifySwitchedFlight();
        Require((await other.SwitchWeaponAsync(RpgSlot, token)).Code == "weapon-selected",
            "The independently admitted peer must select its own RPG slot.");
        Require((await other.BazookaHoldAsync(true, Target.x, Target.y, Target.z, token))
            .Code == "bazooka-targeting", "The peer must send a real typed RPG hold.");
        SetStage("wait-five-impacts");
        await WaitForAsync(() => observation.ImpactCount == ExpectedImpacts, adapter, token);
        SetStage("compare-peer-history");
        observation.VerifyPeer(await ReadPeerImpactsAsync(other, token));
        if (_effects != null)
        {
            SetStage("wait-source-particle-simulation");
            await WaitForAsync(_effects.HasFinished, adapter, token);
        }
    }

    private static void DestroyOwned(GameObject owned)
    {
        if (owned == null)
        {
            return;
        }

        if (Application.isPlaying)
        {
            UnityEngine.Object.Destroy(owned);
        }
        else
        {
            UnityEngine.Object.DestroyImmediate(owned);
        }
    }

    private static async Task WaitForAsync(
        Func<bool> condition, SelfHostedBattleClient adapter, CancellationToken token)
    {
        while (!condition())
        {
            await Task.Delay(PollMilliseconds, token);
            if (_effects != null)
            {
                _effects.ThrowIfFailed();
            }

            if (!Application.isPlaying)
            {
                // Only the Editor control needs explicit polling; Play Mode uses the real adapter Update.
                await adapter.Refresh();
                await adapter.DispatchEvents();
            }
        }
    }

    private static async Task<IReadOnlyDictionary<ulong, MatchEvent>> ReadPeerImpactsAsync(
        MatchConnection peer, CancellationToken token)
    {
        var result = new Dictionary<ulong, MatchEvent>();
        var consumer = new MatchEventConsumer();
        consumer.EventReceived += item =>
        {
            if (item.Kind == MatchEventKind.Impact && (item.Reason == "bazooka" || item.Reason == "bazooka-fake"))
            {
                result.Add(item.ProjectileId, item.Clone());
            }
        };
        while (result.Count < ExpectedImpacts)
        {
            MatchEventBatch page = await peer.PollEventsAsync(consumer.LastEventId, token);
            if (page.Events.Count == 0)
            {
                throw new InvalidOperationException("The peer history omitted an impact already delivered to Unity.");
            }

            consumer.Consume(page);
        }

        return result;
    }

    private static void Observe()
    {
        if (!_audit.IsCompleted && EditorApplication.timeSinceStartup < _deadline)
        {
            return;
        }

        EditorApplication.update -= Observe;
        if (_audit.IsCompleted && !_audit.IsFaulted && !_audit.IsCanceled)
        {
            EditorApplication.Exit(0);
        }
        else
        {
            string state = _client == null || _client.State == null ? "no-state" :
                "phase=" + _client.State.Phase + ", tick=" + _client.State.ServerTick +
                ", shots=" + _client.State.Players[0].ShotsFired +
                ", targeting=" + _client.State.Players[0].BazookaTargeting +
                ", projectiles=" + string.Join(",", _client.State.Projectiles.Select(row => row.Kind).ToArray());
            Debug.LogError((_audit.Exception == null ? "Live bazooka audit timed out." : _audit.Exception.ToString()) +
                " stage=" + _stage + ", " + state);
            EditorApplication.Exit(1);
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private static void SetStage(string stage)
    {
        _stage = stage;
        Debug.Log("LIVE_BAZOOKA_STAGE " + stage);
    }
}
