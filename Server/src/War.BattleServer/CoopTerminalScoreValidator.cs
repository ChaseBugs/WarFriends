using War.Protocol;

namespace War.BattleServer;

/// <summary>
/// Checks terminal co-op score rows against a signed allocation and reviewed
/// mission rule. This does not prove projectile hits or authorize settlement.
/// </summary>
internal static class CoopTerminalScoreValidator
{
    internal static void ValidateSuccess(
        MatchSnapshot snapshot, MatchManifest allocation,
        MissionCatalog missions, CoopEnemyCombatCatalog combat)
    {
        ArgumentNullException.ThrowIfNull(snapshot);
        ArgumentNullException.ThrowIfNull(missions);
        ArgumentNullException.ThrowIfNull(combat);
        MatchManifest manifest = MatchManifest.Validate(allocation);
        if (manifest.Mode != MatchManifest.CoopMissionMode ||
            !manifest.MissionIndex.HasValue ||
            manifest.CatalogRevision != missions.SourceSha256 ||
            snapshot.MatchId != manifest.MatchId ||
            snapshot.ManifestHash != manifest.Digest() ||
            snapshot.Coop == null ||
            snapshot.Phase != BattlePhase.Ended ||
            snapshot.TerminalReason != "mission-success" ||
            snapshot.RewardEligible || snapshot.WinnerPlayerId.Length != 0 ||
            snapshot.EndTick != snapshot.ServerTick ||
            snapshot.ServerTick > 10_000_000 ||
            snapshot.StartTick > 10_000_000 ||
            !snapshot.Coop.Started || !snapshot.Coop.Completed ||
            snapshot.Coop.Failed)
            throw new InvalidDataException("Invalid co-op success envelope.");

        MissionRule rule = missions.Get(manifest.MissionIndex.Value);
        ulong durationTicks = checked((ulong)rule.TimeSeconds *
            MatchManifest.TickRate);
        if (manifest.DurationSeconds != rule.TimeSeconds ||
            snapshot.Coop.MissionIndex != rule.Index ||
            snapshot.Coop.MissionType != rule.MissionType ||
            snapshot.Coop.ObjectiveTarget != rule.Objective.GetValueOrDefault() ||
            snapshot.Coop.ObjectiveScore is < 0 or > 1_000_000_000 ||
            (rule.MissionType == "Score"
                ? snapshot.Coop.ObjectiveScore < rule.Objective.GetValueOrDefault()
                : snapshot.Coop.ObjectiveScore != 0) ||
            snapshot.Coop.DeadlineTick != snapshot.StartTick + durationTicks ||
            snapshot.EndTick < snapshot.StartTick ||
            snapshot.Players.Count != 2 ||
            snapshot.Coop.ParticipantIds.Count != 2 ||
            !snapshot.Coop.ParticipantIds.SequenceEqual(
                manifest.Players.Select(player => player.PlayerId)
                    .Order(StringComparer.Ordinal)))
            throw new InvalidDataException("Co-op success differs from source mission.");

        ValidateEnemyLedger(snapshot, rule, combat);
        ValidateObjective(snapshot, rule);

        if (rule.MissionType == "Score")
        {
            if (snapshot.Coop.ParticipantScores.Count != manifest.Players.Length)
                throw new InvalidDataException("Score mission has an incomplete allied ledger.");
            long total = 0;
            for (int index = 0; index < manifest.Players.Length; index++)
            {
                BattleCoopParticipantScore row = snapshot.Coop.ParticipantScores[index];
                if (row.PlayerId != manifest.Players[index].PlayerId ||
                    row.Score < 0 || row.Score > 1_000_000_000)
                    throw new InvalidDataException("Invalid Score mission participant row.");
                total += row.Score;
            }
            if (total != snapshot.Coop.ObjectiveScore)
                throw new InvalidDataException("Allied scores do not conserve mission progress.");
        }
        else if (snapshot.Coop.ParticipantScores.Count != 0)
        {
            throw new InvalidDataException("Non-Score mission has allied score rows.");
        }

        float remainingTimeRatio =
            (float)(snapshot.Coop.DeadlineTick - snapshot.EndTick) /
            durationTicks;
        var expectedScores = new List<CoopMissionSuccessScore>();
        for (int index = 0; index < manifest.Players.Length; index++)
        {
            ParticipantManifest definition = manifest.Players[index];
            BattlePlayerState player = snapshot.Players[index];
            if (player.PlayerId != definition.PlayerId ||
                !player.Admitted || !player.Ready ||
                player.MaxHealth != definition.Combat!.MaxHealth ||
                !float.IsFinite(player.Health) ||
                player.Health > player.MaxHealth ||
                player.Dead != (player.Health <= 0))
                throw new InvalidDataException("Invalid co-op terminal player vitality.");
            if (player.Dead)
                continue;
            float healthRatio = Math.Clamp(
                player.Health / player.MaxHealth, 0f, 1f);
            CoopMissionSuccessScore expected = CoopMissionScorePolicy.Calculate(
                rule, healthRatio, remainingTimeRatio);
            expectedScores.Add(expected);
            int scoreIndex = expectedScores.Count - 1;
            if (scoreIndex >= snapshot.Coop.SuccessScores.Count ||
                snapshot.Coop.SuccessScores[scoreIndex].PlayerId != player.PlayerId ||
                snapshot.Coop.SuccessScores[scoreIndex].Score != expected.Score ||
                snapshot.Coop.SuccessScores[scoreIndex].Stars != expected.Stars)
                throw new InvalidDataException("Co-op success score differs from host state.");
        }
        if (expectedScores.Count == 0 ||
            snapshot.Coop.SuccessScores.Count != expectedScores.Count)
            throw new InvalidDataException("Co-op success has an invalid score roster.");
    }

