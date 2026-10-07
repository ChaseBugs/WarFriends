using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace War.BattleServer;

internal sealed record CollisionPlayer(string PlayerId, PlayerCollisionModel Pose,int Layer=-1,int Fraction=0);
internal sealed record DynamicShotTarget(ulong EntityId,int PartComponentFileId,int Layer,PlayerHitbox Hitbox,
    string? PassengerRole=null,int? RepairDronePathIndex=null,bool ArmyInfantry=false,bool Decoy=false,bool HeavyTurret=false,bool HelicopterGunner=false,bool GroundVehicleBody=false,bool HelicopterBody=false,bool DroneRoot=false,bool AssaultGlass=false);
internal sealed record ShotCollision(float Distance, Vector3 Position, string SourcePath, string? PlayerId, float PartWeight, bool Static = false,string? DynamicOwner=null,int? ColliderIndex=null,ulong? DynamicEntityId=null,int? DynamicPartId=null,string? DynamicPassengerRole=null,int? DynamicRepairDronePathIndex=null,bool DynamicArmyInfantry=false,bool DynamicDecoy=false,bool DynamicHeavyTurret=false,bool DynamicHelicopterGunner=false,int? ColliderLayer=null,bool SourceDestroyable=false);

// Input poses come exclusively from host animation/pose authority. This class has
// no network adapter and no client-submitted target player or damage parameter.
internal sealed class ShotCollisionWorld
{
    private readonly RecoveredBattleMap? map;
    private readonly CollisionPlayer[] players;
    private readonly Func<string,bool>? dynamicEnabled;
    private readonly Func<int,bool>? colliderEnabled;
    private readonly Func<int,int,int>? runtimeLayer;
    private readonly Func<string,IReadOnlyList<DynamicShotTarget>>? dynamicTargets;
    internal ShotCollisionWorld(RecoveredBattleMap? map, IEnumerable<CollisionPlayer> players,
        Func<string,bool>? dynamicEnabled=null,Func<int,bool>? colliderEnabled=null,
        Func<int,int,int>? runtimeLayer=null,Func<string,IReadOnlyList<DynamicShotTarget>>? dynamicTargets=null)
    {
        this.map = map;this.dynamicEnabled=dynamicEnabled;this.colliderEnabled=colliderEnabled;
        this.runtimeLayer=runtimeLayer;this.dynamicTargets=dynamicTargets;
        this.players = players.Take(3).ToArray();
        if (this.players.Length != 2 || this.players.Any(p => p == null || p.Pose == null || p.Pose.Role != "gameplay" ||
            !Guid.TryParseExact(p.PlayerId, "N", out _) || p.PlayerId != p.PlayerId.ToLowerInvariant() ||
            p.Layer is not (-1 or 22 or 23) || p.Fraction is <0 or >2) ||
            this.players[0].PlayerId == this.players[1].PlayerId)
            throw new InvalidDataException("Expected two distinct host-owned gameplay collision poses.");
    }
    internal ShotCollision? Raycast(string shooterId, Vector3 origin, Vector3 direction, float range, uint mapLayerMask = uint.MaxValue)
    {
        if (!players.Any(p => p.PlayerId == shooterId)) throw new InvalidDataException("Unknown shot owner.");
        if (!PlayerHitbox.Finite(origin) || !PlayerHitbox.Finite(direction) || direction.LengthSquared()<1e-12f ||
            !float.IsFinite(range) || range is <= 0 or > 10000) throw new InvalidDataException("Invalid server shot ray.");
        // Static geometry wins a distance tie: never shoot through a surface to
        // an overlapping player. Disabled reference colliders are never promoted.
        direction = Vector3.Normalize(direction);
        var geometry = map?.Raycast(origin, direction, range, mapLayerMask,dynamicEnabled,colliderEnabled,runtimeLayer);
        ShotCollision? nearest = geometry == null ? null : new(geometry.Distance, geometry.Position, geometry.SourcePath, null, 0, geometry.Layer is 13 or 30,geometry.DynamicOwner,geometry.ColliderIndex,ColliderLayer:geometry.Layer,
            SourceDestroyable:geometry.Layer==24&&geometry.DynamicOwner!=null);
        foreach (var player in players)
        {
            if (player.PlayerId == shooterId) continue;
            if(player.Layer>=0&&(mapLayerMask&(1u<<player.Layer))==0)continue;
            var hit = player.Pose.Raycast(origin, direction, range);
            if (hit != null && (nearest == null || hit.Distance < nearest.Distance))
                nearest = new(hit.Distance, hit.Position, hit.PartPath, player.PlayerId, hit.Weight,
                    ColliderLayer:player.Layer>=0?player.Layer:null,
                    SourceDestroyable:player.Layer is 22 or 23);
        }
        if(dynamicTargets!=null)
            foreach(var target in dynamicTargets(shooterId))
            {
                if(target==null||target.EntityId==0||target.Layer is <0 or >31||target.Hitbox==null||
                   target.RepairDronePathIndex is <0 or >1||
                   (target.PassengerRole==null&&target.RepairDronePathIndex==null&&!target.ArmyInfantry&&!target.Decoy&&!target.HeavyTurret&&!target.HelicopterGunner&&target.PartComponentFileId<=0)||
                   (target.HelicopterGunner&&(target.PartComponentFileId!=0||target.PassengerRole!=null||
                       target.RepairDronePathIndex!=null||target.ArmyInfantry||target.Decoy||target.HeavyTurret))||
                   (target.PassengerRole!=null&&(target.PartComponentFileId!=0||target.RepairDronePathIndex!=null||
                       target.ArmyInfantry||target.Decoy||target.HeavyTurret||target.PassengerRole.Length is <1 or >32||target.PassengerRole.Any(char.IsControl)))||
                   (target.RepairDronePathIndex!=null&&(target.PartComponentFileId!=0||target.PassengerRole!=null||target.ArmyInfantry||target.Decoy||target.HeavyTurret))||
                   (target.ArmyInfantry&&(target.PartComponentFileId!=0||target.PassengerRole!=null||target.RepairDronePathIndex!=null||target.Decoy||target.HeavyTurret))||
                   (target.Decoy&&(target.PartComponentFileId!=0||target.PassengerRole!=null||target.RepairDronePathIndex!=null||target.ArmyInfantry||target.HeavyTurret))||
                   (target.HeavyTurret&&(target.PartComponentFileId<=0||target.PassengerRole!=null||target.RepairDronePathIndex!=null||target.ArmyInfantry||target.Decoy)))
                    throw new InvalidDataException("Invalid host dynamic shot target.");
                if(target.AssaultGlass &&
                   (target.PartComponentFileId!=
                        AssaultHelicopterMeshColliderCatalog.FrontGlassColliderFileId ||
                    target.Layer!=8 ||
                    target.PassengerRole!=null || target.RepairDronePathIndex!=null ||
                    target.ArmyInfantry || target.Decoy || target.HeavyTurret ||
                    target.HelicopterGunner || target.GroundVehicleBody ||
                    target.HelicopterBody || target.DroneRoot))
                    throw new InvalidDataException("Invalid Assault Helicopter glass target.");
                if((mapLayerMask&(1u<<target.Layer))==0)continue;
                var distance=target.Hitbox.Raycast(origin,direction,range);
                if(distance.HasValue&&(nearest==null||distance.Value<nearest.Distance))
                    nearest=new(distance.Value,origin+direction*distance.Value,target.Hitbox.SourcePath,null,
                        target.Hitbox.Weight,DynamicEntityId:target.EntityId,
                        DynamicPartId:target.PartComponentFileId>0?target.PartComponentFileId:null,
                        DynamicPassengerRole:target.PassengerRole,
                        DynamicRepairDronePathIndex:target.RepairDronePathIndex,
                        DynamicArmyInfantry:target.ArmyInfantry,DynamicDecoy:target.Decoy,
                        DynamicHeavyTurret:target.HeavyTurret,DynamicHelicopterGunner:target.HelicopterGunner,
                        ColliderLayer:target.Layer,
                        SourceDestroyable:target.Layer is 8 or 22 or 23 or 24 or 26 or 27 &&
                            (target.DroneRoot||target.GroundVehicleBody||target.HelicopterBody||target.AssaultGlass||
                             target.PassengerRole!=null||target.RepairDronePathIndex!=null||
                             target.ArmyInfantry||target.Decoy||target.HeavyTurret||target.HelicopterGunner));
            }
        return nearest;
    }
    internal IReadOnlyList<ShotgunCollider> OverlapEnemy(string shooterId,Vector3 origin,float radius,
        uint layerMask=uint.MaxValue)
    {
        if(!PlayerHitbox.Finite(origin) || !float.IsFinite(radius) || radius is <=0 or >100)
            throw new InvalidDataException("Invalid shotgun overlap query.");
        var shooter=players.SingleOrDefault(p=>p.PlayerId==shooterId);
        if(shooter==null)
            throw new InvalidDataException("Unknown shotgun shooter.");
        var enemy=players.Single(p=>p.PlayerId!=shooterId);
        if(shooter.Pose.PoseKind=="serialized-reference-only" || enemy.Pose.PoseKind=="serialized-reference-only")
            throw new InvalidDataException("Shotgun overlap needs current host player poses.");
        var result=enemy.Pose.Parts.Where(p=>(enemy.Layer<0||(layerMask&(1u<<enemy.Layer))!=0)&&
                p.OverlapsSphere(origin,radius))
            .Select(p=>new ShotgunCollider(Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(p.SourcePath))),
                enemy.PlayerId,p.Center,true)).ToList();
        if(map!=null&&dynamicEnabled!=null&&shooter.Fraction is 1 or 2)
        {
            var opposingShields=map.Covers.Where(c=>c.Fraction!=shooter.Fraction)
                .ToDictionary(c=>c.SourcePath+"/riot_shield",StringComparer.Ordinal);
            foreach(var shield in map.DynamicSphereOverlaps(origin,radius,layerMask,colliderEnabled,runtimeLayer))
            {
                if(shield.Layer!=24||!opposingShields.ContainsKey(shield.DynamicOwner)||
                   !dynamicEnabled(shield.DynamicOwner))continue;
                var center=(shield.BoundsMin+shield.BoundsMax)*.5f;
                string identity="shield:"+opposingShields[shield.DynamicOwner].SourceIndex;
                string collider=identity+":"+shield.ColliderIndex;
                result.Add(new ShotgunCollider(Convert.ToHexStringLower(SHA256.HashData(
                    Encoding.UTF8.GetBytes(collider))),identity,center,true));
                if(result.Count>128)throw new InvalidDataException("Shotgun overlap exceeded source candidate bound.");
            }
        }
        var dynamicColliderOrdinals=new Dictionary<string,int>(StringComparer.Ordinal);
        if(dynamicTargets!=null)
            foreach(var target in dynamicTargets(shooterId))
            {
                if(target==null||target.EntityId==0||target.Layer is <0 or >31||target.Hitbox==null)
                    throw new InvalidDataException("Invalid shotgun dynamic overlap authority.");
                // Source vehicle bodies, repair-drone roots, Heavy Turrets,
                // Decoys, and infantry own opposing DestroyableObject colliders.
                bool vehicleBody=target.GroundVehicleBody&&target.PartComponentFileId>0&&
                    !target.HeavyTurret&&!target.Decoy&&!target.ArmyInfantry&&!target.HelicopterBody&&!target.DroneRoot&&
                    target.PassengerRole==null&&target.RepairDronePathIndex==null&&
                    !target.HelicopterGunner;
                bool repairDrone=target.RepairDronePathIndex is 0 or 1&&
                    target.PartComponentFileId==0&&target.PassengerRole==null&&
                    !target.Decoy&&!target.ArmyInfantry&&!target.HeavyTurret&&
                    !target.HelicopterGunner&&!target.GroundVehicleBody&&!target.HelicopterBody&&!target.DroneRoot;
                bool passenger=target.PassengerRole is {Length:>0 and <=32}&&
                    !target.PassengerRole.Any(char.IsControl)&&target.PartComponentFileId==0&&
                    target.RepairDronePathIndex==null&&!target.Decoy&&!target.ArmyInfantry&&
                    !target.HeavyTurret&&!target.HelicopterGunner&&!target.GroundVehicleBody&&!target.HelicopterBody&&!target.DroneRoot;
                bool heavyTurret=target.HeavyTurret&&target.PartComponentFileId>0&&
                    target.PassengerRole==null&&target.RepairDronePathIndex==null&&
                    !target.Decoy&&!target.ArmyInfantry&&!target.HelicopterGunner&&
                    !target.GroundVehicleBody&&!target.HelicopterBody&&!target.DroneRoot;
                bool helicopterBody=target.HelicopterBody&&target.PartComponentFileId>0&&
                    target.PassengerRole==null&&target.RepairDronePathIndex==null&&
                    !target.Decoy&&!target.ArmyInfantry&&!target.HeavyTurret&&
                    !target.HelicopterGunner&&!target.GroundVehicleBody&&!target.DroneRoot;
                bool droneRoot=target.DroneRoot&&target.PartComponentFileId==6544804&&
                    target.PassengerRole==null&&target.RepairDronePathIndex==null&&
                    !target.Decoy&&!target.ArmyInfantry&&!target.HeavyTurret&&
                    !target.HelicopterGunner&&!target.GroundVehicleBody&&!target.HelicopterBody;
                bool helicopterGunner=target.HelicopterGunner&&target.PartComponentFileId==0&&
                    target.PassengerRole==null&&target.RepairDronePathIndex==null&&
                    !target.Decoy&&!target.ArmyInfantry&&!target.HeavyTurret&&
                    !target.GroundVehicleBody&&!target.HelicopterBody&&!target.DroneRoot;
                bool assaultGlass=target.AssaultGlass&&target.PartComponentFileId==
                    AssaultHelicopterMeshColliderCatalog.FrontGlassColliderFileId&&
                    target.Layer==8;
                if(!(target.Decoy||target.ArmyInfantry||vehicleBody||repairDrone||passenger||heavyTurret||helicopterBody||droneRoot||helicopterGunner||assaultGlass)||
                   (layerMask&(1u<<target.Layer))==0||
                   !target.Hitbox.OverlapsSphere(origin,radius))continue;
                string identity=repairDrone?"repair-drone:"+target.EntityId+":"+
                    target.RepairDronePathIndex:passenger?
                    "passenger:"+target.EntityId+":"+target.PassengerRole:
                    (target.Decoy?"decoy:":target.ArmyInfantry?"infantry:":
                     heavyTurret?"heavy-turret:":assaultGlass?"assault-glass:":helicopterBody?"helicopter:":
                     droneRoot?"drone:":helicopterGunner?"helicopter-gunner:":"vehicle:")+target.EntityId;
                string collider=identity+":"+target.Hitbox.SourcePath;
                int ordinal=dynamicColliderOrdinals.GetValueOrDefault(collider);
                dynamicColliderOrdinals[collider]=checked(ordinal+1);
                if(ordinal>0)collider+="#"+ordinal;
                result.Add(new ShotgunCollider(Convert.ToHexStringLower(SHA256.HashData(
                    Encoding.UTF8.GetBytes(collider))),identity,target.Hitbox.Center,true));
                if(result.Count>128)throw new InvalidDataException("Shotgun overlap exceeded source candidate bound.");
            }
        return result.AsReadOnly();
    }
}
