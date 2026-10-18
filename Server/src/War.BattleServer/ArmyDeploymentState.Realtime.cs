namespace War.BattleServer;

public sealed partial class ArmyDeploymentState
{
    private const ulong MaximumSimulationTick = 10_000_000;
    private readonly Dictionary<ulong, RealtimeWave> _realtimeWaves = [];
    private float _lastRealtimeSeconds;
    private float _lastCooldownSeconds;

    internal float NextCooldownSeconds { get; private set; }

    /// <summary>Projects remaining source time onto the existing Client's relative tick countdown.</summary>
    internal ulong ProjectNextDeployTick(ulong simulationTick, float cooldownSeconds)
    {
        BattleRealtime.Validate(cooldownSeconds, _lastCooldownSeconds);
        if (LastAcceptedWave == null)
        {
            return 0;
        }
        float remaining = Math.Max(0f, NextCooldownSeconds - cooldownSeconds);
        return checked(simulationTick + (ulong)Math.Ceiling((double)remaining * MatchManifest.TickRate));
    }

    private int RealtimePendingCount => checked(_realtimeWaves.Values.Sum(wave => wave.Routine.RemainingIterations));

    private int RealtimePendingPower => checked(_realtimeWaves.Values.Sum(wave =>
        checked(wave.Routine.RemainingIterations * (wave.Option.Power / wave.Option.Count))));

    private int RealtimeRusherDemand => checked(_realtimeWaves.Values
        .Where(wave => ArmyRusherPointCatalog.IsRusher(wave.Family.BehaviorType))
        .Sum(wave => wave.Routine.RemainingIterations));

    private int RealtimeRouteDemand(string collection)
    {
        return checked(_realtimeWaves.Values.Where(wave => !wave.Family.IsSoldier &&
            wave.Family.BehaviorType != "MechBehaviour" &&
            ArmySpawnPointSelector.Collection(wave.Family.BehaviorType) == collection)
            .Sum(wave => wave.Routine.RemainingIterations));
    }

    /// <summary>Accepts a source coroutine without projecting its real-time waits into gameplay ticks.</summary>
    internal string TryDeployRealtime(int optionIndex, float cooldownSeconds, float realTimeSeconds)
    {
        RequireRealtimeSchedule();
        BattleRealtime.Validate(realTimeSeconds, _lastRealtimeSeconds);
        BattleRealtime.Validate(cooldownSeconds, _lastCooldownSeconds);
        if (!offered.Contains(optionIndex))
        {
            return "army-not-offered";
        }
        ArmyDeploymentFamily family = FindFamily(optionIndex);
        ArmyDeploymentOption option = catalog.Option(optionIndex);
        string? rejection = GetDeploymentRejection(family, option, cooldownSeconds < NextCooldownSeconds);
        if (rejection != null)
        {
            return rejection;
        }
        AcceptRealtimeWave(family, option, cooldownSeconds, realTimeSeconds);
        return "army-deploying";
    }

    private void AcceptRealtimeWave(ArmyDeploymentFamily family, ArmyDeploymentOption option,
        float cooldownSeconds, float realTimeSeconds)
    {
        float cooldown = (catalog.BaseCooldown + option.Cooldown) * cooldownMultiplier;
        float nextDeploy = cooldownSeconds + cooldown;
        if (!float.IsFinite(nextDeploy) || nextDeploy < cooldownSeconds)
        {
            throw new InvalidDataException("Source deployment cooldown exceeds the float time domain.");
        }
        int nextReserved = checked(reserved.GetValueOrDefault(family.UnitId) + option.Count);
        ulong waveId = checked(_nextWaveId + 1);
        var wave = new ArmyDeploymentWave(waveId, option.Index, family.UnitId, 0)
        {
            IsSoldier = family.IsSoldier,
            StartedRealTimeSeconds = realTimeSeconds
        };
        wave.ValidateClockShape();
        var routine = new ArmyDeploymentRealtimeRoutine(option.Count, realTimeSeconds);
        _activeWaves.Add(waveId, wave);
        _realtimeWaves.Add(waveId, new RealtimeWave(wave, family, option, routine));
        _nextWaveId = waveId;
        LastAcceptedWave = wave;
        reserved[family.UnitId] = nextReserved;
        NextCooldownSeconds = nextDeploy;
        _lastCooldownSeconds = cooldownSeconds;
        _lastRealtimeSeconds = realTimeSeconds;
        InvalidateOffers();
    }

