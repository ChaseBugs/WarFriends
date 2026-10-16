using War.BattleServer;

/// <summary>Exercises mission progress and frozen attribution after a host-confirmed peer departure.</summary>
internal static class CoopSurvivorMissionTests
{
    private const string SurvivorId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string DepartingId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private const string UnknownId = "cccccccccccccccccccccccccccccccc";

    internal static void Run(MissionCatalog catalog, CoopSkillShotScoreCatalog scores)
    {
        VerifySurvival(catalog);
        VerifyKillProgress(catalog);
        VerifyBossProgress(catalog);
        VerifyScoreHistory(catalog, scores);
        VerifyFrozenStartRoster(catalog, scores);
        VerifyLastParticipant(catalog);
        VerifyPrestartRejection(catalog);
        Console.WriteLine("PASS: survivor mission progress, preserved departed-owner credit and departure boundaries");
    }

    private static void VerifySurvival(MissionCatalog catalog)
    {
        CoopMissionEngine mission = Start(catalog, "SurviveXSeconds");
        Require(mission.ContinueAfterPeerDeparture(DepartingId), "The host must be able to retain one survivor.");
        Require(mission.Participants.SequenceEqual([SurvivorId]) && mission.Outcome == MissionOutcome.InProgress,
            "Peer departure must preserve the active mission and survivor roster.");
        Require(!mission.ContinueAfterPeerDeparture(DepartingId) && !mission.Admit(DepartingId),
            "Repeated departure or re-admission must not alter a running mission.");
        Require(!mission.AdvanceTick(mission.DeadlineTick - 1) && mission.AdvanceTick(mission.DeadlineTick) &&
            mission.Outcome == MissionOutcome.Succeeded,
            "The remaining ally must finish survival at the original deadline.");
    }

    private static void VerifyKillProgress(MissionCatalog catalog)
    {
        CoopMissionEngine mission = Start(catalog, "KillXEnemies");
        Require(mission.ContinueAfterPeerDeparture(DepartingId), "The kill mission must retain its survivor.");
        ulong tick = SpawnNext(mission, 1, mission.StartTick);
        Require(mission.ConfirmAiDeath(1, tick) && mission.EnemyKills == 1 && !mission.ConfirmAiDeath(1, tick),
            "Source AI spawning and replay-safe kill progress must continue after departure.");
    }

    private static void VerifyBossProgress(MissionCatalog catalog)
    {
        CoopMissionEngine mission = Start(catalog, "KillOpponent");
        Require(mission.RegisterBoss(CoopMissionEngine.BossEntityId, mission.StartTick) &&
            mission.ContinueAfterPeerDeparture(DepartingId) &&
            mission.ConfirmBossDeath(CoopMissionEngine.BossEntityId, mission.StartTick + 1) &&
            mission.Outcome == MissionOutcome.Succeeded,
            "A host-confirmed boss death must still complete the survivor's mission.");
    }

    private static void VerifyScoreHistory(MissionCatalog catalog, CoopSkillShotScoreCatalog scores)
    {
        CoopMissionEngine mission = Start(catalog, "Score");
        ulong firstTick = SpawnNext(mission, 1, mission.StartTick);
        Require(mission.ConfirmAttributedAiDeath(1, DepartingId, CoopEnemyKillCredit.AlliedArmy, scores, firstTick),
            "The departing ally's first host-confirmed army kill must be accepted.");
        int sourcePoints = scores.PointsForConfirmedEnemyKill(CoopEnemyKillCredit.AlliedArmy);
        ulong secondTick = SpawnNext(mission, 2, firstTick);
        Require(mission.ContinueAfterPeerDeparture(DepartingId) && mission.ScoreFor(DepartingId) == sourcePoints,
            "Deactivation must not erase already earned shared score.");
        Require(mission.ConfirmAttributedAiDeath(2, DepartingId, CoopEnemyKillCredit.AlliedArmy, scores, secondTick),
            "A trusted late projectile credit must retain its frozen original owner.");
        ulong thirdTick = SpawnNext(mission, 3, secondTick);
        Require(!mission.ConfirmAttributedAiDeath(3, UnknownId, CoopEnemyKillCredit.AlliedArmy, scores, thirdTick),
            "An unknown owner must not consume an AI death or earn score.");
        Require(mission.ConfirmAttributedAiDeath(3, SurvivorId, CoopEnemyKillCredit.AlliedArmy, scores, thirdTick) &&
            mission.ScoreFor(DepartingId) == sourcePoints * 2 && mission.ScoreFor(SurvivorId) == sourcePoints &&
            mission.Score == sourcePoints * 3,
            "Original-roster attribution must conserve departed and surviving contributions.");
    }