    private static void ValidateObjective(MatchSnapshot snapshot, MissionRule rule)
    {
        BattleCoopState state = snapshot.Coop;
        int confirmedDeaths = state.EnemySpawns.Count(enemy =>
            enemy.DeathTick != 0 && enemy.Health == 0 &&
            enemy.DeathTick >= enemy.SpawnTick &&
            enemy.DeathTick <= snapshot.EndTick);
        if (state.EnemySpawns.Any(enemy => enemy.DeathTick != 0 &&
                (enemy.Health != 0 || enemy.DeathTick < enemy.SpawnTick ||
                 enemy.DeathTick > snapshot.EndTick)))
            throw new InvalidDataException("Co-op enemy death ledger is inconsistent.");

        switch (rule.MissionType)
        {
            case "KillXEnemies":
                if (snapshot.EndTick >= state.DeadlineTick ||
                    state.EnemyKills != rule.Objective ||
                    confirmedDeaths != state.EnemyKills || state.Boss != null)
                    throw new InvalidDataException("Kill mission lacks its source target.");
                break;
            case "SurviveXSeconds":
                if (snapshot.EndTick != state.DeadlineTick ||
                    state.EnemyKills != 0 || state.Boss != null)
                    throw new InvalidDataException("Survive mission ended before its deadline.");
                break;
            case "Score":
                if (snapshot.EndTick >= state.DeadlineTick ||
                    state.EnemyKills != 0 || state.Boss != null)
                    throw new InvalidDataException("Score mission exceeded its deadline.");
                break;
            case "KillOpponent":
                if (snapshot.EndTick >= state.DeadlineTick || state.EnemyKills != 0 ||
                    state.Boss?.EntityId != CoopMissionEngine.BossEntityId ||
                    state.Boss.Health != 0 ||
                    state.Boss.DeathTick != snapshot.EndTick)
                    throw new InvalidDataException("Boss mission lacks a host death.");
                break;
            default:
                throw new InvalidDataException("Unknown co-op mission objective.");
        }
    }

