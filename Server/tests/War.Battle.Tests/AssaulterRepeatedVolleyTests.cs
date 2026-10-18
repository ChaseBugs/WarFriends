using War.BattleServer;
using War.Protocol;

/// <summary>Follows one ordinary soldier through repeated volleys and the strict hide boundary.</summary>
internal static class AssaulterRepeatedVolleyTests
{
    private const ulong MaximumTick = 1800;
    private const int VolleyCount = 3;
    private static readonly string OwnerId = new('b', 32);

    internal static int Run(BattleCombatContent content)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        MatchEngine host = GrenadierPrimaryDamageTests.CreateRealShotHost(content, map, _ => 0);
        int option = host.ArmyBatch(OwnerId).OptionIndexes.First();
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3,
            DeployArmy = new() { OptionIndex = option }
        }).Code == "army-deploying", "Repeated volleys require an accepted ordinary deployment.");
        host.Advance(host.Snapshot().ServerTick + 1);
        ulong actor = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey;
        ArmyBaseShotStats source = content.Army.ComposeShot("ID_UNIT-ASSAULT", 0, null, null, 1f);
        int checks = 0;
        ulong? expectedPreparation = null;
        for (int volleyIndex = 0; volleyIndex < VolleyCount; volleyIndex++)
        {
            ulong eventCursor = host.EventBatch(OwnerId, 0).LatestEventId;
            AdvanceUntil(host, () => host.AssaulterAttempt(actor) is { CompletedTick: null, CallbackTick: not null });
            AssaulterCornerAttempt started = Attempt(host, actor);
            if (expectedPreparation.HasValue)
            {
                checks += Require(started.Aim.AcquisitionTick == expectedPreparation,
                    "The next automatic preparation missed the cooldown derived at the last round.");
            }

            AdvanceUntil(host, () => host.AssaulterAttempt(actor)?.CompletedTick != null);
            AssaulterCornerAttempt completed = Attempt(host, actor);
            ulong lastRound = completed.CompletedTick ??
                throw new InvalidOperationException("The live volley did not record completion.");
            ulong cooldown = (ulong)MathF.Floor(source.MinShootTime * MatchManifest.TickRate) + 1;
            expectedPreparation = lastRound + cooldown;
            checks += Require(completed.NextShotEligibleTick == expectedPreparation &&
                completed.Aim.AcquisitionTick == started.Aim.AcquisitionTick,
                "Completing the source batch lost its latch or regenerated cooldown.");
            checks += CheckRounds(host, actor, eventCursor, completed);
            checks += CheckHideBoundary(host, actor, lastRound);
            checks += CheckIdleReturn(host, actor, content, expectedPreparation.Value);
            AdvanceTo(host, expectedPreparation.Value - 1);
            checks += Require(host.AssaulterAttempt(actor) == completed,
                "A new attempt replaced the completed source latch before its strict deadline.");
            host.Advance(expectedPreparation.Value);
        }

        checks += Require(!host.Terminal && host.AssaulterCallback(actor) != null,
            "Repeated live volleys aborted the match or lost their callback state.");
        Console.WriteLine($"PASS: {VolleyCount} automatic Assaulter volleys and strict hide/cooldown boundaries.");
        return checks;
    }

    private static int CheckRounds(MatchEngine host, ulong actor, ulong cursor, AssaulterCornerAttempt attempt)
    {
        MatchEvent[] rounds = host.EventBatch(OwnerId, cursor).Events.Where(item =>
            item.Kind == MatchEventKind.Shot && host.ArmyProjectileSourceEntity(item.ProjectileId) == actor)
            .ToArray();
        ulong firstRound = CoopShotCallbackClock.FirstGameplayPollTick(attempt.CallbackTick ??
            throw new InvalidOperationException("The repeated volley lost its callback deadline."));
        int checks = Require(rounds.Length == attempt.Batch.Count,
            "A repeated volley completed without launching its full source batch.");
        checks += Require(rounds.Select(round => round.Tick).SequenceEqual(
            Enumerable.Range(0, attempt.Batch.Count).Select(index => firstRound + (ulong)index * 11)),
            "A repeated volley changed its first-poll or strict source round cadence.");
        return checks;
    }

    private static int CheckIdleReturn(MatchEngine host, ulong actor, BattleCombatContent content, ulong nextAttempt)
    {
        string cover = Entity(host, actor).InfantryClip;
        float coverSeconds = content.EnemyPoses.Clip(cover).Length;
        ulong hideTick = host.Snapshot().ServerTick;
        ulong idleTick = hideTick + (ulong)MathF.Ceiling(coverSeconds * MatchManifest.TickRate);
        Require(idleTick < nextAttempt, "The fixed fixture must allow the source cover-back clip to finish.");
        AdvanceTo(host, idleTick - 1);
        int checks = Require(Entity(host, actor).InfantryClip == cover,
            "The soldier left cover-back before its source clip finished.");
        host.Advance(idleTick);
        checks += Require(Entity(host, actor).InfantryClip == "idle_1",
            "The completed source cover-back clip did not return to queued idle.");
        return checks;
    }

    private static AssaulterCornerAttempt Attempt(MatchEngine host, ulong actor)
    {
        return host.AssaulterAttempt(actor) ??
            throw new InvalidOperationException("The ordinary soldier lost its source attempt.");
    }

    private static int CheckHideBoundary(MatchEngine host, ulong actor, ulong lastRound)
    {
        CardUnitInitialPoint point = host.AssaulterPoint(actor) ??
            throw new InvalidOperationException("Repeated firing lost its Corner reservation.");
        bool isRightSide = point.CornerRightSide ??
            throw new InvalidOperationException("Repeated firing lost its source side.");
        string fire = isRightSide ? "player_fire_right3" : "player_fire_left3";
        string cover = isRightSide ? "player_right_coverBack3" : "player_left_coverBack3";
        AdvanceTo(host, lastRound + MatchManifest.TickRate / 2);
        int checks = Require(Entity(host, actor).InfantryClip == fire,
            "The strict half-second source hide boundary returned to cover one tick early.");
        host.Advance(host.Snapshot().ServerTick + 1);
        checks += Require(Entity(host, actor).InfantryClip == cover,
            "The first tick beyond the source hide deadline did not enter cover-back.");
        return checks;
    }

    private static BattleArmyEntityState Entity(MatchEngine host, ulong actor)
    {
        return host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(entity => entity.EntityKey == actor);
    }

    private static void AdvanceUntil(MatchEngine host, Func<bool> predicate)
    {
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && !predicate())
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        Require(!host.Terminal && predicate(),
            $"The repeated volley fixture stopped at {host.Snapshot().ServerTick}: {host.Snapshot().TerminalReason}.");
    }

    private static void AdvanceTo(MatchEngine host, ulong target)
    {
        AdvanceUntil(host, () => host.Snapshot().ServerTick >= target);
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }
}
