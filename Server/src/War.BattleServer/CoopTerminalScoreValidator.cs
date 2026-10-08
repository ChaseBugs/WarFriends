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
            snapshot.EndTick >= snapshot.Coop.DeadlineTick ||
            snapshot.Players.Count != 2 ||
            snapshot.Coop.ParticipantIds.Count != 2 ||
            !snapshot.Coop.ParticipantIds.SequenceEqual(
                manifest.Players.Select(player => player.PlayerId)
                    .Order(StringComparer.Ordinal)))
            throw new InvalidDataException("Co-op success differs from source mission.");

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
}
