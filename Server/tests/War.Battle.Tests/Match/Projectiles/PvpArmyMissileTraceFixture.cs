using System.Text.Json;
using Google.Protobuf;
using War.Battle.Tests.Match.Tracing;
using War.Battle.Tests.Startup;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Projectiles;

internal sealed class PvpArmyMissileTraceFixture : IDisposable
{
    internal const string First = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    internal const string Second = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    internal const string Rocket = "ID_UNIT-ROCKETSOLDIER";
    internal const string Mortar = "ID_UNIT-MORTAR";
    private const int RandomScale = 1_000_000;
    private const ulong MaximumTick = 1800;
    private static readonly Lazy<BattleCombatContent> Content = new(() =>
        BattleArmyManifestProjectionTests.LoadContent(
            Path.Combine(BackendStartupPolicyTests.FindServerDirectory(), "content")));
    private static readonly JsonSerializerOptions Json = new() { IncludeFields = true };
    private readonly MatchEngineTrace _trace;
    private readonly string _scenario;
    private readonly HashSet<ulong> _projectiles = [];
    private ulong _hostTick = 60;
    private ulong _eventCursor;

    private PvpArmyMissileTraceFixture(string scenario, MatchEngine engine)
    {
        _trace = new MatchEngineTrace(scenario, engine);
        _scenario = scenario;
    }

    internal MatchEngine Engine => _trace.Engine;

    internal ulong EntityKey { get; private set; }

    internal static PvpArmyMissileTraceFixture Ordinary(string scenario, string unit, MissileTraceMode mode)
    {
        MatchEngine? engine = null;
        ulong entity = 0;
        int Choose(int maximum)
        {
            if (mode != MissileTraceMode.Fake || maximum != RandomScale || engine == null)
            {
                return 0;
            }
            bool isReady = unit == Rocket
                ? engine.CardRocketAttack(entity)?.Phase == ArmyRusherAttackPhase.Ready
                : engine.MortarConstruction(entity) is { } construction &&
                    engine.Snapshot().ServerTick >= construction.FirstFireEligibleTick;
            return isReady ? RandomScale - 1 : 0;
        }
        engine = mode == MissileTraceMode.ShortIdle
            ? OrdinaryArmyTestHost.CreateWithIdleTimeout(Content.Value, unit, 2)
            : mode == MissileTraceMode.Fake
                ? OrdinaryArmyTestHost.CreateWithAccuracy(Content.Value, unit, 0.5f, Choose)
                : OrdinaryArmyTestHost.Create(Content.Value, unit, armyChoice: Choose);
        var fixture = new PvpArmyMissileTraceFixture(scenario, engine);
        int option = engine.ArmyBatch(First).OptionIndexes.OrderBy(index => Content.Value.Army.Option(index).Count)
            .First();
        var command = new MatchCommand { CommandId = 3, DeployArmy = new() { OptionIndex = option } };
        Require(fixture._trace.Command(First, command).Code == "army-deploying", "Missile deployment failed.");
        fixture._trace.Command(First, command);
        fixture.Advance();
        fixture.EntityKey = engine.ArmyEntityBatch(First, 0, 0).Entities.First().EntityKey;
        entity = fixture.EntityKey;
        return fixture;
    }

    internal static PvpArmyMissileTraceFixture Card()
    {
        var fixture = new PvpArmyMissileTraceFixture("source-BIGROCKET-card",
            PvpArmyMissileCardHost.Create(Content.Value));
        var command = new MatchCommand { CommandId = 3, UseUnitCard = new()
        {
            RequestId = "cccccccccccccccccccccccccccccccc", SourceCardId = PvpArmyMissileCardHost.Card
        } };
        Require(fixture._trace.Command(First, command).Code == "unit-card-activated", "Rocket card was refused.");
        fixture._trace.Command(First, command);
        fixture.Advance();
        fixture.EntityKey = fixture.Engine.ArmyEntityBatch(First, 0, 0).Entities.First().EntityKey;
        return fixture;
    }

    internal void Advance()
    {
        _trace.Advance(++_hostTick);
        ObserveBoth();
    }

    private void ObserveBoth()
    {
        ObserveFirst();
        _trace.ObservePayload("missile-events-second", Engine.EventBatch(Second, _eventCursor).ToByteArray());
    }

    private void ObserveFirst()
    {
        while (true)
        {
            MatchEventBatch batch = Engine.EventBatch(First, _eventCursor);
            _trace.ObservePayload("missile-events-first", batch.ToByteArray());
            if (batch.Events.Count == 0)
            {
                break;
            }
            _eventCursor = batch.Events[^1].EventId;
        }
        foreach (BattleProjectileState row in Engine.Snapshot().Projectiles)
        {
            if (row.Kind is "card-rocket" or "card-rocket-fake" or "army-mortar" or "army-mortar-fake")
            {
                _projectiles.Add(row.ProjectileId);
            }
        }
        var state = new
        {
            Count = Engine.CardRocketActiveFlightCount,
            Launches = _projectiles.Order().Select(id => new { Id = id, Missile = Engine.CardRocketLaunchMissile(id) }),
            Impacts = Engine.CardRocketImpacts()
        };
        _trace.ObservePayload("missile-authority-impacts", JsonSerializer.SerializeToUtf8Bytes(state, Json));
    }

    internal BattleProjectileState WaitForLaunch(string kind)
    {
        BattleProjectileState? row = null;
        WaitUntil(() => (row = Engine.Snapshot().Projectiles.FirstOrDefault(candidate =>
            candidate.Kind == kind && candidate.OwnerPlayerId == First)) != null);
        Require(Engine.CardRocketLaunchMissile(row!.ProjectileId) != null, "A launch has no frozen missile authority.");
        return row;
    }

    internal void WaitUntil(Func<bool> condition)
    {
        while (!condition() && !Engine.Terminal && Engine.Snapshot().ServerTick < MaximumTick)
        {
            Advance();
        }
        Require(condition(), "The missile trace failed to reach its target: " + _scenario + "/" +
            Engine.Snapshot().ServerTick + "/" + Engine.Snapshot().TerminalReason);
    }

    internal void KillSoldier()
    {
        _trace.Observe("confirmed-missile-soldier-death", Engine.ConfirmArmyDeath(EntityKey, false));
        ObserveBoth();
    }

    internal void Forfeit()
    {
        _trace.Command(First, new MatchCommand { CommandId = 4, Forfeit = new() });
        ObserveBoth();
    }

    internal void PauseAndResume()
    {
        ulong previous = Engine.Snapshot().ServerTick;
        const int IdleFrames = 62;
        for (int index = 0; index < IdleFrames; index++)
        {
            _trace.Advance(++_hostTick);
            ObserveFirst();
            if (Engine.Snapshot().ServerTick == previous)
            {
                break;
            }
            previous = Engine.Snapshot().ServerTick;
        }
        Require(!Engine.Terminal && Engine.Snapshot().ServerTick < _hostTick, "The missile fixture failed to pause.");
        _hostTick += MatchManifest.TickRate;
        _trace.Advance(_hostTick, Engine.ObservedRealTimeSeconds + 3);
        ObserveFirst();
        _trace.Observe("missile-source-resume", Engine.Resume(Second));
        _trace.Advance(++_hostTick, Engine.ObservedRealTimeSeconds + 1d / MatchManifest.TickRate);
        ObserveBoth();
    }

    internal MatchEngineTraceResult Finish()
    {
        return _trace.Finish();
    }

    /// <summary>Releases trace hashing without retaining a temporary project or content copy.</summary>
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

internal enum MissileTraceMode
{
    Real,
    Fake,
    ShortIdle
}
