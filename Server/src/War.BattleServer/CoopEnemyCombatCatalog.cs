namespace War.BattleServer;

/// <summary>
/// Binds Mission.behavioursDictionary names to the recovered unit upgrade rows.
/// Only ordinary mission enemies use these stats. Card events interpolate
/// CARDS_MIN/MAX rows, which are a separate rule.
/// </summary>
public sealed class CoopEnemyCombatCatalog
{
    private static readonly IReadOnlyDictionary<string, string> BehaviourTypes =
        new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["Assaulter"] = "SoldierBehaviourAssaulter",
            ["Sniper"] = "SoldierBehaviourSniper",
            ["Grenadier"] = "SoldierBehaviourGrennader",
            ["Shotgunner"] = "SoldierBehaviourShotgunner",
            ["Parachuter"] = "SoldierBehaviourParachuter",
            ["Minigunner"] = "SoldierBehaviourMinigunner",
            ["RocketLauncher"] = "SoldierBehaviourBazooka",
            ["Swat"] = "SoldierBehaviourSwat",
            ["Engineer"] = "SoldierBehaviourEngineer",
            ["Drone"] = "DroneBehaviour",
            ["Helicopter"] = "AssaultHelicopterBehaviour",
            ["DeployHeli"] = "HelicopterBehaviour",
            ["Humvee"] = "CarBehaviour",
            ["Buggy"] = "CarBuggyBehaviour",
            ["Tank"] = "TankBehaviour",
            ["MachineGunner"] = "SoldierBehaviourMachineGunner",
            ["SciFi"] = "SoldierBehaviourSciFi",
            ["Transporter"] = "CarTransporterBehaviour",
            ["Commando"] = "SoldierBehaviourCommando",
            ["Flamethrower"] = "SoldierBehaviourFlamethrower",
            ["Gunslinger"] = "SoldierBehaviourGunslinger",
            ["Warper"] = "SoldierBehaviourWarper",
            ["Mortar"] = "SoldierBehaviourMortar",
            ["Mech"] = "MechBehaviour"
        };

    private readonly ArmyDeploymentCatalog army;
    private readonly IReadOnlyDictionary<string, string> unitIds;

    public CoopEnemyCombatCatalog(MissionCatalog missions, ArmyDeploymentCatalog army)
    {
        ArgumentNullException.ThrowIfNull(missions);
        this.army = army ?? throw new ArgumentNullException(nameof(army));
        var families = army.Families.ToDictionary(
            family => family.BehaviorType, family => family.UnitId,
            StringComparer.Ordinal);
        var mapped = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach ((string missionName, string typeName) in BehaviourTypes)
        {
            if (!families.TryGetValue(typeName, out string? unitId))
                throw new InvalidDataException($"Co-op behavior {missionName} lacks a source unit.");
            mapped.Add(missionName, unitId);
        }
        foreach (MissionRule mission in missions.Missions)
        {
            foreach (MissionSpawnBehaviour behaviour in mission.Behaviours)
            {
                RequireKnown(mapped, behaviour.Name);
                _ = army.CoopStats(mapped[behaviour.Name], behaviour.Level, false);
            }
            foreach (MissionTimedEvent timedEvent in mission.Events)
            {
                RequireKnown(mapped, timedEvent.Behaviour);
                if (!timedEvent.IsCardUnit)
                    _ = army.CoopStats(
                        mapped[timedEvent.Behaviour], timedEvent.Level, false);
            }
        }
        unitIds = mapped;
    }

    public ArmyBaseCombatStats OrdinaryStats(
        string behaviour, int normalUpgradeIndex, bool heroic = false)
    {
        if (!unitIds.TryGetValue(behaviour, out string? unitId))
            throw new InvalidDataException($"Unknown co-op behavior {behaviour}.");
        return army.CoopStats(unitId, normalUpgradeIndex, heroic);
    }

    private static void RequireKnown(
        IReadOnlyDictionary<string, string> mapped, string behaviour)
    {
        if (!mapped.ContainsKey(behaviour))
            throw new InvalidDataException($"Mission behavior {behaviour} lacks combat stats.");
    }
}
