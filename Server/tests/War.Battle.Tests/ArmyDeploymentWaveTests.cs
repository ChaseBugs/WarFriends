using War.BattleServer;

/// <summary>Checks source deployment identities, final waits, and overlapping coroutine order.</summary>
internal static class ArmyDeploymentWaveTests
{
    private const int IntervalTicks = 9;

    internal static int Run(string directory)
    {
        var content = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"));
        var family = content.Army.Families.Single(row => row.UnitId == "ID_UNIT-ASSAULT");
        ArmyDeploymentOption large = family.Options.Single(option => option.Count == 4);
        ArmyDeploymentOption small = family.Options.Single(option => option.Count == 2);
        var state = new ArmyDeploymentState(content.Army, [family.UnitId]);
        state.SetCooldownMultiplier(0.1f);
        state.SetOffers([large.Index, large.Index, large.Index]);
        Require(state.TryDeploy(large.Index, 0) == "army-deploying", "First source wave was rejected.");
        ArmyDeploymentWave first = state.LastAcceptedWave!;
        Require(first.Id == 1 && first.StartedTick == 0 && first.FinishAfterTick == (ulong)large.Count * IntervalTicks &&
            first.IsSoldier && first.OptionIndex == large.Index, "First wave lost its source lifecycle identity.");
        int energyBeforePreview = state.Energy;
        int pendingBeforePreview = state.PendingCount;
        IReadOnlyList<ArmySpawn> firstPreview = state.PreviewDueSpawns(0);
        IReadOnlyList<ArmySpawn> futurePreview = state.PreviewDueSpawns(IntervalTicks);
        Require(firstPreview.Count == 1 && futurePreview.Count == 2 &&
            state.Energy == energyBeforePreview && state.PendingCount == pendingBeforePreview &&
            state.ActiveCount == 0 && state.CompletedWaves.Count == 0 && state.LastAcceptedWave == first,
            "Read-only preflight consumed energy, queue entries, actor IDs or deployment lifecycle state.");
        Require(state.PreviewDueSpawns(0).SequenceEqual(firstPreview),
            "A repeated preflight changed the expected actor identity.");
        Require(state.Advance(0).SequenceEqual(firstPreview),
            "The committed spawn differs from its non-mutating preflight.");
        Require(state.Advance(IntervalTicks).Single() == futurePreview[1],
            "A future preview consumed an actor ID or changed the second source wait.");
        state.SetOffers([small.Index, small.Index, small.Index]);
        Require(state.TryDeploy(small.Index, 1) == "army-cooldown" && state.LastAcceptedWave == first,
            "A rejected deployment changed source wave authority.");
        ulong start = state.NextDeployTick;
        Require(start == 15 && state.TryDeploy(small.Index, start) == "army-deploying",
            "The overlap fixture did not accept its second source wave.");
        ArmyDeploymentWave second = state.LastAcceptedWave!;
        Require(second.Id == 2 && state.ActiveWaves.Count == 2 && second.FinishAfterTick == start +
            (ulong)small.Count * IntervalTicks, "Overlapping waves lost their independent finish clocks.");
        ArmySpawn early = state.Advance(start).Single();
        Require(early.Tick == start && early.OptionIndex == small.Index && state.WaveOf(early.EntityId) == second,
            "A later wave's due unit was blocked behind an earlier wave's future units.");
        state.Advance(18);
        state.Advance(24);
        state.Advance(27);
        Require(state.PendingCount == 0 && state.ActiveWaves.Count == 2,
            "The final generated entity incorrectly ended its deployment before the source wait.");
        state.Advance(second.FinishAfterTick);
        Require(state.CompletedWaves.Count == 0 && state.ActiveWaves.Count == 2,
            "Source WaitForRealSeconds completed at equality instead of strictly after its boundary.");
        state.Advance(second.FinishAfterTick + 1);
        Require(state.CompletedWaves.SequenceEqual([second]) && state.ActiveWaves.SequenceEqual([first]),
            "Completion order followed acceptance order instead of the source finish clock.");
        state.Advance(first.FinishAfterTick + 1);
        Require(state.CompletedWaves.SequenceEqual([first]) && state.ActiveWaves.Count == 0 &&
            state.WaveOf(early.EntityId) == second, "Finished waves lost live entity provenance.");
        state.Advance(first.FinishAfterTick + 1);
        Require(state.CompletedWaves.Count == 0, "A repeated advance published a completion twice.");
        state.RemoveEntity(early.EntityId);
        Require(state.WaveOf(early.EntityId) == null, "Removed entities retained source wave ownership.");
        return 16 + ArmySpawnPreflightTests.Run(directory) + ArmyDeploymentClockTests.Run(directory);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
