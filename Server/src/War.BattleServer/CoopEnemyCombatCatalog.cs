namespace War.BattleServer;

/// <summary>
/// Binds Mission.behavioursDictionary names to the recovered unit upgrade rows.
/// Ordinary and card mission enemies use different source upgrade rows.
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
    private readonly CoopCardRowCatalog cards;
    private readonly IReadOnlyDictionary<string, string> unitIds;
    private readonly IReadOnlyDictionary<string, string> infantryIdleClips;

    public CoopEnemyCombatCatalog(MissionCatalog missions,
        ArmyDeploymentCatalog army, CoopCardRowCatalog cards)
    {
        ArgumentNullException.ThrowIfNull(missions);
        this.army = army ?? throw new ArgumentNullException(nameof(army));
        this.cards = cards ?? throw new ArgumentNullException(nameof(cards));
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
                else
                    _ = cards.Stats(mapped[timedEvent.Behaviour],
                        Math.Clamp(timedEvent.Level / 25f, 0f, 1f));
            }
        }
        unitIds = mapped;
        var infantry = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var familiesById = army.Families.ToDictionary(family => family.UnitId,
            StringComparer.Ordinal);
        foreach ((string behaviour, string unitId) in mapped)
        {
            if (familiesById[unitId].IsSoldier)
                infantry.Add(behaviour, ArmyInfantryPosePolicy.For(unitId).Idle);
        }
        infantryIdleClips = infantry;
    }

    internal string? InfantryIdleClip(string behaviour)
    {
        if (!unitIds.ContainsKey(behaviour))
            throw new InvalidDataException($"Unknown co-op behavior {behaviour}.");
        return infantryIdleClips.GetValueOrDefault(behaviour);
    }

    public ArmyBaseCombatStats OrdinaryStats(
        string behaviour, int normalUpgradeIndex, bool heroic = false)
    {
        if (!unitIds.TryGetValue(behaviour, out string? unitId))
            throw new InvalidDataException($"Unknown co-op behavior {behaviour}.");
        return army.CoopStats(unitId, normalUpgradeIndex, heroic);
    }

    public ArmyBaseCombatStats CardStats(
        string behaviour, float progress, bool heroic = false)
    {
        if (!unitIds.TryGetValue(behaviour, out string? unitId))
            throw new InvalidDataException($"Unknown co-op behavior {behaviour}.");
        return cards.Stats(unitId, progress, heroic);
    }

    private static void RequireKnown(
        IReadOnlyDictionary<string, string> mapped, string behaviour)
    {
        if (!mapped.ContainsKey(behaviour))
            throw new InvalidDataException($"Mission behavior {behaviour} lacks combat stats.");
    }
}
