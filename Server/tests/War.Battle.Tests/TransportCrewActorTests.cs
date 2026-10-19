using War.BattleServer;

/// <summary>Checks source seat ownership independently of descent animation completion.</summary>
internal static class TransportCrewActorTests
{
    internal static int Run()
    {
        var attached = CreateActor(101);
        Require(attached.Health == 100 && attached.MaximumHealth == 100 && attached.IsAttached,
            "Confirmed crew did not start at source maximum health on its seat.");
        Require(!attached.Damage(float.NaN, 2) && !attached.Damage(-1, 2) && attached.Health == 100,
            "Malformed damage changed crew authority.");
        Require(attached.Damage(25, 3) && attached.Health == 75 && !attached.Damage(1, 2),
            "Crew damage lost health or accepted an older mutation tick.");
        Require(!attached.DestroyWithAircraft(999, 3) && attached.Health == 75,
            "An unrelated aircraft killed this crew actor.");
        Require(attached.DestroyWithAircraft(100, 4) && attached.Health == 0 && attached.DeathTick == 4,
            "Attached crew survived source parent destruction.");
        Require(!attached.Damage(1, 4) && !attached.Detach(4) && !attached.DestroyWithAircraft(100, 4),
            "A dead crew actor accepted another lifetime transition.");

        var detached = CreateActor(102);
        Require(detached.Detach(2) && !detached.IsAttached && !detached.Detach(2),
            "Actual seat release was not a one-time transition.");
        Require(!detached.DestroyWithAircraft(100, 3) && detached.Health == 100,
            "Parent destruction killed an already detached soldier.");
        Require(detached.Damage(100, 4) && detached.DeathTick == 4,
            "Detached crew stopped accepting independent combat damage.");
        return 9;
    }

    private static TransportCrewActorState CreateActor(ulong entityId)
    {
        var identity = new CoopMatchRuntime.TransportCrewIdentity(entityId, 0, 123);
        var member = new HelicopterCrewMemberSnapshot(0, 123, 100, 100, 1, 0);
        return new TransportCrewActorState(identity, 100, member, 1);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
