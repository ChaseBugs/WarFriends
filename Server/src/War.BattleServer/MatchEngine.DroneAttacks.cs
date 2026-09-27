using System.Numerics;
namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly Dictionary<ulong,DroneAttackState> droneAttacks=[];
    private readonly DroneWeaponCatalog? droneWeapon;
    private readonly DroneProjectileCatalog? droneProjectile;
    internal float? DroneAttackDeadline(ulong key)=>droneAttacks.GetValueOrDefault(key)?.Deadline;
    private int DroneBatchRange(int minimum,int maximum)
    {
        if(minimum==maximum)return minimum;
        int choice=armyChoice(maximum-minimum);
        if(choice<0||choice>=maximum-minimum)throw new InvalidDataException("Invalid Drone batch integer sample.");
        return minimum+choice;
    }
    internal DroneTargetDetails ResolveDroneShotTarget(DroneTargetCandidate target)
    {
        if(target.Id.StartsWith("player:",StringComparison.Ordinal))
        {
            string id=target.Id[7..];var player=Find(id)??throw new InvalidDataException("Drone player target disappeared.");
            if(rifleCombat==null||playerShotTargets==null||map==null)
                throw new InvalidDataException("Drone player target lacks source poses.");
            var pose=rifleCombat.Pose(id);
            var rows=playerShotTargets.Gameplay.Select(t=>new DroneShotTarget(t.TransformFileId,t.Type,
                pose.BodyTarget(t.TransformFileId).Position)).ToArray();
            return new(Array.AsReadOnly(rows),true,player.Position,
                -Vector3.Transform(Vector3.UnitZ,map.Covers[player.Cover].Rotation),player.Route==null,Vector3.Zero);
        }
        if(target.Id.StartsWith("decoy:",StringComparison.Ordinal)&&ulong.TryParse(target.Id.AsSpan(6),out ulong decoyId))
        {
            var row=decoys.Snapshot().SingleOrDefault(x=>x.EntityId==decoyId);
            if(row==null||decoySource==null)throw new InvalidDataException("Drone Decoy target disappeared.");
            var rotation=Quaternion.CreateFromAxisAngle(Vector3.UnitY,MathF.Atan2(row.Facing.X,row.Facing.Z));
            var source=decoySource.Prefab;
            return new([new(source.TargetTransformFileId,1,row.Position+Vector3.Transform(source.TargetLocalPosition,rotation))],
                false,row.Position,Vector3.Zero,false,Vector3.Zero);
        }
        if(target.Id.StartsWith("army:",StringComparison.Ordinal)&&ulong.TryParse(target.Id.AsSpan(5),out ulong key)&&
           activeArmyEntities.TryGetValue(key,out var army))
        {
            var position=new Vector3(army.X,army.Y,army.Z);
            if(InfantryShotTargets(key) is { } targets)
                return new(targets,false,position,Vector3.Zero,false,InfantryVelocity(key));
            if(armyDronePaths.TryGetValue(key,out var drone))
                return new([new(454360,1,position)],false,position,Vector3.Zero,false,
                    drone.Velocity*MatchManifest.TickRate);
            if(vehicles?.TryGet(key,out var vehicle)==true&&vehicle!=null&&groundVehicleWeapons!=null)
            {
                var rig=groundVehicleWeapons.For(vehicle.UnitId);
                return new([new(rig.ShotTargetTransformFileId,1,position+rig.ShotTarget)],false,position,
                    Vector3.Zero,false,groundVehicleVelocities.GetValueOrDefault(key));
            }
        }
        throw new InvalidDataException("Drone target has no verified runtime aim binding.");
    }
}
