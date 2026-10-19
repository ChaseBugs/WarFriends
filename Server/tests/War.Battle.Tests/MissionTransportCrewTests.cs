using War.BattleServer;

/// <summary>Checks secondary death accounting without fabricating automatic/event generation.</summary>
internal static class MissionTransportCrewTests
{
    private const ulong SpawnTick = MissionAutomaticSpawnState.AutomaticIntervalTicks;

    internal static int Run(MissionCatalog catalog)
    {
        VerifyWaveBalance(catalog.Get(0));
        VerifyUnlistedAircraft(catalog.Get(0));
        VerifyKillObjective(catalog);
        Console.WriteLine("PASS: initial transport crew preserves generation accounting and one-time kill credit.");
        return 12;
    }

    private static void VerifyWaveBalance(MissionRule source)
    {
        MissionRule rule = source with
        {
            MaxUnitsAtOnce = 1,
            Behaviours = new[]
            {
                new MissionSpawnBehaviour("Assaulter", 1, 1, 1),
                new MissionSpawnBehaviour("DeployHeli", 1, 1, 1),
            },
            Events = Array.Empty<MissionTimedEvent>(),
        };
        var state = new MissionAutomaticSpawnState(rule, count => count - 1);
        Require(state.Start(0) && state.SelectAutomaticBehaviour(SpawnTick) == 1 &&
            state.ConfirmSpawn(1, 100, SpawnTick), "Crew fixture did not confirm its source aircraft.");
        Require(!state.ConfirmInitialTransportCrew(0, new ulong[] { 103 }, SpawnTick) &&
            !state.ConfirmInitialTransportCrew(100, new ulong[] { 101, 101 }, SpawnTick) &&
            !state.ConfirmInitialTransportCrew(100, new ulong[] { 0 }, SpawnTick) &&
            !state.ConfirmInitialTransportCrew(100, new ulong[] { 100 }, SpawnTick),
            "Crew registration accepted unknown parent, duplicate, zero or parent-alias identities.");
        Require(state.ConfirmInitialTransportCrew(100, new ulong[] { 101, 102 }, SpawnTick) &&
            !state.ConfirmInitialTransportCrew(100, new ulong[] { 103 }, SpawnTick) && state.LiveCount == 1,
            "Crew registration consumed generated capacity or allowed a second initial cohort.");
        Require(state.ConfirmDeath(101) && !state.ConfirmDeath(101) && state.ConfirmDeath(102) && state.LiveCount == -1,
            "Secondary deaths lost source killedCount accounting or were applied twice.");
        ulong nextTick = SpawnTick + MissionAutomaticSpawnState.AutomaticIntervalTicks;
        Require(state.SelectAutomaticBehaviour(nextTick) == 0 && state.ConfirmSpawn(0, 103, nextTick) &&
            state.LiveCount == 0, "Failed crew registration consumed identity or changed generated lifetime limits.");
    }

    private static void VerifyUnlistedAircraft(MissionRule source)
    {
        MissionRule rule = source with
        {
            Behaviours = new[] { new MissionSpawnBehaviour("Assaulter", 1, 1, 1) },
            Events = new[] { new MissionTimedEvent(0, "DeployHeli", 1, true, 1, "") },
        };
        var state = new MissionAutomaticSpawnState(rule, null);
        Require(state.Start(0) && state.DueTimedEvents(0).Contains(0) &&
            state.ConfirmTimedEventSpawn(0, 500, 0) &&
            state.ConfirmInitialTransportCrew(500, new ulong[] { 501 }, 0),
            "Timed aircraft absent from the wave list could not register its confirmed crew.");
        Require(state.LiveCount == 0 && state.ConfirmDeath(501) && state.LiveCount == -1,
            "Timed aircraft crew fabricated wave generation or missed a matching Assaulter death.");
    }

    private static void VerifyKillObjective(MissionCatalog catalog)
    {
        MissionRule rule = catalog.Missions.First(row => row.MissionType == "KillXEnemies" && row.Objective >= 3 &&
            row.Events.Any(timedEvent => timedEvent.Behaviour == "DeployHeli"));
        int eventIndex = rule.Events.ToList().FindIndex(timedEvent => timedEvent.Behaviour == "DeployHeli");
        ulong aircraftTick = (ulong)rule.Events[eventIndex].TimeSeconds * MatchManifest.TickRate;
        var engine = new CoopMissionEngine(catalog, rule.Index);
        const string firstPlayer = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        const string secondPlayer = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
        Require(engine.Admit(firstPlayer) && engine.Admit(secondPlayer) &&
            engine.MarkReady(firstPlayer, 0) && engine.MarkReady(secondPlayer, 0), "Crew mission did not start.");
        Require(engine.DueTimedEvents(aircraftTick).Contains(eventIndex) &&
            engine.ConfirmTimedEventSpawn(eventIndex, 600, aircraftTick), "Crew mission aircraft was not confirmed.");
        Require(engine.ConfirmInitialTransportCrew(600, new ulong[] { 601, 602 }, aircraftTick),
            "Mission engine rejected host-confirmed initial crew.");
        Require(engine.ConfirmAiDeath(601, aircraftTick) && engine.EnemyKills == 1 &&
            !engine.ConfirmAiDeath(601, aircraftTick) && engine.EnemyKills == 1,
            "Secondary kill failed one-time objective accounting.");
        Require(engine.ConfirmAiDeath(602, aircraftTick) && engine.EnemyKills == 2,
            "Distinct secondary actor death failed all-types kill objective accounting.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
