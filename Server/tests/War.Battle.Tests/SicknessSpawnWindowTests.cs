using War.BattleServer;

/// <summary>Checks Sickness event-reference semantics separately from protocol and host integration.</summary>
internal static class SicknessSpawnWindowTests
{
    internal static int Run(string directory)
    {
        var content = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"));
        ArmyDeploymentCatalog catalog = content.Army;
        var soldier = catalog.Families.Single(family => family.UnitId == "ID_UNIT-ASSAULT");
        var vehicle = catalog.Families.First(family => !family.IsSoldier);
        ArmyDeploymentWave first = CreateWave(catalog, soldier.Options[0].Index, 1);
        ArmyDeploymentWave second = CreateWave(catalog, soldier.Options[1].Index, 2);
        ArmyDeploymentWave machine = CreateWave(catalog, vehicle.Options[0].Index, 3);
        var window = new SicknessSpawnWindow(1, catalog);
        int checks = CheckCallbacks(window, first, second, machine);
        checks += CheckDamage(window, first);
        checks += CheckInvalid(window, first);
        checks += CheckReusedDefinition(window, first);
        checks += CheckReverseOwner(catalog, first);
        return checks;
    }

    private static int CheckCallbacks(SicknessSpawnWindow window, ArmyDeploymentWave first,
        ArmyDeploymentWave second, ArmyDeploymentWave vehicle)
    {
        int checks = Check(!window.IsArmed && !window.IsApplying, "An unused card subscribed to source callbacks.");
        window.Arm();
        checks += Check(window.IsArmed && !window.IsApplying, "Arming retroactively selected an existing wave.");
        window.DeploymentStarted(1, first);
        window.DeploymentStarted(2, vehicle);
        checks += Check(!window.IsApplying, "Friendly or vehicle starts opened the soldier window.");
        window.DeploymentStarted(2, first);
        checks += Check(window.ShouldAffect(new(2, true, true)), "An eligible opposing spawn was not affected.");
        checks += Check(!window.ShouldAffect(new(1, true, true)) &&
            !window.ShouldAffect(new(2, false, true)) && !window.ShouldAffect(new(2, true, false)),
            "Friendly, non-EnemyController, or freeze-immune entities became victims.");
        checks += Check(window.ShouldAffect(new(0, true, true)), "Source neutral-fraction inequality was changed.");
        window.DeploymentStarted(2, second);
        window.DeploymentFinished(2, first);
        checks += Check(window.IsApplying, "An older different definition ended the replacement window.");
        window.DeploymentFinished(1, second);
        checks += Check(window.IsApplying, "A friendly finish removed the opposing window.");
        window.DeploymentFinished(2, second with { Id = 99 });
        checks += Check(!window.IsArmed, "Finish compared occurrence IDs instead of reused definition identity.");
        window.Arm();
        window.DeploymentStarted(2, first);
        window.Arm();
        checks += Check(window.IsArmed && !window.IsApplying, "Re-use did not reset the remembered definition.");
        window.Disconnect();
        checks += Check(!window.IsArmed, "Disconnect left the source subscriptions armed.");
        return checks;
    }

    private static int CheckDamage(SicknessSpawnWindow window, ArmyDeploymentWave first)
    {
        window.Arm();
        window.DeploymentStarted(2, first);
        float[] weapons = [20, 0, 80];
        var original = new SicknessCombatState(100, 10, weapons) { IsImmortal = true, IsDead = true };
        SicknessCombatState affected = window.Apply(new(2, true, true), original);
        int checks = Check(affected.MaximumHealth == 100 && affected.Health == 50 && original.Health == 10,
            "Sickness halved maximum/current health instead of refilling current health to half maximum.");
        checks += Check(affected.WeaponDamage.SequenceEqual(new float[] { 10, 0, 40 }) &&
            weapons.SequenceEqual(new float[] { 20, 0, 80 }), "Source all-weapons damage scaling changed input data.");
        checks += Check(!affected.IsImmortal && !affected.IsDead, "RefillTo did not clear source vitality flags.");
        weapons[0] = 100;
        checks += Check(affected.WeaponDamage[0] == 10, "The calculated effect retained mutable input weapon damage.");
        SicknessCombatState repeated = window.Apply(new(2, true, true), affected);
        checks += Check(repeated.WeaponDamage[0] == 5 && repeated.Health == 50,
            "Repeated source callbacks did not multiply damage and refill independently.");
        window.DeploymentFinished(2, first);
        checks += Check(ReferenceEquals(window.Apply(new(2, true, true), repeated), repeated) &&
            repeated.WeaponDamage[0] == 5, "Disconnect restored an already-applied unit modifier.");
        return checks;
    }

    private static int CheckInvalid(SicknessSpawnWindow window, ArmyDeploymentWave first)
    {
        window.Arm();
        window.DeploymentStarted(2, first);
        Reject(() => window.DeploymentStarted(2, first with { IsSoldier = false }));
        Reject(() => window.DeploymentFinished(2, first with { UnitId = "ID_UNIT-UNKNOWN" }));
        Reject(() => window.ShouldAffect(new(3, true, true)));
        Reject(() => window.Apply(new(2, true, true), new(float.NaN, 1, [20])));
        Reject(() => window.Apply(new(2, true, true), new(100, 1, [-1])));
        Check(window.IsApplying, "A rejected callback consumed the active window.");
        return 6;
    }

    private static int CheckReusedDefinition(SicknessSpawnWindow window, ArmyDeploymentWave first)
    {
        window.Arm();
        window.DeploymentStarted(2, first);
        window.DeploymentStarted(2, first with { Id = 4 });
        window.DeploymentFinished(2, first);
        return Check(!window.IsArmed, "An older occurrence of the reused option did not close the source window.");
    }

    private static int CheckReverseOwner(ArmyDeploymentCatalog catalog, ArmyDeploymentWave first)
    {
        var window = new SicknessSpawnWindow(2, catalog);
        window.Arm();
        window.DeploymentStarted(1, first);
        int checks = Check(window.ShouldAffect(new(1, true, true)) && !window.ShouldAffect(new(2, true, true)),
            "The source window hardcoded one player as its caster.");
        window.DeploymentFinished(2, first);
        checks += Check(window.IsApplying, "A reversed owner's friendly finish ended the effect.");
        window.DeploymentFinished(1, first);
        checks += Check(!window.IsArmed, "The reversed opposing source finish did not disconnect.");
        return checks;
    }

    private static ArmyDeploymentWave CreateWave(ArmyDeploymentCatalog catalog, int optionIndex, ulong occurrence)
    {
        var family = catalog.Families.Single(candidate => candidate.Options.Any(option => option.Index == optionIndex));
        var state = new ArmyDeploymentState(catalog, [family.UnitId]);
        state.SetOffers([optionIndex, optionIndex, optionIndex]);
        state.TryDeploy(optionIndex, 0);
        return state.LastAcceptedWave! with { Id = occurrence };
    }

    private static int Check(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidOperationException("Malformed source event or unit authority was accepted.");
    }
}
