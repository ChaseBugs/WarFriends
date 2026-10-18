using System.Numerics;

using War.BattleServer;
using War.Protocol;

/// <summary>Checks source batch construction and automatic normal Corner preparation from real host time.</summary>
internal static class AssaulterPreparationTests
{
    private const ulong MaximumArrivalTick = 1800;
    private const int MaximumVolleyRounds = 14;
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(string directory)
    {
        int checks = CheckBatchRules();
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        foreach (PreparationScenario scenario in Enum.GetValues<PreparationScenario>())
        {
            checks += CheckHost(content, scenario);
        }
        return checks;
    }

    private static int CheckBatchRules()
    {
        var definition = new ArmyBaseShotStats(0.5f, 2, 5, 2f, 4f);
        var order = new List<string>();
        float[] rolls = [0.25f, 0.75f, 0.49f, 0.5f];
        int cursor = 0;
        CoopInfantryShotBatch batch = AssaulterShotBatchPolicy.Create(definition, count =>
        {
            Require(count == 3, "The source exclusive batch range changed.");
            order.Add("batch");
            return 2;
        }, () =>
        {
            order.Add("round");
            return rolls[cursor++];
        });
        int checks = Require(batch == new CoopInfantryShotBatch(4, 5),
            "The source batch lost its exclusive maximum or strict real-shot probability comparison.");
        checks += Require(order.SequenceEqual(["batch", "round", "round", "round", "round"]),
            "Real/fake rolls preceded the source batch-size choice.");
        CoopInfantryShotBatch capped = AssaulterShotBatchPolicy.Create(definition with
        {
            FireBatchSizeMin = 15, FireBatchSizeMax = 64, ProbabilityOfRealShot = 2f
        }, _ => 48, () => 0.99f);
        checks += Require(capped == new CoopInfantryShotBatch(MaximumVolleyRounds, (1 << MaximumVolleyRounds) - 1),
            "A valid large upgrade batch was rejected instead of receiving the source fourteen-round clamp.");
        checks += Reject(() => AssaulterShotBatchPolicy.Create(definition, _ => 3, () => 0f));
        checks += Reject(() => AssaulterShotBatchPolicy.Create(definition, _ => 0, () => float.NaN));
        checks += Reject(() => AssaulterShotBatchPolicy.Create(
            definition with { FireBatchSizeMin = 0 }, _ => 0, () => 0f));
        return checks;
    }

