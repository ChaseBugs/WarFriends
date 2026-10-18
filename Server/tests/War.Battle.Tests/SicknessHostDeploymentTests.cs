using War.BattleServer;
using War.Protocol;

/// <summary>Exercises source Sickness window transitions through accepted host deployment commands.</summary>
internal static class SicknessHostDeploymentTests
{
    private const int OwnerFraction = 1;
    private const int OpponentFraction = 2;
    private const string SpawnEffectId = "sickness-host-spawn-test";
    private const float SicknessMultiplier = 0.5f;
    private static readonly string OwnerId = new('a', 32);
    private static readonly string OpponentId = new('b', 32);

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        RecoveredBattleMap map = content.Maps.Single(candidate =>
            candidate.Source.EndsWith("/Park_Multiplayer.unity", StringComparison.Ordinal));
        MatchEngine host = GrenadierPrimaryDamageTests.CreateRealShotHost(content, map, _ => 0);
        var window = new SicknessSpawnWindow(OwnerFraction, content.Army);
        window.Arm();
        host.ArmyDeploymentStarted += window.DeploymentStarted;
        host.ArmyDeploymentFinished += window.DeploymentFinished;
        Dictionary<ulong, SpawnObservation> observed = ObserveSpawns(host, window);

        int checks = CheckFriendlyDeployment(host, window);
        checks += CheckOpposingDeployment(host, window, content);
        checks += CheckSpawnModifiers(host, observed);
        checks += CheckDisconnectedWindow(host, window, observed);
        checks += Require(host.UnsubscribeArmySpawn(SpawnEffectId), "The spawn observer failed to disconnect.");
        host.ArmyDeploymentStarted -= window.DeploymentStarted;
        host.ArmyDeploymentFinished -= window.DeploymentFinished;
        return checks;
    }

    private static Dictionary<ulong, SpawnObservation> ObserveSpawns(MatchEngine host, SicknessSpawnWindow window)
    {
        var observed = new Dictionary<ulong, SpawnObservation>();
        host.SubscribeArmySpawn(SpawnEffectId, key =>
        {
            BattleArmyEntityState entity = ReadEntities(host).Single(row => row.EntityKey == key);
            float damage = host.ArmyDamage(key) ??
                throw new InvalidOperationException("A source Assaulter spawned without weapon authority.");
            bool changed = host.ApplySicknessToArmyAssaulter(key, window);
            observed.Add(key, new SpawnObservation(entity, damage, changed));
        });

        return observed;
    }

    private static int CheckFriendlyDeployment(MatchEngine host, SicknessSpawnWindow window)
    {
        int option = host.ArmyBatch(OwnerId).OptionIndexes.First();
        string result = Deploy(host, OwnerId, option, 3);
        int checks = Require(result == "army-deploying", "The friendly source deployment was rejected.");
        checks += Require(window.IsArmed && !window.IsApplying,
            "A friendly accepted deployment opened the Sickness window.");
        return checks;
    }

    private static int CheckOpposingDeployment(MatchEngine host, SicknessSpawnWindow window,
        BattleCombatContent content)
    {
        int option = host.ArmyBatch(OpponentId).OptionIndexes.First();
        ArmyDeploymentWave? accepted = null;
        int starts = 0;
        int finishes = 0;
        host.ArmyDeploymentStarted += (fraction, wave) =>
        {
            if (fraction != OpponentFraction)
            {
                return;
            }

            starts++;
            accepted = wave;
            Require(CountOpposingEntities(host) == 0,
                "The source start notification ran after the first opposing spawn.");
        };
        host.ArmyDeploymentFinished += (fraction, wave) =>
        {
            if (fraction == OpponentFraction)
            {
                finishes++;
                Require(wave == accepted, "The finish callback changed the accepted definition.");
                Require(CountOpposingEntities(host) == content.Army.Option(option).Count,
                    "The source finish notification preceded its generated entities.");
            }
        };

        int checks = Require(Deploy(host, OpponentId, option, 3) == "army-deploying",
            "The opposing source deployment was rejected.");
        checks += Require(starts == 1 && accepted != null && window.IsApplying,
            "The actual opposing command did not open its source Sickness window.");
        checks += Require(Deploy(host, OpponentId, option, 4) != "army-deploying" && starts == 1,
            "A rejected deployment published another start callback.");
        checks += CheckFinalWait(host, window, accepted!, () => finishes);
        return checks;
    }

    private static int CheckFinalWait(MatchEngine host, SicknessSpawnWindow window,
        ArmyDeploymentWave accepted, Func<int> finishCount)
    {
        while (!host.Terminal && host.Snapshot().ServerTick < accepted.FinishAfterTick)
        {
            host.Advance(host.Snapshot().ServerTick + 1);
        }

        int checks = Require(!host.Terminal && window.IsApplying && finishCount() == 0,
            "The host closed Sickness at the final wait equality boundary.");
        host.Advance(accepted.FinishAfterTick + 1);
        checks += Require(!host.Terminal && !window.IsArmed && finishCount() == 1,
            "The actual final source wait did not disconnect Sickness exactly once.");
        host.Advance(accepted.FinishAfterTick + 1);
        checks += Require(finishCount() == 1, "A repeated host observation replayed the source finish callback.");
        return checks;
    }

    private static int CountOpposingEntities(MatchEngine host)
    {
        return ReadEntities(host).Count(entity => entity.OwnerFraction == OpponentFraction);
    }

    private static IReadOnlyList<BattleArmyEntityState> ReadEntities(MatchEngine host)
    {
        var entities = new List<BattleArmyEntityState>();
        ulong cursor = 0;
        MatchArmyEntityBatch page;
        do
        {
            page = host.ArmyEntityBatch(OpponentId, cursor, 0);
            entities.AddRange(page.Entities);
            if (page.Entities.Count > 0)
            {
                cursor = page.Entities[^1].EntityKey;
            }
        }
        while (page.HasMore);

        return entities;
    }

    private static int CheckSpawnModifiers(MatchEngine host, IReadOnlyDictionary<ulong, SpawnObservation> observed)
    {
        int checks = Require(observed.Count > 0, "No real host spawn reached its effect observer.");
        foreach (BattleArmyEntityState entity in ReadEntities(host))
        {
            SpawnObservation before = observed[entity.EntityKey];
            bool isEnemy = entity.OwnerFraction == OpponentFraction;
            float multiplier = isEnemy ? SicknessMultiplier : 1f;
            checks += Require(before.Changed == isEnemy, "A spawn effect changed the wrong playing fraction.");
            checks += Require(entity.MaxHealth == before.Entity.MaxHealth &&
                entity.Health == before.Entity.MaxHealth * multiplier,
                "Sickness changed maximum health or failed to refill current health from the source maximum.");
            checks += Require(host.ArmyDamage(entity.EntityKey) == before.Damage * multiplier,
                "The actual spawn callback did not scale only the opposing current weapon authority.");
        }

        return checks;
    }

    private static int CheckDisconnectedWindow(MatchEngine host, SicknessSpawnWindow window,
        IReadOnlyDictionary<ulong, SpawnObservation> observed)
    {
        ulong entityKey = observed.First(row => row.Value.Changed).Key;
        float? damage = host.ArmyDamage(entityKey);
        float? health = host.ArmyHealth(entityKey);
        int checks = Require(!host.ApplySicknessToArmyAssaulter(entityKey, window),
            "A disconnected spawn window modified an existing Assaulter.");
        checks += Require(host.ArmyDamage(entityKey) == damage && host.ArmyHealth(entityKey) == health,
            "Disconnect restored or repeatedly scaled already modified combat authority.");

        return checks;
    }

    private static string Deploy(MatchEngine host, string playerId, int option, ulong commandId)
    {
        return host.Command(playerId, new MatchCommand
        {
            CommandId = commandId,
            DeployArmy = new DeployArmyCommand { OptionIndex = option }
        }).Code;
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }

    private sealed record SpawnObservation(BattleArmyEntityState Entity, float Damage, bool Changed);
}
