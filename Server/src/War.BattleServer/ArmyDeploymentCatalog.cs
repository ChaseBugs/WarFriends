using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyDeploymentOption(int Index,int Count,int Power,float Cooldown);
public sealed record ArmyBaseCombatStats(float Health,float Damage);
public sealed record ArmyUpgradeShotStats(float ProbabilityOfRealShot,int FireBatchSizeMin,
    int FireBatchSizeMax,float MinShootTime,float MaxShootTime);
public sealed record ArmyBaseShotStats(float ProbabilityOfRealShot,int FireBatchSizeMin,
    int FireBatchSizeMax,float MinShootTime,float MaxShootTime);
public sealed record ArmyVehicleShotStats(float ShotSpeed,float ProbabilityOfRealShot,
    int FireBatchSizeMin,int FireBatchSizeMax,float MinShootTime,float MaxShootTime,int Crew);
public sealed record ArmyVehicleCannonStats(float Damage,float MinShootTime,float MaxShootTime);
public sealed record ArmyAgentConfig(string PrefabSha256,float Radius,float Acceleration,
    float AngularSpeed,float Height,float StoppingDistance,bool AutoBraking,bool AutoRepath,
    int ObstacleAvoidanceType);
public sealed record ArmyDeploymentFamily(int BehaviorFileId,string BehaviorType,int UpgradeSlotsFileId,string UnitId,
    string SheetRow,int UnitType,int SpawnPointMask,int MaxGeneratedCount,float BaseSpeed,float MovementSpeed,bool IsSoldier,bool IsAir,
    IReadOnlyList<ArmyDeploymentOption> Options,ArmyBaseShotStats? BaseShot,ArmyVehicleShotStats? VehicleShot);

/// <summary>The recovered scene's runtime army options, never a client-submitted catalog.</summary>
public sealed class ArmyDeploymentCatalog
{
    private static readonly HashSet<string> RusherTypes=new(StringComparer.Ordinal)
    {
        "SoldierBehaviourCommando","SoldierBehaviourFlamethrower",
        "SoldierBehaviourParachuter","SoldierBehaviourShotgunner",
        "SoldierBehaviourSwat","SoldierBehaviourWarper"
    };
    public string Revision { get; }
    public float MaxEnergy { get; }
    public float BaseCooldown { get; }
    public ArmyAgentConfig InfantryAgent { get; }
    public IReadOnlyList<ArmyDeploymentFamily> Families { get; }
    private readonly IReadOnlyDictionary<int,ArmyDeploymentOption> options;
    private IReadOnlyDictionary<string,IReadOnlyList<ArmyBaseCombatStats>>? baseStats;
    private IReadOnlyDictionary<string,IReadOnlyList<ArmyUpgradeShotStats>>? upgradeShots;
    private IReadOnlyDictionary<string,IReadOnlyList<float>>? specialValues;
    private IReadOnlyList<ArmyVehicleCannonStats>? buggyCannonStages;
    private IReadOnlyDictionary<string,int>? normalLaneEnds;
    private IReadOnlyDictionary<string,int>? eliteLaneStarts;
    private ArmyDeploymentCatalog(string revision,float maxEnergy,float baseCooldown,ArmyAgentConfig infantryAgent,
        IReadOnlyList<ArmyDeploymentFamily> families,Dictionary<int,ArmyDeploymentOption> options)
    {Revision=revision;MaxEnergy=maxEnergy;BaseCooldown=baseCooldown;InfantryAgent=infantryAgent;Families=families;this.options=options;}

    public ArmyDeploymentOption Option(int index)
        =>options.TryGetValue(index,out var value) ? value : throw new ArgumentOutOfRangeException(nameof(index));

    /// <summary>Unscaled recovered normal-upgrade row. Stage ownership and perk scales are separate authority.</summary>
    public ArmyBaseCombatStats BaseStats(string unitId,int normalUpgradeIndex)
    {
        if(baseStats==null || !baseStats.TryGetValue(unitId,out var stages) ||
           normalLaneEnds==null || !normalLaneEnds.TryGetValue(unitId,out int laneEnd) ||
           normalUpgradeIndex<0 || normalUpgradeIndex>=laneEnd)
            throw new ArgumentOutOfRangeException(nameof(normalUpgradeIndex));
        var value=stages[normalUpgradeIndex];
        if(value.Health<=0)throw new InvalidDataException("Army upgrade stage is an unplayable source sentinel.");
        return value;
    }