    private static void ValidateEnemyLedger(MatchSnapshot snapshot,
        MissionRule rule, CoopEnemyCombatCatalog combat)
    {
        ulong expectedEntityId = 1;
        var timedEventCounts = new int[rule.Events.Count];
        var lastEventSpawnTicks = new ulong?[rule.Events.Count];
        var capacity = new SpawnCapacityReplay(rule);
        BattleCoopEnemySpawn? previousSpawn = null;
        ulong? lastTimedTick = null;
        int lastTimedEventIndex = -1;
        foreach (BattleCoopEnemySpawn enemy in snapshot.Coop.EnemySpawns)
        {
            if (enemy.EntityId != expectedEntityId ||
                enemy.SpawnTick < snapshot.StartTick ||
                enemy.SpawnTick >= snapshot.Coop.DeadlineTick ||
                (previousSpawn != null &&
                 (enemy.SpawnTick < previousSpawn.SpawnTick ||
                  enemy.SpawnTick == previousSpawn.SpawnTick &&
                  enemy.TimedEvent && !previousSpawn.TimedEvent)))
                throw new InvalidDataException(
                    "Co-op enemy spawn has invalid identity or time.");

            // WaveManager makes only one automatic choice per scheduler tick.
            // Timed events can share that tick, but must precede its choice.
            if (!enemy.TimedEvent && previousSpawn != null &&
                previousSpawn.SpawnTick == enemy.SpawnTick &&
                !previousSpawn.TimedEvent)
                throw new InvalidDataException(
                    "Co-op mission spawned twice on one automatic tick.");

            ulong elapsedTicks = enemy.SpawnTick - snapshot.StartTick;
            if (enemy.TimedEvent)
            {
                // DueTimedEvents checks each new whole mission second.
                // Its first check happens one tick after Ready starts play.
                if (elapsedTicks != 1 &&
                    elapsedTicks % MatchManifest.TickRate != 0)
                    throw new InvalidDataException(
                        "Co-op timed spawn missed its event clock.");
                int eventIndex = ValidateTimedSpawn(enemy,
                    snapshot.StartTick, rule, timedEventCounts,
                    lastEventSpawnTicks);
                if (lastTimedTick == enemy.SpawnTick &&
                    eventIndex < lastTimedEventIndex)
                    throw new InvalidDataException(
                        "Co-op timed events differ from source order.");
                lastTimedTick = enemy.SpawnTick;
                lastTimedEventIndex = eventIndex;
            }
            else if (enemy.CardUnit || !rule.Behaviours.Any(behaviour =>
                         behaviour.Name == enemy.Behaviour &&
                         behaviour.Level == enemy.Level) ||
                     elapsedTicks <
                         MissionAutomaticSpawnState.AutomaticIntervalTicks ||
                     elapsedTicks %
                         MissionAutomaticSpawnState.AutomaticIntervalTicks != 0)
                throw new InvalidDataException(
                    "Co-op automatic spawn differs from the mission rule.");

            float expectedProgress = enemy.CardUnit
                ? Math.Clamp(enemy.Level / 25f, 0f, 1f) : 0f;
            float expectedMaximum = enemy.CardUnit
                ? combat.CardStats(enemy.Behaviour, expectedProgress).Health
                : combat.OrdinaryStats(enemy.Behaviour,
                    enemy.Level).Health;
            if (!float.IsFinite(enemy.MaxHealth) ||
                enemy.MaxHealth != expectedMaximum ||
                enemy.CardProgress != expectedProgress ||
                !float.IsFinite(enemy.Health) || enemy.Health < 0 ||
                enemy.Health > enemy.MaxHealth ||
                (enemy.Health == 0) != (enemy.DeathTick != 0) ||
                enemy.SpawnTick > snapshot.EndTick)
                throw new InvalidDataException(
                    "Co-op success has an invalid enemy spawn ledger.");
            capacity.ValidateAndRecord(enemy);
            expectedEntityId++;
            previousSpawn = enemy;
        }
    }

