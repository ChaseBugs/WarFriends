using System.Globalization;
using System.Numerics;
using System.Reflection;
using War.Battle.Tests.Startup;
using War.BattleServer;
using War.Protocol;
using static War.Battle.Tests.Match.Effects.ArmyFlameClockTests;

namespace War.Battle.Tests.Match.Effects;

internal static class ArmyFlameHostClockTests
{
    private const string First = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string Second = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private const string Unit = "ID_UNIT-FLAMETHROWER";
    private const ulong MaximumSeekTick = 1800;
    private static readonly Lazy<BattleCombatContent> Content = new(() =>
        BattleArmyManifestProjectionTests.LoadContent(
            Path.Combine(BackendStartupPolicyTests.FindServerDirectory(), "content")));

    internal static int Run()
    {
        CheckDeferredPlayerPulses();
        CheckBoxPulseReceipts();
        CheckReconnectPause();
        return 3;
    }

    private static MatchEngine CreateHost(float damageScale = 1, int idleTimeoutSeconds = 120)
    {
        MatchEngine host = OrdinaryArmyTestHost.CreateWithPvpBonuses(Content.Value, Unit,
            new(0, -1, -1, damageScale), idleTimeoutSeconds);
        int option = host.ArmyBatch(Second).OptionIndexes
            .OrderBy(index => Content.Value.Army.Option(index).Count).First();
        Require(host.Command(Second, new MatchCommand { CommandId = 3,
            DeployArmy = new() { OptionIndex = option } }).Code == "army-deploying", "The flame deployment failed.");
        return host;
    }

    private static void CheckDeferredPlayerPulses()
    {
        MatchEngine host = CreateHost();
        ulong cursor = 0;
        var references = new Dictionary<ulong, FlameAmmoClockReference>();
        MatchEvent firstHit = SeekPlayerHit(host, references, ref cursor);
        ulong entity = ulong.Parse(firstHit.ActorId, CultureInfo.InvariantCulture);
        FlameAmmoClockReference source = references[firstHit.ProjectileId];
        int remaining = ArmyFlameBurst.HitsPerShot - source.PulseCount;
        Require(remaining > 0, "The fixture reached its target only on the final pulse.");
        ulong fixedTick = host.Snapshot().ServerTick;
        float health = host.Snapshot().Players.Single(player => player.PlayerId == First).Health;
        int impacts = 0;
        for (int frame = 0; frame < 20 && source.PulseCount < ArmyFlameBurst.HitsPerShot; frame++)
        {
            host.Advance(fixedTick, host.ObservedRealTimeSeconds + 0.2);
            source.Advance(host.ObservedCooldownSeconds);
            CheckProgress(host, entity, firstHit.ProjectileId, source);
            MatchEvent[] events = ReadEvents(host, ref cursor);
            impacts += events.Count(row => row.Kind == MatchEventKind.Impact && row.Reason == "army-flame" &&
                row.ProjectileId == firstHit.ProjectileId && row.Tick == fixedTick);
            if (events.Any(row => row.Kind == MatchEventKind.Impact && row.Reason == "army-flame"))
            {
                var throttles = (Dictionary<string, PvpFlameHitThrottle>)typeof(PvpBonusProgressCoordinator)
                    .GetField("flameByVictim", BindingFlags.Instance | BindingFlags.NonPublic)!
                    .GetValue(host.BonusProgress)!;
                Require(throttles[First].LastHitTime == host.ObservedCooldownSeconds,
                    "Flame skill-shot throttling used fixed ticks instead of the source clock.");
            }
        }
        Require(!host.Terminal && host.Snapshot().ServerTick == fixedTick && impacts == remaining &&
            host.Snapshot().Players.Single(player => player.PlayerId == First).Health < health,
            "Deferred source frames lost player pulses, reused a receipt or advanced fixed combat ticks.");
    }

