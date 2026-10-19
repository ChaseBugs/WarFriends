using War.BattleServer;

/// <summary>Preserves one callback chain when an early death reaches the mission target.</summary>
internal static class MissionDeathCascadeTests
{
    internal static int Run(MissionCatalog catalog)
    {
        MissionRule rule = catalog.Get(0) with { Objective = 1 };
        var objective = new MissionObjectiveState(rule);
        Require(objective.Start(1), "Cascade objective did not start.");
        objective.BeginDeathCascade();
        Require(objective.RecordEnemyKill("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 2) &&
            objective.Outcome == MissionOutcome.InProgress,
            "The first attached soldier ended the objective inside its parent's death chain.");
        Require(objective.RecordEnemyKill("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", 2) && objective.EnemyKills == 2,
            "The parent's later kill could not enter the same death chain.");
        objective.CompleteDeathCascade();
        Require(objective.Outcome == MissionOutcome.Succeeded &&
            !objective.RecordEnemyKill("cccccccccccccccccccccccccccccccc", 2),
            "Cascade completion did not close the objective after all synchronous deaths.");
        VerifyScoreCascade(catalog);
        return 7;
    }

    private static void VerifyScoreCascade(MissionCatalog catalog)
    {
        MissionRule rule = catalog.Missions.First(mission => mission.MissionType == "Score") with { Objective = 1 };
        var objective = new MissionObjectiveState(rule);
        Require(objective.Start(1), "Score cascade objective did not start.");
        objective.BeginDeathCascade();
        Require(objective.RecordScore("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", 1, 2) &&
            objective.RecordScore("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb", 2, 2) &&
            objective.Score == 3 && objective.Outcome == MissionOutcome.InProgress,
            "An early Score target stopped the rest of the source callback chain.");
        objective.CompleteDeathCascade();
        Require(objective.Outcome == MissionOutcome.Succeeded,
            "Score cascade failed to complete its objective after the parent death.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
