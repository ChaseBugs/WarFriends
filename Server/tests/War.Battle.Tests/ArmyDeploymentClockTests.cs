using War.BattleServer;

/// <summary>Separates real-time queued spawns from source cooldown time that stops during pause.</summary>
internal static class ArmyDeploymentClockTests
{
    private const ulong FrozenCooldownTick = 10;
    private const ulong FirstRealTick = 100;
    private const ulong SourceSpawnIntervalTicks = 9;

    internal static int Run(string directory)
    {
        var content = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"));
        ArmyDeploymentFamily family = content.Army.Families.Single(row => row.UnitId == "ID_UNIT-ASSAULT");
        ArmyDeploymentOption large = family.Options.Single(option => option.Count == 4);
        ArmyDeploymentOption small = family.Options.Single(option => option.Count == 2);
        var state = new ArmyDeploymentState(content.Army, [family.UnitId]);
        state.SetOffers([large.Index, large.Index, large.Index]);
        Require(state.TryDeploy(large.Index, FrozenCooldownTick, FirstRealTick) == "army-deploying",
            "Independent source clock fixture could not accept its initial wave.");
        ulong cooldownDeadline = state.NextDeployTick;
        ArmyDeploymentWave wave = state.LastAcceptedWave!;
        Require(state.Advance(FirstRealTick).Single().Tick == FirstRealTick,
            "The first queued unit used the frozen cooldown clock as its spawn clock.");
        var later = new List<ArmySpawn>();
        for (ulong index = 1; index < (ulong)large.Count; index++)
        {
            later.AddRange(state.Advance(FirstRealTick + index * SourceSpawnIntervalTicks));
        }
        Require(later.Count == large.Count - 1 && state.PendingCount == 0 &&
            state.ActiveCount == large.Count && state.NextDeployTick == cooldownDeadline,
            "Real-time spawning stopped with cooldown time or changed the cooldown deadline.");
        Require(state.Advance(wave.FinishAfterTick).Count == 0 && state.CompletedWaves.Count == 0,
            "The source final real-time wait completed at equality.");
        state.Advance(wave.FinishAfterTick + 1);
        Require(state.CompletedWaves.SequenceEqual([wave]),
            "The source final wait did not complete after its real-time boundary.");
        state.SetOffers([small.Index, small.Index, small.Index]);
        Require(state.TryDeploy(small.Index, FrozenCooldownTick, wave.FinishAfterTick + 1) == "army-cooldown" &&
            state.PendingCount == 0 && state.LastAcceptedWave == wave,
            "Real-time completion incorrectly expired the frozen cooldown.");
        ulong secondRealTick = wave.FinishAfterTick + 1 + cooldownDeadline - FrozenCooldownTick;
        Require(state.TryDeploy(small.Index, cooldownDeadline, secondRealTick) == "army-deploying" &&
            state.LastAcceptedWave!.StartedTick == secondRealTick,
            "A resumed cooldown scheduled its next wave in the wrong clock domain.");
        Require(state.PreviewDueSpawns(secondRealTick - 1).Count == 0,
            "A future real-time reservation was admitted using its earlier cooldown timestamp.");
        return 8 + CheckReversedClocks(content.Army, family, large);
    }

    private static int CheckReversedClocks(ArmyDeploymentCatalog catalog, ArmyDeploymentFamily family,
        ArmyDeploymentOption option)
    {
        var state = new ArmyDeploymentState(catalog, [family.UnitId]);
        state.SetOffers([option.Index, option.Index, option.Index]);
        int energy = state.Energy;
        bool rejected = false;
        try
        {
            state.TryDeploy(option.Index, FirstRealTick, FrozenCooldownTick);
        }
        catch (InvalidDataException)
        {
            rejected = true;
        }
        Require(rejected && state.Energy == energy && state.PendingCount == 0 && state.NextDeployTick == 0 &&
            state.LastAcceptedWave == null && state.OfferedOptions.Count == 3,
            "Reversed source clock domains changed deployment authority before rejection.");
        return 1;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
