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
        MissionCatalog missions)
    {
        ArgumentNullException.ThrowIfNull(snapshot);
        ArgumentNullException.ThrowIfNull(missions);
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

        ValidateEnemyLedger(snapshot);
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

    private static void ValidateEnemyLedger(MatchSnapshot snapshot)
    {
        var seenEntityIds = new HashSet<ulong>();
        foreach (BattleCoopEnemySpawn enemy in snapshot.Coop.EnemySpawns)
        {
            if (enemy.EntityId == 0 || !seenEntityIds.Add(enemy.EntityId) ||
                !float.IsFinite(enemy.MaxHealth) || enemy.MaxHealth <= 0 ||
                !float.IsFinite(enemy.Health) || enemy.Health < 0 ||
                enemy.Health > enemy.MaxHealth ||
                (enemy.Health == 0) != (enemy.DeathTick != 0) ||
                enemy.SpawnTick > snapshot.EndTick)
                throw new InvalidDataException(
                    "Co-op success has an invalid enemy spawn ledger.");
        }
    }
}