    private sealed class SpawnCapacityReplay
    {
        private readonly MissionRule rule;
        private readonly Dictionary<string, MissionSpawnBehaviour> behaviours;
        private readonly Dictionary<string, int> living =
            new(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<string, int> automaticSpawns =
            new(StringComparer.OrdinalIgnoreCase);
        private readonly PriorityQueue<BattleCoopEnemySpawn, ulong> deaths = new();
        private int liveInScene;

        internal SpawnCapacityReplay(MissionRule rule)
        {
            this.rule = rule;
            behaviours = rule.Behaviours.ToDictionary(
                behaviour => behaviour.Name, StringComparer.OrdinalIgnoreCase);
        }

        internal void ValidateAndRecord(BattleCoopEnemySpawn enemy)
        {
            // SpawnDueEnemies runs before host damage on a tick. Deaths on
            // that same tick cannot free capacity for this spawn decision.
            while (deaths.TryPeek(out _, out ulong deathTick) &&
                   deathTick < enemy.SpawnTick)
            {
                BattleCoopEnemySpawn dead = deaths.Dequeue();
                living[dead.Behaviour]--;
                liveInScene--;
            }

            behaviours.TryGetValue(enemy.Behaviour,
                out MissionSpawnBehaviour? behaviour);
            living.TryGetValue(enemy.Behaviour, out int liveOfBehaviour);
            automaticSpawns.TryGetValue(enemy.Behaviour,
                out int earlierAutomaticCount);
            if (enemy.TimedEvent)
            {
                // Mission.UpdateMission checks the scene limit even when
                // zero. Events outside WaveManager's list have no such limit.
                if (behaviour != null &&
                    liveOfBehaviour >= behaviour.SceneLimit)
                    throw new InvalidDataException(
                        "Co-op timed spawn exceeded its scene limit.");
            }
            else if (liveInScene >= rule.MaxUnitsAtOnce ||
                     behaviour == null ||
                     behaviour.SceneLimit != 0 &&
                     liveOfBehaviour >= behaviour.SceneLimit ||
                     behaviour.MissionLimit != 0 &&
                     earlierAutomaticCount >= behaviour.MissionLimit)
            {
                throw new InvalidDataException(
                    "Co-op automatic spawn exceeded its source capacity.");
            }

            if (behaviour == null)
                return;
            living[enemy.Behaviour] = liveOfBehaviour + 1;
            liveInScene++;
            if (!enemy.TimedEvent)
                automaticSpawns[enemy.Behaviour] = earlierAutomaticCount + 1;
            if (enemy.DeathTick != 0)
                deaths.Enqueue(enemy, enemy.DeathTick);
        }
    }

    private static int ValidateTimedSpawn(BattleCoopEnemySpawn enemy,
        ulong startTick, MissionRule rule, int[] eventCounts,
        ulong?[] lastEventSpawnTicks)
    {
        ulong elapsedSecond = (enemy.SpawnTick - startTick) /
            MatchManifest.TickRate;
        for (int index = 0; index < rule.Events.Count; index++)
        {
            MissionTimedEvent source = rule.Events[index];
            int maximum = source.Count == 0 ? 1 : source.Count;
            if (source.Behaviour != enemy.Behaviour ||
                source.Level != enemy.Level ||
                source.IsCardUnit != enemy.CardUnit ||
                elapsedSecond < source.TimeSeconds ||
                eventCounts[index] >= maximum)
                continue;

            // Mission.UpdateMission visits an event once per whole-second pass.
            // Its Count allows retries on later seconds, not a batch at once.
            if (lastEventSpawnTicks[index] == enemy.SpawnTick)
                throw new InvalidDataException(
                    "Co-op timed event spawned twice in one second.");
            eventCounts[index]++;
            lastEventSpawnTicks[index] = enemy.SpawnTick;
            return index;
        }
        throw new InvalidDataException(
            "Co-op timed spawn has no due source event capacity.");
    }
}