    /// <summary>Source LoadData adds each bought lane's row before perk and mode scaling.</summary>
    public ArmyBaseCombatStats ComposeStats(string unitId,int normalIndex,int? specialIndex,int? eliteIndex)
    {
        var normal=BaseStats(unitId,normalIndex);
        var stages=baseStats![unitId];
        int specialStart=normalLaneEnds![unitId];
        int eliteStart=eliteLaneStarts![unitId];
        if(specialIndex is { } special && (special<specialStart ||
            special>=(eliteStart==-1 ? stages.Count : eliteStart)))
            throw new ArgumentOutOfRangeException(nameof(specialIndex));
        if(eliteIndex is { } elite && (eliteStart==-1 || elite<eliteStart || elite>=stages.Count))
            throw new ArgumentOutOfRangeException(nameof(eliteIndex));
        float health=normal.Health,damage=normal.Damage;
        if(specialIndex.HasValue)
        { health+=stages[specialIndex.Value].Health;damage+=stages[specialIndex.Value].Damage; }
        if(eliteIndex.HasValue)
        { health+=stages[eliteIndex.Value].Health;damage+=stages[eliteIndex.Value].Damage; }
        if(!float.IsFinite(health) || health<=0 || !float.IsFinite(damage) || damage<0)
            throw new InvalidDataException("Composed army stats are outside the recovered combat domain.");
        return new ArmyBaseCombatStats(health,damage);
    }

    /// <summary>UpgradeSlotsBaseSoldier adds SPECIAL from every selected upgrade lane.</summary>
    public float ComposeSpecial(string unitId,int normalIndex,int? specialIndex,int? eliteIndex)
    {
        _=BaseStats(unitId,normalIndex);
        if(specialValues==null||!specialValues.TryGetValue(unitId,out var stages))
            throw new InvalidDataException("Army special upgrade authority is unavailable.");
        ValidateOptionalLanes(unitId,stages.Count,specialIndex,eliteIndex);
        float value=stages[normalIndex];
        if(specialIndex.HasValue)value+=stages[specialIndex.Value];
        if(eliteIndex.HasValue)value+=stages[eliteIndex.Value];
        if(!float.IsFinite(value)||Math.Abs(value)>1_000_000)
            throw new InvalidDataException("Composed army special is outside the recovered combat domain.");
        return value;
    }

    private void ValidateOptionalLanes(string unitId,int stageCount,int? specialIndex,int? eliteIndex)
    {
        int specialStart=normalLaneEnds![unitId];
        int eliteStart=eliteLaneStarts![unitId];
        if(specialIndex is { } special&&(special<specialStart||
            special>=(eliteStart==-1?stageCount:eliteStart)))
            throw new ArgumentOutOfRangeException(nameof(specialIndex));
        if(eliteIndex is { } elite&&(eliteStart==-1||elite<eliteStart||elite>=stageCount))
            throw new ArgumentOutOfRangeException(nameof(eliteIndex));
    }

    /// <summary>UpgradeSlotsBaseSoldier zeroes these fields, then adds every selected lane row.</summary>
    public ArmyBaseShotStats ComposeShot(string unitId,int normalIndex,int? specialIndex,int? eliteIndex,
        float accuracyCoefficient=1f)
    {
        _=BaseStats(unitId,normalIndex);
        if(upgradeShots==null||!upgradeShots.TryGetValue(unitId,out var stages))
            throw new InvalidDataException("Army shot upgrade authority is unavailable.");
        int specialStart=normalLaneEnds![unitId];
        int eliteStart=eliteLaneStarts![unitId];
        if(specialIndex is { } special&&(special<specialStart||
            special>=(eliteStart==-1?stages.Count:eliteStart)))
            throw new ArgumentOutOfRangeException(nameof(specialIndex));
        if(eliteIndex is { } elite&&(eliteStart==-1||elite<eliteStart||elite>=stages.Count))
            throw new ArgumentOutOfRangeException(nameof(eliteIndex));
        if(!float.IsFinite(accuracyCoefficient)||accuracyCoefficient<=0||accuracyCoefficient>10)
            throw new InvalidDataException("Invalid trusted army accuracy coefficient.");
        var selected=new List<ArmyUpgradeShotStats>{stages[normalIndex]};
        if(specialIndex.HasValue)selected.Add(stages[specialIndex.Value]);
        if(eliteIndex.HasValue)selected.Add(stages[eliteIndex.Value]);
        float probability=selected.Sum(x=>x.ProbabilityOfRealShot)*accuracyCoefficient;
        int minimum=selected.Sum(x=>x.FireBatchSizeMin);
        int maximum=selected.Sum(x=>x.FireBatchSizeMax);
        float minTime=selected.Sum(x=>x.MinShootTime);
        float maxTime=selected.Sum(x=>x.MaxShootTime);
        if(!float.IsFinite(probability)||probability<0||probability>40||minimum<1||
           maximum<minimum||maximum>64||!float.IsFinite(minTime)||!float.IsFinite(maxTime)||
           minTime<0||maxTime<minTime||maxTime>180)
            throw new InvalidDataException("Composed army shot stats are outside the recovered combat domain.");
        return new(probability,minimum,maximum,minTime,maxTime);
    }

