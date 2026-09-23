using System.Numerics;

namespace War.BattleServer;

/// <summary>Source behavior class routing over the pinned map spawn collections.</summary>
public sealed class ArmySpawnPointSelector
{
    private readonly ArmySpawnPointCatalog catalog;
    private int minigunnerPointSelections;
    public ArmySpawnPointSelector(ArmySpawnPointCatalog catalog)
        =>this.catalog=catalog??throw new ArgumentNullException(nameof(catalog));

    public bool CanSelect(RecoveredBattleMap map,ArmyDeploymentFamily family,int fraction,
        Func<ArmySpawnPoint,bool> pathAvailable)
        =>AvailableSlots(map,family,fraction,pathAvailable)>0;

    public int AvailableSlots(RecoveredBattleMap map,ArmyDeploymentFamily family,int fraction,
        Func<ArmySpawnPoint,bool> pathAvailable)
    {
        if(fraction is not (1 or 2))throw new ArgumentOutOfRangeException(nameof(fraction));
        ArgumentNullException.ThrowIfNull(pathAvailable);
        var candidates=Candidates(map,family,fraction,pathAvailable);
        if(candidates.Length==0)return 0;
        if(family.IsSoldier || family.BehaviorType=="MechBehaviour")return int.MaxValue;
        return candidates.Select(p=>p.ReservationFileId).Distinct().Count();
    }

    public ArmySpawnPoint? Select(RecoveredBattleMap map,ArmyDeploymentFamily family,int fraction,
        Vector3 opponentPosition,Func<int,int> choose,Func<ArmySpawnPoint,bool> pathAvailable)
    {
        if(fraction is not (1 or 2) || !PlayerHitbox.Finite(opponentPosition))
            throw new ArgumentOutOfRangeException(nameof(fraction));
        ArgumentNullException.ThrowIfNull(choose);
        ArgumentNullException.ThrowIfNull(pathAvailable);
        var candidates=Candidates(map,family,fraction,pathAvailable);
        if(candidates.Length==0)return null;
        if(family.BehaviorType=="MechBehaviour")return candidates[0];
        if(family.BehaviorType=="SoldierBehaviourMinigunner")
        {
            // The source's static comparator alternates on every selection.
            // Keep its mutable parity match-local so concurrent matches cannot
            // change one another's spawn order.
            bool even=minigunnerPointSelections++%2==0;
            var sorted=candidates.ToList();
            sorted.Sort((a,b)=>
            {
                float first=Vector3.DistanceSquared(opponentPosition,a.Position);
                if(even)first=0;
                float second=Vector3.DistanceSquared(opponentPosition,b.Position);
                if(!even)second=0;
                return second.CompareTo(first);
            });
            return sorted[0];
        }
        if(family.BehaviorType is "SoldierBehaviourCommando" or "SoldierBehaviourWarper" or
           "SoldierBehaviourShotgunner" or "SoldierBehaviourSwat" or "SoldierBehaviourFlamethrower")
            return candidates.OrderByDescending(p=>Vector3.DistanceSquared(p.Position,opponentPosition))
                .ThenBy(p=>p.Order).First();
        if(family.BehaviorType is "SoldierBehaviourAssaulter" or "SoldierBehaviourParachuter" or
           "SoldierBehaviourGrennader" or "SoldierBehaviourSciFi")
        {
            var parachute=candidates.FirstOrDefault(p=>p.ComponentType=="SpawnPointParachute");
            if(parachute!=null)return parachute;
        }
        int choiceCount=family.BehaviorType=="DroneBehaviour" && candidates.Length>2 ? 2 : candidates.Length;
        int chosen=family.BehaviorType=="DroneBehaviour" && candidates.Length<=2 ? 0 : choose(choiceCount);
        if(chosen<0 || chosen>=choiceCount)throw new InvalidDataException("Invalid host spawn random choice.");
        return candidates[chosen];
    }

    private ArmySpawnPoint[] Candidates(RecoveredBattleMap map,ArmyDeploymentFamily family,int fraction,
        Func<ArmySpawnPoint,bool> pathAvailable)
    {
        string category=Collection(family.BehaviorType);
        return catalog.ForMap(map).Where(point=>point.Collection==category && point.Fraction==fraction &&
            (family.IsSoldier ? PointMask(point.ComponentType)!=0 &&
                                (family.SpawnPointMask & PointMask(point.ComponentType))==PointMask(point.ComponentType)
                              : family.BehaviorType=="MechBehaviour" ? point.ComponentType=="SpawnPoint"
                              : pathAvailable(point))).ToArray();
    }

    private static int PointMask(string componentType)=>componentType switch
    {"SpawnPoint"=>1,"SpawnPointParachute"=>2,_=>0};

    internal static string Collection(string behaviorType)=>behaviorType switch
    {
        "HelicopterBehaviour"=>"spawnPointsCollectionHelicopters",
        "DroneBehaviour"=>"spawnPointsCollectionDrones",
        "AssaultHelicopterBehaviour"=>"spawnPointsCollectionAssaultHelis",
        "CarBehaviour" or "CarBuggyBehaviour" or "CarTransporterBehaviour" or "TankBehaviour"
            =>"spawnPointsCollectionCars",
        "MechBehaviour"=>"spawnPointsCollection",
        _ when behaviorType.StartsWith("SoldierBehaviour",StringComparison.Ordinal)=>"spawnPointsCollection",
        _=>throw new InvalidDataException("Unknown source army spawn behavior.")
    };
}
