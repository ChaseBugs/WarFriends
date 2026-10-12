using War.BattleServer;

internal static class SabotageTargetPolicyTests
{
    internal static int Run()
    {
        int checks = 0;
        void Check(bool condition, string description)
        {
            if (!condition) throw new Exception(description);
            checks++;
        }

        var youngDrone = new SabotageTargetPolicy.Candidate(
            "Drone", 10, 0, 0, 2, true, true, true, true, 101, 1000f);
        var matureTank = new SabotageTargetPolicy.Candidate(
            "Tank", 20, 0, 0, 2, true, true, true, true, 1, 2000f);
        var hiddenTurret = new SabotageTargetPolicy.Candidate(
            "Turret", 30, 0, 0, 2, false, true, true, true, 1, 500f);
        var alliedMech = new SabotageTargetPolicy.Candidate(
            "Mech", 40, 0, 0, 1, true, true, true, true, 1, 3000f);
        var candidates = new[] { youngDrone, hiddenTurret, alliedMech, matureTank };

        var drawSizes = new List<int>();
        SabotageTargetPolicy.Candidate? selected = SabotageTargetPolicy.Select(
            candidates, 1, 251, count =>
            {
                drawSizes.Add(count);
                return count - 1;
            });
        Check(selected == matureTank && drawSizes.SequenceEqual([2, 1]),
            "Sabotage draws from visible opposing types, then overrides with a mature main AI part");

        drawSizes.Clear();
        selected = SabotageTargetPolicy.Select(
            [youngDrone, matureTank with { SpawnTick = 101 }], 1, 251, count =>
        {
            drawSizes.Add(count);
            return count - 1;
        });
        Check(selected == youngDrone && drawSizes.SequenceEqual([2]),
            "a part exactly five seconds old is not mature; the first draw remains authoritative");

        selected = SabotageTargetPolicy.Select(
            [youngDrone, matureTank with { SpawnTick = 101 }],
            1, 251, _ => 0);
        Check(selected?.SourceType == "Tank",
            "the first draw follows the Client's mechanical type order, not input order");

        var nonMainTank = matureTank with { IsMain = false };
        selected = SabotageTargetPolicy.Select([youngDrone, nonMainTank],
            1, 251, _ => 0);
        Check(selected == nonMainTank,
            "a young or non-main mechanical part remains in the first draw");

        var tankSidePart = matureTank with
        {
            PartId = 1, RegistrationOrder = 1, IsMain = false
        };
        selected = SabotageTargetPolicy.Select(
            [tankSidePart, matureTank], 1, 251, count => count - 1);
        Check(selected == matureTank,
            "separate shootable parts may share one mechanical entity identity");

        drawSizes.Clear();
        selected = SabotageTargetPolicy.Select([hiddenTurret, alliedMech],
            1, 251, count =>
            {
                drawSizes.Add(count);
                return 0;
            });
        Check(selected == null && drawSizes.Count == 0,
            "a spent card with no visible enemy consumes no random draw");

        try
        {
            SabotageTargetPolicy.Select([matureTank, matureTank], 1, 251, _ => 0);
            throw new Exception("duplicate mechanical authority was accepted");
        }
        catch (InvalidDataException) { checks++; }

        try
        {
            SabotageTargetPolicy.Select(
                [matureTank, tankSidePart with { RegistrationOrder = 0 }],
                1, 251, _ => 0);
            throw new Exception("duplicate registration order was accepted");
        }
        catch (InvalidDataException) { checks++; }

        try
        {
            SabotageTargetPolicy.Select([matureTank], 1, 251, count => count);
            throw new Exception("out-of-range host draw was accepted");
        }
        catch (InvalidDataException) { checks++; }

        return checks;
    }
}