    /// <summary>Vehicle UpgradesLoaded replaces serialized turret timing with selected upgrade rows.</summary>
    public ArmyVehicleShotStats ComposeVehicleShot(string unitId,int normalIndex,int? specialIndex,
        int? eliteIndex,float accuracyCoefficient=1f)
    {
        var family=Families.SingleOrDefault(f=>f.UnitId==unitId)??
            throw new ArgumentOutOfRangeException(nameof(unitId));
        if(family.VehicleShot==null||family.IsAir||family.IsSoldier)
            throw new InvalidDataException("Army family has no ground-vehicle shot contract.");
        _=BaseStats(unitId,normalIndex);
        if(upgradeShots==null||!upgradeShots.TryGetValue(unitId,out var stages))
            throw new InvalidDataException("Vehicle shot upgrade authority is unavailable.");
        ValidateOptionalLanes(unitId,stages.Count,specialIndex,eliteIndex);
        if(!float.IsFinite(accuracyCoefficient)||accuracyCoefficient<=0||accuracyCoefficient>10)
            throw new InvalidDataException("Invalid trusted vehicle accuracy coefficient.");
        var selected=new List<ArmyUpgradeShotStats>{stages[normalIndex]};
        if(specialIndex.HasValue)selected.Add(stages[specialIndex.Value]);
        if(eliteIndex.HasValue)selected.Add(stages[eliteIndex.Value]);
        float probability=Math.Min(1f,selected.Sum(x=>x.ProbabilityOfRealShot)*accuracyCoefficient);
        int minimum=selected.Sum(x=>x.FireBatchSizeMin);
        int maximum=selected.Sum(x=>x.FireBatchSizeMax);
        float minTime=selected.Sum(x=>x.MinShootTime);
        float maxTime=selected.Sum(x=>x.MaxShootTime);
        if(!float.IsFinite(probability)||probability<0||minimum<0||maximum<minimum||maximum>64||
           !float.IsFinite(minTime)||!float.IsFinite(maxTime)||minTime<0||maxTime<minTime||maxTime>180||
           (maximum==0&&(minimum!=0||minTime!=0||maxTime!=0)))
            throw new InvalidDataException("Composed vehicle shot stats are outside the recovered combat domain.");
        return new(family.VehicleShot.ShotSpeed,probability,minimum,maximum,minTime,maxTime,
            family.VehicleShot.Crew);
    }

    /// <summary>Buggy LoadDefinitionFromXLS adds cannon damage and timing from every selected lane.</summary>
    public ArmyVehicleCannonStats ComposeBuggyCannon(int normalIndex,int? specialIndex,int? eliteIndex)
    {
        _=BaseStats("ID_UNIT-BUGGY",normalIndex);
        if(buggyCannonStages==null)throw new InvalidDataException("Buggy cannon authority is unavailable.");
        ValidateOptionalLanes("ID_UNIT-BUGGY",buggyCannonStages.Count,specialIndex,eliteIndex);
        var selected=new List<ArmyVehicleCannonStats>{buggyCannonStages[normalIndex]};
        if(specialIndex.HasValue)selected.Add(buggyCannonStages[specialIndex.Value]);
        if(eliteIndex.HasValue)selected.Add(buggyCannonStages[eliteIndex.Value]);
        float damage=selected.Sum(x=>x.Damage);
        float min=selected.Sum(x=>x.MinShootTime),max=selected.Sum(x=>x.MaxShootTime);
        if(!float.IsFinite(damage)||damage<=0||damage>10_000_000||!float.IsFinite(min)||
           !float.IsFinite(max)||min<0||max<min||max>180)
            throw new InvalidDataException("Composed Buggy cannon stats are outside the recovered combat domain.");
        return new(damage,min,max);
    }

    public float EffectiveHealth(string unitId,int normalIndex,int? specialIndex,int? eliteIndex,
        ArmyHealthFactors factors)
    {
        ArgumentNullException.ThrowIfNull(factors);
        if(!float.IsFinite(factors.PerkCoefficient) || factors.PerkCoefficient<=0 ||
           factors.PerkCoefficient>100 || !float.IsFinite(factors.UpgradeScale) ||
           factors.UpgradeScale<=0 || factors.UpgradeScale>100)
            throw new InvalidDataException("Invalid trusted army health factors.");
        float health=ComposeStats(unitId,normalIndex,specialIndex,eliteIndex).Health;
        health*=factors.PerkCoefficient;
        health*=factors.UpgradeScale;
        if(!float.IsFinite(health) || health<=0 || health>10_000_000)
            throw new InvalidDataException("Army effective health is outside the host combat domain.");
        return health;
    }