    private static int CheckHost(BattleCombatContent content, PreparationScenario scenario)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        MatchEngine host = GrenadierPrimaryDamageTests.CreateRealShotHost(content, map, _ => 0);
        int option = host.ArmyBatch(OpponentId).OptionIndexes.First();
        Require(host.Command(OpponentId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The preparation fixture failed its real normal deployment.");
        host.Advance(61);
        ulong actor = host.ArmyEntityBatch(OpponentId, 0, 0).Entities.Single().EntityKey;
        while (!host.Terminal && host.AssaulterCorner(actor) == null &&
            host.Snapshot().ServerTick < MaximumArrivalTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        ulong eligible = host.AssaulterCorner(actor)?.FirstShotEligibleTick ??
            throw new InvalidOperationException("The normal actor did not acquire a source Corner shot clock.");
        AdvanceTo(host, eligible - 1);
        int checks = Require(host.AssaulterAttempt(actor) == null,
            "The host attempted Corner preparation before the source strict deadline.");
        if (scenario == PreparationScenario.LateOpposingUnit)
        {
            DeployLateOpponent(host);
        }
        host.Advance(eligible);
        AssaulterCornerAttempt attempt = host.AssaulterAttempt(actor) ??
            throw new InvalidOperationException("The actual host tick did not automatically prepare a source attempt.");
        checks += Require(attempt.Aim.ActorEntityKey == actor && attempt.Aim.AcquisitionTick == eligible,
            "The automatic attempt lost its source actor or actual eligible tick.");
        checks += Require(attempt.CallbackTick.HasValue == (scenario == PreparationScenario.Player),
            "The fixed source player/unit geometry did not exercise its expected Corner acceptance branch.");
        checks += CheckAttempt(content, host, actor, attempt);
        checks += CheckNextTransition(host, actor, attempt);
        checks += Require(host.ConfirmArmyDeath(actor, false) && host.AssaulterAttempt(actor) == null,
            "A dead normal Assaulter retained a pending source attempt.");
        Console.WriteLine($"PASS: automatic Assaulter {scenario} attempt tick {eligible}, " +
            $"exposed={attempt.CallbackTick.HasValue}.");
        return checks;
    }

    private static int CheckAttempt(BattleCombatContent content, MatchEngine host, ulong actor,
        AssaulterCornerAttempt attempt)
    {
        ArmyBaseShotStats source = content.Army.ComposeShot("ID_UNIT-ASSAULT", 0, null, null, 1f);
        int count = Math.Min(source.FireBatchSizeMin, MaximumVolleyRounds);
        int checks = Require(attempt.Batch.Count == count && attempt.Batch.RealShotMask == (1 << count) - 1,
            "The real automatic attempt did not retain its source batch and pre-rolled real flags.");
        ulong expectedNext = attempt.Aim.AcquisitionTick +
            (ulong)MathF.Floor(source.MinShootTime * MatchManifest.TickRate) + 1;
        checks += Require(attempt.NextShotEligibleTick == expectedNext,
            "Preparation did not reschedule the source next-shot deadline.");
        CardUnitInitialPoint point = host.AssaulterPoint(actor) ??
            throw new InvalidOperationException("The source attempt lost its shared Corner.");
        var entity = host.ArmyEntityBatch(OpponentId, 0, 0).Entities.Single(row => row.EntityKey == actor);
        Vector3 direction = point.CornerDirection ??
            throw new InvalidOperationException("The source attempt lost its Corner direction.");
        bool isRightSide = point.CornerRightSide ??
            throw new InvalidOperationException("The source attempt lost its Corner side.");
        bool canExpose = CornerShotPolicy.CanExpose(direction, isRightSide,
            new(entity.X, entity.Y, entity.Z), attempt.Aim.TargetPosition);
        checks += Require(attempt.CallbackTick.HasValue == canExpose,
            "The source Corner side/angle gate did not control callback preparation.");
        if (attempt.CallbackTick.HasValue)
        {
            ulong callback = CoopShotCallbackClock.CallbackTick(attempt.Aim.AcquisitionTick,
                content.EnemyPoses.Clip("player_look_right3").Length);
            checks += Require(attempt.CallbackTick == callback,
                "The automatic callback plan lost source right-look length plus 0.05 seconds.");
        }

        return checks;
    }

    private static int CheckNextTransition(MatchEngine host, ulong actor, AssaulterCornerAttempt attempt)
    {
        if (attempt.CallbackTick.HasValue)
        {
            Require(host.Command(OwnerId, new MatchCommand
            {
                CommandId = 3, MoveCover = new() { Direction = 1 }
            }).Code == "moving", "The latch fixture failed actual player movement.");
            AdvanceTo(host, host.Snapshot().ServerTick + 2);
            return Require(host.AssaulterAttempt(actor) == attempt,
                "Later player movement replaced an already prepared source attempt.");
        }

        AdvanceTo(host, attempt.NextShotEligibleTick - 1);
        int checks = Require(host.AssaulterAttempt(actor) == attempt,
            "A rejected Corner side retried before its source cooldown.");
        host.Advance(attempt.NextShotEligibleTick);
        checks += Require(host.AssaulterAttempt(actor)?.Aim.AcquisitionTick == attempt.NextShotEligibleTick,
            "A rejected Corner side did not retry at its source next-shot tick.");
        return checks;
    }

    private static void DeployLateOpponent(MatchEngine host)
    {
        // This source spawn is behind the chosen Corner's exposed side. It is
        // selected before player fallback, making the actual side test reject.
        int option = host.ArmyBatch(OwnerId).OptionIndexes.First();
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3, DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "The source side-rejection fixture failed its opposing deployment.");
    }

    private static void AdvanceTo(MatchEngine host, ulong tick)
    {
        while (!host.Terminal && host.Snapshot().ServerTick < tick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        Require(!host.Terminal, $"The actual preparation host ended: {host.Snapshot().TerminalReason}.");
    }

    private static int Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return 1;
        }

        throw new InvalidOperationException("Malformed Assaulter batch authority was accepted.");
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }

    private enum PreparationScenario
    {
        Player,
        LateOpposingUnit
    }
}