    private static void VerifyLastParticipant(MissionCatalog catalog)
    {
        CoopMissionEngine mission = Start(catalog, "SurviveXSeconds");
        Require(mission.ContinueAfterPeerDeparture(DepartingId) &&
            !mission.ContinueAfterPeerDeparture(SurvivorId) && mission.Participants.SequenceEqual([SurvivorId]) &&
            mission.Outcome == MissionOutcome.InProgress,
            "The continuation operation must not silently remove the last survivor.");
        Require(mission.Leave(SurvivorId) && mission.Outcome == MissionOutcome.Failed &&
            mission.SelectAutomaticBehaviour(mission.StartTick + 1) == null,
            "The explicit final leave must close mission progress and spawning.");
    }

    private static void VerifyFrozenStartRoster(MissionCatalog catalog, CoopSkillShotScoreCatalog scores)
    {
        MissionRule rule = catalog.Missions.First(candidate => candidate.MissionType == "Score");
        var mission = new CoopMissionEngine(catalog, rule.Index, _ => 0);
        Require(mission.Admit(UnknownId) && mission.Leave(UnknownId),
            "A loading-stage identity must be removable before the eventual battle roster starts.");
        Require(mission.Admit(SurvivorId) && mission.Admit(DepartingId) &&
            mission.MarkReady(SurvivorId, 0) && mission.MarkReady(DepartingId, 0),
            "The actual starting roster must be frozen from the two ready allies.");
        ulong tick = SpawnNext(mission, 1, mission.StartTick);
        Require(!mission.ConfirmAttributedAiDeath(1, UnknownId, CoopEnemyKillCredit.AlliedArmy, scores, tick) &&
            mission.ConfirmAttributedAiDeath(1, SurvivorId, CoopEnemyKillCredit.AlliedArmy, scores, tick),
            "A former loading identity must not become a durable combat owner or consume a death receipt.");
    }

    private static void VerifyPrestartRejection(MissionCatalog catalog)
    {
        MissionRule rule = catalog.Missions.First(candidate => candidate.MissionType == "SurviveXSeconds");
        var mission = new CoopMissionEngine(catalog, rule.Index);
        mission.Admit(SurvivorId);
        mission.Admit(DepartingId);
        Require(!mission.ContinueAfterPeerDeparture(DepartingId) && mission.Participants.Count == 2,
            "Loading cancellation must not use the running-peer continuation operation.");
    }

    private static CoopMissionEngine Start(MissionCatalog catalog, string missionType)
    {
        MissionRule rule = catalog.Missions.First(candidate => candidate.MissionType == missionType);
        var mission = new CoopMissionEngine(catalog, rule.Index, _ => 0);
        Require(mission.Admit(SurvivorId) && mission.Admit(DepartingId) &&
            mission.MarkReady(SurvivorId, 0) && mission.MarkReady(DepartingId, 0) && mission.Started,
            "Both source allies must be admitted and ready before mission play.");
        return mission;
    }

    private static ulong SpawnNext(CoopMissionEngine mission, ulong entityId, ulong afterTick)
    {
        for (ulong tick = afterTick + 1; tick < mission.DeadlineTick; tick++)
        {
            int? behaviour = mission.SelectAutomaticBehaviour(tick);
            if (!behaviour.HasValue)
            {
                continue;
            }

            Require(mission.ConfirmAutomaticSpawn(behaviour.Value, entityId, tick),
                "The due source automatic spawn must be confirmed by the host.");
            return tick;
        }

        throw new InvalidDataException("The source mission did not permit the required automatic spawn.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
