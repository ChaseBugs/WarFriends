using War.BattleServer;

/// <summary>Checks source waits through reservation, entity publication and Sickness callbacks.</summary>
internal static class ArmyDeploymentRealtimeStateTests
{
    private const ulong FrozenGameTick = 10;
    private const float StartedSeconds = 1f;
    private const float SourceWaitSeconds = 0.3f;

    internal static int Run(string directory)
    {
        var content = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"));
        ArmyDeploymentFamily family = content.Army.Families.Single(row => row.UnitId == "ID_UNIT-ASSAULT");
        ArmyDeploymentOption option = family.Options.Single(row => row.Count == 4);
        var state = new ArmyDeploymentState(content.Army, [family.UnitId]);
        state.SetOffers([option.Index, option.Index, option.Index]);
        int initialEnergy = state.Energy;
        Require(state.TryDeployRealtime(option.Index, FrozenGameTick, StartedSeconds) == "army-deploying" &&
            state.PendingCount == option.Count && state.Energy == initialEnergy, "Acceptance spent reserved energy.");

        ArmyDeploymentWave started = state.LastAcceptedWave!;
        ulong cooldownDeadline = state.NextDeployTick;
        var sickness = new SicknessSpawnWindow(1, content.Army);
        sickness.Arm();
        sickness.DeploymentStarted(2, started);
        Reject(() => sickness.DeploymentFinished(2, started));
        Require(sickness.IsApplying, "An unfinished wave closed Sickness.");
        Reject(() => state.Advance(FrozenGameTick));
        Reject(() => state.AdvanceRealtime(float.NaN, FrozenGameTick));

        ArmySpawn preview = state.PreviewRealtimeSpawns(StartedSeconds, FrozenGameTick).Single();
        _ = state.PreviewRealtimeSpawns(StartedSeconds + 100f, FrozenGameTick);
        Require(state.PendingCount == option.Count && state.Energy == initialEnergy,
            "A future preview changed reservations or energy.");
        ArmySpawn first = state.AdvanceRealtime(StartedSeconds, FrozenGameTick).Single();
        Require(first == preview && first.RealTimeSeconds == StartedSeconds,
            "Committed spawn differs from the nonmutating real-time preview.");
        Require(state.AdvanceRealtime(StartedSeconds + SourceWaitSeconds, FrozenGameTick).Count == 0,
            "Strict source wait advanced at equality.");

        float now = StartedSeconds + 10f;
        var spawned = new List<ArmySpawn> { first };
        for (int index = 1; index < option.Count; index++)
        {
            spawned.AddRange(state.AdvanceRealtime(now, FrozenGameTick));
            Require(state.AdvanceRealtime(now, FrozenGameTick).Count == 0,
                "A delayed frame burst through a newly constructed wait.");
            now = float.BitIncrement(now + SourceWaitSeconds);
        }
        Require(spawned.Count == option.Count && spawned.Select(row => row.EntityId).Distinct().Count() == option.Count &&
            spawned.All(row => row.Tick == FrozenGameTick && row.RealTimeSeconds.HasValue) &&
            state.PendingCount == 0 && state.Energy == initialEnergy - option.Power &&
            state.NextDeployTick == cooldownDeadline && state.CompletedWaves.Count == 0 && sickness.IsApplying,
            "Frozen gameplay time changed source iteration accounting or completed the final wait early.");

        Reject(() => state.AdvanceRealtime(StartedSeconds, FrozenGameTick));
        Require(state.AdvanceRealtime(now, FrozenGameTick).Count == 0 && state.CompletedWaves.Count == 1,
            "The final wait did not publish exactly one completion.");
        ArmyDeploymentWave completed = state.CompletedWaves.Single();
        Require(completed.StartedRealTimeSeconds == StartedSeconds && completed.FinishedRealTimeSeconds == now &&
            started.FinishedRealTimeSeconds == null, "Completion mutated the original start event.");
        Reject(() => sickness.DeploymentStarted(2, completed));
        sickness.DeploymentFinished(2, completed);
        Require(!sickness.IsArmed, "The completed definition did not close Sickness.");
        state.AdvanceRealtime(now, FrozenGameTick);
        Require(state.CompletedWaves.Count == 0, "A terminal wave published completion twice.");
        return 17 + option.Count - 1 + CheckRejectedCommit(content.Army, family, option);
    }

    private static int CheckRejectedCommit(ArmyDeploymentCatalog catalog, ArmyDeploymentFamily family,
        ArmyDeploymentOption option)
    {
        var state = new ArmyDeploymentState(catalog, [family.UnitId]);
        state.SetOffers([option.Index, option.Index, option.Index]);
        state.TryDeployRealtime(option.Index, FrozenGameTick, StartedSeconds);
        var energyProperty = typeof(ArmyDeploymentState).GetProperty(nameof(ArmyDeploymentState.Energy))!;
        int initialEnergy = state.Energy;
        energyProperty.SetValue(state, 0);

        Reject(() => state.AdvanceRealtime(StartedSeconds, FrozenGameTick));
        Require(state.PendingCount == option.Count && state.ActiveCount == 0 && state.CompletedWaves.Count == 0,
            "Failed energy preflight consumed an iteration or entity identity.");
        energyProperty.SetValue(state, initialEnergy);
        ArmySpawn recovered = state.AdvanceRealtime(StartedSeconds, FrozenGameTick).Single();
        Require(recovered.EntityId == 1 && state.PendingCount == option.Count - 1,
            "Rejected commit changed the first source deadline or entity identity.");

        var legacy = new ArmyDeploymentState(catalog, [family.UnitId]);
        legacy.SetOffers([option.Index, option.Index, option.Index]);
        legacy.TryDeploy(option.Index, FrozenGameTick);
        Reject(() => legacy.AdvanceRealtime(StartedSeconds, FrozenGameTick));
        Require(legacy.PendingCount == option.Count && legacy.ActiveCount == 0,
            "Real-time advancement consumed a legacy schedule.");
        return 5;
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (exception is InvalidDataException or
            InvalidOperationException or ArgumentOutOfRangeException)
        {
            return;
        }
        throw new InvalidOperationException("Invalid deployment transition was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
