using System.Text.Json;
using Google.Protobuf;
using War.Battle.Tests.Match.Tracing;
using War.Battle.Tests.Startup;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Effects;

internal sealed class PvpArmyEffectTraceFixture : IDisposable
{
    internal const string First = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    internal const string Second = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    internal const string Flame = "ID_UNIT-FLAMETHROWER";
    internal const string Commando = "ID_UNIT-COMMANDO";
    private static readonly Lazy<BattleCombatContent> Content = new(() =>
        BattleArmyManifestProjectionTests.LoadContent(
            Path.Combine(BackendStartupPolicyTests.FindServerDirectory(), "content")));
    private readonly MatchEngineTrace _trace;
    private readonly ulong[] _entities;
    private readonly List<MatchEvent> _events = [];
    private ulong _hostTick = 60;
    private ulong _eventCursor;

    internal PvpArmyEffectTraceFixture(string scenario, string unit, int idleSeconds = 120)
    {
        var upgrades = new OrdinaryArmyTestHost.UpgradeSelection(0, unit == Commando ? 71 : -1, -1);
        MatchEngine engine = OrdinaryArmyTestHost.CreateUpgraded(Content.Value, unit, upgrades, idleSeconds);
        _trace = new MatchEngineTrace(scenario, engine);
        int option = engine.ArmyBatch(Second).OptionIndexes
            .OrderBy(index => Content.Value.Army.Option(index).Count).First();
        var deploy = new MatchCommand { CommandId = 3, DeployArmy = new() { OptionIndex = option } };
        Require(_trace.Command(Second, deploy).Code == "army-deploying", "The effect trace could not deploy.");
        _trace.Command(Second, deploy);
        _trace.Advance(++_hostTick);
        _entities = engine.ArmyEntityBatch(Second, 0, 0).Entities.Select(row => row.EntityKey).Order().ToArray();
        Require(_entities.Length > 0, "The effect trace has no source soldier.");
        ObserveBoth();
    }

    internal MatchEngine Engine => _trace.Engine;

    internal ulong Actor => _entities[0];

    internal IReadOnlyList<MatchEvent> Events => _events;

    internal void Advance()
    {
        _trace.Advance(++_hostTick);
        ObserveBoth();
    }

    internal void AdvanceWithoutOpponentTraffic()
    {
        _trace.Advance(++_hostTick);
        ObserveFirst();
    }

    internal void DeferFrame()
    {
        _trace.Advance(_hostTick, Engine.ObservedRealTimeSeconds + 0.2);
        ObserveBoth();
    }

    internal void ObserveBoth()
    {
        ObserveFirst();
        _trace.ObservePayload("events-second", Engine.EventBatch(Second, _eventCursor).ToByteArray());
    }

    private void ObserveFirst()
    {
        while (true)
        {
            MatchEventBatch batch = Engine.EventBatch(First, _eventCursor);
            _trace.ObservePayload("events-first", batch.ToByteArray());
            if (batch.Events.Count == 0)
            {
                break;
            }
            _events.AddRange(batch.Events);
            _eventCursor = batch.Events[^1].EventId;
        }
        var state = _entities.Select(entity => new
        {
            Entity = entity,
            Flame = Engine.ArmyFlameProgress(entity).Select(row => new
            {
                row.ProjectileId, row.PulseIndex, DeadlineBits = BitConverter.SingleToInt32Bits(row.NextPulseSeconds)
            }).ToArray(),
            Poison = Engine.ArmyPoisonProgress(entity).Select(row => new { row.ProjectileId, row.Remaining }).ToArray()
        }).ToArray();
        _trace.ObservePayload("effect-state", JsonSerializer.SerializeToUtf8Bytes(state));
    }

    internal void KillActor()
    {
        _trace.Observe("confirmed-source-death", Engine.ConfirmArmyDeath(Actor, false));
        ObserveBoth();
    }

    internal void Forfeit()
    {
        _trace.Command(First, new MatchCommand { CommandId = 3, Forfeit = new() });
        ObserveBoth();
    }

    internal void WaitUntil(Func<bool> condition)
    {
        const ulong MaximumTick = 2400;
        while (!condition() && !Engine.Terminal && Engine.Snapshot().ServerTick < MaximumTick)
        {
            Advance();
        }
        Require(condition(), "The source effect trace never reached its required state: " +
            Engine.Snapshot().TerminalReason);
    }

    internal void AdvanceFrames(int count)
    {
        for (int frame = 0; frame < count && !Engine.Terminal; frame++)
        {
            Advance();
        }
    }

    internal void PauseObservation()
    {
        ulong previous = Engine.Snapshot().ServerTick;
        for (int frame = 0; frame < 62; frame++)
        {
            AdvanceWithoutOpponentTraffic();
            if (Engine.Snapshot().ServerTick == previous)
            {
                break;
            }
            previous = Engine.Snapshot().ServerTick;
        }
        Require(!Engine.Terminal && Engine.Snapshot().ServerTick < _hostTick, "The effect fixture did not pause.");
        _hostTick += 30;
        _trace.Advance(_hostTick, Engine.ObservedRealTimeSeconds + 3);
        ObserveFirst();
        _trace.Observe("source-resume", Engine.Resume(Second));
        _trace.Advance(++_hostTick, Engine.ObservedRealTimeSeconds + 1d / MatchManifest.TickRate);
        ObserveBoth();
    }

    internal MatchEngineTraceResult Finish()
    {
        return _trace.Finish();
    }

    /// <summary>Releases the incremental trace hash without retaining a temporary project or scene copy.</summary>
    public void Dispose()
    {
        _trace.Dispose();
    }

    internal static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