    // AIObject.SyncUpgradesRPC applies scaleDamage after the upgrade lanes load.
    // Perk.ScaleByPerk changes HP/speed/shot speed, not damage.
    public float EffectiveDamage(string unitId,int normalIndex,int? specialIndex,int? eliteIndex,
        float damageScale)
    {
        if(!float.IsFinite(damageScale) || damageScale<=0 || damageScale>100)
            throw new InvalidDataException("Invalid trusted army damage scale.");
        float damage=ComposeStats(unitId,normalIndex,specialIndex,eliteIndex).Damage*damageScale;
        if(!float.IsFinite(damage) || damage<0 || damage>10_000_000)
            throw new InvalidDataException("Army effective damage is outside the host combat domain.");
        return damage;
    }

    // UpgradeSlotsGeneric.LoadData replaces the serialized behavior speed with
    // ArmyUpgrades.MOVEMENTSPEED, then ScaleByPerk applies speedCoef.
    public float EffectiveSpeed(string unitId,float perkSpeedCoefficient)
        =>EffectiveSpeed(unitId,perkSpeedCoefficient,0,null,null,validateUpgrade:false);

    /// <summary>SWAT UpdateVisual multiplies runtime speed by one plus the selected special lane.</summary>
    public float EffectiveSpeed(string unitId,float perkSpeedCoefficient,int normalIndex,
        int? specialIndex,int? eliteIndex)
        =>EffectiveSpeed(unitId,perkSpeedCoefficient,normalIndex,specialIndex,eliteIndex,validateUpgrade:true);

    private float EffectiveSpeed(string unitId,float perkSpeedCoefficient,int normalIndex,
        int? specialIndex,int? eliteIndex,bool validateUpgrade)
    {
        var family=Families.SingleOrDefault(f=>f.UnitId==unitId) ??
            throw new ArgumentOutOfRangeException(nameof(unitId));
        if(!float.IsFinite(perkSpeedCoefficient) || perkSpeedCoefficient<=0 ||
           perkSpeedCoefficient>100)
            throw new InvalidDataException("Invalid trusted army perk speed coefficient.");
        float speed=family.MovementSpeed*perkSpeedCoefficient;
        if(validateUpgrade)
        {
            float special=ComposeSpecial(unitId,normalIndex,specialIndex,eliteIndex);
            if(family.BehaviorType=="SoldierBehaviourSwat"&&specialIndex.HasValue)
            {
                if(special<0||special>10)
                    throw new InvalidDataException("SWAT special speed is outside its recovered combat domain.");
                speed*=1+special;
            }
        }
        if(!float.IsFinite(speed) || speed<=0 || speed>20)
            throw new InvalidDataException("Army effective speed is outside the host movement domain.");
        return speed;
    }