    /// <summary>Previews actual ready iterations without spending energy or changing either source wait.</summary>
    internal IReadOnlyList<ArmySpawn> PreviewRealtimeSpawns(float realTimeSeconds, ulong simulationTick)
    {
        RealtimeWave[] ready = ReadyRealtimeWaves(realTimeSeconds, simulationTick);
        return PreviewSpawns(ready.Where(wave => wave.Routine.Preview(realTimeSeconds) ==
            ArmyDeploymentRealtimeRoutine.Step.SpawnIteration).Select(wave =>
            (simulationTick, wave.Family, wave.Option, wave.Wave.Id)))
            .Select(spawn => spawn with { RealTimeSeconds = realTimeSeconds }).ToArray();
    }

    /// <summary>Commits at most one iteration per ready wave, then publishes actual final-wait completion.</summary>
    internal IReadOnlyList<ArmySpawn> AdvanceRealtime(float realTimeSeconds, ulong simulationTick)
    {
        RealtimeWave[] ready = ReadyRealtimeWaves(realTimeSeconds, simulationTick);
        RealtimeWave[] iterations = ready.Where(wave => wave.Routine.Preview(realTimeSeconds) ==
            ArmyDeploymentRealtimeRoutine.Step.SpawnIteration).ToArray();
        RealtimeWave[] completed = ready.Where(wave => wave.Routine.Preview(realTimeSeconds) ==
            ArmyDeploymentRealtimeRoutine.Step.Finished).ToArray();
        _ = PreviewSpawns(iterations.Select(wave => (simulationTick, wave.Family, wave.Option, wave.Wave.Id)));

        var spawned = new List<ArmySpawn>();
        foreach (RealtimeWave wave in iterations)
        {
            spawned.Add(CommitSpawn((simulationTick, wave.Family, wave.Option, wave.Wave.Id), realTimeSeconds));
            wave.Routine.CommitIteration(realTimeSeconds);
        }
        _completedWaves = CompleteRealtimeWaves(completed, realTimeSeconds);
        _lastRealtimeSeconds = realTimeSeconds;
        return spawned.AsReadOnly();
    }

    private IReadOnlyList<ArmyDeploymentWave> CompleteRealtimeWaves(RealtimeWave[] waves, float realTimeSeconds)
    {
        var completed = new List<ArmyDeploymentWave>();
        foreach (RealtimeWave wave in waves)
        {
            wave.Routine.CommitFinished(realTimeSeconds);
            completed.Add(wave.Wave with { FinishedRealTimeSeconds = realTimeSeconds });
            _activeWaves.Remove(wave.Wave.Id);
            _realtimeWaves.Remove(wave.Wave.Id);
        }
        return completed.AsReadOnly();
    }

    private RealtimeWave[] ReadyRealtimeWaves(float realTimeSeconds, ulong simulationTick)
    {
        RequireRealtimeSchedule();
        BattleRealtime.Validate(realTimeSeconds, _lastRealtimeSeconds);
        if (simulationTick > MaximumSimulationTick)
        {
            throw new ArgumentOutOfRangeException(nameof(simulationTick));
        }
        foreach (RealtimeWave wave in _realtimeWaves.Values)
        {
            if (!_activeWaves.TryGetValue(wave.Wave.Id, out ArmyDeploymentWave? active) || active != wave.Wave)
            {
                throw new InvalidDataException("A real-time deployment lost its active wave identity.");
            }
            active.ValidateClockShape();
        }
        return _realtimeWaves.Values.Where(wave => wave.Routine.Preview(realTimeSeconds) !=
            ArmyDeploymentRealtimeRoutine.Step.None).OrderBy(wave => wave.Routine.DeadlineSeconds)
            .ThenBy(wave => wave.Wave.Id).ToArray();
    }

    private void RequireLegacySchedule()
    {
        if (LastAcceptedWave?.StartedRealTimeSeconds.HasValue == true)
        {
            throw new InvalidOperationException("Active real-time deployments cannot be advanced by legacy ticks.");
        }
    }

    private void RequireRealtimeSchedule()
    {
        if (LastAcceptedWave != null && !LastAcceptedWave.StartedRealTimeSeconds.HasValue)
        {
            throw new InvalidOperationException("Active legacy deployments cannot be advanced as real-time coroutines.");
        }
    }

    private sealed record RealtimeWave(ArmyDeploymentWave Wave, ArmyDeploymentFamily Family,
        ArmyDeploymentOption Option, ArmyDeploymentRealtimeRoutine Routine);
}
