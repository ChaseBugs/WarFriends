using War.BattleServer;
using War.Protocol;

/// <summary>Checks a real Corner deadline inside a volley without injecting timing or projectile state.</summary>
internal static class AssaulterDeferredPointChangeTests
{
    private const ulong MaximumTick = 1800;
    private const int CornerDelayRange = 10;
    private const int SourceCornerDelayOffset = 3;
    private const int RandomScale = 1_000_000;
    private const int TimingDraw = 200_000;
    private const ulong RoundIntervalTicks = 11;
    private static readonly string OwnerId = new('b', 32);

    internal static int Run(BattleCombatContent content)
    {
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        MatchEngine host = GrenadierPrimaryDamageTests.CreateRealShotHost(content, map, Draw);
        ulong actor = Deploy(host);
        AdvanceUntil(host, () => host.AssaulterCorner(actor) != null);
        ulong due = host.AssaulterCorner(actor)?.FirstPointChangeEligibleTick ??
            throw new InvalidOperationException("The source Corner did not initialize its timer.");
        var observedShotTicks = new HashSet<ulong>();
        ulong cursor = host.EventBatch(OwnerId, 0).LatestEventId;
        AdvanceUntil(host, () => host.Snapshot().ServerTick >= due - 1, () =>
        {
            MatchEventBatch page = host.EventBatch(OwnerId, cursor);
            foreach (MatchEvent shot in page.Events.Where(item => item.Kind == MatchEventKind.Shot &&
                host.ArmyProjectileSourceEntity(item.ProjectileId) == actor))
            {
                observedShotTicks.Add(shot.Tick);
            }

            cursor = page.LatestEventId;
        });
        AssaulterCornerAttempt attempt = host.AssaulterAttempt(actor) ??
            throw new InvalidOperationException("The fixed source timing did not acquire a volley.");
        Require(attempt is { CallbackTick: not null, CompletedTick: null },
            "The fixed source timing must overlap an actual pending volley.");
        ulong firstRound = CoopShotCallbackClock.FirstGameplayPollTick(attempt.CallbackTick ??
            throw new InvalidOperationException("The source volley lost its callback."));
        int checks = Require(observedShotTicks.Contains(firstRound),
            "The deadline fixture must observe a launched first round, not only a scheduled callback.");
        return checks + CheckPendingVolley(host, actor, attempt, due);
    }

    private static int Draw(int maximum)
    {
        if (maximum == RandomScale)
        {
            return TimingDraw;
        }

        return maximum == CornerDelayRange ? SourceCornerDelayOffset : 0;
    }

    private static ulong Deploy(MatchEngine host)
    {
        Require(host.Command(OwnerId, new MatchCommand
        {
            CommandId = 3,
            DeployArmy = new() { OptionIndex = host.ArmyBatch(OwnerId).OptionIndexes.First() }
        }).Code == "army-deploying", "The deferred change requires a normal deployment.");
        host.Advance(host.Snapshot().ServerTick + 1);
        return host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single().EntityKey;
    }

    private static int CheckPendingVolley(MatchEngine host, ulong actor, AssaulterCornerAttempt attempt, ulong due)
    {
        CardUnitInitialPoint original = host.AssaulterPoint(actor) ??
            throw new InvalidOperationException("The active volley lost its source Corner.");
        BattleArmyEntityState other = host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(row =>
            row.EntityKey != actor);
        Require(host.ConfirmArmyDeath(other.EntityKey, false), "The alternate destination did not release.");
        ulong firstRound = CoopShotCallbackClock.FirstGameplayPollTick(attempt.CallbackTick ??
            throw new InvalidOperationException("The active volley lost its callback."));
        ulong finalRound = firstRound + (ulong)(attempt.Batch.Count - 1) * RoundIntervalTicks;
        int checks = Require(firstRound < due && finalRound > due,
            $"The source change deadline {due} must fall between actual rounds {firstRound} and {finalRound}.");
        ulong cursor = host.EventBatch(OwnerId, 0).LatestEventId;
        while (host.Snapshot().ServerTick < finalRound - 1)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            Require(!host.Terminal, "The deferred active volley aborted the match.");
            checks += Require(host.AssaulterPoint(actor) == original && host.AssaulterAttempt(actor) == attempt,
                "The expired point-change timer interrupted an active source volley.");
        }

        host.Advance(finalRound);
        MatchEvent shot = host.EventBatch(OwnerId, cursor).Events.Single(item => item.Kind == MatchEventKind.Shot &&
            item.Tick == finalRound && host.ArmyProjectileSourceEntity(item.ProjectileId) == actor);
        checks += Require(!host.Terminal && host.AssaulterPoint(actor)?.ComponentFileId != original.ComponentFileId &&
            host.AssaulterCorner(actor) == null && host.AssaulterAttempt(actor) == null,
            "The source final-round tick did not finish shooting and transfer its expired Corner reservation.");
        checks += Require(host.ArmyProjectileLaunch(shot.ProjectileId) != null &&
            host.ArmyEntityBatch(OwnerId, 0, 0).Entities.Single(row => row.EntityKey == actor).InfantryClip == "run_0",
            "Point transfer removed the last airborne bullet or failed to enter walking.");
        Console.WriteLine($"PASS: expired Corner change waits through the volley and transfers on tick {finalRound}.");
        return checks;
    }

    private static void AdvanceUntil(MatchEngine host, Func<bool> predicate, Action? observe = null)
    {
        while (!host.Terminal && host.Snapshot().ServerTick < MaximumTick && !predicate())
        {
            host.Advance(host.Snapshot().ServerTick + 1);
            observe?.Invoke();
        }

        Require(!host.Terminal && predicate(),
            "The deferred point-change fixture stopped before its source condition.");
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