    public void ValidateSourceSheet(string contentPath)
    {
        using var document=JsonDocument.Parse(File.ReadAllBytes(contentPath));
        var sheet=document.RootElement.GetProperty("sheets").EnumerateArray()
            .Single(x=>x.GetProperty("type").GetString()=="Google2u.ArmyUpgrades");
        var rows=sheet.GetProperty("rows").EnumerateArray().ToDictionary(
            x=>x.GetProperty("NAME").GetString()!,StringComparer.Ordinal);
        var sourceSheets=document.RootElement.GetProperty("sheets").EnumerateArray()
            .ToDictionary(x=>x.GetProperty("type").GetString()!,StringComparer.Ordinal);
        var acceptedStats=new Dictionary<string,IReadOnlyList<ArmyBaseCombatStats>>(StringComparer.Ordinal);
        var acceptedShots=new Dictionary<string,IReadOnlyList<ArmyUpgradeShotStats>>(StringComparer.Ordinal);
        var acceptedSpecials=new Dictionary<string,IReadOnlyList<float>>(StringComparer.Ordinal);
        ArmyVehicleCannonStats[]? acceptedBuggyCannons=null;
        var acceptedLaneEnds=new Dictionary<string,int>(StringComparer.Ordinal);
        var acceptedEliteStarts=new Dictionary<string,int>(StringComparer.Ordinal);
        foreach(var family in Families)
        {
            if(!rows.TryGetValue(family.SheetRow,out var row))
                throw new InvalidDataException("Army family has no recovered upgrade row.");
            var counts=row.GetProperty("SPAWNS").GetString()?.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            if(counts==null || counts.Length!=family.Options.Count)
                throw new InvalidDataException("Army spawn options differ from recovered sheet.");
            int power=row.GetProperty("TOTALPOWER").GetInt32();
            float cooldown=row.GetProperty("COOLDOWN").GetSingle();
            float movementSpeed=row.GetProperty("MOVEMENTSPEED").GetSingle();
            if(!float.IsFinite(movementSpeed) || movementSpeed<=0 || movementSpeed>20 ||
               family.MovementSpeed!=movementSpeed)
                throw new InvalidDataException("Army runtime movement speed differs from recovered sheet.");
            for(int i=0;i<counts.Length;i++)
            {
                if(!int.TryParse(counts[i],System.Globalization.NumberStyles.None,
                    System.Globalization.CultureInfo.InvariantCulture,out int count) ||
                   count!=family.Options[i].Count ||
                   checked(count*power)!=family.Options[i].Power ||
                   count*cooldown!=family.Options[i].Cooldown)
                    throw new InvalidDataException("Army option differs from recovered runtime row.");
            }
            if(!sourceSheets.TryGetValue(family.SheetRow,out var stageSheet))
                throw new InvalidDataException("Army normal-upgrade sheet is absent.");
            var stageRows=stageSheet.GetProperty("rows");
            if(stageRows.GetArrayLength() is < 1 or > 256)
                throw new InvalidDataException("Army normal-upgrade stage count is invalid.");
            int normalLaneEnd=row.GetProperty("STARTINGSPECIAL").GetInt32();
            int eliteLaneStart=row.GetProperty("STARTINGELITE").GetInt32();
            if(normalLaneEnd is < 1 or > 255 || normalLaneEnd>=stageRows.GetArrayLength() ||
               (eliteLaneStart!=-1 && (eliteLaneStart<=normalLaneEnd || eliteLaneStart>=stageRows.GetArrayLength())))
                throw new InvalidDataException("Army upgrade lane offsets differ from recovered source.");
            var stages=new ArmyBaseCombatStats[stageRows.GetArrayLength()];
            var shots=new ArmyUpgradeShotStats[stageRows.GetArrayLength()];
            var specials=new float[stageRows.GetArrayLength()];
            var cannons=family.UnitId=="ID_UNIT-BUGGY"?new ArmyVehicleCannonStats[stageRows.GetArrayLength()]:null;
            for(int i=0;i<stages.Length;i++)
            {
                var stage=stageRows[i];
                float hp=stage.GetProperty("HP").GetSingle();
                float damage=stage.GetProperty("DAMAGE").GetSingle();
                int batchMin=stage.GetProperty("BATCHSIZEMIN").GetInt32();
                int batchMax=stage.GetProperty("BATCHSIZEMAX").GetInt32();
                float frequencyMin=stage.GetProperty("SHOTFREQUENCYMIN").GetSingle();
                float frequencyMax=stage.GetProperty("SHOTFREQUENCYMAX").GetSingle();
                float probability=stage.GetProperty("REALSHOTPROBABILITY").GetSingle();
                float specialValue=stage.GetProperty("SPECIAL").GetSingle();
                // Recovered tables contain zeroed upgrade-lane sentinel rows between
                // normal and elite ranges; never turn one into a live combat entity.
                if(!float.IsFinite(hp) || hp<0 || !float.IsFinite(damage) || damage<0 ||
                   batchMin<0||batchMax<batchMin||batchMax>32||
                   !float.IsFinite(frequencyMin)||!float.IsFinite(frequencyMax)||
                   frequencyMin<0||frequencyMax<frequencyMin||frequencyMax>60||
                   !float.IsFinite(probability)||probability<0||probability>10||
                   !float.IsFinite(specialValue)||Math.Abs(specialValue)>1_000_000)
                    throw new InvalidDataException("Army normal-upgrade combat stat is invalid.");
                stages[i]=new ArmyBaseCombatStats(hp,damage);
                shots[i]=new ArmyUpgradeShotStats(probability,batchMin,batchMax,frequencyMin,frequencyMax);
                specials[i]=specialValue;
                if(cannons!=null)
                {
                    float cannonDamage=stage.GetProperty("CANNONDAMAGE").GetSingle();
                    float cannonMin=stage.GetProperty("SHOTFREQUENCYMINCANNON").GetSingle();
                    float cannonMax=stage.GetProperty("SHOTFREQUENCYMAXCANNON").GetSingle();
                    if(!float.IsFinite(cannonDamage)||cannonDamage<0||!float.IsFinite(cannonMin)||
                       !float.IsFinite(cannonMax)||cannonMin<0||cannonMax<cannonMin||cannonMax>60)
                        throw new InvalidDataException("Buggy cannon upgrade stage is invalid.");
                    cannons[i]=new(cannonDamage,cannonMin,cannonMax);
                }
            }
            acceptedStats.Add(family.UnitId,Array.AsReadOnly(stages));
            acceptedShots.Add(family.UnitId,Array.AsReadOnly(shots));
            acceptedSpecials.Add(family.UnitId,Array.AsReadOnly(specials));
            acceptedLaneEnds.Add(family.UnitId,normalLaneEnd);
            acceptedEliteStarts.Add(family.UnitId,eliteLaneStart);
            if(cannons!=null)acceptedBuggyCannons=cannons;
        }
        baseStats=acceptedStats;
        buggyCannonStages=acceptedBuggyCannons is null?null:Array.AsReadOnly(acceptedBuggyCannons);
        upgradeShots=acceptedShots;
        specialValues=acceptedSpecials;
        normalLaneEnds=acceptedLaneEnds;
        eliteLaneStarts=acceptedEliteStarts;
    }