    private static MatchEvent SeekPlayerHit(MatchEngine host,
        Dictionary<ulong, FlameAmmoClockReference> references, ref ulong cursor)
    {
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumSeekTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            MatchEvent[] events = ReadEvents(host, ref cursor);
            foreach (MatchEvent shot in events.Where(row => row.Kind == MatchEventKind.Shot &&
                row.Reason == "army-flame" && row.ActorId == Second))
            {
                references.Add(shot.ProjectileId, new FlameAmmoClockReference(host.ObservedCooldownSeconds));
            }
            foreach (FlameAmmoClockReference source in references.Values)
            {
                source.Advance(host.ObservedCooldownSeconds);
            }
            MatchEvent? hit = events.FirstOrDefault(row => row.Kind == MatchEventKind.Impact &&
                row.Reason == "army-flame" && row.TargetId == First && references.ContainsKey(row.ProjectileId));
            if (hit != null)
            {
                return hit;
            }
        }
        throw new InvalidOperationException("Natural flame fire did not hit the opposing player.");
    }

    private static void CheckProgress(MatchEngine host, ulong entity, ulong projectile, FlameAmmoClockReference source)
    {
        (ulong ProjectileId, int PulseIndex, float NextPulseSeconds)[] rows =
            host.ArmyFlameProgress(entity).Where(row => row.ProjectileId == projectile).ToArray();
        if (source.PulseCount == ArmyFlameBurst.HitsPerShot)
        {
            Require(rows.Length == 0, "The completed source burst retained its capacity reservation.");
            return;
        }
        Require(rows.Length == 1 && rows[0].PulseIndex == source.PulseCount &&
            BitConverter.SingleToInt32Bits(rows[0].NextPulseSeconds) ==
                BitConverter.SingleToInt32Bits(source.NextDeadline),
            "The actual engine's deferred-frame pulse state differs from Client Update.");
    }

    private static void CheckBoxPulseReceipts()
    {
        MatchEngine host = CreateHost(0.0001f);
        host.BonusPlanner.EnqueueConfirmedBonus("11111111111111111111111111111111", Second, 6);
        for (int index = 0; index < 3; index++)
        {
            host.BonusProgress.RecordConfirmedSkillShot(Second,
                (index + 2).ToString("x32", CultureInfo.InvariantCulture), 0x1210, 1f);
        }
        for (ulong tick = 61; tick <= 153; tick++)
        {
            host.Advance(tick);
        }
        PvpBonusBoxSnapshot box = host.BonusPlanner.ActiveBoxesSnapshot().Single();
        BattleArmyEntityState soldier = host.ArmyEntityBatch(Second, 0, 0).Entities.Single();
        var burst = new ArmyFlameBurst(7777, soldier.EntityKey, Second, 0);
        Vector3 origin = box.Position - Vector3.UnitZ;
        burst.CommitPulse(0.4f);
        Require(host.ApplyArmyFlameBonusBoxes(ArmyFlamePulse.FromBurst(burst), origin, Vector3.UnitZ) == 1,
            "The first committed source pulse did not damage the neutral box.");
        float afterFirst = host.BonusPlanner.BoxSnapshot(box.BoxId).Health;
        Require(host.ApplyArmyFlameBonusBoxes(ArmyFlamePulse.FromBurst(burst), origin, Vector3.UnitZ) == 0 &&
            host.BonusPlanner.BoxSnapshot(box.BoxId).Health == afterFirst,
            "Replaying the same committed pulse damaged its box twice.");
        burst.CommitPulse(0.8f);
        Require(host.ApplyArmyFlameBonusBoxes(ArmyFlamePulse.FromBurst(burst), origin, Vector3.UnitZ) == 1 &&
            host.BonusPlanner.BoxSnapshot(box.BoxId).Health < afterFirst && host.Snapshot().ServerTick == 153,
            "Distinct source pulses in one simulation tick shared a bonus-box receipt.");
    }

    private static MatchEvent[] ReadEvents(MatchEngine host, ref ulong cursor)
    {
        MatchEvent[] result = ReadFirstEvents(host, ref cursor);
        host.EventBatch(Second, cursor);
        return result;
    }

    private static void CheckReconnectPause()
    {
        const int IdleSeconds = 2;
        MatchEngine host = CreateHost(idleTimeoutSeconds: IdleSeconds);
        ulong cursor = 0;
        var references = new Dictionary<ulong, FlameAmmoClockReference>();
        MatchEvent firstHit = SeekPlayerHit(host, references, ref cursor);
        ulong entity = ulong.Parse(firstHit.ActorId, CultureInfo.InvariantCulture);
        ulong hostTick = host.Snapshot().ServerTick;
        bool isPaused = false;
        for (int frame = 0; frame < IdleSeconds * MatchManifest.TickRate + 2; frame++)
        {
            ulong previous = host.Snapshot().ServerTick;
            host.Advance(++hostTick, host.ObservedRealTimeSeconds + 1d / MatchManifest.TickRate);
            ReadFirstEvents(host, ref cursor);
            if (host.Snapshot().ServerTick == previous)
            {
                isPaused = true;
                break;
            }
        }
        var before = host.ArmyFlameProgress(entity).ToArray();
        float pausedClock = host.ObservedCooldownSeconds;
        ulong pausedTick = host.Snapshot().ServerTick;
        Require(isPaused && before.Length > 0 && !host.Terminal, "The pause fixture lost its live source burst.");
        host.Advance(hostTick + 30, host.ObservedRealTimeSeconds + 3);
        Require(host.ObservedCooldownSeconds == pausedClock && host.Snapshot().ServerTick == pausedTick &&
            host.ArmyFlameProgress(entity).SequenceEqual(before), "Reconnect wall time advanced live flame authority.");
        Require(host.Resume(Second), "The source flame fixture could not resume its participant.");
        host.Advance(hostTick + 31, host.ObservedRealTimeSeconds + 1d / MatchManifest.TickRate);
        Require(!host.Terminal && host.ObservedCooldownSeconds < pausedClock + 0.04f &&
            host.Snapshot().ServerTick == pausedTick + 1, "Flame resume consumed the paused host-time backlog.");
    }

    private static MatchEvent[] ReadFirstEvents(MatchEngine host, ref ulong cursor)
    {
        var result = new List<MatchEvent>();
        while (true)
        {
            MatchEventBatch batch = host.EventBatch(First, cursor);
            if (batch.Events.Count == 0)
            {
                return result.ToArray();
            }
            result.AddRange(batch.Events);
            cursor = batch.Events[^1].EventId;
        }
    }
}