    public static ArmyDeploymentCatalog Load(string path,string expectedRevision,string expectedSceneRevision)
    {
        var bytes=File.ReadAllBytes(path);
        if(bytes.Length is < 100 or > 65536 ||
           Convert.ToHexStringLower(SHA256.HashData(bytes))!=expectedRevision)
            throw new InvalidDataException("Army deployment revision mismatch.");
        using var document=JsonDocument.Parse(bytes,new JsonDocumentOptions{MaxDepth=8});
        var root=document.RootElement;
        Exact(root,"version","sceneSha256","runtimeRule","maxEnergy","sendUnitsBaseCooldown","infantryAgent","families");
        if(root.GetProperty("version").GetInt32()!=1 ||
           root.GetProperty("sceneSha256").GetString()!=expectedSceneRevision ||
           root.GetProperty("runtimeRule").GetString()!=
           "SpawningManagerDeathMatch.InstanceOnPlayerDataLoaded replaces serialized unitsCounts with ArmyUpgrades.SPAWNS and reindexes all options")
            throw new InvalidDataException("Army deployment does not bind recovered scene/runtime rules.");
        float energy=root.GetProperty("maxEnergy").GetSingle();
        float baseCooldown=root.GetProperty("sendUnitsBaseCooldown").GetSingle();
        if(energy!=8 || baseCooldown!=1)throw new InvalidDataException("Wrong recovered army constants.");
        var agent=root.GetProperty("infantryAgent");
        Exact(agent,"prefabSha256","radius","acceleration","angularSpeed","height",
            "stoppingDistance","autoBraking","autoRepath","obstacleAvoidanceType");
        var infantryAgent=new ArmyAgentConfig(agent.GetProperty("prefabSha256").GetString()??"",
            agent.GetProperty("radius").GetSingle(),agent.GetProperty("acceleration").GetSingle(),
            agent.GetProperty("angularSpeed").GetSingle(),agent.GetProperty("height").GetSingle(),
            agent.GetProperty("stoppingDistance").GetSingle(),
            agent.GetProperty("autoBraking").GetBoolean(),agent.GetProperty("autoRepath").GetBoolean(),
            agent.GetProperty("obstacleAvoidanceType").GetInt32());
        if(!System.Text.RegularExpressions.Regex.IsMatch(infantryAgent.PrefabSha256,@"\A[0-9a-f]{64}\z") ||
           infantryAgent.Radius!=.17f || infantryAgent.Acceleration!=10f ||
           infantryAgent.AngularSpeed!=600f || infantryAgent.Height!=.52f ||
           infantryAgent.StoppingDistance!=0 || !infantryAgent.AutoBraking ||
           !infantryAgent.AutoRepath || infantryAgent.ObstacleAvoidanceType!=1)
            throw new InvalidDataException("Recovered infantry NavMeshAgent settings changed.");
        var entries=root.GetProperty("families");
        if(entries.GetArrayLength()!=24)throw new InvalidDataException("Incomplete army family set.");
        var familyIds=new HashSet<int>();var slotIds=new HashSet<int>();
        var unitIds=new HashSet<string>(StringComparer.Ordinal);
        int rusherCount=0;
        var accepted=new ArmyDeploymentFamily[24];
        var byOption=new Dictionary<int,ArmyDeploymentOption>();
        for(int i=0;i<24;i++)
        {
            var entry=entries[i];
            bool rusher=RusherTypes.Contains(entry.GetProperty("behaviorType").GetString()??"");
            bool infantryShooter=rusher ||
                (entry.GetProperty("behaviorType").GetString()??"")=="SoldierBehaviourMinigunner";
            bool vehicle=!entry.GetProperty("isSoldier").GetBoolean() &&
                (entry.GetProperty("behaviorType").GetString()??"")!="MechBehaviour";
            if(rusher)rusherCount++;
            if(infantryShooter)Exact(entry,"behaviorFileId","behaviorType","upgradeSlotsFileId","unitId","sheetRow","unitType",
                "spawnPointMask","maxGeneratedCount","baseSpeed","baseShot","movementSpeed","isSoldier","isAir","options");
            else if(vehicle)Exact(entry,"behaviorFileId","behaviorType","upgradeSlotsFileId","unitId","sheetRow","unitType",
                "spawnPointMask","maxGeneratedCount","baseSpeed","movementSpeed","vehicleShot","isSoldier","isAir","options");
            else Exact(entry,"behaviorFileId","behaviorType","upgradeSlotsFileId","unitId","sheetRow","unitType",
                "spawnPointMask","maxGeneratedCount","baseSpeed","movementSpeed","isSoldier","isAir","options");
            int behavior=entry.GetProperty("behaviorFileId").GetInt32();
            string behaviorType=entry.GetProperty("behaviorType").GetString()??"";
            int slot=entry.GetProperty("upgradeSlotsFileId").GetInt32();
            string unit=entry.GetProperty("unitId").GetString()??"";
            string row=entry.GetProperty("sheetRow").GetString()??"";
            int type=entry.GetProperty("unitType").GetInt32();
            int spawnMask=entry.GetProperty("spawnPointMask").GetInt32();
            int capacity=entry.GetProperty("maxGeneratedCount").GetInt32();
            float baseSpeed=entry.GetProperty("baseSpeed").GetSingle();
            float movementSpeed=entry.GetProperty("movementSpeed").GetSingle();
            bool soldier=entry.GetProperty("isSoldier").GetBoolean();
            ArmyBaseShotStats? baseShot=null;
            ArmyVehicleShotStats? vehicleShot=null;
            if(infantryShooter)
            {
                var shot=entry.GetProperty("baseShot");
                Exact(shot,"probabilityOfRealShot","fireBatchSizeMin","fireBatchSizeMax",
                    "minShootTime","maxShootTime");
                baseShot=new(shot.GetProperty("probabilityOfRealShot").GetSingle(),
                    shot.GetProperty("fireBatchSizeMin").GetInt32(),
                    shot.GetProperty("fireBatchSizeMax").GetInt32(),
                    shot.GetProperty("minShootTime").GetSingle(),
                    shot.GetProperty("maxShootTime").GetSingle());
                if(!float.IsFinite(baseShot.ProbabilityOfRealShot) ||
                   baseShot.ProbabilityOfRealShot is < 0 or > 1 ||
                   baseShot.FireBatchSizeMin<1 || baseShot.FireBatchSizeMax>14 ||
                   baseShot.FireBatchSizeMin>baseShot.FireBatchSizeMax ||
                   !float.IsFinite(baseShot.MinShootTime) || !float.IsFinite(baseShot.MaxShootTime) ||
                   baseShot.MinShootTime<0 || baseShot.MaxShootTime>60 ||
                   baseShot.MinShootTime>baseShot.MaxShootTime)
                    throw new InvalidDataException("Invalid recovered infantry base shot definition.");
            }
            if(vehicle)
            {
                var shot=entry.GetProperty("vehicleShot");
                Exact(shot,"shotSpeed","probabilityOfRealShot","fireBatchSizeMin","fireBatchSizeMax",
                    "minShootTime","maxShootTime","crew");
                var crewValue=shot.GetProperty("crew").GetSingle();
                if(!float.IsFinite(crewValue) || crewValue<0 || crewValue>int.MaxValue || crewValue!=MathF.Truncate(crewValue))
                    throw new InvalidDataException("Invalid recovered vehicle crew count.");
                vehicleShot=new(shot.GetProperty("shotSpeed").GetSingle(),shot.GetProperty("probabilityOfRealShot").GetSingle(),
                    shot.GetProperty("fireBatchSizeMin").GetInt32(),shot.GetProperty("fireBatchSizeMax").GetInt32(),
                    shot.GetProperty("minShootTime").GetSingle(),shot.GetProperty("maxShootTime").GetSingle(),(int)crewValue);
                if(!float.IsFinite(vehicleShot.ShotSpeed) || vehicleShot.ShotSpeed<=0 ||
                   !float.IsFinite(vehicleShot.ProbabilityOfRealShot) || vehicleShot.ProbabilityOfRealShot is <0 or >1 ||
                   vehicleShot.FireBatchSizeMin<0 || vehicleShot.FireBatchSizeMax>14 ||
                   vehicleShot.FireBatchSizeMin>vehicleShot.FireBatchSizeMax || vehicleShot.Crew<0)
                    throw new InvalidDataException("Invalid recovered vehicle shot definition.");
            }
            if(behavior<=0 || slot<=0 || !familyIds.Add(behavior) || !slotIds.Add(slot) ||
               !System.Text.RegularExpressions.Regex.IsMatch(behaviorType,@"\A[A-Za-z][A-Za-z0-9]{1,60}\z") ||
               !System.Text.RegularExpressions.Regex.IsMatch(unit,@"\AID_UNIT-[A-Z0-9-]{1,50}\z") || !unitIds.Add(unit) ||
               !System.Text.RegularExpressions.Regex.IsMatch(row,@"\AGoogle2u.DBUpgradeSlots[A-Za-z0-9]{1,40}\z") ||
               type is < 0 or > 10 || capacity is < 0 or > 100 ||
               !float.IsFinite(baseSpeed) || baseSpeed is <= 0 or > 20 ||
               !float.IsFinite(movementSpeed) || movementSpeed is <= 0 or > 20 ||
               (soldier ? spawnMask is not (1 or 2 or 3) : spawnMask!=0))
                throw new InvalidDataException("Invalid recovered army family identity or limit.");
            var options=entry.GetProperty("options");
            if(options.GetArrayLength() is < 1 or > 8)throw new InvalidDataException("Invalid army option count.");
            var familyOptions=new ArmyDeploymentOption[options.GetArrayLength()];
            for(int j=0;j<familyOptions.Length;j++)
            {
                var option=options[j];Exact(option,"index","count","power","cooldown");
                int index=option.GetProperty("index").GetInt32();
                int count=option.GetProperty("count").GetInt32();
                int power=option.GetProperty("power").GetInt32();
                float cooldown=option.GetProperty("cooldown").GetSingle();
                if(index!=byOption.Count || count is < 1 or > 100 || power is < 1 or > 1000 ||
                   !float.IsFinite(cooldown) || cooldown is < 0 or > 1000)
                    throw new InvalidDataException("Invalid recovered army option.");
                var acceptedOption=new ArmyDeploymentOption(index,count,power,cooldown);
                byOption.Add(index,acceptedOption);familyOptions[j]=acceptedOption;
            }
            accepted[i]=new(behavior,behaviorType,slot,unit,row,type,spawnMask,capacity,baseSpeed,movementSpeed,
                soldier,entry.GetProperty("isAir").GetBoolean(),
                Array.AsReadOnly(familyOptions),baseShot,vehicleShot);
        }
        if(byOption.Count!=48 || rusherCount!=6)
            throw new InvalidDataException("Incomplete runtime army options or Rusher definitions.");
        var vehicleSpeeds=new Dictionary<string,float>(StringComparer.Ordinal)
        {
            ["ID_UNIT-HELICOPTER"]=3f,["ID_UNIT-HUMVEE"]=1.7f,
            ["ID_UNIT-DRONE"]=.87f,["ID_UNIT-TANK"]=1f,
            ["ID_UNIT-BUGGY"]=1.7f,["ID_UNIT-ASSAULTHELI"]=.87f,
            ["ID_UNIT-TRANSPORTER"]=1.7f
        };
        foreach(var (unit,speed) in vehicleSpeeds)
        {
            var family=accepted.SingleOrDefault(f=>f.UnitId==unit);
            if(family==null || family.IsSoldier || family.MovementSpeed!=speed)
                throw new InvalidDataException("Incomplete recovered vehicle family contract.");
        }
        var vehicleCaps=new Dictionary<string,int>(StringComparer.Ordinal)
        {["ID_UNIT-HELICOPTER"]=1,["ID_UNIT-HUMVEE"]=1,["ID_UNIT-DRONE"]=2,
         ["ID_UNIT-TANK"]=1,["ID_UNIT-BUGGY"]=1,["ID_UNIT-ASSAULTHELI"]=1,
         ["ID_UNIT-TRANSPORTER"]=1};
        foreach(var (unit,cap) in vehicleCaps)
            if(accepted.Single(f=>f.UnitId==unit).MaxGeneratedCount!=cap)
                throw new InvalidDataException("Recovered vehicle generation cap changed.");
        return new(expectedRevision,energy,baseCooldown,infantryAgent,Array.AsReadOnly(accepted),byOption);
    }

    private static void Exact(JsonElement value,params string[] fields)
    {
        if(value.ValueKind!=JsonValueKind.Object || value.EnumerateObject().Select(p=>p.Name).Order().SequenceEqual(fields.Order())==false)
            throw new InvalidDataException("Unexpected army catalog field set.");
    }
}
